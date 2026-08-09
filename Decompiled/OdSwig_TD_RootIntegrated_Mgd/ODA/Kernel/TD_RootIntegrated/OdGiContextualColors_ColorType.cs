using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGiContextualColors_ColorType
{
	kGridMajorLinesColor = 0,
	kGridMinorLinesColor = 1,
	kGridAxisLinesColor = 2,
	kLightGlyphsColor = 3,
	kLightHotspotColor = 4,
	kLightFalloffColor = 5,
	kLightStartLimitColor = 6,
	kLightEndLimitColor = 7,
	kLightShapeColor = 8,
	kLightDistanceColor = 9,
	kWebMeshColor = 0xA,
	kWebMeshMissingColor = 0xB,
	kCameraGlyphsColor = 0xC,
	kCameraFrustrumColor = 0xD,
	kCameraClippingColor = 0xE,
	kNumColors = 0xF
}
