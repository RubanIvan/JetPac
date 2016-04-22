using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JetPac.GameEngine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JetPac.GameObject
{

    public enum PlayerStateEnum
    {
        /// <summary>Стоит развернут в лево </summary>
        IdleLeft,
        /// <summary>Стоит развернут в право</summary>
        IdleRight,
        /// <summary>Идет в лево </summary>
        WalkLeft,
        /// <summary>Идет в право</summary>
        WalkRight,
        /// <summary>Летит в лево</summary>
        FlyLeft,
        /// <summary>Летит в право</summary>
        FlyRight
    }


    class Player :GameEngine.GameObject
    {
        /// <summary>Хранит все состояния объекта</summary>
        protected Dictionary<PlayerStateEnum, State> ObjectStates = new Dictionary<PlayerStateEnum, State>();

        /// <summary>Текущее состояние объекта</summary>
        protected State State;

        public Player(List<GameEngine.GameObject> gameObjects, Texture2D texture, SpriteBatch spriteBatch, SpriteFont font) : base(gameObjects, texture, spriteBatch, font)
        {
            ObjectStates.Add(PlayerStateEnum.IdleRight, new PlayerIdleRight(this));
            ObjectStates.Add(PlayerStateEnum.IdleLeft, new PlayerIdleLeft(this));
            ObjectStates.Add(PlayerStateEnum.WalkLeft, new PlayerWalkLeft(this));

            ChangeState(PlayerStateEnum.WalkLeft);
            Pos= new Rectangle(350, 600 - 16 - 44, 32, 44);
        }

        /// <summary>Сменить состояние объекта</summary>
        public void ChangeState(PlayerStateEnum state)
        {
            State = ObjectStates[state];
            //SMstate = state;
            State.OnChange();
        }

        public override void Draw()
        {
            SpriteBatch.Draw(Texture, Pos,State.Animation.SpritePos, Color.White);
        }

        public override void Update(GameTime gameTime)
        {
            State.Update(gameTime);
        }
    }

    /// <summary>Игрок стоит повернут в лево</summary>
    public class PlayerIdleLeft : State
    {
        public PlayerIdleLeft(GameEngine.GameObject player)
            : base(player)
        {
            Animation = new Animation(new List<Rectangle>() { new Rectangle(224 , 320, 32, 44) });
        }
    }

    /// <summary>Игрок стоит повернут в лево</summary>
    public class PlayerIdleRight : State
    {
        public PlayerIdleRight(GameEngine.GameObject player)
            : base(player)
        {
            Animation = new Animation(new List<Rectangle>() { new Rectangle(0, 320, 32, 44) });
        }
    }

    /// <summary>Игрок идет в лево</summary>
    public class PlayerWalkLeft : State
    {
        public PlayerWalkLeft(GameEngine.GameObject player)
            : base(player)
        {
            Animation = new Animation(new List<Rectangle>()
            {
                new Rectangle(128, 320, 32, 44),
                new Rectangle(160, 320, 32, 44),
                //new Rectangle(192, 320, 32, 44),
                //new Rectangle(224, 320, 32, 44),
            }, 500, true, true);

        }

        public override void Update(GameTime gameTime)
        {
            Animation.Update(gameTime);

            ElapsedTime += gameTime.ElapsedGameTime.Milliseconds;

            if (ElapsedTime > 10)
            {
                ElapsedTime = 0;
                GameObject.Pos.X -= 0;
            }
        }


    }

}
