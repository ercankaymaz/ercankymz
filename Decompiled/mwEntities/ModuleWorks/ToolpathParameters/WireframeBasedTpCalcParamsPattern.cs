using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum WireframeBasedTpCalcParamsPattern
{
	Wfb5axisProfiling,
	Wfb2axisRough,
	Wfb2axisProfile,
	WfbEngrave,
	WfbFace,
	WfbTrochoidal,
	WfbExtrude,
	Wfb2axisChamfer,
	Wfb3axisProfile,
	WfbTextEngrave,
	Wfb2axisFloorFinishing,
	Wfb6axisProfiling,
	Wfb2AxisContouring
}
