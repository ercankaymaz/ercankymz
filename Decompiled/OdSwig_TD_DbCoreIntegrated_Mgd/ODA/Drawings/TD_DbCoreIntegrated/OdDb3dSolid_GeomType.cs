using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDb3dSolid_GeomType
{
	eUndefinedType = 0,
	eSphere = 1,
	eTorus = 2,
	eCylinder = 3,
	eCone = 4,
	eBox = 5,
	eWedge = 6,
	ePyramid = 7,
	eExtrusion = 8,
	eSweep = 9,
	eLoft = 0xA,
	eRevolve = 0xB
}
