namespace Syntra.VDOAP.CProef.ECommerce.LIB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Images : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Product_Images",
                c => new
                    {
                        image_ID = c.Int(nullable: false, identity: true),
                        product_ID = c.Int(nullable: false),
                        order = c.Int(nullable: false),
                        image_URL = c.String(),
                    })
                .PrimaryKey(t => t.image_ID)
                .ForeignKey("dbo.products", t => t.product_ID, cascadeDelete: true)
                .Index(t => t.product_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product_Images", "product_ID", "dbo.products");
            DropIndex("dbo.Product_Images", new[] { "product_ID" });
            DropTable("dbo.Product_Images");
        }
    }
}
