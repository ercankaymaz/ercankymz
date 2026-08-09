using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDbField_EvalOption
{
	kDisable = 0,
	kOnOpen = 1,
	kOnSave = 2,
	kOnPlot = 4,
	kOnEtransmit = 8,
	kOnRegen = 0x10,
	kOnDemand = 0x20,
	kAutomatic = 0x3F
}
