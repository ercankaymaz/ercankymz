using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum TriangleMeshBasedTpCalcParamsFilteringType
{
	TmbFtInscribedCircle = 0,
	TmbFtDiagonalLength = 1,
	TmbFtCircumscribedCircle = 2,
	TmbFtMinimumSegmentLength = 4,
	TmbFtContourLength = 5
}
