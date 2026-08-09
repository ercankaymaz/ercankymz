using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass.Apps;

[Serializable]
public class TuftingPartOfsett : buSerilization
{
	public double Distance = 4.0;

	public camPathDirectionType Direction = camPathDirectionType.Normal;

	public bool ConnectTipPoint = true;

	public static List<string> Captions = new List<string>();

	public TuftingPartOfsett()
	{
	}

	public TuftingPartOfsett(TuftingPartOfsett data)
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
