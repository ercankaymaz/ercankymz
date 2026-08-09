using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class buNestedResult : buSerilization5
{
	public string JobName = "";

	public string JobColor = "";

	public string JobExplanation = "";

	public double ExecutionTime = 0.0;

	public double PastalWidth = 0.0;

	public double MaxXPosition = 0.0;

	public double MaxYPosition = 0.0;

	public double PartGap = 0.0;

	public DateTime ExecutionDate = default(DateTime);

	public int Licanse = 1;

	public int NestedSheetCount = 0;

	public int OrderedTotalPartCount = 0;

	public int NestedTotalPartCount = 0;

	public double TotalUsingPersentage = 0.0;

	public bool NotNestedAll = false;

	public string ItemNo = "";

	public string SalesNo = "";

	public string Other = "";

	public string Aux = "";

	public double UserData = 0.0;

	public buNestingVar Parameters = new buNestingVar();

	public List<buNestedSheet> NestedResultSheets = new List<buNestedSheet>();

	public List<buNestingPart> NestingPartsList = new List<buNestingPart>();

	public List<buNestingSheet> NestingSheetList = new List<buNestingSheet>();

	public buNestedResult()
	{
	}

	public buNestedResult(buNestedResult data)
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
		NestedResultSheets.Clear();
		for (int j = 0; j <= data.NestedResultSheets.Count - 1; j++)
		{
			NestedResultSheets.Add(new buNestedSheet(data.NestedResultSheets[j]));
		}
		for (int k = 0; k <= data.NestingPartsList.Count - 1; k++)
		{
			NestingPartsList.Add(new buNestingPart(data.NestingPartsList[k]));
		}
		for (int l = 0; l <= data.NestingSheetList.Count - 1; l++)
		{
			NestingSheetList.Add(new buNestingSheet(data.NestingSheetList[l]));
		}
	}

	public static void Copy(buNestedResult data, ref buNestedResult copied)
	{
		copied = new buNestedResult(data);
	}

	public static void Copy(List<buNestedResult> data, ref List<buNestedResult> copied)
	{
		copied.Clear();
		copied = new List<buNestedResult>();
		for (int i = 0; i <= data.Count - 1; i++)
		{
			buNestedResult item = new buNestedResult(data[i]);
			copied.Add(item);
		}
	}

	public static List<buNestedResult> Copy(List<buNestedResult> data)
	{
		List<buNestedResult> list = new List<buNestedResult>();
		for (int i = 0; i <= data.Count - 1; i++)
		{
			buNestedResult item = new buNestedResult(data[i]);
			list.Add(item);
		}
		return list;
	}

	public static ArrayList ToDef(buNestedResult Result, int Space)
	{
		ArrayList arrayList = new ArrayList();
		string text = "";
		arrayList.AddRange(Result.ToDefAll("", 2 + Space, SerilizationMode5.MultiLine));
		text = arrayList[arrayList.Count - 1].ToString();
		arrayList.RemoveAt(arrayList.Count - 1);
		arrayList.AddRange(buNestingPart.ToDef(Result.NestingPartsList, Space + 4).ToArray());
		arrayList.AddRange(buNestingSheet.ToDef(Result.NestingSheetList, Space + 4).ToArray());
		arrayList.AddRange(buNestedSheet.ToDef(Result.NestedResultSheets, Space + 4).ToArray());
		arrayList.Add(text);
		return arrayList;
	}

	public static void Decode(ArrayList AL, ref buNestedResult Result)
	{
		Result = new buNestedResult();
		List<List<string>> CalcList = new List<List<string>>();
		buStatics.ListToSpecificList("<buNestedResult>", "</buNestedResult>", AddStartEndKey: true, AL, ref CalcList);
		List<List<string>> CalcList2 = new List<List<string>>();
		buStatics.ListToSpecificList("<buNestingPart>", "</buNestingPart>", AddStartEndKey: true, AL, ref CalcList2);
		List<List<string>> CalcList3 = new List<List<string>>();
		buStatics.ListToSpecificList("<buNestingSheet>", "</buNestingSheet>", AddStartEndKey: true, AL, ref CalcList3);
		new List<List<string>>();
		if (CalcList.Count > 0)
		{
			ArrayList arrayList = new ArrayList();
			arrayList.AddRange(CalcList[0].ToArray());
			buSerilization5.Decode(arrayList, "", SerilizationMode5.MultiLine, Result);
			buNestedSheet.Decode(arrayList, ref Result.NestedResultSheets);
			arrayList.Clear();
		}
		if (CalcList2.Count > 0)
		{
			buNestingPart.Decode(AL, ref Result.NestingPartsList);
		}
		if (CalcList3.Count > 0)
		{
			buNestingSheet.Decode(AL, ref Result.NestingSheetList);
		}
		CalcList2.Clear();
		CalcList3.Clear();
		CalcList.Clear();
	}
}
