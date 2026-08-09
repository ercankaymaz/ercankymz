using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum Oda_FileAccessMode : long
{
	kFileRead = -2147483648L,
	kFileWrite = 0x40000000L,
	kFileTmp = 0x20000000L,
	kFileDelete = 0x10000000L,
	kNoFlushWhenClosed = 0x8000000L,
	kFileReadWrite = -1073741824L
}
