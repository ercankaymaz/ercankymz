using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGsCullingPrimitive_PrimitiveType
{
	kPrimBBox = 0,
	kPrimBSphere = 1,
	kPrimOBBox = 2
}
