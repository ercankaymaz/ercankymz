using System;
using System.Collections.Generic;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class CutterProgramSettings : buSerilization
{
	public double MachineWidth = 3000.0;

	public double MachineHeight = 2000.0;

	public double RepeatCount = 1.0;

	public bool ShowMachineSize = true;

	public double PastalWidth = 10000.0;

	public string DrillLayerName = "13";

	public string MirrorLayerName = "6";

	public string RopeDirectionLayerName = "7";

	public string NotchInsideLayerName = "";

	public string NotchOutsideLayerName = "";

	public string ContourLayerName = "1";

	public string ContourRuleScaleLayerName = "1";

	public string NotchLayerName = "";

	public string InfoLayerName = "";

	public string PartInfoLayerName = "";

	public string ContourRefLayerName = "";

	public string InnerContourLayerName = "11";

	public string InnerContourNoCutLayerName = "8";

	public string InnerContourRefLayerName = "";

	public string InnerContourPloter1LayerName = "14";

	public string InnerContourPloter2LayerName = "87";

	public double DrillMainDaimeterValue = 5.0;

	public double DrillAuxDaimeterValue = 6.0;

	public bool NotchOnContour = true;

	public double MirrorCenterPointCatchGapDistance = 5.0;

	public bool AddAttribute = false;

	public bool ExtendEntitiesFromRuleFile = true;

	public double XScaleFactor = 0.254;

	public double YScaleFactor = 0.254;

	public double OffsetValue = 0.0;

	public bool DeleteOriginal = false;

	public CamClosedContourType OffsetType = CamClosedContourType.Outter;

	public bool LockLayers = false;

	public bool ShowOperationInfo = true;

	public static List<string> Captions = new List<string>();

	public CutterProgramSettings()
	{
	}

	public CutterProgramSettings(CutterProgramSettings data)
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

	public static void Copy(CutterProgramSettings Source, ref CutterProgramSettings Target)
	{
		Target = new CutterProgramSettings(Source);
	}

	public override string ToString()
	{
		return "";
	}
}
