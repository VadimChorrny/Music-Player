using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    public class GanreDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Track> Tracks { get; set; }
    }
}
