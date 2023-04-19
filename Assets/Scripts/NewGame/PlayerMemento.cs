using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.NewGame
{
    public class PlayerMemento
    {
        public int Lives { get; set; }
        public int Fireballs { get; set; }
        public Vector2 StartPosition { get; set; }

        public PlayerMemento(int lives, int fire, Vector2 start)
        {
            this.Lives = lives;
            this.Fireballs = fire;
            this.StartPosition = start;
        }
    }
}
