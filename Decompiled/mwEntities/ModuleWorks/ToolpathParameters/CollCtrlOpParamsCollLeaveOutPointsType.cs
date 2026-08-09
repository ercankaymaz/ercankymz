using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum CollCtrlOpParamsCollLeaveOutPointsType
{
	LopDontTrimTp,
	LopTrimTpAfterFirstCol,
	LopTrimTpBeforeLastCol,
	LopTrimTpBetwFirstAndLastCol,
	LopTrimTpBeforeFirstCol,
	LopTrimTpAfterLastCol
}
