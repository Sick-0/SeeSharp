using System;
using System.Diagnostics;

namespace StreamConsole
{
    public class Intro
    {
        private string nameCoach = "Sicco";
        private int ageCoach = 28;

        private string[] myGamesForQ = new string[3]{"Factorio", "Subnautica", "Animal Crossing"};
        
        private string[] myMoviesForQ = new string[3] {"Joker", "The Platform", "Totoro"};

        public void getCoachInfo()
        {
            Console.WriteLine("The coach is " + nameCoach + " his age is " + ageCoach);
        }

        public void checkCoachInfo()
        {
            //if statements
            if (true)
            {
                Console.WriteLine("its true duh");
            }

            if (ageCoach > 18)
            {
                Console.WriteLine("He is an adult wooop wooop");
            }

            if (myMoviesForQ.Length > 3)
            {
                Console.WriteLine("He is prepare");
            }
            else
            {
                Console.WriteLine("He is kipsla");
            }

            switch (nameCoach)
            {
                case "Sicco" :
                    Console.WriteLine("ITS SICCO TIME");
                    break;
                case "Koen" :
                    Console.WriteLine("ITS PHP TIME");
                    break;
                default :
                    Console.WriteLine("ITS NOT EVEN A COACH");
                    break;
            }
        }

        public void LoopsBaby()
        {
            while (ageCoach < 100)
            {
                if (ageCoach == 30)
                {
                    break;
                }
                Console.WriteLine(ageCoach++);
            }

            for (int i = 0; i < 11; i++)
            {
                Console.WriteLine(i);
            }

            foreach (string game in myGamesForQ)
            {
                Console.WriteLine(game);
            }
        }
        
    }
}
