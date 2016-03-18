namespace GrSU.University.Data.Model
{
    using Common;

    public class Student : BaseModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int GroupId { get; set; }
    }
}
