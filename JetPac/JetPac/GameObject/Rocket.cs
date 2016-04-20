using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JetPac.GameObject
{
    /// <summary>Перечисления всех ракет</summary>
    enum RocketType
    {
        RocketU1=0,
        RocketU2,
        RocketU3,
        RocketU4,
    }

    /// <summary>Перечесление кусков ракеты</summary>
    enum RocketSection
    {
        Top=0,
        Body,
        Engine
    }

    class RocketPart:GameEngine.GameObject
    {
        //список координат в текстуре
        private Rectangle[] TextureFrom = new Rectangle[1];

        //список координат на экране
        private Rectangle[] ScrCoord = new Rectangle[1];

        //тип ракеты
        private RocketType RocketType;
        
        public RocketPart(Point pos, RocketType rocketType, RocketSection section, List<GameEngine.GameObject> gameObjects, Texture2D texture, SpriteBatch spriteBatch, SpriteFont font) : base(gameObjects, texture, spriteBatch, font)
        {
            RocketType = rocketType;

            //получаем координаты в текстуре куска ракеты
            TextureFrom[0]=new Rectangle((int)section * 32, ((int)rocketType)*32+128,32,32);

            ScrCoord[0]=new Rectangle(pos.X,pos.Y,32,32);
        }

        //переместится в точку
        public override void MoveTo(Point pos)
        {
            ScrCoord[0] = new Rectangle(pos.X, pos.Y, 32, 32);
        }

        public override void Draw()
        {
            SpriteBatch.Draw(Texture, ScrCoord[0], TextureFrom[0], Color.White);
        }
    }


    class Rocket : GameEngine.GameObject
    {
        //список координат в текстуре
        private Rectangle[] TextureFrom = new Rectangle[3];

        //список координат на экране
        private Rectangle[] ScrCoord = new Rectangle[3];

        //тип ракеты
        private RocketType RocketType;

        public Rocket(Point pos, RocketType rocketType, List<GameEngine.GameObject> gameObjects, Texture2D texture, SpriteBatch spriteBatch, SpriteFont font) : base(gameObjects, texture, spriteBatch, font)
        {
            RocketType = rocketType;
            //получаем координаты в текстуре куска ракеты
            TextureFrom[0] = new Rectangle((int)0 * 32, ((int)rocketType) * 32 + 128, 32, 32);
            TextureFrom[1] = new Rectangle((int)1 * 32, ((int)rocketType) * 32 + 128, 32, 32);
            TextureFrom[2] = new Rectangle((int)2 * 32, ((int)rocketType) * 32 + 128, 32, 32);

            ScrCoord[0] = new Rectangle(pos.X, pos.Y, 32, 32);
            ScrCoord[1] = new Rectangle(pos.X, pos.Y+32, 32, 32);
            ScrCoord[2] = new Rectangle(pos.X, pos.Y+64, 32, 32);
        }

        //переместится в точку
        public override void MoveTo(Point pos)
        {
            ScrCoord[0] = new Rectangle(pos.X, pos.Y, 32, 32);
        }

        public override void Draw()
        {
            SpriteBatch.Draw(Texture, ScrCoord[0], TextureFrom[0], Color.White);
            SpriteBatch.Draw(Texture, ScrCoord[1], TextureFrom[1], Color.White);
            SpriteBatch.Draw(Texture, ScrCoord[2], TextureFrom[2], Color.White);
        }
    }
}
