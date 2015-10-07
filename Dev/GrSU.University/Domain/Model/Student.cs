namespace GrSU.University.Domain.Model
{
    using Common;

    public class Student : BaseModel
    {
        private int groupId;

        private StudentGroup group;

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int GroupId
        {
            get { return groupId; }
            set
            {
                if (value == groupId)
                {
                    return;
                }

                groupId = value;
                group = null;
            }
        }

        public StudentGroup Group
        {
            get { return group; }
            set
            {
                group = value;
                groupId = group == null ? default(int) : group.Id;
            }
        }

        public override object Clone()
        {
            return new Student
                   {
                       Id = this.Id,
                       FirstName = this.FirstName,
                       GroupId = this.GroupId,
                       Group = (StudentGroup)this.Group.Clone(),
                       LastName = this.LastName
                   };
        }

        public override void SetNullReferences()
        {
            base.SetNullReferences();
            this.group = null;
        }

        public override void Map(object objTo)
        {
            if (!(objTo is Student))
            {
                return;
            }

            var typedObj = (Student) objTo;
            typedObj.FirstName = this.FirstName;
            typedObj.LastName = this.FirstName;
            typedObj.Group = (StudentGroup)this.Group.Clone();
        }
    }
}
