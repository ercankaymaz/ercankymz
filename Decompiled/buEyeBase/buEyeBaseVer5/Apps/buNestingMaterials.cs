using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class buNestingMaterials : buSerilization5
{
	public double Thickness = 18.0;

	public double Cost = 1.0;

	public int ID = -1;

	public string Material = "Standart";

	public string Explanation = "";

	public bool Enable = true;

	public static List<string> Captions = new List<string>();

	public buNestingMaterials()
	{
	}

	public buNestingMaterials(buNestingMaterials data)
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
				_ = fields[i].Name;
				object value = fields[i].GetValue(CopiedClass);
				fields[i].SetValue(this, value);
			}
		}
	}

	public override string ToString()
	{
		return Material + " - Thickness: " + Thickness + " , Enable: " + Enable;
	}

	public static void Copy(buNestingMaterials Base, ref buNestingMaterials Copied)
	{
		Copied = new buNestingMaterials(Base);
	}

	public static void Copy(List<buNestingMaterials> Base, ref List<buNestingMaterials> Copied)
	{
		Copied.Clear();
		Copied = new List<buNestingMaterials>();
		for (int i = 0; i <= Base.Count - 1; i++)
		{
			buNestingMaterials item = new buNestingMaterials(Base[i]);
			Copied.Add(item);
		}
	}

	public static List<buNestingMaterials> Copy(List<buNestingMaterials> Base)
	{
		List<buNestingMaterials> list = new List<buNestingMaterials>();
		for (int i = 0; i <= Base.Count - 1; i++)
		{
			buNestingMaterials item = new buNestingMaterials(Base[i]);
			list.Add(item);
		}
		return list;
	}

	public static ArrayList ToDef(List<buNestingMaterials> Mats, int Space)
	{
		string text = new string(' ', Space);
		new string(' ', Space + 2);
		new string(' ', Space + 6);
		new string(' ', Space + 8);
		ArrayList arrayList = new ArrayList();
		arrayList.Add(text + "<nestingMaterials>");
		for (int i = 0; i <= Mats.Count - 1; i++)
		{
			arrayList.AddRange(Mats[i].ToDefAll("", 2 + Space, SerilizationMode5.MultiLine));
		}
		arrayList.Add(text + "</nestingMaterials>");
		return arrayList;
	}

	public static void Decode(ArrayList AL, ref List<buNestingMaterials> Mats)
	{
		new List<List<string>>();
		Mats.Clear();
		Mats = new List<buNestingMaterials>();
		List<List<string>> CalcList = new List<List<string>>();
		buStatics.ListToSpecificList("<nestingMaterials>", "</nestingMaterials>", AddStartEndKey: true, AL, ref CalcList);
		for (int i = 0; i <= CalcList.Count - 1; i++)
		{
			ArrayList arrayList = new ArrayList();
			arrayList.AddRange(CalcList[i].ToArray());
			buNestingMaterials buNestingMaterials2 = new buNestingMaterials();
			buSerilization5.Decode(arrayList, "", SerilizationMode5.MultiLine, buNestingMaterials2);
			Mats.Add(buNestingMaterials2);
		}
	}
}
