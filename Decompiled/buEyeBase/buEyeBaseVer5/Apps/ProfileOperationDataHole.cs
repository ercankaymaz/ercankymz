using System;
using System.Collections;
using System.Drawing;
using System.Reflection;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class ProfileOperationDataHole : buSerilization5
{
	public double HoleDepth = 10.0;

	public double HoleDiameter = 10.0;

	public Color HoleColor = Color.Blue;

	public double HoleThickness = 1.0;

	public bool Tapping = false;

	public double TappingDiameter = 5.0;

	public double TappingDepth = 8.0;

	public double TappingPitch = 2.0;

	public double TappingAddition = 1.0;

	public ProfileOperationDataHole()
	{
	}

	public ProfileOperationDataHole(ProfileOperationDataHole data)
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
		string text = "Dia : " + HoleDiameter;
		if (Tapping)
		{
			text = text + " - Tapping Dia: " + TappingDiameter.ToString("f1");
		}
		return text;
	}

	public static ArrayList ToDefPars(ProfileOperationDataHole P, string Char, int Space)
	{
		string text = "ProfileOperationDataHolePars";
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

	public static ArrayList ToDefPars(ProfileOperationDataHole P, int Space)
	{
		ArrayList arrayList = new ArrayList();
		arrayList.Add(buString5.SpaceChar(Space) + "<ProfileOperationDataHolePars>");
		arrayList.Add(buString5.SpaceChar(Space + 2) + ToDefPars(P));
		arrayList.Add(buString5.SpaceChar(Space) + "</ProfileOperationDataHolePars>");
		return arrayList;
	}

	public static string ToDefPars(ProfileOperationDataHole P)
	{
		return buSerilization5.ClassToString(P);
	}
}
