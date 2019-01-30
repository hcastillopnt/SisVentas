namespace BusinessEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Trabajador", "acceso", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Trabajador", "acceso", c => c.String(nullable: false, maxLength: 20, storeType: "nvarchar"));
        }
    }
}
