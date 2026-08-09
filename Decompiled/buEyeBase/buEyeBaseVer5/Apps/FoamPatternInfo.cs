using System;
using System.Reflection;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class FoamPatternInfo : buSerilization5
{
	public double TotalArea = 0.0;

	public double BoxArea = 0.0;

	public double UsedPersentageFromBoxArea = 0.0;

	public double TotalCuttingLength = 0.0;

	public double TotalNoCuttingLength = 0.0;

	public double TimeCutting = 0.0;

	public FoamPatternInfo()
	{
	}

	public FoamPatternInfo(double totalArea, double boxArea, double usedPersentageFromBoxArea, double totalCuttingLength, double totalNoCuttingLength, double timeCutting)
	{
		TotalArea = totalArea;
		BoxArea = boxArea;
		UsedPersentageFromBoxArea = usedPersentageFromBoxArea;
		TotalCuttingLength = totalCuttingLength;
		TotalNoCuttingLength = totalNoCuttingLength;
		TimeCutting = timeCutting;
	}

	public FoamPatternInfo(FoamPatternInfo data)
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

	public override string ToString()
	{
		return "TotalArea: " + TotalArea + " - BoxArea: " + BoxArea + " - %: " + UsedPersentageFromBoxArea + " - TimeCutting: " + TimeCutting;
	}
}
