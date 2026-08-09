using System;
using System.Reflection;

namespace buClass;

[Serializable]
public class G1Properties : buSerilization
{
	public CodeUsing AuxCodeForFirstRisingG1 = new CodeUsing();

	public CodeUsing AuxCodeForAllG1 = new CodeUsing();

	public G1Properties()
	{
	}

	public G1Properties(G1Properties data)
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
		AuxCodeForFirstRisingG1 = new CodeUsing(data.AuxCodeForFirstRisingG1);
		AuxCodeForAllG1 = new CodeUsing(data.AuxCodeForAllG1);
	}
}
