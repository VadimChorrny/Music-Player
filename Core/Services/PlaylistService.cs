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
        private readonly IRepository<Playlist> _playlistRepository;
        private readonly IMapper _mapper;
        public PlaylistService(IRepository<Playlist> repository, IMapper mapper)
        {
            _playlistRepository = repository;
            _mapper = mapper;
        }
        public async Task Create(PlaylistDTO playlist)
        {
            if (playlist == null)
                throw new HttpException($"Error with create new playlist!", HttpStatusCode.NotFound);
            await _playlistRepository.Insert(_mapper.Map<Playlist>(playlist));
            await _playlistRepository.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            if (id < 0) throw new HttpException($"Invalid id!", HttpStatusCode.NotFound);
            var playlist = _playlistRepository.GetById(id);
            if (playlist != null)
                await _playlistRepository.Delete(playlist);
            await _playlistRepository.SaveChangesAsync();
        }
        public async Task Edit(PlaylistDTO playlist)
        {
            if (playlist == null)
                throw new HttpException($"Error with edit playlist!", HttpStatusCode.NotFound);
            _playlistRepository.Update(_mapper.Map<Playlist>(playlist));
            await _playlistRepository.SaveChangesAsync();
        }
        public async Task<IEnumerable<PlaylistDTO>> Get()
        {
            return _mapper.Map<IEnumerable<PlaylistDTO>>(await _playlistRepository.Get());
        }
        public async Task<PlaylistDTO> GetPlaylistById(int id)
        {
            if (id < 0) throw new HttpException($"Invalid id!", HttpStatusCode.BadGateway);
            var playlist = _playlistRepository.GetById(id);
            if (playlist == null) throw new HttpException($"Playlist Not Found!", HttpStatusCode.NotFound);
            return _mapper.Map<PlaylistDTO>(await playlist);
        }
    }
}
