using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Sstop.WebApi.Domains
{
    public class ArtistaDomain
    {
        public int IdArtista { get; set; }
        public int Nome { get; set; }
        public EstiloDomain Estilo  { get; set; }
    }
}
