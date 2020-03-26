using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicTacToeServer.Models
{
    public class CurrentState
    {
        public char NextMove { get; set; }
        public string[] CurrentBoard { get; set; }
    }
}
