using System;

namespace ModuleWorks;

[Serializable]
public enum DisplayCoordinates
{
	DisplayAbsoluteWithoutTLC,
	DisplayAbsoluteWithTLC,
	DisplayRelative,
	DisplayOnlyBlock,
	DisplayBlockAndComment,
	DisplayRelativeWithTLC,
	DisplayGeometryAxisValueRTCPOFF,
	DisplayContactPointForWorkOffset,
	DisplayBaseCoordinateSystem
}
