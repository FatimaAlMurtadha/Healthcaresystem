namespace App;

class Patient_Journal
{
  public User PatientName;
  public string? Title;
  public string? Description;
  public string? Notice;
  public DateTime Date;

  public Patient_Journal(User patientname, string? title, string? description, string notice, DateTime date)
  {
    PatientName = patientname;
    Title = title;
    Description = description;
    Notice = notice;
    Date = date;
  }

  // function för att "As a patient, I need to be able to view my own journal."
  public void ViewMyOwnJournal()
  {
    User active_user.IsRole(Role Patient); // Beh
    if ()
  }
}