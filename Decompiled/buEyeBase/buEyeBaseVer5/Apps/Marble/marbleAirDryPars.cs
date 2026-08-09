using System;
using System.Collections.Generic;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class marbleAirDryPars : buSerilization5
{
	public double Height = 10.0;

	public double StepDistance = 50.0;

	public double RapidDistance = 80.0;

	public HorizontalVertical Direction = HorizontalVertical.Horizontal;

	public MarbleAirDryPartType PartType = MarbleAirDryPartType.Block;

	public static List<string> Captions = new List<string>();

	public marbleAirDryPars()
	{
	}

	public marbleAirDryPars(marbleAirDryPars data)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(data, ref CopiedClass);
		if (!(this != null && CopiedClass != null) || !(GetType() == CopiedClass.GetType()))
		{
			return;
		}
		FieldInfo[] fields = GetType().GetFields();
		if (fields != null)
		{
			for (int i = 0; i <= fields.Length - 1; i++)
			{
				_ = fields[i].Name;
				object value = fields[i].GetValue(CopiedClass);
				fields[i].SetValue(this, value);
			}
		}
	}

	public static void Copy(marbleAirDryPars Source, ref marbleAirDryPars Target)
	{
		Target = new marbleAirDryPars(Source);
	}

	public override string ToString()
	{
		return "Height : " + Height + " , StepDistance : " + StepDistance + " , Direction : " + Direction;
	}
}
