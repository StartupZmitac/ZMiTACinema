namespace CinemaAPI.Authorization
{
    public class Authorization
    {
        public Authorization() { }

        public enum State 
        {
            admin,
            guest,
            cashier,
            fail
        }

        public State state;

        public void login() { }
    }
}
