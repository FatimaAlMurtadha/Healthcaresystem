namespace App;

class User : IUser
{
    private string _username;
    private string _password;
    private Role _role;
    private Permission _permissions; //Behöver för bitflggor

    public User(string username, string password, Role role = Role.User)
    {
        _username = username;
        _password = password;
        _role = role;

        // AA!! vi får diskutera vilka permissions varje roll ska ha
        _permissions = role switch
        {
            Role.Main_Admin => Permission.ManagePermissions
                             | Permission.ManageLocations
                             | Permission.ManagePersonnels
                             | Permission.ManageRegistrations
                             | Permission.ManageJournals
                             | Permission.ManageAppointments
                             | Permission.ManageLocalAdmins,

            Role.Local_Admin => Permission.ManageLocations
                              | Permission.ManagePersonnels
                              | Permission.ManageRegistrations
                              | Permission.ManageAppointments,

            Role.Personnel => Permission.ManageJournals
                              | Permission.ManageAppointments,

            Role.Patient => Permission.ManageAppointments,//(?)
            _ => Permission.None
        };
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

    // Kontrollera om användaren har en viss permission
    public bool HasPermission(Permission permission)
    {
        return (_permissions & permission) == permission;
    }

    public override string ToString()
    {
        return $"{_username} ({_role})";
    }
}
