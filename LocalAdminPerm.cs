namespace App;

class Local_Admin : IUser
{
    private string admin_username;
    private string _password;
    public string? Region;




    public Local_Admin(string? username, string? password, string? region)
    {
        admin_username = username;
        _password = password;
        Region = region;


    }

    public bool TryLogin(string username, string password)
    {
        return username == admin_username && password == _password;
    }

    public bool IsRole(Role role)
    {
        return Role.Local_Admin == role;
    }

    public Role GetRole()
    {
        return Role.Local_Admin;
    }




}





class Location
{
    public string Name;
    public string Hospital;

    public Location(string name, string hospital)
    {
        Name = name;
        Hospital = hospital;
    }

    public override string ToString()
    {
        return Name + " (Sjukhus: " + Hospital + ")";
    }
}




    //Personal konto
    class PersonnelAccount
    {
        public string Email;
        public string Password;

        public PersonnelAccount(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }



   
    class Local_Admin_Permission
    {
        
        public static List<Location> Locations = new List<Location>();
        public static List<PersonnelAccount> Personnels = new List<PersonnelAccount>();
    

        public static bool NewLocation(string LocationName, string HospitalName)
        {
           
            Locations.Add(new Location(LocationName, HospitalName));
            Console.WriteLine("Ny plats: " + LocationName + " (" + HospitalName + ")");
            return true;
        }

        // Visar alla platser
        public static void ShowLocations()
        {
            if (Locations.Count == 0)
            {
                Console.WriteLine("Inga platser ännu.");
                return;
            }

            Console.WriteLine("Platser:");
            int i = 0;
            while (i < Locations.Count)
            {
                Console.WriteLine("- " + Locations[i].ToString());
                i = i + 1;
            }
        }

   
        public static bool NewPersonnel(string personnelemail, string personnelpassword)
        {

            Personnels.Add(new PersonnelAccount(personnelemail, personnelpassword));
            Console.WriteLine("Nytt konto för personalen: " + personnelemail);
            return true;
        }
      

       
    }
