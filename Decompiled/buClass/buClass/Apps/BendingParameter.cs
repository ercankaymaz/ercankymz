using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass.Apps;

[Serializable]
public class BendingParameter : buSerilization
{
	public string Name = "";

	public double PtValue = 2.0;

	public double OverrideUp = 100.0;

	public double OverrideDown = 100.0;

	public double Override18mmUp = 100.0;

	public double Override18mmDown = 100.0;

	public double Override15mmUp = 100.0;

	public double Override15mmDown = 100.0;

	public double Override12mmUp = 100.0;

	public double Override12mmDown = 100.0;

	public double BridgeOffset = 0.0;

	public double BendingXDistance = 0.0;

	public double DiskCircumfarance = 0.0;

	public double BroachBendingOVerride = 100.0;

	public List<BendingParameterItem> CornerItems = new List<BendingParameterItem>();

	public List<RadiusParameterItem> RadiusItems = new List<RadiusParameterItem>();

	public BendingParameter()
	{
	}

	public BendingParameter(BendingParameter data)
	{
		object CopiedClass = new object();
		buSerilization.CopyClass(data, ref CopiedClass);
		if (this != null && CopiedClass != null && GetType() == CopiedClass.GetType())
		{
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
		CornerItems.Clear();
		RadiusItems.Clear();
		for (int j = 0; j <= data.CornerItems.Count - 1; j++)
		{
			CornerItems.Add(new BendingParameterItem(data.CornerItems[j]));
		}
		for (int k = 0; k <= data.RadiusItems.Count - 1; k++)
		{
			RadiusItems.Add(new RadiusParameterItem(data.RadiusItems[k]));
		}
	}

	public override string ToString()
	{
		return Name.ToString() + " ; Pt : " + PtValue + " ; OverrideUp : " + OverrideUp + " ; OverrideDown : " + OverrideDown;
	}
}
