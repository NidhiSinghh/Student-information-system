--ASSIGNMENT2

CREATE DATABASE SIS;
USE SIS;


select * from students;
select * from PAYMENTS;
select * from courses;
select * from TEACHER;
select * from Enrollments;
select * from PAYMENTS;

Select * from Payments where STUDENT_ID=2 ORDER BY PAYMENT_DATE DESC;
--Select COURSE_ID FROM COURSES WHERE COURSE_NAME='physics';
--CREATE STUDENTS TABLE
CREATE TABLE STUDENTS
(
STUDENT_ID INT IDENTITY PRIMARY KEY,
FIRST_NAME VARCHAR(20) NOT NULL,
LAST_NAME VARCHAR(20) ,
EMAIL VARCHAR(30) NOT NULL,
PHONE VARCHAR(10) NOT NULL,
DOB DATE NOT NULL,
)
CREATE TABLE TEACHER
(
TEACHER_ID INT IDENTITY PRIMARY KEY,
FIRST_NAME VARCHAR(20) NOT NULL,
LAST_NAME VARCHAR(20) ,
EMAIL VARCHAR(30) NOT NULL,
)
CREATE TABLE COURSES
(

COURSE_ID INT IDENTITY PRIMARY KEY,
TEACHER_ID INT NOT NULL,
COURSE_NAME VARCHAR(20) NOT NULL ,
CREDITS INT NOT NULL,
FOREIGN KEY(TEACHER_ID) REFERENCES TEACHER(TEACHER_ID)
)

CREATE TABLE Enrollments
(

Enrollment_ID INT IDENTITY PRIMARY KEY,
STUDENT_ID INT NOT NULL,
COURSE_ID INT NOT NULL ,
Enrollment_DATE DATE NOT NULL,
FOREIGN KEY(STUDENT_ID) REFERENCES STUDENTS(STUDENT_ID),
FOREIGN KEY(COURSE_ID) REFERENCES COURSES(COURSE_ID)
)
CREATE TABLE PAYMENTS
(

PAYMENT_ID INT IDENTITY PRIMARY KEY,
STUDENT_ID INT NOT NULL,
AMOUNT FLOAT NOT NULL ,
PAYMENT_DATE DATE NOT NULL,
FOREIGN KEY(STUDENT_ID) REFERENCES STUDENTS(STUDENT_ID),

)

SELECT * FROM STUDENTS
SELECT * FROM TEACHER

INSERT INTO STUDENTS (first_name,last_name,dOB,email,phone)
VALUES 
('John', 'Doe', '1990-01-15', 'john.doe@example.com', '1234567890'),
  ('Jane', 'Smith', '1992-05-20', 'jane.smith@example.com', '9876543210'),
  ('Bob', 'Johnson', '1988-08-10', 'bob.johnson@example.com', '5551234567');

INSERT INTO STUDENTS (first_name,last_name,dOB,email,phone)
VALUES 
   ('Alice', 'Williams', '1995-03-08', 'alice.williams@example.com', '4567890123'),
  ('Charlie', 'Brown', '1991-11-30', 'charlie.brown@example.com', '7890123456'),
  ('Eva', 'Clark', '1987-07-22', 'eva.clark@example.com', '3210987654'),
  ('David', 'Miller', '1993-09-18', 'david.miller@example.com', '2345678901'),
  ('Sophia', 'Garcia', '1989-12-05', 'sophia.garcia@example.com', '8765432109'),
  ('Jack', 'White', '1994-04-12', 'jack.white@example.com', '9876543210'),
  ('Olivia', 'Jones', '1996-06-25', 'olivia.jones@example.com', '2345678901');
  SELECT * FROM STUDENTS;

  INSERT INTO TEACHER(first_name,last_name,email)
 values ('Smith', 'doe', 'prof.smith@example.com');

 INSERT INTO Teacher (first_name, last_name, email)
VALUES
  ('Emma', 'Johnson', 'emma.johnson@example.com'),
  ('Michael', 'Davis', 'michael.davis@example.com'),
  ('Ava', 'Wilson', 'ava.wilson@example.com'),
  ('James', 'Lee', 'james.lee@example.com'),
  ('Sophia', 'Brown', 'sophia.brown@example.com'),
  ('Daniel', 'Wang', 'daniel.wang@example.com'),
  ('Olivia', 'Taylor', 'olivia.taylor@example.com'),
  ('Ethan', 'Miller', 'ethan.miller@example.com'),
  ('Grace', 'Anderson', 'grace.anderson@example.com');

  SELECT * FROM TEACHER;


INSERT INTO Courses (course_name, credits, teacher_id)
VALUES
  ('Mathematics', 3, 1),
  ('History', 4, 2),
  ('Physics', 3, 3),
  ('Computer Science', 4, 1),
  ('English Literature', 3, 2),
  ('Chemistry', 3, 3),
  ('Economics', 4, 1),
  ('Biology', 3, 2),
  ('Art History', 4, 3),
  ('Geography', 3, 1);

  INSERT INTO Enrollments (student_id, course_id, enrollment_date)
VALUES
  (11, 1, '2023-01-01'),
  (2, 2, '2023-01-15'),
  (3, 3, '2023-02-01'),
  (4, 4, '2023-02-15'),
  (5, 5, '2023-03-01'),
  (6, 6, '2023-03-15'),
  (7, 7, '2023-04-01'),
  (8, 8, '2023-04-15'),
  (9, 9, '2023-05-01'),
  (10, 10, '2023-05-15');

  select * from Enrollments

 INSERT INTO Payments (student_id, amount, payment_date)
VALUES
  (11, 500, '2023-01-05'),
  (2, 600, '2023-02-10'),
  (3, 450, '2023-03-15'),
  (4, 550, '2023-04-20'),
  (5, 700, '2023-05-25'),
  (6, 400, '2023-06-30'),
  (7, 750, '2023-07-05'),
  (8, 480, '2023-08-10'),
  (9, 600, '2023-09-15'),
  (10, 550, '2023-10-20');

  use sis
--  b) Write SQL queries for the following tasks:
--1. Write an SQL query to insert a new student into the "Students" table with the following details:
--a. First Name: John
--b. Last Name: Doe
--c. Date of Birth: 1995-08-15
--d. Email: john.doe@example.com
--e. Phone Number: 1234567890

--SELECT * FROM STUDENTS
INSERT INTO STUDENTS(FIRST_NAME,LAST_NAME,DOB,EMAIL,PHONE)
VALUES ( 'Charlie', 'Brown', '1991-11-30', 'charlie.brown@example.com', '7890123456'  );

--2. Write an SQL query to enroll a student in a course. Choose an existing student and course and
--insert a record into the "Enrollments" table with the enrollment date.

INSERT INTO Enrollments (student_id, course_id, enrollment_date)
VALUES (4, 1, '2023-11-30');

--3. Update the email address of a specific teacher in the "Teacher" table. Choose any teacher and
--modify their email address.
UPDATE TEACHER 
SET EMAIL='New@mail.com' WHERE TEACHER_ID=2;
--4. Write an SQL query to delete a specific enrollment record from the "Enrollments" table. Select
--an enrollment record based on student and course.
DELETE FROM Enrollments
WHERE STUDENT_ID = 2 AND COURSE_ID = 1;

--5. Update the "Courses" table to assign a specific teacher to a course. Choose any course and
--teacher from the respective tables.
UPDATE COURSES
SET TEACHER_ID=8 WHERE TEACHER_ID=3 AND COURSE_ID=6;


--6. Delete a specific student from the "Students" table and remove all their enrollment records
--from the "Enrollments" table. Be sure to maintain referential integrity.

DELETE FROM Enrollments WHERE STUDENT_ID=4
DELETE FROM Payments WHERE student_id = 4
DELETE FROM STUDENTS WHERE STUDENT_ID=4

SELECT * FROM STUDENTS
SELECT * FROM Enrollments

--7. Update the payment amount for a specific payment record in the "Payments" table. Choose any
--payment record and modify the payment amount.

UPDATE PAYMENTS SET AMOUNT='2000' WHERE PAYMENT_ID=3;
SELECT * FROM PAYMENTS

--4. Joins:
--1. Write an SQL query to calculate the total payments made by a specific student. You will need to
--join the "Payments" table with the "Students" table based on the student's ID.

SELECT S.STUDENT_ID,S.FIRST_NAME,SUM(P.AMOUNT) AS TOTAL_PAYMENT
FROM PAYMENTS P JOIN STUDENTS S
ON P.STUDENT_ID=S.STUDENT_ID 
GROUP BY S.STUDENT_ID,S.FIRST_NAME


--2. Write an SQL query to retrieve a list of courses along with the count of students enrolled in each
--course. Use a JOIN operation between the "Courses" table and the "Enrollments" table.

--coursesid,name->enroll:stud_id

SELECT E.COURSE_ID,C.COURSE_NAME,COUNT(E.STUDENT_ID)
FROM COURSES C JOIN Enrollments E
ON C.COURSE_ID=E.COURSE_ID
GROUP BY E.COURSE_ID,C.COURSE_NAME

--3. Write an SQL query to find the names of students who have not enrolled in any course. Use a
--LEFT JOIN between the "Students" table and the "Enrollments" table to identify students
--without enrollments.

--stuname,id->enrol:

SELECT S.STUDENT_ID,S.FIRST_NAME
FROM STUDENTS S LEFT JOIN Enrollments E
ON S.STUDENT_ID=E.STUDENT_ID
WHERE E.STUDENT_ID IS NULL

--4. Write an SQL query to retrieve the first name, last name of students, and the names of the
--courses they are enrolled in. Use JOIN operations between the "Students" table and the
--"Enrollments" and "Courses" tables.

--stuid,->enrol:id,courseid->courseS:coursenames,


SELECT S.FIRST_NAME,S.LAST_NAME,C.COURSE_NAME
FROM STUDENTS S JOIN Enrollments E  ON S.STUDENT_ID=E.STUDENT_ID
JOIN COURSES   C                     ON C.COURSE_ID=E.COURSE_ID
GROUP BY S.STUDENT_ID,S.FIRST_NAME,S.LAST_NAME,C.COURSE_NAME



--5. Create a query to list the names of teachers and the courses they are assigned to. Join the
--"Teacher" table with the "Courses" table.

--teacherid->courses:courseid,name

SELECT T.TEACHER_ID,T.FIRST_NAME,T.LAST_NAME,C.COURSE_NAME
FROM TEACHER T JOIN COURSES C  ON T.TEACHER_ID=C.TEACHER_ID
GROUP BY  T.TEACHER_ID,T.FIRST_NAME,T.LAST_NAME,C.COURSE_enrolNAME

--6. Retrieve a list of students and their enrollment dates for a specific course. You'll need to join the
--"Students" table with the "Enrollments" and "Courses" tables.
--student:id->enrol:date

SELECT S.STUDENT_ID,S.FIRST_NAME,E.Enrollment_DATE
FROM STUDENTS S JOIN Enrollments E
ON S.STUDENT_ID=E.STUDENT_ID

--7. Find the names of students who have not made any payments. Use a LEFT JOIN between the
--"Students" table and the "Payments" table and filter for students with NULL payment records.
--stu:id->payment:stu_id

SELECT S.*
FROM STUDENTS S LEFT JOIN PAYMENTS P
ON S.STUDENT_ID=P.STUDENT_ID
WHERE P.STUDENT_ID IS NULL


--8. Write a query to identify courses that have no enrollments. You'll need to use a LEFT JOIN
--between the "Courses" table and the "Enrollments" table and filter for courses with NULL
--enrollment records.

SELECT C.*
FROM COURSES C LEFT JOIN Enrollments E
ON C.COURSE_ID=E.COURSE_ID
WHERE E.COURSE_ID IS NULL

--9. Identify students who are enrolled in more than one course. Use a self-join on the "Enrollments"
--table to find students with multiple enrollment records.
--stuid->coursrid->enroll

--without self join
--SELECT S.STUDENT_ID,S.FIRST_NAME,COUNT(C.COURSE_NAME) AS NO_OF_ENROLLED_COURSES
--FROM STUDENTS S JOIN Enrollments E   ON S.STUDENT_ID=E.STUDENT_ID
--JOIN COURSES C                       ON C.COURSE_ID=E.COURSE_ID
--GROUP BY S.STUDENT_ID,S.FIRST_NAME
--HAVING COUNT(C.COURSE_NAME) >1

SELECT E1.STUDENT_ID,COUNT(e1.course_id)
FROM Enrollments E1 JOIN Enrollments E2 ON e1.student_id = e2.student_id AND e1.course_id != e2.course_id
GROUP BY
e1.student_id
HAVING
COUNT(e1.course_id) > 1;



--10. Find teachers who are not assigned to any courses. Use a LEFT JOIN between the "Teacher"
--table and the "Courses" table and filter for teachers with NULL course assignments.

SELECT T.*
FROM Teacher T LEFT JOIN Courses C ON T.TEACHER_ID=C.TEACHER_ID     
WHERE C.TEACHER_ID IS NULL

--5. Aggregate Functions and Subqueries:
--1. Write an SQL query to calculate the average number of students enrolled in each course. Use
--aggregate functions and subqueries to achieve this.

SELECT AVG(CAST(count_of_enrolls AS FLOAT)) 
FROM(
SELECT course_id,COUNT(*) AS count_of_enrolls FROM Enrollments GROUP BY COURSE_ID ) AS count_enrollments


--2. Identify the student(s) who made the highest payment. Use a subquery to find the maximum
--payment amount and then retrieve the student(s) associated with that amount.

SELECT STUDENT_ID,FIRST_NAME FROM STUDENTS WHERE STUDENT_ID IN (
select Top 1 STUDENT_ID  FROM PAYMENTS ORDER BY AMOUNT DESC)



--3. Retrieve a list of courses with the highest number of enrollments. Use subqueries to find the
--course(s) with the maximum enrollment count.

SELECT COURSE_ID,COURSE_NAME  FROM COURSES WHERE COURSE_ID IN (
SELECT TOP 1 COURSE_ID FROM Enrollments GROUP BY COURSE_ID ORDER BY COUNT(*) desc)

--4 Calculate the average number of students enrolled in each course
SELECT
course_id,course_name,
(SELECT AVG(CAST(count_enrollments AS FLOAT))
FROM (SELECT course_id, COUNT(*) AS count_enrollments
FROM Enrollments
GROUP BY course_id) AS CourseEnrollments
WHERE CourseEnrollments.course_id = Courses.course_id) AS average_students_enrolled
FROM Courses;


--5. Identify students who are enrolled in all available courses. Use subqueries to compare a student's enrollments with the total number of courses.
SELECT S.student_id, S.first_name, S.last_name
FROM Students S
WHERE (SELECT COUNT(DISTINCT E.course_id) FROM Enrollments E WHERE E.student_id = S.student_id)
= (SELECT COUNT(DISTINCT course_id) 
FROM Courses)


--6. Retrieve the names of teachers who have not been assigned to any courses. Use subqueries to find teachers with no course assignments.
SELECT teacher_id,first_name,last_name
FROM Teacher T
WHERE teacher_id NOT IN (SELECT DISTINCT teacher_id FROM Courses WHERE teacher_id IS NOT NULL)


--7 Calculate the average age of all students. Use subqueries to calculate the age of each student
--based on their date of birth.

SELECT AVG(age) AS average_age
 FROM(
 SELECT DATEDIFF(YEAR,DOB,GETDATE())  AS age
 FROM Students
) AS student_age

--8. Identify courses with no enrollments. Use subqueries to find courses without enrollment records.
SELECT course_id,course_name
FROM Courses C
WHERE course_id NOT IN (SELECT DISTINCT course_id FROM Enrollments WHERE course_id IS NOT NULL)


--9. Calculate the total payments made by each student for each course they are enrlled in. Use subqueries and aggregate functions to sum payments.
SELECT student_id,course_id,COALESCE((SELECT SUM(amount) FROM Payments 
 WHERE student_id = Enrollments.student_id
 AND course_id = Enrollments.course_id), 0) AS total_payments
FROM Enrollments


--10. Identify students who have made more than one payment. Use subqueries and aggregate functions to count payments per student and filter for those with counts greater than one.
--functions to count payments per student and filter for those with counts greater than one.
SELECT STUDENT_ID,FIRST_NAME  FROM STUDENTS WHERE STUDENT_ID IN (
SELECT  STUDENT_ID FROM PAYMENTS GROUP BY STUDENT_ID HAVING COUNT(*) >1)


--11.Write an SQL query to calculate the total payments made by each student. Join the "Students"
--table with the "Payments" table and use GROUP BY to calculate the sum of payments for each
--student.
SELECT S.STUDENT_ID, COALESCE(sum(amount), 0)  AS sum_payment
FROM STUDENTS S LEFT JOIN PAYMENTS P
ON S.STUDENT_ID=P.STUDENT_ID
GROUP BY S.STUDENT_ID

--12  Retrieve a list of course names along with the count of students enrolled in each course. Use
--JOIN operations between the "Courses" table and the "Enrollments" table and GROUP BY to
--count enrollments.

SELECT C.COURSE_NAME,COUNT(*) AS student_count
FROM COURSES C JOIN Enrollments E
ON C.COURSE_ID=E.COURSE_ID GROUP BY C.COURSE_NAME


--13.Calculate the average payment amount made by students. Use JOIN operations between the
--"Students" table and the "Payments" table and GROUP BY to calculate the average.
SELECT S.STUDENT_ID, COALESCE(AVG(amount), 0)  AS average_payment
FROM STUDENTS S LEFT JOIN PAYMENTS P
ON S.STUDENT_ID=P.STUDENT_ID
GROUP BY S.STUDENT_ID

--Query 4 :- Calculate the total payments made to courses taught by each teacher. Use aggregate functions to sum 
--payments for each teacher's courses.

select * from Teacher
select * from Courses 
select * from Enrollments 
select * from Payments 

select Teacher.TEACHER_ID , sum(Payments.Amount) as Tot_Payments , Courses.COURSE_NAME
from Teacher
join Courses on Teacher.TEACHER_ID=Courses.TEACHER_ID
join Enrollments on Courses.COURSE_ID = Enrollments.COURSE_ID
join Payments on Enrollments.STUDENT_ID = Payments.STUDENT_ID
group by Teacher.TEACHER_ID , Courses.COURSE_NAME














































































































































































































