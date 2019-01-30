namespace BusinessEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Trabajador", "num_documento", c => c.String(nullable: false, maxLength: 15, storeType: "nvarchar"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Trabajador", "num_documento", c => c.String(nullable: false, maxLength: 8, storeType: "nvarchar"));
        }
    }
}
