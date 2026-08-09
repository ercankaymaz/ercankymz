using System;
using System.Collections.Generic;
using System.Reflection;

namespace buEyeBaseVer5;

[Serializable]
public class camSpeedsEnable : buSerilization5
{
	public bool Feed = true;

	public bool BackwardFeed = false;

	public bool Plunge = true;

	public bool Rapid = false;

	public bool Leave = true;

	public bool Finish = true;

	public static List<string> Captions = new List<string>();

	public camSpeedsEnable()
	{
	}

	public camSpeedsEnable(bool feed, bool plunge, bool rapid, bool leave, bool backwardfeed, bool finish)
	{
		Feed = feed;
		Plunge = plunge;
		Rapid = rapid;
		Leave = leave;
		BackwardFeed = backwardfeed;
		Finish = finish;
	}

	public camSpeedsEnable(camSpeedsEnable speeds)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(speeds, ref CopiedClass);
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

	public override string ToString()
	{
		return "Feed: " + Feed + " , Plunge: " + Plunge + " , Rapid: " + Rapid + " , Leave: " + Leave;
	}
}
