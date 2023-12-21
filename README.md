# Student Information System (SIS) Project

## Overview

This project implements a Student Information System (SIS) in C# . The system encompasses more than 15 essential features to manage students, courses, enrollments, teachers, and payments.Users can interact with the system using the console menu, facilitating easy navigation and execution of various operations.
## Directory Structure

The project follows a structured directory layout:

- **model**: Contains entity classes with attributes representing real-world entities.
- **repository**: Holds Service Provider interfaces/abstract classes showcasing functionalities.
- **exception**: Contains user-defined exceptions and handles exceptions whenever needed.
- **utility**: Includes utility classes for database properties and connections.
- **main**: MainModule class demonstrating functionalities in a menu-driven application.

## Key Functionalities

1. **Teacher Management:**
   - Update Teacher Information
   - Display the information
   - Retrieve assigned courses

2. **Student Management:**
   - Enroll a student
   - Update and display student information
   - Record a payment by student
   - Retrieve a list of courses in which a student is enrolled.
   - Retrieve a list of payment records for a student.

3. **Course Management:**
   - Assign Teacher to a course
   - Retrieve a list of student enrollments for a course
   - Update and display Course Information
   - Retrieve assigned Teacher for a course

4. **Enrollment Management:**
   - Retrieve Student associated with the Enrollment
   - Retrieve Course associated with the Enrollment

5. **Payment Handling:**
   - Retrieve Student for Payment
   - Retrieve Payment Amount and Payment Date

## Database Design

### Tables

1. **Students**
   - student_id (Primary Key)
   - first_name
   - last_name
   - date_of_birth
   - email
   - phone_number

2. **Courses**
   - course_id (Primary Key)
   - course_name
   - credits
   - teacher_id (Foreign Key)

3. **Enrollments**
   - enrollment_id (Primary Key)
   - student_id (Foreign Key)
   - course_id (Foreign Key)
   - enrollment_date

4. **Teacher**
   - teacher_id (Primary Key)
   - first_name
   - last_name
   - email

5. **Payments**
   - payment_id (Primary Key)
   - student_id (Foreign Key)
   - amount
   - payment_date

## Getting Started

1. Clone the repository: `https://github.com/NidhiSinghh/Student-information-system.git`
2. Set up your SQL database and update connection details in `DBUtil` class and `appsettings.json` file.

## Packages Used

The Car Rental System project utilizes the following key packages:

1. **Microsoft.Extensions.Configuration**
2. **Microsoft.Extensions.Configuration.Abstractions**
3. **Microsoft.Extensions.Configuration.FileExtensions**
4. **Microsoft.Extensions.Configuration.Json**
5. **System.Data.SqlClient**
   
## Running the Application

Compile and run the `Program.cs` class to start the menu-driven application.

## Contributors

- Nidhi Singh

