using App;


/*
As a user, I need to be able to log in.

As a user, I need to be able to log out.

As a user, I need to be able to request registration as a patient.

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

IUser? active_user = null;
bool running = true;

List<IUser> users = new List<IUser>();
users.Add(new User("Fatima", "123")); // Behövs en User Class 




while (running)
{ // Skapa Welcom menu 
  if (active_user == null)
  {
    System.Console.WriteLine("------------  Health Care System  -------------");
    System.Console.WriteLine("-----------------------------------------------------");
    System.Console.WriteLine("Log in firsta to open the system");
    System.Console.WriteLine();
  
    // Loga in för att öpnna systemet
    System.Console.WriteLine("Username: ");
    string? username = Console.ReadLine();

    Console.Clear();
    System.Console.WriteLine("Password: ");
    string? password = Console.ReadLine();
    Console.Clear();

    // foreach loop för att kolla om TryLogIns Info är korrekt
    foreach (IUser user in users)
    {
      if (user.TryLogin(username, password))
      {
        active_user = user;
        break;
      }
    }

  }
  // Else satsen Öppnar menyer beroende på Role "Vem som är inloggad"
  else
  {
    Console.Clear();
    System.Console.WriteLine("------------Welcom to Health Care System-------------");
    System.Console.WriteLine("-----------------------------------------------------");
    // Här Kollar vi Role för att öpnna meny beroende på role
    if (active_user.IsRole(Role.User))
    {
      System.Console.WriteLine("------Welcome User ------");
      System.Console.WriteLine("Choose one of the following: ");

      System.Console.WriteLine("1. Request registration: ");
      System.Console.WriteLine("2. log out");
      System.Console.WriteLine("3. Quit");
      string? input = Console.ReadLine();
      switch (input)
      {
        case "1": // request registration
          break;

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

    } // slut på user meny
    if (active_user.IsRole(Role.Main_Admin))
    {


    } // slut på Main Admin meny
    if (active_user.IsRole(Role.Local_Admin))
    {

    } // slut på Local Admin meny
    if (active_user.IsRole(Role.Personnel))
    {

    } // slut på Personnel meny
    if (active_user.IsRole(Role.Patient))
    {

    } // slut på patient meny


  } // slut på else satsen som öppnar systemet

}






static void Give_Local_Admin(List<IUser> users)// detta kontot finns men det blir en local_Admin
{
  System.Console.WriteLine("Please enter the name of the person who you wants to be a Local_Admin");
  string username = Console.ReadLine()!;
  System.Console.WriteLine("please enter the password of that person");
  string password = Console.ReadLine()!;
  foreach (IUser user in users)
  {
    if (user.TryLogin(username, password))
    {
      user.IsRole(Role.Local_Admin);

    }


  }
}

static void Make_Local_Admin(List<IUser> users)
{
    System.Console.WriteLine("Please enter the name of the account");
  string username = Console.ReadLine()!;
  System.Console.WriteLine("Please enter the name of the account");
  string password = Console.ReadLine()!;
  users.Add(new User(username, password));
}



static void Add_Locations() // kan inte fixa denna just nu då locations är ej fungerande just nu
{
    


}