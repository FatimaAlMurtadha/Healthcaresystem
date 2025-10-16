namespace App;

public class RequestRegistration
{
  // class fields
  public string? PersonalNumber;
  public string? PatientName;
  public string? PatientEmail;
  public string? PatientPassword;
  public RegistrationStatus Status;

  // class constructor
  public RequestRegistration(string? personalnumber, string? patientname, string? patientemail, string? patientpassword, RegistrationStatus status)
  {
    PersonalNumber = personalnumber;
    PatientName = patientname;
    PatientEmail = patientemail;
    PatientPassword = patientpassword;
    Status = status;

  }

}


public enum RegistrationStatus
{
  Pending,
  Accept,
  Deny,

}