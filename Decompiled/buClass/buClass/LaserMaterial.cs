using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass;

[Serializable]
public class LaserMaterial : buSerilization
{
	public string Name = "Mat";

	public List<LaserMaterialData> Orders = new List<LaserMaterialData>();

	public LaserMaterial()
	{
	}

	public LaserMaterial(LaserMaterial data)
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
					string name = fields[i].Name;
					object value = fields[i].GetValue(CopiedClass);
					fields[i].SetValue(this, value);
				}
			}
		}
		Orders = new List<LaserMaterialData>();
		for (int j = 0; j <= data.Orders.Count - 1; j++)
		{
			Orders.Add(new LaserMaterialData(data.Orders[j]));
		}
	}

	public static void Copy(LaserMaterial Base, ref LaserMaterial Copied)
	{
		Copied = new LaserMaterial(Base);
	}

	public static void Copy(List<LaserMaterial> Base, ref List<LaserMaterial> Copied)
	{
		Copied.Clear();
		Copied = new List<LaserMaterial>();
		for (int i = 0; i <= Base.Count - 1; i++)
		{
			Copied.Add(new LaserMaterial(Base[i]));
		}
	}

	public override string ToString()
	{
		return "Name: " + Name.ToString();
	}
}
