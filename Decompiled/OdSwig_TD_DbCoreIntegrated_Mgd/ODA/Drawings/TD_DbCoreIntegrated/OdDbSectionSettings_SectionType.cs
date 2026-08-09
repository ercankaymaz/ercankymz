using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDbSectionSettings_SectionType
{
	kLiveSection = 1,
	k2dSection = 2,
	k3dSection = 4
}
