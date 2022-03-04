using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        // INITIAL DATABASE
        private ApplicationDbContext _context;
        // INITIAL REPOSITORIES
        private IRepository<Track> _trackRepository;
        private IRepository<Author> _authorRepository;
        private IRepository<Ganre> _ganreRepository;
        private IRepository<Playlist> _playlistRepository;
        public UnitOfWork(ApplicationDbContext context) { _context = context; } // CTOR
        // GET FOR REPOSITORY
        public IRepository<Track> TrackRepository
        {
            get 
            {
                if (_trackRepository == null)
                    _trackRepository = new Repository<Track>(_context);
                return _trackRepository;
            }
        }
        public IRepository<Author> AuthorRepository
        {
            get
            {
                if (_authorRepository == null)
                    _authorRepository = new Repository<Author>(_context);
                return _authorRepository;
            }
        }
        public IRepository<Ganre> GanreRepository
        {
            get
            {
                if (_ganreRepository == null)
                    _ganreRepository = new Repository<Ganre>(_context);
                return _ganreRepository;
            }
        }
        public IRepository<Playlist> PlaylistRepository
        {
            get
            {
                if (_playlistRepository == null)
                    _playlistRepository = new Repository<Playlist>(_context);
                return _playlistRepository;
            }
        }
        // REALISE Save();
        public Task<int> SaveChangesAsync() => _context.SaveChangesAsync();
        // DISPOSING
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if(disposing)
                    _context.Dispose();
                this.disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

// WHY NEED UNIT OF WORK ???

// Паттерн Unit of Work позволяет
// упростить работу с различными репозиториями и дает уверенность,
// что все репозитории будут использовать один и тот же контекст данных.

