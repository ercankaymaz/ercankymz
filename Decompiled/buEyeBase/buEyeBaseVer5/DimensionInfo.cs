using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using buClass;
using devDept.Geometry;

namespace buEyeBaseVer5;

[Serializable]
public class DimensionInfo : buSerilization5
{
	public string Chars = "";

	public string Explanation = "";

	public string TextOverride = "";

	public string ReletedEntityName = "";

	public double Distance = 0.0;

	public double Angle = 0.0;

	public bool IsVertical = false;

	public DimensionType Type = DimensionType.None;

	public Point3D CatchPoint = new Point3D();

	public Point3D BasePoint = new Point3D();

	public Point3D CatchPointOfEntity = new Point3D();

	public Point3D BasePointOfEntity = new Point3D();

	public int ReSizedEntityIndex = -1;

	public int ReSizedEntitySubIndex = -1;

	public string SelectedEntities = "";

	public DimensionInfo()
	{
	}

	public DimensionInfo(string chars, string explanation, double distance, double angle, bool isvertical, DimensionType type)
	{
		Chars = chars;
		Explanation = explanation;
		Distance = distance;
		Angle = angle;
		IsVertical = isvertical;
		Type = type;
	}

	public DimensionInfo(DimensionInfo data)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(data, ref CopiedClass);
		if (!(this != null && CopiedClass != null))
		{
			return;
		}
		if (GetType() == CopiedClass.GetType())
		{
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
		BasePoint = buVector5.ToPoint3D(data.BasePoint);
		CatchPoint = buVector5.ToPoint3D(data.CatchPoint);
		CatchPointOfEntity = buVector5.ToPoint3D(data.CatchPointOfEntity);
		BasePointOfEntity = buVector5.ToPoint3D(data.BasePointOfEntity);
	}

	public ArrayList ToDef(int Space)
	{
		ArrayList arrayList = new ArrayList();
		arrayList.Add(buString5.SpaceChar(Space) + buSerilization5.ClassToString(this));
		return arrayList;
	}

	public static void Decode(List<string> SL, ref DimensionInfo Sewing)
	{
		try
		{
			object obj = null;
			if (SL.Count >= 1)
			{
				Sewing = new DimensionInfo();
				obj = Sewing;
				buSerilization5.StringToClass(ref obj, SL[0]);
			}
		}
		catch (Exception)
		{
		}
	}

	public override string ToString()
	{
		return Chars + " - Exp: " + Explanation + " - Dis: " + Distance.ToString("f2") + " - Type: " + Type.ToString() + " - Ent Index: " + ReSizedEntityIndex;
	}
}
