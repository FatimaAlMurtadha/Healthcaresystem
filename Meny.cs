/*
using App;

#if false 
*/

/*
As a user, I need to be able to log in.

As a user, I need to be able to log out.

As a user, I need to be able to request registration as a patient.

As an admin with sufficient permissions, I need to be able to give admins the permission to handle the permission system, in fine granularity.

As an admin with sufficient permissions, I need to be able to assign admins to certain regions.

As an admin with sufficient permissions, I need to be able to give admins the permission to handle registrations.

As an admin with sufficient permissions, I need to be able to give admins the permission to add locations.

As an admin with sufficient permissions, I need to be able to give admins the permission to create accounts for personnel.

As an admin with sufficient permissions, I need to be able to give admins the permission to view a list of who has permission to what.

As an admin with sufficient permissions, I need to be able to add locations.

As an admin with sufficient permissions, I need to be able to accept user registration as patients.

As an admin with sufficient permissions, I need to be able to deny user registration as patients.

As an admin with sufficient permissions, I need to be able to create accounts for personnel.

As an admin with sufficient permissions, I need to be able to view a list of who has permission to what.

As personnel with sufficient permissions, I need to be able to view a patients journal entries.

As personnel with sufficient permissions, I need to be able to mark journal entries with different levels of read permissions.

As personnel with sufficient permissions, I need to be able to register appointments.

As personnel with sufficient permissions, I need to be able to modify appointments.

As personnel with sufficient permissions, I need to be able to approve appointment requests.

As personnel with sufficient permissions, I need to be able to view the schedule of a location.

As a patient, I need to be able to view my own journal.

As a patient, I need to be able to request an appointment.

As a logged in user, I need to be able to view my schedule.


IUser? active_user = null;

List<IUser> users = new List<IUser>();
users.Add(new User("Fatima", "123")); // Behövs en User Class 


    {
        bool running = true;

        while (running) // Huvudloopen för hela programmet.
        {
              if (active_user == null) // Om ingen är inloggad, visa själva gästmenyn som står nedanför.
            {
                Console.WriteLine("\n -- MENU --");
                Console.WriteLine("1. Log in");
                Console.WriteLine("2. Create patient account");
                Console.WriteLine("3. Quit");
              
                var meny1 = Console.ReadLine();

                switch (meny1)
                {
                    case "1": Login(); break;
                    case "2": Register_Patient(); break;
                    case "3": running = false; break;     // avlsutar programmet när man väljer 3

                }


                else if (active_user == Local_Admin)

                {
                    System.Console.WriteLine(" 1. Create accounts for personell ");
                    System.Console.WriteLine(" 2. Accept/deny user registration as patients ");
                    System.Console.WriteLine(" 3. Add locations ");
                    System.Console.WriteLine(" 4. Handle permission system ");
                    System.Console.WriteLine(" 5. Handle registrations  ");
                    System.Console.WriteLine(" 6. Fix personell status  ");
                    System.Console.WriteLine(" 7. Log out" );
                    
                    var meny2 = Console.ReadLine();


                    switch (meny2)
                    {
                        case "1": Create_personell_accounts(); break;
                        case "2": Handle_patient_registrations(); break;
                        case "3": Add_locations(); break;
                        case "4": Handle_permission_system(); break;
                        case "5": Handle_registrations(); break;
                        case "6": Handle_personell_status(); break;
                        case "7": Logout();
                    }

                    

                }



                  else if (active_user == Personnel)

                {
                    System.Console.WriteLine(" 1. Show patient journals ");
                    System.Console.WriteLine(" 2. Create journalnotes ");
                    System.Console.WriteLine(" 3. Book patient appointments ");
                    System.Console.WriteLine(" 4. Handle patient visits ");
                    System.Console.WriteLine(" 5. Show schedule for my hospital ");
                    System.Console.WriteLine(" 6. Log out  ");
                    
                    var meny3 = Console.ReadLine();


                    switch (meny3)
                    {
                        case "1": Patient_journals(); break;
                        case "2": Journal_notes(); break;
                        case "3": Book_patient_appointments(); break;
                        case "4": Patient_visits(); break;
                        case "5": Schedule(); break;
                        case "6": Logout();
                    
                    }


                    else if (active_user == Patient)

                {
                    System.Console.WriteLine(" 1. Show my Journal ");
                    System.Console.WriteLine(" 2. Book an appointment ");
                    System.Console.WriteLine(" 3. Show history ");
                    System.Console.WriteLine(" 4. Log out  ");
                    
                    var meny4 = Console.ReadLine();


                    switch (meny4)
                    {
                        case "1": My_journal(); break;
                        case "2": Book_appointment(); break;
                        case "3": My_History(); break;
                        case "4": Logout();
                        
                    
                    }


                
            }
                
        }

            }
        


        }

       

}*/








