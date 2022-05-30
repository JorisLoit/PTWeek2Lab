namespace Task2.Presentation.Model
{ 
    public class State
    {
        public Catalog Book { get; }
        public bool Available = true;

        public State(Catalog book)
        {
            Book = book;
        }

        public void ChangeState()
        {
            if (Available)
            {
                Available = false;
            }
            else
            {
                Available = true;
            }
        }
    }
}
