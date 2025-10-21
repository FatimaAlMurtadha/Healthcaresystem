namespace App;

class User : IUser
{
    public string? UserName;
    string? _password;
    Role _role;

    public User(string? username, string? password, Role role)
    {
        UserName = username;
        _password = password;
        _role = role;
    }

    public bool TryLogin(string? username, string? password)
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
    public string? GetUserName()
    {
        return UserName;
    }
}