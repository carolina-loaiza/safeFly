namespace Entities_POJO
{
    public class Tax:BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; } 
        public string Status { get; set; }
    }
}
