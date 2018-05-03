namespace Syntra.VDOAP.CProef.ECommerce.LIB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class redo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.localize_products", "name", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.localize_products", "descr", c => c.String());
            AddColumn("dbo.localize_products", "color", c => c.String());
            AddColumn("dbo.localize_products", "material", c => c.String());
            DropColumn("dbo.localize_products", "Product name English");
            DropColumn("dbo.localize_products", "Product name Dutch");
            DropColumn("dbo.localize_products", "descr English");
            DropColumn("dbo.localize_products", "descr Dutch");
            DropColumn("dbo.localize_products", "color English");
            DropColumn("dbo.localize_products", "color Dutch");
            DropColumn("dbo.localize_products", "material English");
            DropColumn("dbo.localize_products", "material Dutch");
        }
        
        public override void Down()
        {
            AddColumn("dbo.localize_products", "material Dutch", c => c.String());
            AddColumn("dbo.localize_products", "material English", c => c.String());
            AddColumn("dbo.localize_products", "color Dutch", c => c.String());
            AddColumn("dbo.localize_products", "color English", c => c.String());
            AddColumn("dbo.localize_products", "descr Dutch", c => c.String());
            AddColumn("dbo.localize_products", "descr English", c => c.String());
            AddColumn("dbo.localize_products", "Product name Dutch", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.localize_products", "Product name English", c => c.String(nullable: false, maxLength: 255));
            DropColumn("dbo.localize_products", "material");
            DropColumn("dbo.localize_products", "color");
            DropColumn("dbo.localize_products", "descr");
            DropColumn("dbo.localize_products", "name");
        }
    }
}
