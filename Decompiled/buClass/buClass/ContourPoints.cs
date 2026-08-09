using System;
using System.Collections.Generic;

namespace buClass;

[Serializable]
public class ContourPoints : buSerilization
{
	public List<Pnt3D> Outter = new List<Pnt3D>();

	public List<List<Pnt3D>> Holes = new List<List<Pnt3D>>();

	public ContourPoints()
	{
	}

	public ContourPoints(ContourPoints contourpoints)
	{
		for (int i = 0; i <= contourpoints.Outter.Count - 1; i++)
		{
			Outter.Add(new Pnt3D(contourpoints.Outter[i]));
		}
		for (int j = 0; j <= contourpoints.Holes.Count - 1; j++)
		{
			List<Pnt3D> list = new List<Pnt3D>();
			for (int k = 0; k <= contourpoints.Holes[j].Count - 1; k++)
			{
				list.Add(new Pnt3D(contourpoints.Holes[j][k]));
			}
			Holes.Add(list);
		}
	}

	public ContourPoints(TriangulationPoints tiranglepoints)
	{
		for (int i = 0; i <= tiranglepoints.Points.Count - 1; i++)
		{
			Outter.Add(new Pnt3D(tiranglepoints.Points[i]));
		}
		for (int j = 0; j <= tiranglepoints.Holes.Count - 1; j++)
		{
			List<Pnt3D> list = new List<Pnt3D>();
			for (int k = 0; k <= tiranglepoints.Holes[j].Count - 1; k++)
			{
				list.Add(new Pnt3D(tiranglepoints.Holes[j][k]));
			}
			Holes.Add(list);
		}
	}

	public ContourPoints(List<Pnt3D> outter, List<List<Pnt3D>> holes)
	{
		for (int i = 0; i <= outter.Count - 1; i++)
		{
			Outter.Add(new Pnt3D(outter[i]));
		}
		for (int j = 0; j <= holes.Count - 1; j++)
		{
			List<Pnt3D> list = new List<Pnt3D>();
			for (int k = 0; k <= holes[j].Count - 1; k++)
			{
				list.Add(new Pnt3D(holes[j][k]));
			}
			Holes.Add(list);
		}
	}

	public ContourPoints(List<Pnt3D> outter)
	{
		for (int i = 0; i <= outter.Count - 1; i++)
		{
			Outter.Add(new Pnt3D(outter[i]));
		}
		Holes = new List<List<Pnt3D>>();
	}

	public override string ToString()
	{
		string text = "";
		return "Out Count: " + Outter.Count + " - Hole Count: " + Holes.Count;
	}
}
