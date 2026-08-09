using SixLabors.ImageSharp.ColorSpaces.Conversion;

namespace SixLabors.ImageSharp.ColorSpaces;

public static class RgbWorkingSpaces
{
	public static readonly RgbWorkingSpace SRgb = new SRgbWorkingSpace(Illuminants.D65, new RgbPrimariesChromaticityCoordinates(new CieXyChromaticityCoordinates(0.64f, 0.33f), new CieXyChromaticityCoordinates(0.3f, 0.6f), new CieXyChromaticityCoordinates(0.15f, 0.06f)));

	public static readonly RgbWorkingSpace SRgbSimplified = new GammaWorkingSpace(2.2f, Illuminants.D65, new RgbPrimariesChromaticityCoordinates(new CieXyChromaticityCoordinates(0.64f, 0.33f), new CieXyChromaticityCoordinates(0.3f, 0.6f), new CieXyChromaticityCoordinates(0.15f, 0.06f)));

	public static readonly RgbWorkingSpace Rec709 = new Rec709WorkingSpace(Illuminants.D65, new RgbPrimariesChromaticityCoordinates(new CieXyChromaticityCoordinates(0.64f, 0.33f), new CieXyChromaticityCoordinates(0.3f, 0.6f), new CieXyChromaticityCoordinates(0.15f, 0.06f)));

	public static readonly RgbWorkingSpace Rec2020 = new Rec2020WorkingSpace(Illuminants.D65, new RgbPrimariesChromaticityCoordinates(new CieXyChromaticityCoordinates(0.708f, 0.292f), new CieXyChromaticityCoordinates(0.17f, 0.797f), new CieXyChromaticityCoordinates(0.131f, 0.046f)));

	public static readonly RgbWorkingSpace ECIRgbv2 = new LWorkingSpace(Illuminants.D50, new RgbPrimariesChromaticityCoordinates(new CieXyChromaticityCoordinates(0.67f, 0.33f), new CieXyChromaticityCoordinates(0.21f, 0.71f), new CieXyChromaticityCoordinates(0.14f, 0.08f)));

	public static readonly RgbWorkingSpace AdobeRgb1998 = new GammaWorkingSpace(2.2f, Illuminants.D65, new RgbPrimariesChromaticityCoordinates(new CieXyChromaticityCoordinates(0.64f, 0.33f), new CieXyChromaticityCoordinates(0.21f, 0.71f), new CieXyChromaticityCoordinates(0.15f, 0.06f)));

	public static readonly RgbWorkingSpace ApplesRgb = new GammaWorkingSpace(1.8f, Illuminants.D65, new RgbPrimariesChromaticityCoordinates(new CieXyChromaticityCoordinates(0.625f, 0.34f), new CieXyChromaticityCoordinates(0.28f, 0.595f), new CieXyChromaticityCoordinates(0.155f, 0.07f)));

	public static readonly RgbWorkingSpace BestRgb = new GammaWorkingSpace(2.2f, Illuminants.D50, new RgbPrimariesChromaticityCoordinates(new CieXyChromaticityCoordinates(0.7347f, 0.2653f), new CieXyChromaticityCoordinates(0.215f, 0.775f), new CieXyChromaticityCoordinates(0.13f, 0.035f)));

	public static readonly RgbWorkingSpace BetaRgb = new GammaWorkingSpace(2.2f, Illuminants.D50, new RgbPrimariesChromaticityCoordinates(new CieXyChromaticityCoordinates(0.6888f, 0.3112f), new CieXyChromaticityCoordinates(0.1986f, 0.7551f), new CieXyChromaticityCoordinates(0.1265f, 0.0352f)));

	public static readonly RgbWorkingSpace BruceRgb = new GammaWorkingSpace(2.2f, Illuminants.D65, new RgbPrimariesChromaticityCoordinates(new CieXyChromaticityCoordinates(0.64f, 0.33f), new CieXyChromaticityCoordinates(0.28f, 0.65f), new CieXyChromaticityCoordinates(0.15f, 0.06f)));

	public static readonly RgbWorkingSpace CIERgb = new GammaWorkingSpace(2.2f, Illuminants.E, new RgbPrimariesChromaticityCoordinates(new CieXyChromaticityCoordinates(0.735f, 0.265f), new CieXyChromaticityCoordinates(0.274f, 0.717f), new CieXyChromaticityCoordinates(0.167f, 0.009f)));

	public static readonly RgbWorkingSpace ColorMatchRgb = new GammaWorkingSpace(1.8f, Illuminants.D50, new RgbPrimariesChromaticityCoordinates(new CieXyChromaticityCoordinates(0.63f, 0.34f), new CieXyChromaticityCoordinates(0.295f, 0.605f), new CieXyChromaticityCoordinates(0.15f, 0.075f)));

	public static readonly RgbWorkingSpace DonRgb4 = new GammaWorkingSpace(2.2f, Illuminants.D50, new RgbPrimariesChromaticityCoordinates(new CieXyChromaticityCoordinates(0.696f, 0.3f), new CieXyChromaticityCoordinates(0.215f, 0.765f), new CieXyChromaticityCoordinates(0.13f, 0.035f)));

	public static readonly RgbWorkingSpace EktaSpacePS5 = new GammaWorkingSpace(2.2f, Illuminants.D50, new RgbPrimariesChromaticityCoordinates(new CieXyChromaticityCoordinates(0.695f, 0.305f), new CieXyChromaticityCoordinates(0.26f, 0.7f), new CieXyChromaticityCoordinates(0.11f, 0.005f)));

	public static readonly RgbWorkingSpace NTSCRgb = new GammaWorkingSpace(2.2f, Illuminants.C, new RgbPrimariesChromaticityCoordinates(new CieXyChromaticityCoordinates(0.67f, 0.33f), new CieXyChromaticityCoordinates(0.21f, 0.71f), new CieXyChromaticityCoordinates(0.14f, 0.08f)));

	public static readonly RgbWorkingSpace PALSECAMRgb = new GammaWorkingSpace(2.2f, Illuminants.D65, new RgbPrimariesChromaticityCoordinates(new CieXyChromaticityCoordinates(0.64f, 0.33f), new CieXyChromaticityCoordinates(0.29f, 0.6f), new CieXyChromaticityCoordinates(0.15f, 0.06f)));

	public static readonly RgbWorkingSpace ProPhotoRgb = new GammaWorkingSpace(1.8f, Illuminants.D50, new RgbPrimariesChromaticityCoordinates(new CieXyChromaticityCoordinates(0.7347f, 0.2653f), new CieXyChromaticityCoordinates(0.1596f, 0.8404f), new CieXyChromaticityCoordinates(0.0366f, 0.0001f)));

	public static readonly RgbWorkingSpace SMPTECRgb = new GammaWorkingSpace(2.2f, Illuminants.D65, new RgbPrimariesChromaticityCoordinates(new CieXyChromaticityCoordinates(0.63f, 0.34f), new CieXyChromaticityCoordinates(0.31f, 0.595f), new CieXyChromaticityCoordinates(0.155f, 0.07f)));

	public static readonly RgbWorkingSpace WideGamutRgb = new GammaWorkingSpace(2.2f, Illuminants.D50, new RgbPrimariesChromaticityCoordinates(new CieXyChromaticityCoordinates(0.735f, 0.265f), new CieXyChromaticityCoordinates(0.115f, 0.826f), new CieXyChromaticityCoordinates(0.157f, 0.018f)));
}
