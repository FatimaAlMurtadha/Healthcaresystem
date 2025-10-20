using System.ComponentModel.Design;
using App;


/*
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
SystemLogicMenu menu = new SystemLogicMenu();
IUser? active_user = null;
bool running = true;


while (running)
{ // Skapa Welcom menu 
  if (active_user == null)
  {
    System.Console.WriteLine("------------  Health Care System  -------------");
    System.Console.WriteLine("-----------------------------------------------------");
    System.Console.WriteLine("Log in firsta to open the system");
    System.Console.WriteLine();
    System.Console.WriteLine("1. User.");
    System.Console.WriteLine("2. Patient.");
    System.Console.WriteLine("3. Personnel.");
    System.Console.WriteLine("4. Admin");
    System.Console.WriteLine("f. Close");
    System.Console.WriteLine("C. Create account");


    string? input = Console.ReadLine();
    menu.LogInAsUser();
  }  
  
    else
    {
      
        menu.LogInAsUser();                    //frågar efter username/password
        active_user = menu.ActiveUser;         // resultat
        if (active_user?.IsRole(Role.User) == true)
        {
          try { Console.Clear(); } catch { }
          System.Console.WriteLine("------Welcome User ------");
          System.Console.WriteLine("Choose one of the following: ");
          System.Console.WriteLine("1. Request registration: ");
          System.Console.WriteLine("e. log out");
          System.Console.WriteLine("f. Close");
          string? userinput = Console.ReadLine();
          switch (userinput)
          {
            case "1": // request registration
              menu.SendRegistrationRequest();
              break; // slut av request registration

            case "e": // As a user, I need to be able to log out.
              active_user = null;
              break;

            case "f": // close
              running = false;
              break;



            default:
              System.Console.WriteLine("Invalid choice.");
              System.Console.WriteLine("Press ENTER to continue.....");
              Console.ReadLine();
              break;
          }
        }
        
         // resultat
        if (active_user?.IsRole(Role.Patient) == true)
        {
          try { Console.Clear(); } catch { }
          System.Console.WriteLine("------Welcome Patient ------");
          System.Console.WriteLine("Choose one of the following: ");
          System.Console.WriteLine();
          System.Console.WriteLine("1. View your journal. ");
          System.Console.WriteLine("2. Request an appointment");
          System.Console.WriteLine("3. View your sechedule");
          System.Console.WriteLine("e. Log out");
          System.Console.WriteLine("f. Close");
          string? patientinput = Console.ReadLine();

          switch (patientinput)
          {
            case "1": // view journal
              break;
            case "2": // request an appointment
              break;
            case "3": // view sechdule
              break;
            case "e": // Log out
              active_user = null;
              break;
            case "f": // close
              running = false;
              break;
            default:
              System.Console.WriteLine("Invalid choice.");
              System.Console.WriteLine("Press ENTER to continue.....");
              Console.ReadLine();
              break;
          }

        } // slut på patient meny
   
      // Personnel
             // resultat
        if (active_user?.IsRole(Role.Personnel) == true)
        {
          try { Console.Clear(); } catch { }
          System.Console.WriteLine("1. View a patient's journal entries.");
          System.Console.WriteLine("2. Mark journal entries with different levels of read permissions.");
          System.Console.WriteLine("3. Register appointments.");
          System.Console.WriteLine("4. Modify appointments.");
          System.Console.WriteLine("5. Approve appointment requests.");
          System.Console.WriteLine("6. View the schedule of a location.");
          System.Console.WriteLine("7. Log out");
          System.Console.WriteLine("f. Close");
          string? personnelinput = Console.ReadLine();
          switch (personnelinput)
          {
            case "1": // View a patient's journal entries
              break;
            case "2": // Mark Journal entries
              break;
            case "3": // Register appointment
              break;
            case "4": // Modify appointment
              break;
            case "5": // Approve appointment request
              break;
            case "6": // View schedule of location
              break;
            case "7": // Log out
              break;
            case "f": // Close
              break;
            default:
              System.Console.WriteLine("Invalid choice.");
              System.Console.WriteLine("Press ENTER to continue.....");
              Console.ReadLine();
              break;
          }

        } // slut på Personnel meny
             // resultat
        if (active_user?.IsRole(Role.Main_Admin) == true)
        {
          try { Console.Clear(); } catch { }
          System.Console.WriteLine("MainAdmin menue");
          System.Console.WriteLine("2. Accept Requests");
          string? mainadmininput = Console.ReadLine();
          switch (mainadmininput)
          {
            case "1":
              break;
            default:
              System.Console.WriteLine("Invalid choice.");
              System.Console.WriteLine("Press ENTER to continue.....");
              Console.ReadLine();
              break;

            case "2":
              menu.Accept_requests();
              break;

          }

        } // slut på Main Admin meny 
        //Fixa case för Local Admin pls :D
        if (active_user!.IsRole(Role.Local_Admin))
        {
          try { Console.Clear(); } catch { }
          System.Console.WriteLine("LocalAdmin menue");
          string? mainadmininput = Console.ReadLine();
          switch (mainadmininput)
          {
          
            default:
              System.Console.WriteLine("Invalid choice.");
              System.Console.WriteLine("Press ENTER to continue.....");
              Console.ReadLine();
              break;

            case "2":
              menu.Make_Personnel();
              break;
          }

        } // slut på Local Admin meny


    }



  }






static void Add_Locations() // kan inte fixa denna just nu då locations är ej fungerande just nu
{
    


}