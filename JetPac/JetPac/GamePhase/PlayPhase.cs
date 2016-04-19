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
            Floor fl=new Floor(GameObjects,Texture, SpriteBatch, Font);
            GameObjects.Add(fl);
        }

        public override void Update(GameTime gameTime)
        {
            
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
