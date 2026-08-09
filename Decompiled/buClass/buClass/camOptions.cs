using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass;

[Serializable]
public class camOptions : buSerilization
{
	public bool SelectAllPoints = false;

	public bool SelectAllDrawings = false;

	public double PocketNextContourMaxDistance = 10.0;

	public camAxesLimits AxesLimit = new camAxesLimits();

	public static List<string> Captions = new List<string>();

	public camOptions()
	{
	}

	public camOptions(camOptions data)
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
		((camOptions)CopiedClass).AxesLimit = new camAxesLimits(data.AxesLimit);
	}

	public override string ToString()
	{
		return "SelectAllPoints: " + SelectAllPoints;
	}
}
