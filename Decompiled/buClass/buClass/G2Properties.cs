using System;
using System.Reflection;

namespace buClass;

[Serializable]
public class G2Properties : buSerilization
{
	public CodeUsing AuxCodeForFirstRisingG2 = new CodeUsing();

	public CodeUsing AuxCodeForAllG2 = new CodeUsing();

	public G2Properties()
	{
	}

	public G2Properties(G2Properties data)
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
		AuxCodeForFirstRisingG2 = new CodeUsing(data.AuxCodeForFirstRisingG2);
		AuxCodeForAllG2 = new CodeUsing(data.AuxCodeForAllG2);
	}
}
