using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.NewGame
{
    class GameHistory
    {
        public Stack<PlayerMemento> History { get; private set; }
        public GameHistory()
        {
            History = new Stack<PlayerMemento>();
        }
    }
}
