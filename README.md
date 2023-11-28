Title: Emergency Room Queue Management System

Description:

The Emergency Room Queue Management System is a console-based application designed to streamline the management of patient queues in an emergency room (ER) setting. Developed in C#, this application offers a user-friendly interface to efficiently handle patient data and prioritize medical care based on urgency.

Key Features:

Patient Data Management:

Allows for the addition of new patients into the system, capturing essential information such as name, birthdate, and medical priority.
Prioritizes patients based on a defined urgency criterion, automatically escalating priority for patients under 21 or over 65 years of age.
Queue Handling:

Manages a dynamic queue of patients, sorting them according to their medical priority.
Facilitates the processing (dequeueing) of patients in order of priority, ensuring that those in most need receive attention first.
Data Initialization from File:

On startup, the system loads initial patient data from a CSV file, making it easy to pre-populate the queue with existing records.
The file path is relative, allowing for flexibility and ease of deployment across different systems.
User Interface:

Provides a simple, text-based menu system for easy navigation and operation.
Supports various operations like adding a patient, processing the current patient, listing all patients in the queue, and exiting the application.
Robust Error Handling:

Includes validations for user inputs, ensuring data integrity and correct operation.
Handles file reading errors gracefully, displaying informative messages to the user.
Use Case Scenario:

The system is ideal for emergency departments in hospitals, where managing a large influx of patients efficiently and fairly is crucial. It helps medical staff to triage patients effectively, ensuring that critical cases are attended to promptly. The application's simplicity makes it easy to use, even in high-stress environments.

Technical Aspects:

Developed using C# in a .NET environment.
Utilizes object-oriented programming principles for clear structure and maintainability.
Employs the PriorityQueue data structure for efficient queue management.
This description provides an overview of the system's functionality, features, and potential use case, highlighting its value in a medical emergency setting.






