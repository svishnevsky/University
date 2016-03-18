namespace GrSU.University.Data.Model
{
    using System;
    using Common;

    public class Lecture : BaseModel
    {
        public int LectorId { get; set; }

        public int GroupId { get; set; }

        public int RoomId { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }
    }
}
