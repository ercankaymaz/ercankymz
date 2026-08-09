using System;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[Flags]
[ComVisible(true)]
public enum AggregateBits
{
	Raw = 0,
	Calculated = 1,
	Interpolated = 2,
	DataSourceMask = 3,
	Partial = 4,
	ExtraData = 8,
	MultipleValues = 0x10
}
