using System;

namespace ModuleWorks;

[Serializable]
[Flags]
public enum ToolMeshType
{
	CuttingPart = 1,
	NonCuttingPart = 2,
	Arbor = 4,
	Holder = 8,
	ToolWithoutHolder = 7,
	All = 0xF
}
