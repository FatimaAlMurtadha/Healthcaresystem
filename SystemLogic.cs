using System;
using System.Collections.Generic;
using System.Text;

namespace App;


public class SystemMenu
{


  List<IUser> users = new List<IUser>();
  public IUser? current_user = null;

  List<RequestRegistration> request_registrations = new List<RequestRegistration>();
  List<Patient_Journal> journals = new List<Patient_Journal>();
  List<Permission> permissions = new List<Permission>();
  private const string FilePath = "Users.txt";
  public SystemMenu()
  {
    // Loud all the users when we first run the system
    users = UserDataManager.LoadUsers();
    // Loud all the journals when we first run the system
    journals = JournalDataManager.LoadJournals();
    // Loud all the permissions when we first run the system
    PermissionsDataManager.LoadPermissions(users);
  }
  // a function to log in as a user "Patient, personnel, main_admin, and local_admin"
  public IUser? LogIn()
  {
    try { Console.Clear(); } catch { }
    System.Console.WriteLine();
    Console.Write("Username: ");
    string username = Console.ReadLine()!;

    try { Console.Clear(); } catch { }

    Console.Clear();
    Console.Write("Password: ");
    string password = Console.ReadLine()!;

    try { Console.Clear(); } catch { }
    if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
    {
      Console.WriteLine("Login failed. Username or password was empty.");
      System.Console.WriteLine("Press ENTER to continue.....");
      Console.ReadLine();
      return null;
    }

    foreach (IUser user in users)
    {

      if (user.TryLogin(username, password))
      {
        System.Console.WriteLine("Login successful.");
        current_user = user;
        return user;
      }
    }
    System.Console.WriteLine("Log in faild. Incorrect username or password.");
    System.Console.WriteLine("Press ENTER to continue.....");
    Console.ReadLine();
    return null;
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
  // check permission when ever the user wants to do sth on the system
  public bool HasPermission(Permission userPermission, Permission requiredPermission)
  {
    return userPermission == requiredPermission;
  }



  // View my own journal 
  public void ShowMyJournal()
  {
    if (current_user == null || !current_user.IsRole(Role.Patient))
    {
      System.Console.WriteLine("Only patients can view their own journals.");
      return;
    }

    Patient patient = current_user as Patient;
    string? username = patient.GetUserName();

    var allJournals = JournalDataManager.LoadJournals();
    var myJournals = allJournals.Where(j => j.GetUserName()?.Trim().ToLower() == username?.Trim().ToLower()).ToList();
    if (myJournals.Count == 0)
    {
      System.Console.WriteLine("No journal entries found.");
      return;
    }

    // call ShowJournal() from Patient_Journal
    Patient_Journal journal = new Patient_Journal(username, "", "", "", DateTime.Now);
    journal.Entries = myJournals;
    journal.ShowJournal();
  }


  // a function to allow a personnel with sufficient permission to creat a journal note

  /*public void CreateJournalNote()
  {
    if (current_user == null || !current_user.IsRole(Role.Personnel))
    {
      Console.WriteLine("Only personnel can create journal notes.");
      return;
    }

    Personnel personnel = current_user as Personnel;
    if (personnel == null || !personnel.HasPermission(Permission.Create_Journal_note))
    {
      Console.WriteLine("You do not have permission to create journal notes.");
      return;
    }

    Console.Write("Enter patient's personal number: ");
    string? personalNumber = Console.ReadLine();

    Console.Write("Enter journal title: ");
    string? title = Console.ReadLine();

    Console.Write("Enter journal note: ");
    string? note = Console.ReadLine();

    DateTime createdDate = DateTime.Now;
    string? author = personnel.Username;

    Patient_Journal journal = new Patient_Journal(personalNumber, author, title, note, createdDate);
    journals.Add(journal); // adding the new note to the current list


    JournalDataManager.SaveJournals(journal); // save the new note on the file 

    Console.WriteLine("Journal note saved successfully.");
    Console.WriteLine("Press ENTER to continue...");
    Console.ReadLine();
  }*/

  public void AcceptPatient()
  {

    foreach (RequestRegistration user in request_registrations)
    {

      if (user.Status != RegistrationStatus.Accept && user.Status != RegistrationStatus.Deny)
      {
        System.Console.WriteLine(user.PatientName + user.PatientEmail + user.Patient_Phone_Number + user.PersonalNumber);
        Console.WriteLine("do you want to accept this person type yes");
        string Admin_input = Console.ReadLine()!;

        if (Admin_input == "yes")
        {

          var dateTime = DateTime.Now;
          var time = dateTime.ToString("ddd, dd MMM yyyy h:mm");
          string username = user.PatientName!;
          string password = user.PatientPassword!;
          Role role = Role.Patient;
          user.Status = RegistrationStatus.Accept;
          string line = $"{username},{password},{role}";
          File.AppendAllLines(FilePath, new[] { line });
          string lines = $"{username},{password},{role},{time}";
          File.AppendAllLines("Users_log.txt", new[] { lines });

          System.Console.WriteLine("you have accepted this request, press enter to continue");
          Console.ReadLine();

        }
        else
        {
          Console.WriteLine("OK the request is denied");
        }

      }

    }
    Console.WriteLine("ther is no more Requests, press ENTER to continue");
    Console.ReadLine();




  }

  public void Create_personell_accounts()
  {
    System.Console.WriteLine("Write username to the account");
    string username = Console.ReadLine()!;
    Console.Clear();
    System.Console.WriteLine("Write password to the account");
    string password = Console.ReadLine()!;
    Role role = Role.Personnel;
    users.Add(new Personnel(username, password));
    string line = $"{username},{password},{role}";
    File.AppendAllLines(FilePath, new[] { line });
    System.Console.WriteLine("you have accepted this request, press enter to continue");
    Console.ReadLine();



  }


}


