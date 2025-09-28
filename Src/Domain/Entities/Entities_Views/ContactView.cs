namespace Domain.Entities.Entities_Views
{
    public sealed class ContactView
    {
        public  int Id { get; set; }
        public  string FirstName { get; set; } = null!;
        public  string LastName { get; set; } = null!;
        public  string PhoneNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
      
    }
}
