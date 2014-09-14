namespace Hermes.Leave.Services.Model
{
    public class User : IUser
    {
        public int Id { set; get; }
        public bool IsApprover { get; set; }
    }
}
