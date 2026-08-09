using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGiDgLinetypeDash_ShapeInfo_SymbolPosOnStroke
{
	kLsNoSymbol = 0,
	kLsAtOriginOfStroke = 1,
	kLsAtEndOfStroke = 2,
	kLsAtCenterOfStroke = 3
}
