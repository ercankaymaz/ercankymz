using System;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[Flags]
[ComVisible(true)]
public enum TransportChannelFeatures
{
	None = 0,
	Open = 1,
	BeginOpen = 2,
	Reconnect = 4,
	BeginReconnect = 8,
	BeginClose = 0x10,
	BeginSendRequest = 0x20,
	ReverseConnect = 0x40,
	SendRequestAsync = 0x80
}
