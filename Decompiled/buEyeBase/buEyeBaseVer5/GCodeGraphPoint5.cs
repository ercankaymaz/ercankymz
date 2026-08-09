using System;
using System.Collections.Generic;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5;

[Serializable]
public class GCodeGraphPoint5 : buSerilization5
{
	public Pnt9D Positions = new Pnt9D();

	public double Radius = 0.0;

	public IJK IJKValues = new IJK();

	public int CodeType = 0;

	public GCodeGraphPoint5()
	{
	}

	public GCodeGraphPoint5(GCodeGraphPoint5 data)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(data, ref CopiedClass);
		if (this != null && CopiedClass != null && GetType() == CopiedClass.GetType())
		{
			FieldInfo[] fields = GetType().GetFields();
			if (fields != null)
			{
				for (int i = 0; i <= fields.Length - 1; i++)
				{
					_ = fields[i].Name;
					object value = fields[i].GetValue(CopiedClass);
					fields[i].SetValue(this, value);
				}
			}
		}
		IJKValues = new IJK(data.IJKValues);
	}

	public static GCodeGraphPoint5 Copy(GCodeGraphPoint5 P)
	{
		GCodeGraphPoint5 gCodeGraphPoint = new GCodeGraphPoint5();
		gCodeGraphPoint.Positions = new Pnt9D(P.Positions);
		gCodeGraphPoint.CodeType = P.CodeType;
		gCodeGraphPoint.IJKValues = new IJK(P.IJKValues);
		gCodeGraphPoint.Radius = P.Radius;
		return gCodeGraphPoint;
	}

	public static void Copy(List<GCodeGraphPoint5> pts, ref List<GCodeGraphPoint5> CopiedPnt)
	{
		CopiedPnt.Clear();
		for (int i = 0; i < pts.Count; i++)
		{
			CopiedPnt.Add(new GCodeGraphPoint5(Copy(pts[i])));
		}
	}

	public override string ToString()
	{
		return "X" + Positions.X.ToString("f3") + " , Y" + Positions.Y.ToString("f3") + " , Z" + Positions.Z.ToString("f3") + " , Type" + CodeType + " , R" + Radius.ToString("f3");
	}
}
