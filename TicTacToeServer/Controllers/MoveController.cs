using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
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
		// POST api/move
		[HttpPost]
		public ActionResult<string[]> Post(CurrentState currentState)
		{
			MoveGenerator mover = new MoveGenerator(currentState);
			string nextState = mover.DetermineNextMove();
			return new ActionResult<string[]>(nextState.Split(','));
		}
	}
}