
namespace App;

public class RequestRegistration
{
  // class fields
  public string? PersonalNumber;
  public string? PatientName;
  public string? PatientEmail;
  public string? PatientPassword;
  public string? Patient_Phone_Number;
  public RegistrationStatus Status;

  // class constructor
  public RequestRegistration(string? personalnumber, string? patientname, string? patientemail, string? patientpassword, string? patient_phone_number, RegistrationStatus status)
  {
    PersonalNumber = personalnumber;
    PatientName = patientname;
    PatientEmail = patientemail;
    PatientPassword = patientpassword;
    Patient_Phone_Number = patient_phone_number;
    Status = status;

  }

}


public enum RegistrationStatus
{
  Pending,
  Accept,
  Deny,

}