using System;
using System.Collections.Generic;
using System.IO;

namespace App;


    static class UserDataManager
    {
        private const string FilePath = "Users.txt"; 
        
        public static void SaveUser(string username, string password, Role role) //Sparar användare i textfilen
        {
            string line = $"{username},{password},{role}";
            File.AppendAllLines(FilePath, new[] { line });
        }

        public static List<IUser> LoadUsers() //Laddar användare från textfilen
        {
            var users = new List<IUser>(); //Fixar lista att fylla på

            if (!File.Exists(FilePath))
                return users;

            foreach (var line in File.ReadAllLines(FilePath))
            {
                var parts = line.Split(',');  //Dela upp varje rad i delar "username,password,role"
                if (parts.Length >= 3 && Enum.TryParse(parts[2], out Role role))
                    users.Add(new User(parts[0], parts[1], role)); // Skapar User-objekt och lägger till i listan
            }

            return users;
        }
    }
