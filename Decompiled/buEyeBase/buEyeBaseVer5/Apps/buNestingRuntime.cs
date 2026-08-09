using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using buClass;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class buNestingRuntime : buSerilization5
{
	public int MaxNestingTimeSec = 10;

	public nestResultSendType NestExecutionTo = nestResultSendType.Job;

	public nestedCreateType nestedResultCreateType = nestedCreateType.Draw;

	public nestedCreateSheetType nestedResultSheetType = nestedCreateSheetType.All;

	public bool CamCuttingEnable = true;

	public bool CamDerzEnable = true;

	public bool CamHoleEnable = true;

	public bool CamTextEnable = true;

	public bool CamPocketCircularEnable = true;

	public bool CamPocketFlatEnable = true;

	public bool CamCutInsideEnable = false;

	public bool CamCutOutsideEnable = false;

	public bool CamCutCenterEnable = false;

	public bool OldResultImportNestedResult = true;

	public bool OldResultImportNestingSheets = true;

	public bool OldResultImportNestingParts = true;

	public bool OldResultImportNestingClearSheets = false;

	public bool OldResultImportNestingClearParts = false;

	public nestOldResultPosition OldResultLocation = nestOldResultPosition.ToJob;

	public bool ShowSheetAddItemNoParameter = false;

	public bool ShowSheetAddThicknessParameter = false;

	public bool ShowSheetAddSalesNoParameter = false;

	public bool ShowSheetAddOtherParameter = false;

	public bool ShowSheetAddAuxParameter = false;

	public bool ShowPartAddItemNoParameter = false;

	public bool ShowPartAddSalesNoParameter = false;

	public bool ShowPartAddOtherParameter = false;

	public bool ShowPartAddAuxParameter = false;

	public bool ShowItemNoNestingJobPage = false;

	public bool ShowPartOffsetJobPage = false;

	public bool AddCsvTypeToAddPartFromFile = false;

	public nestCsvPartImportType NestingCsvTypeOpenModeForAddPart = nestCsvPartImportType.Mode2_NameWidthHeightCount;

	public bool NestingResultDoCam = false;

	public bool NestingResultDraw = false;

	public bool NestingResultCsv = false;

	public bool NestingResultSaveFile = false;

	public bool NestingResultPdfFile = false;

	public bool NestingResultDxfFile = false;

	public bool NestingResultHpglFile = false;

	public bool NestingResultIsoFile = false;

	public string LastNestedProject = "";

	public bool ShowNestResultPageAsFullScreen = true;

	public string NestingJobName = "Job";

	public string NestingJobExplanation = "";

	public string pathNesting = Application.StartupPath;

	public string pathNestingPart = Application.StartupPath;

	public string pathNestingSheet = Application.StartupPath;

	public static List<string> Captions = new List<string>();

	public buNestingRuntime()
	{
	}

	public buNestingRuntime(buNestingRuntime data)
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
}
