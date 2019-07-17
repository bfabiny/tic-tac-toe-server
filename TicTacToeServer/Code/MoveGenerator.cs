using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicTacToeServer.Code
{
	public class MoveGenerator
	{
		private string[] m_currentState;
		private const char MyPlayerCharacter = 'O';
		private const char OtherPlayerCharacter = 'X';

		public MoveGenerator(string currentState)
		{
			m_currentState = currentState.Split(',');
		}

		public string DetermineNextMove()
		{
			/* Move Priority:
			 * 1. Can I win - then win
			 * 2. Can other player win - then block
			 * 3. Pick a square at random
			 */

			string[] nextState = CalculatOWinningMove();
			if (nextState != null)
			{
				return string.Join(',', nextState);
			}

			nextState = BlockXWinningMove();
			if (nextState != null)
			{
				return string.Join(',', nextState);
			}

			nextState = MakeRandomMove();
			return string.Join(',', nextState);
		}

		private string[] MakeRandomMove()
		{
			string[] nextState = m_currentState;

			int index = FindRandomFreeSquare();

			nextState[index] = MyPlayerCharacter.ToString();

			return nextState;
		}

		private int FindRandomFreeSquare()
		{
			int randomSquare = -1;

			List<int> squareIndexes = new List<int>(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 });

			IEnumerable<int> randomisedIndexes = squareIndexes.OrderBy(x => new Random(DateTime.Now.Millisecond).Next());

			for (int i = 0; i < 9; i++)
			{
				if (string.IsNullOrEmpty(m_currentState[randomisedIndexes.ElementAt(i)]))
				{
					randomSquare = randomisedIndexes.ElementAt(i);
					break;
				}
			}

			return randomSquare;
		}

		private string[] CalculatOWinningMove()
		{
		}

		private string[] BlockXWinningMove()
		{
			throw new NotImplementedException();
		}
	}
}