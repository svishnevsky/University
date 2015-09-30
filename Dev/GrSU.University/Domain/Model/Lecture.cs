namespace GrSU.University.Domain.Model
{
    using System;
    using Common;

    public class Lecture : BaseModel
    {
        public Employee Lector { get; set; }

        public StudentGroup Group { get; set; }

        public Room Room { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }
    }
}
