using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class buNestingSheet : buSerilization5
{
	public buNestingSheetData MaterialData = new buNestingSheetData();

	public double Area = 0.0;

	public double Cost = 0.0;

	public int Used = 0;

	public int Remain = 0;

	public int ID = 0;

	public string Aux = "";

	public string FileName = "";

	public bool Enable = true;

	public string Remarks = "";

	public string Referance = "";

	public double TrimWidth = 0.0;

	public double TrimHeight = 0.0;

	public nestMaterialType Type = nestMaterialType.Rectangle;

	public buEntitiesGroup EntitiesGroup = new buEntitiesGroup();

	public static List<string> Captions = new List<string>();

	public buNestingSheet()
	{
	}

	public buNestingSheet(buNestingSheet data)
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
		EntitiesGroup = new buEntitiesGroup(data.EntitiesGroup);
		MaterialData = new buNestingSheetData(data.MaterialData);
	}

	public override string ToString()
	{
		return "W: " + MaterialData.Width + " , H: " + MaterialData.Height + " , Qt: " + MaterialData.Quantity + " , Nested: " + Used;
	}

	public static void Copy(buNestingSheet Base, ref buNestingSheet Copied)
	{
		Copied = new buNestingSheet(Base);
	}

	public static void Copy(List<buNestingSheet> Base, ref List<buNestingSheet> Copied)
	{
		Copied.Clear();
		Copied = new List<buNestingSheet>();
		for (int i = 0; i <= Base.Count - 1; i++)
		{
			buNestingSheet item = new buNestingSheet(Base[i]);
			Copied.Add(item);
		}
	}

	public static ArrayList ToDef(List<buNestingSheet> Sheets, int Space, string Chars = "")
	{
		new string(' ', Space);
		new string(' ', Space + 2);
		new string(' ', Space + 6);
		new string(' ', Space + 8);
		ArrayList arrayList = new ArrayList();
		arrayList.Add(buString5.SpaceChar(Space) + "<NestingSheets" + Chars + ">");
		for (int i = 0; i <= Sheets.Count - 1; i++)
		{
			string text = "";
			arrayList.AddRange(Sheets[i].ToDefAll("", 2 + Space, SerilizationMode5.MultiLine));
			text = arrayList[arrayList.Count - 1].ToString();
			arrayList.RemoveAt(arrayList.Count - 1);
			if (Sheets[i].EntitiesGroup.Outside.Entities.Count > 0)
			{
				arrayList.AddRange(buEntitiesGroup.ToDefGroup(Sheets[i].EntitiesGroup, Space + 4));
			}
			arrayList.Add(text);
		}
		arrayList.Add(buString5.SpaceChar(Space) + "</NestingSheets" + Chars + ">");
		return arrayList;
	}

	public static void Decode(ArrayList AL, ref List<buNestingSheet> Sheets, string Chars = "")
	{
		Sheets.Clear();
		Sheets = new List<buNestingSheet>();
		List<List<string>> CalcList = new List<List<string>>();
		buStatics.ListToSpecificList("<buNestingSheet" + Chars + ">", "</buNestingSheet" + Chars + ">", AddStartEndKey: true, AL, ref CalcList);
		for (int i = 0; i <= CalcList.Count - 1; i++)
		{
			ArrayList arrayList = new ArrayList();
			arrayList.AddRange(CalcList[i].ToArray());
			buNestingSheet buNestingSheet2 = new buNestingSheet();
			buSerilization5.Decode(arrayList, "", SerilizationMode5.MultiLine, buNestingSheet2);
			List<string> CalcList2 = new List<string>();
			buStatics.ListToSpecificList("<buEntitiesGroupData>", "</buEntitiesGroupData>", AddStartEndKey: true, arrayList, ref CalcList2);
			buEntitiesGroup.Decode(CalcList2, ref buNestingSheet2.EntitiesGroup);
			buCall.buNestingCalc_0.CreatePointAndSolidFromEntityGroup(ref buNestingSheet2.EntitiesGroup);
			Sheets.Add(buNestingSheet2);
		}
	}
}
