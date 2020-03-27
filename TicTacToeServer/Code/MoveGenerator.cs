using System;
using System.Collections.Generic;
using System.Linq;
using TicTacToeServer.Models;

namespace TicTacToeServer.Code
{
	public class MoveGenerator
	{
		private string[] m_currentState;
		private char m_playerCharacter;
		//private const char OtherPlayerCharacter = 'X';

		private static List<int[]> WinningMoves = new List<int[]>
		{
			new int[] { 0, 1, 2 },
			new int[] { 3, 4, 5 },
			new int[] { 6, 7, 8 },
			new int[] { 0, 3, 6 },
			new int[] { 1, 4, 7 },
			new int[] { 2, 5, 8 },
			new int[] { 0, 4, 8 },
			new int[] { 2, 4, 6 }
		};

		public MoveGenerator(CurrentState initialState)
		{
			m_currentState = initialState.CurrentBoard;
			m_playerCharacter = initialState.NextMove;
		}

		public string DetermineNextMove()
		{
			/* Move Priority:
			 * 1. Can I win - then win
			 * 2. Can other player win - then block
			 * 3. Pick a square at random
			 */

			/* So, breaking it down a bit... If the game can be ended by this move, then go there, either to win, or block. Otherwise pick a random square */

			string[] nextState = m_currentState;

			int winningIndex = GetGameEndingMove(m_playerCharacter);

			if (winningIndex >= 0 && winningIndex < 9)
			{
				nextState[winningIndex] = m_playerCharacter.ToString();
			}
			else
			{
				int index = FindRandomFreeSquare();
				if (index > -1)
				{
					nextState[index] = m_playerCharacter.ToString();
				}
			}

			return string.Join(',', nextState);
		}

		private int FindRandomFreeSquare()
		{
			int randomSquare = -1;

			List<int> squareIndexes = new List<int>(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 });

			var randomisedIndexes = squareIndexes.OrderBy(x => Guid.NewGuid());

			for (int i = 0; i < 9; i++)
			{
				int randomIndex = randomisedIndexes.ElementAt(i);
				if (string.IsNullOrEmpty(m_currentState[randomIndex]))
				{
					randomSquare = randomIndex;
					break;
				}
			}

			return randomSquare;
		}

		private int GetGameEndingMove(char playerToPrioritise)
		{
			/* Logic:
			 * - Loop through all possible winning moves
			 *	- if two of the squares are the same, and not empty, then move into the empty space
			 *	- otherwise, no-one can win on that row/column/diagonal.
			 */
			List<PlayerMove> blockingMoves = new List<PlayerMove>();

			foreach (int[] winningMove in WinningMoves)
			{
				if ((string.IsNullOrEmpty(m_currentState[winningMove[0]]) && string.IsNullOrEmpty(m_currentState[winningMove[1]]))
					|| (string.IsNullOrEmpty(m_currentState[winningMove[1]]) && string.IsNullOrEmpty(m_currentState[winningMove[2]]))
					|| (string.IsNullOrEmpty(m_currentState[winningMove[0]]) && string.IsNullOrEmpty(m_currentState[winningMove[2]])))
				{
					/* two blank squares - no-one can win here */
					continue;
				}

				if (string.IsNullOrEmpty(m_currentState[winningMove[0]]))
				{
					if (m_currentState[winningMove[1]].Equals(m_currentState[winningMove[2]]))
					{
						/* who can win*/
						if (m_currentState[winningMove[1]][0].Equals(playerToPrioritise))
						{
							return winningMove[0];
						}
						else
						{
							PlayerMove move = new PlayerMove(winningMove[0], m_currentState[winningMove[1]]);
							blockingMoves.Add(move);
						}
					}
				}
				if (string.IsNullOrEmpty(m_currentState[winningMove[1]]))
				{
					if (m_currentState[winningMove[0]].Equals(m_currentState[winningMove[2]]))
					{
						/* who can win*/
						if (m_currentState[winningMove[0]][0].Equals(playerToPrioritise))
						{
							return winningMove[1];
						}
						else
						{
							PlayerMove move = new PlayerMove(winningMove[1], m_currentState[winningMove[0]]);
							blockingMoves.Add(move);
						}
					}
				}
				if (string.IsNullOrEmpty(m_currentState[winningMove[2]]))
				{
					if (m_currentState[winningMove[0]].Equals(m_currentState[winningMove[1]]))
					{
						/* who can win*/
						if (m_currentState[winningMove[0]][0].Equals(playerToPrioritise))
						{
							return winningMove[2];
						}
						else
						{
							PlayerMove move = new PlayerMove(winningMove[2], m_currentState[winningMove[0]]);
							blockingMoves.Add(move);
						}
					}
				}
			}

			if (blockingMoves.Count > 0)
			{
				return blockingMoves[0].Index;
			}
			return -1;
		}
	}
}