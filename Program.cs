using System;

namespace Board
{
    class Program
    {
        static void Main(string[] args)
        {
            
            while (true) {
                Console.WriteLine("Please enter name：");
                string username = Console.ReadLine();
                Console.WriteLine("Please enter one game that you want to play，enter 10  11 or 13, enter q to quit");
                Console.WriteLine("H represent Hearts, S represent Spade, C represent Club, D represent Diamond");
                string type = Console.ReadLine();
                Board board = new Elevens(13);
                switch (type) {
                    case "10":
                        board = new Tens(13);
                        break;
                    case "11":
                        board = new Elevens(9);
                        break;
                    case "12":
                        board = new Thirteens(10);
                        break;
                    case "q":
                        return;
                }
                while (true) {
                    board.printBoard();
                    Console.WriteLine("Please select the card that you want.(enter R to restart the game)");

                    string c = Console.ReadLine();
                    if (c == "R" || c == "r") {
                        break;
                    }
                    foreach (var item in c.Split(' '))
                    {
                        board.SelectCard(item);
                    }
                    if (board.checkForWin())
                    {
                        Console.WriteLine("You win！");
                        break;
                    }
                }

            }
        }
    }
}
