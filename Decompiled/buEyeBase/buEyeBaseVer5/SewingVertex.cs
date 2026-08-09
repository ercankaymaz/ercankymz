using System;
using System.Collections.Generic;
using System.Reflection;
using devDept.Geometry;

namespace buEyeBaseVer5;

[Serializable]
public class SewingVertex : buSerilization5
{
	public List<SewingCode> Codes = new List<SewingCode>();

	public Point3D Point = new Point3D();

	public double DeltaX = 0.0;

	public double DeltaY = 0.0;

	public double FootHeight = 0.0;

	public double Speed = 0.0;

	public SewingPunteriz Punterez = null;

	public SewingVertex()
	{
	}

	public SewingVertex(Point3D Pnt)
	{
		Point = new Point3D(Pnt.X, Pnt.Y, Pnt.Z);
	}

	public SewingVertex(SewingVertex data)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(data, ref CopiedClass);
		if (!(this != null && CopiedClass != null))
		{
			return;
		}
		if (GetType() == CopiedClass.GetType())
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
		if (Punterez != null)
		{
			Punterez = new SewingPunteriz(data.Punterez);
		}
		Codes.Clear();
		Codes = new List<SewingCode>();
		for (int j = 0; j <= data.Codes.Count - 1; j++)
		{
			Codes.Add(new SewingCode(data.Codes[j]));
		}
		Point = new Point3D(data.Point.X, data.Point.Y, data.Point.Z);
	}

	public static void Copy(SewingVertex Data, ref SewingVertex Copied)
	{
		Copied = new SewingVertex(Data);
	}

	public static void Copy(List<SewingVertex> Data, ref List<SewingVertex> Copied)
	{
		Copied.Clear();
		Copied = new List<SewingVertex>();
		for (int i = 0; i <= Data.Count - 1; i++)
		{
			Copied.Add(new SewingVertex(Data[i]));
		}
	}

	public override string ToString()
	{
		return "X: " + Point.X.ToString("f3") + " , Y: " + Point.Y.ToString("f3") + " - dX: " + DeltaX.ToString("f2") + " - dY: " + DeltaY.ToString("f2") + "- Code: " + Codes.Count;
	}
}
