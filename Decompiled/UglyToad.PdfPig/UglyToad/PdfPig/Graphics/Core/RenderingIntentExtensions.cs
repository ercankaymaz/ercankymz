namespace UglyToad.PdfPig.Graphics.Core;

internal static class RenderingIntentExtensions
{
	public static RenderingIntent ToRenderingIntent(this string s)
	{
		return s switch
		{
			"AbsoluteColorimetric" => RenderingIntent.AbsoluteColorimetric, 
			"RelativeColorimetric" => RenderingIntent.RelativeColorimetric, 
			"Saturation" => RenderingIntent.Saturation, 
			"Perceptual" => RenderingIntent.Perceptual, 
			_ => RenderingIntent.RelativeColorimetric, 
		};
	}
}
