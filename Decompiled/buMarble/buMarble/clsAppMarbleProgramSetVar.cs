using System;
using System.Reflection;
using buClass;
using buEyeBaseVer5;

namespace buMarble;

[Serializable]
public class clsAppMarbleProgramSetVar : buSerilization5
{
	public clsAppMarbleProgramSetVar()
	{
	}

	public clsAppMarbleProgramSetVar(clsAppMarbleProgramSetVar data)
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
