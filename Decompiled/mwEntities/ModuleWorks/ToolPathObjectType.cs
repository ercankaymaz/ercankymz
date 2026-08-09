using System;

namespace ModuleWorks;

[Serializable]
public enum ToolPathObjectType
{
	NoObject,
	DriveSurface,
	Curve,
	Surface,
	ToolPathSection,
	Slice
}
