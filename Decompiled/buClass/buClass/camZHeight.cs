using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass;

[Serializable]
public class camZHeight : buSerilization
{
	public double Depth = 0.0;

	public CamZHeightType Type = CamZHeightType.Contour;

	public bool FinalStep = false;

	public static List<string> Captions = new List<string>();

	public camZHeight()
	{
	}

	public camZHeight(camZHeight distance)
	{
		object CopiedClass = new object();
		buSerilization.CopyClass(distance, ref CopiedClass);
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

	public override string ToString()
	{
		return "Depth: " + Depth + " , Type: " + Type;
	}
}
