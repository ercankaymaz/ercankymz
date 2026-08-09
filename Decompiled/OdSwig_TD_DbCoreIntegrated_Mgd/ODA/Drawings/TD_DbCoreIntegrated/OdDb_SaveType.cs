using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDb_SaveType
{
	kDwg = 0,
	kDxf = 1,
	kDxb = 2,
	kUnknown = -1
}
