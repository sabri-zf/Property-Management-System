namespace Infrastructure.Entities
{
    internal class Admin
    {
        public virtual int AdminId { get; set; }
        public virtual int UserId { get; set; }

        // Relationship : Admin Represent one User and User Represent many of Admins
        public virtual User User { get; set; }
    }
}
