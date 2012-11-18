﻿namespace SticKart.Game.Entities
{
    using System.Collections.Generic;
    using FarseerPhysics.Dynamics;

    /// <summary>
    /// Contains level entity names.
    /// </summary>
    public class EntityConstants
    {
        #region paths

        /// <summary>
        /// The path to the entity settings folder.
        /// </summary>
        public const string SpritesFolderPath = "Sprites/Entities/";

        /// <summary>
        /// The sub-folder of the stick man asset folder.
        /// </summary>
        public const string StickManSubPath = "Stick_man/";

        /// <summary>
        /// The path to the entity settings folder.
        /// </summary>
        public const string SettingsFolderPath = "Entity_settings/";

        /// <summary>
        /// The sub-folder path to the bonus settings/sprites folder.
        /// </summary>
        public const string BonusFolderSubPath = "Bonuses/";

        /// <summary>
        /// The sub-folder path to the obstacle settings/sprites folder.
        /// </summary>
        public const string ObstacleFolderSubPath = "Obstacles/";

        /// <summary>
        /// The sub-folder path to the power up settings/sprites folder.
        /// </summary>
        public const string PowerUpFolderSubPath = "Power_ups/";

        #endregion

        #region bonus_names

        /// <summary>
        /// The name of a coin bonus entity.
        /// </summary>
        public const string CoinName = "coin";

        /// <summary>
        /// The name of a ruby bonus entity.
        /// </summary>
        public const string RubyName = "ruby";

        /// <summary>
        /// The name of a diamond bonus entity.
        /// </summary>
        public const string DiamondName = "diamond";

        #endregion

        #region obstacle_names

        /// <summary>
        /// The name of a rock obstacle entity.
        /// </summary>
        public const string RockName = "rock";

        /// <summary>
        /// The name of a spike obstacle entity.
        /// </summary>
        public const string SpikeName = "spike";

        /// <summary>
        /// The name of a fire obstacle entity.
        /// </summary>
        public const string FireName = "fire";

        #endregion

        #region power_up_names

        /// <summary>
        /// The name of an invincible power up entity.
        /// </summary>
        public const string InvincibleName = "invincible";

        /// <summary>
        /// The name of a health power up entity.
        /// </summary>
        public const string HealthName = "health";

        /// <summary>
        /// The name of a speed power up entity.
        /// </summary>
        public const string SpeedName = "speed";

        /// <summary>
        /// The name of a jump power up entity.
        /// </summary>
        public const string JumpName = "jump";

        #endregion

        #region stick_man_assets
        
        /// <summary>
        /// The name of the stick man standing sprite.
        /// </summary>
        public const string StickManStanding = "StickManStanding";        

        #endregion

        /// <summary>
        /// The name of the platform asset.
        /// </summary>
        public const string Platform = "Platform";

        /// <summary>
        /// The name of the floor asset.
        /// </summary>
        public const string Floor = "Floor";       

        #region collision_categories

        /// <summary>
        /// The collision category of the stick man.
        /// </summary>
        public const Category FloorCategory = Category.Cat1;

        /// <summary>
        /// The collision category of the stick man.
        /// </summary>
        public const Category StickManCategory = Category.Cat31;

        /// <summary>
        /// The collision category of a platform.
        /// </summary>
        public const Category PlatformCategory = Category.Cat2;

        /// <summary>
        /// The collision category of an interactive entity.
        /// </summary>
        public const Category InteractiveEntityCategory = Category.Cat3;

        #endregion

        /// <summary>
        /// Gets the list of power up names.
        /// </summary>
        public static List<string> PowerUpNames
        {
            get
            {
                List<string> names = new List<string>();
                names.Add(EntityConstants.InvincibleName);
                names.Add(EntityConstants.HealthName);
                names.Add(EntityConstants.SpeedName);
                names.Add(EntityConstants.JumpName);
                return names;
            }
        }

        /// <summary>
        /// Gets the list of obstacle names.
        /// </summary>
        public static List<string> ObstacleNames
        {
            get
            {
                List<string> names = new List<string>();
                names.Add(EntityConstants.RockName);
                names.Add(EntityConstants.SpikeName);
                names.Add(EntityConstants.FireName);
                return names;
            }
        }

        /// <summary>
        /// Gets the list of bonus names.
        /// </summary>
        public static List<string> BonusNames
        {
            get
            {
                List<string> names = new List<string>();
                names.Add(EntityConstants.CoinName);
                names.Add(EntityConstants.RubyName);
                names.Add(EntityConstants.DiamondName);
                return names;
            }
        }
    }
}