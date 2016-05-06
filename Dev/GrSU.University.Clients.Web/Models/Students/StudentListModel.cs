namespace GrSU.University.Clients.Web.Models.Students
{
    using System.ComponentModel;

    public class StudentListModel
    {
        public int Id { get; set; }

        [DisplayName("Имя")]
        public string FirstName { get; set; }

        [DisplayName("Фамилия")]
        public string LastName { get; set; }

        [DisplayName("Группа")]
        public GroupModel Group { get; set; }
    }
}