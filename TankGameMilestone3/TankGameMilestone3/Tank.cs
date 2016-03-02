using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TankGameMilestone3
{
	/// <summary>
	/// A player-controlled tank game piece
	/// </summary>
	class Tank : MovableGamePiece
	{
		// Attributes
		private int health;
		private Player player;
		private Bullet bullet;

		/// <summary>
		/// Gets the health of the tank
		/// </summary>
		public int Health { get { return health; } }

		/// <summary>
		/// Gets the player to which this tank belongs
		/// </summary>
		public Player Player { get { return player; } }

		/// <summary>
		/// Gets this tank's bullet
		/// </summary>
		public Bullet Bullet { get { return bullet; } }

		/// <summary>
		/// Creates a new tank object
		/// </summary>
		/// <param name="x">The x position</param>
		/// <param name="y">The y position</param>
		/// <param name="dir">The tank's direction</param>
		/// <param name="p">The player that owns this tank</param>
		/// <param name="b">This tank's one and only bullet</param>
		public Tank(int x, int y, int dir, Player p, Bullet b)
			: base(x, y, dir)
		{
			player = p;
			bullet = b;
			health = 2;
		}

        // create the fire method
        public void Fire()
        {
            if(bullet.Active == false)
            {
                // move the bullet to the tank's position
                bullet.X = x;
                bullet.Y = y;

                // change the bullet's direction
                bullet.Direction = direction;

                // set the bullet to active
                bullet.Active = true;
            }
        }

		/// <summary>
		/// Decreases the tank's health
		/// </summary>
		public void TakeHit()
		{
			// Decrement
			health -= 1;

            // check to see if the tank is dead
            this.IsDead();

            // if it is dead then do this
            if (this.IsDead() == true)
            {
                health = 2; // reset health
                player.LoseTank(); // loses tank
            }
		}

		/// <summary>
		/// Determines if the tank is dead
		/// </summary>
		/// <returns>True if the tank's health is less than or equal to zero, false otherwise</returns>
		public bool IsDead()
		{
			return health <= 0;
		}

		/// <summary>
		/// Moves the tank in its current direction
		/// </summary>
		public override void Move()
		{
            // switch statement to determine which direction the tank is going in
            switch (direction)
            {
                case 0: y = y - 1; // increment the position
                    if (y < 0) // check if the tank is near the edge using if statements
                    {
                        y = y + 1;
                    }
                    this.Draw();
                    break;

                case 1: x = x + 1;
                    if (x > Console.BufferWidth -1)
                    {
                        x = x - 1;
                    }
                    this.Draw();
                    break;

                case 2: y = y + 1;
                    if (y > Console.BufferHeight - 1)
                    {
                        y = y - 1;
                    }
                    this.Draw();
                    break;

                case 3: x = x - 1;
                    if (x < 0)
                    {
                        x = x + 1;
                    }
                    this.Draw();
                    break;
            }
		}

		/// <summary>
		/// Draws the tank to the screen
		/// </summary>
		public override void Draw()
		{
			// determine the direction which the tank is moving using a switch statement
            switch(direction)
            {
                case 0: base.Draw();
                    Console.Write("^");
                    break;

                case 1: base.Draw();
                    Console.Write(">");
                    break;

                case 2: base.Draw();
                    Console.Write("v");
                    break;

                case 3: base.Draw();
                    Console.Write("<");
                    break;
            }
		}

        // adding a reverse method to check for collisions
        public void Reverse()
        {
            // use the direction switch statement to determine which way to back up
            switch (direction)
            {
                case 0: y = y + 1;
                    if (y > Console.BufferHeight - 1)
                    {
                        y = y - 1;
                    }
                    this.Draw();
                    break;

                case 1: x = x - 1;
                    if (x < 0)
                    {
                        x = x + 1;
                    }
                    this.Draw();
                    break;

                case 2: y = y - 1; // increment the position
                    if (y < 0) // check if the tank is near the edge using if statements
                    {
                        y = y + 1;
                    }
                    this.Draw();
                    break;

                case 3: x = x + 1;
                    if (x > Console.BufferWidth - 1)
                    {
                        x = x - 1;
                    }
                    this.Draw();
                    break; 
            }
        }

		/// <summary>
		/// Returns a string representation of the tank
		/// </summary>
		/// <returns>A string representation of the tank</returns>
		public override string ToString()
		{
			return "Tank: Health: " + health + " " + base.ToString();
		}
	}
}
