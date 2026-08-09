using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass;

[Serializable]
public class LaserMaterialData : buSerilization
{
	public bool Enable = true;

	public double CuttingG2G3Velocity = 0.0;

	public double Acceleration = 1000.0;

	public double Jerk = 0.0;

	public double Height = 18.0;

	public double CuttingPower = 400.0;

	public double PowerStopTime = 100.0;

	public double PowerDelayTime = 150.0;

	public double StartPower = 100.0;

	public double EndPower = 100.0;

	public double FeedXPlus = 1.0;

	public double FeedXMinus = 1.0;

	public double FeedYPlus = 1.0;

	public double FeedYMinus = 1.0;

	public double FeedXY = 0.0;

	public double PowerXPlus = 1.0;

	public double PowerXMinus = 1.0;

	public double PowerYPlus = 1.0;

	public double PowerYMinus = 1.0;

	public double FocusXPlus = 1.0;

	public double FocusXMinus = 1.0;

	public double FocusYPlus = 1.0;

	public double FocusYMinus = 1.0;

	public double FocusXY = 0.0;

	public string DefineationName = "";

	public LaserMaterialType Type = LaserMaterialType.Text;

	public double PtRealValue = 0.0;

	public DiemakerType CodeType = DiemakerType.None;

	public bool ApplyAll = true;

	public LaserSelection LaserSelect = LaserSelection.Laser1;

	public LaserMaterialData()
	{
	}

	public LaserMaterialData(LaserMaterialData data)
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

	public static void Copy(LaserMaterialData Base, ref LaserMaterialData Copied)
	{
		Copied = new LaserMaterialData(Base);
	}

	public static void Copy(List<LaserMaterialData> Base, ref List<LaserMaterialData> Copied)
	{
		Copied.Clear();
		Copied = new List<LaserMaterialData>();
		for (int i = 0; i <= Base.Count - 1; i++)
		{
			Copied.Add(new LaserMaterialData(Base[i]));
		}
	}

	public override string ToString()
	{
		return DefineationName + " , Type: " + Type;
	}
}
