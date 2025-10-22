namespace App;

class Patient : IUser
{
  string? Personal_Number{ get; set; }
  string? _password { get; set; }

  public Patient(string? personal_number, string? password)
  {
    Personal_Number = personal_number;
    _password = password;
  }
  // a function to use a patient personal number as a username when checking TryLogIn
  public string? GetUserName()
  {
    return Personal_Number;
  }

  public bool TryLogin(string? personal_number, string? password) // username
  {
    return personal_number == Personal_Number && password == _password;
  }

  public bool IsRole(Role role)
  {
    return role == Role.Patient;
  }

  public Role GetRole()
  {
    return Role.Patient;
  }
  public static Permission Permissions { get; set; }

  public string? GetPersonalNumber()
  {
    return Personal_Number;
  }
}