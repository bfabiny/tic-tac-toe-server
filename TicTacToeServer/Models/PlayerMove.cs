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