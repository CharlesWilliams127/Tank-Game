using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TankGameMilestone3
{
	class Bullet : MovableGamePiece
	{
		// Attributes
		private bool active;

		/// <summary>
		/// Gets and sets the active state of the bullet
		/// </summary>
		public bool Active { get { return active; } set { active = value; } }

		/// <summary>
		/// Bullet constructor - Sets the x, y and direction
		/// </summary>
		/// <param name="x">The x position</param>
		/// <param name="y">The y position</param>
		/// <param name="dir">The direction</param>
		public Bullet(int x, int y, int dir)
			: base(x, y, dir)
		{
			// Start out inactive
			active = false;
		}

		/// <summary>
		/// Moves the bullet in its current direction
		/// </summary>
		public override void Move()
		{
               // switch statement to determine which direction the bullet is going in
                switch (direction)
                {
                    case 0: y = y - 1; // increment the position
                        //this.Draw();
                        //if (y <= 0) // check if the tank is near the edge using if statements
                        //{
                            //active = false;
                        //}
                        break;

                    case 1: x = x + 1;
                        if (x > Console.BufferWidth - 1)
                        {
                            active = false;
                        }
                        //this.Draw();
                        break;

                    case 2: y = y + 1;
                        //if (y >= Console.BufferHeight - 1)
                        //{
                            //active = false;
                        //}
                        //this.Draw();
                        break;

                    case 3: x = x - 1;
                        if (x < 0)
                        {
                            active = false;
                        }
                        //this.Draw();
                        break;
                }
                // Check the edges
                if (x < 0 || x >= Console.BufferWidth ||
                    y < 0 || y >= Console.BufferHeight)
                    active = false;
		}

		/// <summary>
		/// Draws the bullet to the screen
		/// </summary>
		public override void Draw()
		{
			// if statement to see if the bullet is active
            if (active == true)
            {
                // call the base draw method
                base.Draw();
                Console.Write("o");
            }
            else
            {
                // if the bullet is not active then end the method
                return;
            }
		}

		/// <summary>
		/// Returns a string representation of the bullet
		/// </summary>
		/// <returns>A string representation of the bullet</returns>
		public override string ToString()
		{
			return "Bullet: Active: " + active + " " + base.ToString();
		}
	}
}
