using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Graphics.Colors;
using UglyToad.PdfPig.Graphics.Core;

namespace UglyToad.PdfPig.Graphics;

public class CurrentGraphicsState : IDeepCloneable<CurrentGraphicsState>
{
	public PdfPath CurrentClippingPath { get; set; }

	public CurrentFontState FontState { get; set; } = new CurrentFontState();

	public double LineWidth { get; set; } = 1.0;

	public LineCapStyle CapStyle { get; set; }

	public LineJoinStyle JoinStyle { get; set; }

	public double MiterLimit { get; set; } = 10.0;

	public LineDashPattern LineDashPattern { get; set; } = LineDashPattern.Solid;

	public RenderingIntent RenderingIntent { get; set; } = RenderingIntent.RelativeColorimetric;

	public bool StrokeAdjustment { get; set; }

	public double AlphaConstantStroking { get; set; } = 1.0;

	public double AlphaConstantNonStroking { get; set; } = 1.0;

	public bool AlphaSource { get; set; }

	public SoftMask SoftMask { get; set; }

	public TransformationMatrix CurrentTransformationMatrix { get; set; } = TransformationMatrix.Identity;

	public IColorSpaceContext ColorSpaceContext { get; set; }

	public IColor CurrentStrokingColor { get; set; }

	public IColor CurrentNonStrokingColor { get; set; }

	public BlendMode BlendMode { get; set; }

	public bool Overprint { get; set; }

	public bool NonStrokingOverprint { get; set; }

	public double OverprintMode { get; set; }

	public double Flatness { get; set; } = 1.0;

	public double Smoothness { get; set; }

	public CurrentGraphicsState DeepClone()
	{
		return new CurrentGraphicsState
		{
			FontState = FontState?.DeepClone(),
			RenderingIntent = RenderingIntent,
			LineDashPattern = LineDashPattern,
			CurrentTransformationMatrix = CurrentTransformationMatrix,
			LineWidth = LineWidth,
			JoinStyle = JoinStyle,
			Overprint = Overprint,
			CapStyle = CapStyle,
			MiterLimit = MiterLimit,
			Flatness = Flatness,
			AlphaConstantStroking = AlphaConstantStroking,
			AlphaConstantNonStroking = AlphaConstantNonStroking,
			AlphaSource = AlphaSource,
			NonStrokingOverprint = NonStrokingOverprint,
			OverprintMode = OverprintMode,
			Smoothness = Smoothness,
			StrokeAdjustment = StrokeAdjustment,
			CurrentStrokingColor = CurrentStrokingColor,
			CurrentNonStrokingColor = CurrentNonStrokingColor,
			CurrentClippingPath = CurrentClippingPath,
			ColorSpaceContext = ColorSpaceContext?.DeepClone(),
			BlendMode = BlendMode,
			SoftMask = SoftMask
		};
	}
}
