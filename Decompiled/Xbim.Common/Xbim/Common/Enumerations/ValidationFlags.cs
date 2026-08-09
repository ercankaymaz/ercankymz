using System;

namespace Xbim.Common.Enumerations;

[Flags]
public enum ValidationFlags
{
	None = 0,
	Properties = 2,
	Inverses = 4,
	EntityWhereClauses = 8,
	TypeWhereClauses = 0x10,
	All = -1
}
