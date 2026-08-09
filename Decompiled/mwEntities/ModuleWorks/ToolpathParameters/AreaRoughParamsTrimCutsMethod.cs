using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum AreaRoughParamsTrimCutsMethod
{
	TcByCutLenPercentage,
	TcWhenCurvatureExceedsToolDia
}
