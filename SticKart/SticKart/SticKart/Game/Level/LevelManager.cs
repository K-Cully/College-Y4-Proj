﻿namespace SticKart.Game.Level
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Display;
    using Entities;
    using FarseerPhysics.Common;
    using FarseerPhysics.Dynamics;
    using FarseerPhysics.Factories;
    using FarseerPhysics.SamplesFramework;
    using Input;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// Defines a level and all elements contained within.
    /// </summary>
    public class LevelManager
    {
        // TODO: remove/change to scrolling death once floor is implemented.
        private Body boundry;

        #region level_settings

        /// <summary>
        /// The current level number.
        /// </summary>
        private int currentLevel;

        /// <summary>
        /// Whether the current level is a custom level or not.
        /// </summary>
        private bool currentLevelCustom;

        /// <summary>
        /// The physics world used by the level.
        /// </summary>
        private World physicsWorld;

        #endregion

        #region game_settings

        /// <summary>
        /// The resolution of the game display area.
        /// </summary>
        private Vector2 gameDisplayResolution;

        /// <summary>
        /// The set frame-time of the game.
        /// </summary>
        private float frameTime;

        /// <summary>
        /// The sprite batch to use when drawing.
        /// </summary>
        private SpriteBatch spriteBatch;

        #endregion

        #region content_managment

        /// <summary>
        /// The floor sprite.
        /// </summary>
        private Sprite floorSprite;

        /// <summary>
        /// The content manager to use for loading content.
        /// </summary>
        private ContentManager contentManager;

        /// <summary>
        /// The level loader.
        /// </summary>
        private LevelLoader levelLoader;

        #endregion

        #region entities

        /// <summary>
        /// The list of floor edges.
        /// </summary>
        private List<Body> floorEdges;

        /// <summary>
        /// The list of visual floor edges.
        /// </summary>
        private List<VisualEdge> visualFloorEdges;

        /// <summary>
        /// The list of platforms.
        /// </summary>
        private List<Platform> platforms;

        /// <summary>
        /// the list of interactive entities.
        /// </summary>
        private List<InteractiveEntity> interactiveEntities;
        
        /// <summary>
        /// The player's in game representation.
        /// </summary>
        private StickMan stickman;

        #endregion

        // TODO: Remove this boundry or scroll.
        public Vertices GetBounds()
        {
            float height = ConvertUnits.ToSimUnits(this.gameDisplayResolution.Y);
            float width = ConvertUnits.ToSimUnits(this.gameDisplayResolution.X * 2.0f);

            Vertices bounds = new Vertices(4);
            bounds.Add(new Vector2(0.0f, 0.0f));
            bounds.Add(new Vector2(width, 0.0f));
            bounds.Add(new Vector2(width, height));
            bounds.Add(new Vector2(0.0f, height));
            return bounds;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LevelManager"/> class.
        /// </summary>
        /// <param name="gameDisplayResolution">The resolution the game is set to render at.</param>
        /// <param name="frameTime">The frame time set for the game.</param>
        public LevelManager(Vector2 gameDisplayResolution, float frameTime)
        {
            this.physicsWorld = null;
            this.gameDisplayResolution = gameDisplayResolution;
            this.frameTime = frameTime;
            this.physicsWorld = null;
            this.spriteBatch = null;
            this.floorSprite = new Sprite();
            this.contentManager = null;
            this.levelLoader = null;
            this.floorEdges = new List<Body>();
            this.visualFloorEdges = new List<VisualEdge>();
            this.platforms = new List<Platform>();
            this.interactiveEntities = new List<InteractiveEntity>();
            this.stickman = null;
        }

        /// <summary>
        /// Loads the content used by entities in a level.
        /// </summary>
        /// <param name="contentManager">The content manager to load content with.</param>
        /// <param name="spriteBatch">The sprite batch to render using.</param>
        public void LoadContent(ContentManager contentManager, SpriteBatch spriteBatch)
        {
            this.physicsWorld = new World(ConvertUnits.ToSimUnits(new Vector2(0.0f, 348.8f)));

            this.boundry = BodyFactory.CreateLoopShape(this.physicsWorld, this.GetBounds());
            this.boundry.Friction = float.MaxValue;
            this.boundry.CollisionCategories = Category.All;
            this.boundry.CollidesWith = Category.All;

            this.contentManager = contentManager;
            this.spriteBatch = spriteBatch;
            this.InitializeAndLoadSprites(this.spriteBatch, this.contentManager);

            this.levelLoader = new LevelLoader(this.contentManager);        
            this.stickman = new StickMan(ref this.physicsWorld, 10.0f, 100, -1.0f, this.spriteBatch, this.contentManager);
        }

        /// <summary>
        /// Loads and starts the level specified.
        /// </summary>
        /// <param name="levelNumber">The level to start.</param>
        /// <param name="isCustom">Whether the level is a custom level or not.</param>
        public void BeginLevel(int levelNumber, bool isCustom)
        {
            this.currentLevel = levelNumber > 0 ? levelNumber : 1;
            this.currentLevelCustom = isCustom;

            // TODO: Implement logic to allow for custom levels.

            this.physicsWorld.ClearForces();
            this.levelLoader.LoadLevel(this.currentLevel, this.currentLevelCustom);

            LevelFactory.CreateFloor(this.levelLoader.FloorPoints, ref this.physicsWorld, ref this.floorEdges, ref this.visualFloorEdges, this.gameDisplayResolution.Y);
            LevelFactory.CreatePlatforms(this.levelLoader.PlatformDescriptions, ref this.physicsWorld, ref this.platforms, this.spriteBatch, this.contentManager);
            LevelFactory.CreateInteractiveEntities(this.levelLoader.InteractiveDescriptions, ref this.physicsWorld, ref this.interactiveEntities, this.spriteBatch, this.contentManager);
            this.stickman.Reset(this.levelLoader.StartPosition);
            // TODO: this.exit = new Exit(this.levelLoader.EndPosition);
        }

        /// <summary>
        /// Cleans up after a level.
        /// </summary>
        public void EndLevel() // TODO: Call once level end added.
        {
            LevelFactory.DisposeOfPlatforms(ref this.physicsWorld, ref this.platforms);
            LevelFactory.DisposeOfInteractiveEntities(ref this.physicsWorld, ref this.interactiveEntities);
            LevelFactory.DisposeOfFloor(ref this.physicsWorld, ref this.floorEdges, ref this.visualFloorEdges);
            // TODO: this.exit.Dispose();
        }
   
        /// <summary>
        /// Updates all the entities in the current level.
        /// </summary>
        /// <param name="gameTime">The game time.</param>
        /// <param name="commands">A list of input commands.</param>
        public void Update(GameTime gameTime, List<InputCommand> commands)
        {
            // TODO
            this.stickman.Update(gameTime);

            foreach (InputCommand command in commands)
            {
                switch (command)
                {
                    case InputCommand.Jump:
                        this.stickman.Jump();
                        break;
                    case InputCommand.Crouch:
                        this.stickman.CrouchOrJumpDown();
                        break;
                    case InputCommand.Run:
                        this.stickman.Run();
                        break;
                    default:
                        break;
                }
            }

            this.physicsWorld.Step(MathHelper.Min((float)gameTime.ElapsedGameTime.TotalSeconds, this.frameTime));                    
        }

        /// <summary>
        /// Draws the level and any entities it contains.
        /// </summary>
        public void Draw()
        {
            // TODO
            foreach (Platform platform in this.platforms)
            {
                platform.Draw();
            }

            foreach (VisualEdge edge in this.visualFloorEdges)
            {
                Sprite.Draw(this.floorSprite, edge.Position, edge.Angle);
            }

            this.stickman.Draw();
        }

        /// <summary>
        /// Initializes and loads the textures for the floor sprite.
        /// </summary>
        /// <param name="spriteBatch">The sprite batch to use for rendering the sprites.</param>
        /// <param name="contentManager">The content manager to use for loading the sprites.</param>
        private void InitializeAndLoadSprites(SpriteBatch spriteBatch, ContentManager contentManager)
        {
            this.floorSprite.InitializeAndLoad(spriteBatch, contentManager, EntityConstants.SpritesFolderPath + EntityConstants.Floor);
        }
    }
}