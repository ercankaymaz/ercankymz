using System;

namespace ModuleWorks;

[Serializable]
[Flags]
public enum ToolPathCollisionReport
{
	NoCollision = 0,
	ToolTipAndCheckSurface = 1,
	ToolTipAndPartSurface = 2,
	ToolShaftAndCheckSurface = 4,
	ToolShaftAndPartSurface = 8,
	ToolArborAndCheckSurface = 0x10,
	ToolArborAndPartSurface = 0x20,
	ToolHolderAndCheckSurface = 0x40,
	ToolHolderAndPartSurface = 0x80,
	ToolExtenderAndCheckSurface = 0x100,
	ToolExtenderAndPartSurface = 0x200,
	FullCollision = 0x3FF
}
