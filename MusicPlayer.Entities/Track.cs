using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Entities
{
    [DataContract]
    public class Track
    {   
        [DataMember]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [DataMember]
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [DataMember]
        [Required]
        public TimeSpan Duration { get; set; }

        [DataMember]
        [Required]
        [StringLength(255)]
        public string PathToFile { get; set; }

        [DataMember]
        [Required]
        public Guid AlbumId { get; set; }

        [DataMember]
        public virtual Album Album { get; set; }

        [DataMember]
        [Required]
        public Guid GenreId { get; set; }

        [DataMember]
        public virtual Genre Genre { get; set; }

        [DataMember]
        [Required]
        public Guid FormatId { get; set; }

        [DataMember]
        public virtual Format Format { get; set; }

        public override string ToString()
        {
            return Name;
        }

    }
}
