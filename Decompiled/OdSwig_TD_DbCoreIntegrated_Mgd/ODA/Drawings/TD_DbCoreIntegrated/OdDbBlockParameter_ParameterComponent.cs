using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDbBlockParameter_ParameterComponent
{
	Base = 0,
	End = 1,
	BaseXEndY = 2,
	EndXBaseY = 3,
	InvalidComponent = 4
}
