using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    public class AuthorDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Nickname { get; set; }
        public virtual ICollection<Playlist> Playlists { get; set; }
        public virtual ICollection<Track> Tracks { get; set; }
    }
}
