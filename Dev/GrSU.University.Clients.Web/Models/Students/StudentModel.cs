namespace GrSU.University.Clients.Web.Models.Students
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using Resources;
    using Resources.Entities;

    public class StudentModel
    {
        public int Id { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = "FirstName")]
        [Required(ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "Required")]
        [StringLength(50, MinimumLength = 2, ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "StringLength")]
        public string FirstName { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = "LastName")]
        [Required(ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "Required")]
        [StringLength(50, MinimumLength = 2, ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "StringLength")]
        public string LastName { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = "Group")]
        [Required(ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "Required")]
        public int GroupId { get; set; }

        public IEnumerable<SelectListItem> StudentGroups { get; set; }
    }
}