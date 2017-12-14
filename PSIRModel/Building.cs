using System.Collections.Generic;

namespace PSIRModel
{
    public class Building
    {
        public int BuildingId { get; set; }
        public string Address { get; set; }
        public string PremisesType { get; set; }
        public string LocalGovArea { get; set; }
        public string Ward { get; set; }
        public ICollection<Shop> Shops { get; set; }
    }
}
