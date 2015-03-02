namespace UniversityofLouisvilleVaccine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondEvent : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Events");
            AlterColumn("dbo.Events", "id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Events", "id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Events");
            AlterColumn("dbo.Events", "id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Events", "id");
        }
    }
}
