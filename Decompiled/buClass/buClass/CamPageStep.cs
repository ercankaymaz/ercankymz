using System;
using System.Reflection;

namespace buClass;

[Serializable]
public class CamPageStep : buSerilization
{
	public bool Enable = true;

	public bool Start = true;

	public bool End = false;

	public bool Step = false;

	public bool Count = false;

	public bool Distance = false;

	public bool MoveUp = false;

	public bool MoveUpType = false;

	public bool Sequence = false;

	public CamPageStep()
	{
	}

	public CamPageStep(CamPageStep data)
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
