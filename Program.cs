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

As a logged in user, I need to be able to view my schedule.
*/
IUser? active_user = null;
bool running = true;

List<IUser> users = new List<IUser>();

while (running)
{ // Skapa Welcom menu 
  if (active_user == null)
  {
    System.Console.WriteLine("------------Welcom to Health Care System-------------");
    System.Console.WriteLine("-----------------------------------------------------");
    System.Console.WriteLine("Log in firsta to open the system");

else
{
      System.Console.WriteLine("Username: ");
      string? username = Console.ReadLine();

      System.Console.WriteLine("Password: ");
      string? password = Console.ReadLine();
      if (username != "" && password != null && password != "" && password != null)
      {
        users.Add(new IUser(username, password));

      }
      System.Console.WriteLine("1. Request registration: ");
      System.Console.WriteLine("2. log out");
      System.Console.WriteLine("3. Quit");
      string? input = Console.ReadLine();
      switch (input)
      {
        case "1": // request registration
          break;

        case "2": // log out

          break;

        case "3": // quit
          break;

        default:
        System.Console.WriteLine("Invalid input. Press Enter to continue");
          
           break;
      }

   
   }
  }
}

