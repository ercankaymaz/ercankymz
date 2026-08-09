using System;
using System.Collections.Generic;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Tokenization.Scanner;

public class CoreTokenScanner : ISeekableTokenScanner, ITokenScanner
{
	private static readonly CommentTokenizer CommentTokenizer = new CommentTokenizer();

	private static readonly HexTokenizer HexTokenizer = new HexTokenizer();

	private static readonly NameTokenizer NameTokenizer = new NameTokenizer();

	private static readonly PlainTokenizer PlainTokenizer = new PlainTokenizer();

	private static readonly NumericTokenizer NumericTokenizer = new NumericTokenizer();

	private readonly StringTokenizer stringTokenizer;

	private readonly ArrayTokenizer arrayTokenizer;

	private readonly DictionaryTokenizer dictionaryTokenizer;

	private readonly ScannerScope scope;

	private readonly IReadOnlyDictionary<NameToken, IReadOnlyList<NameToken>> namedDictionaryRequiredKeys;

	private readonly IInputBytes inputBytes;

	private readonly bool usePdfDocEncoding;

	private readonly List<(byte firstByte, ITokenizer tokenizer)> customTokenizers = new List<(byte, ITokenizer)>();

	private readonly bool useLenientParsing;

	private bool hasBytePreRead;

	private bool isInInlineImage;

	private readonly bool isStream;

	public long CurrentTokenStart { get; private set; }

	public IToken CurrentToken { get; private set; }

	public long CurrentPosition => inputBytes.CurrentOffset;

	public long Length => inputBytes.Length;

	public CoreTokenScanner(IInputBytes inputBytes, bool usePdfDocEncoding, ScannerScope scope = ScannerScope.None, IReadOnlyDictionary<NameToken, IReadOnlyList<NameToken>> namedDictionaryRequiredKeys = null, bool useLenientParsing = false, bool isStream = false)
	{
		this.inputBytes = inputBytes ?? throw new ArgumentNullException("inputBytes");
		this.usePdfDocEncoding = usePdfDocEncoding;
		stringTokenizer = new StringTokenizer(usePdfDocEncoding);
		arrayTokenizer = new ArrayTokenizer(usePdfDocEncoding);
		dictionaryTokenizer = new DictionaryTokenizer(usePdfDocEncoding, null, useLenientParsing);
		this.scope = scope;
		this.namedDictionaryRequiredKeys = namedDictionaryRequiredKeys;
		this.useLenientParsing = useLenientParsing;
		this.isStream = isStream;
	}

	public bool TryReadToken<T>(out T token) where T : class, IToken
	{
		token = null;
		if (!MoveNext())
		{
			return false;
		}
		if (CurrentToken is T val)
		{
			token = val;
			return true;
		}
		return false;
	}

	public void Seek(long position)
	{
		inputBytes.Seek(position);
	}

	public bool MoveNext()
	{
		int num = 0;
		bool flag = false;
		bool flag2 = false;
		while ((hasBytePreRead && !inputBytes.IsAtEnd()) || inputBytes.MoveNext())
		{
			hasBytePreRead = false;
			byte currentByte = inputBytes.CurrentByte;
			char c = (char)currentByte;
			if (flag)
			{
				if (ReadHelper.IsEndOfLine(c))
				{
					flag = false;
				}
				continue;
			}
			ITokenizer tokenizer = null;
			foreach (var customTokenizer in customTokenizers)
			{
				if (currentByte == customTokenizer.firstByte)
				{
					tokenizer = customTokenizer.tokenizer;
					break;
				}
			}
			if (tokenizer == null)
			{
				if (ReadHelper.IsWhitespace(currentByte) || char.IsControl(c))
				{
					flag2 = false;
					continue;
				}
				if (currentByte == 37 && isStream)
				{
					flag = true;
					continue;
				}
				if (flag2 && c != '>')
				{
					continue;
				}
				switch (c)
				{
				case '(':
					tokenizer = stringTokenizer;
					break;
				case '<':
					if (inputBytes.Peek() == 60)
					{
						flag2 = true;
						tokenizer = dictionaryTokenizer;
						if (namedDictionaryRequiredKeys != null && CurrentToken is NameToken key && namedDictionaryRequiredKeys.TryGetValue(key, out var value))
						{
							tokenizer = new DictionaryTokenizer(usePdfDocEncoding, value, useLenientParsing);
						}
					}
					else
					{
						tokenizer = HexTokenizer;
					}
					break;
				case '>':
					if (scope == ScannerScope.Dictionary)
					{
						num++;
						if (num == 2)
						{
							return false;
						}
						break;
					}
					goto default;
				case '[':
					tokenizer = arrayTokenizer;
					break;
				case ']':
					if (scope == ScannerScope.Array)
					{
						return false;
					}
					goto default;
				case '/':
					tokenizer = NameTokenizer;
					break;
				case '%':
					tokenizer = CommentTokenizer;
					break;
				case '+':
				case '-':
				case '.':
				case '0':
				case '1':
				case '2':
				case '3':
				case '4':
				case '5':
				case '6':
				case '7':
				case '8':
				case '9':
					tokenizer = NumericTokenizer;
					break;
				default:
					tokenizer = PlainTokenizer;
					break;
				}
			}
			CurrentTokenStart = inputBytes.CurrentOffset - 1;
			if (tokenizer == null || !tokenizer.TryTokenize(currentByte, inputBytes, out var token))
			{
				flag2 = true;
				hasBytePreRead = false;
				continue;
			}
			if (token is OperatorToken operatorToken)
			{
				if (operatorToken.Data == "BI")
				{
					isInInlineImage = true;
				}
				else if (isInInlineImage && operatorToken.Data == "ID")
				{
					List<byte> list = ReadInlineImageData();
					isInInlineImage = false;
					CurrentToken = new InlineImageDataToken(new Memory<byte>(list.ToArray()));
					hasBytePreRead = false;
					return true;
				}
			}
			CurrentToken = token;
			hasBytePreRead = tokenizer.ReadsNextByte;
			return true;
		}
		return false;
	}

	public void RegisterCustomTokenizer(byte firstByte, ITokenizer tokenizer)
	{
		if (tokenizer == null)
		{
			throw new ArgumentNullException("tokenizer");
		}
		customTokenizers.Add((firstByte, tokenizer));
	}

	public void DeregisterCustomTokenizer(ITokenizer tokenizer)
	{
		customTokenizers.RemoveAll(((byte firstByte, ITokenizer tokenizer) x) => x.tokenizer == tokenizer);
	}

	public IReadOnlyList<byte> RecoverFromIncorrectEndImage(long lastEndImageOffset)
	{
		List<byte> list = new List<byte>();
		inputBytes.Seek(lastEndImageOffset);
		if (!inputBytes.MoveNext() || inputBytes.CurrentByte != 69)
		{
			throw new PdfDocumentFormatException($"Failed to recover the image data stream for an inline image at offset {lastEndImageOffset}. " + $"Expected to read byte 'E' instead got {inputBytes.CurrentByte}.");
		}
		list.Add(inputBytes.CurrentByte);
		if (!inputBytes.MoveNext() || inputBytes.CurrentByte != 73)
		{
			throw new PdfDocumentFormatException($"Failed to recover the image data stream for an inline image at offset {lastEndImageOffset}. " + $"Expected to read second byte 'I' following 'E' instead got {inputBytes.CurrentByte}.");
		}
		list.Add(inputBytes.CurrentByte);
		list.AddRange(ReadUntilEndImage(lastEndImageOffset));
		inputBytes.MoveNext();
		return list;
	}

	private List<byte> ReadInlineImageData()
	{
		if (!ReadHelper.IsWhitespace(inputBytes.CurrentByte))
		{
			throw new PdfDocumentFormatException($"No whitespace character following the image data (ID) operator. Position: {inputBytes.CurrentOffset}.");
		}
		long startsAt = inputBytes.CurrentOffset - 2;
		return ReadUntilEndImage(startsAt);
	}

	private List<byte> ReadUntilEndImage(long startsAt)
	{
		List<byte> list = new List<byte>();
		byte b = 0;
		while (inputBytes.MoveNext())
		{
			if (inputBytes.CurrentByte == 73 && b == 69)
			{
				byte[] array = new byte[6];
				long currentOffset = inputBytes.CurrentOffset;
				int num = inputBytes.Read(array);
				bool flag = true;
				if (num == array.Length)
				{
					bool flag2 = false;
					foreach (byte b2 in array)
					{
						if (ReadHelper.IsWhitespace(b2))
						{
							flag2 = true;
							continue;
						}
						if (b2 > 127)
						{
							flag = false;
							break;
						}
						if (b2 < 32 && b2 != 13 && b2 != 10 && b2 != 9)
						{
							flag = false;
							break;
						}
					}
					if (!flag2)
					{
						flag = false;
					}
				}
				inputBytes.Seek(currentOffset);
				if (flag)
				{
					list.RemoveAt(list.Count - 1);
					return list;
				}
			}
			list.Add(inputBytes.CurrentByte);
			b = inputBytes.CurrentByte;
		}
		if (useLenientParsing)
		{
			return list;
		}
		throw new PdfDocumentFormatException($"No end of inline image data (EI) was found for image data at position {startsAt}.");
	}
}
