using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadassFilms.Core.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Resume { get; set; }
        public string? CreatorIp { get; set; }
    }
}
