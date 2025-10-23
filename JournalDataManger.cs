namespace App;

using System;
using System.Collections.Generic;
using System.IO;

static class JournalDataManager
{
  private const string FilePath = "Journals.txt";

  public static void SaveJournals(Patient_Journal journal) 
  {
    string line = $"{ journal.GetUserName()},{ journal.GetAuthor()},{ journal.GetTitle()},{ journal.GetNote()},{ journal.GetDate()}";
    try { File.AppendAllLines(FilePath, new[] { line }); } catch(IOException ex){System.Console.WriteLine($"Error saving journal: {ex.Message}");}
  }

  public static List<Patient_Journal> LoadJournals() //Laddar journals från textfilen
  {
    var journals = new List<Patient_Journal>(); //Fixar lista att fylla på

    if (!File.Exists(FilePath))
    {
      System.Console.WriteLine("No journals file found");
      return journals;
    }
    foreach (var line in File.ReadAllLines(FilePath))
    {
      var parts = line.Split(',');  //Dela upp varje rad i delar 
      if (parts.Length >= 5 && DateTime.TryParse(parts[4], out DateTime created_date))
        journals.Add(new Patient_Journal(parts[0], parts[1],parts[2],parts[3], created_date)); // Skapar journals-objekt och lägger till i listan
    }

    return journals;
  }
}
