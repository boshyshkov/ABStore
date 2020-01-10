namespace ABStore.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Single(nullable: false),
                        Genre = c.String(),
                        PublisherName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        Password = c.String(),
                        Money = c.Single(nullable: false),
                        isPublisher = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LibraryItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GameId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                //manually inserted foreign key as entity if another aggregate
                .ForeignKey("dbo.Games", t => t.GameId)
                .Index(t => t.GameId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LibraryItems", "UserId", "dbo.Users");
            DropIndex("dbo.LibraryItems", new[] { "UserId" });
            DropTable("dbo.LibraryItems");
            DropTable("dbo.Users");
            DropTable("dbo.Games");
        }
    }
}
