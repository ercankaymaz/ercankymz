using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDb_Planarity
{
	kNonPlanar = 0,
	kPlanar = 1,
	kLinear = 2
}
