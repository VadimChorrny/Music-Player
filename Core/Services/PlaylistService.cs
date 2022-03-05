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
    public class PlaylistService : IPlaylistService
    {
        //private readonly IRepository<Playlist> _playlistRepository;
        //private readonly IRepository<TrackService> _trackService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public PlaylistService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task Create(PlaylistDTO playlist)
        {
            if (playlist == null)
                throw new HttpException($"Error with create new playlist!", HttpStatusCode.NotFound);
            await _unitOfWork.PlaylistRepository.Insert(_mapper.Map<Playlist>(playlist));
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            if (id < 0) throw new HttpException($"Invalid id!", HttpStatusCode.NotFound);
            var playlist = _unitOfWork.PlaylistRepository.GetById(id);
            if (playlist != null)
                await _unitOfWork.PlaylistRepository.Delete(playlist);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task Edit(PlaylistDTO playlist)
        {
            if (playlist == null)
                throw new HttpException($"Error with edit playlist!", HttpStatusCode.NotFound);
            _unitOfWork.PlaylistRepository.Update(_mapper.Map<Playlist>(playlist));
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<IEnumerable<PlaylistDTO>> Get()
        {
            return _mapper.Map<IEnumerable<PlaylistDTO>>(await _unitOfWork.PlaylistRepository.Get());
        }
        public async Task<PlaylistDTO> GetPlaylistById(int id)
        {
            if (id < 0) throw new HttpException($"Invalid id!", HttpStatusCode.BadGateway);
            var playlist = _unitOfWork.PlaylistRepository.GetById(id);
            if (playlist == null) throw new HttpException($"Playlist Not Found!", HttpStatusCode.NotFound);
            return _mapper.Map<PlaylistDTO>(await playlist);
        }
        public async Task<IEnumerable<TrackDTO>> GetAllTrackFromPlaylist(int id)
        {
            if (id < 0) throw new HttpException($"Invalid id {id}!", HttpStatusCode.BadGateway);
            var tracks = _mapper.Map<IEnumerable<TrackDTO>>(await _unitOfWork.TrackRepository.Get(e=>e.PlaylistId == id));
            return tracks;
        }
    }
}
