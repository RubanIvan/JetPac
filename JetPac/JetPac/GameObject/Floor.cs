using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JetPac.GameEngine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JetPac.GameObject
{

    //пол поверхность планеты на которой ходим
    class Floor:GameEngine.GameObject
    {
        //список координат в текстуре
        private Rectangle[] TextureFrom = new Rectangle[50];

        //список координат на экране
        private Rectangle[] ScrCoord=new Rectangle[50] ;

        public Floor(List<GameEngine.GameObject> gameObjects, Texture2D texture, SpriteBatch spriteBatch, SpriteFont font) : base(gameObjects, texture, spriteBatch, font)
        {   
            //берем левую заглушку
            TextureFrom[0]= new Rectangle(TrueRnd.Next(3)*16,412,16,16);
            
            //добавляем середину
            for (int i = 1; i < 49; i++)
            {
                TextureFrom[i]=new Rectangle(TrueRnd.Next(3) * 16, 428, 16, 16);
            }
            //правую заглушку
            TextureFrom[49]=new Rectangle(TrueRnd.Next(3) * 16, 444, 16, 16);

            //Заполняем координаты на экране
            for (int i = 0; i < 50; i++)
            {
                ScrCoord[i]=new Rectangle(16*i, 584, 16, 16);
            }

            //колайдер для столкновений
            _collaider=new Rectangle(0,584,800,16);

        }

        
        public override void Draw()
        {
            for (int i = 0; i < TextureFrom.Length; i++)
            {
                SpriteBatch.Draw(Texture, ScrCoord[i], TextureFrom[i], Color.Yellow);
            }

        }
    }
}
