using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum TPRotationRoughParamsSortType
{
	TprSortByCompleteToolpath,
	TprSortByPasses,
	TprSortBySlices,
	TprSortByPartialToolpath
}
