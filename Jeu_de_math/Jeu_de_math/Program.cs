using System;

namespace Jeu_de_math
{
    class Program
    {
        enum e_Operator
        {
            ADDITION = 1,
            MULTIPLICATION = 2
        }
        static bool pauserQuestion(int min, int max)
        {
            Random rand = new Random();
            int reponseInt = 0;

            while (true)
            {
                int a = rand.Next(min, max+1);
                int b = rand.Next(min, max + 1);

                e_Operator o = (e_Operator)rand.Next(1, 3);
                int resultatAttendu;

                switch (o)
                {
                    case e_Operator.ADDITION:
                        Console.Write(a + " + " + b + " = ");
                        resultatAttendu = a + b;
                        break;
                    case e_Operator.MULTIPLICATION:
                        Console.Write(a + " x " + b + " = ");
                        resultatAttendu = a * b;
                        break;
                    default:
                        Console.WriteLine("Operateur inconnu");
                        return false;
                }

                string reponse = Console.ReadLine();
                try
                {
                    reponseInt = int.Parse(reponse);
                    if (reponseInt == resultatAttendu)
                    {
                         return true;
                    }
                    return false;
                }
                catch (Exception)
                {
                    Console.WriteLine("Pas bon");
                }
            }
        }
        static void Main(string[] args)
        {
            const int NOMBRE_MIN = 1;
            const int NOMBRE_Max = 10;
            const int NB_Questions = 5;

            int points = 0;
            
            for (int i = 0; i < NB_Questions; i++)
            {
                Console.WriteLine("Question n " + (i + 1) + " / " + NB_Questions);
                bool bonnereponse = pauserQuestion(NOMBRE_MIN, NOMBRE_Max);
                if (bonnereponse)
                {
                    Console.WriteLine("Bonne réponse");
                    points++;
                }
                else
                {
                    Console.WriteLine("Mauvaise réponse");

                }
                Console.WriteLine();
            }
            Console.WriteLine("Vous avez " + points + " / " + NB_Questions );

            int moyenne = NB_Questions / 2;

            if (points == NB_Questions)
            {
                Console.WriteLine("Excellent");
            }
            else if (points == 0)
            {
                Console.WriteLine("Revisez vos maths");
            }
            else if (points > moyenne)
            {
                Console.WriteLine("Pas mal");
            }
            else
            {
                Console.WriteLine("Peu mieux faire");
            }
        }

    }
}