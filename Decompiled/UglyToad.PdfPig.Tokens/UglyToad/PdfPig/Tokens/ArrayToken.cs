using System;
using System.Collections.Generic;
using System.Text;
using UglyToad.PdfPig.Core;

namespace UglyToad.PdfPig.Tokens;

public sealed class ArrayToken : IDataToken<IReadOnlyList<IToken>>, IToken, IEquatable<IToken>
{
	public IReadOnlyList<IToken> Data { get; }

	public int Length { get; }

	public IToken this[int i] => Data[i];

	public ArrayToken(IReadOnlyList<IToken> data)
	{
		if (data == null)
		{
			throw new ArgumentNullException("data");
		}
		List<IToken> list = new List<IToken>(data.Count);
		for (int i = 0; i < data.Count; i++)
		{
			IToken token = data[i];
			if (i >= 2 && token == OperatorToken.R && data[i - 1] is NumericToken numericToken && data[i - 2] is NumericToken numericToken2)
			{
				list.RemoveRange(list.Count - 2, 2);
				list.Add(new IndirectReferenceToken(new IndirectReference(numericToken2.Long, numericToken.Int)));
			}
			else
			{
				list.Add(token);
			}
		}
		Data = list;
		Length = Data.Count;
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder("[ ");
		for (int i = 0; i < Data.Count; i++)
		{
			IToken value = Data[i];
			stringBuilder.Append(value);
			if (i < Data.Count - 1)
			{
				stringBuilder.Append(',');
			}
			stringBuilder.Append(' ');
		}
		stringBuilder.Append(']');
		return stringBuilder.ToString();
	}

	public bool Equals(IToken obj)
	{
		if (this == obj)
		{
			return true;
		}
		if (!(obj is ArrayToken arrayToken))
		{
			return false;
		}
		if (arrayToken.Length != Length)
		{
			return false;
		}
		for (int i = 0; i < Length; i++)
		{
			if (!Data[i].Equals(arrayToken[i]))
			{
				return false;
			}
		}
		return true;
	}
}
