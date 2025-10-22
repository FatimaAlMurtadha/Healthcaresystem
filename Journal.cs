namespace App;

class Patient_Journal
{

  string? UserName { get; set; }
  public List<Patient_Journal> Entries { get; set; } = new List<Patient_Journal>(); // need mange
  string? Author;
  string? Title { get; set; }
  string? Notes { get; set; }
  DateTime Created_Date { get; set; }

  public Patient_Journal(string? username, string? author, string? title, string? notes, DateTime created_date)
  {
    UserName = username;
    Author = author;
    Title = title;
    Notes = notes;
    Created_Date = created_date;
  }
  // a function to mark or add entries
  public void AddEntry(Patient_Journal entry)
  {
    if (entry.GetUseName() == UserName)
    {
      Entries.Add(entry);
      System.Console.WriteLine("Note was successfully added");
    }
    else
    {
      System.Console.WriteLine("Note can not be added. Invalid personal security number");
    }
  }

  // a function to show journal entries

  public void ShowJournal()
  {
    System.Console.WriteLine($"The journal of the patient {UserName}:");
    foreach(Patient_Journal entry in Entries )
    {
      System.Console.WriteLine($"- {entry.GetDate(): yyyy-MM-dd}, by {entry.GetAuthor()}");
      System.Console.WriteLine($"The title: {entry.GetTitle()}");
      System.Console.WriteLine($"The note: {entry.GetNote()}");
    }
  }


  public string? GetUseName() => UserName;
  public string? GetAuthor() => Author;
  public string? GetNote() => Notes;
  public DateTime? GetDate() => Created_Date;
  public string? GetTitle() => Title;

  

}