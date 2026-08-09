using System;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class FoamActiveBlock : buSerilization5
{
	public FoamPlaneType Plane = FoamPlaneType.XZ;

	public int BlockIndex = 0;

	public int PatternIndex = 0;

	public FoamActiveBlock()
	{
	}

	public FoamActiveBlock(FoamActiveBlock data)
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

	public override string ToString()
	{
		return Plane.ToString() + " - BlockIndex: " + BlockIndex;
	}
}
