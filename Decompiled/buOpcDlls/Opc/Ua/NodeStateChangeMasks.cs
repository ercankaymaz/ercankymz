using System;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[Flags]
[ComVisible(true)]
public enum NodeStateChangeMasks
{
	None = 0,
	Children = 1,
	References = 2,
	Value = 4,
	NonValue = 8,
	Deleted = 0x10
}
