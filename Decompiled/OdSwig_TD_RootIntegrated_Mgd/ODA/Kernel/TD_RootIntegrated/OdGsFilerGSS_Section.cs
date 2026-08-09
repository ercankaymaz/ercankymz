using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGsFilerGSS_Section
{
	kEOFSection = -1,
	kHeaderSection = 0,
	kDatabaseLinkSection = 1,
	kGsModuleSection = 2,
	kDeviceSection = 3,
	kClientDeviceSection = 4,
	kViewSection = 5,
	kClientViewSection = 6,
	kModelSection = 7,
	kClientModelSection = 8,
	kNodeSection = 9,
	kClientNodeSection = 0xA,
	kMetafileSection = 0xB,
	kClientMetafileSection = 0xC,
	kClientMaterialSection = 0xD,
	kBlockRefImplSection = 0xE,
	kLinkedDeviceSection = 0xF,
	kRenditionSection = 0x10,
	kRuntimeChangesSection = 0x11
}
