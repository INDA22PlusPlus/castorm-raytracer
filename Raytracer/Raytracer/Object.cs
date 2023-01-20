using System;
using System.Drawing;

namespace Raytracer;

public abstract class Object
{
    public Color Color;
    public double Reflection;

    protected Object(Color color, double reflection)
    {
        Color = color;
        Reflection = reflection;
    }

    public abstract bool Trace(Ray ray, out Vector3? intersection);
}

