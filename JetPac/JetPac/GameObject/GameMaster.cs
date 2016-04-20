using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JetPac.GameEngine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JetPac.GameObject
{
    class GameMaster : GameEngine.GameObject
    {
        /// <summary>текущий уровень игры</summary>
        private int GameLevel = 0;

        /// <summary>определяет необходимы ли стартовые настройки уровня</summary>
        private bool isGameStart = true;

        //скорость добавления монстров в игру
        private int AddEnemyElapsedTime;
        private int AddEnemyTimeSpeed = 700;


        /// <summary>Храним ссылку на куски ракеты чтоб потом быстро убрать из списка и добавить целую рокету</summary>
        RocketPart[] RocketPart = new RocketPart[3];

        public override void Update(GameTime gameTime)
        {
            //если игра только начилась производим настройку уровня (добавляем обьекты)
            if (isGameStart)
            {
                LevelInit();
                isGameStart = false;
            }

            //Добавляем монстров с определенной скоростью
            AddEnemyElapsedTime += gameTime.ElapsedGameTime.Milliseconds;

            //проверяем время после последнего добавления и количество монстров
            if (AddEnemyElapsedTime > AddEnemyTimeSpeed && GameObjects.Count(x => x is IEnemy)< GameLevels.Level[GameLevel].MaxEnemy)
            {
                GameObjects.Add((GameEngine.GameObject)Activator.CreateInstance(GameLevels.Level[GameLevel].EnemyType, GameObjects, Texture, SpriteBatch, Font));
            }
            

        }

        /// <summary>Инициализация уровня</summary>
        private void LevelInit()
        {
            //создаем пол
            GameObjects.Add(new Floor(GameObjects, Texture, SpriteBatch, Font));

            //создаем все полочки на уровне
            foreach (RackPoint rack in GameLevels.Level[GameLevel].Racks)
            {
                GameObjects.Add(new Rack(new Point(rack.x, rack.y), rack.length, GameObjects, Texture, SpriteBatch, Font));
            }

            //создаем ракету
            if (GameLevels.Level[GameLevel].isAssemblyRequired)
            { //по частям
                //двигатель всегда стоит на космодроме
                RocketPart engine = new RocketPart(new Point(GameLevels.Level[GameLevel].Kosmodrom.X, 552),
                                      GameLevels.Level[GameLevel].RocketType,
                                      RocketSection.Engine,
                                      GameObjects, Texture, SpriteBatch, Font);
                GameObjects.Add(engine);
                RocketPart[0] = engine;

                //на первую платформу ставим тело ракеты 
                RocketPart body = new RocketPart(new Point(GameLevels.Level[GameLevel].Racks[0].x + (int)(GameLevels.Level[GameLevel].Racks[0].length / 2.0f) * 16 - 16, GameLevels.Level[GameLevel].Racks[0].y - 32),
                                      GameLevels.Level[GameLevel].RocketType,
                                      RocketSection.Body,
                                      GameObjects, Texture, SpriteBatch, Font);
                GameObjects.Add(body);
                RocketPart[1] = body;
                //на вторую платформу ставим верхушку ракеты 
                RocketPart top = new RocketPart(new Point(GameLevels.Level[GameLevel].Racks[1].x + (int)(GameLevels.Level[GameLevel].Racks[1].length / 2.0f) * 16 - 16, GameLevels.Level[GameLevel].Racks[1].y - 32),
                                      GameLevels.Level[GameLevel].RocketType,
                                      RocketSection.Top,
                                      GameObjects, Texture, SpriteBatch, Font);
                GameObjects.Add(top);
                RocketPart[2] = top;
            }
            else
            {
                //если надо ставить целую рокету то ставим целую
                Rocket rocket = new Rocket(new Point(GameLevels.Level[GameLevel].Kosmodrom.X, 520 - 16 - 16),
                                      GameLevels.Level[GameLevel].RocketType,
                                      GameObjects, Texture, SpriteBatch, Font);
                GameObjects.Add(rocket);
            }

            
            //стартуем уровень с половиной монмтров
            Type t = GameLevels.Level[GameLevel].EnemyType;
            for (int i = 0; i < GameLevels.Level[GameLevel].MaxEnemy/2.0; i++)
            {
                GameObjects.Add((GameEngine.GameObject)Activator.CreateInstance(t, GameObjects, Texture, SpriteBatch, Font));
            }
        }

        /// <summary>Добавляет противников</summary>
        private void AddEnemy()
        {
            
            //находим всех противников
            int CurEnemyCount = GameObjects.Count(x => x is IEnemy);

            //добавляем до штата
            for (int i = CurEnemyCount; i < GameLevels.Level[GameLevel].MaxEnemy; i++)
            {
                GameObjects.Add((GameEngine.GameObject)Activator.CreateInstance(GameLevels.Level[GameLevel].EnemyType, GameObjects, Texture, SpriteBatch, Font));
            }
        }

        //конструктор
        public GameMaster(List<GameEngine.GameObject> gameObjects, Texture2D texture, SpriteBatch spriteBatch, SpriteFont font) : base(gameObjects, texture, spriteBatch, font)
        {
        }

    }
}
