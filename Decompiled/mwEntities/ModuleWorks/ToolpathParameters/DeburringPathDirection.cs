using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum DeburringPathDirection
{
	automatic,
	climb,
	conventional,
	followCurveChaining
}
