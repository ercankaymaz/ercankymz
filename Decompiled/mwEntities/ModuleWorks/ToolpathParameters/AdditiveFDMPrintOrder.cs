using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum AdditiveFDMPrintOrder
{
	Skirt,
	Brim,
	Wall,
	Infill,
	InfillTopLayer,
	InfillBottomLayer,
	Support,
	SupportInterfaceFloor,
	SupportInterfaceRoof,
	Ironing,
	OuterWall,
	InnerWall
}
