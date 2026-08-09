using System;
using System.Reflection;
using devDept.Geometry;

namespace buEyeBaseVer5;

[Serializable]
public class CutterInfo : buSerilization5
{
	public Point3D notchPoint = new Point3D();

	public CutterInfo()
	{
	}

	public CutterInfo(CutterInfo data)
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
		notchPoint = new Point3D(data.notchPoint.X, data.notchPoint.Y, data.notchPoint.Z);
	}

	public override string ToString()
	{
		return "notchP: " + notchPoint.X.ToString("f3") + " , " + notchPoint.Y.ToString("f3");
	}
}
