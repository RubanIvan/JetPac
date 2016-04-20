using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JetPac.GameEngine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JetPac.GameObject
{
    class EnemyMeteor:GameEngine.GameObject,IEnemy    
    {
        /// <summary>Текущая анимация объекта</summary>
        public Animation Animation;

        /// <summary>координаты обьекта на экране</summary>
        public Rectangle Pos;

        //скорость движения 
        private int MoveElapsedTime;
        private int MoveTimeSpeed=50;
        //смещение по y
        private int dy = TrueRnd.Next(7);

        /// <summary>направление движения -1 с права, 1 с лева </summary>
        private int dir;

        //Список с чем может сталкнутся метеорит (пол и полочки)
        private List<Rectangle> WallColaider=new List<Rectangle>(); 

        public EnemyMeteor(List<GameEngine.GameObject> gameObjects, Texture2D texture, SpriteBatch spriteBatch, SpriteFont font) : base(gameObjects, texture, spriteBatch, font)
        {
            //выбираем направление
            dir = TrueRnd.Next(1) > 0 ? 1 : -1;
            
            //выбираем один из 4 метеоритов
            int n = TrueRnd.Next(3);
            Animation = new Animation(new List<Rectangle>()
            {
                new Rectangle(0, 460+n*20, 32, 20),new Rectangle(32, 460+n*20, 32, 20),
                new Rectangle(64, 460+n*20, 32, 20),new Rectangle(96, 460+n*20, 32, 20),
            }, 50, true, true, null);

            //устанавливаем начальные координаты
            if (dir > 0)
            {
                Pos = new Rectangle(0, TrueRnd.Next(550), 32, 20);
            }
            else
            {
                Pos = new Rectangle(800, TrueRnd.Next(550), 32, 20);
            }

            foreach (GameEngine.GameObject gameObject in GameObjects)
            {
                //сохраняем колайдеры от стен и пола
                if ((gameObject is Floor) || (gameObject is Rack) )
                {
                    WallColaider.Add(gameObject.Collaider);
                }
            }
        }

        public override void Update(GameTime gameTime)
        {
            Animation.Update(gameTime);
            MoveElapsedTime += gameTime.ElapsedGameTime.Milliseconds;

            if (MoveElapsedTime > MoveTimeSpeed)
            {
                MoveElapsedTime = 0;
                Pos =new Rectangle(Pos.X+7*dir,Pos.Y+dy,32,20);
                if(Pos.X<0) Pos = new Rectangle(800, Pos.Y + 2, 32, 20);
                if(Pos.X>800) Pos = new Rectangle(0, Pos.Y + 2, 32, 20);

                //Проверяем на столкновение со стенками
                foreach (Rectangle wall in WallColaider)
                {
                    if (wall.Intersects(Pos))
                    {   //если столкнулись удаляем метеорит
                        GameObjects.Remove(this);
                        //ставим на его место метеорит
                        GameObjects.Add(new Blow(Pos, GameObjects, Texture, SpriteBatch, Font));
                    }
                }
            }
        }

        public override void Draw()
        {
            if (dir > 0)
            {
                SpriteBatch.Draw(Texture, Pos, Animation.SpritePos, Color.White);
            }
            else
            {
                SpriteBatch.Draw(Texture, Pos, Animation.SpritePos, Color.White,0,Vector2.Zero, SpriteEffects.FlipHorizontally,0 );    
            }

        }
    }
}
