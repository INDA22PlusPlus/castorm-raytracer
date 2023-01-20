using System;
using System.Drawing;

namespace Raytracer;

public class Sphere : Object
{
    public Vector3 Center { get; set; }
    public double Radius { get; set; }

    public Sphere(Vector3 center, double radius, Color color, double reflection = 0) : base(color, reflection)
    {
        Center = center;
        Radius = radius;
        Color = color;
    }

    public override bool Trace(Ray ray, out Vector3? intersection)
    {
        intersection = null;
        var v = ray.Origin - Center;
        var a = ray.Direction.Dot(ray.Direction);
        var b = 2 * v.Dot(ray.Direction);
        var c = v.Dot(v) - Radius * Radius;

        var hit = b * b - 4 * a * c;
        if (hit < 0) return false;
        var t = (-b + Math.Sqrt(b * b - 4 * a * c)) / (2 * a);

        intersection = ray.Origin + ray.Direction * t;
        return true;

    }
}

