namespace App;

class Main_Admin : IUser
{
  public string Username;
  string _password;


  public Main_Admin(string username, string password)
  {
    Username = username;
    _password = password;

  }

  public bool TryLogin(string username, string password)
  {
    return username == Username && password == _password;
  }

  public bool IsRole(Role role)
  {
    return Role.Main_Admin == role;
  }

  public Role GetRole()
  {
    return Role.Main_Admin;
  }
}