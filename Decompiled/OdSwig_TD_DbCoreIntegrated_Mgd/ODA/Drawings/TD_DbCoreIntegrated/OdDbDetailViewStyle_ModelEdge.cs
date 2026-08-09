using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDbDetailViewStyle_ModelEdge
{
	kSmooth = 0,
	kSmoothWithBorder = 1,
	kSmoothWithConnectionLine = 2,
	kJagged = 3
}
