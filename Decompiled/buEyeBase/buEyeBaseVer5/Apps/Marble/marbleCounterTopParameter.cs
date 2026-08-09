using System;
using System.Collections.Generic;
using System.Reflection;

namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class marbleCounterTopParameter : buSerilization5
{
	public MarbleCountertopTypes CountertopType = MarbleCountertopTypes.RectangleType1;

	public marbleCountertopMainPars Main = new marbleCountertopMainPars();

	public marbleCountertopInsidePars SinkData = new marbleCountertopInsidePars();

	public marbleCountertopTapPars TapData = new marbleCountertopTapPars();

	public marbleCountertopCavityPars CavityData = new marbleCountertopCavityPars();

	public static List<string> Captions = new List<string>();

	public marbleCounterTopParameter()
	{
	}

	public marbleCounterTopParameter(marbleCounterTopParameter data)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(data, ref CopiedClass);
		if (!(this != null && CopiedClass != null))
		{
			return;
		}
		if (GetType() == CopiedClass.GetType())
		{
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
		SinkData = new marbleCountertopInsidePars(data.SinkData);
		TapData = new marbleCountertopTapPars(data.TapData);
		CavityData = new marbleCountertopCavityPars(data.CavityData);
	}

	public override string ToString()
	{
		return CountertopType.ToString();
	}
}
