using System;
using System.Drawing;
namespace Raytracer;

public class PointLight
{
	public Vector3 Center;
	public double Luminosity = 1000;
	public double Falloff = 1;

	public PointLight(Vector3 center, double lux = 1000, double falloff = 1)
	{
        Center = center;
		Luminosity = lux;
		Falloff = falloff;
	}

	public double GetModifier(double distance) => Math.Max(1 - (Falloff / Luminosity * (distance * distance)), 0);

	public Vector3 GetDirection(Vector3 point) => Center - point;
}

