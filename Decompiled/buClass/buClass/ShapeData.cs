using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace buClass;

[Serializable]
public class ShapeData : buSerilization
{
	public ShapeData()
	{
	}

	public ShapeData(ShapeData data)
	{
		object CopiedClass = new object();
		buSerilization.CopyClass(data, ref CopiedClass);
		if (!(this != null && CopiedClass != null) || !(GetType() == CopiedClass.GetType()))
		{
			return;
		}
		FieldInfo[] fields = GetType().GetFields();
		if (fields != null)
		{
			for (int i = 0; i <= fields.Length - 1; i++)
			{
				string name = fields[i].Name;
				object value = fields[i].GetValue(CopiedClass);
				fields[i].SetValue(this, value);
			}
		}
	}

	public static void Copy(ShapeData Base, ref ShapeData Copied)
	{
		if (Base.GetType() == typeof(PointData))
		{
			Copied = new PointData((PointData)Base);
		}
		if (Base.GetType() == typeof(LineData))
		{
			Copied = new LineData((LineData)Base);
		}
		if (Base.GetType() == typeof(RectangleCenterData))
		{
			Copied = new RectangleCenterData((RectangleCenterData)Base);
		}
		if (Base.GetType() == typeof(RectangleCornerData))
		{
			Copied = new RectangleCornerData((RectangleCornerData)Base);
		}
		if (Base.GetType() == typeof(RectangleCornerChamferData))
		{
			Copied = new RectangleCornerChamferData((RectangleCornerChamferData)Base);
		}
		if (Base.GetType() == typeof(RectangleCornerFilletData))
		{
			Copied = new RectangleCornerFilletData((RectangleCornerFilletData)Base);
		}
		if (Base.GetType() == typeof(CircleCenterData))
		{
			Copied = new CircleCenterData((CircleCenterData)Base);
		}
		if (Base.GetType() == typeof(SlotData))
		{
			Copied = new SlotData((SlotData)Base);
		}
		if (Base.GetType() == typeof(EllipseCenterData))
		{
			Copied = new EllipseCenterData((EllipseCenterData)Base);
		}
		if (Base.GetType() == typeof(PolygonCenterData))
		{
			Copied = new PolygonCenterData((PolygonCenterData)Base);
		}
		if (Base.GetType() == typeof(BarrelData))
		{
			Copied = new BarrelData((BarrelData)Base);
		}
		if (Base.GetType() == typeof(TextVectorData))
		{
			Copied = new TextVectorData((TextVectorData)Base);
		}
		if (Base.GetType() == typeof(TriangleTwinData))
		{
			Copied = new TriangleTwinData((TriangleTwinData)Base);
		}
	}

	public static ShapeData Decode(List<string> AL, string Char, SerilizationMode Mode)
	{
		ShapeData shapeData = null;
		string text = "";
		if (AL.Count > 0)
		{
			text = AL[0];
			if (text.Length > 0)
			{
				if (text.IndexOf("PointData") >= 0)
				{
					shapeData = new PointData();
					buSerilization.Decode(AL, "", SerilizationMode.MultiLine, shapeData);
				}
				if (text.IndexOf("RectangleCornerData") >= 0)
				{
					shapeData = new RectangleCornerData();
					buSerilization.Decode(AL, "", SerilizationMode.MultiLine, shapeData);
				}
				if (text.IndexOf("RectangleCenterData") >= 0)
				{
					shapeData = new RectangleCenterData();
					buSerilization.Decode(AL, "", SerilizationMode.MultiLine, shapeData);
				}
				if (text.IndexOf("RectangleCornerChamferData") >= 0)
				{
					shapeData = new RectangleCornerChamferData();
					buSerilization.Decode(AL, "", SerilizationMode.MultiLine, shapeData);
				}
				if (text.IndexOf("RectangleCornerFilletData") >= 0)
				{
					shapeData = new RectangleCornerFilletData();
					buSerilization.Decode(AL, "", SerilizationMode.MultiLine, shapeData);
				}
				if (text.IndexOf("LineData") >= 0)
				{
					shapeData = new LineData();
					buSerilization.Decode(AL, "", SerilizationMode.MultiLine, shapeData);
				}
				if (text.IndexOf("CircleCenterData") >= 0)
				{
					shapeData = new CircleCenterData();
					buSerilization.Decode(AL, "", SerilizationMode.MultiLine, shapeData);
				}
				if (text.IndexOf("EllipseCenterData") >= 0)
				{
					shapeData = new EllipseCenterData();
					buSerilization.Decode(AL, "", SerilizationMode.MultiLine, shapeData);
				}
				if (text.IndexOf("SlotData") >= 0)
				{
					shapeData = new SlotData();
					buSerilization.Decode(AL, "", SerilizationMode.MultiLine, shapeData);
				}
				if (text.IndexOf("PolygonCenterData") >= 0)
				{
					shapeData = new PolygonCenterData();
					buSerilization.Decode(AL, "", SerilizationMode.MultiLine, shapeData);
				}
				if (text.IndexOf("TriangleTwinData") >= 0)
				{
					shapeData = new TriangleTwinData();
					buSerilization.Decode(AL, "", SerilizationMode.MultiLine, shapeData);
				}
				if (text.IndexOf("BarrelData") >= 0)
				{
					shapeData = new BarrelData();
					buSerilization.Decode(AL, "", SerilizationMode.MultiLine, shapeData);
				}
				if (text.IndexOf("TextVectorData") >= 0)
				{
					shapeData = new TextVectorData();
					buSerilization.Decode(AL, "", SerilizationMode.MultiLine, shapeData);
				}
			}
		}
		return shapeData;
	}

	public ArrayList ToDefAll(int Space)
	{
		string text = new string(' ', Space);
		ArrayList arrayList = new ArrayList();
		buSerilization.ExceptionalVariables.Clear();
		arrayList.Add(text + "<ShapeData>");
		if (GetType() == typeof(LineData))
		{
			arrayList.AddRange(ToDefAll("", Space + 2, SerilizationMode.MultiLine).ToArray());
		}
		if (GetType() == typeof(RectangleCornerData))
		{
			arrayList.AddRange(ToDefAll("", Space + 2, SerilizationMode.MultiLine).ToArray());
		}
		if (GetType() == typeof(RectangleCornerFilletData))
		{
			arrayList.AddRange(ToDefAll("", Space + 2, SerilizationMode.MultiLine).ToArray());
		}
		if (GetType() == typeof(RectangleCornerChamferData))
		{
			arrayList.AddRange(ToDefAll("", Space + 2, SerilizationMode.MultiLine).ToArray());
		}
		if (GetType() == typeof(CircleCenterData))
		{
			arrayList.AddRange(ToDefAll("", Space + 2, SerilizationMode.MultiLine).ToArray());
		}
		if (GetType() == typeof(EllipseCenterData))
		{
			arrayList.AddRange(ToDefAll("", Space + 2, SerilizationMode.MultiLine).ToArray());
		}
		if (GetType() == typeof(PointData))
		{
			arrayList.AddRange(ToDefAll("", Space + 2, SerilizationMode.MultiLine).ToArray());
		}
		if (GetType() == typeof(RectangleCenterData))
		{
			arrayList.AddRange(ToDefAll("", Space + 2, SerilizationMode.MultiLine).ToArray());
		}
		if (GetType() == typeof(SlotData))
		{
			arrayList.AddRange(ToDefAll("", Space + 2, SerilizationMode.MultiLine).ToArray());
		}
		if (GetType() == typeof(PolygonCenterData))
		{
			arrayList.AddRange(ToDefAll("", Space + 2, SerilizationMode.MultiLine).ToArray());
		}
		if (GetType() == typeof(BarrelData))
		{
			arrayList.AddRange(ToDefAll("", Space + 2, SerilizationMode.MultiLine).ToArray());
		}
		if (GetType() == typeof(TriangleTwinData))
		{
			arrayList.AddRange(ToDefAll("", Space + 2, SerilizationMode.MultiLine).ToArray());
		}
		if (GetType() == typeof(TextVectorData))
		{
			arrayList.AddRange(ToDefAll("", Space + 2, SerilizationMode.MultiLine).ToArray());
		}
		arrayList.Add(text + "</ShapeData>");
		return arrayList;
	}
}
