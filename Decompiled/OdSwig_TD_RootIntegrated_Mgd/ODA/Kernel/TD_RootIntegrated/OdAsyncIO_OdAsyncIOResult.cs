using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdAsyncIO_OdAsyncIOResult
{
	Success = 0,
	InProgress = 1,
	Cancelled = 2,
	CanNotOpenFile = 3,
	WrongFileDescriptor = 4,
	BufferPtrIsNull = 5,
	WrongRequestDescriptor = 6,
	UnknownError = 7
}
