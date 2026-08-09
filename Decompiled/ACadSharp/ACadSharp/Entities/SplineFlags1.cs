using System;

namespace ACadSharp.Entities;

[Flags]
public enum SplineFlags1 : ushort
{
	None = 0,
	MethodFitPoints = 1,
	CVFrameShow = 2,
	Closed = 4,
	UseKnotParameter = 8
}
