using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum ToolAxisControlParamsContactPointProfileSegment
{
	[Obsolete("Deprecated since 2021.04. Please use FullProfile instead!")]
	CdOnAllContours = 0,
	[Obsolete("Deprecated since 2021.04. Please use Barrel instead!")]
	CdOnSingleContours = 1,
	FullProfile = 0,
	Barrel = 1,
	ConvexTip = 2,
	FlatnessDiameter = 3,
	TipRadius = 4,
	UpperRadius = 5,
	ConeSection = 6,
	Cylinder = 7,
	CurvedProfile = 8
}
