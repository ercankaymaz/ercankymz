using System.ComponentModel;

namespace ComponentFactory.Krypton.Toolkit;

public class HeaderGroupValuesPrimary : HeaderValuesBase
{
	private const string _defaultHeading = "Heading";

	[DefaultValue("Heading")]
	public override string Heading
	{
		get
		{
			return base.Heading;
		}
		set
		{
			base.Heading = value;
		}
	}

	public HeaderGroupValuesPrimary(NeedPaintHandler needPaint)
		: base(needPaint)
	{
	}

	protected override string GetHeadingDefault()
	{
		return "Heading";
	}

	protected override string GetDescriptionDefault()
	{
		return string.Empty;
	}
}
