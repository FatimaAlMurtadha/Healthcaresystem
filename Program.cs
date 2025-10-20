using System.ComponentModel.Design;
using App;



<<<<<<< HEAD

// En lista på alla registration requests


=======
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
>>>>>>> main
SystemLogicMenu menu = new SystemLogicMenu();
IUser? active_user = null;
bool running = true;


while (running)
{ // Create Welcome menu 
  if (active_user == null)
  {
    System.Console.WriteLine("------------  Health Care System  -------------");
    System.Console.WriteLine("-----------------------------------------------------");
<<<<<<< HEAD
    System.Console.WriteLine("-----Log in ---------");
    System.Console.WriteLine("Username: ");
    string? username = Console.ReadLine();
    System.Console.WriteLine("Password:");
    string? password = Console.ReadLine();
    // 

    string? input = Console.ReadLine();
    switch (input)
    {
      case "1": // User
        if (active_user.IsRole(Role.User))
        {
          try { Console.Clear(); } catch {}
=======
    System.Console.WriteLine("Log in firsta to open the system");
    System.Console.WriteLine();
    System.Console.WriteLine("1. User.");
    System.Console.WriteLine("2. Patient.");
    System.Console.WriteLine("3. Personnel.");
    System.Console.WriteLine("4. Main admin");
    System.Console.WriteLine("5. Local admin");
    System.Console.WriteLine("f. Close");
    System.Console.WriteLine("C. Create account");
    string? input = Console.ReadLine();
    switch (input)
    {
      case "1":
        menu.LogInAsUser();                    //frågar efter username/password
        active_user = menu.ActiveUser;         // resultat
        if (active_user?.IsRole(Role.User) == true)
        {
          try { Console.Clear(); } catch { }
>>>>>>> main
          System.Console.WriteLine("------Welcome User ------");
          System.Console.WriteLine("Choose one of the following: ");

          System.Console.WriteLine("1. Request registration: ");

          System.Console.WriteLine("1. Request registration as patient: ");
          System.Console.WriteLine("e. log out");
          System.Console.WriteLine("f. Close");
          string? userinput = Console.ReadLine();
          switch (input)
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
        break;
      case "2": // Patient
<<<<<<< HEAD
        if (active_user.IsRole(Role.Patient))
=======
        menu.LogInAsUser();                    //frågar efter username/password
        active_user = menu.ActiveUser;         // resultat
        if (active_user?.IsRole(Role.Patient) == true)
>>>>>>> main
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
        break;
      case "3": // Personnel
<<<<<<< HEAD
        if (active_user.IsRole(Role.Personnel))
=======
        menu.LogInAsUser();                    //frågar efter username/password
        active_user = menu.ActiveUser;         // resultat
        if (active_user?.IsRole(Role.Personnel) == true)
>>>>>>> main
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
        break;
<<<<<<< HEAD
      case "4": // Admin
<<<<<<< HEAD
        if (active_user.IsRole(Role.Main_Admin))
=======
=======
      case "4": // Main Admin
>>>>>>> abaec5c7fb1b33e2fa1d9bb7e83ac14cb56b123b
        menu.LogInAsUser();                    //frågar efter username/password
        active_user = menu.ActiveUser;         // resultat
        if (active_user?.IsRole(Role.Main_Admin) == true)
>>>>>>> main
        {
<<<<<<< HEAD
          try { Console.Clear(); } catch {}
          System.Console.WriteLine("MainAdmin menue");
=======
          try { Console.Clear(); } catch { }
          System.Console.WriteLine("Main Admin menu");
          System.Console.WriteLine("1. Give admins the permission to handle registrations");
          System.Console.WriteLine("2. Give admins the permission to add locations");
          System.Console.WriteLine("3. Assign admins to certain regions");
          System.Console.WriteLine("4. Give admins the permission to to handle the permission system");
          System.Console.WriteLine("5. Give admins the permission to create personell accounts");
          System.Console.WriteLine("e. Log out");
          System.Console.WriteLine("f. Close");
>>>>>>> abaec5c7fb1b33e2fa1d9bb7e83ac14cb56b123b
          string? mainadmininput = Console.ReadLine();
          switch(mainadmininput)
          {
            case "1": // Give admins the permission to handle registrations
              break;

            case "2": //  Give admins the permission to add locations
            break;

            case "3": // Assign admins to certain regions
            break;

            case "4": // Give admins the permission to to handle the permission system
            break;

            case "5": // Give admins the permission to create personell accounts
            break;

             case "e": // Log out
            active_user = null;

            case "f": // close
            running = false;
            
            
            default:
              System.Console.WriteLine("Invalid choice.");
              System.Console.WriteLine("Press ENTER to continue.....");
              Console.ReadLine();
              break;
          }
          

<<<<<<< HEAD
        } // slut på Main Admin meny
        if (active_user.IsRole(Role.Local_Admin))
=======
        } // slut på Main Admin meny 
<<<<<<< HEAD
        //Fixa case för Local Admin pls :D
        if (active_user!.IsRole(Role.Local_Admin))
>>>>>>> main
=======

        break;
        case "5": // Local admin
        menu.LogInAsUser();
        active_user = menu.ActiveUser;
        if (active_user?.IsRole(Role.Local_Admin) == true)

>>>>>>> abaec5c7fb1b33e2fa1d9bb7e83ac14cb56b123b
        {
          try { Console.Clear(); } catch { }
          System.Console.WriteLine("LocalAdmin menu");
          System.Console.WriteLine("1. Handle patient registration");
          System.Console.WriteLine("2. Create accounts for personell");
          System.Console.WriteLine("3. Add locations");
          System.Console.WriteLine("e. Log out");
          System.Console.WriteLine("f. Close ");
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
              menu.Make_Personnel();
              break;

            case "e": // Log out
            active_user = null;

            case "f": // close
            running = false;


          }

        } // slut på Local Admin meny
        break;

      // The rest of the first switch
      case "f": // close
        running = false;
        break;


            case "C":
              menu.Make_account();
            
            
              break;
              
      default:
        System.Console.WriteLine("Invalid choice.");
        System.Console.WriteLine("Press ENTER to continue.....");
        Console.ReadLine();
        break;
    }



  }
  
}


<<<<<<< HEAD
<<<<<<< HEAD
=======
<<<<<<< HEAD
=======
=======

>>>>>>> abaec5c7fb1b33e2fa1d9bb7e83ac14cb56b123b
 // slut på else satsen som öppnar systemet




   
>>>>>>> main









static void Make_Personnel(List<IUser> users)
{
  System.Console.WriteLine("Please enter the name of the account");
  string username = Console.ReadLine()!;
  System.Console.WriteLine("Please enter the name of the account");
  string password = Console.ReadLine()!;
  //users.Add(new Personnel(username, password));


}



static void Add_Locations() // kan inte fixa denna just nu då locations är ej fungerande just nu
{
    


}