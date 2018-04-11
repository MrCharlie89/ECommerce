namespace Syntra.VDOAP.CProef.ECommerce.LIB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Languages",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        languagename = c.String(nullable: false),
                        iso = c.String(nullable: false),
                        localname = c.String(name: "local name"),
                        Created_At = c.DateTime(nullable: false),
                        Modified_At = c.DateTime(nullable: false),
                        Deleted_At = c.DateTime(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.localize_products",
                c => new
                    {
                        ProductID = c.Int(name: "Product ID", nullable: false),
                        languageID = c.Int(name: "language ID", nullable: false),
                        name = c.String(nullable: false, maxLength: 255),
                        descr = c.String(),
                        color = c.String(),
                        material = c.String(),
                    })
                .PrimaryKey(t => new { t.ProductID, t.languageID })
                .ForeignKey("dbo.Languages", t => t.languageID, cascadeDelete: true)
                .ForeignKey("dbo.products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID)
                .Index(t => t.languageID);
            
            CreateTable(
                "dbo.Localize_ProductCategory",
                c => new
                    {
                        categoryID = c.Int(name: "category ID", nullable: false),
                        languageID = c.Int(name: "language ID", nullable: false),
                        name = c.String(nullable: false, maxLength: 255),
                        descr = c.String(),
                    })
                .PrimaryKey(t => new { t.categoryID, t.languageID })
                .ForeignKey("dbo.Languages", t => t.languageID, cascadeDelete: true)
                .ForeignKey("dbo.product_categories", t => t.categoryID, cascadeDelete: true)
                .Index(t => t.categoryID)
                .Index(t => t.languageID);
            
            CreateTable(
                "dbo.product_categories",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        parent_id = c.Int(),
                        Created_At = c.DateTime(nullable: false),
                        Modified_At = c.DateTime(nullable: false),
                        Deleted_At = c.DateTime(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.product_categories", t => t.parent_id)
                .Index(t => t.parent_id);
            
            CreateTable(
                "dbo.products",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        category_ID = c.Int(nullable: false),
                        product_code = c.String(nullable: false, maxLength: 50),
                        unit_price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Current_Stock = c.Int(nullable: false),
                        is_active = c.Boolean(nullable: false),
                        Created_At = c.DateTime(nullable: false),
                        Modified_At = c.DateTime(nullable: false),
                        Deleted_At = c.DateTime(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.product_categories", t => t.category_ID, cascadeDelete: true)
                .Index(t => t.category_ID);
            
            CreateTable(
                "dbo.supplier",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        vatnumber = c.String(nullable: false, maxLength: 20),
                        suppliername = c.String(nullable: false, maxLength: 255),
                        streetname_and_number = c.String(nullable: false),
                        city = c.String(nullable: false),
                        postalcode = c.String(nullable: false),
                        phonenumber = c.String(nullable: false, maxLength: 15),
                        emailadress = c.String(nullable: false),
                        name_contact = c.String(),
                        contact_telephone_number = c.String(),
                        emailadress_contact = c.String(),
                        website = c.String(),
                        Created_At = c.DateTime(nullable: false),
                        Modified_At = c.DateTime(nullable: false),
                        Deleted_At = c.DateTime(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.users",
                c => new
                    {
                        user_id = c.Guid(nullable: false),
                        first_name = c.String(nullable: false, maxLength: 255),
                        last_name = c.String(nullable: false, maxLength: 255),
                        user_name = c.String(nullable: false, maxLength: 50),
                        encrypted_pwd = c.String(nullable: false, maxLength: 255),
                        pwd_salt = c.String(maxLength: 255),
                        email = c.String(nullable: false, maxLength: 255),
                        Created_At = c.DateTime(nullable: false),
                        Modified_At = c.DateTime(nullable: false),
                        Deleted_At = c.DateTime(),
                    })
                .PrimaryKey(t => t.user_id)
                .Index(t => t.user_name, unique: true)
                .Index(t => t.email, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.products", "category_ID", "dbo.product_categories");
            DropForeignKey("dbo.localize_products", "Product ID", "dbo.products");
            DropForeignKey("dbo.Localize_ProductCategory", "category ID", "dbo.product_categories");
            DropForeignKey("dbo.product_categories", "parent_id", "dbo.product_categories");
            DropForeignKey("dbo.Localize_ProductCategory", "language ID", "dbo.Languages");
            DropForeignKey("dbo.localize_products", "language ID", "dbo.Languages");
            DropIndex("dbo.users", new[] { "email" });
            DropIndex("dbo.users", new[] { "user_name" });
            DropIndex("dbo.products", new[] { "category_ID" });
            DropIndex("dbo.product_categories", new[] { "parent_id" });
            DropIndex("dbo.Localize_ProductCategory", new[] { "language ID" });
            DropIndex("dbo.Localize_ProductCategory", new[] { "category ID" });
            DropIndex("dbo.localize_products", new[] { "language ID" });
            DropIndex("dbo.localize_products", new[] { "Product ID" });
            DropTable("dbo.users");
            DropTable("dbo.supplier");
            DropTable("dbo.products");
            DropTable("dbo.product_categories");
            DropTable("dbo.Localize_ProductCategory");
            DropTable("dbo.localize_products");
            DropTable("dbo.Languages");
        }
    }
}
