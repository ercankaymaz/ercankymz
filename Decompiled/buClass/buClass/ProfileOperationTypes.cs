using System;

namespace buClass;

[Serializable]
public enum ProfileOperationTypes
{
	Circle = 0,
	Rectangle = 1,
	RoundRectangle = 2,
	Barrel = 3,
	Ellipse = 4,
	Hole = 5,
	Notch = 6,
	FreeDraw = 7,
	Text = 8,
	FromSelection = 9,
	Slot = 10,
	FromFile = 11,
	Cut = 12,
	CustomText = 13,
	Polygon = 14,
	FromFileList = 15,
	WireText = 16,
	Library = 17,
	Tapping = 18,
	UnKnown = 99
}
