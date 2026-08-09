using System;

namespace Microsoft.Isam.Esent.Interop;

internal struct NATIVE_RSTMAP
{
	public IntPtr szDatabaseName;

	public IntPtr szNewDatabaseName;

	public void FreeHGlobal()
	{
		LibraryHelpers.MarshalFreeHGlobal(szDatabaseName);
		LibraryHelpers.MarshalFreeHGlobal(szNewDatabaseName);
	}
}
