using System;
using System.Drawing;
using System.Reflection;
using devDept.Geometry;

namespace buEyeBaseVer5;

[Serializable]
public class CopyEventFormVars : buSerilization5
{
	public ContentAlignment Alignment = ContentAlignment.BottomLeft;

	public Point3D CatchPoint = new Point3D();

	public bool ShowZ = true;

	public bool ShowAligment = true;

	public bool isCoordinateMode = true;

	public CopyEventFormVars()
	{
	}

	public CopyEventFormVars(CopyEventFormVars data)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(data, ref CopiedClass);
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
}
