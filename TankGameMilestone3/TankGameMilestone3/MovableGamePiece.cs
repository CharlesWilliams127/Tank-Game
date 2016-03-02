using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TankGameMilestone3
{
	/// <summary>
	/// A game piece that can move around the screen
	/// </summary>
	abstract class MovableGamePiece : GamePiece
	{
		// Attributes
		protected int direction;

		/// <summary>
		/// Gets and sets the direction
		/// </summary>
		public int Direction
		{
			get { return direction; }
			set
			{
				if (value >= 0 && value <= 3)
					direction = value;
			}
		}

		/// <summary>
		/// MovableGamePiece constructor - sets the X, Y and direction
		/// </summary>
		/// <param name="x">The x position</param>
		/// <param name="y">The y position</param>
		/// <param name="dir">The direction the game piece is facing</param>
		public MovableGamePiece(int x, int y, int dir)
			: base(x, y)
		{
			// Use the property to set the direction
			Direction = dir;
		}

		/// <summary>
		/// Moves the game piece in its current direction
		/// </summary>
		public abstract void Move();

		/// <summary>
		/// Returns a string representation containing the X, Y and direction
		/// </summary>
		/// <returns>A string representation of this movable game piece</returns>
		public override string ToString()
		{
			return base.ToString() + " Direction: " + direction;
		}

	}
}
