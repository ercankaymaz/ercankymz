using System;
using System.Collections.Generic;
using devDept.Geometry;

namespace buEyeBaseVer5;

[Serializable]
public class Point3DList
{
	public List<Point3D> Points = new List<Point3D>();

	public object Settings = null;

	public override string ToString()
	{
		string text = Points.Count.ToString();
		if (Points.Count > 0)
		{
			text = text + " - S: " + Points[0].ToString() + " - E: " + Points[Points.Count - 1].ToString();
		}
		return text;
	}
}
