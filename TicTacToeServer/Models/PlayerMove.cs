using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicTacToeServer.Models
{
	public class PlayerMove
	{
		public int Index { get; }
		public string Player { get; }

		public PlayerMove(int index, string player)
		{
			this.Index = index;
			this.Player = player;
		}
	}
}