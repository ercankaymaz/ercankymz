using System;
using System.Reflection;

namespace buClass;

[Serializable]
public class CamPageVelocity : buSerilization
{
	public bool Feed = true;

	public bool BackwardFeed = false;

	public bool Plunge = true;

	public bool Rapid = false;

	public bool Leave = false;

	public bool Finish = false;

	public bool SpindleSpeed = false;

	public CamPageVelocity()
	{
	}

	public CamPageVelocity(CamPageVelocity data)
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
