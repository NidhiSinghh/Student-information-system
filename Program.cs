using sis_v2.Service;

ISISService isisService=new SISservice();

while (true)
{
    Console.WriteLine("1.Display Student information");
    Console.WriteLine("2.UpdateStudentInfo");
    Console.WriteLine("3.GetEnrolledCourses()");
    Console.WriteLine("4.EnrollInCourse()");
    Console.WriteLine("5.MakePayment()");
    Console.WriteLine("6.GetPaymentHistory()");
    Console.WriteLine("7.DisplayCourseInfo()");
    Console.WriteLine("8.DisplayTeacherInfo()");
    Console.WriteLine("9.UpdateCourseInfo");
    Console.WriteLine("10.GetEnrollments()");
    Console.WriteLine("11.GetTeacher()");
    Console.WriteLine("12. GetStudentWithEnrollment()");
    Console.WriteLine("13. GetCourse()");
    Console.WriteLine("14. UpdateTeacherInfo()");
    Console.WriteLine("15. GetAssignedCourses()");
    Console.WriteLine("16. GetStudentWithPayment()");
    Console.WriteLine("17. GetPaymentAmount()");
    Console.WriteLine("18. GetPaymentDate()");


    Console.WriteLine("Enter choice");
    int choice=int.Parse(Console.ReadLine());

    switch(choice)
    {
        case 1:
            isisService.DisplayStudentInfo();
            break;
        case 2:
            isisService.UpdateStudentInfo(); 
            break;
        case 3:
            isisService.GetEnrolledCourses();
            break;
        case 4:
            isisService.EnrollInCourse();
            break;
        case 5:
            isisService.MakePayment();
            break;
        case 6:
            isisService.GetPaymentHistory();
            break;
        case 7:
            isisService.DisplayCourseInfo();
            break;
        case 8:
            isisService.DisplayTeacherInfo();
            break;
        case 9:
            isisService.UpdateCourseInfo();
            break;
        case 10:
            isisService.GetEnrollments();
            break;
        case 11:
            isisService.GetTeacher();
            break;
        case 12:
            isisService.GetStudentWithEnrollment();
            break;
        case 13:
            isisService.GetCourse();
            break;
        case 14:
            isisService.UpdateTeacherInfo();
            break;
        case 15:
            isisService.GetAssignedCourses();
            break;
        case 16:
            isisService.GetStudentWithPayment();
            break;
        case 17:
            isisService.GetPaymentAmount();
            break;
        case 18:
            isisService.GetPaymentDate();
            break;
        default:
            Console.WriteLine("Enter correct choice");
            break;
    }
}