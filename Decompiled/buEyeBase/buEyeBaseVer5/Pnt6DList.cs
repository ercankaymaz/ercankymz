using System;
using System.Collections.Generic;
using buClass;

namespace buEyeBaseVer5;

[Serializable]
public class Pnt6DList
{
	public List<Pnt6D> Points = new List<Pnt6D>();

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
