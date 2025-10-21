namespace App;

class Patient_Journal
{
  Patient? PersonalNumber;
  string? Title { get; set; }
  string? Description { get; set; }
  string? Notes { get; set; }
  DateTime Created_Date { get; set; }

  public Patient_Journal(Patient? personalnaumber, string? title, string? description, string notice, DateTime created_date)
  {
    PersonalNumber = personalnaumber;
    Title = title;
    Description = description;
    Notes = notice;
    Created_Date = created_date;
  }
  public string? GetPersonalNumber()
  {
    return PersonalNumber?.GetPersonalNumber(); // on patient class // connect both patient and journal
  }
  public override string ToString()
  {
    return $"The date: {Created_Date:yyyy-MM-dd}.\nThe title: {Title}.\nDescription: {Description}.\nNotes: {Notes}.";
  }

}