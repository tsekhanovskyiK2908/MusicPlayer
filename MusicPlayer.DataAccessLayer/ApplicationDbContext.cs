using MusicPlayer.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.DataAccessLayer
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Artist> Artists { get; set; }

        public DbSet<Artist> Albums { get; set; }
        
        public DbSet<Track> Tracks { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Format> Formats { get; set; }

        public DbSet<TrackPlaylist> TrackPlaylists { get; set; }

        public DbSet<Playlist> Playlists { get; set; }

        public DbSet<User> Users { get; set; }

        public ApplicationDbContext():base(ConfigurationManager.ConnectionStrings["MusicPlayerDB"].ConnectionString)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
