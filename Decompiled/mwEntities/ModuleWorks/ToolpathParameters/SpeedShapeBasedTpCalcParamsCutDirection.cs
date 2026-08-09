using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum SpeedShapeBasedTpCalcParamsCutDirection
{
	CdAuto,
	CdFromCenterAway,
	CdZigZag,
	CdInputCurve,
	CdReverseInputCurve,
	CdPlusX,
	CdMinusX,
	CdPlusY,
	CdMinusY
}
