using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Playlist
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int? AuthorId { get; set; }
        public Author Author { get; set; }
        public ICollection<Track> Tracks { get; set; }
    }
}

// Плейлист, потрібно реалізувати CRUD