using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Encryption;
using UglyToad.PdfPig.Filters;
using UglyToad.PdfPig.Parser.FileStructure;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Tokenization.Scanner;

internal class PdfTokenScanner : IPdfTokenScanner, ISeekableTokenScanner, ITokenScanner, IDisposable
{
	private static readonly Regex EndsWithNumberRegex = new Regex("(?<=^[^\\s\\d]+)\\d+$");

	private readonly IInputBytes inputBytes;

	private readonly IObjectLocationProvider objectLocationProvider;

	private readonly ILookupFilterProvider filterProvider;

	private readonly CoreTokenScanner coreTokenScanner;

	private readonly ParsingOptions parsingOptions;

	private readonly FileHeaderOffset fileHeaderOffset;

	private IEncryptionHandler encryptionHandler;

	private bool isDisposed;

	private bool isBruteForcing;

	private readonly Dictionary<IndirectReference, ObjectToken> overwrittenTokens = new Dictionary<IndirectReference, ObjectToken>();

	private readonly List<IToken> readTokens = new List<IToken>();

	private readonly long[] previousTokenPositions = new long[3];

	private readonly IToken[] previousTokens = new IToken[3];

	private IndirectReference? callingObject;

	private static ReadOnlySpan<byte> EndstreamBytes => "endstream"u8;

	public IToken? CurrentToken { get; private set; }

	public long CurrentPosition => coreTokenScanner.CurrentPosition;

	public long Length => coreTokenScanner.Length;

	public PdfTokenScanner(IInputBytes inputBytes, IObjectLocationProvider objectLocationProvider, ILookupFilterProvider filterProvider, IEncryptionHandler encryptionHandler, FileHeaderOffset fileHeaderOffset, ParsingOptions parsingOptions)
	{
		this.inputBytes = inputBytes;
		this.objectLocationProvider = objectLocationProvider;
		this.filterProvider = filterProvider;
		this.encryptionHandler = encryptionHandler;
		this.fileHeaderOffset = fileHeaderOffset;
		this.parsingOptions = parsingOptions;
		coreTokenScanner = new CoreTokenScanner(inputBytes, usePdfDocEncoding: true, ScannerScope.None, null, parsingOptions.UseLenientParsing);
	}

	public void UpdateEncryptionHandler(IEncryptionHandler newHandler)
	{
		encryptionHandler = newHandler ?? throw new ArgumentNullException("newHandler");
	}

	public bool MoveNext()
	{
		if (isDisposed)
		{
			throw new ObjectDisposedException("PdfTokenScanner");
		}
		int num = 0;
		while (coreTokenScanner.MoveNext() && !object.Equals(coreTokenScanner.CurrentToken, OperatorToken.StartObject))
		{
			if (!(coreTokenScanner.CurrentToken is CommentToken))
			{
				num++;
				previousTokens[0] = previousTokens[1];
				previousTokenPositions[0] = previousTokenPositions[1];
				previousTokens[1] = previousTokens[2];
				previousTokenPositions[1] = previousTokenPositions[2];
				previousTokens[2] = coreTokenScanner.CurrentToken;
				previousTokenPositions[2] = coreTokenScanner.CurrentTokenStart;
			}
		}
		if (num < 2)
		{
			return false;
		}
		long num2 = previousTokenPositions[1];
		NumericToken numericToken = previousTokens[1] as NumericToken;
		NumericToken numericToken2 = previousTokens[2] as NumericToken;
		if (numericToken == null || numericToken2 == null)
		{
			if (numericToken2 == null || !(previousTokens[1] is OperatorToken operatorToken))
			{
				return false;
			}
			Match match = EndsWithNumberRegex.Match(operatorToken.Data);
			if (!match.Success || !int.TryParse(match.Value, NumberStyles.Any, CultureInfo.InvariantCulture, out var result))
			{
				return false;
			}
			num2 = previousTokenPositions[1] + match.Index;
			numericToken = new NumericToken(result);
		}
		bool flag = false;
		long? actualTokenStart;
		while (coreTokenScanner.MoveNext() && !IsToken(coreTokenScanner, OperatorToken.EndObject, out actualTokenStart))
		{
			if (coreTokenScanner.CurrentToken is CommentToken)
			{
				continue;
			}
			if (coreTokenScanner.CurrentToken == OperatorToken.StartObject)
			{
				if (flag && readTokens[0] is StreamToken item)
				{
					readTokens.Clear();
					readTokens.Add(item);
					coreTokenScanner.Seek(previousTokenPositions[0]);
					break;
				}
				if (readTokens.Count == 3 && readTokens[1] is NumericToken && readTokens[2] is NumericToken)
				{
					IndirectReference indirectReference = new IndirectReference(numericToken.Int, numericToken2.Int);
					IToken data = encryptionHandler.Decrypt(indirectReference, readTokens[0]);
					CurrentToken = new ObjectToken(num2, indirectReference, data);
					readTokens.Clear();
					coreTokenScanner.Seek(previousTokenPositions[0]);
					return true;
				}
				return false;
			}
			if (IsToken(coreTokenScanner, OperatorToken.Xref, out actualTokenStart) || IsToken(coreTokenScanner, OperatorToken.StartXref, out actualTokenStart))
			{
				if (flag && readTokens[0] is StreamToken item2)
				{
					readTokens.Clear();
					readTokens.Add(item2);
					coreTokenScanner.Seek(previousTokenPositions[2]);
					break;
				}
				if (readTokens.Count == 1)
				{
					IndirectReference indirectReference2 = new IndirectReference(numericToken.Int, numericToken2.Int);
					IToken data2 = encryptionHandler.Decrypt(indirectReference2, readTokens[0]);
					CurrentToken = new ObjectToken(num2, indirectReference2, data2);
					readTokens.Clear();
					coreTokenScanner.Seek(previousTokenPositions[2]);
					return true;
				}
				return false;
			}
			if (IsToken(coreTokenScanner, OperatorToken.StartStream, out var actualTokenStart2))
			{
				IndirectReference indirectReference3 = new IndirectReference(numericToken.Long, numericToken2.Int);
				bool getLength = !isBruteForcing && (!callingObject.HasValue || !callingObject.Value.Equals(indirectReference3));
				IndirectReference? indirectReference4 = callingObject;
				try
				{
					callingObject = indirectReference3;
					if (TryReadStream(actualTokenStart2.Value, getLength, out StreamToken stream))
					{
						readTokens.Clear();
						readTokens.Add(stream);
						flag = true;
					}
				}
				finally
				{
					callingObject = indirectReference4;
				}
			}
			else
			{
				readTokens.Add(coreTokenScanner.CurrentToken);
			}
			previousTokens[0] = previousTokens[1];
			previousTokenPositions[0] = previousTokenPositions[1];
			previousTokens[1] = previousTokens[2];
			previousTokenPositions[1] = previousTokenPositions[2];
			previousTokens[2] = coreTokenScanner.CurrentToken;
			previousTokenPositions[2] = coreTokenScanner.CurrentTokenStart;
		}
		if (!flag && !IsToken(coreTokenScanner, OperatorToken.EndObject, out actualTokenStart))
		{
			readTokens.Clear();
			return false;
		}
		IndirectReference indirectReference5 = new IndirectReference(numericToken.Long, numericToken2.Int);
		IToken token;
		if (readTokens.Count == 3 && readTokens[0] is NumericToken numericToken3 && readTokens[1] is NumericToken numericToken4 && readTokens[2] == OperatorToken.R)
		{
			token = new IndirectReferenceToken(new IndirectReference(numericToken3.Long, numericToken4.Int));
		}
		else if (readTokens.Count > 1)
		{
			List<IToken> list = readTokens.Where((IToken x) => !(x is OperatorToken operatorToken2) || (operatorToken2.Data != ">" && operatorToken2.Data != "]")).ToList();
			token = ((list.Count == 1) ? list[0] : ((!(readTokens[0] is StreamToken streamToken) || !readTokens.Skip(1).All((IToken x) => x is OperatorToken operatorToken2 && operatorToken2.Equals(OperatorToken.EndStream))) ? readTokens[readTokens.Count - 1] : streamToken));
		}
		else
		{
			token = readTokens[readTokens.Count - 1];
		}
		token = encryptionHandler.Decrypt(indirectReference5, token);
		CurrentToken = new ObjectToken(num2, indirectReference5, token);
		objectLocationProvider.UpdateOffset(indirectReference5, num2);
		readTokens.Clear();
		return true;
	}

	private bool IsToken(CoreTokenScanner scanner, OperatorToken token, [NotNullWhen(true)] out long? actualTokenStart)
	{
		if (scanner.CurrentToken == token)
		{
			actualTokenStart = scanner.CurrentTokenStart;
			return true;
		}
		if (parsingOptions.UseLenientParsing && scanner.CurrentToken is OperatorToken operatorToken && operatorToken.Data.EndsWith(token.Data))
		{
			actualTokenStart = scanner.CurrentTokenStart + operatorToken.Data.Length - token.Data.Length;
			return true;
		}
		actualTokenStart = null;
		return false;
	}

	private bool TryReadStream(long startStreamTokenOffset, bool getLength, [NotNullWhen(true)] out StreamToken? stream)
	{
		stream = null;
		DictionaryToken streamDictionary = GetStreamDictionary();
		long? num = (getLength ? GetStreamLength(streamDictionary) : ((long?)null));
		if (!getLength && streamDictionary.TryGet(NameToken.Length, out NumericToken token))
		{
			num = token.Long;
		}
		if (!ReadStreamTokenStart(inputBytes, startStreamTokenOffset))
		{
			return false;
		}
		do
		{
			if (!inputBytes.MoveNext())
			{
				return false;
			}
			if (inputBytes.CurrentByte == 13)
			{
				if (inputBytes.Peek() == 10)
				{
					inputBytes.MoveNext();
				}
				break;
			}
		}
		while (inputBytes.CurrentByte != 10);
		long currentOffset = inputBytes.CurrentOffset;
		long num2 = 0L;
		int num3 = 0;
		int num4 = 0;
		int num5 = 0;
		if (TryReadUsingLength(inputBytes, num, currentOffset, out byte[] data))
		{
			stream = new StreamToken(streamDictionary, data);
			return true;
		}
		long currentOffset2 = inputBytes.CurrentOffset;
		PossibleStreamEndLocation? possibleStreamEndLocation = null;
		while (inputBytes.MoveNext())
		{
			if (num.HasValue)
			{
				_ = num2 == num;
			}
			if (num5 < "end".Length && inputBytes.CurrentByte == "end"[num5])
			{
				num5++;
			}
			else if (num5 == "end".Length)
			{
				if (inputBytes.CurrentByte == "stream"[num4])
				{
					num3 = 0;
					num4++;
					if (num4 == "stream".Length && (!inputBytes.MoveNext() || ReadHelper.IsWhitespace(inputBytes.CurrentByte)))
					{
						PossibleStreamEndLocation value = new PossibleStreamEndLocation(inputBytes.CurrentOffset - OperatorToken.EndStream.Data.Length, OperatorToken.EndStream);
						possibleStreamEndLocation = value;
						if (num.HasValue && num2 > num)
						{
							break;
						}
						num4 = 0;
					}
				}
				else if (inputBytes.CurrentByte == "obj"[num3])
				{
					num4 = 0;
					num3++;
					if (num3 == "obj".Length)
					{
						if (possibleStreamEndLocation.HasValue)
						{
							PossibleStreamEndLocation value2 = possibleStreamEndLocation.Value;
							inputBytes.Seek(value2.Offset + value2.Type.Data.Length + 1);
							break;
						}
						PossibleStreamEndLocation value3 = new PossibleStreamEndLocation(inputBytes.CurrentOffset - OperatorToken.EndObject.Data.Length, OperatorToken.EndObject);
						possibleStreamEndLocation = value3;
						if (num2 > num)
						{
							break;
						}
					}
				}
				else
				{
					num4 = 0;
					num3 = 0;
					num5 = 0;
				}
			}
			else
			{
				num4 = 0;
				num3 = 0;
				num5 = ((inputBytes.CurrentByte == "end"[0]) ? 1 : 0);
			}
			num2++;
		}
		long position = inputBytes.CurrentOffset + 1;
		if (!possibleStreamEndLocation.HasValue)
		{
			return false;
		}
		PossibleStreamEndLocation? possibleStreamEndLocation2 = possibleStreamEndLocation;
		long num6 = possibleStreamEndLocation2.Value.Offset - currentOffset;
		inputBytes.Seek(possibleStreamEndLocation2.Value.Offset - 3);
		inputBytes.MoveNext();
		num6 = ((inputBytes.CurrentByte != 13) ? (num6 - 2) : (num6 - 3));
		Memory<byte> data2 = new byte[num6];
		inputBytes.Seek(currentOffset2);
		inputBytes.Read(data2.Span);
		inputBytes.Seek(position);
		stream = new StreamToken(streamDictionary, data2);
		return true;
	}

	private static bool TryReadUsingLength(IInputBytes inputBytes, long? length, long startDataOffset, [NotNullWhen(true)] out byte[]? data)
	{
		data = null;
		if (!length.HasValue || length.Value + startDataOffset >= inputBytes.Length)
		{
			return false;
		}
		byte[] array = new byte[EndstreamBytes.Length];
		int num = 0;
		inputBytes.Seek(length.Value + startDataOffset);
		byte? b = inputBytes.Peek();
		if (b.HasValue && ReadHelper.IsEndOfLine(b.Value))
		{
			num++;
			inputBytes.MoveNext();
			b = inputBytes.Peek();
			if (b.HasValue && ReadHelper.IsEndOfLine(b.Value))
			{
				num++;
				inputBytes.MoveNext();
			}
		}
		if (inputBytes.Read(array) != array.Length)
		{
			return false;
		}
		for (int i = 0; i < EndstreamBytes.Length; i++)
		{
			if (array[i] != EndstreamBytes[i])
			{
				inputBytes.Seek(startDataOffset);
				return false;
			}
		}
		inputBytes.Seek(startDataOffset);
		data = new byte[(int)length.Value];
		int num2 = inputBytes.Read(data);
		if (num2 != data.Length)
		{
			throw new InvalidOperationException($"Reading using the stream length failed to read as many bytes as the stream specified. Wanted {length.Value}, got {num2} at {startDataOffset + 1}.");
		}
		inputBytes.Read(array);
		for (int j = 0; j < num; j++)
		{
			if (!inputBytes.MoveNext())
			{
				inputBytes.Seek(startDataOffset);
				return false;
			}
		}
		inputBytes.MoveNext();
		return true;
	}

	private DictionaryToken GetStreamDictionary()
	{
		if (previousTokens[2] is DictionaryToken result)
		{
			return result;
		}
		if (previousTokens[1] is DictionaryToken result2)
		{
			return result2;
		}
		throw new PdfDocumentFormatException("No dictionary token was found prior to the 'stream' operator. Previous tokens were:" + $" {previousTokens[2]} and {previousTokens[1]}.");
	}

	private long? GetStreamLength(DictionaryToken dictionary)
	{
		if (!dictionary.Data.TryGetValue("Length", out var value))
		{
			return null;
		}
		long? result = null;
		if (value is NumericToken numericToken)
		{
			return numericToken.Long;
		}
		long currentOffset = inputBytes.CurrentOffset;
		if (value is IndirectReferenceToken indirectReferenceToken && objectLocationProvider.TryGetOffset(indirectReferenceToken.Data, out var offset))
		{
			if (offset < 0)
			{
				ushort searchDepth = 0;
				ObjectToken objectFromStream = GetObjectFromStream(indirectReferenceToken.Data, offset, ref searchDepth);
				return ((objectFromStream.Data as NumericToken) ?? throw new PdfDocumentFormatException($"Could not locate the length object with offset {offset} which should have been in a stream." + $" Found: {objectFromStream.Data}.")).Long;
			}
			Seek(offset);
			List<IToken> collection = new List<IToken>(readTokens);
			readTokens.Clear();
			if (MoveNext() && ((ObjectToken)CurrentToken).Data is NumericToken numericToken2)
			{
				result = numericToken2.Long;
			}
			readTokens.AddRange(collection);
			Seek(currentOffset);
		}
		return result;
	}

	private static bool ReadStreamTokenStart(IInputBytes input, long tokenStart)
	{
		input.Seek(tokenStart);
		for (int i = 0; i < OperatorToken.StartStream.Data.Length; i++)
		{
			if (!input.MoveNext() || input.CurrentByte != OperatorToken.StartStream.Data[i])
			{
				input.Seek(tokenStart);
				return false;
			}
		}
		return true;
	}

	public bool TryReadToken<T>(out T token) where T : class, IToken
	{
		if (isDisposed)
		{
			throw new ObjectDisposedException("PdfTokenScanner");
		}
		return coreTokenScanner.TryReadToken<T>(out token);
	}

	public void Seek(long position)
	{
		if (isDisposed)
		{
			throw new ObjectDisposedException("PdfTokenScanner");
		}
		coreTokenScanner.Seek(position);
	}

	public void RegisterCustomTokenizer(byte firstByte, ITokenizer tokenizer)
	{
		if (isDisposed)
		{
			throw new ObjectDisposedException("PdfTokenScanner");
		}
		coreTokenScanner.RegisterCustomTokenizer(firstByte, tokenizer);
	}

	public void DeregisterCustomTokenizer(ITokenizer tokenizer)
	{
		if (isDisposed)
		{
			throw new ObjectDisposedException("PdfTokenScanner");
		}
		coreTokenScanner.DeregisterCustomTokenizer(tokenizer);
	}

	public ObjectToken? Get(IndirectReference reference)
	{
		ushort searchDepth = 0;
		return Get(reference, ref searchDepth);
	}

	private ObjectToken? Get(IndirectReference reference, ref ushort searchDepth)
	{
		if (searchDepth > 100)
		{
			throw new PdfDocumentFormatException("Reached maximum search depth while getting indirect reference.");
		}
		searchDepth++;
		if (isDisposed)
		{
			throw new ObjectDisposedException("PdfTokenScanner");
		}
		if (overwrittenTokens.TryGetValue(reference, out ObjectToken value))
		{
			return value;
		}
		if (objectLocationProvider.TryGetCached(reference, out ObjectToken objectToken))
		{
			return objectToken;
		}
		if (!objectLocationProvider.TryGetOffset(reference, out var offset))
		{
			return null;
		}
		if (offset < 0)
		{
			return GetObjectFromStream(reference, offset, ref searchDepth);
		}
		if (offset == 0L && reference.Generation > 65535)
		{
			return new ObjectToken(offset, reference, NullToken.Instance);
		}
		Seek(offset);
		if (!MoveNext())
		{
			TryBruteForceFileToFindReference(reference, out ObjectToken result);
			return result;
		}
		ObjectToken objectToken2 = (ObjectToken)CurrentToken;
		if (objectToken2.Number.Equals(reference))
		{
			return objectToken2;
		}
		TryBruteForceFileToFindReference(reference, out ObjectToken result2);
		return result2;
	}

	public void ReplaceToken(IndirectReference reference, IToken token)
	{
		overwrittenTokens[reference] = new ObjectToken(0L, reference, token);
	}

	private bool TryBruteForceFileToFindReference(IndirectReference reference, [NotNullWhen(true)] out ObjectToken? result)
	{
		result = null;
		try
		{
			isBruteForcing = true;
			Seek(fileHeaderOffset.Value);
			while (MoveNext())
			{
				objectLocationProvider.Cache((ObjectToken)CurrentToken, force: true);
			}
			if (!objectLocationProvider.TryGetCached(reference, out ObjectToken objectToken))
			{
				return false;
			}
			result = objectToken;
			return true;
		}
		finally
		{
			isBruteForcing = false;
		}
	}

	private ObjectToken GetObjectFromStream(IndirectReference reference, long offset, ref ushort searchDepth)
	{
		long num = offset * -1;
		ObjectToken objectToken = Get(new IndirectReference(num, 0), ref searchDepth);
		if (!(objectToken?.Data is StreamToken stream))
		{
			throw new PdfDocumentFormatException("Requested a stream object by reference but the requested stream object " + $"was not a stream: {reference}, {objectToken?.Data}.");
		}
		foreach (ObjectToken item in ParseObjectStream(stream, offset))
		{
			objectLocationProvider.Cache(item);
		}
		if (!objectLocationProvider.TryGetCached(reference, out ObjectToken objectToken2))
		{
			throw new PdfDocumentFormatException($"Could not find the object {reference} in the stream {num}.");
		}
		return objectToken2;
	}

	private IReadOnlyList<ObjectToken> ParseObjectStream(StreamToken stream, long offset)
	{
		if (!stream.StreamDictionary.TryGet(NameToken.N, out var token) || !(token is NumericToken numericToken))
		{
			throw new PdfDocumentFormatException($"Object stream dictionary did not provide number of objects {stream.StreamDictionary}.");
		}
		if (!stream.StreamDictionary.TryGet(NameToken.First, out var token2) || !(token2 is NumericToken { Long: var num }))
		{
			throw new PdfDocumentFormatException($"Object stream dictionary did not provide first object offset {stream.StreamDictionary}.");
		}
		CoreTokenScanner coreTokenScanner = new CoreTokenScanner(new MemoryInputBytes(stream.Decode(filterProvider, this)), usePdfDocEncoding: true, ScannerScope.None, null, parsingOptions.UseLenientParsing, isStream: true);
		List<(long, long)> list = new List<(long, long)>();
		for (int i = 0; i < numericToken.Int; i++)
		{
			coreTokenScanner.MoveNext();
			NumericToken numericToken3 = (NumericToken)coreTokenScanner.CurrentToken;
			coreTokenScanner.MoveNext();
			NumericToken numericToken4 = (NumericToken)coreTokenScanner.CurrentToken;
			list.Add((numericToken3.Long, num + numericToken4.Long));
		}
		List<ObjectToken> list2 = new List<ObjectToken>();
		for (int j = 0; j < list.Count; j++)
		{
			(long, long) tuple = list[j];
			if (((tuple.Item2 - (coreTokenScanner.CurrentPosition - 1)) | (coreTokenScanner.CurrentPosition + 1 - tuple.Item2)) < 0)
			{
				coreTokenScanner.Seek(tuple.Item2);
			}
			coreTokenScanner.MoveNext();
			IToken currentToken = coreTokenScanner.CurrentToken;
			if (currentToken.Equals(OperatorToken.EndObject))
			{
				coreTokenScanner.MoveNext();
				currentToken = coreTokenScanner.CurrentToken;
			}
			list2.Add(new ObjectToken(offset, new IndirectReference(tuple.Item1, 0), currentToken));
		}
		return list2;
	}

	public void Dispose()
	{
		inputBytes?.Dispose();
		isDisposed = true;
	}
}
