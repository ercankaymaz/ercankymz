using System;
using System.Reflection;

namespace buClass;

[Serializable]
public class ToolPageVisible : buSerilization
{
	public bool ShowTabData = true;

	public bool ShowTabCam = true;

	public bool ShowTabGeometry = true;

	public bool ShowTabColor = true;

	public bool ShowTabAux = true;

	public bool ShowTabPosition = true;

	public bool ShowTabLimit = true;

	public bool ShowName = true;

	public bool ShowNo = true;

	public bool ShowSector = true;

	public bool ShowHeightOffsetIndex = true;

	public bool ShowTag = true;

	public bool ShowPurpose = true;

	public bool ShowClone = true;

	public bool ShowMinLength = true;

	public bool ShowVector = true;

	public bool ShowGeometryType = true;

	public bool ShowStepOverride = true;

	public bool ShowCutOverride = true;

	public bool ShowOperationHeight = true;

	public bool ShowFeedVelocity = true;

	public bool ShowPlungeVelocity = true;

	public bool ShowFinishVelocity = true;

	public bool ShowAreaClearanceVelocity = true;

	public bool ShowSpindleSpeed = true;

	public bool ShowSpindleDirection = true;

	public bool ShowSafeDistance = true;

	public bool ShowSecondHeadHeight = true;

	public bool ShowOutputs = true;

	public bool ShowAir = true;

	public bool ShowWater = true;

	public bool ShowOil = true;

	public bool ShowInnerCooler = true;

	public bool ShowAngularPosition = true;

	public bool ShowSetPositionXYZ = true;

	public bool ShowSetPositionABC = true;

	public bool ShowOfsetXYZ = true;

	public bool ShowOffsetABC = true;

	public bool ShowPlaneLimits = true;

	public bool ShowAxisALimits = true;

	public bool ShowAxisBLimits = true;

	public bool ShowAxisCLimits = true;

	public bool ShowColorToolCuttings = true;

	public bool ShowColorToolBody = true;

	public bool ShowColorHolder = true;

	public bool ShowColorBody = true;

	public bool ShowColorCam = true;

	public bool ShowColorUpper = true;

	public bool ShowColorPlunge = true;

	public bool ShowColorLeave = true;

	public int PageWidth = 0;

	public int PageHeight = 0;

	public ToolPageVisible()
	{
	}

	public ToolPageVisible(ToolPageVisible data)
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
}
