using System;
using System.Collections.Generic;
using System.Reflection;

namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class marbleLathePars : buSerilization5
{
	public double LatheRadiusTopDistance = 0.0;

	public double LatheSafeDistance = 100.0;

	public double LathePlungeFeed = 10.0;

	public double LatheCutFeed = 20.0;

	public bool LatheCAxisFollowDirection = false;

	public MarbleLatheDirection LatheDirection = MarbleLatheDirection.MaxToMin;

	public bool LatheZSafeDistanceFromTopSurface = false;

	public static List<string> Captions = new List<string>();

	public marbleLathePars()
	{
	}

	public marbleLathePars(marbleLathePars data)
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

	public static void Copy(marbleLathePars Source, ref marbleLathePars Target)
	{
		Target = new marbleLathePars(Source);
	}

	public override string ToString()
	{
		return "LatheSafeDistance : " + LatheSafeDistance + " , LathePlungeFeed : " + LathePlungeFeed + " , LatheCutFeed : " + LatheCutFeed + " , LatheDir : " + LatheDirection;
	}
}
