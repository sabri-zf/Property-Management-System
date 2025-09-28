namespace Domain.Entities
{
    public sealed class Manager
    {
        public int ManagerId { get; set; }

        public int UserId { get; set; }

        // Relationship : User Has many Manager and Manager belong to one User
        public User User { get; set; }
    }
}
