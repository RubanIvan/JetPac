using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JetPac.GameEngine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JetPac.GamePhase
{
    class LoadScrPhase : GamePhaseObject
    {
        /// <summary>Позиция на экране для вывода заднего фона</summary>
        Rectangle BkgTo = new Rectangle(0, 0, 800, 600);
        /// <summary>Позиция заднего фона в текстуре</summary>
        Rectangle BkgFrom = new Rectangle(0, 0, 800, 600);

        public LoadScrPhase(Texture2D texture, SpriteBatch spriteBatch, SpriteFont font) : base(texture, spriteBatch, font)
        {
        }

        public override void Update(GameTime gameTime)
        {
            
            if (Input.PressAnyKey())
            {
                
                GamePhaseManager.SwitchTo(Phase.MainMenu);
            }
        }

        public override void Draw()
        {
            //Задний фон
            SpriteBatch.Draw(Texture, BkgTo, BkgFrom, Color.White);
        }
    }
}
