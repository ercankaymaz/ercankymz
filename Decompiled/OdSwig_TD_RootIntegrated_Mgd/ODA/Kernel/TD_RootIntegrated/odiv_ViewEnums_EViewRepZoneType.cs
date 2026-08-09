using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum odiv_ViewEnums_EViewRepZoneType
{
	kZoneUndefined = -1,
	kZoneCenter = 0,
	kZoneRight = 1,
	kZoneTopRight = 2,
	kZoneTop = 3,
	kZoneTopLeft = 4,
	kZoneLeft = 5,
	kZoneBottomLeft = 6,
	kZoneBottom = 7,
	kZoneBottomRight = 8
}
