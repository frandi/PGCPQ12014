namespace MvcApplication3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveDOBColumn : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.People", "DOB");
        }
        
        public override void Down()
        {
            AddColumn("dbo.People", "DOB", c => c.DateTime());
        }
    }
}
