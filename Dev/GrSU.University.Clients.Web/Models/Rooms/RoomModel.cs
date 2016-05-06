namespace GrSU.University.Clients.Web.Models.Rooms
{
    using System.ComponentModel.DataAnnotations;
    using Resources;
    using Resources.Entities;

    public class RoomModel
    {
        public int Id { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = "Name")]
        [Required(ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "Required")]
        [StringLength(50, MinimumLength = 2, ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "StringLength")]
        public string Number { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = "SitsCount")]
        [Required(ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "Required")]
        public int SitsCount { get; set; }
    }
}