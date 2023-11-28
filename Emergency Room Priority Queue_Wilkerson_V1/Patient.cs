//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;


//public class Patient



using System;
using System.ComponentModel.Design;

public class Patient
{
    // Properties to hold patient details: Last Name, First Name, Birthdate, and Priority.
    public string LastName { get; }
    public string FirstName { get; }
    public DateTime Birthdate { get; }
    public int Priority { get; private set; }  // Priority is set privately within the class.

    // Constructor: Initializes a new instance of the Patient class with given details.
    public Patient(string lastName, string firstName, DateTime birthdate, int priority)
    {
        LastName = lastName;      // Assigning the last name of the patient.
        FirstName = firstName;    // Assigning the first name of the patient.
        Birthdate = birthdate;    // Assigning the birthdate of the patient.
        SetPriority(priority);    // Setting the priority based on the given priority and patient's age.
    }

    // SetPriority: Private method to set the priority of the patient.
    // If the patient is below 21 years or above 65 years, priority is set to 1 (highest).
    private void SetPriority(int priority)
    {
        // Calculate the age of the patient.
        int age = DateTime.Now.Year - Birthdate.Year;

        // Check if age is below 21 or above 65 to set priority to 1.
        // Otherwise, use the provided priority.
        if (age < 21 || age > 65)
        {
            Priority = 1;
        }
        else
        {
            Priority = priority;
        }
    }

    // ToString: Override method to return a string representation of the patient.
    // This method is used when we need a string that represents the patient.
    public override string ToString()
    {
        // Formats and returns patient's information as a string.
        return $"{LastName}, {FirstName}, {Birthdate:MM/dd/yyyy}, {Priority}";
    }
}


//Key Points:
//Properties: LastName, FirstName, Birthdate, and Priority hold patient's personal and priority information.
//Constructor: Initializes a new Patient object with provided details.
//SetPriority Method: Determines the priority level of the patient based on their age.
//ToString Method: Provides a formatted string representation of the patient's information.
//This Patient class is designed to encapsulate all relevant information about a patient, including their priority in the medical queue, which is determined based on age criteria.