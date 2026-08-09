using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGeExtents2d_IntersectionStatus
{
	kIntersectUnknown = 0,
	kIntersectNot = 1,
	kIntersectOpIn = 2,
	kIntersectOpOut = 3,
	kIntersectOk = 4
}
