using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum PathDirectionType
{
	automatic,
	climb,
	conventional,
	followCurveChaining,
	legacy
}
