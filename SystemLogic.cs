using System.ComponentModel.Design;

namespace App;


public class SystemMenu
{
  public void CloseSystem()
  {
    Console.Clear();
    System.Console.WriteLine("Thank you for using this Healthcare System.");
    System.Console.WriteLine();
    System.Console.WriteLine("Press Enter to close");
    Console.ReadLine();
  }
  public void LogOut()
  {
    Console.Clear();
    System.Console.WriteLine("You are susseccfully logged out");
    System.Console.WriteLine();
    System.Console.WriteLine("Press ENTER to continue......");
    Console.ReadLine();
  }
  List<RequestRegistration> request_registrations = new List<RequestRegistration>();
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
  User? active_user = null;

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

    }
    if (!found_patient)
    {
      System.Console.WriteLine("There is no journal connected with this account");
    }
  }
  public void Creat_JournalNote()
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
      System.Console.WriteLine("Title: ");
      string? title = Console.ReadLine();
      System.Console.WriteLine("Description: ");
      string? description = Console.ReadLine();
      System.Console.WriteLine("Note: ");
      string? other = Console.ReadLine();
      DateTime created_date = DateTime.Now;


      // put all information on the patient' journal list
      journals.Add(new Patient_Journal(personalnaumber, title,description, other, created_date));

    }
  }
}


