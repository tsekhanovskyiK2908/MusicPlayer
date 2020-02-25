namespace MusicPlayer.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialSchema : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Album",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true, defaultValueSql: "newsequentialid()"),
                        Name = c.String(nullable: false, maxLength: 50),
                        ArtistId = c.Guid(nullable: false),
                        ReleaseDate = c.DateTime(nullable: false),
                        RecordLabel = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Artist", t => t.ArtistId, cascadeDelete: true)
                .Index(t => t.ArtistId);
            
            CreateTable(
                "dbo.Artist",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true, defaultValueSql: "newsequentialid()"),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Format",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true, defaultValueSql: "newsequentialid()"),
                        Name = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Genre",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true, defaultValueSql: "newsequentialid()"),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Playlist",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true, defaultValueSql: "newsequentialid()"),
                        Name = c.String(nullable: false, maxLength: 50),
                        UserId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true, defaultValueSql: "newsequentialid()"),
                        Email = c.String(nullable: false, maxLength: 50),
                        PasswordHash = c.String(nullable: false, maxLength: 256),
                        Username = c.String(nullable: false, maxLength: 50),
                        IsAdmin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TrackPlaylist",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true, defaultValueSql: "newsequentialid()"),
                        TrackId = c.Guid(nullable: false),
                        PlaylistId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Playlist", t => t.PlaylistId, cascadeDelete: true)
                .ForeignKey("dbo.Track", t => t.TrackId, cascadeDelete: true)
                .Index(t => t.TrackId)
                .Index(t => t.PlaylistId);
            
            CreateTable(
                "dbo.Track",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true, defaultValueSql: "newsequentialid()"),
                        Name = c.String(nullable: false, maxLength: 50),
                        Duration = c.Time(nullable: false, precision: 7),
                        PathToFile = c.String(nullable: false, maxLength: 255),
                        AlbumId = c.Guid(nullable: false),
                        GenreId = c.Guid(nullable: false),
                        FormatId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Album", t => t.AlbumId, cascadeDelete: true)
                .ForeignKey("dbo.Format", t => t.FormatId, cascadeDelete: true)
                .ForeignKey("dbo.Genre", t => t.GenreId, cascadeDelete: true)
                .Index(t => t.AlbumId)
                .Index(t => t.GenreId)
                .Index(t => t.FormatId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TrackPlaylist", "TrackId", "dbo.Track");
            DropForeignKey("dbo.Track", "GenreId", "dbo.Genre");
            DropForeignKey("dbo.Track", "FormatId", "dbo.Format");
            DropForeignKey("dbo.Track", "AlbumId", "dbo.Album");
            DropForeignKey("dbo.TrackPlaylist", "PlaylistId", "dbo.Playlist");
            DropForeignKey("dbo.Playlist", "UserId", "dbo.User");
            DropForeignKey("dbo.Album", "ArtistId", "dbo.Artist");
            DropIndex("dbo.Track", new[] { "FormatId" });
            DropIndex("dbo.Track", new[] { "GenreId" });
            DropIndex("dbo.Track", new[] { "AlbumId" });
            DropIndex("dbo.TrackPlaylist", new[] { "PlaylistId" });
            DropIndex("dbo.TrackPlaylist", new[] { "TrackId" });
            DropIndex("dbo.Playlist", new[] { "UserId" });
            DropIndex("dbo.Album", new[] { "ArtistId" });
            DropTable("dbo.Track");
            DropTable("dbo.TrackPlaylist");
            DropTable("dbo.User");
            DropTable("dbo.Playlist");
            DropTable("dbo.Genre");
            DropTable("dbo.Format");
            DropTable("dbo.Artist");
            DropTable("dbo.Album");
        }
    }
}
