using System;
using System.Reflection;
using buClass;
using buEyeBaseVer5.buEntities;

namespace buEyeBaseVer5;

[Serializable]
public class DimensionGroup : buSerilization5
{
	public buEntity dimEntity = null;

	public ShapeDataValueType ShapeValueType = ShapeDataValueType.None;

	public planeNames PlaneType = planeNames.Top;

	public bool UsePlaneType = false;

	public DimensionGroup()
	{
		dimEntity = new buEntity();
	}

	public DimensionGroup(buEntity dimEnt, ShapeDataValueType ValueType)
	{
		buEntity.Copy(dimEnt, ref dimEntity);
		ShapeValueType = ValueType;
	}

	public DimensionGroup(DimensionGroup data)
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
		if (data.dimEntity != null)
		{
			buEntity.Copy(data.dimEntity, ref dimEntity);
		}
	}

	public override string ToString()
	{
		return ShapeValueType.ToString();
	}
}
