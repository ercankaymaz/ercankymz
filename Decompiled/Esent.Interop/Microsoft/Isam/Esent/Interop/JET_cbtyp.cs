using System;

namespace Microsoft.Isam.Esent.Interop;

[Flags]
public enum JET_cbtyp
{
	Null = 0,
	Finalize = 1,
	BeforeInsert = 2,
	AfterInsert = 4,
	BeforeReplace = 8,
	AfterReplace = 0x10,
	BeforeDelete = 0x20,
	AfterDelete = 0x40,
	UserDefinedDefaultValue = 0x80,
	OnlineDefragCompleted = 0x100,
	FreeCursorLS = 0x200,
	FreeTableLS = 0x400
}
