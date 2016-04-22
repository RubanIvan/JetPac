using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace JetPac.GameEngine
{
    /// <summary>Состояние объекта </summary>
    public class State
    {
        /// <summary>Текущая анимация объекта</summary>
        public Animation Animation;

        /// <summary>Объект которому принадлежит это состояние</summary>
        protected GameObject GameObject;

        /// <summary>Время в тиках прошедшее после последнего действия</summary>
        protected int ElapsedTime = 0;

        //Конструктор
        public State(Animation animation)
        {
            Animation = animation;
        }

        /// <summary>Конструктор</summary>
        /// <param name="gameObject">кому принадлежит это состояние</param>
        public State(GameObject gameObject)
        {
            GameObject = gameObject;
        }


        public virtual void Update(GameTime gameTime)
        {
            Animation.Update(gameTime);
        }

        /// <summary>Вызывается когда выбирается состояние</summary>
        public virtual void OnChange()
        {
        }

    }

}
