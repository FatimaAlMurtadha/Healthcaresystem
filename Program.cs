using System.Diagnostics;
using App;


/*


As a user, I need to be able to log out.
As an admin with sufficient permissions, I need to be able to give admins the permission to handle the permission system, in fine granularity.

As an admin with sufficient permissions, I need to be able to assign admins to certain regions.

As an admin with sufficient permissions, I need to be able to give admins the permission to handle registrations.

As an admin with sufficient permissions, I need to be able to give admins the permission to add locations.

As an admin with sufficient permissions, I need to be able to give admins the permission to create accounts for personnel.

As an admin with sufficient permissions, I need to be able to give admins the permission to view a list of who has permission to what.

As an admin with sufficient permissions, I need to be able to add locations.

As an admin with sufficient permissions, I need to be able to accept user registration as patients.

As an admin with sufficient permissions, I need to be able to deny user registration as patients.

As an admin with sufficient permissions, I need to be able to create accounts for personnel.

As an admin with sufficient permissions, I need to be able to view a list of who has permission to what.

As personnel with sufficient permissions, I need to be able to view a patients journal entries.

As personnel with sufficient permissions, I need to be able to mark journal entries with different levels of read permissions.

As personnel with sufficient permissions, I need to be able to register appointments.

As personnel with sufficient permissions, I need to be able to modify appointments.

As personnel with sufficient permissions, I need to be able to approve appointment requests.

As personnel with sufficient permissions, I need to be able to view the schedule of a location.

As a patient, I need to be able to view my own journal.

As a patient, I need to be able to request an appointment.

As a logged in Patient, I need to be able to view my schedule.
*/

// En lista på alla registration requests

SystemLogicMenu menu = new SystemLogicMenu();
IUser? active_user = null;
bool running = true;

<<<<<<< HEAD
List<IUser> users = new List<IUser>();
users.Add(new User("Fatima", "123")); // Behövs en User Class 
List<List<IUser>> listlocation = new List<List<IUser>>();

=======
>>>>>>> 3da81084e1abb0f355d0fd69e3781f8f62bc69f3

while (running)
{ // Skapa Welcom menu 
  if (active_user == null)
  {
    System.Console.WriteLine("------------  Health Care System  -------------");
    System.Console.WriteLine("-----------------------------------------------------");
    System.Console.WriteLine("Log in As: ");
    System.Console.WriteLine();
<<<<<<< HEAD

    // Loga in för att öpnna systemet
    System.Console.WriteLine("Username: ");
    string? username = Console.ReadLine();

    Console.Clear();
    System.Console.WriteLine("Password: ");
    string? password = Console.ReadLine();
    Console.Clear();

    // foreach loop för att kolla om TryLogIns Info är korrekt
    foreach (IUser user in users)
=======
    System.Console.WriteLine("1. User.");
    System.Console.WriteLine("2. Patient.");
    System.Console.WriteLine("3. Personnel.");
    System.Console.WriteLine("4. Admin");
    string? input = Console.ReadLine();
    switch(input)
>>>>>>> 3da81084e1abb0f355d0fd69e3781f8f62bc69f3
    {
      case "1": // User
      if (active_user.IsRole(Role.User))
        {
          System.Console.WriteLine("------Welcome User ------");
          System.Console.WriteLine("Choose one of the following: ");

          System.Console.WriteLine("1. Request registration: ");
          System.Console.WriteLine("2. log out");
          System.Console.WriteLine("3. Quit");
          string? userinput = Console.ReadLine();
          switch (input)
          {
            case "1": // request registration
              menu.SendRegistrationRequest();
              break; // slut av request registration

            case "2": // log out
              active_user = null;
              break;

            case "3": // quit
              running = false;
              break;

            default:
              System.Console.WriteLine("Invalid input. Press Enter to continue");

              break;
          }
        }
        break;
      case "2": // Patient
        if (active_user.IsRole(Role.Patient))
        {

        } // slut på patient meny
        break;
      case "3": // Personnel
        if (active_user.IsRole(Role.Personnel))
        {

        } // slut på Personnel meny
        break;
      case "4": // Admin
        if (active_user.IsRole(Role.Main_Admin))
        {


        } // slut på Main Admin meny
        if (active_user.IsRole(Role.Local_Admin))
        {

        } // slut på Local Admin meny
        break;

    }
  }
  // Else satsen Öppnar menyer beroende på Role "Vem som är inloggad"
  else
  {
    Console.Clear();
    System.Console.WriteLine("------------Welcom to Health Care System-------------");
    System.Console.WriteLine("-----------------------------------------------------");
    // Här Kollar vi Role för att öpnna meny beroende på role

    
    
   


  } // slut på else satsen som öppnar systemet

}











static void Make_Personnel(List<IUser> users)
{
  System.Console.WriteLine("Please enter the name of the account");
  string username = Console.ReadLine()!;
  System.Console.WriteLine("Please enter the name of the account");
  string password = Console.ReadLine()!;
  users.Add(new Personnel(username, password));


}


static void Add_Locations() // kan inte fixa denna just nu då locations är ej fungerande just nu
{
    


}