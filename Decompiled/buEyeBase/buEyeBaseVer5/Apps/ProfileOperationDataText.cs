using System;
using System.Collections;
using System.Drawing;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class ProfileOperationDataText : buSerilization5
{
	public double TextWidth = 0.0;

	public double TextHeight = 0.0;

	public double TextAngle = 0.0;

	public string TextString = "";

	public double CharSpace = 1.0;

	public double SpaceValue = 2.0;

	public bool isWire = false;

	public Font TextFont = new Font("Arial", 12f);

	public ProfileScaleCenterType TextScaleCenter = ProfileScaleCenterType.Center;

	public ContentAlignment TextAlignment = ContentAlignment.MiddleCenter;

	public Color TextColor = Color.Blue;

	public double TextThickness = 1.0;

	public ProfileOperationDataText()
	{
	}

	public ProfileOperationDataText(ProfileOperationDataText data)
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
		return TextString + " - Width : " + TextWidth + " - TextHeight : " + TextHeight;
	}

	public static ArrayList ToDefPars(ProfileOperationDataText P, string Char, int Space)
	{
		string text = "ProfileOperationDataTextPars";
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

	public static ArrayList ToDefPars(ProfileOperationDataText P, int Space)
	{
		ArrayList arrayList = new ArrayList();
		arrayList.Add(buString5.SpaceChar(Space) + "<ProfileOperationDataTextPars>");
		arrayList.Add(buString5.SpaceChar(Space + 2) + ToDefPars(P));
		arrayList.Add(buString5.SpaceChar(Space) + "</ProfileOperationDataTextPars>");
		return arrayList;
	}

	public static string ToDefPars(ProfileOperationDataText P)
	{
		return buSerilization5.ClassToString(P);
	}
}
