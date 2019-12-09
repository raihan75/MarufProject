namespace CompileError.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Product_PurchasedProductModified : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "PurchasedProduct_Id", "dbo.PurchasedProducts");
            DropIndex("dbo.Products", new[] { "PurchasedProduct_Id" });
            DropColumn("dbo.Products", "PurchasedProduct_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "PurchasedProduct_Id", c => c.Int());
            CreateIndex("dbo.Products", "PurchasedProduct_Id");
            AddForeignKey("dbo.Products", "PurchasedProduct_Id", "dbo.PurchasedProducts", "Id");
        }
    }
}
