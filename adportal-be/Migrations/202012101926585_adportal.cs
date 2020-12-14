namespace adportal_be.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adportal : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Advertisements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 80),
                        Description = c.String(nullable: false, maxLength: 500),
                        Price = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                        AdType_Id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AdTypes", t => t.AdType_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.AdType_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FileName = c.String(nullable: false),
                        ImageUrl = c.String(),
                        Advertisement_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Advertisements", t => t.Advertisement_Id)
                .Index(t => t.Advertisement_Id);
            
            CreateTable(
                "dbo.AdTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 25),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false),
                        Login = c.String(nullable: false, maxLength: 25),
                        Password = c.String(nullable: false, maxLength: 25),
                        Country = c.String(),
                        City = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CategoryAdvertisements",
                c => new
                    {
                        Category_Id = c.Int(nullable: false),
                        Advertisement_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Category_Id, t.Advertisement_Id })
                .ForeignKey("dbo.Categories", t => t.Category_Id, cascadeDelete: true)
                .ForeignKey("dbo.Advertisements", t => t.Advertisement_Id, cascadeDelete: true)
                .Index(t => t.Category_Id)
                .Index(t => t.Advertisement_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Advertisements", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Advertisements", "AdType_Id", "dbo.AdTypes");
            DropForeignKey("dbo.Images", "Advertisement_Id", "dbo.Advertisements");
            DropForeignKey("dbo.CategoryAdvertisements", "Advertisement_Id", "dbo.Advertisements");
            DropForeignKey("dbo.CategoryAdvertisements", "Category_Id", "dbo.Categories");
            DropIndex("dbo.CategoryAdvertisements", new[] { "Advertisement_Id" });
            DropIndex("dbo.CategoryAdvertisements", new[] { "Category_Id" });
            DropIndex("dbo.Images", new[] { "Advertisement_Id" });
            DropIndex("dbo.Advertisements", new[] { "User_Id" });
            DropIndex("dbo.Advertisements", new[] { "AdType_Id" });
            DropTable("dbo.CategoryAdvertisements");
            DropTable("dbo.Users");
            DropTable("dbo.AdTypes");
            DropTable("dbo.Images");
            DropTable("dbo.Categories");
            DropTable("dbo.Advertisements");
        }
    }
}
