using System;
using System.Collections;
using System.Drawing;
using System.Reflection;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class ProfileOperationDataCut : buSerilization5
{
	public double CutWidth = 10.0;

	public double CutHeigth = 50.0;

	public double CutDepth = 10.0;

	public double CutAngle = 0.0;

	public Color CutColor = Color.Blue;

	public double CutThickness = 1.0;

	public ProfileOperationDataCut()
	{
	}

	public ProfileOperationDataCut(ProfileOperationDataCut data)
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
		return "Width : " + CutWidth + " - H : " + CutHeigth;
	}

	public static ArrayList ToDefPars(ProfileOperationDataCut P, string Char, int Space)
	{
		string text = "ProfileOperationDataCutPars";
		if (Char.Trim().Length > 0)
		{
			text = Char;
		}
		ArrayList arrayList = new ArrayList();
		arrayList.Add(buString5.SpaceChar(Space) + "<" + text);
		arrayList.Add(buString5.SpaceChar(Space + 2) + ToDefPars(P));
		arrayList.Add(buString5.SpaceChar(Space) + "</" + text);
		return arrayList;
	}

	public static ArrayList ToDefPars(ProfileOperationDataCut P, int Space)
	{
		ArrayList arrayList = new ArrayList();
		arrayList.Add(buString5.SpaceChar(Space) + "<ProfileOperationDataCutPars>");
		arrayList.Add(buString5.SpaceChar(Space + 2) + ToDefPars(P));
		arrayList.Add(buString5.SpaceChar(Space) + "</ProfileOperationDataCutPars>");
		return arrayList;
	}

	public static string ToDefPars(ProfileOperationDataCut P)
	{
		return buSerilization5.ClassToString(P);
	}
}
