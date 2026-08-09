using System;
using System.Reflection;
using buClass;
using devDept.Geometry;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class SewingSelectedPoint : buSerilization5
{
	public Point3D refPoint = new Point3D();

	public int VertexIndex = -1;

	public int EntityIndex = -1;

	public StartMiddleEndType CatchPosition = StartMiddleEndType.Start;

	public bool isStitch = false;

	public SewingSelectedPoint()
	{
	}

	public SewingSelectedPoint(SewingSelectedPoint data)
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
				_ = fields[i].Name;
				object value = fields[i].GetValue(CopiedClass);
				fields[i].SetValue(this, value);
			}
		}
	}

	public override string ToString()
	{
		return CatchPosition.ToString() + " - Ent Index: " + EntityIndex + " - PointIndex: " + VertexIndex + " - X: " + refPoint.X + " - Y: " + refPoint.Y;
	}
}
