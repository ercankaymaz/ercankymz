using System;
using System.Reflection;
using SmartAssembly.Delegates;
using SmartAssembly.HouseOfCards;
using buClass;

namespace buMotion;

[Serializable]
public class TechnicianLoginInfo : buSerilization
{
	public string TechName = _001C(107383214);

	public string TechNick = _001C(107397519);

	public int TechID = 0;

	public int TechLevel = 0;

	public int TechPassword = 0;

	public TechnicianType TechType = TechnicianType.TechnicalService;

	[NonSerialized]
	internal static GetString _001C;

	public TechnicianLoginInfo()
	{
	}

	public TechnicianLoginInfo(TechnicianLoginInfo data)
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
		return TechName;
	}

	static TechnicianLoginInfo()
	{
		Strings.CreateGetStringDelegate(typeof(TechnicianLoginInfo));
	}
}
