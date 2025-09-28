namespace Domain.Entities.Entities_Views
{
    public sealed class TenantView
    { 
        public  int Id { get; set; }
        public  string FirstName { get; set; } = null!;
        public  string LastName { get; set; } = null!;
        public  DateOnly BirthDay { get; set;}
        public  DateTime createAt { get; set;}
        public  DateTime? updateAt { get; set;}

    }
}
