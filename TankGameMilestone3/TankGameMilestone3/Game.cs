using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace TankGameMilestone3
{
	class Game
	{
		// Attributes
		private Player p1;
		private Player p2;
		private Tank t1;
		private Tank t2;
		private Bullet b1;
		private Bullet b2;
		private List<Wall> walls;
        private Boolean gameOver;

		#region Properties
		/// <summary>
		/// Gets the Player object for player 1
		/// </summary>
		public Player Player1 { get { return p1; } }

		/// <summary>
		/// Gets the Player object for player 2
		/// </summary>
		public Player Player2 { get { return p2; } }

		/// <summary>
		/// Gets the tank object for player 1
		/// </summary>
		public Tank Tank1 { get { return t1; } }

		/// <summary>
		/// Gets the tank object for player 2
		/// </summary>
		public Tank Tank2 { get { return t2; } }

		/// <summary>
		/// Gets the first tank's bullet object
		/// </summary>
		public Bullet Bullet1 { get { return b1; } }
		
		/// <summary>
		/// Gets the second tank's bullet object
		/// </summary>
		public Bullet Bullet2 { get { return b2; } }

		/// <summary>
		/// Gets the list of walls
		/// </summary>
		public List<Wall> Walls { get { return walls; } }
		#endregion

		/// <summary>
		/// Creates a new game object, which will control
		/// the tank game
		/// </summary>
		public Game()
		{
			// Create the objects
            walls = new List<Wall>();
			p1 = new Player("Bob", 1);
			p2 = new Player("Jim", 2);
			b1 = new Bullet(3, 3, 1);
			b2 = new Bullet(20, 3, 3);
			t1 = new Tank(4, 4, 1, p1, b1);
			t2 = new Tank(20, 4, 3, p2, b2);
            gameOver = false;
            Console.CursorVisible = false;
            Console.BufferHeight = 25;
            Console.WindowHeight = 25;
            this.ReadMap("Map.txt");
		}

        // create the EndGame method
        public void EndGame()
        {
            // clear the console and print the endgame message
            Console.Clear();
            // check to see who wins
            if (p1.LostGame() == true)
            {
                Console.WriteLine("Player 2 has won!");
            }
            else
            {
                Console.WriteLine("Player 1 has won!");
            }
            // more will be added here in the future
        }

        // create the DrawGame method
        public void DrawGame()
        {
            Console.Clear();
            t1.Draw();
            t2.Draw();
            b1.Draw();
            b2.Draw();
            // foreach loop to draw every wall
            foreach(Wall wall in walls)
            {
                wall.Draw();
            }

        }
        
        /// <summary>
        /// Get keyboard input and return it
        /// </summary>
        public char[] GetInput()
        {
            // A list of characters
            List<char> input = new List<char>();

            // Loop while keys are available or we hit 10 keys
            for (int i = 0; Console.KeyAvailable && i < 10; i++)
            {
                // Read a key (preventing it from being printed) 
                // and put it in the key list (if it's not in there yet)
                ConsoleKeyInfo info = Console.ReadKey(true);
                if (!input.Contains(info.KeyChar))
                    input.Add(info.KeyChar);
            }

            // Use up any remaining key presses
            while (Console.KeyAvailable)
            {
                // Read a single key
                Console.ReadKey(true);
            }

            // Convert the list to an array and return
            return input.ToArray();
        }
        
        /// <summary>
        /// Get a bunch of keyboard input and return it
        /// </summary>
        /*
        public char[] GetInput()
        {
            // An array of characters
            char[] input = new char[10];

            // Loop while keys are available and the array hasn’t been filled
            for (int i = 0; Console.KeyAvailable && i < input.Length; i++)
            {
                // Read a key (preventing it from being printed) 
                // and put it in the key array
                ConsoleKeyInfo info = Console.ReadKey(true);
                input[i] = info.KeyChar;
            }

            // Use up any remaining key presses
            while (Console.KeyAvailable)
            {
                // Read a single key
                Console.ReadKey(true);
            }

            // Return the array
            return input;
        }
         * */

        // create the ProcessInput method
        public void ProcessInput()
        {
            char[] input = this.GetInput(); // storing the input in an array
            
            // create a loop that will check each element in the array
            for(int j = 0; j < input.Length; j++)
            {
                // create a switch statement to check each input value in the array
                switch (input[j])
                {
                    case 'q': gameOver = true;
                        break;

                    case 'w': t1.Direction = 0;
                        t1.Move();
                        break;

                    case 'd': t1.Direction = 1;
                        t1.Move();
                        break;

                    case 's': t1.Direction = 2;
                        t1.Move();
                        break;

                    case 'a': t1.Direction = 3;
                        t1.Move();
                        break;

                    case 'f': t1.Fire();
                        break;

                    case 'i': t2.Direction = 0;
                        t2.Move();
                        break;

                    case 'l': t2.Direction = 1;
                        t2.Move();
                        break;

                    case 'k': t2.Direction = 2;
                        t2.Move();
                        break;

                    case 'j': t2.Direction = 3;
                        t2.Move();
                        break;

                    case 'h': t2.Fire();
                        break;
                }
            }
        }

        // detect collisions
        private void DetectCollisions()
        {
            // use if else statements to check every possible collision
            if (b1.IsColliding(t2) == true) // bullet 1 colliding with tank
            {
                t2.TakeHit();
                b1.Active = false;
            }
            else
            {
                if (b2.IsColliding(t1) == true) // bullet 2 colliding with tank
                {
                    t1.TakeHit();
                    b2.Active = false;
                }
                else
                {
                    // foreach loop to check each wall
                    foreach(Wall wall in walls)
                    {
                        if(b1.IsColliding(wall) == true) // bullet 1 colliding with wall
                        {
                            b1.Active = false;
                        }
                        else
                        {
                            if (b2.IsColliding(wall) == true) // bullet 2 colliding with wall
                            {
                                b2.Active = false;
                            }
                            else
                            {
                                if (t1.IsColliding(wall) == true) // tank 1 colliding with wall
                                {
                                    t1.Reverse();
                                }
                                else
                                {
                                    if (t2.IsColliding(wall) == true) // tank 2 colliding with wall
                                    {
                                        t2.Reverse();
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        // SetupTank method that will read from the Map.txt file
        private void SetupTank(string data, Tank tnk)
        {
            // create an array to hold the split data in string form
            string[] dataStr = data.Split(',');

            // parse each part into an int
            // set up a try catch to detect any exceptions
            try
            {
                // set each value of the tank to the data from the map
                tnk.X = int.Parse(dataStr[0]);
                tnk.Y = int.Parse(dataStr[1]);
                tnk.Direction = int.Parse(dataStr[2]);
            }
            catch(Exception e) // if anything goes wrong
            {
                return;
            }
        }

        // the CreateWall method will assign the read values from Map.txt to walls
        private void CreateWall(string data)
        {
            // create an array to hold the split data in string form
            string[] dataStr = data.Split(',');

            // parse each part into an int
            // set up a try catch to detect any exceptions
            try
            {
                // set each value of the wall to the data from the map
                int posX = int.Parse(dataStr[0]);
                int posY = int.Parse(dataStr[1]);

                // create a wall
                Wall wall = new Wall(posX, posY);
                
                // add that wall to the walls list
                walls.Add(wall);
            }
            catch (Exception e) // if anything goes wrong
            {
                return;
            }
        }

        // create the ReadMap method, it will actually read Map.txt
        public void ReadMap(string map)
        {
            try
            {
                // create the StreamReader object
            StreamReader input = new StreamReader(map);

            // read the first two lines
            string line1 = null;
            string line2 = null;
            line1 = input.ReadLine();
            line2 = input.ReadLine();

            // pass both lines off to the SetupTank methods
            this.SetupTank(line1, t1);
            this.SetupTank(line2, t2);

            // create a string attribute that will hold the walls' data
            string lineWall = null;
            // loop until there are no more lines left
            while((lineWall = input.ReadLine()) != null)
            {
                // lineWall = input.ReadLine();

                // assign the lineWall value to the CreateWall method
                this.CreateWall(lineWall);
            }

            // close the stream
            input.Close();
            }
            catch(Exception e) // in case anything is wrong with the map file the game will just run normally
            {
                return;
            }
        }

        // create the GameLoop method
        public void GameLoop()
        {
            while(gameOver == false)
            {
                // call the ProcessInput method
                this.ProcessInput();

                // call the DetectCollisions method
                this.DetectCollisions();

                // call the bullet's moves
                b1.Move();
                b2.Move();

                // call the DrawGame to display everything
                this.DrawGame();

                // pause the screen
                System.Threading.Thread.Sleep(100);

                // check to see if the game is lost
                if(p1.LostGame() == true || p2.LostGame() == true)
                {
                    gameOver = true;
                }
            }
            this.EndGame(); // end the game
        }
	}
}
