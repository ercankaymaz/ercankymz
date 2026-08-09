namespace ComponentFactory.Krypton.Toolkit;

public class HeaderValues : HeaderValuesBase
{
	private const string _defaultHeading = "Heading";

	private const string _defaultDescription = "Description";

	public HeaderValues(NeedPaintHandler needPaint)
		: base(needPaint)
	{
	}

	protected override string GetHeadingDefault()
	{
		return "Heading";
	}

	protected override string GetDescriptionDefault()
	{
		return "Description";
	}
}
