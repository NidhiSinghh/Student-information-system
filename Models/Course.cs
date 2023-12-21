using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sis_v2.Models
{
    internal class Course
    {
        public int CourseId { get; set; }
        public string? CourseName { get; set; }
        public int? Credits { get; set; }
        public int? TeacherId { get; set; }

        //public Course() { }
        //public Course(int id, string courseName, int credits, int teacherId)
        //{
        //    CourseId = id;
        //    CourseName = courseName;
        //    Credits = credits;
        //    TeacherId = teacherId;

        //}
        public override string ToString()
        {
            return $"Course Id:{CourseId}\tCourse Name:{CourseName}\tCredits: {Credits}\tTeacher Id:{TeacherId} ";
        }

    }
}

