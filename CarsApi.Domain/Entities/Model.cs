using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsApi.Domain.Entities
{
    public class Model
    {
        public int Id { get; set; }
        public required String Name { get; set; }
        public required float Fipe_value { get; set; }
        public required int Brand_id { get; set; } 
        public ICollection<Car>? Cars { get; set; }
         public Brand? Brand { get; set; }
        
    }
} 