namespace App; 
public class Main_Admin: IUser
{
  string? UserName { get; set; }
  string? Password { get; set; }
  public Main_Admin(string? username, string? password)
  {
    UserName = username;
    Password = password;
  }
  public bool TryLogin(string? username, string? password)
  {
    return username == UserName && password == Password;
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