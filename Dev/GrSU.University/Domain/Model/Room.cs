namespace GrSU.University.Domain.Model
{
    using Common;

    public class Room : BaseModel
    {
        public string Number { get; set; }

        public int SitsCount { get; set; }
    }
}
