using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TankGameMilestone3
{
	class Program
	{
        // I decided to use your code for this second milestone Professor, simply because it's much cleaner and has
        // no unnecessary bits like my first milestone code did (multiple gets and sets for the same attributes for example).
		static void Main(string[] args)
		{
			// Make the game
			Game game = new Game();

            // run the game through the GameLoop!
            game.GameLoop();

			// leave the objects at the initial values
			// game.Player1.LoseTank();
			// game.Tank1.TakeHit()

			// do not Print out the objects
			// Console.WriteLine(game.Player1);
			// Console.WriteLine(game.Player2);
			// Console.WriteLine(game.Tank1);
			// Console.WriteLine(game.Tank2);
			// Console.WriteLine(game.Bullet1);
			// Console.WriteLine(game.Bullet2);
			// Console.WriteLine(game.Wall);
            Console.ReadLine();

		}
	}
}
