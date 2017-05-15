namespace TedShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_AdModUser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdMods",
                c => new
                    {
                        AdMod_ID = c.Long(nullable: false, identity: true),
                        AdModCode = c.String(nullable: false),
                        AdModName = c.String(nullable: false),
                        AdMod_OnLoad = c.String(),
                        AdMod_Image = c.String(),
                        AdMod_Url = c.String(),
                        AdMod_Parent = c.Long(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 256),
                        MetaKeyword = c.String(maxLength: 256),
                        MetaDescription = c.String(maxLength: 256),
                        Status = c.Boolean(nullable: false),
                        AdMod_Group_Group_ID = c.Int(),
                    })
                .PrimaryKey(t => t.AdMod_ID)
                .ForeignKey("dbo.GroupMods", t => t.AdMod_Group_Group_ID)
                .Index(t => t.AdMod_Group_Group_ID);
            
            CreateTable(
                "dbo.AdModApplicationUsers",
                c => new
                    {
                        AdMod_AdMod_ID = c.Long(nullable: false),
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.AdMod_AdMod_ID, t.ApplicationUser_Id })
                .ForeignKey("dbo.AdMods", t => t.AdMod_AdMod_ID, cascadeDelete: true)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .Index(t => t.AdMod_AdMod_ID)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AdModApplicationUsers", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.AdModApplicationUsers", "AdMod_AdMod_ID", "dbo.AdMods");
            DropForeignKey("dbo.AdMods", "AdMod_Group_Group_ID", "dbo.GroupMods");
            DropIndex("dbo.AdModApplicationUsers", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.AdModApplicationUsers", new[] { "AdMod_AdMod_ID" });
            DropIndex("dbo.AdMods", new[] { "AdMod_Group_Group_ID" });
            DropTable("dbo.AdModApplicationUsers");
            DropTable("dbo.AdMods");
        }
    }
}
