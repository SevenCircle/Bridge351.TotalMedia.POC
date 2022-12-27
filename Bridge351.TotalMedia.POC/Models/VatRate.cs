using System;
using System.Collections.Generic;

namespace Bridge351.TotalMedia.POC.Models
{
    public partial class VatRate
    {
        public int VatNumberId { get; set; }
        public decimal VatNumber { get; set; }
        public int CountryId { get; set; }

        public virtual Country Country { get; set; } = null!;
    }
}
