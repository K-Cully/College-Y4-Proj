// <auto-generated />

using Microsoft.Xna.Framework;

namespace FarseerPhysics.SamplesFramework
{
    /// <summary>
    /// Helper for converting between display and simulation units.
    /// </summary>
    public static class ConvertUnits
    {
        /// <summary>
        /// The ratio of display units to simulation units.
        /// </summary>
        private static float _displayUnitsToSimUnitsRatio = 100f;

        /// <summary>
        /// The ratio of simulation units to display units.
        /// </summary>
        private static float _simUnitsToDisplayUnitsRatio = 1 / _displayUnitsToSimUnitsRatio;

        /// <summary>
        /// Sets the display unit to simulation unit ratio.
        /// </summary>
        /// <param name="displayUnitsPerSimUnit">The number of display unit to one simulation unit.</param>
        public static void SetDisplayUnitToSimUnitRatio(float displayUnitsPerSimUnit)
        {
            _displayUnitsToSimUnitsRatio = displayUnitsPerSimUnit;
            _simUnitsToDisplayUnitsRatio = 1 / displayUnitsPerSimUnit;
        }

        /// <summary>
        /// Converts from simulation units to display units.
        /// </summary>
        /// <param name="simUnits">The value in simulation units.</param>
        /// <returns>The value in display units.</returns>
        public static float ToDisplayUnits(float simUnits)
        {
            return simUnits * _displayUnitsToSimUnitsRatio;
        }

        /// <summary>
        /// Converts from simulation units to display units.
        /// </summary>
        /// <param name="simUnits">The value in simulation units.</param>
        /// <returns>The value in display units.</returns>
        public static float ToDisplayUnits(int simUnits)
        {
            return simUnits * _displayUnitsToSimUnitsRatio;
        }

        /// <summary>
        /// Converts from simulation units to display units.
        /// </summary>
        /// <param name="simUnits">The value in simulation units.</param>
        /// <returns>The value in display units.</returns>
        public static Vector2 ToDisplayUnits(Vector2 simUnits)
        {
            return simUnits * _displayUnitsToSimUnitsRatio;
        }

        /// <summary>
        /// Converts from simulation units to display units.
        /// </summary>
        /// <param name="simUnits">The value in simulation units.</param>
        /// <param name="displayUnits">Storage space for the value in display units.</param>
        public static void ToDisplayUnits(ref Vector2 simUnits, out Vector2 displayUnits)
        {
            Vector2.Multiply(ref simUnits, _displayUnitsToSimUnitsRatio, out displayUnits);
        }

        /// <summary>
        /// Converts from simulation units to display units.
        /// </summary>
        /// <param name="simUnits">The value in simulation units.</param>
        /// <returns>The value in display units.</returns>
        public static Vector3 ToDisplayUnits(Vector3 simUnits)
        {
            return simUnits * _displayUnitsToSimUnitsRatio;
        }

        /// <summary>
        /// Converts from simulation units to display units.
        /// </summary>
        /// <param name="x">The x value in simulation units.</param>
        /// <param name="y">The y value in simulation units.</param>
        /// <returns>The vactor value in display units.</returns>
        public static Vector2 ToDisplayUnits(float x, float y)
        {
            return new Vector2(x, y) * _displayUnitsToSimUnitsRatio;
        }

        /// <summary>
        /// Converts from simulation units to display units.
        /// </summary>
        /// <param name="x">The x value in simulation units.</param>
        /// <param name="y">The y value in simulation units.</param>
        /// <param name="displayUnits">The vector to store the dispaly units in.</param>
        public static void ToDisplayUnits(float x, float y, out Vector2 displayUnits)
        {
            displayUnits = Vector2.Zero;
            displayUnits.X = x * _displayUnitsToSimUnitsRatio;
            displayUnits.Y = y * _displayUnitsToSimUnitsRatio;
        }

        /// <summary>
        /// Converts from display units to simulation units.
        /// </summary>
        /// <param name="displayUnits">The value in display units.</param>
        /// <returns>The value in simulation units.</returns>
        public static float ToSimUnits(float displayUnits)
        {
            return displayUnits * _simUnitsToDisplayUnitsRatio;
        }

        /// <summary>
        /// Converts from display units to simulation units.
        /// </summary>
        /// <param name="displayUnits">The value in display units.</param>
        /// <returns>The value in simulation units.</returns>
        public static float ToSimUnits(double displayUnits)
        {
            return (float)displayUnits * _simUnitsToDisplayUnitsRatio;
        }

        /// <summary>
        /// Converts from display units to simulation units.
        /// </summary>
        /// <param name="displayUnits">The value in display units.</param>
        /// <returns>The value in simulation units.</returns>
        public static float ToSimUnits(int displayUnits)
        {
            return displayUnits * _simUnitsToDisplayUnitsRatio;
        }

        /// <summary>
        /// Converts from display units to simulation units.
        /// </summary>
        /// <param name="displayUnits">The value in display units.</param>
        /// <returns>The value in simulation units.</returns>
        public static Vector2 ToSimUnits(Vector2 displayUnits)
        {
            return displayUnits * _simUnitsToDisplayUnitsRatio;
        }

        /// <summary>
        /// Converts from display units to simulation units.
        /// </summary>
        /// <param name="displayUnits">The value in display units.</param>
        /// <returns>The value in simulation units.</returns>
        public static Vector3 ToSimUnits(Vector3 displayUnits)
        {
            return displayUnits * _simUnitsToDisplayUnitsRatio;
        }

        /// <summary>
        /// Converts from display units to simulation units.
        /// </summary>
        /// <param name="displayUnits">The value in display units.</param>
        /// <param name="simUnits">Storage space for the value in simulation units.</param>
        public static void ToSimUnits(ref Vector2 displayUnits, out Vector2 simUnits)
        {
            Vector2.Multiply(ref displayUnits, _simUnitsToDisplayUnitsRatio, out simUnits);
        }

        /// <summary>
        /// Converts from display units to simulation units.
        /// </summary>
        /// <param name="x">The x value in display units.</param>
        /// <param name="y">The y value in display units.</param>
        /// <returns>The value in simulation units as a vector.</returns>
        public static Vector2 ToSimUnits(float x, float y)
        {
            return new Vector2(x, y) * _simUnitsToDisplayUnitsRatio;
        }

        /// <summary>
        /// Converts from display units to simulation units.
        /// </summary>
        /// <param name="x">The x value in display units.</param>
        /// <param name="y">The y value in display units.</param>
        /// <returns>The value in simulation units.</returns>
        public static Vector2 ToSimUnits(double x, double y)
        {
            return new Vector2((float)x, (float)y) * _simUnitsToDisplayUnitsRatio;
        }

        /// <summary>
        /// Converts from display units to simulation units.
        /// </summary>
        /// <param name="x">The x value in display units.</param>
        /// <param name="y">The y value in display units.</param>
        /// <param name="simUnits">Storage space for the value in simulation units.</param>
        public static void ToSimUnits(float x, float y, out Vector2 simUnits)
        {
            simUnits = Vector2.Zero;
            simUnits.X = x * _simUnitsToDisplayUnitsRatio;
            simUnits.Y = y * _simUnitsToDisplayUnitsRatio;
        }
    }
}