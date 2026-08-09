using System;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[Flags]
[ComVisible(true)]
public enum LimitBits
{
	None = 0,
	Low = 0x100,
	High = 0x200,
	Constant = 0x300
}
