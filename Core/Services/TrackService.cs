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
    public class TrackService : ITrackService
    {
        private readonly IRepository<Track> _trackRepository;
        private readonly IMapper _mapper;
        public TrackService(IRepository<Track> repository, IMapper mapper)
        {
            _trackRepository = repository;
            _mapper = mapper;
        }
        // METHODS FOR SERVICES
        public async Task Create(TrackDTO track)
        {
            if (track == null)
                throw new HttpException($"Error with create new track!", HttpStatusCode.NotFound);
            await _trackRepository.Insert(_mapper.Map<Track>(track));
            await _trackRepository.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            if (id < 0) throw new HttpException($"Invalid id!", HttpStatusCode.NotFound);
            var track = _trackRepository.GetById(id);
            if(track != null)
                await _trackRepository.Delete(track);
            await _trackRepository.SaveChangesAsync();
        }
        public async Task Edit(TrackDTO track)
        {
            if(track == null)
                throw new HttpException($"Error with edit track!",HttpStatusCode.NotFound);
            _trackRepository.Update(_mapper.Map<Track>(track));
            await _trackRepository.SaveChangesAsync();
        }
        public async Task<IEnumerable<TrackDTO>> Get()
        {
            return _mapper.Map<IEnumerable<TrackDTO>>(await _trackRepository.Get());
        }
        public async Task<TrackDTO> GetTrackById(int id)
        {
            if (id < 0) throw new HttpException($"Invalid id!", HttpStatusCode.BadGateway);
            var track = _trackRepository.GetById(id);
            if (track == null) throw new HttpException($"Track Not Found!", HttpStatusCode.NotFound);
            return _mapper.Map<TrackDTO>(await track);
        }
    }
}

// GENERAL STATUS CODE
// NotFound ------------- 404
// BadGateway ----------- 502
// BadRequest ----------- 400
// Created -------------- 201
// GatewayTimeout ------- 504
// InternalServerError -- 500
// OK ------------------- 200