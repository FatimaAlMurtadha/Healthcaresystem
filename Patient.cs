namespace App;

class Patient : IUser
{
  string? UserName{ get; set; }
  string? _password { get; set; }

  public Patient(string? username, string? password)
  {
    UserName = username;
    _password = password;
  }
  // a function to use a patient personal number as a username when checking TryLogIn
  public string? GetUserName()
  {
    return UserName;
  }

  public bool TryLogin(string username, string password)
  {
    return username == UserName && password == _password;
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
}