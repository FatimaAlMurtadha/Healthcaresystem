namespace App;

class User : IUser
{
    public string UserName;
    string _password;

    public User(string? username, string password)
    {
        UserName = username;
        _password = password;
    }

    public bool TryLogin(string username, string password)
    {
        return username == UserName && password == _password;
    }

    public bool IsRole(Role role)
    {
        return Role.User == role;
    }

    public Role GetRole()
    {
        return Role.User;
    }
    public static Permission Permissions { get; set; }
    public string? GetPersonalNumber()
    {
        return UserName;
    }
}