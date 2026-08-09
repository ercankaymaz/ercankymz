using System;
using System.Reflection;

namespace buClass;

[Serializable]
public class ModBusVariables : buSerilization
{
	public ushort Address = 0;

	public byte Unit = 1;

	public string Name = "";

	public ModBusVariables()
	{
	}

	public ModBusVariables(ModBusVariables data)
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

	public override string ToString()
	{
		return Address + " ; " + Unit + " ; " + Name;
	}
}
