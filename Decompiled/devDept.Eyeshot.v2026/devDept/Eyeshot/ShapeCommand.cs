namespace devDept.Eyeshot;

internal enum ShapeCommand : byte
{
	EndOfShape = 0,
	PenDown = 1,
	PenUp = 2,
	DivideVectorLengths = 3,
	MultiplyVectorLengths = 4,
	PushCurrentLocationOntoStack = 5,
	PopCurrentLocationFromStack = 6,
	DrawSubshapeNumberGiven = 7,
	XYDisplacement = 8,
	MultipleXYDisplacements = 9,
	OctantArc = 10,
	FractionalArc = 11,
	ArcDefinedByXYDisplacementAndBulge = 12,
	MultipleBulgeSpecifiedArcs = 13,
	ProcessNextCommandOnlyIfVerticalText = 14,
	RegularLine = 16
}
