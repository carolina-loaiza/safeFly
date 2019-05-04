namespace Entities_POJO
{
    public class UserXRoleXView : BaseEntity
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int RoleId { get; set; }
        public int ViewId { get; set; }
    }
}