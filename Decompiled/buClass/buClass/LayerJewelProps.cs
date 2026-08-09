using System;
using System.Reflection;
using buClass.Apps;

namespace buClass;

[Serializable]
public class LayerJewelProps : buSerilization
{
	public double Depth = 0.0;

	public string ModeName = "";

	public JewelVar JewelMode = new JewelVar();

	public int ModeIndex = 0;

	public LayerJewelProps()
	{
	}

	public LayerJewelProps(LayerJewelProps data)
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
		JewelMode = new JewelVar(data.JewelMode);
	}

	public override string ToString()
	{
		return "Mode Name : " + JewelMode.ModeName + " -  Depth : " + Depth;
	}
}
