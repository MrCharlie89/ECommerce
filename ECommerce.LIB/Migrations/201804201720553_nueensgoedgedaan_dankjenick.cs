namespace Syntra.VDOAP.CProef.ECommerce.LIB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nueensgoedgedaan_dankjenick : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.products", "category_ID", "dbo.product_categories");
            DropIndex("dbo.products", new[] { "category_ID" });
            AlterColumn("dbo.products", "category_ID", c => c.Int());
            CreateIndex("dbo.products", "category_ID");
            AddForeignKey("dbo.products", "category_ID", "dbo.product_categories", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.products", "category_ID", "dbo.product_categories");
            DropIndex("dbo.products", new[] { "category_ID" });
            AlterColumn("dbo.products", "category_ID", c => c.Int(nullable: false));
            CreateIndex("dbo.products", "category_ID");
            AddForeignKey("dbo.products", "category_ID", "dbo.product_categories", "id", cascadeDelete: true);
        }
    }
}
