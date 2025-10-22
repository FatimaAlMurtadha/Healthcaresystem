namespace App;

public interface IUser
{
    public bool TryLogin(string username, string password);

    public bool IsRole(Role role);

    public Role GetRole();

   public string? GetUserName()
  {
        return "";
  }
}

public enum Role
{
    None,
    Patient,
    Main_Admin,
    Local_Admin,
    Personnel,
}