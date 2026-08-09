using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum CollCtrlOpBaseParamsCollStrategy
{
	CsRetractTool,
	CsMoveToolAlongVector,
	CsTiltToolAway,
	CsLeaveOutPoints,
	CsLeaveOutPlanes,
	CsKeepPointsColl,
	CsReportCollisions
}
