using System;
using System.Collections.Generic;

namespace buClass;

[Serializable]
public class PocketPoints : buSerilization
{
	public List<List<Pnt3D>> Pockets = new List<List<Pnt3D>>();

	public PocketPoints()
	{
	}

	public PocketPoints(PocketPoints PocketPointspoints)
	{
		for (int i = 0; i <= PocketPointspoints.Pockets.Count - 1; i++)
		{
			List<Pnt3D> list = new List<Pnt3D>();
			for (int j = 0; j <= PocketPointspoints.Pockets[i].Count - 1; j++)
			{
				list.Add(new Pnt3D(PocketPointspoints.Pockets[i][j]));
			}
			Pockets.Add(list);
		}
	}

	public PocketPoints(List<List<Pnt3D>> points)
	{
		for (int i = 0; i <= points.Count - 1; i++)
		{
			List<Pnt3D> list = new List<Pnt3D>();
			for (int j = 0; j <= points[i].Count - 1; j++)
			{
				list.Add(new Pnt3D(points[i][j]));
			}
			Pockets.Add(list);
		}
	}

	public override string ToString()
	{
		string text = "";
		return "Pockets: " + Pockets.Count;
	}
}
