using System;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class SewingOffsetOptions : buSerilization5
{
	public OffsetCornerType CornerTyppe = OffsetCornerType.Line;

	public CamClosedContourType ClosedType = CamClosedContourType.Inner;

	public CamOpenContourType OpenType = CamOpenContourType.Left;

	public bool MakeSameStartOffsetYLevel = true;

	public bool MakeSameEndOffsetYLevel = true;

	public SewingOffsetOptions()
	{
	}

	public SewingOffsetOptions(SewingOffsetOptions data)
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
}
