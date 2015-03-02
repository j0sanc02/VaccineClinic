namespace UniversityofLouisvilleVaccine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EventInitial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128),
                        title = c.String(),
                        start = c.String(),
                        hour = c.Double(nullable: false),
                        min = c.Double(nullable: false),
                        end = c.String(),
                        allDay = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Events");
        }
    }
}
