using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Track> TrackRepository { get; }
        IRepository<Author> AuthorRepository { get; }
        IRepository<Playlist> PlaylistRepository { get; }
        IRepository<Ganre> GanreRepository { get; }
        Task<int> SaveChangesAsync();
    }
}
