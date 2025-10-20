using System;
using System.IO;
using System.Collections.Generic;

namespace App
{
    public static class AppointmentMenu
    {
        public static void Patient_RequestAppointment()
        {
            Console.Write("Enter your username: "); //För .txt i appointments. !! Vi kan använda getter om det finns tid över. /Oskar
            string patient = Console.ReadLine();

            Console.Write("Enter date/time (Skriv fritext): "); //Vi kan också använda set tid values. Just nu så är det fritext, tlx "November 5:e tack"
            string when = Console.ReadLine();

            Console.Write("Personnel name: ");
            string personnel = Console.ReadLine();

            bool ok = false;
            if (File.Exists("Users.txt"))
            {
                string[] lines = File.ReadAllLines("Users.txt");
                int i = 0;
                while (i < lines.Length)
                {
                    string[] p = lines[i].Split(',');
                    if (p.Length >= 3 && p[0] == personnel && p[2] == "Personnel")
                    {
                        ok = true;
                        break;
                    }
                    i++;
                }
            }

            if (!ok)
            {
                Console.WriteLine("No such personnel.");
                Console.WriteLine("Press ENTER to continue...");
                Console.ReadLine();   //  softlock issue - still ongoing
                return;
            }

            string id = AppointmentStorage.NewRequest(patient, personnel, when);
            Console.WriteLine("Request sent. ID: " + id);
            Console.WriteLine("Press ENTER to continue...");
            Console.ReadLine();      
        }

        public static void Patient_ViewSchedule()
        {
            Console.Write("Enter your username: ");
            string name = Console.ReadLine();

            List<Appointment> list = AppointmentStorage.LoadForUser(name);
            bool any = false;
            int i = 0;
            while (i < list.Count)
            {
                Appointment a = list[i];
                if (a.Status == AppointmentStatus.Approved)
                {
                    Console.WriteLine(a.When + " | " + a.Patient + " ↔ " + a.Personnel + " (#" + a.Id + ")");
                    any = true;
                }
                i++;
            }
            if (!any) Console.WriteLine("No approved appointments yet.");
            Console.WriteLine("Press ENTER to continue...");
            Console.ReadLine();
        }

        public static void Personnel_ViewSchedule()
        {
            Console.Write("Enter your username: ");
            string name = Console.ReadLine();

            List<Appointment> list = AppointmentStorage.LoadForUser(name);
            bool any = false;
            int i = 0;
            while (i < list.Count)
            {
                Appointment a = list[i];
                if (a.Status == AppointmentStatus.Approved)
                {
                    Console.WriteLine(a.When + " | " + a.Patient + " ↔ " + a.Personnel + " (#" + a.Id + ")");
                    any = true;
                }
                i++;
            }

            if (!any)
                Console.WriteLine("No approved appointments yet.");

            Console.WriteLine("Press ENTER to continue...");
            Console.ReadLine();
        }

        public static void Personnel_ApproveRequests()
        {
            Console.Write("Your username (personnel): ");
            string me = Console.ReadLine();

            List<Appointment> pending = AppointmentStorage.PendingForPersonnel(me);
            if (pending.Count == 0)
            {
                Console.WriteLine("No requests.");
                Console.WriteLine("Press ENTER to continue...");
                Console.ReadLine();
                return;
            }

            int i = 0;
            while (i < pending.Count)
            {
                Appointment a = pending[i];
                Console.WriteLine((i + 1) + ". " + a.Id + " | " + a.Patient + " → " + a.Personnel + " @ " + a.When);
                i++;
            }

            Console.Write("Pick number: ");
            int pick;
            if (!int.TryParse(Console.ReadLine(), out pick)) return;
            if (pick < 1 || pick > pending.Count) return;

            Console.Write("Approve (y/n)? ");
            string yn = Console.ReadLine();
            AppointmentStatus status = (yn == "y" || yn == "Y") ? AppointmentStatus.Approved : AppointmentStatus.Denied;

            AppointmentStorage.UpdateStatus(pending[pick - 1].Id, status);
            Console.WriteLine("Updated.");
            Console.WriteLine("Press ENTER to continue...");
            Console.ReadLine();
        }

        public static void LocalAdmin_ApproveAny()
        {
            List<Appointment> all = AppointmentStorage.PendingAll();
            if (all.Count == 0)
            {
                Console.WriteLine("No pending requests.");
                Console.WriteLine("Press ENTER to continue...");
                Console.ReadLine();
                return;
            }

            int i = 0;
            while (i < all.Count)
            {
                Appointment a = all[i];
                Console.WriteLine((i + 1) + ". " + a.Id + " | " + a.Patient + " → " + a.Personnel + " @ " + a.When);
                i++;
            }

            Console.Write("Pick number: ");
            int pick;
            if (!int.TryParse(Console.ReadLine(), out pick)) return;
            if (pick < 1 || pick > all.Count) return;

            Console.Write("Approve (y/n)? ");
            string yn = Console.ReadLine();
            AppointmentStatus status = (yn == "y" || yn == "Y") ? AppointmentStatus.Approved : AppointmentStatus.Denied;

            AppointmentStorage.UpdateStatus(all[pick - 1].Id, status);
            Console.WriteLine("Updated.");
            Console.WriteLine("Press ENTER to continue...");
            Console.ReadLine();
        }
    }
}
