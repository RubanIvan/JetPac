using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JetPac.GameEngine
{
    abstract class GameObject
    {
        //ссылка на список всех обьектов в игре
        protected List<GameObject> GameObjects;

        //ссылка на данные для отрисовки
        protected Texture2D Texture;
        protected SpriteBatch SpriteBatch;
        protected SpriteFont Font;

        //Колайдер для обработки столкновений
        protected Rectangle _collaider;
        public Rectangle Collaider {
            get { return _collaider; }
            set { _collaider = value; }
        }

        public GameObject(List<GameObject> gameObjects, Texture2D texture, SpriteBatch spriteBatch, SpriteFont font)
        {
            GameObjects = gameObjects;
            Texture = texture;
            SpriteBatch = spriteBatch;
            Font = font;
        }

        

        public abstract void Update(GameTime gameTime);
        public abstract void Draw();


    }
}
