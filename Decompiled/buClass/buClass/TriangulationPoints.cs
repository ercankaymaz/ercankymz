using System;
using System.Collections.Generic;

namespace buClass;

[Serializable]
public class TriangulationPoints : buSerilization
{
	public List<Pnt3D> Points = new List<Pnt3D>();

	public List<Triangle3D> Triangles = new List<Triangle3D>();

	public List<List<Pnt3D>> Holes = new List<List<Pnt3D>>();

	public TriangulationPoints()
	{
	}

	public TriangulationPoints(TriangulationPoints triangulationpoints)
	{
		triangulationpoints.Points = new List<Pnt3D>();
		for (int i = 0; i <= triangulationpoints.Points.Count - 1; i++)
		{
			Points.Add(new Pnt3D(triangulationpoints.Points[i]));
		}
		triangulationpoints.Holes = new List<List<Pnt3D>>();
		for (int j = 0; j <= triangulationpoints.Holes.Count - 1; j++)
		{
			List<Pnt3D> list = new List<Pnt3D>();
			for (int k = 0; k <= triangulationpoints.Holes[j].Count - 1; k++)
			{
				list.Add(new Pnt3D(triangulationpoints.Holes[j][k]));
			}
			Holes.Add(list);
		}
		triangulationpoints.Triangles = new List<Triangle3D>();
		for (int l = 0; l <= triangulationpoints.Triangles.Count - 1; l++)
		{
			Triangles.Add(new Triangle3D(triangulationpoints.Triangles[l]));
		}
	}
}
