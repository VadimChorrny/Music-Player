using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    public class AuthorPlaylistsDTO
    {
        public virtual ICollection<Playlist> Playlists { get; set; }
        public virtual ICollection<Track> Tracks { get; set; }
    }
}
