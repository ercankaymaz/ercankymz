using System.Numerics;

namespace SixLabors.ImageSharp.ColorSpaces.Conversion;

public class ColorSpaceConverterOptions
{
	public CieXyz WhitePoint { get; set; } = CieLuv.DefaultWhitePoint;

	public CieXyz TargetLuvWhitePoint { get; set; } = CieLuv.DefaultWhitePoint;

	public CieXyz TargetLabWhitePoint { get; set; } = CieLab.DefaultWhitePoint;

	public CieXyz TargetHunterLabWhitePoint { get; set; } = HunterLab.DefaultWhitePoint;

	public RgbWorkingSpace TargetRgbWorkingSpace { get; set; } = Rgb.DefaultWorkingSpace;

	public IChromaticAdaptation? ChromaticAdaptation { get; set; } = new VonKriesChromaticAdaptation();

	public Matrix4x4 LmsAdaptationMatrix { get; set; } = CieXyzAndLmsConverter.DefaultTransformationMatrix;
}
