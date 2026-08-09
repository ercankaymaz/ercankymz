using System;

namespace Microsoft.Isam.Esent.Interop;

[Flags]
public enum ObjectInfoFlags
{
	None = 0,
	System = int.MinValue,
	TableFixedDDL = 0x40000000,
	TableTemplate = 0x20000000,
	TableDerived = 0x10000000,
	TableNoFixedVarColumnsInDerivedTables = 0x4000000
}
