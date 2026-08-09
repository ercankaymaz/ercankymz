using System;
using System.Reflection;
using System.Windows.Forms;

namespace buClass;

[Serializable]
public class MachineType : buSerilization
{
	public int ID = 1;

	public int ToolCount = 1;

	public string Name = "Machine";

	public string pathJob = Application.StartupPath;

	public MachineType()
	{
	}

	public MachineType(MachineType data)
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
