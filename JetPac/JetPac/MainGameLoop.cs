using System;
using System.Collections.Generic;
using System.Linq;
using JetPac.GameEngine;
using JetPac.GamePhase;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace JetPac
{
    /// <summary>Основной класс игры</summary>
    public class MainGameLoop : Microsoft.Xna.Framework.Game
    {
        /// <summary>Графический экран</summary>
        GraphicsDeviceManager Graphics;

        /// <summary>Простынь со спрайтами</summary>
        SpriteBatch SpriteBatch;

        /// <summary>Шрифт для вывода текста</summary>
        SpriteFont Font;

        /// <summary>Статический класс по работе со звуком</summary>
        //SoundEngine

        /// <summary>Статический класс опрос клавиатуры и мыши</summary>
        //Input

        /// <summary>Статический класс смена фаз (сцен) игры</summary>
        //GamePhaseManager

        // конструктор
        public MainGameLoop()
        {
            Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            Graphics.PreferredBackBufferHeight = Const.ScrDy;
            Graphics.PreferredBackBufferWidth = Const.ScrDx;

        }

        
        //Загрузка всех ресурсов
        protected override void LoadContent()
        {
            //загружаем шрифт
            Font = Content.Load<SpriteFont>("font");

            //Инициализируем статический класс со звуком
            SoundEngine.SoundInit(Content);
            
            // Create a new SpriteBatch, which can be used to draw textures.
            SpriteBatch = new SpriteBatch(GraphicsDevice);

            //Загружаем все фазы(сцены)
            GamePhaseManager.Add(Phase.Exit, new PhaseExit(this));
            GamePhaseManager.Add(Phase.LoadScr, new LoadScrPhase(Content.Load<Texture2D>("Load Scr"), SpriteBatch, Font));
            GamePhaseManager.Add(Phase.MainMenu, new MainMenuPhase(Content.Load<Texture2D>("stars_texture"), SpriteBatch, Font));

            //Переключаемся на фазу загрузочной картинки
            GamePhaseManager.SwitchTo(Phase.LoadScr);

        }

        
        //Обновление модели игры
        protected override void Update(GameTime gameTime)
        {
            // Выход при нажатии Escape
            if (Input.IsKeyDown(Keys.Escape)) this.Exit();
            //Обновляем состояние клавиатуры
            Input.Update();

            //Обновляем текущую сцену
            GamePhaseManager.CurrentPhase.Update(gameTime);

            if (Input.IsKeyDown(Keys.A))
            {
                GamePhaseManager.SwitchTo(Phase.LoadScr);
            }


            base.Update(gameTime);
        }

        
        //Отрисовка модели игры
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            SpriteBatch.Begin();

            GamePhaseManager.CurrentPhase.Draw();

            SpriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
