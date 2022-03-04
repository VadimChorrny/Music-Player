using AutoMapper;
using Core.DTO;
using Core.Entities;
using Core.Exceptions;
using Core.Interfaces;
using Core.Interfaces.CustomServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class GanreService : IGanreService
    {
        private readonly IRepository<Ganre> _ganreRepository;
        private readonly IMapper _mapper;
        public GanreService(IRepository<Ganre> repository,IMapper mapper)
        {
            _ganreRepository = repository;
            _mapper = mapper;
        }
        public async Task Create(GanreDTO ganre)
        {
            if (ganre == null)
                throw new HttpException($"Error with create new ganre!", HttpStatusCode.NotFound);
            await _ganreRepository.Insert(_mapper.Map<Ganre>(ganre));
            await _ganreRepository.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            if (id < 0) throw new HttpException($"Invalid id!", HttpStatusCode.NotFound);
            var ganre = _ganreRepository.GetById(id);
            if (ganre != null)
                await _ganreRepository.Delete(ganre);
            await _ganreRepository.SaveChangesAsync();
        }
        public async Task Edit(GanreDTO ganre)
        {
            if (ganre == null)
                throw new HttpException($"Error with edit ganre!", HttpStatusCode.NotFound);
            _ganreRepository.Update(_mapper.Map<Ganre>(ganre));
            await _ganreRepository.SaveChangesAsync();
        }
        public async Task<IEnumerable<GanreDTO>> Get()
        {
            return _mapper.Map<IEnumerable<GanreDTO>>(await _ganreRepository.Get());
        }
        public async Task<GanreDTO> GetGanreById(int id)
        {
            if (id < 0) throw new HttpException($"Invalid id!", HttpStatusCode.BadGateway);
            var author = _ganreRepository.GetById(id);
            if (author == null) throw new HttpException($"Ganre Not Found!", HttpStatusCode.NotFound);
            return _mapper.Map<GanreDTO>(await author);
        }
    }
}
