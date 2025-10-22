using System;
using System.IO;
using System.Globalization;
using System.Collections.Generic;

namespace App
{
    public static class AppointmentMenu
    {
        // Ändra så att vi kan parsa datum/tid. Ingen mer fritext så att vi kan ha en nice UI
        static bool TryParseStart(string text, out DateTime start)
        {
            return DateTime.TryParseExact(
                text,
                "yyyy-MM-dd HH:mm",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out start
            );
        }

        // Satt defaulttid för en appointment till 30 minuter
        static DateTime EndFromStart(DateTime start) => start.AddMinutes(30);

        // Här skriver vi ut en rad i agendan
        static void PrintAgendaLine(Appointment a, DateTime start, DateTime end)
        {
            Console.WriteLine($"{start:ddd dd}  {start:HH:mm}–{end:HH:mm}  {a.Patient} → {a.Personnel}  [{a.Status}]");
            if (!string.IsNullOrWhiteSpace(a.Note))
                Console.WriteLine($"   » {a.Note}");
        }

        public static void Patient_RequestAppointment()
        {
            Console.Write("Enter your username: ");
            string patient = Console.ReadLine();

            Console.WriteLine("Enter date/time in format: yyyy-MM-dd HH:mm");
            Console.Write("When: ");
            string whenText = Console.ReadLine();

            DateTime parsed;
            if (!TryParseStart(whenText, out parsed))
            {
                Console.WriteLine("Invalid format. Example: 2025-11-02 09:30");
                Console.ReadLine();
                return;
            }

            Console.Write("Personnel username: ");
            string personnel = Console.ReadLine();

            // Kollar Users.txt för att se att personnel existerar
            bool ok = false;
            if (File.Exists("Users.txt"))
            {
                foreach (var line in File.ReadAllLines("Users.txt"))
                {
                    var p = line.Split(',');
                    if (p.Length >= 3 && p[0] == personnel && p[2] == "Personnel")
                    {
                        ok = true;
                        break;
                    }
                }
            }
            if (!ok)
            {
                Console.WriteLine("No such personnel.");
                Console.ReadLine();
                return;
            }

            Console.Write("Vad behöver du hjälp med?: ");
            string note = Console.ReadLine();

            // Skriver i AppointmentStorage.NewRequest(patient, personnel, when, note)
            string id = AppointmentStorage.NewRequest(patient, personnel, parsed.ToString("yyyy-MM-dd HH:mm"), note);

            Console.WriteLine($"Request sent! ID: {id}");
            Console.ReadLine();
        }

        public static void Patient_ViewSchedule(string username)
        {
            Console.WriteLine($"== Dina bokningar ({username}) ==");
            List<Appointment> list = AppointmentStorage.LoadForUser(username);

            if (list.Count == 0)
            {
                Console.WriteLine("Inga bokningar ännu.");
                Console.ReadLine();
                return;
            }

            //Om datum går att parsa visar vi sluttid också.
            foreach (var a in list)
            {
                if (TryParseStart(a.When, out var start))
                {
                    var end = EndFromStart(start);
                    Console.WriteLine($"{a.When}–{end:HH:mm}  → {a.Personnel}  [{a.Status}]");
                }
                else
                {
                    // Om något råkar vara felformat -> visa som det är
                    Console.WriteLine($"{a.When}  → {a.Personnel}  [{a.Status}]");
                }

                if (!string.IsNullOrWhiteSpace(a.Note))
                    Console.WriteLine($"   » {a.Note}");
            }

            Console.ReadLine();
        }

        public static void Personnel_ViewSchedule(string username)
        {
         DateTime now = DateTime.Now;

        // Beräkna denna veckas måndag och söndag
         int diff = ((int)now.DayOfWeek + 6) % 7; // Måndag = 0
          DateTime monday = now.Date.AddDays(-diff);
          DateTime from = monday;
         DateTime to = monday.AddDays(7).AddSeconds(-1);

        Console.WriteLine($"== This Week ({username}) ==");

         // Hämta alla bokningar för denna användare
         List<Appointment> list = AppointmentStorage.LoadForUser(username);

       foreach (var a in list)
        {
        if (!TryParseStart(a.When, out var start)) continue;
        if (start >= from && start <= to)
        {
            var end = EndFromStart(start);
            PrintAgendaLine(a, start, end);
        }
          }

      Console.WriteLine("Press ENTER to continue...");
        Console.ReadLine();
}

        public static void Personnel_ApproveRequests(string username)
        {
            List<Appointment> pending = AppointmentStorage.PendingForPersonnel(username);
            if (pending.Count == 0)
            {
                Console.WriteLine("No pending requests.");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("== Pending Requests ==");
            for (int i = 0; i < pending.Count; i++)
            {
                var a = pending[i];
                Console.WriteLine($"{i + 1}. {a.Patient} → {a.Personnel} @ {a.When}");
                if (!string.IsNullOrWhiteSpace(a.Note))
                    Console.WriteLine($"   Note: {a.Note}");
            }

            Console.Write("Pick number: ");
            if (!int.TryParse(Console.ReadLine(), out int pick)) return;
            if (pick < 1 || pick > pending.Count) return;

            Console.Write("Approve (y/n)? ");
            string yn = Console.ReadLine();
            AppointmentStatus status = (yn == "y" || yn == "Y")
                ? AppointmentStatus.Approved
                : AppointmentStatus.Denied;

            AppointmentStorage.UpdateStatus(pending[pick - 1].Id, status);
            Console.WriteLine("Updated!");
            Console.ReadLine();
        }

        public static void LocalAdmin_ManageAppointments()
{
    Console.WriteLine("== Manage All Appointments ==");

    List<Appointment> all = AppointmentStorage.LoadAll(); // loads everything from file
    if (all.Count == 0)
    {
        Console.WriteLine("No appointments in system.");
        Console.ReadLine();
        return;
    }

    // Här sorterar vi med tid (ascending)
    all.Sort((a, b) =>
    {
        if (TryParseStart(a.When, out var t1) && TryParseStart(b.When, out var t2))
            return t1.CompareTo(t2);
        return 0;
    });

    // Visar ALLA bokningar (epic)
    for (int i = 0; i < all.Count; i++)
    {
        var a = all[i];
        if (TryParseStart(a.When, out var start))
        {
            var end = EndFromStart(start);
            Console.WriteLine($"{i + 1}. {start:yyyy-MM-dd HH:mm}–{end:HH:mm}  {a.Patient} → {a.Personnel}  [{a.Status}]");
        }
        else
        {
            Console.WriteLine($"{i + 1}. {a.When}  {a.Patient} → {a.Personnel}  [{a.Status}]");
        }

        if (!string.IsNullOrWhiteSpace(a.Note))
            Console.WriteLine($"   » {a.Note}");
    }

    // Denna del frågar vilken bokning admin vill ändra status på och accept eller deny
    Console.WriteLine();
    Console.Write("Enter number to approve/deny (or press ENTER to exit): ");
    string choice = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(choice)) return;

    if (!int.TryParse(choice, out int pick)) return;
    if (pick < 1 || pick > all.Count) return;

    Appointment selected = all[pick - 1];
    Console.WriteLine($"Selected: {selected.Patient} → {selected.Personnel} @ {selected.When}");
    Console.Write("Approve (y/n)? ");
    string yn = Console.ReadLine();

    AppointmentStatus status = (yn == "y" || yn == "Y")
        ? AppointmentStatus.Approved
        : AppointmentStatus.Denied;

    AppointmentStorage.UpdateStatus(selected.Id, status);
    Console.WriteLine("Updated successfully.");
    Console.ReadLine();
        }

    }
}
