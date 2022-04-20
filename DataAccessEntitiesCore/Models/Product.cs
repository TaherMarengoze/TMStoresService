using System;
using System.Collections.Generic;

#nullable disable

namespace EntitiesCore.Models
{
    public partial class Product
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
    }
}
