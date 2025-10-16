namespace App

class AppointmentReguest
{
    public string Id;
    public string PatEmail;
    public string Time;


    public AppointmentReguest(string id, string patemail, string time)
    {
        Id = id;
        PatEmail = patemail;
        Time = time;
    }
}

class Appointment
{
    public string Id;
    public string PatEmail;
    public string DoctorEmail;
    public string Time;


    public AppointmentReguest(string id, string patemail, string doctoremail, string time)
    {
        Id = id;
        PatEmail = patemail;
        DoctorEmail = doctoremail;
        Time = time;
    }
    
}