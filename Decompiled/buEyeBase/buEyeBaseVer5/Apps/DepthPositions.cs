using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5.Apps;

public class DepthPositions : buSerilization5
{
	public double Depth = 0.0;

	public double TopPosition = 0.0;

	public double BottomPosition = 0.0;

	public double SpindleSpeed = 0.0;

	public double PlungeFeed = 0.0;

	public bool PeckingUp = false;

	public double PeckingUpDistance = 0.0;

	public double Wait = 0.0;

	public DepthPositions()
	{
	}

	public DepthPositions(DepthPositions data)
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

	public static void SaveFile(List<DepthPositions> Depths, string FileName)
	{
		ArrayList arrayList = new ArrayList();
		arrayList.Add("<DepthValues>");
		for (int i = 0; i <= Depths.Count - 1; i++)
		{
			arrayList.AddRange(Depths[i].ToDefAll("", 2, SerilizationMode5.MultiLine));
		}
		arrayList.Add("</DepthValues>");
		buFile5.SaveToFile(arrayList, FileName);
		arrayList.Clear();
	}

	public static void OpenFile(ref List<DepthPositions> Depths, string FileName)
	{
		List<string> StringList = new List<string>();
		List<List<string>> CalcList = new List<List<string>>();
		buFile5.OpenFromFile(FileName, ref StringList);
		buStatics.ListToSpecificList("<DepthPositions>", "</DepthPositions>", AddStartEndKey: true, StringList, ref CalcList);
		for (int i = 0; i <= CalcList.Count - 1; i++)
		{
			DepthPositions depthPositions = new DepthPositions();
			buSerilization5.Decode(CalcList[i], "", SerilizationMode5.MultiLine, depthPositions);
			Depths.Add(depthPositions);
		}
		CalcList.Clear();
		StringList.Clear();
	}

	public static void Copy(List<DepthPositions> Depths, ref List<DepthPositions> Copied)
	{
		if (Depths != null)
		{
			if (Copied == null)
			{
				Copied = new List<DepthPositions>();
			}
			Copied.Clear();
			for (int i = 0; i <= Depths.Count - 1; i++)
			{
				Copied.Add(new DepthPositions(Depths[i]));
			}
		}
	}

	public override string ToString()
	{
		return "Depth: " + Depth + " - TopPosition: " + TopPosition + " - BottomPosition: " + BottomPosition;
	}
}
