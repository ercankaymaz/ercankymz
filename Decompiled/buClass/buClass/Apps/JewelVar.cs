using System;
using System.Reflection;
using System.Windows.Forms;

namespace buClass.Apps;

[Serializable]
public class JewelVar : buSerilization
{
	public jewelLimits Limits = new jewelLimits();

	public jewelMode JewelMode = new jewelMode();

	public jewelPositioningSettings PositionProp = new jewelPositioningSettings();

	public jewelMaterial JewelMaterialProp = new jewelMaterial();

	public jewelTangent JewelTangentProp = new jewelTangent();

	public camStep JewelSteppingProp = new camStep();

	public jewelSideOperation JewelSideProp = new jewelSideOperation();

	public jewelScale JewelScaleProp = new jewelScale();

	public jewelPunching JewelPunchProp = new jewelPunching();

	public jewelCam JewelCamProp = new jewelCam();

	public jewelCamItem JewelCamItemProp = new jewelCamItem();

	public jewelUserSettings UserSettings = new jewelUserSettings();

	public jewelSettings Settings = new jewelSettings();

	public CodesysCNCSets CNCSettings = new CodesysCNCSets();

	public CodesysAxCnc AxisXCncSetting = new CodesysAxCnc();

	public CodesysAxCnc AxisYCncSetting = new CodesysAxCnc();

	public CodesysAxCnc AxisZCncSetting = new CodesysAxCnc();

	public CodesysAxCnc AxisACncSetting = new CodesysAxCnc();

	public CodesysAxCnc AxisBCncSetting = new CodesysAxCnc();

	public CodesysAxCnc AxisCCncSetting = new CodesysAxCnc();

	public CodesysAxCnc AxisUCncSetting = new CodesysAxCnc();

	public CodesysAxCnc AxisVCncSetting = new CodesysAxCnc();

	public CodesysAxCnc AxisWCncSetting = new CodesysAxCnc();

	public string ModeName = "";

	public string ModePreparedBy = "";

	public bool OilEnable = false;

	public SortingNextGroupFindRulesType SortNextGRoupRules = SortingNextGroupFindRulesType.ClosestLength;

	public string PostPath = Application.StartupPath;

	public string PostName = "";

	public JewelVar()
	{
	}

	public JewelVar(JewelVar jewel)
	{
		object CopiedClass = new object();
		buSerilization.CopyClass(jewel, ref CopiedClass);
		if (this != null && CopiedClass != null && GetType() == CopiedClass.GetType())
		{
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
		JewelCamItemProp = new jewelCamItem(jewel.JewelCamItemProp);
		JewelCamProp = new jewelCam(jewel.JewelCamProp);
		JewelMaterialProp = new jewelMaterial(jewel.JewelMaterialProp);
		JewelMode = new jewelMode(jewel.JewelMode);
		JewelPunchProp = new jewelPunching(jewel.JewelPunchProp);
		JewelScaleProp = new jewelScale(jewel.JewelScaleProp);
		JewelSteppingProp = new camStep(jewel.JewelSteppingProp);
		JewelSideProp = new jewelSideOperation(jewel.JewelSideProp);
		JewelTangentProp = new jewelTangent(jewel.JewelTangentProp);
		Settings = new jewelSettings(jewel.Settings);
		UserSettings = new jewelUserSettings(jewel.UserSettings);
		PositionProp = new jewelPositioningSettings(jewel.PositionProp);
		CNCSettings = new CodesysCNCSets(jewel.CNCSettings);
		Limits = new jewelLimits(jewel.Limits);
		AxisACncSetting = new CodesysAxCnc(jewel.AxisACncSetting);
		AxisBCncSetting = new CodesysAxCnc(jewel.AxisBCncSetting);
		AxisCCncSetting = new CodesysAxCnc(jewel.AxisCCncSetting);
		AxisXCncSetting = new CodesysAxCnc(jewel.AxisXCncSetting);
		AxisYCncSetting = new CodesysAxCnc(jewel.AxisYCncSetting);
		AxisZCncSetting = new CodesysAxCnc(jewel.AxisZCncSetting);
		AxisUCncSetting = new CodesysAxCnc(jewel.AxisUCncSetting);
		AxisVCncSetting = new CodesysAxCnc(jewel.AxisVCncSetting);
		AxisWCncSetting = new CodesysAxCnc(jewel.AxisWCncSetting);
	}
}
