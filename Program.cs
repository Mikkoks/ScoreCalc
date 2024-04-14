using System;
using System.Collections.Generic;
namespace ScoreCalc;

class Program
{
    static void Main(string[] args)
    {
        List<MenuItem> menuItems = [
            new("Set max score."),
            new("Set number of rounds."),
            new("Exit"),
        ];

        int selectedItem = 0;

        while (true)
        {
            Console.Clear();
            DisplayMenu(menuItems, selectedItem);
            Console.WriteLine($"You selected: {menuItems[selectedItem].Label}");
            ConsoleKeyInfo key = Console.ReadKey();

            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    selectedItem = Math.Clamp(--selectedItem, 0, menuItems.Count - 1);
                    break;
                case ConsoleKey.DownArrow:
                    selectedItem = Math.Clamp(++selectedItem, 0, menuItems.Count - 1);
                    break;
                case ConsoleKey.Enter:
                    if (selectedItem == menuItems.Count - 1)
                    {
                        return;
                    }
                    else
                    {
                        Console.WriteLine($"You selected: {menuItems[selectedItem].Label}");

                    }
                    break;
            }
            static void DisplayMenu(List<MenuItem> menuItems, int selectedItem)
            {
                Console.WriteLine("Select an option:");

                for (var i = 0; i < menuItems.Count; i++)
                {
                    if (selectedItem == i)
                    {
                        Console.WriteLine($">{menuItems[i].Label}");
                    }
                    else
                    {
                        Console.WriteLine($"{menuItems[i].Label}");
                    }

                }
            }
        }


    }
}

internal class MenuItem(string label)
{
    public string Label = label;
}