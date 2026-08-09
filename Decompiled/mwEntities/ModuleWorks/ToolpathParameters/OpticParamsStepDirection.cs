using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum OpticParamsStepDirection
{
	SdFromMinusXToPlusX,
	SdFromPlusXToMinusX,
	SdFromMinusYToPlusY,
	SdFromPlusYToMinusY
}
