using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGiPolyline_SegType
{
	kLine = 0,
	kArc = 1,
	kCoincident = 2,
	kPoint = 3,
	kEmpty = 4
}
