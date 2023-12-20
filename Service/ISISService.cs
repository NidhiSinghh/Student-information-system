using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sis_v2.Service
{
    internal interface ISISService
    {

        void DisplayStudentInfo();
       void UpdateStudentInfo();
        void GetEnrolledCourses();
       void EnrollInCourse();
        void MakePayment();
    }
}
