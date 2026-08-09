using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDbSectionSettings_Generation
{
	kSourceAllObjects = 1,
	kSourceSelectedObjects = 2,
	kDestinationNewBlock = 0x10,
	kDestinationReplaceBlock = 0x20,
	kDestinationFile = 0x40
}
