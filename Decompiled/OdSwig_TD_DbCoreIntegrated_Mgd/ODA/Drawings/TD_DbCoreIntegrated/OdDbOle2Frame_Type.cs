using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDbOle2Frame_Type
{
	kUnknown = 0,
	kLink = 1,
	kEmbedded = 2,
	kStatic = 3
}
