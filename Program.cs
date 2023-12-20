using sis_v2.Service;

ISISService isisService=new SISservice();

while (true)
{
    Console.WriteLine("1.Display Student information");
    Console.WriteLine("2.UpdateStudentInfo");
    Console.WriteLine("3.GetEnrolledCourses()");
    Console.WriteLine("4.EnrollInCourse()");
    Console.WriteLine("5.MakePayment()");


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
        default:
            Console.WriteLine("Enter correct choice");
            break;
    }
}