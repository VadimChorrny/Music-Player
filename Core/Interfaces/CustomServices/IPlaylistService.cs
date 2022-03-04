using Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.CustomServices
{
    public interface IPlaylistService
    {
        Task<IEnumerable<PlaylistDTO>> Get();
        Task<PlaylistDTO> GetPlaylistById(int id);
        Task Create(PlaylistDTO track);
        Task Edit(PlaylistDTO track);
        Task Delete(int id);
    }
}
