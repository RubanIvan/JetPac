using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using JetPac.GameEngine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JetPac.GamePhase
{
    class MainMenuPhase: GamePhaseObject
    {
        /// <summary>Позиция на экране для вывода заднего фона</summary>
        Rectangle BkgTo = new Rectangle(0, 0, 800, 600);
        /// <summary>Позиция заднего фона в текстуре</summary>
        Rectangle BkgFrom = new Rectangle(0, 2048-600-1000, 800, 600);

        /// <summary>На сколько пикселей смещать задний фон</summary>
        int BkgDelta = 4;

        /// <summary>Скорость заднего фона</summary>
        int BkgSpeed = 30;

        /// <summary>перектытие начала концом</summary>
        int Overlap = 0;

        public MainMenuPhase(Texture2D texture, SpriteBatch spriteBatch, SpriteFont font) : base(texture, spriteBatch, font)
        {
        }

        public override void Update(GameTime gameTime)
        {
            ElapsedTime += gameTime.ElapsedGameTime.Milliseconds;

            if (ElapsedTime > BkgSpeed)
            {
                //Debug.WriteLine(Overlap);
                ElapsedTime = 0;
                Overlap = BkgFrom.Y - BkgDelta;
                if (Overlap < -600)
                {
                    Overlap = 2048 + Overlap;
                }
                BkgFrom = new Rectangle(0, Overlap, 800, 600);
                
            }
        }

        public override void Draw()
        {

            SpriteBatch.Draw(Texture, BkgTo, BkgFrom, Color.White);
            //если необходимо перекрытие то рисуем его
            if (Overlap < 0)
            {
                SpriteBatch.Draw(Texture, new Rectangle(0,0,800, Overlap*-1), new Rectangle(0,2048+Overlap,800,Overlap*-1), Color.White);
            }

            SpriteBatch.DrawString(Font,"Player 1", new Vector2(350, 150), Color.Azure);
            SpriteBatch.DrawString(Font, "Press any key to start", new Vector2(300-50, 150+40), Color.Azure);

        }
    }
}
