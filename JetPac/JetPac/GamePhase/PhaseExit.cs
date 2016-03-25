using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JetPac.GameEngine;
using Microsoft.Xna.Framework;

namespace JetPac.GamePhase
{

    //Просто выходим из игры
    class PhaseExit : GamePhaseObject
    {
        private MainGameLoop Game;

        public PhaseExit(MainGameLoop game)
            : base(null, null, null)
        {
            Game = game;

        }

        public override void Update(GameTime gameTime)
        {
            Game.Exit();
        }

        public override void Draw()
        {
            Game.Exit();
        }
    }
}
