namespace App
{

    class AppointmentRequest
    {
        public string Id;
        public string PatEmail;
        public string Time;


        public AppointmentRequest(string id, string patemail, string time)
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


        public Appointment(string id, string patemail, string doctoremail, string time)
        {
            Id = id;
            PatEmail = patemail;
            DoctorEmail = doctoremail;
            Time = time;
        }

    }

    class AppointmentLogic

    {
        static List<AppointmentRequest> requests = new List<AppointmentRequest>();     // en lista för förfrågningar
        static List<Appointment> appointments = new List<Appointment>();               // en lista för godkända bokningar

        static int IdNum = 1;                                           //börjar med id nummer 1


        public static bool CreateRequest(string patemail, string time)   // för att skapa en ny förfråga för patienten 
        {

            string id = IdNum.ToString();
            IdNum = IdNum + 1;

            requests.Add(new AppointmentRequest(id, patemail, time));   // lägger ny förfrågan i listan
            Console.WriteLine("id:" + id);                              // skriver ut vilket id nummer man har fått
            return true;
        }

        public static bool AcceptRequest ()
        {

            
        }


    }
}