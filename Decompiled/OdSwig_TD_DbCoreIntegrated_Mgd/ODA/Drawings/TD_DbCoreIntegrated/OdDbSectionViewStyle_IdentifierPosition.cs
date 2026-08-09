using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDbSectionViewStyle_IdentifierPosition
{
	kEndCuttingPlane = 0,
	kAboveDirectionArrowLine = 1,
	kAboveDirectionArrowSymbol = 2,
	kStartDirectionArrow = 3,
	kEndDirectionArrow = 4
}
