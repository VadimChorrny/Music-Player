using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Author
    {
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Nickname { get; set; }
        public IEnumerable<Playlist> Playlists { get; set; }
        public IEnumerable<Track> Tracks { get; set; }
    }

    // Клас для автора
}
