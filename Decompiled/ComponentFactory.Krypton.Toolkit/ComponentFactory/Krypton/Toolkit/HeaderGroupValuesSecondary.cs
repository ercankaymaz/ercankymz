using System.ComponentModel;
using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public class HeaderGroupValuesSecondary : HeaderValuesBase
{
	private const string _defaultDescription = "Description";

	[DefaultValue("Description")]
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

	public HeaderGroupValuesSecondary(NeedPaintHandler needPaint)
		: base(needPaint)
	{
	}

	protected override Image GetImageDefault()
	{
		return null;
	}

	protected override string GetHeadingDefault()
	{
		return "Description";
	}

	protected override string GetDescriptionDefault()
	{
		return string.Empty;
	}
}
