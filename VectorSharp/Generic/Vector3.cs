using System;
using System.Collections.Generic;
using System.Linq;

namespace VectorSharp.Generic
{
    public static class Vector3
    {
        private static readonly Dictionary<Type, Func<object, object, object, object>> specificTypes = new Dictionary<Type, Func<object, object, object, object>>();

        /// <summary>
        /// Creates a new instance of the <see cref="Vector3&lt;TCoordinate&gt;"/> class with the given positions.
        /// </summary>
        /// <param name="x">The x part or coordinate of the vector.</param>
        /// <param name="y">The y part of coordinate of the vector.</param>
        /// <param name="z">The z part or coordinate of the vector.</param>
        public static Vector3<TCoordinate> Create<TCoordinate>(TCoordinate x, TCoordinate y, TCoordinate z)
        {
            var coordinateType = typeof(TCoordinate);

            if (!specificTypes.ContainsKey(coordinateType))
                throw new ArgumentException("TCoordinate", "Coordinate type not currently supported.");

            return (Vector3<TCoordinate>)specificTypes[coordinateType](x, y, z);
        }

        internal static void AddSpecificType<TSpecificVector3, TCoordinate>() where TSpecificVector3 : Vector3<TCoordinate>
        {
            var specificType = typeof(TSpecificVector3);
            specificTypes.Add(typeof(TCoordinate), (x, y, z) => Activator.CreateInstance(specificType, x, y, z));
        }
    }

    /// <summary>
    /// Represents a vector or point in 3D Cartesian Space with a generic coordinate type.
    /// </summary>
    /// <typeparam name="TCoordinate">The type of the coordinates.</typeparam>
    public abstract class Vector3<TCoordinate>
    {
        private readonly TCoordinate x;
        private readonly TCoordinate y;
        private readonly TCoordinate z;

        /// <summary>
        /// Gets the x part or coordinate of the vector.
        /// </summary>
        public TCoordinate X
        {
            get { return x; }
        }

        /// <summary>
        /// Gets the y part of coordinate of the vector.
        /// </summary>
        public TCoordinate Y
        {
            get { return y; }
        }

        /// <summary>
        /// Gets the z part or coordinate of the vector.
        /// </summary>
        public TCoordinate Z
        {
            get { return z; }
        }

        protected Vector3(TCoordinate x, TCoordinate y, TCoordinate z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        #region MathOperations

        #region CrossProduct

        /// <summary>
        /// Calculates the cross or vector product of this vector and the given one.
        /// </summary>
        /// <param name="other">The other vector.</param>
        /// <returns>The cross or vector product of the two vectors.</returns>
        public abstract Vector3<TCoordinate> CrossProduct(Vector3<TCoordinate> other);

        /// <summary>
        /// Calculates the cross or vector product of this vector and the given one.
        /// </summary>
        /// <param name="other">The other vector.</param>
        /// <returns>The cross or vector product of the two vectors.</returns>
        public Vector3<TCoordinate> VectorProduct(Vector3<TCoordinate> other)
        {
            return CrossProduct(other);
        }

        #endregion CrossProduct

        #region DotProduct

        /// <summary>
        /// Gets the dot or scalar product of this vector and the given one.
        /// </summary>
        /// <param name="other">The other vector.</param>
        /// <returns>The dot or scalar product of the two vectors.</returns>
        public abstract TCoordinate DotProduct(Vector3<TCoordinate> other);

        /// <summary>
        /// Gets the dot or scalar product of this vector and the given one.
        /// </summary>
        /// <param name="other">The other vector.</param>
        /// <returns>The dot or scalar product of the two vectors.</returns>
        public TCoordinate ScalarProduct(Vector3<TCoordinate> other)
        {
            return DotProduct(other);
        }

        #endregion DotProduct

        public static Vector3<TCoordinate> operator -(Vector3<TCoordinate> left, Vector3<TCoordinate> right)
        {
            return left.Subtract(right);
        }

        public static Vector3<TCoordinate> operator -(Vector3<TCoordinate> subject)
        {
            return subject.Invert();
        }

        public static Vector3<TCoordinate> operator *(Vector3<TCoordinate> left, TCoordinate right)
        {
            return left.Multiply(right);
        }

        public static Vector3<TCoordinate> operator *(TCoordinate left, Vector3<TCoordinate> right)
        {
            return right.Multiply(left);
        }

        public static Vector3<TCoordinate> operator +(Vector3<TCoordinate> left, Vector3<TCoordinate> right)
        {
            return left.Add(right);
        }

        protected abstract Vector3<TCoordinate> Add(Vector3<TCoordinate> other);

        protected abstract Vector3<TCoordinate> Invert();

        protected abstract Vector3<TCoordinate> Multiply(Vector3<TCoordinate> other);

        protected abstract Vector3<TCoordinate> Multiply(TCoordinate other);

        protected abstract Vector3<TCoordinate> Subtract(Vector3<TCoordinate> right);

        #endregion MathOperations

        public override string ToString()
        {
            return "Vector3: " + X + "/" + Y + "/" + Z;
        }
    }
}