namespace GrSU.University.Clients.Web.Models.Students
{
    using System.ComponentModel.DataAnnotations;
    using Resources.Entities;

    public class StudentListModel
    {
        public int Id { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = "FirstName")]
        public string FirstName { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = "LastName")]
        public string LastName { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = "Group")]
        public GroupModel Group { get; set; }
    }
}