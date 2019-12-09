namespace CompileError.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductPurchasedProductRelationEstablished : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PurchasedProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PurchaseId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        ManufactureDate = c.String(),
                        ExpireDate = c.String(),
                        Quantity = c.Double(nullable: false),
                        UnitPrice = c.Double(nullable: false),
                        Mrp = c.Double(nullable: false),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Purchases", t => t.PurchaseId, cascadeDelete: true)
                .Index(t => t.PurchaseId);
            
            AddColumn("dbo.Products", "PurchasedProduct_Id", c => c.Int());
            CreateIndex("dbo.Products", "PurchasedProduct_Id");
            AddForeignKey("dbo.Products", "PurchasedProduct_Id", "dbo.PurchasedProducts", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PurchasedProducts", "PurchaseId", "dbo.Purchases");
            DropForeignKey("dbo.Products", "PurchasedProduct_Id", "dbo.PurchasedProducts");
            DropIndex("dbo.PurchasedProducts", new[] { "PurchaseId" });
            DropIndex("dbo.Products", new[] { "PurchasedProduct_Id" });
            DropColumn("dbo.Products", "PurchasedProduct_Id");
            DropTable("dbo.PurchasedProducts");
        }
    }
}
