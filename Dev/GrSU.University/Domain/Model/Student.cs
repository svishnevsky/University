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
    }
}
