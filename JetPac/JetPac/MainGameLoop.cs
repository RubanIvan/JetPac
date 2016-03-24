using System;
using System.Collections.Generic;
using System.Linq;
using JetPac.GameEngine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace JetPac
{
    /// <summary>�������� ����� ����</summary>
    public class MainGameLoop : Microsoft.Xna.Framework.Game
    {
        /// <summary>����������� �����</summary>
        GraphicsDeviceManager Graphics;

        /// <summary>�������� �� ���������</summary>
        SpriteBatch SpriteBatch;

        /// <summary>����� ��� ������ ������</summary>
        SpriteFont Font;

        /// <summary>����������� ����� �� ������ �� ������</summary>
        //SoundEngine

        /// <summary>����������� ����� ����� ���������� � ����</summary>
        //Input


        // �����������
        public MainGameLoop()
        {
            Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            Graphics.PreferredBackBufferHeight = Const.ScrDy;
            Graphics.PreferredBackBufferWidth = Const.ScrDx;

        }

        
        //�������� ���� ��������
        protected override void LoadContent()
        {
            //��������� �����
            Font = Content.Load<SpriteFont>("font");

            //�������������� ����������� ����� �� ������
            SoundEngine.SoundInit(Content);


            // Create a new SpriteBatch, which can be used to draw textures.
            SpriteBatch = new SpriteBatch(GraphicsDevice);

            
        }

        
        //���������� ������ ����
        protected override void Update(GameTime gameTime)
        {
            // ����� ��� ������� Escape
            if (Input.IsKeyDown(Keys.Escape)) this.Exit();
            //��������� ��������� ����������
            Input.Update();



            base.Update(gameTime);
        }

        
        //��������� ������ ����
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            

            base.Draw(gameTime);
        }
    }
}
