namespace App;

class Patient_Journal
{
  User PatientPersonalNumber;
   string? Title { get; set; }
   string? Description { get; set; }
   string? Notice { get; set; }
   DateTime Date { get; set; }

  public Patient_Journal(User patientpersonalnaumber, string? title, string? description, string notice, DateTime date)
  {
    PatientPersonalNumber = patientpersonalnaumber;
    Title = title;
    Description = description;
    Notice = notice;
    Date = date;
  }
  public string? ToString()
  {
    return "{PatientPersonalNumber}";
  }


}