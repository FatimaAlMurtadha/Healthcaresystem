namespace App;


using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


  static class PermissionsDataManager
  {
    private const string FilePath = "Permissions.txt";

    // Load permissions from file and assign to personnel
    public static void LoadPermissions(List<IUser> users)
    {
      if (!File.Exists(FilePath)) return;

      foreach (var line in File.ReadAllLines(FilePath))
      {
        var parts = line.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        if (parts.Length != 2) continue;

        string username = parts[0];
        string permissionText = parts[1];

        if (!Enum.TryParse(permissionText, out Permission permission)) continue;

        var personnel = users.FirstOrDefault(u => u is Personnel && u.GetUserName() == username) as Personnel;
        personnel?.AddPermission(permission);
      }
    }

    // Save a new permission for a personnel
    public static void SavePermission(string username, Permission permission)
    {
      string line = $"{username},{permission}";
      File.AppendAllLines(FilePath, new[] { line });
    }
  }


