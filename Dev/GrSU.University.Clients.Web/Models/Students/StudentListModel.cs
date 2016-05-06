namespace GrSU.University.Clients.Web.Models.Students
{
    public class StudentListModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public GroupModel Group { get; set; }
    }
}