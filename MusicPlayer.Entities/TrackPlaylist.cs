using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Entities
{
    public class TrackPlaylist
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public Guid TrackId { get; set; }

        public virtual Track Track { get; set; }

        [Required]
        public Guid PlaylistId { get; set; }

        public virtual Playlist Playlist { get; set; }
    }
}
