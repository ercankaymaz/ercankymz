using System;
using System.Collections.Generic;
using System.Reflection;

namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class marbleLatheVerticalPars : buSerilization5
{
	public double LatheRadiusTopDistance = 0.0;

	public double LatheSafeDistance = 100.0;

	public double LathePlungeFeed = 10.0;

	public double LatheCutFeed = 20.0;

	public double LatheBaseHeight = 0.0;

	public static List<string> Captions = new List<string>();

	public marbleLatheVerticalPars()
	{
	}

	public marbleLatheVerticalPars(marbleLatheVerticalPars data)
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

	public static void Copy(marbleLatheVerticalPars Source, ref marbleLatheVerticalPars Target)
	{
		Target = new marbleLatheVerticalPars(Source);
	}

	public override string ToString()
	{
		return "LatheSafeDistance : " + LatheSafeDistance + " , LathePlungeFeed : " + LathePlungeFeed + " , LatheCutFeed : " + LatheCutFeed;
	}
}
