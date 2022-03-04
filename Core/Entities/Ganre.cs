using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Ganre
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public List<Track> Tracks { get; set; }
    }
}

// Клас для жанрів