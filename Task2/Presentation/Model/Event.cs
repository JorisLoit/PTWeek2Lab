namespace Task2.Presentation.Model
{
    public abstract class Event
    {
        public State state { get; set; }
        public User user { get; set; }
        public string description { get; set; }
    }

    public class Borrowing : Event
    {
       
        public Borrowing(State state, User User)
        {
            this.state = state;
            this.user = User;
            this.description = "Borrowed";
        }

    }

    public class Returning : Event
    {
  
        public Returning(State state, User User)
        {
            this.state = state;
            this.user = User;
            this.description = "Returned";
        }

    }
}