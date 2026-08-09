using System;
using System.Collections.Generic;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class BendingLRAMaterial : buSerilization
{
	public string Name = "Mat";

	public List<BendingLRAMaterialData> Orders = new List<BendingLRAMaterialData>();

	public BendingLRAMaterial()
	{
	}

	public BendingLRAMaterial(BendingLRAMaterial data)
	{
		object CopiedClass = new object();
		buSerilization.CopyClass(data, ref CopiedClass);
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
		Orders = new List<BendingLRAMaterialData>();
		for (int j = 0; j <= data.Orders.Count - 1; j++)
		{
			Orders.Add(new BendingLRAMaterialData(data.Orders[j]));
		}
	}

	public static void Copy(BendingLRAMaterial Base, ref BendingLRAMaterial Copied)
	{
		Copied = new BendingLRAMaterial(Base);
	}

	public static void Copy(List<BendingLRAMaterial> Base, ref List<BendingLRAMaterial> Copied)
	{
		Copied.Clear();
		Copied = new List<BendingLRAMaterial>();
		for (int i = 0; i <= Base.Count - 1; i++)
		{
			Copied.Add(new BendingLRAMaterial(Base[i]));
		}
	}

	public override string ToString()
	{
		return "Name: " + Name.ToString();
	}
}
