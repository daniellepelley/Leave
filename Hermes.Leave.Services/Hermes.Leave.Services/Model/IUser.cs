namespace Hermes.Leave.Services.Model
{
    public interface IUser
    {
        int Id { set; get; }
        bool IsApprover { get; }
    }
}