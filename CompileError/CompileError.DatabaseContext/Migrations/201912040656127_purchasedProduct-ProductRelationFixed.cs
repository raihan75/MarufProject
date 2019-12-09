namespace CompileError.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class purchasedProductProductRelationFixed : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.PurchasedProducts", "ProductId");
            AddForeignKey("dbo.PurchasedProducts", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PurchasedProducts", "ProductId", "dbo.Products");
            DropIndex("dbo.PurchasedProducts", new[] { "ProductId" });
        }
    }
}
