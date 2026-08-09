using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGiMapper_Projection
{
	kInheritProjection = 0,
	kPlanar = 1,
	kBox = 2,
	kCylinder = 3,
	kSphere = 4,
	kDgnParametric = 0x32,
	kDgnPlanar = 0x33,
	kDgnCylinder = 0x34,
	kDgnCylinderCapped = 0x35,
	kDgnSphere = 0x36
}
