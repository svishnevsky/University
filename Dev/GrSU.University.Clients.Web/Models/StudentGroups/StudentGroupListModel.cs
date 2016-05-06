namespace GrSU.University.Clients.Web.Models.StudentGroups
{
    using System.ComponentModel;

    public class StudentGroupListModel
    {
        public int Id { get; set; }

        [DisplayName("Название")]
        public string Name { get; set; }

        [DisplayName("Количество студентов")]
        public int StudentCount { get; set; }
    }
}