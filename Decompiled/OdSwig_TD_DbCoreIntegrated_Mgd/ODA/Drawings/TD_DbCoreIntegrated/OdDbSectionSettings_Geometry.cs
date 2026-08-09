using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDbSectionSettings_Geometry
{
	kIntersectionBoundary = 1,
	kIntersectionFill = 2,
	kBackgroundGeometry = 4,
	kForegroundGeometry = 8,
	kCurveTangencyLines = 0x10
}
