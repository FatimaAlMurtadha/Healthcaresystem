using System;
using System.Collections.Generic;
using System.IO;

namespace App
{
    static class UserDataManager
    {
        private const string FilePath = "Users.txt";

        public static void SaveUser(string username, string password, Role role) //Sparar användare i textfilen
        {
            string line = $"{username},{password},{role}";
            File.AppendAllLines(FilePath, new[] { line });
        }

        public static List<IUser> LoadUsers()
        {
            var users = new List<IUser>();
            if (!File.Exists(FilePath)) return users;

            foreach (var raw in File.ReadAllLines(FilePath))
            {
                var line = raw?.Trim();
                if (string.IsNullOrWhiteSpace(line)) continue;

                var parts = line.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
                if (parts.Length < 3) continue;

                string username = parts[0];
                string password = parts[1];
                string roleText = parts[2];

                if (!Enum.TryParse(roleText, ignoreCase: true, out Role role)) continue;

                IUser u = role switch
                {
                    Role.Patient => new Patient(username, password),
                    Role.Personnel => new Personnel(username, password),
                    Role.Main_Admin => new Main_Admin(username, password),
                    Role.Local_Admin => new Local_Admin(username, password),
                };
                users.Add(u);
            }
            return users;
        }
    }
}