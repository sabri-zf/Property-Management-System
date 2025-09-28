namespace Domain.Entities
{
    public sealed class Admin
    {
        public int AdminId { get; set; }
        public int UserId { get; set; }

        // Relationship : Admin Represent one User and User Represent many of Admins
        public User User { get; set; }
    }
}
