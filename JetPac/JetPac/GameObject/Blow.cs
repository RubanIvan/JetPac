using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JetPac.GameEngine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JetPac.GameObject
{
    class Blow:GameEngine.GameObject
    {
        /// <summary>Текущая анимация объекта</summary>
        public Animation Animation;

        /// <summary>координаты обьекта на экране</summary>
        public Rectangle Pos;

        public Blow(Rectangle pos, List<GameEngine.GameObject> gameObjects, Texture2D texture, SpriteBatch spriteBatch, SpriteFont font) : base(gameObjects, texture, spriteBatch, font)
        {
            Pos = new Rectangle(pos.X, pos.Y, 48, 32);
            //Pos = new Rectangle(pos.X,pos.Y,72,48);

            Animation = new Animation(new List<Rectangle>()
            {
                new Rectangle(0, 540, 48, 32),new Rectangle(48, 540, 48, 32),
                new Rectangle(96, 540, 48, 32),new Rectangle(144, 540, 48, 32),
                new Rectangle(240, 540, 48, 32),new Rectangle(288, 540, 48, 32),

                //new Rectangle(0, 572, 72, 48),new Rectangle(72*1, 572, 72, 48),
                //new Rectangle(72*2, 572, 72, 48),new Rectangle(72*3, 572, 72, 48),
                //new Rectangle(72*4, 572, 72, 48),new Rectangle(72*5, 572, 72, 48),

            }, 100, true, false, ()=> { GameObjects.Remove(this); });

        }

        public override void Update(GameTime gameTime)
        {
            Animation.Update(gameTime);
        }

        public override void Draw()
        {
            SpriteBatch.Draw(Texture, Pos, Animation.SpritePos, Color.White);
        }
    }
}
