namespace GrSU.University.Clients.Web.Models.StudentGroups
{
    using System.ComponentModel.DataAnnotations;
    using Resources;
    using Resources.Entities;

    public class StudentGroupModel
    {
        public int Id { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = "Name")]
        [Required(ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "Required")]
        [StringLength(50, MinimumLength = 2, ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "StringLength")]
        public string Name { get; set; }
    }
}