using System;

namespace Testing
{
    class Menu
    {
        string[] optionList;
        public int optionSelected;
        int index;

        public Menu()
        {
            //List of options
            optionList = new string[] {
                "One",
                "Two",
                "Exit"
            };

            //Default values when nothing is selected
            optionSelected = -1;
            index = 0;
        }

        /// <summary>
        /// Shows the Menu 
        /// </summary>
        public void Show()
        {
            Console.CursorVisible = false;

            Console.WriteLine("Select Option:");
            Console.WriteLine("--------------\n");

            for (int i = 0; i < optionList.Length; i++)
            {
                if (i == index)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;

                    Console.WriteLine( "        " + optionList[i]);

                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine(optionList[i]);
                }
            }

            //Reads key
            ConsoleKeyInfo opt = Console.ReadKey();

            //Move selector or select current option
            switch (opt.Key)
            {
                case ConsoleKey.DownArrow:
                    if (index == optionList.Length - 1)
                        index = 0;
                    else
                        index++;
                    break;

                case ConsoleKey.UpArrow:
                    if (index <= 0)
                        index = optionList.Length - 1;
                    else
                        index--;
                    break;

                case ConsoleKey.Enter:
                    optionSelected = index + 1;
                    break;

                default:
                    optionSelected = -1;
                    break;
            }

            Console.Clear();
            Console.CursorVisible = true;
        }

        /// <summary>
        /// Executes the option selected
        /// </summary>
        /// <returns>False if the user selects the "Exit" option</returns>
        public bool DoOption()
        {
            bool status = true;

            switch (optionSelected)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("HELLO one!");
                    Console.ReadKey();
                    Console.Clear();
                    break;

                case 2:
                    Console.Clear();
                    Console.WriteLine("HELLO two!");
                    Console.ReadKey();
                    Console.Clear();
                    break;

                case 3:
                    status = false;
                    break;
            }

            //Resets the option selected
            optionSelected = -1;

            return status;
        }
    }

    class Program
    {
        public static Menu menu;

        static void Main(string[] args)
        {
            menu = new Menu();

            do
            {
                do
                {
                    menu.Show();
                } while (menu.optionSelected == -1);

            } while (menu.DoOption());

            Console.Clear();
            Console.WriteLine("Press any key to exit the program ...");
            Console.ReadKey();
        }
    }
}
