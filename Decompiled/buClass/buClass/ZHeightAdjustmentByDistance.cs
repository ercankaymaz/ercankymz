using System;
using System.Reflection;

namespace buClass;

[Serializable]
public class ZHeightAdjustmentByDistance : buSerilization
{
	public double ZHeightValue = 0.0;

	public double LevelCenter = 0.0;

	public double LevelMin = 0.0;

	public double LevelMax = 0.0;

	public VectorXYType Direction = VectorXYType.YVector;

	public ZHeightProfileType ZType = ZHeightProfileType.Linear;

	public ZHeightAdjustmentByDistance()
	{
	}

	public ZHeightAdjustmentByDistance(ZHeightAdjustmentByDistance data)
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
}
