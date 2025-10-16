namespace App;

[Flags]  //Varje permissions får unikt binärt värde
public enum Permission
{
    None                = 0,  //
    ManagePermissions = 1 << 0,  //1
    ManageLocations = 1 << 1,   //2
    ManagePersonnels = 1 << 2,  //4
    ManageRegistrations = 1 << 3, //8
    ManageJournals = 1 << 4, //16
    ManageAppointments = 1 << 5, //32
    ManageLocalAdmins = 1 << 6, //64
}

//Så om Jackson har ManageLocations (2), ManagePersonnels (4) och ManageRegistration (8) och ManageAppointments (32)
//Så blir det binärt 00101110 eller (2 + 4 + 8 + 32 = 46). Eller Jackson:46 
//