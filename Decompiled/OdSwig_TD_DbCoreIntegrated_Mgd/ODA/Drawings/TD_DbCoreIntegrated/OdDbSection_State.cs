using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDbSection_State
{
	kPlane = 1,
	kBoundary = 2,
	kVolume = 4
}
