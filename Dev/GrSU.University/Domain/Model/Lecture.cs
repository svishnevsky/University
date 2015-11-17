namespace GrSU.University.Domain.Model
{
    using System;
    using Common;

    public class Lecture : BaseModel
    {
        private int lectorId;

        private Employee lector;

        private int groupId;

        private StudentGroup group;

        private int roomId;

        private Room room;

        public int LectorId
        {
            get { return lectorId; }
            set
            {
                if (value == lectorId)
                {
                    return;
                }

                lectorId = value;
                lector = null;
            }
        }

        public Employee Lector
        {
            get { return Lector; }
            set
            {
                lector = value;
                lectorId = lector == null ? default(int) : lector.Id;
            }
        }

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

        public int RoomId
        {
            get { return roomId; }
            set
            {
                if (value == roomId)
                {
                    return;
                }

                roomId = value;
                room = null;
            }
        }

        public Room Room
        {
            get { return room; }
            set
            {
                room = value;
                roomId = room == null ? default(int) : room.Id;
            }
        }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }
    }
}
