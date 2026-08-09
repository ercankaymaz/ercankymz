using System;
using System.Collections;
using System.Drawing;
using System.Reflection;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class ProfileOperationDataBarel : buSerilization5
{
	public double BarrelLength = 50.0;

	public double BarrelDiameter = 16.0;

	public double BarrelWidth = 10.0;

	public double BarrelAngle = 0.0;

	public Color BarrelColor = Color.Blue;

	public double BarrelThickness = 1.0;

	public ProfileOperationDataBarel()
	{
	}

	public ProfileOperationDataBarel(ProfileOperationDataBarel data)
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
		return "Len : " + BarrelLength + " - Dia : " + BarrelDiameter + " - Width : " + BarrelWidth;
	}

	public static ArrayList ToDefPars(ProfileOperationDataBarel P, string Char, int Space)
	{
		string text = "ProfileOperationDataPars";
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

	public static ArrayList ToDefPars(ProfileOperationDataBarel P, int Space)
	{
		ArrayList arrayList = new ArrayList();
		arrayList.Add(buString5.SpaceChar(Space) + "<ProfileOperationDataBarelPars>");
		arrayList.Add(buString5.SpaceChar(Space + 2) + ToDefPars(P));
		arrayList.Add(buString5.SpaceChar(Space) + "</ProfileOperationDataBarelPars>");
		return arrayList;
	}

	public static string ToDefPars(ProfileOperationDataBarel P)
	{
		return buSerilization5.ClassToString(P);
	}
}
