using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDbPolyline_SegType
{
	kLine = 0,
	kArc = 1,
	kCoincident = 2,
	kPoint = 3,
	kEmpty = 4
}
