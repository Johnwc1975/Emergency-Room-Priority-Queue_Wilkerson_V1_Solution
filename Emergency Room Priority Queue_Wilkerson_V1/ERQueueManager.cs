

//public class ERQueueManager


using System;
using System.Collections.Generic;
using System.IO;

public class ERQueueManager
{
    // This PriorityQueue is used to store patients, with their priority as the sorting key.
    private PriorityQueue<Patient, int> queue = new PriorityQueue<Patient, int>();

    // LoadPatientsFromFile: Reads patients' data from a CSV file and adds them to the queue.
    public void LoadPatientsFromFile(string filePath)
    {
        // Check if the specified file exists. If not, display a message and return.
        if (!File.Exists(filePath))
        {
            Console.WriteLine("File not found. Please ensure the file path is correct.");
            return;
        }

        try
        {
            // Read all lines from the file.
            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                // Split each line into parts using the comma as a separator.
                var parts = line.Split(',');
                if (parts.Length >= 4)
                {
                    // Extract patient information from the parts.
                    string firstName = parts[0].Trim();
                    string lastName = parts[1].Trim();
                    DateTime birthDate = DateTime.Parse(parts[2].Trim());
                    int priority = int.Parse(parts[3].Trim());

                    // Create a new Patient object and add it to the queue.
                    var patient = new Patient(lastName, firstName, birthDate, priority);
                    EnqueuePatient(patient);
                }
            }
        }
        catch (Exception ex)
        {
            // If an error occurs during file reading or processing, display the error message.
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    // EnqueuePatient: Adds a patient to the priority queue.
    public void EnqueuePatient(Patient patient)
    {
        // The patient is enqueued with their priority value determining their place in the queue.
        queue.Enqueue(patient, patient.Priority);
    }

    // DequeuePatient: Removes and returns the patient with the highest priority from the queue.
    public Patient DequeuePatient()
    {
        // Try to dequeue a patient. If successful, return the patient; otherwise, return null.
        if (queue.TryDequeue(out Patient patient, out _))
        {
            return patient;
        }
        return null;
    }

    // ListPatients: Displays all patients currently in the queue.
    public void ListPatients()
    {
        // Heading for the queue listing.
        Console.WriteLine("Current Queue:");

        // Iterate over each patient in the queue (in no particular order) and display their details.
        foreach (var patient in queue.UnorderedItems)
        {
            Console.WriteLine($"{patient.Element} (Priority: {patient.Priority})");
        }
    }
}
//Key Points:

//PriorityQueue: Used to manage patients based on their priority.

//File Reading: The LoadPatientsFromFile method reads patient data from a CSV file.

//Patient Enqueueing: The EnqueuePatient method adds a patient to the queue.

//Patient Dequeueing: The DequeuePatient method removes and returns the patient with the highest priority.

//Listing Patients: The ListPatients method lists all patients in the queue, showing their priority.

//This code is structured to manage an emergency room queue where patients are prioritized and processed based on the urgency of their condition.