namespace GrSU.University.Clients.Web.Models.Rooms
{
    using System.ComponentModel.DataAnnotations;
    using Resources.Entities;

    public class RoomListModel
    {
        public int Id { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = "Name")]
        public string Number { get; set; }

        [Display(ResourceType = typeof(DisplayNames), Name = "SitsCount")]
        public int SitsCount { get; set; }
    }
}