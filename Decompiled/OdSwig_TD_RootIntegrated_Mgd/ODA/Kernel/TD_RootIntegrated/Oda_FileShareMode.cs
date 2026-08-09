using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum Oda_FileShareMode
{
	kShareDenyReadWrite = 0x10,
	kShareDenyWrite = 0x20,
	kShareDenyRead = 0x30,
	kShareDenyNo = 0x40
}
