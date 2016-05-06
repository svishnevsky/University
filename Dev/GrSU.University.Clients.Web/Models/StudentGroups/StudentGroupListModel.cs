namespace GrSU.University.Clients.Web.Models.StudentGroups
{
    using System.ComponentModel.DataAnnotations;
    using Resources.Entities;

    public class StudentGroupListModel
    {
        public int Id { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = "Name")]
        public string Name { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = "StudentCount")]
        public int StudentCount { get; set; }
    }
}