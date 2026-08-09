using System;

namespace ModuleWorks;

[Serializable]
[Flags]
public enum VerifierSurfaceInformation
{
	None = 0,
	Vertex = 1,
	Normal = 2,
	MoveId = 4,
	Deviation = 8,
	PartId = 0x10,
	ToolId = 0x20,
	All = 0x3F
}
