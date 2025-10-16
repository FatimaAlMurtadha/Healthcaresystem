namespace App;

public class SystemLogicMenu
{
  IUser? active_user = null;
  bool running = true;

  List<IUser> users = new List<IUser>();

  List<RequestRegistration> request_registrations = new List<RequestRegistration>();



  public void LogInAsUser()
  { // As a user, I need to be able to log in.
    users.Add(new User("Fatima", "123")); // Default user
    // Loga in för att öpnna systemet
    System.Console.WriteLine("Username: ");
    string? username = Console.ReadLine();

    Console.Clear();
    System.Console.WriteLine("Password: ");
    string? password = Console.ReadLine();
    users.Add(new User(username, password));
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
  // As a user, I need to be able to request registration as a patient.
  public void SendRegistrationRequest()
  {

    try { Console.Clear(); } catch {}
    System.Console.WriteLine("Your personal security number: ");
    string? patientpersonalnumber = Console.ReadLine();
    System.Console.WriteLine("Your name: ");
    string? patientname = Console.ReadLine();
    System.Console.WriteLine("Your email: ");
    string? patientemail = Console.ReadLine();
    System.Console.WriteLine("Your password: ");
    string? patientpassword = Console.ReadLine();

    if (patientpersonalnumber != null && patientpersonalnumber != "" && patientname != null && patientname != "" && patientemail != null && patientemail != "" && patientpassword != null && patientpassword != "")
    {

      request_registrations.Add(new RequestRegistration(patientpersonalnumber, patientname, patientemail, patientpassword, RegistrationStatus.Pending));
      System.Console.WriteLine("Your request has been sent susseccfully");
    }
    else
    {
      System.Console.WriteLine("Invlid input. Nothing of the information can be null or empty");
      System.Console.WriteLine("Press ENTER to continue......");
      Console.ReadLine();
    }

  }
  static void Give_Local_Admin(List<IUser> users)// detta kontot finns men det blir en local_Admin
  {
    try { Console.Clear(); } catch {}
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
    try { Console.Clear(); } catch {}
    System.Console.WriteLine("Please enter the name of the account");
    string username = Console.ReadLine()!;
    System.Console.WriteLine("Please enter the name of the account");
    string password = Console.ReadLine()!;
    users.Add(new Local_Admin(username, password)); // need Local_Admin class
  }

}
