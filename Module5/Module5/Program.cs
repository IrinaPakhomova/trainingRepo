using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module5
{
    class Program
    {
        const int n = 12;
        static String[][] frame = new string[n][];
        static bool gameStatus = true;
        static string hero = "H";
        static string bomb = "*";
        static int lifeScore = 10;
        static string princess = "P";
        static string emptyCell = " ";
        static int[,] field;

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            start:;
            frame[0] = new string[] { "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#" };
            for (int i = 1; i < n - 1; i++)
            {
                frame[i] = new string[] { "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#" };
            }
            frame[n - 1] = new string[] { "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#" };
            frame[10][10] = hero;
            frame[1][1] = princess;
            GenerateBombs(10, out field);
            Render();
            while (gameStatus)
            {
                var key = Console.ReadKey();
                MoveHero(key);
                Render();
            }

            if (!gameStatus)
            {
                Console.WriteLine("Do you want play again? (Y/N)");
                if (string.Equals(Console.ReadLine(), "Y", StringComparison.InvariantCultureIgnoreCase))
                {
                    gameStatus = true;
                    lifeScore = 10;
                    goto start;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("".PadRight(23, '#'));
                    Console.WriteLine("#                     #");
                    Console.WriteLine("#       GameOver!     #");
                    Console.WriteLine("#                     #");
                    Console.WriteLine("".PadRight(23, '#'));
                }
            }
            Console.ReadKey();
        }
        static void YouAreWinner()
        {
            Render();
            Console.WriteLine("YOU ARE WINNER!!");
            Console.WriteLine("Press any key...");
            gameStatus = false;
            Console.ReadKey();
        }
        static void YouAreLoser()
        {
            Render();
            Console.WriteLine("YOU ARE LOOSER!!");
            Console.WriteLine("Press any key...");
            gameStatus = false;
            Console.ReadKey();
        }
        static void Render()
        {
            Console.Clear();
            for (int x = 0; x < n; x++)
            {
                for (int y = 0; y < n; y++)
                    Console.Write(frame[y][x]);
                Console.WriteLine();
            }
            Console.WriteLine($"\nHero life is:{lifeScore}\n");
        }

        static void MoveHero(ConsoleKeyInfo keyInfo)
        {
            for (int x = frame.Length - 1; x >= 0; x--)
            {
                for (int y = 0; y < frame[x].Length; y++)
                {
                    if (frame[x][y] == hero)
                    {
                        if (keyInfo.Key == ConsoleKey.UpArrow)
                        {
                            if ((x - 1) >= 0 && (frame[x][y - 1] == emptyCell || frame[x][y - 1] == princess))
                            {
                                if (frame[x][y - 1] == princess)
                                {
                                    frame[x][y] = emptyCell;
                                    frame[x][y - 1] = hero;
                                    YouAreWinner();
                                }
                                else
                                {
                                    frame[x][y] = emptyCell;
                                    if (field[x - 1, y - 2] > 0)
                                    {
                                        frame[x][y - 1] = bomb;
                                        lifeScore -= field[x - 1, y - 2];
                                        field[x - 1, y - 2] = 0;
                                        if (lifeScore < 0)
                                        {
                                            lifeScore = 0;
                                            YouAreLoser();
                                        }
                                        Render();
                                        System.Threading.Thread.Sleep(1000);
                                    }
                                    frame[x][y - 1] = hero;
                                }
                            }
                            return;
                        }
                        else if (keyInfo.Key == ConsoleKey.DownArrow)
                        {
                            if ((x + 1) <= (frame.Length - 1) && (frame[x][y + 1] == emptyCell || frame[x][y + 1] == princess))
                            {
                                if (frame[x][y + 1] == princess)
                                {
                                    frame[x][y] = emptyCell;
                                    frame[x][y + 1] = hero;
                                    YouAreWinner();
                                }
                                else
                                {
                                    frame[x][y] = emptyCell;
                                    if (field[x - 1, y] > 0)
                                    {
                                        frame[x][y + 1] = bomb;
                                        lifeScore -= field[x - 1, y];
                                        field[x - 1, y] = 0;
                                        if (lifeScore < 0)
                                        {
                                            lifeScore = 0;
                                            YouAreLoser();
                                        }
                                        Render();
                                        System.Threading.Thread.Sleep(1000);
                                    }
                                    frame[x][y + 1] = hero;
                                }
                            }
                            return;
                        }
                        else if (keyInfo.Key == ConsoleKey.LeftArrow)
                        {
                            if ((y - 1) >= 0 && (frame[x - 1][y] == emptyCell || frame[x - 1][y] == princess))
                            {
                                if (frame[x - 1][y] == princess)
                                {
                                    frame[x][y] = emptyCell;
                                    frame[x - 1][y] = hero;
                                    YouAreWinner();
                                }
                                else
                                {
                                    frame[x][y] = emptyCell;
                                    if (field[x - 2, y - 1] > 0)
                                    {
                                        frame[x - 1][y] = bomb;
                                        lifeScore -= field[x - 2, y - 1];
                                        field[x - 2, y - 1] = 0;
                                        if (lifeScore < 0)
                                        {
                                            lifeScore = 0;
                                            YouAreLoser();
                                        }
                                        Render();
                                        System.Threading.Thread.Sleep(1000);
                                    }
                                    frame[x - 1][y] = hero;
                                }
                            }
                            return;
                        }
                        else if (keyInfo.Key == ConsoleKey.RightArrow)
                        {
                            if ((y + 1) <= (frame.Length - 1) && (frame[x + 1][y] == emptyCell || frame[x + 1][y] == princess))
                            {

                                if (frame[x + 1][y] == princess)
                                {
                                    frame[x][y] = emptyCell;
                                    frame[x + 1][y] = hero;
                                    YouAreWinner();
                                }
                                else
                                {
                                    frame[x][y] = emptyCell;

                                    if (field[x, y - 1] > 0)
                                    {
                                        frame[x + 1][y] = bomb;
                                        lifeScore -= field[x, y - 1];
                                        field[x, y - 1] = 0;

                                        if (lifeScore < 0)
                                        {
                                            lifeScore = 0;
                                            YouAreLoser();
                                        }
                                        Render();
                                        System.Threading.Thread.Sleep(1000);
                                    }
                                    frame[x + 1][y] = hero;
                                }
                            }
                            return;
                        }

                    }
                }
            }
        }

        static void GenerateBombs(int field_length, out int[,] mas)
        {
            mas = new int[field_length, field_length];
            Random rn = new Random();
            int pozX, pozY;
            int count = 0;
            do
            {
                pozX = rn.Next(0, field_length);
                pozY = rn.Next(0, field_length);
                if (!((pozX == 0 && pozY == 0) || (pozX == 9 && pozY == 9)))
                {
                    if (mas[pozX, pozY] == 0)
                    {
                        mas[pozX, pozY] = count + 1;
                        count++;
                    }
                }
            } while (count <= 10);
        }
    }
}
