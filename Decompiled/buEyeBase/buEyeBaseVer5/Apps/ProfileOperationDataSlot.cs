using System;
using System.Collections;
using System.Drawing;
using System.Reflection;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class ProfileOperationDataSlot : buSerilization5
{
	public double SlotWidth = 50.0;

	public double SlotDiameter = 10.0;

	public double SlotAngle = 0.0;

	public Color SlotColor = Color.Blue;

	public double SlotThickness = 1.0;

	public ProfileOperationDataSlot()
	{
	}

	public ProfileOperationDataSlot(ProfileOperationDataSlot data)
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
		return "Width : " + SlotWidth + " - Dia : " + SlotDiameter;
	}

	public static ArrayList ToDefPars(ProfileOperationDataSlot P, string Char, int Space)
	{
		string text = "ProfileOperationDataSlotPars";
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

	public static ArrayList ToDefPars(ProfileOperationDataSlot P, int Space)
	{
		ArrayList arrayList = new ArrayList();
		arrayList.Add(buString5.SpaceChar(Space) + "<ProfileOperationDataSlotPars>");
		arrayList.Add(buString5.SpaceChar(Space + 2) + ToDefPars(P));
		arrayList.Add(buString5.SpaceChar(Space) + "</ProfileOperationDataSlotPars>");
		return arrayList;
	}

	public static string ToDefPars(ProfileOperationDataSlot P)
	{
		return buSerilization5.ClassToString(P);
	}
}
