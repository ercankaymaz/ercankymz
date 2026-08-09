using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdEdgeTypeFlags_Enum
{
	kTangent = 1,
	kTangentShortend = 2,
	kInterference = 4,
	kBend = 8,
	kThread = 0x10,
	kPresentation = 0x20,
	kOuterBoundary = 0x40,
	kRegular = 0
}
