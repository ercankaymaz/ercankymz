using System;
using System.Collections;
using System.Drawing;
using System.Reflection;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class ProfileOperationDataRectangleRound : buSerilization5
{
	public double RoundRectangleWidth = 20.0;

	public double RoundRectangleHeight = 20.0;

	public double RoundRectangleRadius = 2.0;

	public double RoundRectangleAngle = 0.0;

	public Color RoundRectangleColor = Color.Blue;

	public double RoundRectangleThickness = 1.0;

	public ProfileOperationDataRectangleRound()
	{
	}

	public ProfileOperationDataRectangleRound(ProfileOperationDataRectangleRound data)
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
		return "Width : " + RoundRectangleWidth + " - Height : " + RoundRectangleHeight + " - Radius : " + RoundRectangleRadius;
	}

	public static ArrayList ToDefPars(ProfileOperationDataRectangleRound P, string Char, int Space)
	{
		string text = "ProfileOperationDataRectangleRoundPars";
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

	public static ArrayList ToDefPars(ProfileOperationDataRectangleRound P, int Space)
	{
		ArrayList arrayList = new ArrayList();
		arrayList.Add(buString5.SpaceChar(Space) + "<ProfileOperationDataRectangleRoundPars>");
		arrayList.Add(buString5.SpaceChar(Space + 2) + ToDefPars(P));
		arrayList.Add(buString5.SpaceChar(Space) + "</ProfileOperationDataRectangleRoundPars>");
		return arrayList;
	}

	public static string ToDefPars(ProfileOperationDataRectangleRound P)
	{
		return buSerilization5.ClassToString(P);
	}
}
