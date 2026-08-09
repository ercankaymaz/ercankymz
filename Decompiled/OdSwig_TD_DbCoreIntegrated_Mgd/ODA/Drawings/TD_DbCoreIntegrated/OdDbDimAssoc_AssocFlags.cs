using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDbDimAssoc_AssocFlags
{
	kFirstPointRef = 1,
	kSecondPointRef = 2,
	kThirdPointRef = 4,
	kFourthPointRef = 8
}
