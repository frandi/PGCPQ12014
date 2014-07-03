namespace MvcApplication3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDepartment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentId = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(),
                    })
                .PrimaryKey(t => t.DepartmentId);
            
            AddColumn("dbo.People", "DepartmentId", c => c.Int());
            CreateIndex("dbo.People", "DepartmentId");
            AddForeignKey("dbo.People", "DepartmentId", "dbo.Departments", "DepartmentId");
            DropColumn("dbo.People", "Department");
        }
        
        public override void Down()
        {
            AddColumn("dbo.People", "Department", c => c.String());
            DropForeignKey("dbo.People", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.People", new[] { "DepartmentId" });
            DropColumn("dbo.People", "DepartmentId");
            DropTable("dbo.Departments");
        }
    }
}
