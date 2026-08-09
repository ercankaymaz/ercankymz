using System;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class Router3AXSettings : buSerilization5
{
	public bool ShowOperationInfo = false;

	public SizeObject SizeStock = new SizeObject(500.0, 500.0, 10.0);

	public string MultiGCodeSeparatorChar = "_";

	public MachineTableType TableType = MachineTableType.SingleTable;

	public bool DualTable = false;

	public bool M75Mode = false;

	public bool BuCenterCalculation = false;

	public bool AutoWaterClose = true;

	public bool Save3DDataWhileGCodeCreate = false;

	public bool SaveGCodeDataWhileGCodeCreate = false;

	public Router3AXSettings()
	{
	}

	public Router3AXSettings(Router3AXSettings data)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(data, ref CopiedClass);
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
}
