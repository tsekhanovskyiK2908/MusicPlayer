using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Entities
{
    public class Track
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public TimeSpan Duration { get; set; }

        [Required]
        [StringLength(255)]
        public string PathToFile { get; set; }

        [Required]
        public Guid AlbumId { get; set; }

        public virtual Album Album { get; set; }

        [Required]
        public Guid GenreId { get; set; }

        public virtual Genre Genre { get; set; }

        [Required]
        public Guid FormatId { get; set; }

        public virtual Format Format { get; set; }

    }
}
