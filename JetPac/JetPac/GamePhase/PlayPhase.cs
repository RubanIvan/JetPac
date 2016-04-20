using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JetPac.GameEngine;
using JetPac.GameObject;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JetPac.GamePhase
{
    class PlayPhase : GamePhaseObject
    {
        public PlayPhase(Texture2D texture, SpriteBatch spriteBatch, SpriteFont font) : base(texture, spriteBatch, font)
        {
            //создаем GameMaster в дальнейшем он делает ключивые изменения в игре
            GameMaster GM=new GameMaster(GameObjects, Texture, SpriteBatch, Font);
            GameObjects.Add(GM);
        }

        public override void Update(GameTime gameTime)
        {
            for (int i = 0; i < GameObjects.Count; i++)
            {
                GameObjects[i].Update(gameTime);
            }
            
        }

        public override void Draw()
        {
            foreach (GameEngine.GameObject gameObject in GameObjects)
            {
                gameObject.Draw();
            }
        }

        

        
    }
}
