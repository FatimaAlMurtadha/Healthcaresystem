namespace App
{
    public enum AppointmentStatus { Requested, Approved, Denied }

    public class Appointment
    {
        public string Id;
        public string Patient;
        public string Personnel;
        public string When;        // vi lagrar som "yyyy-MM-dd HH:mm"
        public AppointmentStatus Status;
        public string Note;        // Jag valde att lägga till en note, vi har inte patientens anledning för att boka tid annars

        public Appointment(string id, string patient, string personnel, string whenText, AppointmentStatus status, string note)
        {
            Id = id;
            Patient = patient;
            Personnel = personnel;
            When = whenText;
            Status = status;
            Note = note ?? "";
        }

        // id|patient|personnel|when|status|note
        public override string ToString()
        {
            // DEtta är för att undvika null
            string safeNote = Note == null ? "" : Note.Replace("\r", " ").Replace("\n", " ");
            return Id + "|" + Patient + "|" + Personnel + "|" + When + "|" + Status.ToString() + "|" + safeNote;
        }

        // Parsar bokningen från en line of text
        public static bool TryParse(string line, out Appointment a)
        {
            a = null;
            if (string.IsNullOrWhiteSpace(line)) return false;

            var parts = line.Split('|');
            if (parts.Length < 5) return false;

            AppointmentStatus s;
            if (!System.Enum.TryParse(parts[4], out s)) s = AppointmentStatus.Requested;

            string note = "";
            if (parts.Length >= 6) note = parts[5];

            a = new Appointment(parts[0], parts[1], parts[2], parts[3], s, note);
            return true;
        }
    }
}
