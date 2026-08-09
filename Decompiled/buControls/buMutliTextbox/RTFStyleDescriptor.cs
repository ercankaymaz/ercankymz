using System.Drawing;
using System.Runtime.CompilerServices;

namespace buMutliTextbox;

public class RTFStyleDescriptor
{
	[CompilerGenerated]
	private Color color_0;

	[CompilerGenerated]
	private Color color_1;

	[CompilerGenerated]
	private string string_0;

	public Color ForeColor
	{
		[CompilerGenerated]
		get
		{
			return color_0;
		}
		[CompilerGenerated]
		set
		{
			color_0 = value;
		}
	}

	public Color BackColor
	{
		[CompilerGenerated]
		get
		{
			return color_1;
		}
		[CompilerGenerated]
		set
		{
			color_1 = value;
		}
	}

	public string AdditionalTags
	{
		[CompilerGenerated]
		get
		{
			return string_0;
		}
		[CompilerGenerated]
		set
		{
			string_0 = value;
		}
	}
}
