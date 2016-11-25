namespace UniversityIot.UsersDataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2Constraint : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Name", c => c.String());
        }
    }
}
