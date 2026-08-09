using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass;

[Serializable]
public class GCodeGraphPoint : buSerilization
{
	public Pnt9D Positions = new Pnt9D();

	public double Radius = 0.0;

	public IJK IJKValues = new IJK();

	public int CodeType = 0;

	public GCodeGraphPoint()
	{
	}

	public GCodeGraphPoint(GCodeGraphPoint data)
	{
		object CopiedClass = new object();
		buSerilization.CopyClass(data, ref CopiedClass);
		if (this != null && CopiedClass != null && GetType() == CopiedClass.GetType())
		{
			FieldInfo[] fields = GetType().GetFields();
			if (fields != null)
			{
				for (int i = 0; i <= fields.Length - 1; i++)
				{
					string name = fields[i].Name;
					object value = fields[i].GetValue(CopiedClass);
					fields[i].SetValue(this, value);
				}
			}
		}
		IJKValues = new IJK(data.IJKValues);
	}

	public static GCodeGraphPoint Copy(GCodeGraphPoint P)
	{
		GCodeGraphPoint gCodeGraphPoint = new GCodeGraphPoint();
		gCodeGraphPoint.Positions = new Pnt9D(P.Positions);
		gCodeGraphPoint.CodeType = P.CodeType;
		gCodeGraphPoint.IJKValues = new IJK(P.IJKValues);
		gCodeGraphPoint.Radius = P.Radius;
		return gCodeGraphPoint;
	}

	public static void Copy(List<GCodeGraphPoint> pts, ref List<GCodeGraphPoint> CopiedPnt)
	{
		CopiedPnt.Clear();
		for (int i = 0; i < pts.Count; i++)
		{
			CopiedPnt.Add(new GCodeGraphPoint(Copy(pts[i])));
		}
	}

	public override string ToString()
	{
		return "X" + Positions.X.ToString("f3") + " , Y" + Positions.Y.ToString("f3") + " , Z" + Positions.Z.ToString("f3") + " , Type" + CodeType + " , R" + Radius.ToString("f3");
	}
}
