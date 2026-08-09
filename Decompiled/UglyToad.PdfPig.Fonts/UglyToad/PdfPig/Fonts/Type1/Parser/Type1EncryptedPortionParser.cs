using System;
using System.Collections.Generic;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Fonts.Type1.CharStrings;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Fonts.Type1.Parser;

internal class Type1EncryptedPortionParser
{
	private const ushort EexecEncryptionKey = 55665;

	private const int EexecRandomBytes = 4;

	private const int Len4Bytes = 4;

	private const int Password = 5839;

	private const int CharstringEncryptionKey = 4330;

	public (Type1PrivateDictionary, Type1CharStrings) Parse(ReadOnlySpan<byte> bytes, bool isLenientParsing)
	{
		if (!IsBinary(bytes))
		{
			bytes = ConvertHexToBinary(bytes);
		}
		ReadOnlySpan<byte> readOnlySpan = Decrypt(bytes, 55665, 4);
		if (readOnlySpan.Length == 0)
		{
			Type1PrivateDictionary item = new Type1PrivateDictionary(new Type1PrivateDictionary.Builder());
			Type1CharStrings item2 = new Type1CharStrings(new Dictionary<string, Type1CharStrings.CommandSequence>(), new Dictionary<int, string>(), new Dictionary<int, Type1CharStrings.CommandSequence>());
			return (item, item2);
		}
		Type1Tokenizer type1Tokenizer = new Type1Tokenizer(new MemoryInputBytes(new ReadOnlyMemory<byte>(readOnlySpan.ToArray())));
		while (!type1Tokenizer.CurrentToken.IsPrivateDictionary)
		{
			type1Tokenizer.GetNext();
			if (type1Tokenizer.CurrentToken == null)
			{
				throw new InvalidOperationException("Did not find the private dictionary start token.");
			}
		}
		Type1Token next = type1Tokenizer.GetNext();
		if (next == null || next.Type != Type1Token.TokenType.Integer)
		{
			throw new InvalidOperationException($"No length token was present in the stream following the private dictionary start, instead got {next}.");
		}
		int num = next.AsInt();
		ReadExpected(type1Tokenizer, Type1Token.TokenType.Name, "dict");
		ReadExpectedAfterOptional(type1Tokenizer, Type1Token.TokenType.Name, "def", Type1Token.TokenType.Name, "dup");
		ReadExpected(type1Tokenizer, Type1Token.TokenType.Name, "begin");
		int lenIv = 4;
		Type1PrivateDictionary.Builder builder = new Type1PrivateDictionary.Builder();
		for (int i = 0; i < num; i++)
		{
			Type1Token next2 = type1Tokenizer.GetNext();
			if (next2 == null || next2.Type != Type1Token.TokenType.Literal)
			{
				break;
			}
			switch (next2.Text)
			{
			case "RD":
			case "-|":
			{
				IReadOnlyList<Type1Token> rd = ReadProcedure(type1Tokenizer, hasReadStartProc: false);
				builder.Rd = rd;
				ReadTillDef(type1Tokenizer);
				break;
			}
			case "|-":
			case "ND":
			{
				IReadOnlyList<Type1Token> noAccessDef = ReadProcedure(type1Tokenizer, hasReadStartProc: false);
				builder.NoAccessDef = noAccessDef;
				ReadTillDef(type1Tokenizer);
				break;
			}
			case "NP":
			case "|":
			{
				IReadOnlyList<Type1Token> noAccessPut = ReadProcedure(type1Tokenizer, hasReadStartProc: false);
				builder.NoAccessPut = noAccessPut;
				ReadTillDef(type1Tokenizer);
				break;
			}
			case "BlueValues":
			{
				IReadOnlyList<int> blueValues = ReadArrayValues(type1Tokenizer, (Type1Token x) => x.AsInt());
				builder.BlueValues = blueValues;
				break;
			}
			case "OtherBlues":
			{
				IReadOnlyList<int> otherBlues = ReadArrayValues(type1Tokenizer, (Type1Token x) => x.AsInt());
				builder.OtherBlues = otherBlues;
				break;
			}
			case "StdHW":
			{
				double value = ReadArrayValues(type1Tokenizer, (Type1Token x) => x.AsDouble())[0];
				builder.StandardHorizontalWidth = value;
				break;
			}
			case "StdVW":
			{
				double value3 = ReadArrayValues(type1Tokenizer, (Type1Token x) => x.AsDouble())[0];
				builder.StandardVerticalWidth = value3;
				break;
			}
			case "StemSnapH":
			{
				IReadOnlyList<double> stemSnapHorizontalWidths = ReadArrayValues(type1Tokenizer, (Type1Token x) => x.AsDouble());
				builder.StemSnapHorizontalWidths = stemSnapHorizontalWidths;
				break;
			}
			case "StemSnapV":
			{
				IReadOnlyList<double> stemSnapVerticalWidths = ReadArrayValues(type1Tokenizer, (Type1Token x) => x.AsDouble());
				builder.StemSnapVerticalWidths = stemSnapVerticalWidths;
				break;
			}
			case "BlueScale":
				builder.BlueScale = ReadNumeric(type1Tokenizer);
				ReadTillDef(type1Tokenizer);
				break;
			case "ForceBold":
				builder.ForceBold = ReadBoolean(type1Tokenizer);
				ReadTillDef(type1Tokenizer);
				break;
			case "MinFeature":
				try
				{
					Type1Token next3 = type1Tokenizer.GetNext();
					if (next3.Type == Type1Token.TokenType.StartArray)
					{
						IReadOnlyList<int> readOnlyList = ReadArrayValues(type1Tokenizer, (Type1Token x) => x.AsInt(), hasReadStart: true);
						builder.MinFeature = new MinFeature(readOnlyList[0], readOnlyList[1]);
					}
					else if (next3.Type == Type1Token.TokenType.StartProc)
					{
						IReadOnlyList<Type1Token> readOnlyList2 = ReadProcedure(type1Tokenizer, hasReadStartProc: true);
						builder.MinFeature = new MinFeature(readOnlyList2[0].AsInt(), readOnlyList2[1].AsInt());
					}
				}
				catch
				{
				}
				ReadTillDef(type1Tokenizer);
				break;
			case "password":
			{
				int num2 = (int)ReadNumeric(type1Tokenizer);
				if (num2 != 5839 && !isLenientParsing)
				{
					throw new InvalidOperationException($"Type 1 font had the wrong password: {num2}");
				}
				builder.Password = num2;
				ReadTillDef(type1Tokenizer);
				break;
			}
			case "UniqueID":
			{
				int value2 = (int)ReadNumeric(type1Tokenizer);
				builder.UniqueId = value2;
				ReadTillDef(type1Tokenizer);
				break;
			}
			case "lenIV":
				lenIv = (int)ReadNumeric(type1Tokenizer);
				ReadTillDef(type1Tokenizer);
				break;
			case "BlueShift":
				builder.BlueShift = (int)ReadNumeric(type1Tokenizer);
				ReadTillDef(type1Tokenizer);
				break;
			case "BlueFuzz":
				builder.BlueFuzz = (int)ReadNumeric(type1Tokenizer);
				ReadTillDef(type1Tokenizer);
				break;
			case "FamilyBlues":
				builder.FamilyBlues = ReadArrayValues(type1Tokenizer, (Type1Token x) => x.AsInt());
				break;
			case "FamilyOtherBlues":
				builder.FamilyOtherBlues = ReadArrayValues(type1Tokenizer, (Type1Token x) => x.AsInt());
				break;
			case "LanguageGroup":
				builder.LanguageGroup = (int)ReadNumeric(type1Tokenizer);
				ReadTillDef(type1Tokenizer);
				break;
			case "RndStemUp":
				builder.RoundStemUp = ReadBoolean(type1Tokenizer);
				ReadTillDef(type1Tokenizer);
				break;
			case "Subrs":
				builder.Subroutines = ReadSubroutines(type1Tokenizer, lenIv, isLenientParsing);
				break;
			case "OtherSubrs":
				ReadOtherSubroutines(type1Tokenizer, isLenientParsing);
				ReadTillDef(type1Tokenizer);
				break;
			case "ExpansionFactor":
				builder.ExpansionFactor = ReadNumeric(type1Tokenizer);
				ReadTillDef(type1Tokenizer);
				break;
			case "Erode":
				ReadTillDef(type1Tokenizer, skip: true);
				break;
			default:
				ReadTillDef(type1Tokenizer, skip: true);
				break;
			}
		}
		Type1Token type1Token = type1Tokenizer.CurrentToken;
		IReadOnlyList<Type1CharstringDecryptedBytes> charStrings;
		if (type1Token != null)
		{
			while (type1Token != null && type1Token.Type != Type1Token.TokenType.Literal && !string.Equals(type1Token.Text, "CharStrings", StringComparison.OrdinalIgnoreCase))
			{
				type1Token = type1Tokenizer.GetNext();
			}
			charStrings = ((type1Token == null) ? new Type1CharstringDecryptedBytes[0] : ReadCharStrings(type1Tokenizer, lenIv, isLenientParsing));
		}
		else
		{
			charStrings = new Type1CharstringDecryptedBytes[0];
		}
		Type1PrivateDictionary item3 = builder.Build();
		Type1CharStrings item4 = Type1CharStringParser.Parse(charStrings, builder.Subroutines ?? new Type1CharstringDecryptedBytes[0]);
		return (item3, item4);
	}

	private static bool IsBinary(ReadOnlySpan<byte> bytes)
	{
		if (bytes.Length < 4)
		{
			return true;
		}
		if (ReadHelper.IsWhitespace(bytes[0]))
		{
			return true;
		}
		for (int i = 1; i < 4; i++)
		{
			if (!ReadHelper.IsHex(bytes[i]))
			{
				return true;
			}
		}
		return false;
	}

	private static ReadOnlySpan<byte> ConvertHexToBinary(ReadOnlySpan<byte> bytes)
	{
		byte[] array = new byte[bytes.Length / 2];
		int num = 0;
		char high = '\0';
		int num2 = 0;
		for (int i = 0; i < bytes.Length; i++)
		{
			char c = (char)bytes[i];
			if (ReadHelper.IsHex(c))
			{
				if (num2 == 1)
				{
					array[num++] = HexToken.ConvertPair(high, c);
					num2 = 0;
				}
				else
				{
					num2++;
				}
				high = c;
			}
		}
		return array;
	}

	private static ReadOnlySpan<byte> Decrypt(ReadOnlySpan<byte> bytes, int key, int randomBytes)
	{
		if (randomBytes == -1)
		{
			return bytes;
		}
		if (randomBytes > bytes.Length || bytes.Length == 0)
		{
			return default(ReadOnlySpan<byte>);
		}
		byte[] array = new byte[bytes.Length - randomBytes];
		for (int i = 0; i < bytes.Length; i++)
		{
			int num = bytes[i] & 0xFF;
			int num2 = num ^ (key >> 8);
			if (i >= randomBytes)
			{
				array[i - randomBytes] = (byte)num2;
			}
			key = ((num + key) * 52845 + 22719) & 0xFFFF;
		}
		return array;
	}

	private static void ReadExpected(Type1Tokenizer tokenizer, Type1Token.TokenType type, string text = null)
	{
		Type1Token next = tokenizer.GetNext();
		if (next == null)
		{
			throw new InvalidOperationException("Type 1 Encrypted portion ended when a token with text '" + text + "' was expected.");
		}
		if (next.Type != type || (text != null && !string.Equals(next.Text, text, StringComparison.OrdinalIgnoreCase)))
		{
			throw new InvalidOperationException($"Found invalid token {next} when type {type} with text {text} was expected.");
		}
	}

	private static void ReadExpectedAfterOptional(Type1Tokenizer tokenizer, Type1Token.TokenType optionalType, string optionalText, Type1Token.TokenType type, string text)
	{
		Type1Token next = tokenizer.GetNext();
		if (next == null)
		{
			throw new InvalidOperationException("Type 1 Encrypted portion ended when a token with text '" + optionalText + "' or '" + text + "' was expected.");
		}
		if (next.Type != type || !string.Equals(next.Text, text, StringComparison.OrdinalIgnoreCase))
		{
			if (next.Type != optionalType || !string.Equals(next.Text, optionalText, StringComparison.OrdinalIgnoreCase))
			{
				throw new InvalidOperationException($"Found invalid token {next} when type {type} with text {text} was expected.");
			}
			ReadExpected(tokenizer, type, text);
		}
	}

	private static IReadOnlyList<Type1Token> ReadProcedure(Type1Tokenizer tokenizer, bool hasReadStartProc)
	{
		List<Type1Token> list = new List<Type1Token>();
		int depth = (hasReadStartProc ? 1 : (-1));
		ReadProcedure(tokenizer, list, ref depth);
		return list;
	}

	private static void ReadProcedure(Type1Tokenizer tokenizer, List<Type1Token> tokens, ref int depth)
	{
		if (depth == -1)
		{
			ReadExpected(tokenizer, Type1Token.TokenType.StartProc);
			depth = 1;
		}
		if (depth == 0)
		{
			return;
		}
		Type1Token next;
		while ((next = tokenizer.GetNext()) != null)
		{
			if (next.Type == Type1Token.TokenType.StartProc)
			{
				depth++;
				ReadProcedure(tokenizer, tokens, ref depth);
				continue;
			}
			if (next.Type == Type1Token.TokenType.EndProc)
			{
				depth--;
				break;
			}
			tokens.Add(next);
		}
	}

	private static void ReadTillDef(Type1Tokenizer tokenizer, bool skip = false)
	{
		if (string.Equals(tokenizer.CurrentToken.Text, "def", StringComparison.OrdinalIgnoreCase))
		{
			return;
		}
		Type1Token next;
		while ((next = tokenizer.GetNext()) != null)
		{
			if (next.Type == Type1Token.TokenType.Name)
			{
				if (string.Equals(next.Text, "ND", StringComparison.OrdinalIgnoreCase) || string.Equals(next.Text, "|-", StringComparison.OrdinalIgnoreCase) || string.Equals(next.Text, "def", StringComparison.OrdinalIgnoreCase))
				{
					break;
				}
				if (!string.Equals(next.Text, "systemdict"))
				{
					continue;
				}
				ReadExpected(tokenizer, Type1Token.TokenType.Literal, "internaldict");
				ReadExpected(tokenizer, Type1Token.TokenType.Name, "known");
				ReadExpected(tokenizer, Type1Token.TokenType.StartProc);
				while ((next = tokenizer.GetNext()) != null)
				{
					if (next.Type == Type1Token.TokenType.Name && (next.Text == "ND" || next.Text == "def"))
					{
						return;
					}
				}
			}
			else if (!skip)
			{
				throw new InvalidOperationException($"Encountered unexpected non-name token while reading till 'def' token: {next}");
			}
		}
	}

	private static void ReadTillPut(Type1Tokenizer tokenizer)
	{
		Type1Token next;
		while ((next = tokenizer.GetNext()) != null && !string.Equals(next.Text, "put", StringComparison.OrdinalIgnoreCase))
		{
			string text = next.Text;
			if (text == "NP" || text == "|")
			{
				break;
			}
		}
	}

	private static IReadOnlyList<T> ReadArrayValues<T>(Type1Tokenizer tokenizer, Func<Type1Token, T> converter, bool hasReadStart = false, bool includeDef = true)
	{
		if (!hasReadStart)
		{
			ReadExpected(tokenizer, Type1Token.TokenType.StartArray);
		}
		List<T> list = new List<T>();
		Type1Token next;
		while ((next = tokenizer.GetNext()) != null && next.Type != Type1Token.TokenType.EndArray)
		{
			if (next.Type == Type1Token.TokenType.StartArray)
			{
				IReadOnlyList<T> collection = ReadArrayValues(tokenizer, converter, hasReadStart: true, includeDef: false);
				list.AddRange(collection);
			}
			try
			{
				T item = converter(next);
				list.Add(item);
			}
			catch (Exception innerException)
			{
				throw new InvalidOperationException($"Conversion of token '{next}' to value of type {typeof(T).Name} failed.", innerException);
			}
		}
		if (includeDef)
		{
			ReadTillDef(tokenizer);
		}
		return list;
	}

	private static double ReadNumeric(Type1Tokenizer tokenizer)
	{
		Type1Token next = tokenizer.GetNext();
		if (next == null || (next.Type != Type1Token.TokenType.Integer && next.Type != Type1Token.TokenType.Real))
		{
			throw new InvalidOperationException($"Expected to read a numeric token, instead got: {next}.");
		}
		return next.AsDouble();
	}

	private static bool ReadBoolean(Type1Tokenizer tokenizer)
	{
		Type1Token next = tokenizer.GetNext();
		if (next == null || (!string.Equals(next.Text, "true", StringComparison.OrdinalIgnoreCase) && !string.Equals(next.Text, "false", StringComparison.OrdinalIgnoreCase)))
		{
			throw new InvalidOperationException($"Expected to read a boolean token, instead got: {next}.");
		}
		return next.AsBool();
	}

	private static void ReadOtherSubroutines(Type1Tokenizer tokenizer, bool isLenientParsing)
	{
		Type1Token next = tokenizer.GetNext();
		if (next.Type == Type1Token.TokenType.StartArray)
		{
			ReadArrayValues(tokenizer, (Type1Token x) => x, hasReadStart: true, includeDef: false);
		}
		else if (next.Type == Type1Token.TokenType.Integer || next.Type == Type1Token.TokenType.Real)
		{
			int num = next.AsInt();
			ReadExpected(tokenizer, Type1Token.TokenType.Name, "array");
			for (int num2 = 0; num2 < num; num2++)
			{
				ReadExpected(tokenizer, Type1Token.TokenType.Name, "dup");
				ReadNumeric(tokenizer);
				ReadTillPut(tokenizer);
			}
			ReadTillDef(tokenizer);
		}
		else if (!isLenientParsing)
		{
			throw new InvalidOperationException($"Failed to read start of /OtherSubrs array. Got start token: {next}.");
		}
	}

	private static IReadOnlyList<Type1CharstringDecryptedBytes> ReadSubroutines(Type1Tokenizer tokenizer, int lenIv, bool isLenientParsing)
	{
		int num = (int)ReadNumeric(tokenizer);
		List<Type1CharstringDecryptedBytes> list = new List<Type1CharstringDecryptedBytes>(num);
		ReadExpected(tokenizer, Type1Token.TokenType.Name, "array");
		for (int i = 0; i < num; i++)
		{
			Type1Token next = tokenizer.GetNext();
			if (next.Type != Type1Token.TokenType.Name || !string.Equals(next.Text, "dup"))
			{
				break;
			}
			int index = (int)ReadNumeric(tokenizer);
			int num2 = (int)ReadNumeric(tokenizer);
			Type1Token next2 = tokenizer.GetNext();
			if (!(next2 is Type1DataToken type1DataToken))
			{
				throw new InvalidOperationException($"Found an unexpected token instead of subroutine charstring: {next2}.");
			}
			ReadOnlyMemory<byte> data;
			if (!isLenientParsing)
			{
				data = type1DataToken.Data;
				if (data.Length != num2)
				{
					throw new InvalidOperationException($"The subroutine charstring {type1DataToken} did not have the expected length of {num2}.");
				}
			}
			data = type1DataToken.Data;
			list.Add(new Type1CharstringDecryptedBytes(Decrypt(data.Span, 4330, lenIv).ToArray(), index));
			ReadTillPut(tokenizer);
		}
		ReadTillDef(tokenizer);
		return list;
	}

	private static IReadOnlyList<Type1CharstringDecryptedBytes> ReadCharStrings(Type1Tokenizer tokenizer, int lenIv, bool isLenientParsing)
	{
		int num = (int)ReadNumeric(tokenizer);
		ReadExpected(tokenizer, Type1Token.TokenType.Name, "dict");
		ReadExpected(tokenizer, Type1Token.TokenType.Name);
		ReadExpected(tokenizer, Type1Token.TokenType.Name, "begin");
		List<Type1CharstringDecryptedBytes> list = new List<Type1CharstringDecryptedBytes>();
		for (int i = 0; i < num; i++)
		{
			Type1Token next = tokenizer.GetNext();
			if (next.Type == Type1Token.TokenType.Name && string.Equals(next.Text, "end", StringComparison.OrdinalIgnoreCase))
			{
				break;
			}
			if (next.Type != Type1Token.TokenType.Literal)
			{
				throw new InvalidOperationException($"Type 1 font error. Expected literal for charstring name, instead got: {next}.");
			}
			string text = next.Text;
			double num2 = ReadNumeric(tokenizer);
			Type1Token next2 = tokenizer.GetNext();
			if (!(next2 is Type1DataToken type1DataToken))
			{
				throw new InvalidOperationException($"Got wrong type of token, expected charstring, instead got: {next2}.");
			}
			ReadOnlyMemory<byte> data;
			if (!isLenientParsing)
			{
				data = type1DataToken.Data;
				if ((double)data.Length != num2)
				{
					throw new InvalidOperationException($"The charstring {type1DataToken} did not have the expected length of {num2}.");
				}
			}
			data = type1DataToken.Data;
			list.Add(new Type1CharstringDecryptedBytes(text, Decrypt(data.Span, 4330, lenIv).ToArray(), i));
			ReadTillDef(tokenizer);
		}
		ReadExpected(tokenizer, Type1Token.TokenType.Name, "end");
		return list;
	}
}
