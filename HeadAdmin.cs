namespace App
{
    public class Main_Admin : IUser
    {
        private string _userName;
        private string _password;

        public Main_Admin(string username, string password)
        {
            _userName = username;
            _password = password;
        }

        public bool TryLogin(string username, string password)
        {
            return username == _userName && password == _password;
        }

        public bool IsRole(Role role)
        {
            return role == Role.Main_Admin;
        }

        public Role GetRole()
        {
            return Role.Main_Admin;
        }

        public override string ToString()
        {
            return _userName + " (Main_Admin)";
        }
    }

   
    public class LocAdmin
    {
        public string Email;
        public string Region;
        public bool AddLocationPerm;
        public bool HandleRegistrationPerm;

        public LocAdmin(string email, string region, bool addLoc, bool handleReg)
        {
            Email = email;
            Region = region;
            AddLocationPerm = addLoc;
            HandleRegistrationPerm = handleReg;
        }

        public override string ToString()    
        {
            string add = AddLocationPerm ? "1" : "0";        // 1 true, 0 false
            string handle = HandleRegistrationPerm ? "1" : "0";
            string line = Email + "," + Region + "," + add + "," + handle;
            return line;
        }
    }


    public static class MainAdminService
    {
        private const string PermissionsFile = "Permissions.txt"; 

        
        public static List<LocAdmin> LoadAll()
        {
            List<LocAdmin> list = new List<LocAdmin>();

            if (!File.Exists(PermissionsFile))
            {
                File.WriteAllText(PermissionsFile, "");   // skapa tom fil
                return list;
            }

            string[] lines = File.ReadAllLines(PermissionsFile);
            int i = 0;
            while (i < lines.Length)
            {
                string line = lines[i];
                if (!string.IsNullOrWhiteSpace(line))
                {
                    string[] p = line.Split(','); // p[0]=email, p[1]=region, p[2]=add, p[3]=handle
                    if (p.Length >= 4)
                    {
                        bool add = (p[2] == "1");
                        bool handle = (p[3] == "1");
                        LocAdmin entry = new LocAdmin(p[0], p[1], add, handle);
                        list.Add(entry);
                    }
                }
                i = i + 1;
            }
            return list;
        }

        
        public static void SaveAll(List<LocAdmin> list)       // Sparar hela listan till fil och ersätter innehållet
        {
            List<string> lines = new List<string>();
            int i = 0;
            while (i < list.Count)
            {
                string row = list[i].ToString(); // "email,region,1/0,1/0"
                lines.Add(row);
                i = i + 1;
            }
            File.WriteAllLines(PermissionsFile, lines.ToArray());
        }

        
        public static bool AddLocalAdmin(string email)        // Lägger till Local Admin
        {
            if (string.IsNullOrWhiteSpace(email)) return false;

            List<LocAdmin> all = LoadAll();
            int i = 0;
            while (i < all.Count)
            {
                if (all[i].Email == email) return false;         // dubblett
                i = i + 1;
            }

            all.Add(new LocAdmin(email, "", false, false));
            SaveAll(all);
            Console.WriteLine("Lokal admin tillagd: " + email);
            return true;
        }

        
        public static bool AssignRegion(string email, string region)       // Sätter region på en Local Admin
        {
            if (string.IsNullOrWhiteSpace(email)) return false;
            if (string.IsNullOrWhiteSpace(region)) return false;

            List<LocAdmin> all = LoadAll();
            int i = 0;
            while (i < all.Count)
            {
                if (all[i].Email == email)
                {
                    all[i].Region = region;
                    SaveAll(all);
                    Console.WriteLine("Region \"" + region + "\" tilldelad till " + email);
                    return true;
                }
                i = i + 1;
            }
            Console.WriteLine("Hittade ingen lokal admin: " + email);
            return false;
        }

        
        public static bool GivePermToAddLocation(string email)    // AddLocations
        {
            List<LocAdmin> all = LoadAll();
            int i = 0;
            while (i < all.Count)
            {
                if (all[i].Email == email)
                {
                    all[i].AddLocationPerm = true;
                    SaveAll(all);
                    Console.WriteLine(email + " kan nu lägga till platser.");
                    return true;
                }
                i = i + 1;
            }
            Console.WriteLine("Hittade ingen lokal admin: " + email);
            return false;
        }

        
        public static bool GivePermToHandle(string email)     // handle registrations
        {
            List<LocAdmin> all = LoadAll();
            int i = 0;
            while (i < all.Count)
            {
                if (all[i].Email == email)
                {
                    all[i].HandleRegistrationPerm = true;
                    SaveAll(all);
                    Console.WriteLine(email + " kan nu hantera registreringar.");
                    return true;
                }
                i = i + 1;
            }
            Console.WriteLine("Hittade ingen lokal admin: " + email);
            return false;
        }

        
        public static bool AllPerm(string email, string perm_name)     // Kollar om en Local Admin har en viss permission
        {
            List<LocAdmin> all = LoadAll();
            int i = 0;
            while (i < all.Count)
            {
                if (all[i].Email == email)
                {
                    if (perm_name == "AddLocations") return all[i].AddLocationPerm;
                    if (perm_name == "HandleRegistrations") return all[i].HandleRegistrationPerm;
                }
                i = i + 1;
            }
            return false;
        }

        
        public static void ListLocalAdmins()       // Skriver ut alla Local Admins 
        {
            List<LocAdmin> all = LoadAll();

            if (all.Count == 0)
            {
                Console.WriteLine("Inga lokala admins.");
                return;
            }

            Console.WriteLine("Lokala admins:");
            int i = 0;
            while (i < all.Count)
            {
                LocAdmin a = all[i];
                string perms = "";
                if (a.AddLocationPerm) perms = perms + "[AddLocations] ";
                if (a.HandleRegistrationPerm) perms = perms + "[HandleRegistrations] ";
                if (perms == "") perms = "(inga)";
                string regionText = string.IsNullOrWhiteSpace(a.Region) ? "(ingen region)" : a.Region;
                Console.WriteLine("- " + a.Email + " | Region: " + regionText + " | " + perms);
                i = i + 1;
            }
        }
    }
}
