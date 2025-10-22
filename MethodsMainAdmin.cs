namespace App;
// 1. 
User.cs 

 return (_permissions & permission) == permission;
    }
*/

    public override string ToString()
{
  return $"{_username} ({_role})";
}
}

Program.cs


             case "e": // Log out
            active_user = null;

            case "f": // close
  running = false;

              System.Console.WriteLine("Invalid choice.");
  System.Console.WriteLine("Press ENTER to continue.....");
  Console.ReadLine();

  break;
}

//3. 
program.cs
{
  System.Console.WriteLine("------------  Health Care System  -------------");
  System.Console.WriteLine("-----------------------------------------------------");
  System.Console.WriteLine("Log in firsta to open the system");
  System.Console.WriteLine("Log in as :   ---  or create an account ");
  System.Console.WriteLine();
  System.Console.WriteLine("1. User.");
  System.Console.WriteLine("2. Patient.");

// 4.
Program.cs


while (running)
  { // Skapa Welcom menu 
    { // Create Welcome menu 
      if (active_user == null)
      {
        System.Console.WriteLine("------------  Health Care System  -------------");

    System.Console.WriteLine("1. User.");
        System.Console.WriteLine("2. Patient.");
        System.Console.WriteLine("3. Personnel.");
        System.Console.WriteLine("4. Admin");
        System.Console.WriteLine("4. Main admin");
        System.Console.WriteLine("5. Local admin");
        System.Console.WriteLine("f. Close");
        System.Console.WriteLine("C. Create account");
        string? input = Console.ReadLine();

          try { Console.Clear(); } catch { }
        System.Console.WriteLine("------Welcome User ------");
        System.Console.WriteLine("Choose one of the following: ");

        System.Console.WriteLine("1. Request registration: ");

        System.Console.WriteLine("1. Request registration as patient: ");
        System.Console.WriteLine("e. log out");
        System.Console.WriteLine("f. Close");
        string? userinput = Console.ReadLine();

            case "1": // view journal
          break;
        case "2": // request an appointment
          AppointmentMenu.Patient_RequestAppointment();
          break;
        case "3": // view sechdule
          AppointmentMenu.Patient_ViewSchedule();
          break;
        case "e": // Log out
          active_user = null;


        } // slut på patient meny
        break;
case "3": // Personnel
          menu.LogInAsUser();                    //frågar efter username/password
          active_user = menu.ActiveUser;         // resultat

          if (active_user?.IsRole(Role.Personnel) == true)
          {
            bool personnelRunning = true;
            while (personnelRunning)
            {
              try { Console.Clear(); } catch { }
              System.Console.WriteLine("1. View a patient's journal entries.");
              System.Console.WriteLine("2. Mark journal entries with different levels of read permissions.");
              System.Console.WriteLine("3. Register appointments.");
              System.Console.WriteLine("4. Modify appointments.");
              System.Console.WriteLine("5. Approve appointment requests.");
              System.Console.WriteLine("6. View the schedule.");
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
                  AppointmentMenu.Personnel_ApproveRequests();
                  break;
                case "6": // View schedule
                  AppointmentMenu.Personnel_ViewSchedule();
                  break;
                case "7": // Log out
                  active_user = null;
                  personnelRunning = false; // return to main menu
                  break;
                case "f": // Close
                  running = false;
                  personnelRunning = false;
                  break;
                default:
                  System.Console.WriteLine("Invalid choice.");
                  System.Console.WriteLine("Press ENTER to continue.....");
                  Console.ReadLine();
                  break;
              }
            }
          } // slut på Personnel meny
          break;
        case "4": // Admin
        case "3": // Personnel
          menu.LogInAsUser();                    //frågar efter username/password
          active_user = menu.ActiveUser;         // resultat
          if (active_user?.IsRole(Role.Main_Admin) == true)
            if (active_user?.IsRole(Role.Personnel) == true)
            {
              try { Console.Clear(); } catch { }
              System.Console.WriteLine("MainAdmin menue");
              System.Console.WriteLine("2. Accept Requests");
              string? mainadmininput = Console.ReadLine();
              switch (mainadmininput)
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
                case "1":
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


          } // slut på Main Admin meny 
            //Fixa case för Local Admin pls :D
          if (active_user!.IsRole(Role.Local_Admin))

            break;
        case "5": // Local admin
          menu.LogInAsUser();
          active_user = menu.ActiveUser;
          if (active_user?.IsRole(Role.Local_Admin) == true)

          {
            try { Console.Clear(); } catch { }
            System.Console.WriteLine("LocalAdmin menue");
            System.Console.WriteLine("LocalAdmin menu");
            System.Console.WriteLine("1. Handle patient registration");
            System.Console.WriteLine("2. Create accounts for personell");
            System.Console.WriteLine("3. Add locations");
            System.Console.WriteLine("e. Log out");
            System.Console.WriteLine("f. Close ");
            string? mainadmininput = Console.ReadLine();
            switch (mainadmininput)
            {

            case "2":
              menu.Make_Personnel();
              break;

            case "e": // Log out
              active_user = null;

            case "f": // close
              running = false;


            }

          } // slut på Local Admin meny


 // slut på else satsen som öppnar systemet



static void Make_Personnel(List<IUser> users)
          {
            System.Console.WriteLine("Please enter the name of the account");
            string username = Console.ReadLine()!;
            System.Console.WriteLine("Please enter the name of the account");
            string password = Console.ReadLine()!;
            users.Add(new Personnel(username, password));


          }

// 5
Nya cases
System.Console.WriteLine("3. Assign admins to certain regions");
          System.Console.WriteLine("4. Give admins the permission to to handle the permission system");
          System.Console.WriteLine("5. Give admins the permission to create personell accounts");
          System.Console.WriteLine("6. Log out");
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

            case "e": // Log out
              active_user = null;

            case "f": // close
              running = false;


            default:

              System.Console.WriteLine("1. Handle patient registration");
              System.Console.WriteLine("2. Create accounts for personell");
              System.Console.WriteLine("3. Add locations");
              System.Console.WriteLine("4. Log out");
              System.Console.WriteLine("e. Log out");
              System.Console.WriteLine("f. Close ");
              string? mainadmininput = Console.ReadLine();
              switch (mainadmininput)
              {

                case "2":
                  menu.Make_Personnel();
                  break;

                case "e": // Log out
                  active_user = null;

                case "f": // close
                  running = false;


              }

          } // slut på Local Admin meny
        
// 6.
finslipat menyerna


System.Console.WriteLine("1. User.");
          System.Console.WriteLine("2. Patient.");
          System.Console.WriteLine("3. Personnel.");
          System.Console.WriteLine("4. Admin");
          System.Console.WriteLine("4. Main admin");
          System.Console.WriteLine("5. Local admin");
          System.Console.WriteLine("f. Close");
          System.Console.WriteLine("C. Create account");
          string? input = Console.ReadLine();

          try { Console.Clear(); } catch { }
          System.Console.WriteLine("------Welcome User ------");
          System.Console.WriteLine("Choose one of the following: ");


          System.Console.WriteLine("1. Request registration: ");


          System.Console.WriteLine("1. Request registration as patient: ");
 (sparar ändringar innan pull)
          System.Console.WriteLine("e. log out");
          System.Console.WriteLine("f. Close");
          string? userinput = Console.ReadLine();


        } // slut på Personnel meny
        break;
      case "4": // Admin
        case "4": // Main Admin
          menu.LogInAsUser();                    //frågar efter username/password
          active_user = menu.ActiveUser;         // resultat
          if (active_user?.IsRole(Role.Main_Admin) == true)
          {
            try { Console.Clear(); } catch { }
            System.Console.WriteLine("MainAdmin menue");
            System.Console.WriteLine("Main Admin menu");
            System.Console.WriteLine("1. Give admins the permission to handle registrations");
            System.Console.WriteLine("2. Give admins the permission to add locations");
            System.Console.WriteLine("3. Assign admins to certain regions");
            System.Console.WriteLine("4. Give admins the permission to to handle the permission system");
            System.Console.WriteLine("5. Give admins the permission to create personell accounts");
            System.Console.WriteLine("6. Log out");
            string? mainadmininput = Console.ReadLine();
            switch (mainadmininput)
            {
              case "1":
              case "1": // Give admins the permission to handle registrations
                break;


              default:
                System.Console.WriteLine("Invalid choice.");
                System.Console.WriteLine("Press ENTER to continue.....");
                Console.ReadLine();
                break;
            }


          } // slut på Main Admin meny 
            //Fixa case för Local Admin pls :D
          if (active_user!.IsRole(Role.Local_Admin))

            break;
        case "5": // Local admin
          menu.LogInAsUser();
          active_user = menu.ActiveUser;
          if (active_user?.IsRole(Role.Local_Admin) == true)

          {
            try { Console.Clear(); } catch { }
            System.Console.WriteLine("LocalAdmin menue");
            System.Console.WriteLine("LocalAdmin menu");
            System.Console.WriteLine("1. Handle patient registration");
            System.Console.WriteLine("2. Create accounts for personell");
            System.Console.WriteLine("3. Add locations");
            System.Console.WriteLine("4. Log out");
            string? mainadmininput = Console.ReadLine();
            switch (mainadmininput)
            {
              static void Add_Locations() // kan inte fixa denna just nu då locations är ej fungerande just nu

//  7.

spara ändringar innan pull


while (running)
            { // Skapa Welcom menu 
              { // Create Welcome menu 
                if (active_user == null)
                {
                  System.Console.WriteLine("------------  Health Care System  -------------");

          try { Console.Clear(); } catch { }
                  System.Console.WriteLine("------Welcome User ------");
                  System.Console.WriteLine("Choose one of the following: ");

                  System.Console.WriteLine("f. Close");
                  string? userinput = Console.ReadLine();
                  static void Make_Personnel(List<IUser> users)
            {
              System.Console.WriteLine("Please enter the name of the account");
              string username = Console.ReadLine()!;
              System.Console.WriteLine("Please enter the name of the account");
              string password = Console.ReadLine()!;
              users.Add(new Personnel(username, password));


            }



 