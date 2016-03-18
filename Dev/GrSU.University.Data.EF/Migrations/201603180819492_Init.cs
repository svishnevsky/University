namespace GrSU.University.Data.EF.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        RoomId = c.Int(nullable: false, identity: true),
                        Number = c.String(nullable: false, maxLength: 50),
                        SitsCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RoomId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 70),
                        LastName = c.String(nullable: false, maxLength: 70),
                        GroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StudentId)
                .ForeignKey("dbo.StudentGroups", s => s.GroupId, true, "Student_StudentGroups");
            
            CreateTable(
                "dbo.StudentGroups",
                c => new
                    {
                        StudentGroupId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.StudentGroupId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.StudentGroups");
            DropTable("dbo.Students");
            DropTable("dbo.Rooms");
        }
    }
}
