using System;
using System.Reflection;

namespace buClass;

[Serializable]
public class G0Properties : buSerilization
{
	public bool UseFeedSpeed = false;

	public bool UseAllChars = false;

	public CodeUsing AuxCodeForFirstRisingG0 = new CodeUsing();

	public CodeUsing AuxCodeForLastFallingG0 = new CodeUsing();

	public CodeUsing AuxCodeForAllG0 = new CodeUsing();

	public G0Properties()
	{
	}

	public G0Properties(G0Properties data)
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
		AuxCodeForFirstRisingG0 = new CodeUsing(data.AuxCodeForFirstRisingG0);
		AuxCodeForAllG0 = new CodeUsing(data.AuxCodeForAllG0);
	}

	public G0Properties(bool usefeed, bool useallchar)
	{
		UseFeedSpeed = usefeed;
		UseAllChars = useallchar;
	}
}
