using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Graphics.Colors;

public readonly struct ResourceColorSpace
{
	public NameToken Name { get; }

	public IToken? Data { get; }

	internal ResourceColorSpace(NameToken name, IToken? data)
	{
		Name = name;
		Data = data;
	}

	internal ResourceColorSpace(NameToken name)
		: this(name, null)
	{
	}
}
