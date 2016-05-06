namespace GrSU.University.Clients.Web.Models.Rooms
{
    using System.ComponentModel;

    public class RoomListModel
    {
        public int Id { get; set; }

        [DisplayName("Название")]
        public string Number { get; set; }

        [DisplayName("Количество мест")]
        public int SitsCount { get; set; }
    }
}