namespace Syntra.VDOAP.CProef.ECommerce.LIB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Localize_ProductCategory", name: "name", newName: "Category name");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.Localize_ProductCategory", name: "Category name", newName: "name");
        }
    }
}
