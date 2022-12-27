using System;
using System.Collections.Generic;

namespace Bridge351.TotalMedia.POC.Models
{
    public partial class Country
    {
        public Country()
        {
            VatRates = new HashSet<VatRate>();
        }

        public int CountryId { get; set; }
        public string? CountryName { get; set; }

        public virtual ICollection<VatRate> VatRates { get; set; }
    }
}
