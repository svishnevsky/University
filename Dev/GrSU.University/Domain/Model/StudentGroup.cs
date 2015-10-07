namespace GrSU.University.Domain.Model
{
    using Common;

    public class StudentGroup : BaseModel
    {
        public string Name { get; set; }

        public override object Clone()
        {
            return new StudentGroup
                   {
                       Id = this.Id,
                       Name = this.Name
                   };
        }

        public override void Map(object objTo)
        {
            if (!(objTo is StudentGroup))
            {
                return;
            }

            var group = (StudentGroup) objTo;
            group.Name = this.Name;
        }
    }
}
