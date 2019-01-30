namespace BusinessEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Proveedor", "num_Documento", c => c.String(nullable: false, maxLength: 10, storeType: "nvarchar"));
            DropColumn("dbo.Proveedor", "num_Caracter");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Proveedor", "num_Caracter", c => c.String(nullable: false, maxLength: 10, storeType: "nvarchar"));
            DropColumn("dbo.Proveedor", "num_Documento");
        }
    }
}
