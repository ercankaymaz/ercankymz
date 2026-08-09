using System;
using System.Collections.Generic;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Fonts.Encodings;
using UglyToad.PdfPig.Tokenization.Scanner;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Fonts.Type1.Parser;

public static class Type1FontParser
{
	private sealed class PreviousTokenSet
	{
		private readonly IToken[] tokens = new IToken[3];

		public IToken this[int index] => tokens[2 - index];

		public void Add(IToken token)
		{
			tokens[0] = tokens[1];
			tokens[1] = tokens[2];
			tokens[2] = token;
		}
	}

	private const string ClearToMark = "cleartomark";

	private const int PfbFileIndicator = 128;

	private static readonly char[] Separators = new char[1] { ' ' };

	private static readonly Type1EncryptedPortionParser EncryptedPortionParser = new Type1EncryptedPortionParser();

	public static Type1Font Parse(IInputBytes inputBytes, int length1, int length2)
	{
		bool flag = inputBytes.Peek() == 128;
		ReadOnlySpan<byte> bytes = default(ReadOnlySpan<byte>);
		if (flag)
		{
			(byte[] ascii, byte[] binary) tuple = ReadPfbHeader(inputBytes);
			byte[] item = tuple.ascii;
			bytes = tuple.binary;
			inputBytes = new MemoryInputBytes(item);
		}
		CoreTokenScanner coreTokenScanner = new CoreTokenScanner(inputBytes, usePdfDocEncoding: false);
		if (!coreTokenScanner.TryReadToken<CommentToken>(out var token) || !token.Data.StartsWith("!"))
		{
			throw new InvalidFontFormatException("The Type1 program did not start with '%!'.");
		}
		string[] array = token.Data.Split(Separators, StringSplitOptions.RemoveEmptyEntries);
		string name = ((array.Length != 3) ? "Unknown" : array[1]);
		while (coreTokenScanner.MoveNext() && coreTokenScanner.CurrentToken is CommentToken)
		{
		}
		List<DictionaryToken> dictionaries = new List<DictionaryToken>();
		Type1ArrayTokenizer tokenizer = new Type1ArrayTokenizer();
		Type1NameTokenizer tokenizer2 = new Type1NameTokenizer();
		coreTokenScanner.RegisterCustomTokenizer(123, tokenizer);
		coreTokenScanner.RegisterCustomTokenizer(47, tokenizer2);
		try
		{
			using ArrayPoolBufferWriter<byte> arrayPoolBufferWriter = new ArrayPoolBufferWriter<byte>();
			PreviousTokenSet previousTokenSet = new PreviousTokenSet();
			previousTokenSet.Add(coreTokenScanner.CurrentToken);
			while (coreTokenScanner.MoveNext())
			{
				if (coreTokenScanner.CurrentToken is OperatorToken token2)
				{
					if (object.Equals(coreTokenScanner.CurrentToken, OperatorToken.Eexec))
					{
						int num = 0;
						while (inputBytes.MoveNext())
						{
							if (inputBytes.CurrentByte == (byte)"cleartomark"[num])
							{
								num++;
							}
							else
							{
								if (num > 0)
								{
									for (int i = 0; i < num; i++)
									{
										arrayPoolBufferWriter.Write((byte)"cleartomark"[i]);
									}
								}
								num = 0;
							}
							if (num == "cleartomark".Length)
							{
								break;
							}
							if (num <= 0)
							{
								arrayPoolBufferWriter.Write(inputBytes.CurrentByte);
							}
						}
					}
					else
					{
						HandleOperator(token2, coreTokenScanner, previousTokenSet, dictionaries);
					}
				}
				previousTokenSet.Add(coreTokenScanner.CurrentToken);
			}
			if (!flag)
			{
				bytes = arrayPoolBufferWriter.WrittenSpan.ToArray();
			}
		}
		finally
		{
			coreTokenScanner.DeregisterCustomTokenizer(tokenizer);
			coreTokenScanner.DeregisterCustomTokenizer(tokenizer2);
		}
		IReadOnlyDictionary<int, string> encoding = GetEncoding(dictionaries);
		ArrayToken fontMatrix = GetFontMatrix(dictionaries);
		PdfRectangle? boundingBox = GetBoundingBox(dictionaries);
		var (privateDictionary, charStrings) = EncryptedPortionParser.Parse(bytes, isLenientParsing: false);
		return new Type1Font(name, encoding, fontMatrix, boundingBox.GetValueOrDefault(), privateDictionary, charStrings);
	}

	private static (byte[] ascii, byte[] binary) ReadPfbHeader(IInputBytes bytes)
	{
		int num = ReadSize(1);
		byte[] array = new byte[num];
		for (int i = 0; i < num; i++)
		{
			bytes.MoveNext();
			array[i] = bytes.CurrentByte;
		}
		int num2 = ReadSize(2);
		byte[] array2 = new byte[num2];
		for (int i = 0; i < num2; i++)
		{
			bytes.MoveNext();
			array2[i] = bytes.CurrentByte;
		}
		return (ascii: array, binary: array2);
		int ReadSize(byte recordType)
		{
			bytes.MoveNext();
			if (bytes.CurrentByte != 128)
			{
				throw new InvalidOperationException($"File does not start with 0x80, which indicates a full PFB file. Instead got: {bytes.CurrentByte}");
			}
			bytes.MoveNext();
			if (bytes.CurrentByte != recordType)
			{
				throw new InvalidOperationException($"Encountered unexpected header type in the PFB file: {bytes.CurrentByte}");
			}
			bytes.MoveNext();
			byte currentByte = bytes.CurrentByte;
			bytes.MoveNext();
			int num3 = currentByte + (bytes.CurrentByte << 8);
			bytes.MoveNext();
			int num4 = num3 + (bytes.CurrentByte << 16);
			bytes.MoveNext();
			return num4 + (bytes.CurrentByte << 24);
		}
	}

	private static void HandleOperator(OperatorToken token, ISeekableTokenScanner scanner, PreviousTokenSet set, List<DictionaryToken> dictionaries)
	{
		if (token.Data == "dict")
		{
			DictionaryToken item = ReadDictionary(((NumericToken)set[0]).Int, scanner);
			dictionaries.Add(item);
		}
	}

	private static DictionaryToken ReadDictionary(int keys, ISeekableTokenScanner scanner)
	{
		IToken token = null;
		Dictionary<NameToken, IToken> dictionary = new Dictionary<NameToken, IToken>();
		while (scanner.MoveNext() && (!(scanner.CurrentToken is OperatorToken operatorToken) || operatorToken.Data != "begin"))
		{
		}
		for (int i = 0; i < keys; i++)
		{
			if (!scanner.TryReadToken<NameToken>(out var token2))
			{
				return new DictionaryToken(dictionary);
			}
			if (token2.Data.Equals(NameToken.Encoding))
			{
				(ArrayToken, NameToken) tuple = ReadEncoding(scanner);
				NameToken key = token2;
				IToken item = tuple.Item1;
				dictionary[key] = item ?? tuple.Item2;
				continue;
			}
			while (scanner.MoveNext())
			{
				if (scanner.CurrentToken == OperatorToken.Def)
				{
					dictionary[token2] = token;
					break;
				}
				if (scanner.CurrentToken == OperatorToken.Dict)
				{
					if (!(token is NumericToken numericToken))
					{
						return new DictionaryToken(dictionary);
					}
					token = ReadDictionary(numericToken.Int, scanner);
				}
				else if (scanner.CurrentToken != OperatorToken.Readonly && !(scanner.CurrentToken is OperatorToken { Data: "end" }))
				{
					token = scanner.CurrentToken;
				}
			}
		}
		return new DictionaryToken(dictionary);
	}

	private static (ArrayToken encoding, NameToken name) ReadEncoding(ISeekableTokenScanner scanner)
	{
		List<IToken> list = new List<IToken>();
		if (!scanner.TryReadToken<NumericToken>(out var _))
		{
			if (scanner.CurrentToken is OperatorToken operatorToken && operatorToken.Data.Equals(NameToken.StandardEncoding))
			{
				return (encoding: null, name: NameToken.StandardEncoding);
			}
			return (encoding: new ArrayToken(list), name: null);
		}
		if (!scanner.TryReadToken<OperatorToken>(out var token2) || token2.Data != "array")
		{
			return (encoding: new ArrayToken(list), name: null);
		}
		bool flag = false;
		while (scanner.MoveNext() && (!(scanner.CurrentToken is OperatorToken operatorToken2) || operatorToken2.Data != "for"))
		{
			if (scanner.CurrentToken is OperatorToken operatorToken3)
			{
				if (string.Equals(operatorToken3.Data, "for", StringComparison.OrdinalIgnoreCase))
				{
					break;
				}
				if (string.Equals(operatorToken3.Data, OperatorToken.Dup.Data, StringComparison.OrdinalIgnoreCase))
				{
					flag = true;
					break;
				}
			}
		}
		if (scanner.CurrentToken != OperatorToken.For && !flag)
		{
			return (encoding: new ArrayToken(list), name: null);
		}
		while ((flag || scanner.MoveNext()) && !IsDefOrReadonly())
		{
			flag = false;
			if (scanner.CurrentToken != OperatorToken.Dup)
			{
				throw new InvalidFontFormatException("Expected the array for encoding to begin with 'dup'.");
			}
			scanner.MoveNext();
			NumericToken item = (NumericToken)scanner.CurrentToken;
			scanner.MoveNext();
			NameToken item2 = (NameToken)scanner.CurrentToken;
			if (!scanner.TryReadToken<OperatorToken>(out var token3) || token3 != OperatorToken.Put)
			{
				throw new InvalidFontFormatException("Expected the array entry to end with 'put'.");
			}
			list.Add(item);
			list.Add(item2);
		}
		while (scanner.CurrentToken != OperatorToken.Def && scanner.MoveNext())
		{
		}
		return (encoding: new ArrayToken(list), name: null);
		bool IsDefOrReadonly()
		{
			if (scanner.CurrentToken != OperatorToken.Def)
			{
				return scanner.CurrentToken == OperatorToken.Readonly;
			}
			return true;
		}
	}

	private static IReadOnlyDictionary<int, string> GetEncoding(IReadOnlyList<DictionaryToken> dictionaries)
	{
		Dictionary<int, string> dictionary = new Dictionary<int, string>();
		foreach (DictionaryToken dictionary2 in dictionaries)
		{
			if (!dictionary2.TryGet(NameToken.Encoding, out var token))
			{
				continue;
			}
			if (token is ArrayToken arrayToken)
			{
				for (int i = 0; i < arrayToken.Data.Count; i += 2)
				{
					NumericToken numericToken = (NumericToken)arrayToken.Data[i];
					NameToken nameToken = (NameToken)arrayToken.Data[i + 1];
					dictionary[numericToken.Int] = nameToken.Data;
				}
				return dictionary;
			}
			if (token is NameToken nameToken2 && nameToken2.Equals(NameToken.StandardEncoding))
			{
				return StandardEncoding.Instance.CodeToNameMap;
			}
		}
		return dictionary;
	}

	private static ArrayToken GetFontMatrix(IReadOnlyList<DictionaryToken> dictionaries)
	{
		foreach (DictionaryToken dictionary in dictionaries)
		{
			if (dictionary.TryGet(NameToken.FontMatrix, out var token) && token is ArrayToken result)
			{
				return result;
			}
		}
		return null;
	}

	private static PdfRectangle? GetBoundingBox(IReadOnlyList<DictionaryToken> dictionaries)
	{
		foreach (DictionaryToken dictionary in dictionaries)
		{
			if (dictionary.TryGet(NameToken.FontBbox, out var token) && token is ArrayToken arrayToken && arrayToken.Data.Count == 4)
			{
				NumericToken obj = (NumericToken)arrayToken.Data[0];
				NumericToken numericToken = (NumericToken)arrayToken.Data[1];
				NumericToken numericToken2 = (NumericToken)arrayToken.Data[2];
				return new PdfRectangle(y2: ((NumericToken)arrayToken.Data[3]).Double, x1: obj.Double, y1: numericToken.Double, x2: numericToken2.Double);
			}
		}
		return null;
	}
}
