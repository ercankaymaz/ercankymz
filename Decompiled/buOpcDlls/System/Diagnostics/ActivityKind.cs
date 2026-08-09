using System.Runtime.InteropServices;

namespace System.Diagnostics;

[ComVisible(true)]
public enum ActivityKind
{
	Internal,
	Server,
	Client,
	Producer,
	Consumer
}
