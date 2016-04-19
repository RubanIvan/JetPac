using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using JetPac.GameEngine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JetPac.GameEngine
{

    /// <summary>Фазы игры (игра, настройки, начальное, меню) </summary>
    public enum Phase
    {
        Exit,
        /// <summary>Загрузочная картинка</summary>
        LoadScr,
        /// <summary>Начальное меню</summary>
        MainMenu,
        ///// <summary>Сама игра</summary>
        PlayGame

        //GameOver,

        //HiScore,

        //NewHiScore
    }

    /// <summary>Управляет фазами игры </summary>
    static class GamePhaseManager
    {
        /// <summary>Хранит все возможные фазы игры</summary>
        private static Dictionary<Phase, GamePhaseObject> GamePhases = new Dictionary<Phase, GamePhaseObject>();

        /// <summary>Текущее состояние игры</summary>
        public static GamePhaseObject CurrentPhase;
        //public static GamePhaseObject CurrentPhase
        //{
        //    get { return _CurrentPhase; }
        //    private set { _CurrentPhase = value; }
        //}

        /// <summary>Добавление фазы </summary>
        public static void Add(Phase phase, GamePhaseObject gamestate)
        {
            GamePhases[phase] = gamestate;
        }

        /// <summary>Переключение состояний</summary>
        public static void SwitchTo(Phase phase)
        {
            

            if (CurrentPhase != null)
            {
                //если это первое преклюение не вызываем LostFocus у предыдущего состояния
                CurrentPhase.LostFocus();
            }
                CurrentPhase = GamePhases[phase];
                CurrentPhase.Reset();
                CurrentPhase.Focus();

            
        }

    }

    
    /// <summary>Каждая часть игры (меню,список очков,настройки) должна иметь эти методы и свойства</summary>
    abstract class GamePhaseObject
    {
        //public GraphicsDeviceManager Graphics;
        public SpriteBatch SpriteBatch;
        public Texture2D Texture;
        public SpriteFont Font;
       

        /// <summary>Список всех объектов</summary>
        protected List<GameObject> GameObjects;

        /// <summary>Время прошедшее с последнего Update </summary>
        protected int ElapsedTime = 0;

        //Конструктор
        public GamePhaseObject(Texture2D texture, SpriteBatch spriteBatch, SpriteFont font)
        {
            GameObjects = new List<GameObject>();
            Texture = texture;
            SpriteBatch = spriteBatch;
            Font = font;
            
       }

    public abstract void Update(GameTime gameTime);

        public abstract void Draw();

        /// <summary>Выполняется при получении фокуса (начале работы) </summary>
        public virtual void Reset() { }

        /// <summary>Выполняется при потери фокуса (конец работы фазы) </summary>
        public virtual void LostFocus() { }

        /// <summary>Выполняется при потери фокуса (конец работы фазы) </summary>
        public virtual void Focus() { }

    }

}
