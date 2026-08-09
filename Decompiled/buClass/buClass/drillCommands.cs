using System;

namespace buClass;

[Serializable]
public enum drillCommands
{
	SingleHole = 0,
	VerticalHoles = 1,
	HorizontalHoles = 2,
	HorizontalLineHoles = 3,
	VerticalLineHoles = 4,
	ThreeHole = 5,
	InclineHoles = 6,
	CutVertical = 100,
	CutHorizontal = 101,
	CutFree = 102,
	CutVerticalLine = 103,
	CutHorizontalLine = 104,
	DrawingRectangle = 200,
	DrawingCircle = 201,
	DrawingEllipse = 202,
	DrawingPoliygon = 203,
	DrawingKeyHole = 204,
	DrawingSlot = 205,
	DrawingStar = 206,
	DrawingContour = 207,
	ProfilingSingleCorner = 300,
	ProfilingAllCorner = 301,
	ProfilingSingleRoundCorner = 302,
	ProfilingMiddleHorizontalPocket = 303,
	ProfilingMiddleVerticalPocket = 304,
	ProfilingMiddleHorizontalCurve = 305,
	ProfilingMiddleVerticalCurve = 306,
	Engraving = 400
}
