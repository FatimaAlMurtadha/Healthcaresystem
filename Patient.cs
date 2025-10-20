namespace App;

class Patient
{
  string? PatientPersonalNumber { get; set; }
  string? PatientPassword { get; set; };

  public Patient( string? patientpersonalnumber,string? patientpassword)
  {
    PatientPersonalNumber = patientpersonalnumber;
    PatientPassword = patientpassword;

  }

  public bool TryLogin(string? patientpersonalnumber, string? patientpassword)
  {
    return patientpersonalnumber == PatientPersonalNumber && patientpassword == PatientPassword;

  }

  public bool IsRole(Role role)
  {
    return Role.Patient == role;

  }
  public Role GetRole()
  {
    return Role.Patient;

  }


}
