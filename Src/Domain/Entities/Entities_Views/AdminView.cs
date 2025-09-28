namespace Domain.Entities.Entities_Views
{
    public sealed class AdminView
    {
        public  int Id { get; set; }
        public  string FirstName { get; set; } = null!;
        public  string LastName { get; set; } = null!;
        public  DateOnly BirthDay { get; set; }
        public  string UserName { get; set; } = null!;
        public  string Password { get; set; } = null!;
        public  string Email { get; set; } = null!;
        public  string Phone { get; set; } = null!;
        public  DateTime createAt { get; set; }
        public  DateTime? updateAt { get; set; }
        public  bool IsActive { get; set; }
    }
}
