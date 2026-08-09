using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDbHatch_HatchLoopType
{
	kDefault = 0,
	kExternal = 1,
	kPolyline = 2,
	kDerived = 4,
	kTextbox = 8,
	kOutermost = 0x10,
	kNotClosed = 0x20,
	kSelfIntersecting = 0x40,
	kTextIsland = 0x80,
	kDuplicate = 0x100,
	kIsAnnotative = 0x200,
	kDoesNotSupportScale = 0x400,
	kForceAnnoAllVisible = 0x800,
	kOrientToPaper = 0x1000,
	kIsAnnotativeBlock = 0x2000
}
