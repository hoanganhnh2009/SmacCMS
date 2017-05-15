namespace TedShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_Mod_menu_Admod : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Menus", "GroupID", "dbo.MenuGroups");
            DropIndex("dbo.Menus", new[] { "GroupID" });
            CreateTable(
                "dbo.GroupMods",
                c => new
                    {
                        Group_ID = c.Int(nullable: false, identity: true),
                        Group_Name = c.String(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 256),
                        MetaKeyword = c.String(maxLength: 256),
                        MetaDescription = c.String(maxLength: 256),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Group_ID);
            
            CreateTable(
                "dbo.MenuItems",
                c => new
                    {
                        MenuItem_ID = c.Long(nullable: false, identity: true),
                        MenuItem_DisplayName = c.String(nullable: false),
                        MenuItem_Url = c.String(nullable: false),
                        MenuItem_Level = c.String(nullable: false),
                        Position = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 256),
                        MetaKeyword = c.String(maxLength: 256),
                        MetaDescription = c.String(maxLength: 256),
                        Status = c.Boolean(nullable: false),
                        Language_lang_ID = c.Int(nullable: false),
                        Menu_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MenuItem_ID)
                .ForeignKey("dbo.Languages", t => t.Language_lang_ID, cascadeDelete: true)
                .ForeignKey("dbo.Menus", t => t.Menu_ID, cascadeDelete: true)
                .Index(t => t.Language_lang_ID)
                .Index(t => t.Menu_ID);
            
            CreateTable(
                "dbo.Languages",
                c => new
                    {
                        lang_ID = c.Int(nullable: false, identity: true),
                        lang_Code = c.String(nullable: false),
                        lang_Name = c.String(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 256),
                        MetaKeyword = c.String(maxLength: 256),
                        MetaDescription = c.String(maxLength: 256),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.lang_ID);
            
            CreateTable(
                "dbo.SiteMod_Type",
                c => new
                    {
                        Modtype_ID = c.Int(nullable: false, identity: true),
                        Modtype_Code = c.String(nullable: false, maxLength: 50),
                        Modtype_Name = c.String(nullable: false, maxLength: 256),
                        Modtype_Desc = c.String(),
                    })
                .PrimaryKey(t => t.Modtype_ID);
            
            CreateTable(
                "dbo.SiteMods",
                c => new
                    {
                        Mod_ID = c.Long(nullable: false, identity: true),
                        Mod_Name = c.String(nullable: false, maxLength: 512),
                        Mod_Title = c.String(nullable: false, maxLength: 512),
                        Mod_Url = c.String(),
                        Mod_Code = c.String(),
                        Mod_Icon = c.String(maxLength: 50),
                        Mod_isSingleContent = c.String(),
                        Mod_SEOKey = c.String(maxLength: 1024),
                        Mod_SEODescription = c.String(maxLength: 1024),
                        Mod_SEOTitle = c.String(maxLength: 1024),
                        Mod_Content = c.String(maxLength: 1024),
                        Mod_Position = c.Int(nullable: false),
                        Mod_Parent = c.Int(nullable: false),
                        Mod_Type = c.Int(nullable: false),
                        Mod_Status = c.Int(nullable: false),
                        Mod_Lang = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 256),
                        MetaKeyword = c.String(maxLength: 256),
                        MetaDescription = c.String(maxLength: 256),
                        Status = c.Boolean(nullable: false),
                        Modtype_ID_Modtype_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Mod_ID)
                .ForeignKey("dbo.SiteMod_Type", t => t.Modtype_ID_Modtype_ID, cascadeDelete: true)
                .Index(t => t.Modtype_ID_Modtype_ID);
            
            AddColumn("dbo.Menus", "Menu_Code", c => c.String(nullable: false));
            AddColumn("dbo.Menus", "Menu_Name", c => c.String(nullable: false));
            AddColumn("dbo.Menus", "CreatedDate", c => c.DateTime());
            AddColumn("dbo.Menus", "CreatedBy", c => c.String(maxLength: 256));
            AddColumn("dbo.Menus", "UpdatedDate", c => c.DateTime());
            AddColumn("dbo.Menus", "UpdatedBy", c => c.String(maxLength: 256));
            AddColumn("dbo.Menus", "MetaKeyword", c => c.String(maxLength: 256));
            AddColumn("dbo.Menus", "MetaDescription", c => c.String(maxLength: 256));
            DropColumn("dbo.Menus", "Name");
            DropColumn("dbo.Menus", "URL");
            DropColumn("dbo.Menus", "DisplayOrder");
            DropColumn("dbo.Menus", "GroupID");
            DropColumn("dbo.Menus", "Target");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Menus", "Target", c => c.String(maxLength: 10));
            AddColumn("dbo.Menus", "GroupID", c => c.Int(nullable: false));
            AddColumn("dbo.Menus", "DisplayOrder", c => c.Int());
            AddColumn("dbo.Menus", "URL", c => c.String(nullable: false, maxLength: 256));
            AddColumn("dbo.Menus", "Name", c => c.String(nullable: false, maxLength: 50));
            DropForeignKey("dbo.SiteMods", "Modtype_ID_Modtype_ID", "dbo.SiteMod_Type");
            DropForeignKey("dbo.MenuItems", "Menu_ID", "dbo.Menus");
            DropForeignKey("dbo.MenuItems", "Language_lang_ID", "dbo.Languages");
            DropIndex("dbo.SiteMods", new[] { "Modtype_ID_Modtype_ID" });
            DropIndex("dbo.MenuItems", new[] { "Menu_ID" });
            DropIndex("dbo.MenuItems", new[] { "Language_lang_ID" });
            DropColumn("dbo.Menus", "MetaDescription");
            DropColumn("dbo.Menus", "MetaKeyword");
            DropColumn("dbo.Menus", "UpdatedBy");
            DropColumn("dbo.Menus", "UpdatedDate");
            DropColumn("dbo.Menus", "CreatedBy");
            DropColumn("dbo.Menus", "CreatedDate");
            DropColumn("dbo.Menus", "Menu_Name");
            DropColumn("dbo.Menus", "Menu_Code");
            DropTable("dbo.SiteMods");
            DropTable("dbo.SiteMod_Type");
            DropTable("dbo.Languages");
            DropTable("dbo.MenuItems");
            DropTable("dbo.GroupMods");
            CreateIndex("dbo.Menus", "GroupID");
            AddForeignKey("dbo.Menus", "GroupID", "dbo.MenuGroups", "ID", cascadeDelete: true);
        }
    }
}
