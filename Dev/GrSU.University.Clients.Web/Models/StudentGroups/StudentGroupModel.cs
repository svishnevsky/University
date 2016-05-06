namespace GrSU.University.Clients.Web.Models.StudentGroups
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class StudentGroupModel
    {
        public int Id { get; set; }

        [DisplayName("Название")]
        [Required(ErrorMessage = "Поле \"{0}\" обязательно.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Длина поля \"{0}\" должна быть от {2} до {1} символов.")]
        public string Name { get; set; }
    }
}