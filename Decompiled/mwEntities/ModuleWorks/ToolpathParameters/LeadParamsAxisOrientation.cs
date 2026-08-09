using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum LeadParamsAxisOrientation
{
	Fixed = 1,
	Tangential,
	Tilted,
	OrthoToCutDirection,
	Automatic,
	UserDefinedDirection,
	NormalToLead,
	LastTypeAo
}
