using System;

namespace ACadSharp.Entities;

[Flags]
public enum ViewportStatusFlags
{
	PerspectiveMode = 1,
	FrontClipping = 2,
	BackClipping = 4,
	UcsFollow = 8,
	FrontClipNotAtEye = 0x10,
	UcsIconVisibility = 0x20,
	UcsIconAtOrigin = 0x40,
	FastZoom = 0x80,
	SnapMode = 0x100,
	GridMode = 0x200,
	IsometricSnapStyle = 0x400,
	HidePlotMode = 0x800,
	IsoPairTop = 0x1000,
	IsoPairRight = 0x2000,
	ViewportZoomLocking = 0x4000,
	CurrentlyAlwaysEnabled = 0x8000,
	NonRectangularClipping = 0x10000,
	ViewportOff = 0x20000,
	DisplayGridBeyondDrawingLimits = 0x40000,
	AdaptiveGridDisplay = 0x80000,
	SubdivisionGridBelowSpacing = 0x100000
}
