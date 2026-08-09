using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum TriangleMeshBasedTpCalcParamsMultiplePassesOrder
{
	MpoDefault,
	MpoFromTopOneway,
	MpoFromTopZigZag,
	MpoDirectZigZag
}
