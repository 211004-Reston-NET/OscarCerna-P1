using System;

namespace UserInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            bool repeat = true;

            IFactory factory = new MenuFactory();

            IMenu page = factory.GetMenu(MenuType.MainMenu);

            while (repeat)
            {
                 Console.Clear();

                 page.Menu();
                 MenuType currentPage = page.YourChoice();

                 if (currentPage == MenuType.Exit)
                 {
                    Console.WriteLine("You Are Exiting The Application!");
                    Console.WriteLine("Press Enter to Continue");
                    Console.ReadLine();
                    repeat = false;
                }
                else
                {
                    page = factory.GetMenu(currentPage);
                }
            }

        }
    }
}