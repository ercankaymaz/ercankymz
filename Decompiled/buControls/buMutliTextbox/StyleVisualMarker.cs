using System.Drawing;
using System.Runtime.CompilerServices;

namespace buMutliTextbox;

public class StyleVisualMarker : VisualMarker
{
	[CompilerGenerated]
	private Style style_0;

	public Style Style
	{
		[CompilerGenerated]
		get
		{
			return style_0;
		}
		[CompilerGenerated]
		private set
		{
			style_0 = value;
		}
	}

	public StyleVisualMarker(Rectangle rectangle, Style style)
		: base(rectangle)
	{
		Style = style;
	}
}
