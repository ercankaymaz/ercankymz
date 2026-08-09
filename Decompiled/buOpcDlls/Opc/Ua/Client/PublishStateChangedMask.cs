using System;
using System.Runtime.InteropServices;

namespace Opc.Ua.Client;

[Flags]
[ComVisible(true)]
public enum PublishStateChangedMask
{
	None = 0,
	Stopped = 1,
	Recovered = 2,
	KeepAlive = 4,
	Republish = 8,
	Transferred = 0x10,
	Timeout = 0x20
}
