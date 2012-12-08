// <auto-generated />
// Note: There are no comments in this file as it is merely a placeholder until I add the editor to the game.

namespace SticKart
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Audio;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.GamerServices;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using Microsoft.Xna.Framework.Media;
    using Display;
    using LevelEditor;

    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class SticKartLevelEditor : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        
        SpriteBatch spriteBatch;

        Vector2 screenDimensions;

        float clickTimer;

        float maxTimeBetweenClicks;

        float keyTimer;

        float maxTimeBetweenKeys;

        LevelEditor.LevelEditor levelEditor;

        public SticKartLevelEditor()
        {
            this.TargetElapsedTime = TimeSpan.FromSeconds(1.0 / 30.0);
            this.screenDimensions = new Vector2(1280.0f, 720.0f);
            this.graphics = new GraphicsDeviceManager(this);
            this.graphics.PreferredBackBufferWidth = (int)this.screenDimensions.X;
            this.graphics.PreferredBackBufferHeight = (int)this.screenDimensions.Y;
            this.graphics.IsFullScreen = false;
            Content.RootDirectory = "Content";
            this.IsMouseVisible = true;
            Camera2D.Initialize(this.screenDimensions);
            this.levelEditor = new LevelEditor.LevelEditor();
            this.maxTimeBetweenKeys = 0.2f;
            this.keyTimer = this.maxTimeBetweenKeys;
            this.maxTimeBetweenClicks = 0.2f;
            this.clickTimer = this.maxTimeBetweenClicks;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            this.levelEditor.LoadContent(this.spriteBatch, this.Content);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            this.keyTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            this.clickTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            MouseState mouseState = Mouse.GetState();

            if (mouseState.X > 0 && mouseState.Y > 0 && mouseState.X < this.screenDimensions.X && mouseState.Y < screenDimensions.Y)
            {
                this.levelEditor.Update(new Vector2(mouseState.X, mouseState.Y) + Camera2D.OffsetPosition);

                if (this.clickTimer > this.maxTimeBetweenClicks)
                {
                    if (mouseState.LeftButton == ButtonState.Pressed)
                    {
                        this.levelEditor.AddSelectedElement();
                        this.clickTimer = 0.0f;
                    }
                    else if (mouseState.RightButton == ButtonState.Pressed)
                    {
                        this.levelEditor.RemoveSelectedElement();
                        this.clickTimer = 0.0f;
                    }
                }

                KeyboardState temp = Keyboard.GetState();
                if (mouseState.X > this.screenDimensions.X * 0.9f)
                {
                    Camera2D.Update(new Vector2(50.0f, 0.0f), gameTime);
                }                
                else if (temp.IsKeyDown(Keys.Right))
                {
                    Camera2D.Update(new Vector2(250.0f, 0.0f), gameTime);
                }
                else if (Camera2D.OffsetPosition.X > 0.0f)
                {
                    if (mouseState.X < this.screenDimensions.X * 0.1f)
                    {
                        Camera2D.Update(new Vector2(-50.0f, 0.0f), gameTime);
                    }
                    else if (temp.IsKeyDown(Keys.Left))
                    {
                        Camera2D.Update(new Vector2(-250.0f, 0.0f), gameTime);
                    }
                }

                if (this.keyTimer > this.maxTimeBetweenKeys)
                {                    
                    if (temp.IsKeyDown(Keys.Up))
                    {
                        this.levelEditor.CycleSelection();
                        this.keyTimer = 0.0f;
                    }
                    else if (temp.IsKeyDown(Keys.Add))
                    {
                        this.levelEditor.PlatformWidth = this.levelEditor.PlatformWidth + 16.0f;
                        this.keyTimer = 0.0f;
                    }
                    else if (temp.IsKeyDown(Keys.Subtract))
                    {
                        this.levelEditor.PlatformWidth = this.levelEditor.PlatformWidth + -16.0f;
                        this.keyTimer = 0.0f;
                    }
                    else if (temp.IsKeyDown(Keys.S))
                    {
                        this.levelEditor.SaveLevel(true); // TODO: Remove in release
                        this.levelEditor.SaveLevel(false);
                        this.keyTimer = 0.0f;
                    }
                    else if (temp.IsKeyDown(Keys.L))
                    {
                        this.levelEditor.LoadLevel(1);
                        this.keyTimer = 0.0f;
                    }
                    else if (temp.IsKeyDown(Keys.N))
                    {
                        this.levelEditor.CreateNewLevel();
                        this.keyTimer = 0.0f;
                    }
                }
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            this.spriteBatch.Begin();
            this.levelEditor.Draw();
            this.spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
