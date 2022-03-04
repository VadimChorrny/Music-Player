using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    public class TrackDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public byte[] AudioFile { get; set; }
        public int? AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
