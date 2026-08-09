namespace UglyToad.PdfPig.Graphics.Colors;

public interface IColor
{
	ColorSpace ColorSpace { get; }

	(double r, double g, double b) ToRGBValues();
}
