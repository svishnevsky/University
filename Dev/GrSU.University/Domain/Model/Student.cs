namespace GrSU.University.Domain.Model
{
    using Common;

    public class Student : BaseModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public StudentGroup Group { get; set; }
    }
}
