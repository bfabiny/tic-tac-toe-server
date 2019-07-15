using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace TicTacToeServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
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
        public ActionResult<char[]> CalculateNextMove([FromBody] char[]currentState)
        {
            char[] nextState = DetermineNextMove(currentState);
            return new ActionResult<char[]>(nextState);
        }

        private char[] DetermineNextMove(char[] currentState)
        {
            char[] nextState = currentState;

            if (CanOWin(currentState, out nextState))
            {
                return nextState;
            }

            else if (CanXWin(currentState, out nextState))
            {
                return nextState;
            }

            
            return currentState;
        }

        private bool CanOWin(char[] currentState, out char[] nextState)
        {
            throw new NotImplementedException();
        }

        private bool CanXWin(char[] currentState, out char[] nextState)
        {
            throw new NotImplementedException();
        }

        // PUT api/move/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/move/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
