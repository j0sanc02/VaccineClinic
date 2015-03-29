namespace UniversityofLouisvilleVaccine.DataContexts.GrantInfoMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GrantInfoes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        grantTitle = c.String(nullable: false),
                        grantStart = c.DateTime(nullable: false),
                        grantEnd = c.DateTime(nullable: false),
                        grantAmount = c.Int(nullable: false),
                        grantFunder = c.String(nullable: false),
                        collaborator = c.String(nullable: false),
                        coordName = c.String(nullable: false),
                        deadline = c.DateTime(nullable: false),
                        maxPages = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.GrantInfoes");
        }
    }
}
