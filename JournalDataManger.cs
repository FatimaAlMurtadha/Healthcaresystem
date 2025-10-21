namespace App;

static class JournalDataManager
{
  private const string FilePath = "Journals.txt";

  public static void SaveJournals(string? personalnaumber, string? author, string? title, string? notes, DateTime created_date) 
  {
    string line = $"{personalnaumber},{author},{title},{notes},{created_date}";
    File.AppendAllLines(FilePath, new[] { line });
  }

  public static List<Patient_Journal> LoadJournals() //Laddar journals från textfilen
  {
    var journals = new List<Patient_Journal>(); //Fixar lista att fylla på

    if (!File.Exists(FilePath))
      return journals;

    foreach (var line in File.ReadAllLines(FilePath))
    {
      var parts = line.Split(',');  //Dela upp varje rad i delar 
      if (parts.Length >= 5 && Enum.TryParse(parts[4], out DateTime created_date))
        journals.Add(new Patient_Journal(parts[0], parts[1],parts[2],parts[3], created_date)); // Skapar journals-objekt och lägger till i listan
    }

    return journals;
  }
}
