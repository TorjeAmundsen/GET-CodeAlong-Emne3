namespace CodeAlong
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Horse> horses = new List<Horse>()
            {
                new Horse(35, "Sugar"),
                new Horse(30, "Cash"),
                new Horse(27, "Dakota"),
                new Horse(37, "Cisco"),
                new Horse(29, "Sunshine"),
            };
            Stable stable = new Stable(horses);
            stable.Menu();
        }
    }
}