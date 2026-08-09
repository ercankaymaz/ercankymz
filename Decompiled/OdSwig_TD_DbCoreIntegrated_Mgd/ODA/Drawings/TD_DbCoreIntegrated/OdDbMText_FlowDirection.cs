using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDbMText_FlowDirection
{
	kLtoR = 1,
	kRtoL = 2,
	kTtoB = 3,
	kBtoT = 4,
	kByStyle = 5
}
