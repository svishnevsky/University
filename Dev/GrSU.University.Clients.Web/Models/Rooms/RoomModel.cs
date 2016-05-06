namespace GrSU.University.Clients.Web.Models.Rooms
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class RoomModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле \"{0}\" обязательно.")]
        [DisplayName("Название")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Длина поля \"{0}\" должна быть от {2} до {1} символов.")]
        public string Number { get; set; }

        [Required(ErrorMessage = "Поле \"{0}\" обязательно.")]
        [DisplayName("Количество мест")]
        public int SitsCount { get; set; }
    }
}