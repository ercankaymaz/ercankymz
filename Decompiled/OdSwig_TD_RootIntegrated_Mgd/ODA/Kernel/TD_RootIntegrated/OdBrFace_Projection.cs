using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdBrFace_Projection
{
	kInheritProjection = 0,
	kPlanar = 1,
	kBox = 2,
	kCylinder = 3,
	kSphere = 4
}
