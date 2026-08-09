using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using buClass;
using buEyeBaseVer5.buEntities;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class buNestedSheet : buSerilization5
{
	public int Count = 0;

	public int ID = 0;

	public string MaterialName = "";

	public double MaterialWidth = 0.0;

	public double MaterialHeight = 0.0;

	public double MaterialArea = 0.0;

	public double MaterialAreaFromMaxX = 0.0;

	public double MaterialThickness = 5.0;

	public double NestedArea = 0.0;

	public double TotalOutsideLength = 0.0;

	public double TotalInsideLength = 0.0;

	public double TotalNoneCuttingLength = 0.0;

	public double TotalLength = 0.0;

	public int TotalUpMove = 0;

	public int TotalDownMove = 0;

	public int TotalTextCount = 0;

	public double ApproxExecutionTimeSec = 0.0;

	public int ApproxExecution0UpDownCnt = 0;

	public int ApproxExecution1UpDownCnt = 0;

	public int ApproxExecution2UpDownCnt = 0;

	public int ApproxExecution3UpDownCnt = 0;

	public int ApproxExecution4UpDownCnt = 0;

	public int ApproxExecution5UpDownCnt = 0;

	public int ApproxExecution6UpDownCnt = 0;

	public int ApproxExecution7UpDownCnt = 0;

	public int ApproxExecution8UpDownCnt = 0;

	public int ApproxExecution9UpDownCnt = 0;

	public double ApproxExecution0Len = 0.0;

	public double ApproxExecution1Len = 0.0;

	public double ApproxExecution2Len = 0.0;

	public double ApproxExecution3Len = 0.0;

	public double ApproxExecution4Len = 0.0;

	public double ApproxExecution5Len = 0.0;

	public double ApproxExecution6Len = 0.0;

	public double ApproxExecution7Len = 0.0;

	public double ApproxExecution8Len = 0.0;

	public double ApproxExecution9Len = 0.0;

	public double ApproxExecution0TimeSec = 0.0;

	public double ApproxExecution1TimeSec = 0.0;

	public double ApproxExecution2TimeSec = 0.0;

	public double ApproxExecution3TimeSec = 0.0;

	public double ApproxExecution4TimeSec = 0.0;

	public double ApproxExecution5TimeSec = 0.0;

	public double ApproxExecution6TimeSec = 0.0;

	public double ApproxExecution7TimeSec = 0.0;

	public double ApproxExecution8TimeSec = 0.0;

	public double ApproxExecution9TimeSec = 0.0;

	public int MaterialID = 0;

	public string Name = "Sheet";

	public double UsingPersentage = 0.0;

	public double UsingPersentageFromMaxX = 0.0;

	public bool DontUse = false;

	public bool CalculationError = false;

	public double PartsTotalWidth = 0.0;

	public double PartsTotalHeight = 0.0;

	public string ItemNo = "";

	public string SalesNo = "";

	public string Other = "";

	public string Aux = "";

	public double UserData = 0.0;

	public string WarningText = "";

	public double SheetMaxXPosition = 0.0;

	public double SheetMaxYPosition = 0.0;

	public nestMaterialType Type = nestMaterialType.Rectangle;

	public buEntitiesGroup EntitiesGroup = new buEntitiesGroup();

	public List<List<buEntity>> UselessEntities = new List<List<buEntity>>();

	public List<buNestedPart> Parts = new List<buNestedPart>();

	public List<Rectangle2D> RemnantSheets = new List<Rectangle2D>();

	public List<camTp> Cams = new List<camTp>();

	public MachineGCodeExecutionResult GCodeResult = null;

	public buNestedSheet()
	{
	}

	public buNestedSheet(buNestedSheet data)
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
		Parts.Clear();
		for (int j = 0; j <= data.Parts.Count - 1; j++)
		{
			Parts.Add(new buNestedPart(data.Parts[j]));
		}
		RemnantSheets.Clear();
		for (int k = 0; k <= data.RemnantSheets.Count - 1; k++)
		{
			RemnantSheets.Add(new Rectangle2D(data.RemnantSheets[k]));
		}
		UselessEntities.Clear();
		for (int l = 0; l <= data.UselessEntities.Count - 1; l++)
		{
			List<buEntity> list = new List<buEntity>();
			for (int m = 0; m <= data.UselessEntities[l].Count - 1; m++)
			{
				buEntity copiedEntity = new buEntity();
				buEntity.Copy(data.UselessEntities[l][m], ref copiedEntity);
				list.Add(copiedEntity);
			}
			UselessEntities.Add(list);
		}
		if (data.Cams != null && data.Cams.Count > 0)
		{
			Cams = new List<camTp>();
			camTp.CopyCam(data.Cams, ref Cams);
		}
		if (data.GCodeResult != null)
		{
			GCodeResult = new MachineGCodeExecutionResult(data.GCodeResult);
		}
	}

	public buNestedSheet(buNestingSheet data)
	{
		Count = data.MaterialData.Quantity;
		MaterialName = data.MaterialData.Name;
		MaterialWidth = data.MaterialData.Width;
		MaterialHeight = data.MaterialData.Height;
		MaterialThickness = data.MaterialData.Thickness;
		MaterialID = data.ID;
		Type = data.Type;
		ItemNo = data.MaterialData.ItemNo;
		SalesNo = data.MaterialData.SalesNo;
		Other = data.MaterialData.Other;
		Aux = data.MaterialData.Aux;
		UserData = data.MaterialData.UserData;
		MaterialID = data.ID;
		EntitiesGroup = new buEntitiesGroup(data.EntitiesGroup);
	}

	public static ArrayList ToDef(List<buNestedSheet> NestedSheets, int Space)
	{
		ArrayList arrayList = new ArrayList();
		arrayList.Add(buString5.SpaceChar(Space) + "<buNestedSheets>");
		for (int i = 0; i <= NestedSheets.Count - 1; i++)
		{
			string text = "";
			arrayList.AddRange(NestedSheets[i].ToDefAll("", 2 + Space, SerilizationMode5.MultiLine));
			text = arrayList[arrayList.Count - 1].ToString();
			arrayList.RemoveAt(arrayList.Count - 1);
			if (NestedSheets[i].EntitiesGroup.Outside.Entities.Count > 0)
			{
				arrayList.AddRange(buEntitiesGroup.ToDefGroup(NestedSheets[i].EntitiesGroup, Space + 4, "NestedSheet"));
			}
			if (NestedSheets[i].Parts.Count > 0)
			{
				arrayList.AddRange(buNestedPart.ToDef(NestedSheets[i].Parts, Space + 4));
			}
			arrayList.Add(text);
		}
		arrayList.Add(buString5.SpaceChar(Space) + "</buNestedSheets>");
		return arrayList;
	}

	public static void Decode(ArrayList AL, ref List<buNestedSheet> Sheets)
	{
		Sheets.Clear();
		Sheets = new List<buNestedSheet>();
		List<List<string>> CalcList = new List<List<string>>();
		buStatics.ListToSpecificList("<buNestedSheet>", "</buNestedSheet>", AddStartEndKey: true, AL, ref CalcList);
		for (int i = 0; i <= CalcList.Count - 1; i++)
		{
			ArrayList arrayList = new ArrayList();
			ArrayList CalcList2 = new ArrayList();
			List<string> CalcList3 = new List<string>();
			arrayList.AddRange(CalcList[i].ToArray());
			buNestedSheet buNestedSheet2 = new buNestedSheet();
			buSerilization5.Decode(arrayList, "", SerilizationMode5.MultiLine, buNestedSheet2);
			buStatics.ListToSpecificList("<buEntitiesGroupDataNestedSheet>", "</buEntitiesGroupDataNestedSheet>", AddStartEndKey: true, arrayList, ref CalcList3);
			buEntitiesGroup.Decode(CalcList3, ref buNestedSheet2.EntitiesGroup);
			buCall.buNestingCalc_0.CreatePointAndSolidFromEntityGroup(ref buNestedSheet2.EntitiesGroup);
			buStatics.ListToSpecificList("<buNestedParts>", "</buNestedParts>", AddStartEndKey: false, arrayList, ref CalcList2);
			if (CalcList2.Count > 0)
			{
				buNestedPart.Decode(CalcList2, ref buNestedSheet2.Parts);
			}
			Sheets.Add(buNestedSheet2);
			arrayList.Clear();
			CalcList3.Clear();
			CalcList2.Clear();
		}
		CalcList.Clear();
	}

	public static void Copy(buNestedSheet Base, ref buNestedSheet Copied)
	{
		Copied = new buNestedSheet(Base);
	}

	public static void Copy(List<buNestedSheet> Base, ref List<buNestedSheet> Copied)
	{
		Copied.Clear();
		Copied = new List<buNestedSheet>();
		for (int i = 0; i <= Base.Count - 1; i++)
		{
			buNestedSheet item = new buNestedSheet(Base[i]);
			Copied.Add(item);
		}
	}
}
