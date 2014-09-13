namespace Hermes.Leave.Services.Model
{
    public class LeaveCard
    {
        public int Allowance { get; set; }
        public int Taken { get; set; }

        public int Remaining
        {
            get { return Allowance - Taken; }
        }
    }
}
