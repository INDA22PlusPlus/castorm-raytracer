using System;
using System.Drawing;

namespace Raytracer;

public class Plane : Object
{
    public Vector3 Normal;
    public double Distance;
	public Plane(Vector3 normal, double distance, Color color, double reflection) : base(color, reflection)
	{
        Normal = normal;
        Distance = distance;
	}

    public override bool Trace(Ray ray, out Vector3? intersection)
    {
        intersection = null;
        var hit = Normal.Dot(ray.Direction);
        if (hit <= 0) return false;

        var t = (Distance - ray.Origin.Dot(Normal)) / hit;

        intersection = ray.Origin + ray.Direction * t;
        return true;
    }
}

