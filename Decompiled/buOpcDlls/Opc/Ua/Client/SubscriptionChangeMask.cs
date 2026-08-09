using System;
using System.Runtime.InteropServices;

namespace Opc.Ua.Client;

[Flags]
[ComVisible(true)]
public enum SubscriptionChangeMask
{
	None = 0,
	Created = 1,
	Deleted = 2,
	Modified = 4,
	ItemsAdded = 8,
	ItemsRemoved = 0x10,
	ItemsCreated = 0x20,
	ItemsDeleted = 0x40,
	ItemsModified = 0x80,
	Transferred = 0x100
}
