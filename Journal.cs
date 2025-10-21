namespace App;

class Patient_Journal
{

  string? PersonalNumber;
  string? Author;
  string? Title { get; set; }
  string? Description { get; set; }
  string? Notes { get; set; }
  DateTime Created_Date { get; set; }

  public Patient_Journal(string? personalnaumber, string? author, string? title, string? description, string notes, DateTime created_date)
  {

    PersonalNumber = personalnaumber;
    Author = author;
    Title = title;
    Description = description;
    Notes = notes;
    Created_Date = created_date;
  }
  public string GetPersonalNumber() => PersonalNumber;
  public string GetAuthor() => Author;
  public string GetNote() => Notes;
  public DateTime GetDate() => Created_Date;
 
  public override string ToString()
  {
    return $"The date: {Created_Date:yyyy-MM-dd}.\nThe title: {Title}.\nDescription: {Description}.\nNotes: {Notes}.";
  }

}