using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TankGameMilestone3
{
	/// <summary>
	/// A wall that blocks tanks and bullets
	/// </summary>
	class Wall : GamePiece
	{
		/// <summary>
		/// Creates a wall at the specified location
		/// </summary>
		/// <param name="x">The x position</param>
		/// <param name="y">The y position</param>
		public Wall(int x, int y)
			: base(x, y) 
		{ }

		/// <summary>
		/// Draws the wall on the screen
		/// </summary>
		public override void Draw()
		{
			// drawing the wall
	        // calling the base class to set the cursor
            base.Draw();
            // use the console to display a character
            Console.Write("#");
		}

		/// <summary>
		/// Returns a string representation of the wall
		/// </summary>
		/// <returns>A string representation of the wall</returns>
		public override string ToString()
		{
			return "Wall: " + base.ToString();
		}
	}
}
