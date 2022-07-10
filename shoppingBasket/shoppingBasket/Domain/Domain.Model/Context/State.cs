namespace Domain.Model.Context
{
    public class State
    {
        public State()
        {
            this.IsValid = true;
        }

        public bool IsValid { get; set; }

        public string InvalidMessage { get; set; }
    }
}
