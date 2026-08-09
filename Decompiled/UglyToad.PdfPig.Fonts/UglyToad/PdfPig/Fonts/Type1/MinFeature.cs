namespace UglyToad.PdfPig.Fonts.Type1;

public class MinFeature
{
	public int First { get; }

	public int Second { get; }

	public static MinFeature Default { get; } = new MinFeature(16, 16);

	public MinFeature(int first, int second)
	{
		First = first;
		Second = second;
	}

	public override string ToString()
	{
		return $"{{{First} {Second}}}";
	}
}
