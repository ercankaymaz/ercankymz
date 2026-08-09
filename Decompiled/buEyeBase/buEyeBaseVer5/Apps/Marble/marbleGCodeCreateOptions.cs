using System;
using System.Collections.Generic;
using System.Reflection;

namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class marbleGCodeCreateOptions : buSerilization5
{
	public bool AddM3M4WhilePlunge = true;

	public bool AddM8WhilePlunge = true;

	public static List<string> Captions = new List<string>();

	public marbleGCodeCreateOptions()
	{
	}

	public marbleGCodeCreateOptions(marbleGCodeCreateOptions data)
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

	public static void Copy(marbleGCodeCreateOptions Source, ref marbleGCodeCreateOptions Target)
	{
		Target = new marbleGCodeCreateOptions(Source);
	}

	public override string ToString()
	{
		return "AddM3M4WhilePlunge : " + AddM3M4WhilePlunge;
	}
}
