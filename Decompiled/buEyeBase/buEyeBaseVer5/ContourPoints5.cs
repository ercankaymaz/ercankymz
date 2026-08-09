using System;
using System.Collections.Generic;
using devDept.Geometry;

namespace buEyeBaseVer5;

[Serializable]
public class ContourPoints5 : buSerilization5
{
	public List<Point3D> Outter = new List<Point3D>();

	public List<List<Point3D>> Inside = new List<List<Point3D>>();

	public ContourPoints5()
	{
	}

	public ContourPoints5(ContourPoints5 contourpoints)
	{
		for (int i = 0; i <= contourpoints.Outter.Count - 1; i++)
		{
			Outter.Add(new Point3D(contourpoints.Outter[i].X, contourpoints.Outter[i].Y, contourpoints.Outter[i].Z));
		}
		for (int j = 0; j <= contourpoints.Inside.Count - 1; j++)
		{
			List<Point3D> list = new List<Point3D>();
			for (int k = 0; k <= contourpoints.Inside[j].Count - 1; k++)
			{
				list.Add(new Point3D(contourpoints.Inside[j][k].X, contourpoints.Inside[j][k].Y, contourpoints.Inside[j][k].Z));
			}
			Inside.Add(list);
		}
	}

	public ContourPoints5(List<Point3D> outter, List<List<Point3D>> inside)
	{
		for (int i = 0; i <= outter.Count - 1; i++)
		{
			Outter.Add(new Point3D(outter[i].X, outter[i].Y, outter[i].Z));
		}
		for (int j = 0; j <= inside.Count - 1; j++)
		{
			List<Point3D> list = new List<Point3D>();
			for (int k = 0; k <= inside[j].Count - 1; k++)
			{
				list.Add(new Point3D(inside[j][k].X, inside[j][k].Y, inside[j][k].Z));
			}
			Inside.Add(list);
		}
	}

	public ContourPoints5(List<Point3D> outter)
	{
		for (int i = 0; i <= outter.Count - 1; i++)
		{
			Outter.Add(new Point3D(outter[i].X, outter[i].Y, outter[i].Z));
		}
		Inside = new List<List<Point3D>>();
	}

	public override string ToString()
	{
		string text = "";
		return "Out Count: " + Outter.Count + " - Inside Count: " + Inside.Count;
	}
}
