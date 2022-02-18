namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdminId = c.Int(nullable: false, identity: true),
                        AdminUserName = c.String(),
                        AdminMail = c.Binary(),
                        PasswordHash = c.Binary(),
                        PasswordSalt = c.Binary(),
                        AdminRole = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => t.AdminId);
            
            CreateTable(
                "dbo.AnimalLovers",
                c => new
                    {
                        AnimalLoverId = c.Int(nullable: false, identity: true),
                        AnimalLoverName = c.String(maxLength: 50),
                        AnimalLoverSurName = c.String(maxLength: 50),
                        AnimalLoverImage = c.String(maxLength: 150),
                        AnimalLoverMail = c.String(maxLength: 50),
                        AnimalLoverPassword = c.String(maxLength: 20),
                        AnimalLoverAbout = c.String(),
                        AnimalLoverStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AnimalLoverId);
            
            CreateTable(
                "dbo.Contents",
                c => new
                    {
                        ContentId = c.Int(nullable: false, identity: true),
                        ContentValue = c.String(maxLength: 1000),
                        ContentDate = c.DateTime(nullable: false),
                        ContentStatus = c.Boolean(nullable: false),
                        AnimalLoverId = c.Int(nullable: false),
                        HeadingId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ContentId)
                .ForeignKey("dbo.AnimalLovers", t => t.AnimalLoverId, cascadeDelete: true)
                .ForeignKey("dbo.Headings", t => t.HeadingId, cascadeDelete: true)
                .Index(t => t.AnimalLoverId)
                .Index(t => t.HeadingId);
            
            CreateTable(
                "dbo.Headings",
                c => new
                    {
                        HeadingId = c.Int(nullable: false, identity: true),
                        HeadingName = c.String(maxLength: 150),
                        HeadingDate = c.DateTime(nullable: false),
                        HeadingStatus = c.Boolean(nullable: false),
                        AnimalId = c.Int(nullable: false),
                        AnimalLoverId = c.Int(),
                    })
                .PrimaryKey(t => t.HeadingId)
                .ForeignKey("dbo.Animals", t => t.AnimalId, cascadeDelete: true)
                .ForeignKey("dbo.AnimalLovers", t => t.AnimalLoverId)
                .Index(t => t.AnimalId)
                .Index(t => t.AnimalLoverId);
            
            CreateTable(
                "dbo.Animals",
                c => new
                    {
                        AnimalId = c.Int(nullable: false, identity: true),
                        AnimalName = c.String(maxLength: 50),
                        AnimalDescription = c.String(),
                    })
                .PrimaryKey(t => t.AnimalId);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ContactId = c.Int(nullable: false, identity: true),
                        UserName = c.String(maxLength: 50),
                        UserMail = c.String(maxLength: 50),
                        Subject = c.String(maxLength: 50),
                        Message = c.String(),
                        ContentDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ContactId);
            
            CreateTable(
                "dbo.Gates",
                c => new
                    {
                        GateId = c.Int(nullable: false, identity: true),
                        GateNo = c.String(),
                        GateCoordinate = c.String(),
                        NeighborhoodId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GateId)
                .ForeignKey("dbo.Neighborhoods", t => t.NeighborhoodId, cascadeDelete: true)
                .Index(t => t.NeighborhoodId);
            
            CreateTable(
                "dbo.Neighborhoods",
                c => new
                    {
                        NeighborhoodId = c.Int(nullable: false, identity: true),
                        NeighborhoodName = c.String(),
                        NeighborhoodCoordinate = c.String(),
                    })
                .PrimaryKey(t => t.NeighborhoodId);
            
            CreateTable(
                "dbo.ImageFiles",
                c => new
                    {
                        ImageId = c.Int(nullable: false, identity: true),
                        ImageName = c.String(maxLength: 100),
                        ImagePath = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.ImageId);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        MessageId = c.Int(nullable: false, identity: true),
                        SenderMail = c.String(maxLength: 50),
                        ReceiverMail = c.String(maxLength: 50),
                        Subject = c.String(),
                        MessageContent = c.String(),
                        MessageDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MessageId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Gates", "NeighborhoodId", "dbo.Neighborhoods");
            DropForeignKey("dbo.Contents", "HeadingId", "dbo.Headings");
            DropForeignKey("dbo.Headings", "AnimalLoverId", "dbo.AnimalLovers");
            DropForeignKey("dbo.Headings", "AnimalId", "dbo.Animals");
            DropForeignKey("dbo.Contents", "AnimalLoverId", "dbo.AnimalLovers");
            DropIndex("dbo.Gates", new[] { "NeighborhoodId" });
            DropIndex("dbo.Headings", new[] { "AnimalLoverId" });
            DropIndex("dbo.Headings", new[] { "AnimalId" });
            DropIndex("dbo.Contents", new[] { "HeadingId" });
            DropIndex("dbo.Contents", new[] { "AnimalLoverId" });
            DropTable("dbo.Messages");
            DropTable("dbo.ImageFiles");
            DropTable("dbo.Neighborhoods");
            DropTable("dbo.Gates");
            DropTable("dbo.Contacts");
            DropTable("dbo.Animals");
            DropTable("dbo.Headings");
            DropTable("dbo.Contents");
            DropTable("dbo.AnimalLovers");
            DropTable("dbo.Admins");
        }
    }
}
