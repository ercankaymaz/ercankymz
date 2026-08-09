using System.Collections;
using System.Drawing;
using System.Reflection;

namespace buEyeBaseVer5.Apps;

public class ProfileOperationDataPolygon : buSerilization5
{
	public int PolygonSide = 6;

	public double PolygonDiameter = 20.0;

	public double PolygonAngle = 0.0;

	public Color PolygonColor = Color.Blue;

	public double PolygonThickness = 1.0;

	public ProfileOperationDataPolygon()
	{
	}

	public ProfileOperationDataPolygon(ProfileOperationDataPolygon data)
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
		return "Side : " + PolygonSide;
	}

	public static ArrayList ToDefPars(ProfileOperationDataPolygon P, string Char, int Space)
	{
		string text = "ProfileOperationDataPolygonPars";
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

	public static ArrayList ToDefPars(ProfileOperationDataPolygon P, int Space)
	{
		ArrayList arrayList = new ArrayList();
		arrayList.Add(buString5.SpaceChar(Space) + "<ProfileOperationDataPolygonPars>");
		arrayList.Add(buString5.SpaceChar(Space + 2) + ToDefPars(P));
		arrayList.Add(buString5.SpaceChar(Space) + "</ProfileOperationDataPolygonPars>");
		return arrayList;
	}

	public static string ToDefPars(ProfileOperationDataPolygon P)
	{
		return buSerilization5.ClassToString(P);
	}
}
