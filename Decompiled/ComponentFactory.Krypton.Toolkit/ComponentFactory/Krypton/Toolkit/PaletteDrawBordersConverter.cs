using System;
using System.ComponentModel;
using System.Globalization;
using System.Text;

namespace ComponentFactory.Krypton.Toolkit;

internal class PaletteDrawBordersConverter : EnumConverter
{
	public PaletteDrawBordersConverter()
		: base(typeof(PaletteDrawBorders))
	{
	}

	public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
	{
		if (destinationType == typeof(string))
		{
			PaletteDrawBorders paletteDrawBorders = (PaletteDrawBorders)value;
			if ((paletteDrawBorders & PaletteDrawBorders.Inherit) == PaletteDrawBorders.Inherit)
			{
				return "Inherit";
			}
			StringBuilder stringBuilder = new StringBuilder();
			if ((paletteDrawBorders & PaletteDrawBorders.Top) == PaletteDrawBorders.Top)
			{
				stringBuilder.Append("Top");
			}
			if ((paletteDrawBorders & PaletteDrawBorders.Bottom) == PaletteDrawBorders.Bottom)
			{
				if (stringBuilder.Length > 0)
				{
					stringBuilder.Append(",");
				}
				stringBuilder.Append("Bottom");
			}
			if ((paletteDrawBorders & PaletteDrawBorders.Left) == PaletteDrawBorders.Left)
			{
				if (stringBuilder.Length > 0)
				{
					stringBuilder.Append(",");
				}
				stringBuilder.Append("Left");
			}
			if ((paletteDrawBorders & PaletteDrawBorders.Right) == PaletteDrawBorders.Right)
			{
				if (stringBuilder.Length > 0)
				{
					stringBuilder.Append(",");
				}
				stringBuilder.Append("Right");
			}
			if (stringBuilder.Length == 0)
			{
				stringBuilder.Append("None");
			}
			return stringBuilder.ToString();
		}
		return base.ConvertTo(context, culture, value, destinationType);
	}

	public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
	{
		if (value is string)
		{
			string text = (string)value;
			PaletteDrawBorders paletteDrawBorders = PaletteDrawBorders.None;
			if (text.Contains("Inherit"))
			{
				paletteDrawBorders = PaletteDrawBorders.Inherit;
			}
			else if (!text.Contains("None"))
			{
				if (text.Contains("Top"))
				{
					paletteDrawBorders |= PaletteDrawBorders.Top;
				}
				if (text.Contains("Bottom"))
				{
					paletteDrawBorders |= PaletteDrawBorders.Bottom;
				}
				if (text.Contains("Left"))
				{
					paletteDrawBorders |= PaletteDrawBorders.Left;
				}
				if (text.Contains("Right"))
				{
					paletteDrawBorders |= PaletteDrawBorders.Right;
				}
			}
			return paletteDrawBorders;
		}
		return base.ConvertFrom(context, culture, value);
	}
}
