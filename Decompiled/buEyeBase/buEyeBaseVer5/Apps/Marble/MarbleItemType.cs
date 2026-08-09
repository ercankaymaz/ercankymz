using System;

namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public enum MarbleItemType
{
	None,
	VerticalCut,
	HorizontalCut,
	Shape,
	Engraving,
	Profiling,
	Text,
	Library,
	Sweep,
	Drill,
	Contour,
	Columns,
	LatheHorizontal,
	LatheVertical,
	ProfileCurve,
	AirDry,
	MaterialClean,
	SingleCut,
	Editor,
	GCode,
	Countertop,
	Slices,
	SawHorizontalMillingRough,
	SawVerticalMillingRough,
	EasyDraw,
	PocketByDrill,
	SawHorizontalMillingFinish,
	SawVerticalMillingFinish,
	TextWireframe,
	Text3D,
	Milling5AxisRotary,
	Milling5AxisFlat,
	HorizontalVerticalCut,
	Shape3D,
	Cavity,
	Tap,
	CutRemainMaterial,
	VacuumAdd
}
