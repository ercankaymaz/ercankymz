using System;
using System.Collections;
using System.Drawing;
using System.Reflection;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class ProfileOperationDataCircle : buSerilization5
{
	public double CircleDiameter = 10.0;

	public Color CircleColor = Color.Blue;

	public double CircleThickness = 1.0;

	public ProfileOperationDataCircle()
	{
	}

	public ProfileOperationDataCircle(ProfileOperationDataCircle data)
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
		return "Dia : " + CircleDiameter;
	}

	public static ArrayList ToDefPars(ProfileOperationDataCircle P, string Char, int Space)
	{
		string text = "ProfileOperationDataCirclePars";
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

	public static ArrayList ToDefPars(ProfileOperationDataCircle P, int Space)
	{
		ArrayList arrayList = new ArrayList();
		arrayList.Add(buString5.SpaceChar(Space) + "<ProfileOperationDataCirclePars>");
		arrayList.Add(buString5.SpaceChar(Space + 2) + ToDefPars(P));
		arrayList.Add(buString5.SpaceChar(Space) + "</ProfileOperationDataCirclePars>");
		return arrayList;
	}

	public static string ToDefPars(ProfileOperationDataCircle P)
	{
		return buSerilization5.ClassToString(P);
	}
}
