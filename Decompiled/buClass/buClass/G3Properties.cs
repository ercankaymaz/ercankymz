using System;
using System.Reflection;

namespace buClass;

[Serializable]
public class G3Properties : buSerilization
{
	public CodeUsing AuxCodeForFirstRisingG3 = new CodeUsing();

	public CodeUsing AuxCodeForAllG3 = new CodeUsing();

	public G3Properties()
	{
	}

	public G3Properties(G3Properties data)
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
		AuxCodeForFirstRisingG3 = new CodeUsing(data.AuxCodeForFirstRisingG3);
		AuxCodeForAllG3 = new CodeUsing(data.AuxCodeForAllG3);
	}
}
