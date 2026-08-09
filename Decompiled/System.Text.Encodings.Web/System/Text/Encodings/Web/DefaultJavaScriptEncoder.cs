using System.Buffers;
using System.Text.Unicode;

namespace System.Text.Encodings.Web;

internal sealed class DefaultJavaScriptEncoder : JavaScriptEncoder
{
	private sealed class EscaperImplementation : ScalarEscaperBase
	{
		internal static readonly EscaperImplementation Singleton = new EscaperImplementation(allowMinimalEscaping: false);

		internal static readonly EscaperImplementation SingletonMinimallyEscaped = new EscaperImplementation(allowMinimalEscaping: true);

		private readonly AsciiByteMap _preescapedMap;

		private EscaperImplementation(bool allowMinimalEscaping)
		{
			_preescapedMap.InsertAsciiChar('\b', 98);
			_preescapedMap.InsertAsciiChar('\t', 116);
			_preescapedMap.InsertAsciiChar('\n', 110);
			_preescapedMap.InsertAsciiChar('\f', 102);
			_preescapedMap.InsertAsciiChar('\r', 114);
			_preescapedMap.InsertAsciiChar('\\', 92);
			if (allowMinimalEscaping)
			{
				_preescapedMap.InsertAsciiChar('"', 34);
			}
		}

		internal override int EncodeUtf8(Rune value, Span<byte> destination)
		{
			if (_preescapedMap.TryLookup(value, out var value2))
			{
				if (SpanUtility.IsValidIndex(destination, 1))
				{
					destination[0] = 92;
					destination[1] = value2;
					return 2;
				}
				return -1;
			}
			return TryEncodeScalarAsHex(this, value, destination);
			static int TryEncodeScalarAsHex(object @this, Rune rune, Span<byte> span)
			{
				if (rune.IsBmp)
				{
					if (SpanUtility.IsValidIndex(span, 5))
					{
						span[0] = 92;
						span[1] = 117;
						HexConverter.ToBytesBuffer((byte)rune.Value, span, 4);
						HexConverter.ToBytesBuffer((byte)((uint)rune.Value >> 8), span, 2);
						return 6;
					}
				}
				else
				{
					UnicodeHelpers.GetUtf16SurrogatePairFromAstralScalarValue((uint)rune.Value, out var highSurrogate, out var lowSurrogate);
					if (SpanUtility.IsValidIndex(span, 11))
					{
						span[0] = 92;
						span[1] = 117;
						HexConverter.ToBytesBuffer((byte)highSurrogate, span, 4);
						HexConverter.ToBytesBuffer((byte)((uint)highSurrogate >> 8), span, 2);
						span[6] = 92;
						span[7] = 117;
						HexConverter.ToBytesBuffer((byte)lowSurrogate, span, 10);
						HexConverter.ToBytesBuffer((byte)((uint)lowSurrogate >> 8), span, 8);
						return 12;
					}
				}
				return -1;
			}
		}

		internal override int EncodeUtf16(Rune value, Span<char> destination)
		{
			if (_preescapedMap.TryLookup(value, out var value2))
			{
				if (SpanUtility.IsValidIndex(destination, 1))
				{
					destination[0] = '\\';
					destination[1] = (char)value2;
					return 2;
				}
				return -1;
			}
			return TryEncodeScalarAsHex(this, value, destination);
			static int TryEncodeScalarAsHex(object @this, Rune rune, Span<char> span)
			{
				if (rune.IsBmp)
				{
					if (SpanUtility.IsValidIndex(span, 5))
					{
						span[0] = '\\';
						span[1] = 'u';
						HexConverter.ToCharsBuffer((byte)rune.Value, span, 4);
						HexConverter.ToCharsBuffer((byte)((uint)rune.Value >> 8), span, 2);
						return 6;
					}
				}
				else
				{
					UnicodeHelpers.GetUtf16SurrogatePairFromAstralScalarValue((uint)rune.Value, out var highSurrogate, out var lowSurrogate);
					if (SpanUtility.IsValidIndex(span, 11))
					{
						span[0] = '\\';
						span[1] = 'u';
						HexConverter.ToCharsBuffer((byte)highSurrogate, span, 4);
						HexConverter.ToCharsBuffer((byte)((uint)highSurrogate >> 8), span, 2);
						span[6] = '\\';
						span[7] = 'u';
						HexConverter.ToCharsBuffer((byte)lowSurrogate, span, 10);
						HexConverter.ToCharsBuffer((byte)((uint)lowSurrogate >> 8), span, 8);
						return 12;
					}
				}
				return -1;
			}
		}
	}

	internal static readonly DefaultJavaScriptEncoder BasicLatinSingleton = new DefaultJavaScriptEncoder(new TextEncoderSettings(UnicodeRanges.BasicLatin));

	internal static readonly DefaultJavaScriptEncoder UnsafeRelaxedEscapingSingleton = new DefaultJavaScriptEncoder(new TextEncoderSettings(UnicodeRanges.All), allowMinimalJsonEscaping: true);

	private readonly OptimizedInboxTextEncoder _innerEncoder;

	public override int MaxOutputCharactersPerInputCharacter => 6;

	internal DefaultJavaScriptEncoder(TextEncoderSettings settings)
		: this(settings, allowMinimalJsonEscaping: false)
	{
	}

	private DefaultJavaScriptEncoder(TextEncoderSettings settings, bool allowMinimalJsonEscaping)
	{
		if (settings == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.settings);
		}
		OptimizedInboxTextEncoder innerEncoder;
		if (!allowMinimalJsonEscaping)
		{
			EscaperImplementation singleton = EscaperImplementation.Singleton;
			ref readonly AllowedBmpCodePointsBitmap allowedCodePointsBitmap = ref settings.GetAllowedCodePointsBitmap();
			object obj = global::_003CPrivateImplementationDetails_003E._7533ADF00A145D285CDFDCD7A63332C731915F01A2A9BB101362BB8D0CF847C4_A1;
			if (obj == null)
			{
				obj = new char[2] { '\\', '`' };
				global::_003CPrivateImplementationDetails_003E._7533ADF00A145D285CDFDCD7A63332C731915F01A2A9BB101362BB8D0CF847C4_A1 = (char[])obj;
			}
			innerEncoder = new OptimizedInboxTextEncoder(singleton, in allowedCodePointsBitmap, forbidHtmlSensitiveCharacters: true, new ReadOnlySpan<char>((char[])obj));
		}
		else
		{
			EscaperImplementation singletonMinimallyEscaped = EscaperImplementation.SingletonMinimallyEscaped;
			ref readonly AllowedBmpCodePointsBitmap allowedCodePointsBitmap2 = ref settings.GetAllowedCodePointsBitmap();
			object obj2 = global::_003CPrivateImplementationDetails_003E._580978A21F179B0480F4AC4BBAA7E699110F4C9E1282B63758A7E9653CA0EDE4_A1;
			if (obj2 == null)
			{
				obj2 = new char[2] { '"', '\\' };
				global::_003CPrivateImplementationDetails_003E._580978A21F179B0480F4AC4BBAA7E699110F4C9E1282B63758A7E9653CA0EDE4_A1 = (char[])obj2;
			}
			innerEncoder = new OptimizedInboxTextEncoder(singletonMinimallyEscaped, in allowedCodePointsBitmap2, forbidHtmlSensitiveCharacters: false, new ReadOnlySpan<char>((char[])obj2));
		}
		_innerEncoder = innerEncoder;
	}

	private protected override OperationStatus EncodeCore(ReadOnlySpan<char> source, Span<char> destination, out int charsConsumed, out int charsWritten, bool isFinalBlock)
	{
		return _innerEncoder.Encode(source, destination, out charsConsumed, out charsWritten, isFinalBlock);
	}

	private protected override OperationStatus EncodeUtf8Core(ReadOnlySpan<byte> utf8Source, Span<byte> utf8Destination, out int bytesConsumed, out int bytesWritten, bool isFinalBlock)
	{
		return _innerEncoder.EncodeUtf8(utf8Source, utf8Destination, out bytesConsumed, out bytesWritten, isFinalBlock);
	}

	private protected override int FindFirstCharacterToEncode(ReadOnlySpan<char> text)
	{
		return _innerEncoder.GetIndexOfFirstCharToEncode(text);
	}

	public unsafe override int FindFirstCharacterToEncode(char* text, int textLength)
	{
		return _innerEncoder.FindFirstCharacterToEncode(text, textLength);
	}

	public override int FindFirstCharacterToEncodeUtf8(ReadOnlySpan<byte> utf8Text)
	{
		return _innerEncoder.GetIndexOfFirstByteToEncode(utf8Text);
	}

	public unsafe override bool TryEncodeUnicodeScalar(int unicodeScalar, char* buffer, int bufferLength, out int numberOfCharactersWritten)
	{
		return _innerEncoder.TryEncodeUnicodeScalar(unicodeScalar, buffer, bufferLength, out numberOfCharactersWritten);
	}

	public override bool WillEncode(int unicodeScalar)
	{
		return !_innerEncoder.IsScalarValueAllowed(new Rune(unicodeScalar));
	}
}
