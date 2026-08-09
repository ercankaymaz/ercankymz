using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum RoughingParamsSortBy
{
	CompleteToolpath,
	Passes,
	Slices,
	PartialToolpath
}
