namespace App
{
    public enum AppointmentStatus { Requested, Approved, Denied }

    public class Appointment
    {
        public string Id;
        public string Patient;    // username
        public string Personnel;  // username (måste matcha från Users.txt)
        public string When;       // Jag har valt att köra fritext för tillfället, alltså "November 5:e tack" kan expandera till en actual tids format om vi har tid över
        public AppointmentStatus Status;

        public Appointment(string id, string patient, string personnel, string whenText, AppointmentStatus status)
        {
            Id = id; Patient = patient; Personnel = personnel; When = whenText; Status = status;
        }

        public override string ToString()
        {
            return $"{Id}|{Patient}|{Personnel}|{When}|{Status}";
        }

        public static bool TryParse(string line, out Appointment a)
        {
            a = null;
            if (string.IsNullOrWhiteSpace(line)) return false;
            var parts = line.Split('|');
            if (parts.Length < 5) return false;

            AppointmentStatus s;
            if (!System.Enum.TryParse(parts[4], out s)) s = AppointmentStatus.Requested;

            a = new Appointment(parts[0], parts[1], parts[2], parts[3], s);
            return true;
        }
    }
}
