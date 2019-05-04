namespace Entities_POJO
{
    public class Role : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
    }
}