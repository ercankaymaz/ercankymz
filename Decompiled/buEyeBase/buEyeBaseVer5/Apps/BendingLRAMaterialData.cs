using System;
using System.Collections.Generic;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class BendingLRAMaterialData : buSerilization
{
	public bool Enable = true;

	public double Length = 0.0;

	public double Rotation = 0.0;

	public double Angle = 0.0;

	public double Radius = 0.0;

	public BendingLRAMaterialData()
	{
	}

	public BendingLRAMaterialData(BendingLRAMaterialData data)
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

	public static void Copy(BendingLRAMaterialData Base, ref BendingLRAMaterialData Copied)
	{
		Copied = new BendingLRAMaterialData(Base);
	}

	public static void Copy(List<BendingLRAMaterialData> Base, ref List<BendingLRAMaterialData> Copied)
	{
		Copied.Clear();
		Copied = new List<BendingLRAMaterialData>();
		for (int i = 0; i <= Base.Count - 1; i++)
		{
			Copied.Add(new BendingLRAMaterialData(Base[i]));
		}
	}

	public override string ToString()
	{
		return "L: " + Length + " - R: " + Rotation + " - A: " + Angle + " - Cr: " + Radius;
	}
}
