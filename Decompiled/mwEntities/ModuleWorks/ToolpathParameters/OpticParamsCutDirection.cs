using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum OpticParamsCutDirection
{
	CdIn,
	CdOut,
	CdInOut,
	CdFromMinusXToPlusX,
	CdFromPlusXToMinusX,
	CdFromMinusYToPlusY,
	CdFromPlusYToMinusY,
	CdManual,
	CdFromMinusZToPlusZ,
	CdFromPlusZToMinusZ
}
