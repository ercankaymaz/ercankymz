using System;
using System.Reflection;

namespace buClass;

[Serializable]
public class G1G2G3Properties : buSerilization
{
	public CodeUsing AuxCodeForFirstRisingG1G2G3 = new CodeUsing();

	public CodeUsing AuxCodeForAllG1G2G3 = new CodeUsing();

	public G1G2G3Properties()
	{
	}

	public G1G2G3Properties(G1G2G3Properties data)
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
		AuxCodeForFirstRisingG1G2G3 = new CodeUsing(data.AuxCodeForFirstRisingG1G2G3);
		AuxCodeForAllG1G2G3 = new CodeUsing(data.AuxCodeForAllG1G2G3);
	}
}
