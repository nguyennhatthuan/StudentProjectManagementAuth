namespace StudentProjectManagementAuth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Groups", "StatusId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Groups", "StatusId");
            AddForeignKey("dbo.Groups", "StatusId", "dbo.Status", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Groups", "StatusId", "dbo.Status");
            DropIndex("dbo.Groups", new[] { "StatusId" });
            DropColumn("dbo.Groups", "StatusId");
            DropTable("dbo.Status");
        }
    }
}
