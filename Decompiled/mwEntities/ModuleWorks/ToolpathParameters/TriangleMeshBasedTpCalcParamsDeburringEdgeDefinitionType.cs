using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum TriangleMeshBasedTpCalcParamsDeburringEdgeDefinitionType
{
	DedtIncludeCurves = 0,
	DedtExcludeCurves = 1,
	[Obsolete("Deprecated since 2022.12. Please use DedtIncludeCurves instead!")]
	DedtUserDefined = 0,
	[Obsolete("Deprecated since 2022.12. Please use DedtExcludeCurves instead!")]
	DedtAutoDetect = 1
}
