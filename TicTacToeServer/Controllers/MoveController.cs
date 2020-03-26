using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TicTacToeServer.Code;
using TicTacToeServer.Models;

namespace TicTacToeServer.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[EnableCors("AllowAllHeaders")]
	public class MoveController : ControllerBase
	{
		// GET api/move
		[HttpGet]
		public ActionResult<IEnumerable<string>> Get()
		{
			return new string[] { "This is the", "Tic Tac Toe server" };
		}

		// GET api/move/5
		[HttpGet("{id}")]
		public ActionResult<string> Get(int id)
		{
			return "value";
		}

		// POST api/move
		[HttpPost]
		public ActionResult<string[]> Post(CurrentState currentState)
		{
			MoveGenerator mover = new MoveGenerator(currentState);
			string nextState = mover.DetermineNextMove();
			return new ActionResult<string[]>(nextState.Split(','));
		}

		//// POST api/move/CalculateNextMove
		//[HttpPost]
		//public ActionResult<string> CalculateNextMove([FromBody] string currentState)
		//{
		//	MoveGenerator mover = new MoveGenerator(currentState);
		//	string nextState = mover.DetermineNextMove();
		//	return new ActionResult<string>(nextState);
		//}
	}
}