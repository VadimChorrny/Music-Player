using Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.CustomServices
{
    public interface IGanreService
    {
        Task<IEnumerable<GanreDTO>> Get();
        Task<GanreDTO> GetGanreById(int id);
        Task Create(GanreDTO track);
        Task Edit(GanreDTO track);
        Task Delete(int id);
    }
}
