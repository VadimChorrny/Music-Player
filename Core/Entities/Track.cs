using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Track
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public byte[] AudioFile { get; set; }
        public int? AuthorId { get; set; }
        public Author Author { get; set; }
        public int? GanreId { get; set; }
        public Ganre Ganre { get; set; }
        public int? PlaylistId { get; set; }
        public Playlist Playlist { get; set; }
    }

    // Клас для збереженя інфи про трек
}
