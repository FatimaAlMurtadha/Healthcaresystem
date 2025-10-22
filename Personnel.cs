namespace App;

class Personnel : IUser
{
    public string? Username{ get; set; }
    string? Password { get; set; }

    public Personnel(string? username, string? password)
    {
        Username = username;
        Password = password;

    }

    public bool TryLogin(string? username, string? password)
    {
        return username == Username && password == Password;

    }

    public bool IsRole(Role role)
    {
        return role == Role.Personnel;

    }
    public Role GetRole()
    {
        return Role.Personnel;

    }
   
    // Define the permission to a specific personnel
    public List<Permission> Permissions { get; set; } = new List<Permission>();

    public bool HasPermission(Permission permission)
    {
        return Permissions.Contains(permission);


    }
    // a function to give vissa personnel permissions
    public void AddPermission(Permission permission) => Permissions.Add(permission);


}
