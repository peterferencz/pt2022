namespace kinevetavegen
{

    internal class Program
    {
        static void Main(string[] args)
        {
            int pos1 = 0;
            int pos2 = 0;
            int pos3 = 0;
            int pos4 = 0;
            Random rnd = new Random();
            int[] hejek = new int[100];
            bool megy = true;
            int aktuálisjátékos = 1;
            int nyertes = 0;


            for (int i = 0; i < 10; i++)
            {
                for (int n = 0; n < 10; n++)
                {
                    hejek[i] = 0; // nullára rakja alapbola az öszes hejet

                }

            }
            
            while (megy)
            {


                int e = 0;
                for (int i = 0; i < 100; i++)
                {
                    e++;

                    if (hejek[i] == 0) // kiirja a táblát
                    {
                        Console.Write(" #");
                    }
                    else if (hejek[i] == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(" O");                                    // külön színnel irja ki az öszeset
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (hejek[i] == 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(" O");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (hejek[i] == 3)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(" O");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (hejek[i] == 4)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(" O");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    if (e == 10)
                    {
                        Console.WriteLine("");
                        e = 0;
                    }




                }
                if (aktuálisjátékos == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else if (aktuálisjátékos == 2)
                {

                    Console.ForegroundColor = ConsoleColor.Yellow;    //beszinezi a dobás dialouget
                }
                else if (aktuálisjátékos == 3)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else if (aktuálisjátékos == 4)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                Console.WriteLine("nyomd le az entert " + aktuálisjátékos + " játékos");
                Console.ReadLine();
                int dobás = rnd.Next(1, 7);
                Console.WriteLine("enyit dobtál:" + dobás);           // dob
                Console.ForegroundColor = ConsoleColor.White;
                if (aktuálisjátékos == 1)
                {
                    hejek[pos1] = 0;
                    pos1 = pos1 + dobás; //berakja a dobott hejre a játékost

                }
                else if (aktuálisjátékos == 2)
                {
                    hejek[pos2] = 0;
                    pos2 = pos2 + dobás;
                }
                else if (aktuálisjátékos == 3)
                {
                    hejek[pos3] = 0;
                    pos3 = pos3 + dobás;
                }
                else if (aktuálisjátékos == 4)
                {
                    hejek[pos4] = 0;
                    pos4 = pos4 + dobás;
                }

                if (pos1 < 100)
                {
                    if (hejek[pos1] != 1 && hejek[pos1] != 0) // kiütés
                    {
                        if (hejek[pos1] == 2)
                        {
                            pos2 = 0;

                        }
                        else if (hejek[pos1] == 3)
                        {
                            pos3 = 0;
                        }
                        else if (hejek[pos1] == 4)
                        {
                            pos4 = 0;
                        }
                    }
                    hejek[pos1] = 1;

                }
                else
                {
                    nyertes = 1;
                    megy = false;
                }
                if (pos2 < 100)
                {
                    if (hejek[pos2] != 2 && hejek[pos2] != 0)
                    {
                        if (hejek[pos2] == 1)
                        {
                            pos1 = 0;

                        }
                        else if (hejek[pos1] == 3)
                        {
                            pos3 = 0;
                        }
                        else if (hejek[pos2] == 4)
                        {
                            pos4 = 0;
                        }
                    }
                    hejek[pos2] = 2;
                }
                else
                {
                    nyertes = 2;
                    megy = false;
                }
                if (pos3 < 100)
                {
                    if (hejek[pos3] != 3 && hejek[pos1] != 0)
                    {
                        if (hejek[pos3] == 1)
                        {
                            pos1 = 0;

                        }
                        else if (hejek[pos3] == 2)
                        {
                            pos2 = 0;
                        }
                        else if (hejek[pos3] == 4)
                        {
                            pos4 = 0;
                        }
                    }
                    hejek[pos3] = 3;
                }
                else
                {
                    nyertes = 3;
                    megy = false;
                }
                if (pos4 < 100)
                {
                    hejek[pos4] = 4;
                    if (hejek[pos4] != 4 && hejek[pos4] != 0)
                    {
                        if (hejek[pos4] == 1)
                        {
                            pos1 = 0;

                        }
                        else if (hejek[pos4] == 2)
                        {
                            pos2 = 0;
                        }
                        else if (hejek[pos4] == 3)
                        {
                            pos3 = 0;
                        }
                    }
                }
                else
                {
                    nyertes = 4;
                    megy = false;
                }
                Console.ReadLine();
                Console.Clear();
                if (aktuálisjátékos != 4) // nyertes játékok kiirása
                {
                    aktuálisjátékos++;
                }
                else
                {
                    aktuálisjátékos = 1;
                }
            }
            Console.WriteLine("nyertél " + nyertes + " játékos");
        }
    }
}