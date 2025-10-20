using System.Reflection.Metadata;

namespace App;

public class SystemLogicMenu
{
internal IUser? ActiveUser => active_user;
  IUser? active_user = null;
  bool running = true;

  List<IUser> users = UserDataManager.LoadUsers();

  List<RequestRegistration> request_registrations = new List<RequestRegistration>();


  //As a user, I need to be able to log in.
  public void LogInAsUser()
  {
    if (users.Count == 0)
      users.Add(new User("Fatima", "123")); // För testing. Annars kan ni gå in i User.txt och skapa ett konto där

    Console.Write("Username: ");
    string? username = Console.ReadLine();

    Console.Clear();
    Console.Write("Password: ");
    string? password = Console.ReadLine();
    Console.Clear();

    // Checkar efter tom användarnamn eller lösenord
    if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
    {
      Console.WriteLine("Login failed. Username or password was empty.");
      return;
    }

    // Efter checken så kan vi vara säkra på att username och password inte är null eller whitespace
    string u = username;
    string p = password;

    bool success = false;
    foreach (IUser user in users)
    {
      if (user.TryLogin(u, p))
      {
        active_user = user;
        success = true;
        break;
      }
    }

    if (!success)
      Console.WriteLine("Login failed. Wrong username or password.");
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
    users.Add(new User(username, password)); // need Local_Admin class
  }

static void Make_account(List<IUser> users)
{
    System.Console.WriteLine("Please enter your name:");
    string? username = Console.ReadLine();

    System.Console.WriteLine("Please enter your password:");
    string? password = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
    {
        Console.WriteLine("Invalid input. Try again.");
        return;
    }

    var newUser = new User(username, password);
    users.Add(newUser);

    // Save to file
    UserDataManager.SaveUser(username, password, Role.User);

    File.AppendAllText("Users_log.txt",
    $"New user created: {username} {password} ({DateTime.Now}){Environment.NewLine}");

    Console.WriteLine("Account created successfully!");
  }
}
