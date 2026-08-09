using System.Globalization;

namespace ExCSS;

internal sealed class NumberToken : Token
{
	private static readonly char[] FloatIndicators = new char[3] { '.', 'e', 'E' };

	public bool IsInteger => base.Data.IndexOfAny(FloatIndicators) == -1;

	public int IntegerValue => int.Parse(base.Data, CultureInfo.InvariantCulture);

	public float Value => float.Parse(base.Data, CultureInfo.InvariantCulture);

	public NumberToken(string number, TextPosition position)
		: base(TokenType.Number, number, position)
	{
	}
}
