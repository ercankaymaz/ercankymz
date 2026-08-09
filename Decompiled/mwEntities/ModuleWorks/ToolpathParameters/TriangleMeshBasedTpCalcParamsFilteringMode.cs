using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum TriangleMeshBasedTpCalcParamsFilteringMode
{
	TmbFmByRegions,
	TmbFmByContours,
	TmbFmByRegionsAndContours
}
