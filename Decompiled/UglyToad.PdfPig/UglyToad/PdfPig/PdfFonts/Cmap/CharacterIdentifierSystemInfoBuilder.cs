namespace UglyToad.PdfPig.PdfFonts.Cmap;

internal class CharacterIdentifierSystemInfoBuilder
{
	private string? registry;

	private string? ordering;

	private int supplement;

	public string? Registry
	{
		get
		{
			return registry;
		}
		set
		{
			registry = value;
			HasRegistry = true;
		}
	}

	public bool HasRegistry { get; private set; }

	public string? Ordering
	{
		get
		{
			return ordering;
		}
		set
		{
			ordering = value;
			HasOrdering = true;
		}
	}

	public bool HasOrdering { get; private set; }

	public int Supplement
	{
		get
		{
			return supplement;
		}
		set
		{
			supplement = value;
			HasSupplement = true;
		}
	}

	public bool HasSupplement { get; private set; }
}
