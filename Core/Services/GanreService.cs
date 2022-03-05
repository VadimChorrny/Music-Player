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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GanreService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task Create(GanreDTO ganre)
        {
            if (ganre == null)
                throw new HttpException($"Error with create new ganre!", HttpStatusCode.NotFound);
            await _unitOfWork.GanreRepository.Insert(_mapper.Map<Ganre>(ganre));
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            if (id < 0) throw new HttpException($"Invalid id!", HttpStatusCode.NotFound);
            var ganre = _unitOfWork.GanreRepository.GetById(id);
            if (ganre != null)
                await _unitOfWork.GanreRepository.Delete(ganre);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task Edit(GanreDTO ganre)
        {
            if (ganre == null)
                throw new HttpException($"Error with edit ganre!", HttpStatusCode.NotFound);
            _unitOfWork.GanreRepository.Update(_mapper.Map<Ganre>(ganre));
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<IEnumerable<GanreDTO>> Get()
        {
            return _mapper.Map<IEnumerable<GanreDTO>>(await _unitOfWork.GanreRepository.Get());
        }
        public async Task<GanreDTO> GetGanreById(int id)
        {
            if (id < 0) throw new HttpException($"Invalid id!", HttpStatusCode.BadGateway);
            var author = _unitOfWork.GanreRepository.GetById(id);
            if (author == null) throw new HttpException($"Ganre Not Found!", HttpStatusCode.NotFound);
            return _mapper.Map<GanreDTO>(await author);
        }
    }
}
