using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDbDimension_DimInspect
{
	kShapeRemove = 0,
	kShapeRound = 1,
	kShapeAngular = 2,
	kShapeNone = 4,
	kShapeLabel = 0x10,
	kShapeRate = 0x20
}
