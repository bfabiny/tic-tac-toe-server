using System;
using TicTacToeServer.Code;
using TicTacToeServer.Models;
using Xunit;

namespace TicTacToeServer.Tests
{
	public class MoveGenerator_Tests
	{
		[Fact]
		public void DetermineNextMove_WhenWinningMoveExistsOnRow_SelectIt()
		{
			string[] currentBoardState = new string[] { "X", "X", "O", "X", "", "", "O", "", "O" };
			CurrentState state = new CurrentState()
			{
				CurrentBoard = currentBoardState,
				NextMove = 'O'
			};

			MoveGenerator mover = new MoveGenerator(state);

			string nextMove = mover.DetermineNextMove();

			string expectedNextMove = "X,X,O,X,,,O,O,O";
			Assert.Equal(expectedNextMove, nextMove);
		}

		[Fact]
		public void DetermineNextMove_WhenWinningMoveExistsOnColumn_SelectIt()
		{
			string[] currentBoardState = new string[] { "", "X", "O", "X", "", "O", "X", "", "" };
			CurrentState state = new CurrentState()
			{
				CurrentBoard = currentBoardState,
				NextMove = 'O'
			};

			MoveGenerator mover = new MoveGenerator(state);

			string nextMove = mover.DetermineNextMove();

			string expectedNextMove = ",X,O,X,,O,X,,O";
			Assert.Equal(expectedNextMove, nextMove);
		}

		[Fact]
		public void DetermineNextMove_WhenWinningMoveExistsOnDiagonal_SelectIt()
		{
			string[] currentBoardState = new string[] { "X", "", "O", "", "O", "X", "", "X", "" };
			CurrentState state = new CurrentState()
			{
				CurrentBoard = currentBoardState,
				NextMove = 'O'
			};

			MoveGenerator mover = new MoveGenerator(state);

			string nextMove = mover.DetermineNextMove();

			string expectedNextMove = "X,,O,,O,X,O,X,";
			Assert.Equal(expectedNextMove, nextMove);
		}

		[Fact]
		public void DetermineNextMove_WhenBlockingMoveExistsOnRow_SelectIt()
		{
			string[] currentBoardState = new string[] { "", "", "O", "", "X", "X", "", "", "O" };
			CurrentState state = new CurrentState()
			{
				CurrentBoard = currentBoardState,
				NextMove = 'O'
			};

			MoveGenerator mover = new MoveGenerator(state);

			string nextMove = mover.DetermineNextMove();

			string expectedNextMove = ",,O,O,X,X,,,O";
			Assert.Equal(expectedNextMove, nextMove);
		}

		[Fact]
		public void DetermineNextMove_WhenBlockingMoveExistsOnColumn_SelectIt()
		{
			string[] currentBoardState = new string[] { "O", "X", "", "", "X", "O", "", "", "" };
			CurrentState state = new CurrentState()
			{
				CurrentBoard = currentBoardState,
				NextMove = 'O'
			};

			MoveGenerator mover = new MoveGenerator(state);

			string nextMove = mover.DetermineNextMove();

			string expectedNextMove = "O,X,,,X,O,,O,";
			Assert.Equal(expectedNextMove, nextMove);
		}

		[Fact]
		public void DetermineNextMove_WhenBlockingMoveExistsOnDiagonal_SelectIt()
		{
			string[] currentBoardState = new string[] { "", "O", "", "", "X", "", "O", "", "X" };
			CurrentState state = new CurrentState()
			{
				CurrentBoard = currentBoardState,
				NextMove = 'O'
			};

			MoveGenerator mover = new MoveGenerator(state);

			string nextMove = mover.DetermineNextMove();

			string expectedNextMove = "O,O,,,X,,O,,X";
			Assert.Equal(expectedNextMove, nextMove);
		}

		[Fact]
		public void DetermineNextMove_WhenBothWinningAndBlockingMovesAvailable_PrioritiseWinningMove()
		{
			string[] currentBoardState = new string[] { "X", "O", "", "X", "", "X", "O", "", "O" };
			CurrentState state = new CurrentState()
			{
				CurrentBoard = currentBoardState,
				NextMove = 'O'
			};

			MoveGenerator mover = new MoveGenerator(state);

			string nextMove = mover.DetermineNextMove();

			string expectedNextMove = "X,O,,X,,X,O,O,O";
			Assert.Equal(expectedNextMove, nextMove);
		}

		[Fact]
		public void DetermineNextMove_WhenAllSquaresPopulated_ReturnsInitialState()
		{
			string[] currentBoardState = new string[] { "X", "O", "X", "X", "O", "X", "O", "X", "O" };
			CurrentState state = new CurrentState()
			{
				CurrentBoard = currentBoardState,
				NextMove = 'O'
			};

			MoveGenerator mover = new MoveGenerator(state);

			string nextMove = mover.DetermineNextMove();

			string expectedNextMove = "X,O,X,X,O,X,O,X,O";
			Assert.Equal(expectedNextMove, nextMove);
		}
	}
}