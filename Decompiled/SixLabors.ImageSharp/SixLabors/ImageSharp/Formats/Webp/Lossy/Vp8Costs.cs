namespace SixLabors.ImageSharp.Formats.Webp.Lossy;

internal class Vp8Costs
{
	public Vp8CostArray[] Costs { get; }

	public Vp8Costs()
	{
		Costs = new Vp8CostArray[3];
		for (int i = 0; i < 3; i++)
		{
			Costs[i] = new Vp8CostArray();
		}
	}
}
