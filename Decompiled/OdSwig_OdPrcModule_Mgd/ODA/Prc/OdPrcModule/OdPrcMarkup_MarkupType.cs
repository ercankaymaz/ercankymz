using System;

namespace ODA.Prc.OdPrcModule;

[Flags]
public enum OdPrcMarkup_MarkupType
{
	kUnknown = 0,
	kText = 1,
	kDimension = 2,
	kArrow = 3,
	kBalloon = 4,
	kCircleCenter = 5,
	kCoordinate = 6,
	kDatum = 7,
	kFastener = 8,
	kGdt = 9,
	kLocator = 0xA,
	kMeasurementPoint = 0xB,
	kRoughness = 0xC,
	kWelding = 0xD,
	kTable = 0xF,
	kOther = 0x10
}
