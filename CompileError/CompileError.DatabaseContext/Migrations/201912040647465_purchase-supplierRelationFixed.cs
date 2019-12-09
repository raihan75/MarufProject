namespace CompileError.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class purchasesupplierRelationFixed : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Purchases", "Supplier_Id", "dbo.Suppliers");
            DropIndex("dbo.Purchases", new[] { "Supplier_Id" });
            DropColumn("dbo.Purchases", "SupplierId");
            RenameColumn(table: "dbo.Purchases", name: "Supplier_Id", newName: "SupplierId");
            AlterColumn("dbo.Purchases", "SupplierId", c => c.Int(nullable: false));
            AlterColumn("dbo.Purchases", "SupplierId", c => c.Int(nullable: false));
            CreateIndex("dbo.Purchases", "SupplierId");
            AddForeignKey("dbo.Purchases", "SupplierId", "dbo.Suppliers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Purchases", "SupplierId", "dbo.Suppliers");
            DropIndex("dbo.Purchases", new[] { "SupplierId" });
            AlterColumn("dbo.Purchases", "SupplierId", c => c.Int());
            AlterColumn("dbo.Purchases", "SupplierId", c => c.String());
            RenameColumn(table: "dbo.Purchases", name: "SupplierId", newName: "Supplier_Id");
            AddColumn("dbo.Purchases", "SupplierId", c => c.String());
            CreateIndex("dbo.Purchases", "Supplier_Id");
            AddForeignKey("dbo.Purchases", "Supplier_Id", "dbo.Suppliers", "Id");
        }
    }
}
