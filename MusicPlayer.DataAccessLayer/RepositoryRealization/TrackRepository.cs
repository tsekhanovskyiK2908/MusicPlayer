using MusicPlayer.DataAccessLayer.Repository;
using MusicPlayer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.DataAccessLayer.RepositoryRealization
{
    public class TrackRepository : Repository<Track>, ITrackRepository
    {
        public TrackRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        public ApplicationDbContext ApplicationDbContext
        {
            get
            {
                return DbContext as ApplicationDbContext;
            }
        }
    }
}
