namespace GrSU.University.Domain.Model
{
    using Common;

    public class Employee : BaseModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Position { get; set; }
    }
}
