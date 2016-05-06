namespace GrSU.University.Clients.Web.Models.Students
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    public class StudentModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int GroupId { get; set; }

        public IEnumerable<SelectListItem> StudentGroups { get; set; }
    }
}