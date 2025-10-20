using System;
using System.Collections.Generic;
using System.IO;

namespace App
{
    static class AppointmentStorage
    {
        const string FilePath = "Appointments.txt";

        public static string NewRequest(string patient, string personnel, string whenText)
        {
            var id = GetNextId().ToString();
            var a = new Appointment(id, patient, personnel, whenText, AppointmentStatus.Requested);
            File.AppendAllLines(FilePath, new[] { a.ToString() });
            return id;
        }

        private static int GetNextId()
        {
        if (!File.Exists(FilePath))
        return 1;

        int maxId = 0;
        string[] lines = File.ReadAllLines(FilePath);
        int i = 0;
        while (i < lines.Length)
        {
        var parts = lines[i].Split('|');
        if (parts.Length > 0)
        {
            int id;
            if (int.TryParse(parts[0], out id) && id > maxId)
                maxId = id;
        }
        i++;
        }
        return maxId + 1;
        }


        public static List<Appointment> LoadAll()
        {
            var list = new List<Appointment>();
            if (!File.Exists(FilePath)) return list;

            foreach (var line in File.ReadAllLines(FilePath))
            {
                Appointment a;
                if (Appointment.TryParse(line, out a)) list.Add(a);
            }
            return list;
        }

        public static void SaveAll(List<Appointment> items)
        {
            var lines = new List<string>();
            int i = 0;
            while (i < items.Count) { lines.Add(items[i].ToString()); i++; }
            File.WriteAllLines(FilePath, lines.ToArray());
        }

        public static List<Appointment> LoadForUser(string username)  // for “schedule”
        {
            var result = new List<Appointment>();
            var all = LoadAll();
            int i = 0;
            while (i < all.Count)
            {
                var a = all[i];
                if (a.Patient == username || a.Personnel == username) result.Add(a);
                i++;
            }
            return result;
        }

        public static List<Appointment> PendingForPersonnel(string personnel) // personnel-only view
        {
            var result = new List<Appointment>();
            var all = LoadAll();
            int i = 0;
            while (i < all.Count)
            {
                var a = all[i];
                if (a.Personnel == personnel && a.Status == AppointmentStatus.Requested) result.Add(a);
                i++;
            }
            return result;
        }

        public static List<Appointment> PendingAll() // for Local_Admin
        {
            var result = new List<Appointment>();
            var all = LoadAll();
            int i = 0;
            while (i < all.Count)
            {
                var a = all[i];
                if (a.Status == AppointmentStatus.Requested) result.Add(a);
                i++;
            }
            return result;
        }

        public static bool UpdateStatus(string id, AppointmentStatus status)
        {
            var all = LoadAll();
            int i = 0; bool found = false;  //Vi börjar med index i = 0 och assumar att vi inte har hittat något än bool found = false.
            while (i < all.Count) //Denna loopen fortsätter sålänge i är mindre än antalet appointments (all.count)
            {
                if (all[i].Id == id) { all[i].Status = status; found = true; break; } //För varje appointment i listan  all all[i] öppnar i-th appointment.
                i++; //Om den ID:n matchar det vi söker efter så kan vi sätta status till en ny value, approve or denied. found = true säger att vi har hittat någogt.
            }
            if (found) SaveAll(all);
            return found;
        }
    }
}
