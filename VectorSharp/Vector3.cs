using System;
using System.Collections.Generic;
using System.Linq;

namespace VectorSharp
{
    /// <summary>
    /// Represents a vector or point in 3D Cartesian Space.
    /// </summary>
    public struct Vector3
    {
        /// <summary>
        /// Gets the x part or coordinate of the vector.
        /// </summary>
        public readonly double X;

        /// <summary>
        /// Gets the y part of coordinate of the vector.
        /// </summary>
        public readonly double Y;

        /// <summary>
        /// Gets the z part or coordinate of the vector.
        /// </summary>
        public readonly double Z;

        /// <summary>
        /// Gets this Vector expressed as a unit vector.
        /// </summary>
        public Vector3 AsUnitVector
        {
            get
            {
                var length = Length;

                return new Vector3(X / length, Y / length, Z / length);
            }
        }

        /// <summary>
        /// Gets the length of the Vector.
        /// </summary>
        public double Length
        {
            get { return Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2) + Math.Pow(Z, 2)); }
        }

        /// <summary>
        /// Creates a new instance of the <see cref="Vector3"/> struct with the given positions.
        /// </summary>
        /// <param name="x">The x part or coordinate of the vector.</param>
        /// <param name="y">The y part of coordinate of the vector.</param>
        /// <param name="z">The z part or coordinate of the vector.</param>
        public Vector3(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        #region CrossProduct

        /// <summary>
        /// Calculates the cross or vector product of this vector and the given one.
        /// </summary>
        /// <param name="other">The other vector.</param>
        /// <returns>The cross or vector product of the two vectors.</returns>
        public Vector3 CrossProduct(Vector3 other)
        {
            return new Vector3(
                x: (Y * other.Z) - (other.Y * Z),
                y: (other.X * Z) - (X * other.Z),
                z: (X * other.Y) - (other.X * Y));
        }

        /// <summary>
        /// Calculates the cross or vector product of this vector and the given one.
        /// </summary>
        /// <param name="other">The other vector.</param>
        /// <returns>The cross or vector product of the two vectors.</returns>
        public Vector3 VectorProduct(Vector3 other)
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
        public double DotProduct(Vector3 other)
        {
            return (X * other.X) + (Y * other.Y) + (Z * other.Z);
        }

        /// <summary>
        /// Gets the dot or scalar product of this vector and the given one.
        /// </summary>
        /// <param name="other">The other vector.</param>
        /// <returns>The dot or scalar product of the two vectors.</returns>
        public double ScalarProduct(Vector3 other)
        {
            return DotProduct(other);
        }

        #endregion DotProduct

        #region MathOperators

        public static Vector3 operator -(Vector3 left, Vector3 right)
        {
            return new Vector3(left.X - right.X, left.Y - right.Y, left.Z - right.Z);
        }

        public static Vector3 operator -(Vector3 subject)
        {
            return new Vector3(-subject.X, -subject.Y, -subject.Z);
        }

        public static Vector3 operator *(Vector3 left, double right)
        {
            return new Vector3(left.X * right, left.Y * right, left.Z * right);
        }

        public static Vector3 operator *(double left, Vector3 right)
        {
            return right * left;
        }

        public static Vector3 operator +(Vector3 left, Vector3 right)
        {
            return new Vector3(left.X + right.X, left.Y + right.Y, left.Z + right.Z);
        }

        #endregion MathOperators

        #region Equality

        public static bool operator !=(Vector3 left, Vector3 right)
        {
            return !(left == right);
        }

        public static bool operator ==(Vector3 left, Vector3 right)
        {
            return left.X.IsAlmostEqualTo(right.X) && left.Y.IsAlmostEqualTo(right.Y) && left.Z.IsAlmostEqualTo(right.Z);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Vector3))
                return false;

            return (Vector3)obj == this;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return X.GetHashCode() * 13 + Y.GetHashCode() * 13 + Z.GetHashCode();
            }
        }

        #endregion Equality

        public override string ToString()
        {
            return "Vector3: " + X + "/" + Y + "/" + Z;
        }
    }
}