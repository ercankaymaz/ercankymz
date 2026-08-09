using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class buNestingPart : buSerilization5
{
	public buNestingPartData PartData = new buNestingPartData();

	public double RotateDegree = 0.0;

	public double Area = 0.0;

	public double PartDistance = 0.0;

	public double Price = 0.0;

	public double PrecutWidth = 0.0;

	public double PrecutHeight = 0.0;

	public int Nested = 0;

	public int Remain = 0;

	public int ID = 0;

	public string Explanation = "";

	public string Aux = "";

	public string Material = "";

	public string Code = "";

	public string FileName = "";

	public string Referance = "";

	public bool CanRotate = false;

	public bool Enable = true;

	public bool UseInnersAsHolePartInPart = true;

	public bool EdgeLeft = false;

	public bool EdgeRight = false;

	public bool EdgeTop = false;

	public bool EdgeBottom = false;

	public bool Selected = false;

	public double EdgeLeftThickness = 0.0;

	public double EdgeRightThickness = 0.0;

	public double EdgeTopThickness = 0.0;

	public double EdgeBottomThickness = 0.0;

	public nestMaterialType Type = nestMaterialType.Rectangle;

	public buEntitiesGroup EntitiesGroup = new buEntitiesGroup();

	public static List<string> Captions = new List<string>();

	public buNestingPart()
	{
	}

	public buNestingPart(buNestingPart data)
	{
		object CopiedClass = new object();
		buSerilization.CopyClass(data, ref CopiedClass);
		if (this != null && CopiedClass != null && GetType() == CopiedClass.GetType())
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
		PartData = new buNestingPartData(data.PartData);
		EntitiesGroup = new buEntitiesGroup(data.EntitiesGroup);
	}

	public override string ToString()
	{
		return "Type: " + Type.ToString() + " - " + PartData.ToString();
	}

	public static void Copy(buNestingPart Base, ref buNestingPart Copied)
	{
		Copied = new buNestingPart(Base);
	}

	public static void Copy(List<buNestingPart> Base, ref List<buNestingPart> Copied)
	{
		Copied.Clear();
		Copied = new List<buNestingPart>();
		for (int i = 0; i <= Base.Count - 1; i++)
		{
			buNestingPart item = new buNestingPart(Base[i]);
			Copied.Add(item);
		}
	}

	public static ArrayList ToDef(List<buNestingPart> Parts, int Space)
	{
		string text = new string(' ', Space);
		new string(' ', Space + 2);
		new string(' ', Space + 6);
		new string(' ', Space + 8);
		ArrayList arrayList = new ArrayList();
		arrayList.Add(text + "<NestingParts>");
		for (int i = 0; i <= Parts.Count - 1; i++)
		{
			string text2 = "";
			arrayList.AddRange(Parts[i].ToDefAll("", 4 + Space, SerilizationMode5.MultiLine));
			text2 = arrayList[arrayList.Count - 1].ToString();
			arrayList.RemoveAt(arrayList.Count - 1);
			if (Parts[i].EntitiesGroup.Outside.Entities.Count > 0)
			{
				arrayList.AddRange(buEntitiesGroup.ToDefGroup(Parts[i].EntitiesGroup, Space + 4));
			}
			arrayList.Add(text2);
		}
		arrayList.Add(text + "</NestingParts>");
		return arrayList;
	}

	public static void Decode(ArrayList AL, ref List<buNestingPart> Parts)
	{
		Parts.Clear();
		Parts = new List<buNestingPart>();
		List<List<string>> CalcList = new List<List<string>>();
		buStatics.ListToSpecificList("<buNestingPart>", "</buNestingPart>", AddStartEndKey: true, AL, ref CalcList);
		for (int i = 0; i <= CalcList.Count - 1; i++)
		{
			ArrayList arrayList = new ArrayList();
			arrayList.AddRange(CalcList[i].ToArray());
			buNestingPart buNestingPart2 = new buNestingPart();
			buSerilization5.Decode(arrayList, "", SerilizationMode5.MultiLine, buNestingPart2);
			List<string> CalcList2 = new List<string>();
			buStatics.ListToSpecificList("<buEntitiesGroupData>", "</buEntitiesGroupData>", AddStartEndKey: true, arrayList, ref CalcList2);
			buEntitiesGroup.Decode(CalcList2, ref buNestingPart2.EntitiesGroup);
			buCall.buNestingCalc_0.CreatePointAndSolidFromEntityGroup(ref buNestingPart2.EntitiesGroup, View3D: false);
			Parts.Add(buNestingPart2);
		}
	}
}
