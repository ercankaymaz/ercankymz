using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGsProperties_PropertiesType
{
	kViewport = 1,
	kBackground = 2,
	kVisualStyle = 4,
	kRenderEnvironment = 8,
	kRenderSettings = 0x10,
	kDeviceSimple = 0,
	kDeviceBackground = 3,
	kDeviceNormal = 7,
	kDeviceRender = 0x1F,
	kAll = 0x1F
}
