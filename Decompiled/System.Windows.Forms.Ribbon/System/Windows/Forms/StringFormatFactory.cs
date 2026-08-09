using System.Drawing;

namespace System.Windows.Forms;

internal static class StringFormatFactory
{
	public static StringFormat NearCenter()
	{
		return new StringFormat
		{
			Alignment = StringAlignment.Near,
			LineAlignment = StringAlignment.Center
		};
	}

	public static StringFormat NearCenterNoWrap(StringTrimming trim)
	{
		StringFormat stringFormat = NearCenter();
		stringFormat.Trimming = trim;
		stringFormat.FormatFlags |= StringFormatFlags.NoWrap;
		return stringFormat;
	}

	public static StringFormat CenterNearTrimChar()
	{
		return new StringFormat
		{
			Alignment = StringAlignment.Center,
			LineAlignment = StringAlignment.Near,
			Trimming = StringTrimming.Character
		};
	}

	public static StringFormat Center()
	{
		return new StringFormat
		{
			Alignment = StringAlignment.Center,
			LineAlignment = StringAlignment.Center
		};
	}

	public static StringFormat Center(StringTrimming trim)
	{
		StringFormat stringFormat = Center();
		stringFormat.Trimming = trim;
		return stringFormat;
	}

	public static StringFormat CenterNoWrap(StringTrimming trim)
	{
		StringFormat stringFormat = Center(trim);
		stringFormat.FormatFlags |= StringFormatFlags.NoWrap;
		return stringFormat;
	}

	public static StringFormat CenterNoWrapTrimEllipsis()
	{
		return CenterNoWrap(StringTrimming.EllipsisCharacter);
	}
}
