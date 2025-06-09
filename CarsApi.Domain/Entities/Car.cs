using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace CarsApi.Domain.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public required  long Timestamp_Cadaster { get; set; }
        public required int  Model_id { get; set; }
        public required int Year { get; set; }
        public required string Gas_type { get; set; }
        public required int Num_doors { get; set; }
        public string? Color { get; set; }

         public Model? Model { get; set; }
        
    }
}