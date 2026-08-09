using System;

namespace Microsoft.Isam.Esent.Interop;

[Flags]
public enum ColumndefGrbit
{
	None = 0,
	ColumnFixed = 1,
	ColumnTagged = 2,
	ColumnNotNULL = 4,
	ColumnVersion = 8,
	ColumnAutoincrement = 0x10,
	ColumnUpdatable = 0x20,
	ColumnMultiValued = 0x400,
	ColumnEscrowUpdate = 0x800,
	ColumnUnversioned = 0x1000,
	ColumnMaybeNull = 0x2000,
	ColumnFinalize = 0x4000,
	ColumnUserDefinedDefault = 0x8000,
	TTKey = 0x40,
	TTDescending = 0x80
}
