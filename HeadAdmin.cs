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

        public LocAdmin(string email, string region, bool AddLoc, bool HandleReg)
        {
            Email = email;
            Region = region;
            AddLocationPerm = AddLoc;
            HandleRegistrationPerm = HandleReg;
        }

        public override string ToString()
        {
            
            return Email + "," + Region + "," + (AddLocationPerm ? "1" : "0") + "," + (HandleRegistrationPerm ? "1" : "0");
        }
    }
    public static class MainAdminService
    {
        private const string PermissionsFile = "Permissions.txt";

        public static List<LocAdmin> LoadAll()
        {
            var list = new List<LocAdmin>();
            if (!File.Exists(PermissionsFile)) return list;

            string[] lines = File.ReadAllLines(PermissionsFile);
            int i = 0;
            while (i < lines.Length)
            {
                string line = lines[i];
                if (!string.IsNullOrWhiteSpace(line))
                {
                    string[] p = line.Split(',');
                    // förväntat: email,region,add,handle
                    if (p.Length >= 4)
                    {
                        bool add = p[2] == "1";
                        bool handle = p[3] == "1";
                        list.Add(new LocAdmin(p[0], p[1], add, handle));
                    }
                }
                i = i + 1;
            }
            return list;
        }

        
        public static void SaveAll(List<LocAdmin> list)         // Spara alla LocalAdmins till fil
        {
            var lines = new List<string>();
            int i = 0;
            while (i < list.Count)
            {
                lines.Add(list[i].ToString());
                i = i + 1;
            }
            File.WriteAllLines(PermissionsFile, lines.ToArray());
        }

        
        public static bool AddLocalAdmin(string email)      // Lägg till en Local Admin (om inte redan finns)
        {

            List<LocAdmin> all = LoadAll();

            int i = 0;
            while (i < all.Count)
            {
                if (all[i].Email == email) return false; // dubblett
                i = i + 1;
            }

            all.Add(new LocAdmin(email, "", false, false));
            SaveAll(all);
            Console.WriteLine("Lokal admin tillagd: " + email);
            return true;
        }

       
        public static bool AssignRegion(string email, string region)  // region 
        {

            List<LocAdmin> all = LoadAll();
            int i = 0;
            while (i < all.Count)
            {
                if (all[i].Email == email)
                {
                    all[i].Region = region;
                    SaveAll(all);
                    Console.WriteLine("Region \"" + region + "\"  till " + email);
                    return true;
                }
                i = i + 1;
            }
            Console.WriteLine("Hittade ingen lokal admin: " + email);
            return false;
        }

        
        public static bool GivePermToAddLocation(string email)        // AddLocations
        {
            List<LocAdmin> all = LoadAll();
            int i = 0;
            while (i < all.Count)
            {
                if (all[i].Email == email)
                {
                    all[i].AddLocationPerm = true;
                    SaveAll(all);
                    Console.WriteLine( email + "are able to add locations now. ");
                    return true;
                }
                i = i + 1;
            }
            Console.WriteLine("Hittade ingen lokal admin: " + email);
            return false;
        }

        
        public static bool GivePermToHandle(string email)     // HandleRegistrations
        {
            List<LocAdmin> all = LoadAll();
            int i = 0;
            while (i < all.Count)
            {
                if (all[i].Email == email)
                {
                    all[i].HandleRegistrationPerm = true;
                    SaveAll(all);
                    Console.WriteLine( email + "are able to handle the registrations now.");
                    return true;
                }
                i = i + 1;
            }
            Console.WriteLine("Hittade ingen lokal admin: " + email);
            return false;
        }

        
        public static bool AllPerm()
        {
            
        }

        
        public static void ListLocalAdmins()
        {

        }
    }
}
