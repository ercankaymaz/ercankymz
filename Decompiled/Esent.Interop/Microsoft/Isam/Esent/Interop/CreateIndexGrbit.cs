using System;

namespace Microsoft.Isam.Esent.Interop;

[Flags]
public enum CreateIndexGrbit
{
	None = 0,
	IndexUnique = 1,
	IndexPrimary = 2,
	IndexDisallowNull = 4,
	IndexIgnoreNull = 8,
	IndexIgnoreAnyNull = 0x20,
	IndexIgnoreFirstNull = 0x40,
	IndexLazyFlush = 0x80,
	IndexEmpty = 0x100,
	IndexUnversioned = 0x200,
	IndexSortNullsHigh = 0x400
}
