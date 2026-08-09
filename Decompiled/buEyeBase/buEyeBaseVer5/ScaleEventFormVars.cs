using System;
using System.Drawing;
using System.Reflection;
using devDept.Geometry;

namespace buEyeBaseVer5;

[Serializable]
public class ScaleEventFormVars : buSerilization5
{
	public ContentAlignment Alignment = ContentAlignment.BottomLeft;

	public Point3D Ratio = new Point3D();

	public bool ShowAligment = true;

	public bool isLengthMode = true;

	public bool KeepRatio = false;

	public ScaleEventFormVars()
	{
	}

	public ScaleEventFormVars(ScaleEventFormVars data)
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
