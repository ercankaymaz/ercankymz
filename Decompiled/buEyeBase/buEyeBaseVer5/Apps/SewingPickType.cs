using System;
using System.Reflection;
using buClass;
using devDept.Geometry;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class SewingPickType : buSerilization5
{
	public int EntityIndex = -1;

	public int VertexIndex = -1;

	public SewingPickClickType PickType = SewingPickClickType.None;

	public SewingPickEntitySelectType EntitySelectType = SewingPickEntitySelectType.StartPoint;

	public Point3D refPoint = new Point3D();

	public SewingPickType()
	{
	}

	public SewingPickType(SewingPickType data)
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
		return "Ent: " + EntityIndex + " - Ver: " + VertexIndex + " - Pick Type: " + PickType;
	}
}
