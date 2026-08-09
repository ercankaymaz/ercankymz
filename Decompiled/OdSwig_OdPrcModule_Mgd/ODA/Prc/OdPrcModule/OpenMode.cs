using System;

namespace ODA.Prc.OdPrcModule;

[Flags]
public enum OpenMode
{
	kNotOpen = -1,
	kForRead = 0,
	kForWrite = 1,
	kForNotify = 2
}
