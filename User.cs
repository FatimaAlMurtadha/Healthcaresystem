namespace App;

 class User : IUser
{
    private string _username;
    private string _password;
    private Role _role;

    public User(string username, string password, Role role = Role.User)
    {
        _username = username;
        _password = password;
        _role = role;
    }

    public bool TryLogin(string username, string password)
    {
        return _username == username && _password == password;
    }

    public bool IsRole(Role role)
    {
        return _role == role;
    }

    public Role GetRole()
    {
        return _role;
    }


    public override string ToString()
    {
        return $"{_username} ({_role})";
    }
}
