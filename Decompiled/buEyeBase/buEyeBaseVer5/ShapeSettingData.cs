using System;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5;

[Serializable]
public class ShapeSettingData : buSerilization5
{
	public LeftRightType LeftRigthViewType = LeftRightType.Right;

	public ShapeSettingData()
	{
	}

	public ShapeSettingData(ShapeSettingData data)
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
		return "LeftRight :" + LeftRigthViewType;
	}
}
