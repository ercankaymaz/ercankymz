using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass.Apps;

[Serializable]
public class marblePerpendicularCut : buSerilization
{
	public double TangentAngle = 0.0;

	public double PitchAngle = 0.0;

	public double TeachLength = 100.0;

	public double CutHorizontalLength = 0.0;

	public double CutVerticalLength = 0.0;

	public CamCuttingSideDirectionType CuttingSideHorizontal = CamCuttingSideDirectionType.LeftToRight;

	public CamCuttingSideDirectionType CuttingSideVertical = CamCuttingSideDirectionType.LeftToRight;

	public List<marbleCutItems> HorizontalItems = new List<marbleCutItems>();

	public List<marbleCutItems> VerticalItems = new List<marbleCutItems>();

	public static List<string> Captions = new List<string>();

	public marblePerpendicularCut()
	{
	}

	public marblePerpendicularCut(marblePerpendicularCut data)
	{
		object CopiedClass = new object();
		buSerilization.CopyClass(data, ref CopiedClass);
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

	public static void Copy(marblePerpendicularCut Source, ref marblePerpendicularCut Target)
	{
		Target = new marblePerpendicularCut(Source);
	}

	public override string ToString()
	{
		return "TangentAngle : " + TangentAngle + " , PitchAngle : " + PitchAngle;
	}
}
