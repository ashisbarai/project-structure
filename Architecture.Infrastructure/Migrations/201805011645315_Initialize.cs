namespace Architecture.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialize : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 128),
                        Email = c.String(nullable: false, maxLength: 50),
                        Address = c.String(nullable: false, maxLength: 256),
                        CreatedOn = c.DateTimeOffset(nullable: false, precision: 7),
                        ManagerId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employee", t => t.ManagerId)
                .Index(t => t.ManagerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employee", "ManagerId", "dbo.Employee");
            DropIndex("dbo.Employee", new[] { "ManagerId" });
            DropTable("dbo.Employee");
        }
    }
}
