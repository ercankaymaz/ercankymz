namespace SixLabors.ImageSharp.Formats.Webp.Lossy;

internal class Vp8BandProbas
{
	public Vp8ProbaArray[] Probabilities { get; }

	public Vp8BandProbas()
	{
		Probabilities = new Vp8ProbaArray[3];
		for (int i = 0; i < 3; i++)
		{
			Probabilities[i] = new Vp8ProbaArray();
		}
	}
}
