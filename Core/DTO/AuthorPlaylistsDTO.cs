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
        public int Id { get; set; }
        public IEnumerable<PlaylistDTO> Playlists { get; set; }
    }
}
