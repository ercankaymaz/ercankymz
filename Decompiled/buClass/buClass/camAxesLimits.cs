using System;
using System.Reflection;

namespace buClass;

[Serializable]
public class camAxesLimits : buSerilization
{
	public Pnt9D MaxLimit = new Pnt9D();

	public Pnt9D MinLimit = new Pnt9D();

	public camAxesLimits()
	{
	}

	public camAxesLimits(Pnt9D minLimit, Pnt9D maxLimit)
	{
		MinLimit = new Pnt9D(minLimit);
		MaxLimit = new Pnt9D(maxLimit);
	}

	public camAxesLimits(camAxesLimits Data)
	{
		object CopiedClass = new object();
		buSerilization.CopyClass(Data, ref CopiedClass);
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
