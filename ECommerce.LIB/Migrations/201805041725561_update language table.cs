namespace Syntra.VDOAP.CProef.ECommerce.LIB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatelanguagetable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Languages", "Is active", c => c.Boolean(nullable: false));
            AddColumn("dbo.Languages", "Is default", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Languages", "Is default");
            DropColumn("dbo.Languages", "Is active");
        }
    }
}
