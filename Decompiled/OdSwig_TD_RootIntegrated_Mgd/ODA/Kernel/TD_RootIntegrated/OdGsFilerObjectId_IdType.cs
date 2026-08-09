using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGsFilerObjectId_IdType
{
	kNoId = 0,
	kPersistentId = 1,
	kTransientId = 2,
	kIndex = 3
}
