namespace PSIRModel
{
    public class Shop
    {
        public int ShopId { get; set; }
        public int BuildingId { get; set; }
        public string Bprn { get; set; }
        public string ShopNo { get; set; }
        public string ShopType { get; set; }
        public string ShopCategory { get; set; }
        public string ContactNumber { get; set; }
        public string OwnerName { get; set; }
        public virtual Building Building { get; set; }
    }
}
