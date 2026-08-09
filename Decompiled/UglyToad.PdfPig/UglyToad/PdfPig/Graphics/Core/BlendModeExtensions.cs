namespace UglyToad.PdfPig.Graphics.Core;

internal static class BlendModeExtensions
{
	public static BlendMode? ToBlendMode(this string s)
	{
		return s switch
		{
			"Normal" => BlendMode.Normal, 
			"Compatible" => BlendMode.Normal, 
			"Multiply" => BlendMode.Multiply, 
			"Screen" => BlendMode.Screen, 
			"Darken" => BlendMode.Darken, 
			"Lighten" => BlendMode.Lighten, 
			"ColorDodge" => BlendMode.ColorDodge, 
			"ColorBurn" => BlendMode.ColorBurn, 
			"HardLight" => BlendMode.HardLight, 
			"SoftLight" => BlendMode.SoftLight, 
			"Overlay" => BlendMode.Overlay, 
			"Difference" => BlendMode.Difference, 
			"Exclusion" => BlendMode.Exclusion, 
			"Hue" => BlendMode.Hue, 
			"Saturation" => BlendMode.Saturation, 
			"Color" => BlendMode.Color, 
			"Luminosity" => BlendMode.Luminosity, 
			_ => null, 
		};
	}
}
