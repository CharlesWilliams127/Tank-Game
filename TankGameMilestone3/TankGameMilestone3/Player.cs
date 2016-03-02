using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TankGameMilestone3
{
	class Player
	{
		// Attributes
		private String playerName;
		private int tanksLost;
		private int playerNumber;

		/// <summary>
		/// Gets the player's name
		/// </summary>
		public String PlayerName { get { return playerName; } }

		/// <summary>
		/// Gets the number of tanks the player has lost
		/// </summary>
		public int TanksLost { get { return tanksLost; } }

		/// <summary>
		/// Gets the number of this player
		/// </summary>
		public int PlayerNumber { get { return playerNumber; } }

		/// <summary>
		/// Creates a new player with the specified name and number
		/// </summary>
		/// <param name="name">The player's name</param>
		/// <param name="playerNum">The player's number</param>
		public Player(String name, int playerNum)
		{
			// Save the data
			playerName = name;
			playerNumber = playerNum;
		}

		/// <summary>
		/// Returns whether or not this player has lost the game
		/// </summary>
		/// <returns>True if the player has lost, false otherwise</returns>
		public bool LostGame()
		{
			// The player loses if they have lost 5 or more tanks
			return tanksLost >= 5;
		}

		/// <summary>
		/// Increments the number of tanks this player has lost
		/// </summary>
		public void LoseTank()
		{
			// Increment
			tanksLost++;
		}

		/// <summary>
		/// Returns a string representation of the player
		/// </summary>
		/// <returns>A string representation of the player</returns>
		public override string ToString()
		{
			return "Player " + playerNumber + " Name: " + playerName + " Tanks Lost: " + tanksLost;
		}
	}
}
