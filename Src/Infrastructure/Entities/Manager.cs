namespace Infrastructure.Entities
{
    internal class Manager
    {
        public virtual int ManagerId { get; set; }

        public virtual int UserId { get; set; }

        // Relationship : User Has many Manager and Manager belong to one User
        public virtual User User { get; set; }
    }
}
