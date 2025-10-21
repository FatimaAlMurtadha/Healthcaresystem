namespace App;

class Patient : IUser
{
  string? Personal_Number;
  string? _password;

  public Patient(string personal_number, string password)
  {
    Personal_Number = personal_number;
    _password = password;
  }

  public bool TryLogin(string personal_number, string password)
  {
    return personal_number == Personal_Number && password == _password;
  }

  public bool IsRole(Role role)
  {
    return Role.Patient == role;
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