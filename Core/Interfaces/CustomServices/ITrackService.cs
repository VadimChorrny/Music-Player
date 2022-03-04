using Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.CustomServices
{
    public interface ITrackService
    {
        Task<IEnumerable<TrackDTO>> Get();
        Task<TrackDTO> GetTrackById(int id);
        Task Create(TrackDTO track);
        Task Edit(TrackDTO track);
        Task Delete(int id);
    }
}
