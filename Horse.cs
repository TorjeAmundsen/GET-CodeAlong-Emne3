namespace CodeAlong
{
    internal class Horse
    {
        public int _speed;
        public string _name;
        public bool _signedUpForRace;
        public int _distanceTravelledInRace;

        public Horse(int speed, string name)
        {
            _speed = speed;
            _name = name;
        }
        public void Feed()
        {
            Console.WriteLine($"You fed {_name}!\n");
        }
        public void Groom()
        {
            Console.WriteLine($"You groomed and took care of {_name}!\n");
        }
        public void SignUpForRace()
        {
            if (_signedUpForRace )
            {
                Console.WriteLine($"{_name} is already signed up for the race!\n");
                return;
            }
            _signedUpForRace = true;
            Console.WriteLine($"{_name} has been signed up for the next race!\n");
        }
        public void Menu()
        {
            int selected;
            bool inMenu = true;
            while (inMenu)
            {
                Console.WriteLine($"Selected horse: {_name}");
                Console.WriteLine("[1] Feed");
                Console.WriteLine("[2] Groom");
                Console.WriteLine("[3] Sign up for race");
                Console.WriteLine("[4] Go back");
                string input = Console.ReadLine();
                Console.WriteLine();
                bool output = Int32.TryParse(input, out selected);
                if (output && selected >= 1 && selected <= 4)
                {
                    switch (selected)
                    {
                        case 1: Feed(); break;
                        case 2: Groom(); break;
                        case 3: SignUpForRace(); break;
                        default: inMenu = false; break;
                    }
                }
            }

        }
    }
}
