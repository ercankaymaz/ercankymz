using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum WaflParamsContainmentType
{
	surfaceBoundary,
	userDefinedCurves,
	contactPoints,
	remainingStock
}
