using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TicTacToeServer.Code;

namespace TicTacToeServer.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MoveController : ControllerBase
	{
		// GET api/move
		[HttpGet]
		public ActionResult<IEnumerable<string>> Get()
		{
			return new string[] { "value1", "value2" };
		}

		// GET api/move/5
		[HttpGet("{id}")]
		public ActionResult<string> Get(int id)
		{
			return "value";
		}

		// POST api/move
		[HttpPost]
		public void Post([FromBody] string value)
		{
		}

		// POST api/move/CalculateNextMove
		[HttpPost]
		public ActionResult<string> CalculateNextMove([FromBody] string currentState)
		{
			MoveGenerator mover = new MoveGenerator(currentState);
			string nextState = mover.DetermineNextMove();
			return new ActionResult<string>(nextState);
		}
	}
}