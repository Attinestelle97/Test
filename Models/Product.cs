namespace Test_2.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float PriceHt { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public DateTime? DateUpdate { get; set; }
    }
}
