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


IUser? loggedin_user = null;

SystemMenu menu = new SystemMenu();


bool running = true;

while (running)
{
  Console.Clear();

  if (loggedin_user == null)
  {
    System.Console.WriteLine("------------  Health Care System  -------------");
    System.Console.WriteLine("-----------------------------------------------------");
    System.Console.WriteLine("1. Log in.");
    System.Console.WriteLine("2. Request registration as patient: ");
    System.Console.WriteLine("f. close");
    string? input = Console.ReadLine();
    // 
    switch (input)
    {
      // As a user, I need to be able to log in.
      case "1":
        loggedin_user = menu.LogIn();
        break;
      case "2": // As a user, I need to be able to request registration as a patient.
        menu.SendRegistrationRequest();
        break;
      case "f": // Close 
        running = false;
        menu.CloseSystem();
        break;
      default:
        System.Console.WriteLine("Invalid choice. Press ENTER to continue........");
        break;
    }

  }
  else
  {
    switch (loggedin_user.GetRole())
    {
      case Role.Patient:
        Console.WriteLine("-----------Welcome patient-----------");
        System.Console.WriteLine();
        System.Console.WriteLine(" 1. Show my Journal ");
        System.Console.WriteLine(" 2. Book an appointment ");
        System.Console.WriteLine(" 3. Show my schedule ");
        System.Console.WriteLine(" h. Log out  ");
        System.Console.WriteLine(" f. Close  ");
        string? patient_choice = Console.ReadLine();
        switch (patient_choice) // patient choices
        {
          case "1": // show my own journal
            if (menu.HasPermission(Patient.Permissions, Permission.ViewJournals))
            {
              try { Console.Clear(); } catch { }
              menu.ShowMyJournal();
            }
            else
            {
              System.Console.WriteLine("You do not have the permission to view this journal");
            }
            break;
          case "2": // book an appointment
            break;
          case "3": // show my schedule
            break;
          case "h": // log out as a patient
            loggedin_user = null;
            menu.LogOut();

            break;
          case "f": // quit
            running = false;
            menu.CloseSystem();
            break;
          default:
            System.Console.WriteLine("Invalid choice. Press ENTER to continue........");
            break;

        } // slut på patient choices
        break;
      case Role.Personnel:
        Console.WriteLine("----------Welcome personnel---------");
        System.Console.WriteLine(" 1. Show patient's journal entries");
        System.Console.WriteLine(" 2. Mark journal entries with different levels of read permissions");
        System.Console.WriteLine(" 3. Book patient's appointments ");
        System.Console.WriteLine(" 4. Modify appointments");
        System.Console.WriteLine(" 5. Approve appointments requests");
        System.Console.WriteLine(" 6. Show schedule for my hospital ");
        System.Console.WriteLine(" h. Log out  ");
        System.Console.WriteLine(" f. Close");
        string? personnel_choice = Console.ReadLine();
        switch (personnel_choice) // start of personnel switch choices
        {
          case "1": // show 
            break;
          case "2": // create journal note

            if (loggedin_user is Personnel personnel)
            {
              if (personnel.HasPermission(Permission.Create_Journal_note))
              {
                //menu.CreateJournalNote();
              }
              else
              {
                System.Console.WriteLine("You do not have the permission to manage the journal");
              }
            }
            else
            {
              System.Console.WriteLine("Current user is not personnel");
            }

            break;

          case "h": // log out 
            loggedin_user = null;
            menu.LogOut();
            break;
          case "f": // quit
            running = false;
            menu.CloseSystem();
            break;
          default:
            System.Console.WriteLine("Invalid choice. Press ENTER to continue........");
            break;



        } // end of personnel switch choices
        break;
      case Role.Main_Admin:
        Console.WriteLine("----------Welcome main admin--------");
        System.Console.WriteLine(" 1. Handle the system permission");
        System.Console.WriteLine(" 2. ");
        System.Console.WriteLine(" 3. ");
        System.Console.WriteLine(" h. Log out");
        System.Console.WriteLine(" f. Close");
        string? mainAdmin_choice = Console.ReadLine();

        switch (mainAdmin_choice) // start of main admin switch choices
        {
          case "1":
            break;

          case "h": // log out 
            loggedin_user = null;
            menu.LogOut();
            break;
          case "f": // quit
            running = false;
            menu.CloseSystem();
            break;
          default:
            System.Console.WriteLine("Invalid choice. Press ENTER to continue........");
            break;



        } // end of main admin switch choices

        break;
      case Role.Local_Admin:
        Console.WriteLine("---------Welcome local admin---------");
        System.Console.WriteLine(" 1. Create accounts for personell ");
        System.Console.WriteLine(" 2. Accept/deny user registration as patients ");
        System.Console.WriteLine(" 3. Add locations ");
        System.Console.WriteLine(" 4. Handle permission system ");
        System.Console.WriteLine(" 5. Handle registrations  ");
        System.Console.WriteLine(" 6. Fix personell status  ");
        System.Console.WriteLine(" h. Log out");
        System.Console.WriteLine(" f. Close");
        string? localAdmin_choice = Console.ReadLine();

        switch (localAdmin_choice) // start of local admin switch choices
        {
          case "1":
            break;

          case "h": // log out 
            loggedin_user = null;
            menu.LogOut();
            break;
          case "f": // quit
            running = false;
            menu.CloseSystem();
            break;
          default:
            System.Console.WriteLine("Invalid choice. Press ENTER to continue........");
            break;



        } // end of local admin switch choices

        break;
      default: break;
    }



  }
}









