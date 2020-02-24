using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Entities
{
    public class Album
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public Guid ArtistId { get; set; }

        public virtual Artist Artist { get; set; }

        public DateTime ReleaseDate { get; set; }

        [Required]
        [StringLength(100)]
        public string RecordLabel { get; set; }
    }
}
