
namespace App;

public class RequestRegistration
{
  // class fields
  public string? PersonalNumber { get; set; }
  public string? PatientName { get; set; }
  public string? PatientEmail { get; set; }
  public string? PatientPassword { get; set; }
  public string? Patient_Phone_Number { get; set; }
  public RegistrationStatus Status { get; set; }

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
  // a function to be called when ever an admin will receive a pending of registration request as a patient
  public override string? ToString()
  {
    return $"Personal Number: {PersonalNumber}\nName: {PatientName}\nEmail: {PatientEmail}\nStatus: {Status}";
  }

}

public enum RegistrationStatus
{
  Pending,
  Accept,
  Deny,

}