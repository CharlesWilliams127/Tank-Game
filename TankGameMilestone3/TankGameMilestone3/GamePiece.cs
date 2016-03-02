using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TankGameMilestone3
{
	/// <summary>
	/// Represents a single game piece in the tank game
	/// </summary>
	abstract class GamePiece
	{
		// Attributes
		protected int x;
		protected int y;

		/// <summary>
		/// Gets and sets the X position
		/// </summary>
		public int X { get { return x; } set { x = value; } }

		/// <summary>
		/// Gets and sets the Y position
		/// </summary>
		public int Y { get { return y; } set { y = value; } }

		/// <summary>
		/// GamePiece Constructor.  Sets the X and Y positions
		/// </summary>
		/// <param name="newX">The X position</param>
		/// <param name="newY">The Y position</param>
		public GamePiece(int newX, int newY)
		{
			x = newX;
			y = newY;
		}

		/// <summary>
		/// Moves the cursor to the correct place on the screen
		/// </summary>
		public virtual void Draw()
		{
            // clear the console
            // Console.Clear();
			// set the Console's cursors equal to the x and y attributes
            Console.CursorLeft = x;
            Console.CursorTop = y;
		}

        // the method to check whether two objects are colliding
        public Boolean IsColliding(GamePiece gp)
        {
            // check to see if two objects occupy the same space
            if (gp.X == this.X && gp.Y == this.Y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

		/// <summary>
		/// Returns a string representation of the X and Y positions
		/// </summary>
		/// <returns>A string with the X and Y positions</returns>
		public override string ToString()
		{
			return "Position: " + x + "," + y;
		}
	}
}
