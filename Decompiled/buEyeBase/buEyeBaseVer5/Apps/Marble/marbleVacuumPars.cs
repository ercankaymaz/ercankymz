using System;
using System.Collections.Generic;
using System.Reflection;

namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class marbleVacuumPars : buSerilization5
{
	public double VacuumOffset = 10.0;

	public double VacuumExtension = 10.0;

	public static List<string> Captions = new List<string>();

	public marbleVacuumPars()
	{
	}

	public marbleVacuumPars(marbleVacuumPars data)
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

	public static void Copy(marbleVacuumPars Source, ref marbleVacuumPars Target)
	{
		Target = new marbleVacuumPars(Source);
	}

	public override string ToString()
	{
		return "VacuumOffset : " + VacuumOffset + " , VacuumExtension : " + VacuumExtension;
	}
}
