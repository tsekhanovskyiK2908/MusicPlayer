namespace MusicPlayer.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateAlbumAndTrack : DbMigration
    {
        public override void Up()
        {
            SqlFile(@"..\..\PopulationScript\PopulateAlbumAndTrack.sql");
        }
        
        public override void Down()
        {
        }
    }
}
