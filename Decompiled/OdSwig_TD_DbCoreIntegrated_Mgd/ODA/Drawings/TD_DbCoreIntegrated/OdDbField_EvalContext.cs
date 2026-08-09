using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDbField_EvalContext
{
	kOpen = 1,
	kSave = 2,
	kPlot = 4,
	kEtransmit = 8,
	kRegen = 0x10,
	kDemand = 0x20,
	kPreview = 0x40
}
