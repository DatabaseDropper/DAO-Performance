using System;

namespace tasks
{
    public class Course
    {
        public Guid CourseId { get; set; } = Guid.NewGuid();

        public string Name { get; set; }

        public int StudentID { get; set; }
    }
}