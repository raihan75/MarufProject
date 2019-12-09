namespace CompileError.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SupplierPurchaseRelationCreated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Purchases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BillNo = c.String(),
                        SupplierId = c.String(),
                        Date = c.String(),
                        Supplier_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Suppliers", t => t.Supplier_Id)
                .Index(t => t.Supplier_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Purchases", "Supplier_Id", "dbo.Suppliers");
            DropIndex("dbo.Purchases", new[] { "Supplier_Id" });
            DropTable("dbo.Purchases");
        }
    }
}
