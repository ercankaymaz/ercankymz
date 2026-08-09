using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace buMutliTextbox;

public class VisualMarkerEventArgs : MouseEventArgs
{
	[CompilerGenerated]
	private Style style_0;

	[CompilerGenerated]
	private StyleVisualMarker styleVisualMarker_0;

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

	public StyleVisualMarker Marker
	{
		[CompilerGenerated]
		get
		{
			return styleVisualMarker_0;
		}
		[CompilerGenerated]
		private set
		{
			styleVisualMarker_0 = value;
		}
	}

	public VisualMarkerEventArgs(Style style, StyleVisualMarker marker, MouseEventArgs args)
		: base(args.Button, args.Clicks, args.X, args.Y, args.Delta)
	{
		Style = style;
		Marker = marker;
	}
}
