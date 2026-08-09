using System;

namespace UglyToad.PdfPig.PdfFonts;

public sealed class FontDetails
{
	public const int DefaultWeight = 500;

	public const int BoldWeight = 700;

	private readonly Lazy<FontDetails> _bold;

	public string Name { get; }

	public bool IsBold { get; }

	public int Weight { get; }

	public bool IsItalic { get; }

	public FontDetails(string? name, bool isBold, int weight, bool isItalic)
	{
		Name = name ?? string.Empty;
		IsBold = isBold;
		Weight = weight;
		IsItalic = isItalic;
		_bold = (isBold ? new Lazy<FontDetails>(() => this) : new Lazy<FontDetails>(() => new FontDetails(Name, isBold: true, Weight, IsItalic)));
	}

	public FontDetails AsBold()
	{
		return _bold.Value;
	}

	internal static FontDetails GetDefault(string? name = null)
	{
		return new FontDetails(name ?? string.Empty, isBold: false, 500, isItalic: false);
	}

	internal FontDetails WithName(string? name)
	{
		if (name == null)
		{
			return this;
		}
		return new FontDetails(name, IsBold, Weight, IsItalic);
	}

	public override string ToString()
	{
		string text = (IsBold ? " (bold)" : string.Empty);
		string text2 = (IsItalic ? " (italic)" : string.Empty);
		return Name + text + text2;
	}
}
