using System;
using System.Collections.Generic;
using devDept.Geometry;

namespace buEyeBaseVer5;

[Serializable]
public class PointsList : buSerilization5
{
	public List<List<Point3D>> Points = new List<List<Point3D>>();

	public PointsList()
	{
	}

	public PointsList(PointsList contourpoints)
	{
		for (int i = 0; i <= contourpoints.Points.Count - 1; i++)
		{
			List<Point3D> list = new List<Point3D>();
			for (int j = 0; j <= contourpoints.Points[i].Count - 1; j++)
			{
				list.Add(new Point3D(contourpoints.Points[i][j].X, contourpoints.Points[i][j].Y, contourpoints.Points[i][j].Z));
			}
			Points.Add(list);
		}
	}

	public override string ToString()
	{
		string text = "";
		return "Points Count: " + Points.Count;
	}
}
