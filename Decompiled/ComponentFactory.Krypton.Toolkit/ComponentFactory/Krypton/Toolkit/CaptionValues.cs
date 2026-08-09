using System.ComponentModel;
using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public class CaptionValues : HeaderValuesBase
{
	private const string _defaultText = "Caption";

	[DefaultValue("")]
	public override string Description
	{
		get
		{
			return base.Description;
		}
		set
		{
			base.Description = value;
		}
	}

	public CaptionValues(NeedPaintHandler needPaint)
		: base(needPaint)
	{
	}

	protected override Image GetImageDefault()
	{
		return null;
	}

	protected override string GetHeadingDefault()
	{
		return "Caption";
	}

	protected override string GetDescriptionDefault()
	{
		return string.Empty;
	}
}
