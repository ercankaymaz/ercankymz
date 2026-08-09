using System;
using System.Reflection;
using SmartAssembly.Delegates;
using SmartAssembly.HouseOfCards;
using buClass;
using buEyeBaseVer5;
using buMotion;

namespace buMarble;

[Serializable]
public class clsAppMarbleMachineReportItem : buSerilization5
{
	public string ItemName = _001C(107397344);

	public TechnicianLoginInfo TechnicianInfo = new TechnicianLoginInfo();

	public DateTime ItemDate = DateTime.Now;

	public bool Status = false;

	[NonSerialized]
	internal static GetString _001C;

	public clsAppMarbleMachineReportItem()
	{
	}

	public clsAppMarbleMachineReportItem(string itemname)
	{
	}

	public clsAppMarbleMachineReportItem(clsAppMarbleMachineReportItem data)
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

	static clsAppMarbleMachineReportItem()
	{
		Strings.CreateGetStringDelegate(typeof(clsAppMarbleMachineReportItem));
	}
}
