namespace StudentProjectManagementAuth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProjectDetails",
                c => new
                    {
                        ProjectId = c.String(nullable: false, maxLength: 128),
                        GroupId = c.String(nullable: false, maxLength: 128),
                        StartDate = c.DateTime(),
                        EndDate = c.DateTime(),
                    })
                .PrimaryKey(t => new { t.ProjectId, t.GroupId })
                .ForeignKey("dbo.Groups", t => t.GroupId, cascadeDelete: true)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId)
                .Index(t => t.GroupId);
            
            CreateTable(
                "dbo.Projects",
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProjectDetails", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.ProjectDetails", "GroupId", "dbo.Groups");
            DropIndex("dbo.ProjectDetails", new[] { "GroupId" });
            DropIndex("dbo.ProjectDetails", new[] { "ProjectId" });
            DropTable("dbo.Projects");
            DropTable("dbo.ProjectDetails");
        }
    }
}
