using System;
using System.Globalization;

namespace UglyToad.PdfPig.Tokens;

public class NumericToken : IDataToken<double>, IToken, IEquatable<IToken>
{
	public static readonly NumericToken MinusOne = new NumericToken(-1);

	public static readonly NumericToken Zero = new NumericToken(0);

	public static readonly NumericToken One = new NumericToken(1);

	public static readonly NumericToken Two = new NumericToken(2);

	public static readonly NumericToken Three = new NumericToken(3);

	public static readonly NumericToken Four = new NumericToken(4);

	public static readonly NumericToken Five = new NumericToken(5);

	public static readonly NumericToken Six = new NumericToken(6);

	public static readonly NumericToken Seven = new NumericToken(7);

	public static readonly NumericToken Eight = new NumericToken(8);

	public static readonly NumericToken Nine = new NumericToken(9);

	public static readonly NumericToken Ten = new NumericToken(10);

	public static readonly NumericToken Eleven = new NumericToken(11);

	public static readonly NumericToken Twelve = new NumericToken(12);

	public static readonly NumericToken Thirteen = new NumericToken(13);

	public static readonly NumericToken Fourteen = new NumericToken(14);

	public static readonly NumericToken Fifteen = new NumericToken(15);

	public static readonly NumericToken Sixteen = new NumericToken(16);

	public static readonly NumericToken Seventeen = new NumericToken(17);

	public static readonly NumericToken Eighteen = new NumericToken(18);

	public static readonly NumericToken Nineteen = new NumericToken(19);

	public static readonly NumericToken Twenty = new NumericToken(20);

	public static readonly NumericToken OneHundred = new NumericToken(100);

	public static readonly NumericToken FiveHundred = new NumericToken(500);

	public static readonly NumericToken OneThousand = new NumericToken(1000);

	public double Data { get; }

	public bool HasDecimalPlaces => !Math.Floor(Data).Equals(Data);

	public int Int => (int)Data;

	public long Long => (long)Data;

	public double Double => Data;

	public NumericToken(int value)
	{
		Data = value;
	}

	public NumericToken(double value)
	{
		Data = value;
	}

	public bool Equals(IToken obj)
	{
		if (this == obj)
		{
			return true;
		}
		if (!(obj is NumericToken numericToken))
		{
			return false;
		}
		return Data.Equals(numericToken.Data);
	}

	public override int GetHashCode()
	{
		return Data.GetHashCode();
	}

	public override string ToString()
	{
		return Data.ToString(NumberFormatInfo.InvariantInfo);
	}
}
