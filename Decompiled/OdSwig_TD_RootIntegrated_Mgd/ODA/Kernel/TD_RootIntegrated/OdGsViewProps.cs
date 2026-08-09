namespace ODA.Kernel.TD_RootIntegrated;

public enum OdGsViewProps
{
	kVpID = 1,
	kVpRegenType = 2,
	kVpRenderMode = 4,
	kVpWorldToEye = 8,
	kVpPerspective = 16,
	kVpResolution = 32,
	kVpMaxDevForCircle = 64,
	kVpMaxDevForCurve = 128,
	kVpMaxDevForBoundary = 256,
	kVpMaxDevForIsoline = 512,
	kVpMaxDevForFacet = 1024,
	kVpCamLocation = 2048,
	kVpCamTarget = 4096,
	kVpCamUpVector = 8192,
	kVpCamViewDir = 16384,
	kVpViewport = 32768,
	kVpFrontBack = 65536,
	kVpFrozenLayers = 131072,
	kVpLtypeScaleMult = 262144,
	kVpLastPropBit = 262144,
	kVpAllProps = 524287
}
