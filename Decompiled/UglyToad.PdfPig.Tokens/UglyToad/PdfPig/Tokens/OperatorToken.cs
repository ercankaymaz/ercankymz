using System;
using System.Collections.Generic;

namespace UglyToad.PdfPig.Tokens;

public class OperatorToken : IDataToken<string>, IToken, IEquatable<IToken>
{
	private static readonly object Lock = new object();

	private static readonly Dictionary<string, string> PooledNames = new Dictionary<string, string>();

	public static readonly OperatorToken Bt = new OperatorToken("BT");

	public static readonly OperatorToken Def = new OperatorToken("def");

	public static readonly OperatorToken Dict = new OperatorToken("dict");

	public static readonly OperatorToken Dup = new OperatorToken("dup");

	public static readonly OperatorToken Eexec = new OperatorToken("eexec");

	public static readonly OperatorToken EndObject = new OperatorToken("endobj");

	public static readonly OperatorToken EndStream = new OperatorToken("endstream");

	public static readonly OperatorToken Et = new OperatorToken("ET");

	public static readonly OperatorToken For = new OperatorToken("for");

	public static readonly OperatorToken N = new OperatorToken("n");

	public static readonly OperatorToken Put = new OperatorToken("put");

	public static readonly OperatorToken QPop = new OperatorToken("Q");

	public static readonly OperatorToken QPush = new OperatorToken("q");

	public static readonly OperatorToken R = new OperatorToken("R");

	public static readonly OperatorToken Re = new OperatorToken("re");

	public static readonly OperatorToken Readonly = new OperatorToken("readonly");

	public static readonly OperatorToken StartObject = new OperatorToken("obj");

	public static readonly OperatorToken StartStream = new OperatorToken("stream");

	public static readonly OperatorToken Tf = new OperatorToken("Tf");

	public static readonly OperatorToken WStar = new OperatorToken("W*");

	public static readonly OperatorToken Xref = new OperatorToken("xref");

	public static readonly OperatorToken StartXref = new OperatorToken("startxref");

	public string Data { get; }

	private OperatorToken(string data)
	{
		string value;
		lock (Lock)
		{
			if (!PooledNames.TryGetValue(data, out value))
			{
				value = data;
				PooledNames[data] = value;
			}
		}
		Data = value;
	}

	public static OperatorToken Create(ReadOnlySpan<char> data)
	{
		return data switch
		{
			"BT" => Bt, 
			"eexec" => Eexec, 
			"endobj" => EndObject, 
			"endstream" => EndStream, 
			"ET" => Et, 
			"def" => Def, 
			"dict" => Dict, 
			"for" => For, 
			"dup" => Dup, 
			"n" => N, 
			"obj" => StartObject, 
			"put" => Put, 
			"Q" => QPop, 
			"q" => QPush, 
			"R" => R, 
			"re" => Re, 
			"readonly" => Readonly, 
			"stream" => StartStream, 
			"Tf" => Tf, 
			"W*" => WStar, 
			"xref" => Xref, 
			"startxref" => StartXref, 
			_ => new OperatorToken(data.ToString()), 
		};
	}

	public bool Equals(IToken obj)
	{
		if (this == obj)
		{
			return true;
		}
		if (!(obj is OperatorToken operatorToken))
		{
			return false;
		}
		return Data == operatorToken.Data;
	}

	public override int GetHashCode()
	{
		return Data.GetHashCode();
	}

	public override string ToString()
	{
		return Data;
	}
}
