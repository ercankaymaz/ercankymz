using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;

namespace buClass;

[Serializable]
public class ShapeAllData : buSerilization
{
	public double RectangleWidth = 100.0;

	public double RectangleHeight = 100.0;

	public double RoundRectangleWidth = 100.0;

	public double RoundRectangleHeight = 100.0;

	public double RoundRectangleRadius = 10.0;

	public double CircleDiameter = 100.0;

	public double EllipseWidth = 200.0;

	public double EllipseHeight = 100.0;

	public double PolygonRadius = 100.0;

	public int PolygonSide = 6;

	public double TriangleWidth = 100.0;

	public double TriangleHeight = 100.0;

	public double TrapezLength1 = 100.0;

	public double TrapezLength2 = 200.0;

	public double TrapezHeight = 100.0;

	public double SlotWidth = 200.0;

	public double SlotHeight = 300.0;

	public double KeyHoleLength = 200.0;

	public double KeyHoleWidth = 20.0;

	public double KeyHoleDiameter = 80.0;

	public double ArcBigRadius = 100.0;

	public double ArcSmallRadius = 100.0;

	public double ArcSweepAngle = 90.0;

	public double Rotation = 0.0;

	public bool DiagonalCut = false;

	public double MoveX = 0.0;

	public double MoveY = 0.0;

	public double CopyX = 0.0;

	public double CopyY = 0.0;

	public double ScaleX = 0.0;

	public double ScaleY = 0.0;

	public double MirrorDistance = 0.0;

	public double RotateAngle = 0.0;

	public double LinearArrayXCount = 1.0;

	public double LinearArrayYCount = 1.0;

	public double LinearArrayXDistance = 0.0;

	public double LinearArrayYDistance = 0.0;

	public double CircularArrayCount = 1.0;

	public double CircularArrarAngle = 0.0;

	public MirrorAxisXYType MirrorAxis = MirrorAxisXYType.X;

	public ContentAlignment MirrorCenter = ContentAlignment.MiddleCenter;

	public static List<string> Captions = new List<string>();

	public ShapeAllData()
	{
	}

	public ShapeAllData(ShapeAllData data)
	{
		object CopiedClass = new object();
		buSerilization.CopyClass(data, ref CopiedClass);
		if (!(this != null && CopiedClass != null) || !(GetType() == CopiedClass.GetType()))
		{
			return;
		}
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

	public override string ToString()
	{
		return "RectangleWidth: " + RectangleWidth;
	}
}
