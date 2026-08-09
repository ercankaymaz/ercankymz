using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDb_LoftParamType
{
	kLoftNoParam = 0,
	kLoftNoTwist = 1,
	kLoftAlignDirection = 2,
	kLoftSimplify = 4,
	kLoftClose = 8,
	kLoftPeriodic = 0x10,
	kLoftDefault = 7
}
