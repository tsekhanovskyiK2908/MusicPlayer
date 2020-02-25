namespace MusicPlayer.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenreFormatAndArtist : DbMigration
    {
        public override void Up()
        {
            SqlFile(@"..\..\PopulationScript\PopulateGenreAndFormat.sql");
        }
        
        public override void Down()
        {
        }
    }
}
