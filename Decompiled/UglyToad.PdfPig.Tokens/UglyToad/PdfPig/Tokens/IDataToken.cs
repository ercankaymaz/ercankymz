using System;

namespace UglyToad.PdfPig.Tokens;

public interface IDataToken<out T> : IToken, IEquatable<IToken>
{
	T Data { get; }
}
