using System.ComponentModel.Design;

namespace App;


public class SystemMenu
{
  List<IUser> users = new List<IUser>();
  IUser? active_user = null;
  List<RequestRegistration> request_registrations = new List<RequestRegistration>();

  // Loud all the users when we first run the system // need to expand with the rest of the data on the system
  public SystemMenu()
  {
    users = UserDataManager.LoadUsers();
  }
  // a function to log in as a user "Patient, personnel, main_admin, and local_admin"
  public void LogIn()
  {
    try { Console.Clear(); } catch { }
    System.Console.WriteLine();
    Console.Write("Username: ");
    string username = Console.ReadLine();

    try { Console.Clear(); } catch { }

    Console.Clear();
    Console.Write("Password: ");
    string password = Console.ReadLine();

    try { Console.Clear(); } catch { }

    foreach (IUser user in users)
    {
      if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
      {
        Console.WriteLine("Login failed. Username or password was empty.");
        return;
      }

      else if (user.TryLogin(username, password))
      {
        active_user = user;
        break;
      }
    }
  }

  // a function to close the system
  public void CloseSystem()
  {
    Console.Clear();
    System.Console.WriteLine("Thank you for using this Healthcare System.");
    System.Console.WriteLine();
    System.Console.WriteLine("Press Enter to close");
    Console.ReadLine();
  }
  // a function to log out th user "Patient, personnel, main_admin, and local_admin"
  public void LogOut()
  {
    Console.Clear();
    System.Console.WriteLine("You are susseccfully logged out");
    System.Console.WriteLine();
    System.Console.WriteLine("Press ENTER to continue......");
    Console.ReadLine();
  }
  //  a function to request registration as a patient
  public void SendRegistrationRequest()
  {
    try { Console.Clear(); } catch { }
    System.Console.WriteLine("Your personal security number: ");
    string? patientpersonalnumber = Console.ReadLine(); // personal number
    System.Console.WriteLine("Your name: ");
    string? patientname = Console.ReadLine(); // patient name
    System.Console.WriteLine("Your email: ");
    string? patientemail = Console.ReadLine(); // patient email
    System.Console.WriteLine("Your password: ");
    string? patientpassword = Console.ReadLine(); // patient paswword
    System.Console.WriteLine("Your phone number: ");
    string? patient_phone_number = Console.ReadLine(); // patient phone number
    if (string.IsNullOrWhiteSpace(patientpersonalnumber) || string.IsNullOrWhiteSpace(patientname) || string.IsNullOrWhiteSpace(patientpassword) || string.IsNullOrWhiteSpace(patient_phone_number))
    {
      Console.WriteLine("Faild to send a registration request. one or more of the information were empty.");
      System.Console.WriteLine();
      System.Console.WriteLine("Press ENTER to try again");
      Console.ReadLine();
      return;
    }

    else
    {
      try { Console.Clear(); } catch { }
      request_registrations.Add(new RequestRegistration(patientpersonalnumber, patientname, patientemail, patientpassword, patient_phone_number, RegistrationStatus.Pending));
      System.Console.WriteLine();
      System.Console.WriteLine("Your request has been sent susseccfully");
      System.Console.WriteLine();
      System.Console.WriteLine("Press ENTER to continue........");
      Console.ReadLine();
    }

  }
  // check permission after log in

  public bool HasPermission(Permission user_Permession, Permission required_Permission)
  {
    return (user_Permession & required_Permission) == required_Permission;
  }


  // View my own journal 
  List<Patient_Journal> journals = new List<Patient_Journal>();
 

  public void ShowJournal()
  {
    if (active_user == null)
    {
      System.Console.WriteLine("No patient is logged in");
      return;
    }
    bool found_patient = false;
    foreach (Patient_Journal journal in journals)
    {
      if (journal.GetPersonalNumber() == active_user.GetPersonalNumber())
      {
        Console.WriteLine(journal + "\n"); // show the specific patient journal

        Console.WriteLine("---------------------------------"); // a line to seprate items to be be orgnized on the screen.
        found_patient = true;
      }
      System.Console.WriteLine("Press ENTER to continue........");
      Console.ReadLine();

    }
    if (!found_patient)
    {
      System.Console.WriteLine("There is no journal connected with this account");
    }
  }

  // a list with patient 
  List<Patient> patients = new List<Patient>();
  public void CreateJournalNote()
  {
    if (active_user == null)
    {
      System.Console.WriteLine("No personnel is logged in");
      return;
    }
    else
    {
      System.Console.WriteLine("Patient's personal security number: ");
      string? personalnaumber = Console.ReadLine();
      // check if there is a patient with the given personal security number

      Patient? patient_peesonnumber = patients.FirstOrDefault(patient_found => patient_found.GetPersonalNumber() == personalnaumber);
      if (patient_peesonnumber == null)
      {
        System.Console.WriteLine("Patient not found");
        return;
      }
      System.Console.WriteLine("Title: ");
      string? title = Console.ReadLine();
      System.Console.WriteLine("Description: ");
      string? description = Console.ReadLine();
      System.Console.WriteLine("Note: ");
      string? notes = Console.ReadLine();

      DateTime created_date = DateTime.Now;


      // put all information on the patient' journal list
      Patient_Journal new_journal_note = new Patient_Journal(patient_peesonnumber, title, description, notes, created_date);
      journals.Add(new_journal_note);
      System.Console.WriteLine("Note added successfully.");
      System.Console.WriteLine("Press ENTER to continue........");
      Console.ReadLine();

    }
  }
}


