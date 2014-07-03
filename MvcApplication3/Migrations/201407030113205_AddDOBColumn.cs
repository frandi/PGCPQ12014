namespace MvcApplication3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDOBColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "DOB", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.People", "DOB");
        }
    }
}
