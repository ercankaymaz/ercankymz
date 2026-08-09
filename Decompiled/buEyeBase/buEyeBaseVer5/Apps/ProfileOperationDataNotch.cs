using System;
using System.Collections;
using System.Drawing;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class ProfileOperationDataNotch : buSerilization5
{
	public double NotchDepth = 20.0;

	public double NotchWidth = 10.0;

	public double NotchHeight = 20.0;

	public UpDownLocationType NotchUpDown = UpDownLocationType.Up;

	public FrontBackType NotchFrontBack = FrontBackType.Front;

	public ProfileNotchOperationType NotchOPType = ProfileNotchOperationType.Side;

	public double NotchStart = 10.0;

	public ProfileNotchLocationType NotchLocation = ProfileNotchLocationType.Left;

	public Color NotchColor = Color.Blue;

	public double NotchThickness = 1.0;

	public bool UseMilling = false;

	public ProfileOperationDataNotch()
	{
	}

	public ProfileOperationDataNotch(ProfileOperationDataNotch data)
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
		string text = "Depth: " + NotchDepth.ToString("f1") + " - Width: " + NotchWidth.ToString("f1") + " - Height: " + NotchHeight.ToString("f1") + " - " + NotchLocation.ToString() + " - " + NotchUpDown.ToString() + " - " + NotchFrontBack;
		if (UseMilling)
		{
			text = text + " - Milling: " + UseMilling;
		}
		return text;
	}

	public static ArrayList ToDefPars(ProfileOperationDataNotch P, string Char, int Space)
	{
		string text = "ProfileOperationDataNotchPars";
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

	public static ArrayList ToDefPars(ProfileOperationDataNotch P, int Space)
	{
		ArrayList arrayList = new ArrayList();
		arrayList.Add(buString5.SpaceChar(Space) + "<ProfileOperationDataNotchPars>");
		arrayList.Add(buString5.SpaceChar(Space + 2) + ToDefPars(P));
		arrayList.Add(buString5.SpaceChar(Space) + "</ProfileOperationDataNotchPars>");
		return arrayList;
	}

	public static string ToDefPars(ProfileOperationDataNotch P)
	{
		return buSerilization5.ClassToString(P);
	}
}
