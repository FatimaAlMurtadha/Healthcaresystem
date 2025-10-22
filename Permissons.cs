namespace App;

public enum Permission
{
    None,
    HandlePermissions,
    AssignRegion,
    HandleRegistrations,
    AddLocation,
    CreatePersonnel,
    ViewPermissionList,
    AcceptPatient,
    DenyPatient,
    Create_Journal_note, // personnel 
    ViewJournals, // patient
    ApproveAppointments,
    ModifyAppointments,
    ViewSchedule
}
