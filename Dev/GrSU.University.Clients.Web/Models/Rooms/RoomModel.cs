namespace GrSU.University.Clients.Web.Models.Rooms
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class RoomModel
    {
        public int Id { get; set; }
        
        [Required]
        [DisplayName("Название аудитории")]

        [Validation("Ошибка {0}")]
        public string Number { get; set; }

        [Required]
        public int SitsCount { get; set; }
    }
}