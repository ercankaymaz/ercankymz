using System;
using System.Collections;
using System.Drawing;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class ProfileOperationDataFreeDraw : buSerilization5
{
	public double FreeDrawWidth = 0.0;

	public double FreeDrawHeight = 0.0;

	public double FreeDrawAngle = 0.0;

	public ProfileScaleCenterType FreeDrawScaleCenter = ProfileScaleCenterType.Center;

	public Color FreeDrawColor = Color.Blue;

	public double FreeDrawThickness = 1.0;

	public ProfileOperationDataFreeDraw()
	{
	}

	public ProfileOperationDataFreeDraw(ProfileOperationDataFreeDraw data)
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
		return "Width : " + FreeDrawWidth + " - EllipseHeight : " + FreeDrawHeight;
	}

	public static ArrayList ToDefPars(ProfileOperationDataFreeDraw P, string Char, int Space)
	{
		string text = "ProfileOperationDataFreeDrawPars";
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

	public static ArrayList ToDefPars(ProfileOperationDataFreeDraw P, int Space)
	{
		ArrayList arrayList = new ArrayList();
		arrayList.Add(buString5.SpaceChar(Space) + "<ProfileOperationDataFreeDrawPars>");
		arrayList.Add(buString5.SpaceChar(Space + 2) + ToDefPars(P));
		arrayList.Add(buString5.SpaceChar(Space) + "</ProfileOperationDataFreeDrawPars>");
		return arrayList;
	}

	public static string ToDefPars(ProfileOperationDataFreeDraw P)
	{
		return buSerilization5.ClassToString(P);
	}
}
