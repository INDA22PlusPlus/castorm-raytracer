using System;
namespace Raytracer;

public class Vector3
{
    public double X { get; set; }
    public double Y { get; set; }
    public double Z { get; set; }
    public static Vector3 Zero => new(0, 0, 0);

    public Vector3(double x, double y, double z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public static Vector3 operator +(Vector3 a, Vector3 b)
    {
        return new Vector3(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
    }

    public static Vector3 operator -(Vector3 a, Vector3 b)
    {
        return new Vector3(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
    }

    public static Vector3 operator *(Vector3 a, double b)
    {
        return new Vector3(a.X * b, a.Y * b, a.Z * b);
    }

    public static Vector3 operator /(Vector3 a, double b)
    {
        return new Vector3(a.X / b, a.Y / b, a.Z / b);
    }

    public double Dot(Vector3 other) => X * other.X + Y * other.Y + Z * other.Z;

    public double Length => Math.Sqrt(X * X + Y * Y + Z * Z);

    public Vector3 Normalized =>  this / Length;

    public bool IsZero => Length == 0;

    public override string ToString()
    {
        return $"({X}, {Y}, {Z})";
    }

}

