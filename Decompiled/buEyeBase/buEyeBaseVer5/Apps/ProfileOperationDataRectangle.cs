using System;
using System.Collections;
using System.Drawing;
using System.Reflection;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class ProfileOperationDataRectangle : buSerilization5
{
	public double RectangleWidth = 20.0;

	public double RectangleHeight = 20.0;

	public double RectangleRadius = 0.0;

	public double RectangleChamfer = 0.0;

	public double RectangleAngle = 0.0;

	public Color RectangleColor = Color.Blue;

	public double RectangleThickness = 1.0;

	public ProfileOperationDataRectangle()
	{
	}

	public ProfileOperationDataRectangle(ProfileOperationDataRectangle data)
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
		return "Width : " + RectangleWidth + " - Height : " + RectangleHeight;
	}

	public static ArrayList ToDefPars(ProfileOperationDataRectangle P, string Char, int Space)
	{
		string text = "ProfileOperationDataRectanglePars";
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

	public static ArrayList ToDefPars(ProfileOperationDataRectangle P, int Space)
	{
		ArrayList arrayList = new ArrayList();
		arrayList.Add(buString5.SpaceChar(Space) + "<ProfileOperationDataRectanglePars>");
		arrayList.Add(buString5.SpaceChar(Space + 2) + ToDefPars(P));
		arrayList.Add(buString5.SpaceChar(Space) + "</ProfileOperationDataRectanglePars>");
		return arrayList;
	}

	public static string ToDefPars(ProfileOperationDataRectangle P)
	{
		return buSerilization5.ClassToString(P);
	}
}
