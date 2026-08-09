using System;
using System.Collections.Generic;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5;

[Serializable]
public class camPocket5 : buSerilization5
{
	public bool Enable = false;

	public bool UsePoints = false;

	public double StepOverPersentage = 90.0;

	public CamPocketType PocketType = CamPocketType.WfbRghtOffset;

	public InToOutType PocketInOut = InToOutType.OutToIn;

	public bool SharpCorner = false;

	public static List<string> Captions = new List<string>();

	public camPocket5()
	{
	}

	public camPocket5(camPocket5 distance)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(distance, ref CopiedClass);
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
		return "Enable: " + Enable;
	}
}
