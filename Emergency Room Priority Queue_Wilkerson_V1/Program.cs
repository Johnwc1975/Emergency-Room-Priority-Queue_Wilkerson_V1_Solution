//namespace Emergency_Room_Priority_Queue_Wilkerson_V1

// NOTES: 
// Please review and provide feedback. This application is designed to manage a patient queue 
// for an emergency room setting, allowing user interaction for adding, processing, and listing patients.
// It uses a file-based approach for initial patient data loading.

// BEHAVIORS NOT IMPLEMENTED AND WHY: 
// Currently, all core functionalities for the emergency room queue management are implemented. 
// Any additional features, such as persistent data storage or advanced patient management features, 
// could be considered for future updates, but are beyond the scope of this initial implementation.


using System;
using System.IO;

class Program
{
    // A static instance of ERQueueManager to manage the patient queue throughout the program's lifecycle.
    static ERQueueManager queueManager = new ERQueueManager();

    // Main method: the entry point of the application.
    static void Main(string[] args)
    {
        // Combines the base directory of the application with the filename to create a relative path.
        // This ensures that the file path is relative to the current running directory.
        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Patients.csv");

        // Load initial patient data from the CSV file into the queue.
        // This is essential for initializing the system with existing patient data.
        queueManager.LoadPatientsFromFile(filePath);

        // Flag to keep the program running until the user decides to quit.
        bool running = true;
        while (running)
        {
            // Display the menu options to the user.
            // This provides a simple text-based user interface.
            Console.WriteLine("Menu: (A)dd Patient  (P)rocess Current Patient  (L)ist All in Queue  (Q)uit");
            Console.Write("Choose an option: ");
            char choice = Console.ReadKey().KeyChar; // Reads the user's choice.
            Console.WriteLine();

            // Switch statement to handle different user choices.
            switch (choice)
            {
                case 'A':
                case 'a':
                    // Call the method to add a new patient.
                    // This option allows the user to enter a new patient into the system.
                    AddPatient();
                    break;
                case 'P':
                case 'p':
                    // Call the method to process (dequeue) the next patient in the queue.
                    // This is for handling the next patient in line based on priority.
                    ProcessPatient();
                    break;
                case 'L':
                case 'l':
                    // Call the ERQueueManager's method to list all patients in the queue.
                    // This displays all current patients in the queue.
                    queueManager.ListPatients();
                    break;
                case 'Q':
                case 'q':
                    // Set the flag to false to exit the while loop and end the program.
                    // This option allows the user to quit the application.
                    running = false;
                    break;
                default:
                    // Handle invalid user input.
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }

    // AddPatient: Method to add a new patient to the queue.
    static void AddPatient()
    {
        // Gather patient information from the user.
        // This includes the patient's first name, last name, birthdate, and priority.

        Console.Write("Enter First Name: ");
        string firstName = Console.ReadLine();

        Console.Write("Enter Last Name: ");
        string lastName = Console.ReadLine();

        DateTime birthDate;
        while (true)
        {
            Console.Write("Enter Birthdate (MM/DD/YYYY): ");
            if (DateTime.TryParse(Console.ReadLine(), out birthDate))
            {
                break;
            }
            Console.WriteLine("Invalid date format.");
        }

        int priority;
        while (true)
        {
            Console.Write("Enter Priority (1-5): ");
            if (int.TryParse(Console.ReadLine(), out priority) && priority >= 1 && priority <= 5)
            {
                break;
            }
            Console.WriteLine("Invalid priority. It should be a number between 1 and 5.");
        }

        // Create a new patient instance and add it to the queue.
        var patient = new Patient(lastName, firstName, birthDate, priority);
        queueManager.EnqueuePatient(patient);
        Console.WriteLine("Patient added to queue.");
    }

    // ProcessPatient: Method to process (dequeue) the next patient from the queue.
    static void ProcessPatient()
    {
        // Attempt to dequeue the next patient from the queue.
        Patient patient = queueManager.DequeuePatient();
        if (patient != null)
        {
            // Display the dequeued patient's information.
            Console.WriteLine($"Processing patient: {patient}");
        }
        else
        {
            // Inform the user if there are no more patients in the queue.
            Console.WriteLine("No patients in the queue.");
        }
    }
}

// NOTES: 
// Please review and provide feedback. This application is designed to manage a patient queue 
// for an emergency room setting, allowing user interaction for adding, processing, and listing patients.
// It uses a file-based approach for initial patient data loading.

// BEHAVIORS NOT IMPLEMENTED AND WHY: 
// Currently, all core functionalities for the emergency room queue management are implemented. 
// Any additional features, such as persistent data storage or advanced patient management features, 
// could be considered for future updates, but are beyond the scope of this initial implementation.
