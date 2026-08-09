using System;

namespace ModuleWorks;

[Serializable]
public enum PostedMoveType
{
	Approach,
	EntryMacro,
	ConnectionNotClearanceArea,
	ConnectionClearanceArea,
	ExitMacro,
	Retract,
	Contour,
	RewindRetract,
	Rewind,
	RewindApproach,
	Dwell,
	ToolChange,
	Unused
}
