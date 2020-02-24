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
    public class Album
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
        public Guid ArtistId { get; set; }

        [DataMember]
        public virtual Artist Artist { get; set; }

        [DataMember]
        public DateTime ReleaseDate { get; set; }

        [DataMember]
        [Required]
        [StringLength(100)]
        public string RecordLabel { get; set; }
    }
}
