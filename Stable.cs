namespace CodeAlong
{
    internal class Stable
    {
        private List<Horse> _horses;

        public Stable(List<Horse> horses)
        {
            _horses = horses;
        }
        public void ListHorseOptions()
        {
            for (int i = 0;  i < _horses.Count; i++)
            {
                Console.Write($"[{i + 1}] {_horses[i]._name} - Speed: {_horses[i]._speed}km/h");
                if (_horses[i]._signedUpForRace) Console.Write(" (RACING)");
                Console.WriteLine();
            }
        }
        public void StartRace()
        {
            var horsesToRace = _horses.Where(horse => horse._signedUpForRace).ToList();
            if (horsesToRace.Count == 0)
            {
                Console.WriteLine("No horses are signed up!");
                return;
            }
            bool isRaceOngoing = true;
            Horse firstPlace = null;
            while (isRaceOngoing)
            {
                foreach (var horse in horsesToRace)
                {
                    horse._distanceTravelledInRace += horse._speed;
                    if (firstPlace == null || firstPlace._distanceTravelledInRace < horse._distanceTravelledInRace)
                    {
                        firstPlace = horse;
                    }
                    if (horse._distanceTravelledInRace >= 3000) isRaceOngoing = false;
                }
                if (isRaceOngoing)
                {
                    Console.WriteLine($"Currently in the lead: {firstPlace._name} at {firstPlace._distanceTravelledInRace}/3000km!");
                }
                else
                {
                    Console.WriteLine($"{firstPlace._name} has won the race!");
                }
            }
            foreach (var horse in horsesToRace)
            {
                horse._signedUpForRace = false;
                horse._distanceTravelledInRace = 0;
            }
        }
        public void Menu()
        {
            int selected;
            while (true)
            {
                ListHorseOptions();
                Console.WriteLine($"[{_horses.Count + 1}] Start race");
                string input = Console.ReadLine();
                Console.WriteLine();
                bool output = Int32.TryParse(input, out selected);
                if (output && selected >= 1 && selected <= _horses.Count + 1)
                {
                    if (selected <= _horses.Count)
                    {
                        _horses[selected - 1].Menu();
                    }
                    else
                    {
                        StartRace();
                    }
                }
            }
        }
    }
}
