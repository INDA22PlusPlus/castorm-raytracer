// See https://aka.ms/new-console-template for more information
using Raytracer;
using System.Drawing;
using System.Linq;
using System.Text;

Console.WriteLine("Hello, World!");

Sphere sphere = new(new(1500, 200, 20), 100, Color.Red);
Plane plane = new(new(1, 10, 0), -10, Color.White, 0);
List<Raytracer.Object> objects = new() { sphere, plane };
PointLight light = new(new(300, 100, 100), 20000000, 2);

bool h = plane.Trace(new(new(0, 10, 0), new(10, 10, 0)), out var i1);
Console.WriteLine(h);
Console.WriteLine(i1?.Length);

const int Size = 1000;

File.WriteAllText("test.ppm", $"P3\n{Size} {Size}\n255\n");

StringBuilder sb = new(Size*Size*12);
for (int i = 0; i < Size; i++)
{
    for (int j = 0; j < Size; j++)
    {
        Ray ray = new(new(0, 10, 0), new(1000, i - Size / 2, j - Size / 2));
        bool h1 = sphere.Trace(ray, out var i3);
        if (h1 && i3 is not null)
        {
            var mod2 = light.GetModifier(i3.Length);
            string t2 = $"{(int)(sphere.Color.R * mod2)} {(int)(sphere.Color.G * mod2)} {(int)(sphere.Color.B * mod2)} ";
            sb.Append(t2);
            continue;
        }

        bool hit = plane.Trace(ray, out var inter);
        if (!hit || inter is null)
        {
            sb.Append("0 0 0 ");
            continue;
        }
        var tr = light.GetDirection(inter);
        if (sphere.Trace(new(inter, tr), out var i2))
        {
            sb.Append("0 0 0 ");
            continue;
        }

        var mod = light.GetModifier(tr.Length);
        string t = $"{(int)(plane.Color.R * mod)} {(int)(plane.Color.G * mod)} {(int)(plane.Color.B * mod)} ";
        sb.Append(t);
    }
    sb.Append('\n');
    if (i % (Size / 100) == 0)
        Console.WriteLine(i * 100 / Size + "% done");
}
//Console.WriteLine("Hello");
File.AppendAllText("test.ppm",sb.ToString());
Console.ReadKey();