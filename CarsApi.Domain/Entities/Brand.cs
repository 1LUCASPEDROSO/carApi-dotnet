using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsApi.Domain.Entities
{
    public class Brand
    {
        public int Id { get; set; }
        public required String Name { get; set; }
        public ICollection<Model>? Models { get; set; }
    }
}