namespace GrSU.University.Domain.Model
{
    using Common;

    public class Room : BaseModel
    {
        public string Number { get; set; }

        public int SitsCount { get; set; }
        public override object Clone()
        {
            throw new System.NotImplementedException();
        }

        public override void Map(object objTo)
        {
            throw new System.NotImplementedException();
        }
    }
}
