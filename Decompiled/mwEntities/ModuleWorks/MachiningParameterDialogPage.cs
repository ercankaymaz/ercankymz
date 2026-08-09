using System;

namespace ModuleWorks;

[Serializable]
[Flags]
public enum MachiningParameterDialogPage
{
	ToolPage = 1,
	ToolRates = 2,
	SurfacePaths = 4,
	TiltPage = 8,
	CollisionPage = 0x10,
	LinkPage = 0x20,
	RoughingPage = 0x40,
	UtilityPage = 0x80,
	MachinePage = 0x100,
	CornersPage = 0x200,
	MultiCutsPage = 0x400,
	MaterialPage = 0x800,
	DefineMachinePage = 0x1000,
	AllPages = 0x1FFF
}
