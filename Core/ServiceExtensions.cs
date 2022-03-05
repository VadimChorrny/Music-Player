using AutoMapper;
using Core.DTO;
using Core.Entities;
using Core.Interfaces.CustomServices;
using Core.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public static class ServiceExtensions
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<ITrackService, TrackService>();
            services.AddScoped<IGanreService, GanreService>();
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IPlaylistService, PlaylistService>();
        }
        public static void AddAutoMapper(this IServiceCollection services)
        {
            var configures = new MapperConfiguration(mc =>
            {
                mc.CreateMap<Track, TrackDTO>().ReverseMap();
                mc.CreateMap<Playlist, PlaylistDTO>().ReverseMap();
                mc.CreateMap<Ganre, GanreDTO>().ReverseMap();
                mc.CreateMap<Author, AuthorDTO>().ReverseMap();
            });

            IMapper mapper = configures.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
