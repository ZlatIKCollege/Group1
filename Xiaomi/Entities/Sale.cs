using System;
using System.Collections.Generic;

#nullable disable

namespace Xiaomi.Entities
{
    public partial class Sale
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public string Client { get; set; }
        public string Product { get; set; }
        public string KolVo { get; set; }
        public string Summa { get; set; }
    }
}
