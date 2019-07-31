using System;
using TicTacToeServer.Code;
using Xunit;

namespace TicTacToeServer.Tests
{
	public class MoveGenerator_Tests
	{
		[Fact]
		public void DetermineNextMove_WhenWinningMoveExistsOnRow_SelectIt()
		{
			string currentBoardState = "X,X,O,X,,,O,,O";

			MoveGenerator mover = new MoveGenerator(currentBoardState);

			string nextMove = mover.DetermineNextMove();

			string expectedNextMove = "X,X,O,X,,,O,O,O";
			Assert.Equal(expectedNextMove, nextMove);
		}

		[Fact]
		public void DetermineNextMove_WhenWinningMoveExistsOnColumn_SelectIt()
		{
			string currentBoardState = ",X,O,X,,O,X,,";

			MoveGenerator mover = new MoveGenerator(currentBoardState);

			string nextMove = mover.DetermineNextMove();

			string expectedNextMove = ",X,O,X,,O,X,,O";
			Assert.Equal(expectedNextMove, nextMove);
		}

		[Fact]
		public void DetermineNextMove_WhenWinningMoveExistsOnDiagonal_SelectIt()
		{
			string currentBoardState = "X,,O,,O,X,,X,";

			MoveGenerator mover = new MoveGenerator(currentBoardState);

			string nextMove = mover.DetermineNextMove();

			string expectedNextMove = "X,,O,,O,X,O,X,";
			Assert.Equal(expectedNextMove, nextMove);
		}

		[Fact]
		public void DetermineNextMove_WhenBlockingMoveExistsOnRow_SelectIt()
		{
			string currentBoardState = ",,O,,X,X,,,O";

			MoveGenerator mover = new MoveGenerator(currentBoardState);

			string nextMove = mover.DetermineNextMove();

			string expectedNextMove = ",,O,O,X,X,,,O";
			Assert.Equal(expectedNextMove, nextMove);
		}

		[Fact]
		public void DetermineNextMove_WhenBlockingMoveExistsOnColumn_SelectIt()
		{
			string currentBoardState = "O,X,,,X,O,,,";

			MoveGenerator mover = new MoveGenerator(currentBoardState);

			string nextMove = mover.DetermineNextMove();

			string expectedNextMove = "O,X,,,X,O,,O,";
			Assert.Equal(expectedNextMove, nextMove);
		}

		[Fact]
		public void DetermineNextMove_WhenBlockingMoveExistsOnDiagonal_SelectIt()
		{
			string currentBoardState = ",O,,,X,,O,,X";

			MoveGenerator mover = new MoveGenerator(currentBoardState);

			string nextMove = mover.DetermineNextMove();

			string expectedNextMove = "O,O,,,X,,O,,X";
			Assert.Equal(expectedNextMove, nextMove);
		}

		[Fact]
		public void DetermineNextMove_WhenBothWinningAndBlockingMovesAvailable_PrioritiseWinningMove()
		{
			string currentBoardState = "X,O,,X,,X,O,,O";

			MoveGenerator mover = new MoveGenerator(currentBoardState);

			string nextMove = mover.DetermineNextMove();

			string expectedNextMove = "X,O,,X,,X,O,O,O";
			Assert.Equal(expectedNextMove, nextMove);
		}
	}
}