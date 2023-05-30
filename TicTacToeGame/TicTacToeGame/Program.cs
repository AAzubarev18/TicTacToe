using System;
using System.Text;
using System.Threading;

namespace TicTacToeGame
{
    class Program
    {
        static char[] arr = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static int player = 1;
        static int cell;
        static bool flag = false;
        static bool uncertianty = false;

        static void Main(string[] args)
        {

            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("I Игрок(X) ПРОТИВ II Игрока(O)");
                Console.ResetColor();

                if (player % 2 == 0)
                {
                    Console.WriteLine("\nХодит игрок O ");
                }
                else
                {
                    Console.WriteLine("\nХодит игрок X ");
                }

                Board();

                cell = int.Parse(Console.ReadLine());

                if (arr[cell] != 'X' && arr[cell] != 'O')
                {
                    if (player % 2 == 0)
                    {
                        arr[cell] = 'O';
                        player++;
                    }
                    else
                    {
                        arr[cell] = 'X';
                        player++;
                    }
                }
                else
                {
                    Console.WriteLine("К сожалению ячейка {0} уже занята.", cell);
                    Console.WriteLine("\n");
                    Console.WriteLine("Перерисовываем поле...откатываемся назад");
                    Thread.Sleep(2000);
                }

                flag = CheckWin();
            }
            while (!flag);

            Console.Clear();
            Board();

            if (flag == true && uncertianty == true)
            {
                Console.WriteLine("Ничья");
            }
            else if (flag == true && uncertianty == false)
            {
                Console.WriteLine("\nИгрок {0} победил", (player % 2) + 1);
            }
            Console.ReadLine();
        }

        private static void Board()
        {

            String _first = String.Format("  {0}  |  {1}  |  {2}  \n", arr[1], arr[2], arr[3]);
            String _second = String.Format("  {0}  |  {1}  |  {2}  \n", arr[4], arr[5], arr[6]);
            String _third = String.Format("  {0}  |  {1}  |  {2}  \n", arr[7], arr[8], arr[9]);

            Char[] _firstArray = _first.ToCharArray();
            Char[] _secondArray = _second.ToCharArray();
            Char[] _thirdArray = _third.ToCharArray();


            Console.WriteLine("_________________");
            Console.WriteLine("     |     |     |");
            foreach (Char c in _firstArray)
            {
                if (c == 'O')
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(c);
                }
                else if (c == 'X')
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(c);
                }
                else if (c != 'X' || c != 'O')
                {
                    Console.ResetColor();
                    Console.Write(c);
                }

            }
            Console.WriteLine("_____|_____|_____|");
            Console.WriteLine("     |     |     |");
            foreach (Char c in _secondArray)
            {
                if (c == 'O')
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(c);
                }
                else if (c == 'X')
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(c);
                }
                else if (c != 'X' || c != 'O')
                {
                    Console.ResetColor();
                    Console.Write(c);
                }
            }
            Console.WriteLine("_____|_____|_____|");
            Console.WriteLine("     |     |     |");
            foreach (Char c in _thirdArray)
            {
                if (c == 'O')
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(c);
                }
                else if (c == 'X')
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(c);
                }
                else if (c != 'X' || c != 'O')
                {
                    Console.ResetColor();
                    Console.Write(c);
                }
            }

            Console.WriteLine("_____|_____|_____|");

        }

        private static bool CheckWin()
        {
            //Выигрышные исходы
            if ((arr[1] == arr[2] && arr[2] == arr[3]) || (arr[4] == arr[5] && arr[5] == arr[6]) || 
                (arr[6] == arr[7] && arr[7] == arr[8]) || (arr[1] == arr[4] && arr[4] == arr[7]) ||
                (arr[2] == arr[5] && arr[5] == arr[8]) || (arr[3] == arr[6] && arr[6] == arr[9]) || 
                (arr[1] == arr[5] && arr[5] == arr[9]) || (arr[3] == arr[5] && arr[5] == arr[7]))
            {
                return true;
            }
            // Ничья
            else if (arr[1] != '1' && arr[2] != '2' && arr[3] != '3' && arr[4] != '4' && arr[5] != '5' &&
                     arr[6] != '6' && arr[7] != '7' && arr[8] != '8' && arr[9] != '9')
            {
                uncertianty = true;
                return true;
            }
            else
            {
                //В процессе игры
                return false;
            }
        }
    }
}
