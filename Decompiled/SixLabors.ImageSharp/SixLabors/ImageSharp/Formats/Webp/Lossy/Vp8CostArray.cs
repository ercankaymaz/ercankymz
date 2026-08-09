namespace SixLabors.ImageSharp.Formats.Webp.Lossy;

internal class Vp8CostArray
{
	public ushort[] Costs { get; }

	public Vp8CostArray()
	{
		Costs = new ushort[68];
	}
}
