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
    public class AuthorService : IAuthorService
    {
        private readonly IRepository<Author> _authorRepository;
        private readonly IMapper _mapper;
        public AuthorService(IRepository<Author> repository, IMapper mapper)
        {
            _authorRepository = repository;
            _mapper = mapper;
        }
        // METHODS FOR SERVICES
        public async Task Create(AuthorDTO author)
        {
            if (author == null)
                throw new HttpException($"Error with create new author!", HttpStatusCode.NotFound);
            await _authorRepository.Insert(_mapper.Map<Author>(author));
            await _authorRepository.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            if (id < 0) throw new HttpException($"Invalid id!", HttpStatusCode.NotFound);
            var author = _authorRepository.GetById(id);
            if (author != null)
                await _authorRepository.Delete(author);
            await _authorRepository.SaveChangesAsync();
        }
        public async Task Edit(AuthorDTO author)
        {
            if (author == null)
                throw new HttpException($"Error with edit author!", HttpStatusCode.NotFound);
            _authorRepository.Update(_mapper.Map<Author>(author));
            await _authorRepository.SaveChangesAsync();
        }
        public async Task<IEnumerable<AuthorDTO>> Get()
        {
            return _mapper.Map<IEnumerable<AuthorDTO>>(await _authorRepository.Get());
        }
        public async Task<AuthorDTO> GetAuthorById(int id)
        {
            if (id < 0) throw new HttpException($"Invalid id!", HttpStatusCode.BadGateway);
            var author = _authorRepository.GetById(id);
            if (author == null) throw new HttpException($"Author Not Found!", HttpStatusCode.NotFound);
            return _mapper.Map<AuthorDTO>(await author);
        }
        public async Task<AuthorPlaylistsDTO> GetAuthorPlaylist(int id)
        {
            if (id < 0) throw new HttpException($"Invalid id {id}!",HttpStatusCode.BadGateway);
            var playlists = _authorRepository.GetById(id);
            if(playlists == null) throw new HttpException($"Playlist not found",HttpStatusCode.NotFound);
            return _mapper.Map<AuthorPlaylistsDTO>(await _authorRepository.Get());
        }
    }
}
