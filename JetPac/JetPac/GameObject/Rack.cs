using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JetPac.GameEngine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JetPac.GameObject
{
    class Rack:GameEngine.GameObject
    {
        //список координат в текстуре
        private Rectangle[] TextureFrom;

        //список координат на экране
        private Rectangle[] ScrCoord;

        public Rack(Point coord,int length, List<GameEngine.GameObject> gameObjects, Texture2D texture, SpriteBatch spriteBatch, SpriteFont font) : base(gameObjects, texture, spriteBatch, font)
        {
            //Задаем длинну полчки
            TextureFrom=new Rectangle[length];
            ScrCoord=new Rectangle[length];

            //берем левую заглушку
            TextureFrom[0] = new Rectangle(TrueRnd.Next(3) * 16, 412, 16, 16);

            //добавляем середину
            for (int i = 1; i < length-1; i++)
            {
                TextureFrom[i] = new Rectangle(TrueRnd.Next(3) * 16, 428, 16, 16);
            }
            //правую заглушку
            TextureFrom[length-1] = new Rectangle(TrueRnd.Next(3) * 16, 444, 16, 16);
            
            //Заполняем координаты на экране
            for (int i = 0; i < length; i++)
            {
                ScrCoord[i] = new Rectangle(16 * i+coord.X, coord.Y, 16, 16);
            }

            _collaider = new Rectangle(coord.X, coord.Y, 16* (length-1), 16);
        }

        public override void Draw()
        {
            for (int i = 0; i < TextureFrom.Length; i++)
            {
                SpriteBatch.Draw(Texture, ScrCoord[i], TextureFrom[i], Color.Green);
            }
        }
    }
}
