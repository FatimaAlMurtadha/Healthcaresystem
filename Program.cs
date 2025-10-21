using System.ComponentModel.Design;
using App;




// En lista på alla registration requests


SystemLogicMenu menu = new SystemLogicMenu();
IUser? active_user = null;
bool running = true;


while (running)
{ // Create Welcome menu 
  if (active_user == null)
  {
    System.Console.WriteLine("------------  Health Care System  -------------");
    System.Console.WriteLine("-----------------------------------------------------");
    System.Console.WriteLine("-----Log in ---------");
     menu.LogInAsUser();

    string? input = Console.ReadLine();
    switch (input)
    {
      case "1":
        menu.LogInAsUser();                    //frågar efter username/password
        active_user = menu.ActiveUser;         // resultat
        if (active_user?.IsRole(Role.User) == true)
        {
          try { Console.Clear(); } catch { }
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
        menu.LogInAsUser();                    //frågar efter username/password
        active_user = menu.ActiveUser;         // resultat
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
        break;
      case "3": // Personnel
        menu.LogInAsUser();                    //frågar efter username/password
        active_user = menu.ActiveUser;         // resultat
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
        break;
      case "4": // Main Admin
        menu.LogInAsUser();                    //frågar efter username/password
        active_user = menu.ActiveUser;         // resultat
        if (active_user?.IsRole(Role.Main_Admin) == true)
        {
          try { Console.Clear(); } catch { }
          System.Console.WriteLine("Main Admin menu");
          System.Console.WriteLine("1. Give admins the permission to handle registrations");
          System.Console.WriteLine("2. Give admins the permission to add locations");
          System.Console.WriteLine("3. Assign admins to certain regions");
          System.Console.WriteLine("4. Give admins the permission to to handle the permission system");
          System.Console.WriteLine("5. Give admins the permission to create personell accounts");
          System.Console.WriteLine("e. Log out");
          System.Console.WriteLine("f. Close");
          string? mainadmininput = Console.ReadLine();
          switch (mainadmininput)
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

           
            
            
            default:
              System.Console.WriteLine("Invalid choice.");
              System.Console.WriteLine("Press ENTER to continue.....");
              Console.ReadLine();
              break;
          }
          

        } // slut på Main Admin meny 

        break;
        case "5": // Local admin
        menu.LogInAsUser();
        active_user = menu.ActiveUser;
        if (active_user?.IsRole(Role.Local_Admin) == true)

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

              menu.Accept_requests();
              break;
            default:
              System.Console.WriteLine("Invalid choice.");
              System.Console.WriteLine("Press ENTER to continue.....");
              Console.ReadLine();
              break;

            case "2":
              menu.Make_Personnel();
              break;
            case "3":

              break;
           


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



 // slut på else satsen som öppnar systemet




   









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