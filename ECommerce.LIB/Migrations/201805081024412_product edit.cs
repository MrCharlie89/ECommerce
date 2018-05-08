namespace Syntra.VDOAP.CProef.ECommerce.LIB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class productedit : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.localize_products", name: "Product ID", newName: "id");
            RenameIndex(table: "dbo.localize_products", name: "IX_Product ID", newName: "IX_id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.localize_products", name: "IX_id", newName: "IX_Product ID");
            RenameColumn(table: "dbo.localize_products", name: "id", newName: "Product ID");
        }
    }
}
