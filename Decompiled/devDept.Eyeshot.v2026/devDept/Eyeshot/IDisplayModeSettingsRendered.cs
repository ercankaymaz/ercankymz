using devDept.Graphics;

namespace devDept.Eyeshot;

public interface IDisplayModeSettingsRendered : IDisplayModeSettings
{
	shadowType ShadowMode { get; }

	realisticShadowQualityType RealisticShadowQuality { get; }

	bool EnvironmentMapping { get; }
}
