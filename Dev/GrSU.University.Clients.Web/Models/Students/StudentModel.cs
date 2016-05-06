namespace GrSU.University.Clients.Web.Models.Students
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class StudentModel
    {
        public int Id { get; set; }

        [DisplayName("Имя")]
        [Required(ErrorMessage = "Поле \"{0}\" обязательно.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Длина поля \"{0}\" должна быть от {2} до {1} символов.")]
        public string FirstName { get; set; }

        [DisplayName("Фамилия")]
        [Required(ErrorMessage = "Поле \"{0}\" обязательно.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Длина поля \"{0}\" должна быть от {2} до {1} символов.")]
        public string LastName { get; set; }

        [DisplayName("Группа")]
        [Required(ErrorMessage = "Поле \"{0}\" обязательно.")]
        public int GroupId { get; set; }

        public IEnumerable<SelectListItem> StudentGroups { get; set; }
    }
}