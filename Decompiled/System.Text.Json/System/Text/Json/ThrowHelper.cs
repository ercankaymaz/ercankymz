using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO.Pipelines;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;

namespace System.Text.Json;

internal static class ThrowHelper
{
	public const string ExceptionSourceValueToRethrowAsJsonException = "System.Text.Json.Rethrowable";

	[MethodImpl(MethodImplOptions.NoInlining)]
	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowOutOfMemoryException_BufferMaximumSizeExceeded(uint capacity)
	{
		throw new OutOfMemoryException(System.SR.Format(System.SR.BufferMaximumSizeExceeded, capacity));
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowArgumentNullException(string parameterName)
	{
		throw new ArgumentNullException(parameterName);
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowArgumentOutOfRangeException_NewLine(string parameterName)
	{
		throw GetArgumentOutOfRangeException(parameterName, System.SR.InvalidNewLine);
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowArgumentOutOfRangeException_IndentCharacter(string parameterName)
	{
		throw GetArgumentOutOfRangeException(parameterName, System.SR.InvalidIndentCharacter);
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowArgumentOutOfRangeException_IndentSize(string parameterName, int minimumSize, int maximumSize)
	{
		throw GetArgumentOutOfRangeException(parameterName, System.SR.Format(System.SR.InvalidIndentSize, minimumSize, maximumSize));
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowArgumentOutOfRangeException_MaxDepthMustBePositive(string parameterName)
	{
		throw GetArgumentOutOfRangeException(parameterName, System.SR.MaxDepthMustBePositive);
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowArgumentOutOfRangeException_JsonNumberExponentTooLarge(string parameterName)
	{
		throw GetArgumentOutOfRangeException(parameterName, System.SR.JsonNumberExponentTooLarge);
	}

	private static ArgumentOutOfRangeException GetArgumentOutOfRangeException(string parameterName, string message)
	{
		return new ArgumentOutOfRangeException(parameterName, message);
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowArgumentOutOfRangeException_CommentEnumMustBeInRange(string parameterName)
	{
		throw GetArgumentOutOfRangeException(parameterName, System.SR.CommentHandlingMustBeValid);
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowArgumentOutOfRangeException_ArrayIndexNegative(string paramName)
	{
		throw new ArgumentOutOfRangeException(paramName, System.SR.ArrayIndexNegative);
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowArgumentOutOfRangeException_JsonConverterFactory_TypeNotSupported(Type typeToConvert)
	{
		throw new ArgumentOutOfRangeException("typeToConvert", System.SR.Format(System.SR.SerializerConverterFactoryInvalidArgument, typeToConvert.FullName));
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowArgumentException_ArrayTooSmall(string paramName)
	{
		throw new ArgumentException(System.SR.ArrayTooSmall, paramName);
	}

	private static ArgumentException GetArgumentException(string message)
	{
		return new ArgumentException(message);
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowArgumentException(string message)
	{
		throw GetArgumentException(message);
	}

	public static InvalidOperationException GetInvalidOperationException_CallFlushFirst(int _buffered)
	{
		return GetInvalidOperationException(System.SR.Format(System.SR.CallFlushToAvoidDataLoss, _buffered));
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowArgumentException_DestinationTooShort()
	{
		throw GetArgumentException(System.SR.DestinationTooShort);
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowArgumentException_PropertyNameTooLarge(int tokenLength)
	{
		throw GetArgumentException(System.SR.Format(System.SR.PropertyNameTooLarge, tokenLength));
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowArgumentException_ValueTooLarge(long tokenLength)
	{
		throw GetArgumentException(System.SR.Format(System.SR.ValueTooLarge, tokenLength));
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowArgumentException_ValueNotSupported()
	{
		throw GetArgumentException(System.SR.SpecialNumberValuesNotSupported);
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowInvalidOperationException_NeedLargerSpan()
	{
		throw GetInvalidOperationException(System.SR.FailedToGetLargerSpan);
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowPropertyNameTooLargeArgumentException(int length)
	{
		throw GetArgumentException(System.SR.Format(System.SR.PropertyNameTooLarge, length));
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowArgumentException(ReadOnlySpan<byte> propertyName, ReadOnlySpan<byte> value)
	{
		if (propertyName.Length > 166666666)
		{
			ThrowArgumentException(System.SR.Format(System.SR.PropertyNameTooLarge, propertyName.Length));
		}
		else
		{
			ThrowArgumentException(System.SR.Format(System.SR.ValueTooLarge, value.Length));
		}
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowArgumentException(ReadOnlySpan<byte> propertyName, ReadOnlySpan<char> value)
	{
		if (propertyName.Length > 166666666)
		{
			ThrowArgumentException(System.SR.Format(System.SR.PropertyNameTooLarge, propertyName.Length));
		}
		else
		{
			ThrowArgumentException(System.SR.Format(System.SR.ValueTooLarge, value.Length));
		}
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowArgumentException(ReadOnlySpan<char> propertyName, ReadOnlySpan<byte> value)
	{
		if (propertyName.Length > 166666666)
		{
			ThrowArgumentException(System.SR.Format(System.SR.PropertyNameTooLarge, propertyName.Length));
		}
		else
		{
			ThrowArgumentException(System.SR.Format(System.SR.ValueTooLarge, value.Length));
		}
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowArgumentException(ReadOnlySpan<char> propertyName, ReadOnlySpan<char> value)
	{
		if (propertyName.Length > 166666666)
		{
			ThrowArgumentException(System.SR.Format(System.SR.PropertyNameTooLarge, propertyName.Length));
		}
		else
		{
			ThrowArgumentException(System.SR.Format(System.SR.ValueTooLarge, value.Length));
		}
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowInvalidOperationOrArgumentException(ReadOnlySpan<byte> propertyName, int currentDepth, int maxDepth)
	{
		currentDepth &= 0x7FFFFFFF;
		if (currentDepth >= maxDepth)
		{
			ThrowInvalidOperationException(System.SR.Format(System.SR.DepthTooLarge, currentDepth, maxDepth));
		}
		else
		{
			ThrowArgumentException(System.SR.Format(System.SR.PropertyNameTooLarge, propertyName.Length));
		}
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowInvalidOperationException(int currentDepth, int maxDepth)
	{
		currentDepth &= 0x7FFFFFFF;
		ThrowInvalidOperationException(System.SR.Format(System.SR.DepthTooLarge, currentDepth, maxDepth));
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowInvalidOperationException(string message)
	{
		throw GetInvalidOperationException(message);
	}

	private static InvalidOperationException GetInvalidOperationException(string message)
	{
		return new InvalidOperationException(message)
		{
			Source = "System.Text.Json.Rethrowable"
		};
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowInvalidOperationException_DepthNonZeroOrEmptyJson(int currentDepth)
	{
		throw GetInvalidOperationException(currentDepth);
	}

	private static InvalidOperationException GetInvalidOperationException(int currentDepth)
	{
		currentDepth &= 0x7FFFFFFF;
		if (currentDepth != 0)
		{
			return GetInvalidOperationException(System.SR.Format(System.SR.ZeroDepthAtEnd, currentDepth));
		}
		return GetInvalidOperationException(System.SR.EmptyJsonIsInvalid);
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowInvalidOperationOrArgumentException(ReadOnlySpan<char> propertyName, int currentDepth, int maxDepth)
	{
		currentDepth &= 0x7FFFFFFF;
		if (currentDepth >= maxDepth)
		{
			ThrowInvalidOperationException(System.SR.Format(System.SR.DepthTooLarge, currentDepth, maxDepth));
		}
		else
		{
			ThrowArgumentException(System.SR.Format(System.SR.PropertyNameTooLarge, propertyName.Length));
		}
	}

	public static InvalidOperationException GetInvalidOperationException_ExpectedArray(JsonTokenType tokenType)
	{
		return GetInvalidOperationException("array", tokenType);
	}

	public static InvalidOperationException GetInvalidOperationException_ExpectedObject(JsonTokenType tokenType)
	{
		return GetInvalidOperationException("object", tokenType);
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowInvalidOperationException_ExpectedNumber(JsonTokenType tokenType)
	{
		throw GetInvalidOperationException("number", tokenType);
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowInvalidOperationException_ExpectedBoolean(JsonTokenType tokenType)
	{
		throw GetInvalidOperationException("boolean", tokenType);
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowInvalidOperationException_ExpectedString(JsonTokenType tokenType)
	{
		throw GetInvalidOperationException("string", tokenType);
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowInvalidOperationException_ExpectedPropertyName(JsonTokenType tokenType)
	{
		throw GetInvalidOperationException("propertyName", tokenType);
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowInvalidOperationException_ExpectedStringComparison(JsonTokenType tokenType)
	{
		throw GetInvalidOperationException(tokenType);
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowInvalidOperationException_ExpectedComment(JsonTokenType tokenType)
	{
		throw GetInvalidOperationException("comment", tokenType);
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowInvalidOperationException_CannotSkipOnPartial()
	{
		throw GetInvalidOperationException(System.SR.CannotSkip);
	}

	private static InvalidOperationException GetInvalidOperationException(string message, JsonTokenType tokenType)
	{
		return GetInvalidOperationException(System.SR.Format(System.SR.InvalidCast, tokenType, message));
	}

	private static InvalidOperationException GetInvalidOperationException(JsonTokenType tokenType)
	{
		return GetInvalidOperationException(System.SR.Format(System.SR.InvalidComparison, tokenType));
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	internal static void ThrowJsonElementWrongTypeException(JsonTokenType expectedType, JsonTokenType actualType)
	{
		throw GetJsonElementWrongTypeException(expectedType.ToValueKind(), actualType.ToValueKind());
	}

	internal static InvalidOperationException GetJsonElementWrongTypeException(JsonValueKind expectedType, JsonValueKind actualType)
	{
		return GetInvalidOperationException(System.SR.Format(System.SR.JsonElementHasWrongType, expectedType, actualType));
	}

	internal static InvalidOperationException GetJsonElementWrongTypeException(string expectedTypeName, JsonValueKind actualType)
	{
		return GetInvalidOperationException(System.SR.Format(System.SR.JsonElementHasWrongType, expectedTypeName, actualType));
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowJsonReaderException(ref Utf8JsonReader json, ExceptionResource resource, byte nextByte = 0, ReadOnlySpan<byte> bytes = default(ReadOnlySpan<byte>))
	{
		throw GetJsonReaderException(ref json, resource, nextByte, bytes);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static JsonException GetJsonReaderException(ref Utf8JsonReader json, ExceptionResource resource, byte nextByte, ReadOnlySpan<byte> bytes)
	{
		string resourceString = GetResourceString(ref json, resource, nextByte, JsonHelpers.Utf8GetString(bytes));
		long lineNumber = json.CurrentState._lineNumber;
		long bytePositionInLine = json.CurrentState._bytePositionInLine;
		return new JsonReaderException(resourceString + $" LineNumber: {lineNumber} | BytePositionInLine: {bytePositionInLine}.", lineNumber, bytePositionInLine);
	}

	private static bool IsPrintable(byte value)
	{
		if (value >= 32)
		{
			return value < 127;
		}
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static string GetPrintableString(byte value)
	{
		if (!IsPrintable(value))
		{
			return $"0x{value:X2}";
		}
		char c = (char)value;
		return c.ToString();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static string GetResourceString(ref Utf8JsonReader json, ExceptionResource resource, byte nextByte, string characters)
	{
		string printableString = GetPrintableString(nextByte);
		string result = "";
		switch (resource)
		{
		case ExceptionResource.ArrayDepthTooLarge:
			result = System.SR.Format(System.SR.ArrayDepthTooLarge, json.CurrentState.Options.MaxDepth);
			break;
		case ExceptionResource.MismatchedObjectArray:
			result = System.SR.Format(System.SR.MismatchedObjectArray, printableString);
			break;
		case ExceptionResource.TrailingCommaNotAllowedBeforeArrayEnd:
			result = System.SR.TrailingCommaNotAllowedBeforeArrayEnd;
			break;
		case ExceptionResource.TrailingCommaNotAllowedBeforeObjectEnd:
			result = System.SR.TrailingCommaNotAllowedBeforeObjectEnd;
			break;
		case ExceptionResource.EndOfStringNotFound:
			result = System.SR.EndOfStringNotFound;
			break;
		case ExceptionResource.RequiredDigitNotFoundAfterSign:
			result = System.SR.Format(System.SR.RequiredDigitNotFoundAfterSign, printableString);
			break;
		case ExceptionResource.RequiredDigitNotFoundAfterDecimal:
			result = System.SR.Format(System.SR.RequiredDigitNotFoundAfterDecimal, printableString);
			break;
		case ExceptionResource.RequiredDigitNotFoundEndOfData:
			result = System.SR.RequiredDigitNotFoundEndOfData;
			break;
		case ExceptionResource.ExpectedEndAfterSingleJson:
			result = System.SR.Format(System.SR.ExpectedEndAfterSingleJson, printableString);
			break;
		case ExceptionResource.ExpectedEndOfDigitNotFound:
			result = System.SR.Format(System.SR.ExpectedEndOfDigitNotFound, printableString);
			break;
		case ExceptionResource.ExpectedNextDigitEValueNotFound:
			result = System.SR.Format(System.SR.ExpectedNextDigitEValueNotFound, printableString);
			break;
		case ExceptionResource.ExpectedSeparatorAfterPropertyNameNotFound:
			result = System.SR.Format(System.SR.ExpectedSeparatorAfterPropertyNameNotFound, printableString);
			break;
		case ExceptionResource.ExpectedStartOfPropertyNotFound:
			result = System.SR.Format(System.SR.ExpectedStartOfPropertyNotFound, printableString);
			break;
		case ExceptionResource.ExpectedStartOfPropertyOrValueNotFound:
			result = System.SR.ExpectedStartOfPropertyOrValueNotFound;
			break;
		case ExceptionResource.ExpectedStartOfPropertyOrValueAfterComment:
			result = System.SR.Format(System.SR.ExpectedStartOfPropertyOrValueAfterComment, printableString);
			break;
		case ExceptionResource.ExpectedStartOfValueNotFound:
			result = System.SR.Format(System.SR.ExpectedStartOfValueNotFound, printableString);
			break;
		case ExceptionResource.ExpectedValueAfterPropertyNameNotFound:
			result = System.SR.ExpectedValueAfterPropertyNameNotFound;
			break;
		case ExceptionResource.FoundInvalidCharacter:
			result = System.SR.Format(System.SR.FoundInvalidCharacter, printableString);
			break;
		case ExceptionResource.InvalidEndOfJsonNonPrimitive:
			result = System.SR.Format(System.SR.InvalidEndOfJsonNonPrimitive, json.TokenType);
			break;
		case ExceptionResource.ObjectDepthTooLarge:
			result = System.SR.Format(System.SR.ObjectDepthTooLarge, json.CurrentState.Options.MaxDepth);
			break;
		case ExceptionResource.ExpectedFalse:
			result = System.SR.Format(System.SR.ExpectedFalse, characters);
			break;
		case ExceptionResource.ExpectedNull:
			result = System.SR.Format(System.SR.ExpectedNull, characters);
			break;
		case ExceptionResource.ExpectedTrue:
			result = System.SR.Format(System.SR.ExpectedTrue, characters);
			break;
		case ExceptionResource.InvalidCharacterWithinString:
			result = System.SR.Format(System.SR.InvalidCharacterWithinString, printableString);
			break;
		case ExceptionResource.InvalidCharacterAfterEscapeWithinString:
			result = System.SR.Format(System.SR.InvalidCharacterAfterEscapeWithinString, printableString);
			break;
		case ExceptionResource.InvalidHexCharacterWithinString:
			result = System.SR.Format(System.SR.InvalidHexCharacterWithinString, printableString);
			break;
		case ExceptionResource.EndOfCommentNotFound:
			result = System.SR.EndOfCommentNotFound;
			break;
		case ExceptionResource.ZeroDepthAtEnd:
			result = System.SR.Format(System.SR.ZeroDepthAtEnd);
			break;
		case ExceptionResource.ExpectedJsonTokens:
			result = System.SR.ExpectedJsonTokens;
			break;
		case ExceptionResource.NotEnoughData:
			result = System.SR.NotEnoughData;
			break;
		case ExceptionResource.ExpectedOneCompleteToken:
			result = System.SR.ExpectedOneCompleteToken;
			break;
		case ExceptionResource.InvalidCharacterAtStartOfComment:
			result = System.SR.Format(System.SR.InvalidCharacterAtStartOfComment, printableString);
			break;
		case ExceptionResource.UnexpectedEndOfDataWhileReadingComment:
			result = System.SR.Format(System.SR.UnexpectedEndOfDataWhileReadingComment);
			break;
		case ExceptionResource.UnexpectedEndOfLineSeparator:
			result = System.SR.Format(System.SR.UnexpectedEndOfLineSeparator);
			break;
		case ExceptionResource.InvalidLeadingZeroInNumber:
			result = System.SR.Format(System.SR.InvalidLeadingZeroInNumber, printableString);
			break;
		}
		return result;
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowInvalidOperationException(ExceptionResource resource, int currentDepth, int maxDepth, byte token, JsonTokenType tokenType)
	{
		throw GetInvalidOperationException(resource, currentDepth, maxDepth, token, tokenType);
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowArgumentException_InvalidCommentValue()
	{
		throw new ArgumentException(System.SR.CannotWriteCommentWithEmbeddedDelimiter);
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowArgumentException_InvalidUTF8(ReadOnlySpan<byte> value)
	{
		StringBuilder stringBuilder = new StringBuilder();
		int num = Math.Min(value.Length, 10);
		for (int i = 0; i < num; i++)
		{
			byte b = value[i];
			if (IsPrintable(b))
			{
				stringBuilder.Append((char)b);
			}
			else
			{
				stringBuilder.Append($"0x{b:X2}");
			}
		}
		if (num < value.Length)
		{
			stringBuilder.Append("...");
		}
		throw new ArgumentException(System.SR.Format(System.SR.CannotEncodeInvalidUTF8, stringBuilder));
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowArgumentException_InvalidUTF16(int charAsInt)
	{
		throw new ArgumentException(System.SR.Format(System.SR.CannotEncodeInvalidUTF16, $"0x{charAsInt:X2}"));
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowInvalidOperationException_ReadInvalidUTF16(int charAsInt)
	{
		throw GetInvalidOperationException(System.SR.Format(System.SR.CannotReadInvalidUTF16, $"0x{charAsInt:X2}"));
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowInvalidOperationException_ReadIncompleteUTF16()
	{
		throw GetInvalidOperationException(System.SR.CannotReadIncompleteUTF16);
	}

	public static InvalidOperationException GetInvalidOperationException_ReadInvalidUTF8(DecoderFallbackException innerException = null)
	{
		return GetInvalidOperationException(System.SR.CannotTranscodeInvalidUtf8, innerException);
	}

	public static ArgumentException GetArgumentException_ReadInvalidUTF16(EncoderFallbackException innerException)
	{
		return new ArgumentException(System.SR.CannotTranscodeInvalidUtf16, innerException);
	}

	public static InvalidOperationException GetInvalidOperationException(string message, Exception innerException)
	{
		return new InvalidOperationException(message, innerException)
		{
			Source = "System.Text.Json.Rethrowable"
		};
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static InvalidOperationException GetInvalidOperationException(ExceptionResource resource, int currentDepth, int maxDepth, byte token, JsonTokenType tokenType)
	{
		InvalidOperationException invalidOperationException = GetInvalidOperationException(GetResourceString(resource, currentDepth, maxDepth, token, tokenType));
		invalidOperationException.Source = "System.Text.Json.Rethrowable";
		return invalidOperationException;
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowOutOfMemoryException(uint capacity)
	{
		throw new OutOfMemoryException(System.SR.Format(System.SR.BufferMaximumSizeExceeded, capacity));
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static string GetResourceString(ExceptionResource resource, int currentDepth, int maxDepth, byte token, JsonTokenType tokenType)
	{
		string result = "";
		switch (resource)
		{
		case ExceptionResource.MismatchedObjectArray:
			result = ((tokenType == JsonTokenType.PropertyName) ? System.SR.Format(System.SR.CannotWriteEndAfterProperty, (char)token) : System.SR.Format(System.SR.MismatchedObjectArray, (char)token));
			break;
		case ExceptionResource.DepthTooLarge:
			result = System.SR.Format(System.SR.DepthTooLarge, currentDepth & 0x7FFFFFFF, maxDepth);
			break;
		case ExceptionResource.CannotStartObjectArrayWithoutProperty:
			result = System.SR.Format(System.SR.CannotStartObjectArrayWithoutProperty, tokenType);
			break;
		case ExceptionResource.CannotStartObjectArrayAfterPrimitiveOrClose:
			result = System.SR.Format(System.SR.CannotStartObjectArrayAfterPrimitiveOrClose, tokenType);
			break;
		case ExceptionResource.CannotWriteValueWithinObject:
			result = System.SR.Format(System.SR.CannotWriteValueWithinObject, tokenType);
			break;
		case ExceptionResource.CannotWritePropertyWithinArray:
			result = ((tokenType == JsonTokenType.PropertyName) ? System.SR.Format(System.SR.CannotWritePropertyAfterProperty) : System.SR.Format(System.SR.CannotWritePropertyWithinArray, tokenType));
			break;
		case ExceptionResource.CannotWriteValueAfterPrimitiveOrClose:
			result = System.SR.Format(System.SR.CannotWriteValueAfterPrimitiveOrClose, tokenType);
			break;
		}
		return result;
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowFormatException()
	{
		throw new FormatException
		{
			Source = "System.Text.Json.Rethrowable"
		};
	}

	public static void ThrowFormatException(NumericType numericType)
	{
		string message = "";
		switch (numericType)
		{
		case NumericType.Byte:
			message = System.SR.FormatByte;
			break;
		case NumericType.SByte:
			message = System.SR.FormatSByte;
			break;
		case NumericType.Int16:
			message = System.SR.FormatInt16;
			break;
		case NumericType.Int32:
			message = System.SR.FormatInt32;
			break;
		case NumericType.Int64:
			message = System.SR.FormatInt64;
			break;
		case NumericType.Int128:
			message = System.SR.FormatInt128;
			break;
		case NumericType.UInt16:
			message = System.SR.FormatUInt16;
			break;
		case NumericType.UInt32:
			message = System.SR.FormatUInt32;
			break;
		case NumericType.UInt64:
			message = System.SR.FormatUInt64;
			break;
		case NumericType.UInt128:
			message = System.SR.FormatUInt128;
			break;
		case NumericType.Half:
			message = System.SR.FormatHalf;
			break;
		case NumericType.Single:
			message = System.SR.FormatSingle;
			break;
		case NumericType.Double:
			message = System.SR.FormatDouble;
			break;
		case NumericType.Decimal:
			message = System.SR.FormatDecimal;
			break;
		}
		throw new FormatException(message)
		{
			Source = "System.Text.Json.Rethrowable"
		};
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowFormatException(DataType dataType)
	{
		string message = "";
		switch (dataType)
		{
		case DataType.Boolean:
		case DataType.DateOnly:
		case DataType.DateTime:
		case DataType.DateTimeOffset:
		case DataType.TimeOnly:
		case DataType.TimeSpan:
		case DataType.Guid:
		case DataType.Version:
			message = System.SR.Format(System.SR.UnsupportedFormat, dataType);
			break;
		case DataType.Base64String:
			message = System.SR.CannotDecodeInvalidBase64;
			break;
		}
		throw new FormatException(message)
		{
			Source = "System.Text.Json.Rethrowable"
		};
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowInvalidOperationException_ExpectedChar(JsonTokenType tokenType)
	{
		throw GetInvalidOperationException("char", tokenType);
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowObjectDisposedException_Utf8JsonWriter()
	{
		throw new ObjectDisposedException("Utf8JsonWriter");
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowObjectDisposedException_JsonDocument()
	{
		throw new ObjectDisposedException("JsonDocument");
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowInsufficientExecutionStackException_JsonElementDeepEqualsInsufficientExecutionStack()
	{
		throw new InsufficientExecutionStackException(System.SR.JsonElementDeepEqualsInsufficientExecutionStack);
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowArgumentException_NodeValueNotAllowed(string paramName)
	{
		throw new ArgumentException(System.SR.NodeValueNotAllowed, paramName);
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowArgumentException_DuplicateKey(string paramName, object propertyName)
	{
		throw new ArgumentException(System.SR.Format(System.SR.NodeDuplicateKey, propertyName), paramName);
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowKeyNotFoundException()
	{
		throw new KeyNotFoundException();
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowInvalidOperationException_NodeAlreadyHasParent()
	{
		throw new InvalidOperationException(System.SR.NodeAlreadyHasParent);
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowInvalidOperationException_NodeCycleDetected()
	{
		throw new InvalidOperationException(System.SR.NodeCycleDetected);
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowInvalidOperationException_NodeElementCannotBeObjectOrArray()
	{
		throw new InvalidOperationException(System.SR.NodeElementCannotBeObjectOrArray);
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowNotSupportedException_CollectionIsReadOnly()
	{
		throw GetNotSupportedException_CollectionIsReadOnly();
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowInvalidOperationException_NodeWrongType(params ReadOnlySpan<string> supportedTypeNames)
	{
		string p = ((supportedTypeNames.Length == 1) ? supportedTypeNames[0] : string.Join(", ", supportedTypeNames.ToArray()));
		throw new InvalidOperationException(System.SR.Format(System.SR.NodeWrongType, p));
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowInvalidOperationException_NodeParentWrongType(string typeName)
	{
		throw new InvalidOperationException(System.SR.Format(System.SR.NodeParentWrongType, typeName));
	}

	public static NotSupportedException GetNotSupportedException_CollectionIsReadOnly()
	{
		return new NotSupportedException(System.SR.CollectionIsReadOnly);
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowInvalidOperationException_NodeUnableToConvert(Type sourceType, Type destinationType)
	{
		throw new InvalidOperationException(System.SR.Format(System.SR.NodeUnableToConvert, sourceType, destinationType));
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowInvalidOperationException_NodeUnableToConvertElement(JsonValueKind valueKind, Type destinationType)
	{
		throw new InvalidOperationException(System.SR.Format(System.SR.NodeUnableToConvertElement, valueKind, destinationType));
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowArgumentException_DeserializeWrongType(Type type, object value)
	{
		throw new ArgumentException(System.SR.Format(System.SR.DeserializeWrongType, type, value.GetType()));
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowArgumentException_SerializerDoesNotSupportComments(string paramName)
	{
		throw new ArgumentException(System.SR.JsonSerializerDoesNotSupportComments, paramName);
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowNotSupportedException_SerializationNotSupported(Type propertyType)
	{
		throw new NotSupportedException(System.SR.Format(System.SR.SerializationNotSupportedType, propertyType));
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowNotSupportedException_TypeRequiresAsyncSerialization(Type propertyType)
	{
		throw new NotSupportedException(System.SR.Format(System.SR.TypeRequiresAsyncSerialization, propertyType));
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowNotSupportedException_DictionaryKeyTypeNotSupported(Type keyType, JsonConverter converter)
	{
		throw new NotSupportedException(System.SR.Format(System.SR.DictionaryKeyTypeNotSupported, keyType, converter.GetType()));
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowJsonException_DeserializeUnableToConvertValue(Type propertyType)
	{
		throw new JsonException(System.SR.Format(System.SR.DeserializeUnableToConvertValue, propertyType))
		{
			AppendPathInformation = true
		};
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowInvalidCastException_DeserializeUnableToAssignValue(Type typeOfValue, Type declaredType)
	{
		throw new InvalidCastException(System.SR.Format(System.SR.DeserializeUnableToAssignValue, typeOfValue, declaredType));
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowInvalidOperationException_DeserializeUnableToAssignNull(Type declaredType)
	{
		throw new InvalidOperationException(System.SR.Format(System.SR.DeserializeUnableToAssignNull, declaredType));
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowJsonException_PropertyGetterDisallowNull(string propertyName, Type declaringType)
	{
		throw new JsonException(System.SR.Format(System.SR.PropertyGetterDisallowNull, propertyName, declaringType))
		{
			AppendPathInformation = true
		};
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowJsonException_PropertySetterDisallowNull(string propertyName, Type declaringType)
	{
		throw new JsonException(System.SR.Format(System.SR.PropertySetterDisallowNull, propertyName, declaringType))
		{
			AppendPathInformation = true
		};
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowJsonException_ConstructorParameterDisallowNull(string parameterName, Type declaringType)
	{
		throw new JsonException(System.SR.Format(System.SR.ConstructorParameterDisallowNull, parameterName, declaringType))
		{
			AppendPathInformation = true
		};
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowInvalidOperationException_ObjectCreationHandlingPopulateNotSupportedByConverter(JsonPropertyInfo propertyInfo)
	{
		throw new InvalidOperationException(System.SR.Format(System.SR.ObjectCreationHandlingPopulateNotSupportedByConverter, propertyInfo.Name, propertyInfo.DeclaringType));
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowInvalidOperationException_ObjectCreationHandlingPropertyMustHaveAGetter(JsonPropertyInfo propertyInfo)
	{
		throw new InvalidOperationException(System.SR.Format(System.SR.ObjectCreationHandlingPropertyMustHaveAGetter, propertyInfo.Name, propertyInfo.DeclaringType));
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowInvalidOperationException_ObjectCreationHandlingPropertyValueTypeMustHaveASetter(JsonPropertyInfo propertyInfo)
	{
		throw new InvalidOperationException(System.SR.Format(System.SR.ObjectCreationHandlingPropertyValueTypeMustHaveASetter, propertyInfo.Name, propertyInfo.DeclaringType));
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowInvalidOperationException_ObjectCreationHandlingPropertyCannotAllowPolymorphicDeserialization(JsonPropertyInfo propertyInfo)
	{
		throw new InvalidOperationException(System.SR.Format(System.SR.ObjectCreationHandlingPropertyCannotAllowPolymorphicDeserialization, propertyInfo.Name, propertyInfo.DeclaringType));
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowInvalidOperationException_ObjectCreationHandlingPropertyCannotAllowReadOnlyMember(JsonPropertyInfo propertyInfo)
	{
		throw new InvalidOperationException(System.SR.Format(System.SR.ObjectCreationHandlingPropertyCannotAllowReadOnlyMember, propertyInfo.Name, propertyInfo.DeclaringType));
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowInvalidOperationException_ObjectCreationHandlingPropertyCannotAllowReferenceHandling()
	{
		throw new InvalidOperationException(System.SR.ObjectCreationHandlingPropertyCannotAllowReferenceHandling);
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowNotSupportedException_ObjectCreationHandlingPropertyDoesNotSupportParameterizedConstructors()
	{
		throw new NotSupportedException(System.SR.ObjectCreationHandlingPropertyDoesNotSupportParameterizedConstructors);
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowJsonException_SerializationConverterRead(JsonConverter converter)
	{
		throw new JsonException(System.SR.Format(System.SR.SerializationConverterRead, converter))
		{
			AppendPathInformation = true
		};
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowJsonException_SerializationConverterWrite(JsonConverter converter)
	{
		throw new JsonException(System.SR.Format(System.SR.SerializationConverterWrite, converter))
		{
			AppendPathInformation = true
		};
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowJsonException_SerializerCycleDetected(int maxDepth)
	{
		throw new JsonException(System.SR.Format(System.SR.SerializerCycleDetected, maxDepth))
		{
			AppendPathInformation = true
		};
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowJsonException(string message = null)
	{
		throw new JsonException(message)
		{
			AppendPathInformation = true
		};
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowArgumentException_CannotSerializeInvalidType(string paramName, Type typeToConvert, Type declaringType, string propertyName)
	{
		if (declaringType == null)
		{
			throw new ArgumentException(System.SR.Format(System.SR.CannotSerializeInvalidType, typeToConvert), paramName);
		}
		throw new ArgumentException(System.SR.Format(System.SR.CannotSerializeInvalidMember, typeToConvert, propertyName, declaringType), paramName);
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowInvalidOperationException_CannotSerializeInvalidType(Type typeToConvert, Type declaringType, MemberInfo memberInfo)
	{
		if (declaringType == null)
		{
			throw new InvalidOperationException(System.SR.Format(System.SR.CannotSerializeInvalidType, typeToConvert));
		}
		throw new InvalidOperationException(System.SR.Format(System.SR.CannotSerializeInvalidMember, typeToConvert, memberInfo.Name, declaringType));
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowInvalidOperationException_SerializationConverterNotCompatible(Type converterType, Type type)
	{
		throw new InvalidOperationException(System.SR.Format(System.SR.SerializationConverterNotCompatible, converterType, type));
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowInvalidOperationException_ResolverTypeNotCompatible(Type requestedType, Type actualType)
	{
		throw new InvalidOperationException(System.SR.Format(System.SR.ResolverTypeNotCompatible, actualType, requestedType));
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowInvalidOperationException_ResolverTypeInfoOptionsNotCompatible()
	{
		throw new InvalidOperationException(System.SR.ResolverTypeInfoOptionsNotCompatible);
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowInvalidOperationException_JsonSerializerOptionsNoTypeInfoResolverSpecified()
	{
		throw new InvalidOperationException(System.SR.JsonSerializerOptionsNoTypeInfoResolverSpecified);
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowInvalidOperationException_JsonSerializerIsReflectionDisabled()
	{
		throw new InvalidOperationException(System.SR.JsonSerializerIsReflectionDisabled);
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowInvalidOperationException_SerializationConverterOnAttributeInvalid(Type classType, MemberInfo memberInfo)
	{
		string text = classType.ToString();
		if (memberInfo != null)
		{
			text = text + "." + memberInfo.Name;
		}
		throw new InvalidOperationException(System.SR.Format(System.SR.SerializationConverterOnAttributeInvalid, text));
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowInvalidOperationException_SerializationConverterOnAttributeNotCompatible(Type classTypeAttributeIsOn, MemberInfo memberInfo, Type typeToConvert)
	{
		string text = classTypeAttributeIsOn.ToString();
		if (memberInfo != null)
		{
			text = text + "." + memberInfo.Name;
		}
		throw new InvalidOperationException(System.SR.Format(System.SR.SerializationConverterOnAttributeNotCompatible, text, typeToConvert));
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowInvalidOperationException_SerializerOptionsReadOnly(JsonSerializerContext context)
	{
		throw new InvalidOperationException((context == null) ? System.SR.SerializerOptionsReadOnly : System.SR.SerializerContextOptionsReadOnly);
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowInvalidOperationException_DefaultTypeInfoResolverImmutable()
	{
		throw new InvalidOperationException(System.SR.DefaultTypeInfoResolverImmutable);
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowInvalidOperationException_TypeInfoResolverChainImmutable()
	{
		throw new InvalidOperationException(System.SR.TypeInfoResolverChainImmutable);
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowInvalidOperationException_TypeInfoImmutable()
	{
		throw new InvalidOperationException(System.SR.TypeInfoImmutable);
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowInvalidOperationException_InvalidChainedResolver()
	{
		throw new InvalidOperationException(System.SR.SerializerOptions_InvalidChainedResolver);
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowInvalidOperationException_SerializerPropertyNameConflict(Type type, string propertyName)
	{
		throw new InvalidOperationException(System.SR.Format(System.SR.SerializerPropertyNameConflict, type, propertyName));
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowInvalidOperationException_SerializerPropertyNameNull(JsonPropertyInfo jsonPropertyInfo)
	{
		throw new InvalidOperationException(System.SR.Format(System.SR.SerializerPropertyNameNull, jsonPropertyInfo.DeclaringType, jsonPropertyInfo.MemberName));
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowInvalidOperationException_JsonPropertyRequiredAndNotDeserializable(JsonPropertyInfo jsonPropertyInfo)
	{
		throw new InvalidOperationException(System.SR.Format(System.SR.JsonPropertyRequiredAndNotDeserializable, jsonPropertyInfo.Name, jsonPropertyInfo.DeclaringType));
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowInvalidOperationException_JsonPropertyRequiredAndExtensionData(JsonPropertyInfo jsonPropertyInfo)
	{
		throw new InvalidOperationException(System.SR.Format(System.SR.JsonPropertyRequiredAndExtensionData, jsonPropertyInfo.Name, jsonPropertyInfo.DeclaringType));
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowJsonException_JsonRequiredPropertyMissing(JsonTypeInfo parent, BitArray requiredPropertiesSet)
	{
		StringBuilder stringBuilder = new StringBuilder();
		bool flag = true;
		ReadOnlySpan<JsonPropertyInfo> propertyCache = parent.PropertyCache;
		for (int i = 0; i < propertyCache.Length; i++)
		{
			JsonPropertyInfo jsonPropertyInfo = propertyCache[i];
			if (jsonPropertyInfo.IsRequired && !requiredPropertiesSet[jsonPropertyInfo.RequiredPropertyIndex])
			{
				if (!flag)
				{
					stringBuilder.Append(CultureInfo.CurrentUICulture.TextInfo.ListSeparator);
					stringBuilder.Append(' ');
				}
				stringBuilder.Append('\'');
				stringBuilder.Append(jsonPropertyInfo.Name);
				stringBuilder.Append('\'');
				flag = false;
				if (stringBuilder.Length >= 60)
				{
					break;
				}
			}
		}
		throw new JsonException(System.SR.Format(System.SR.JsonRequiredPropertiesMissing, parent.Type, stringBuilder.ToString()));
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowInvalidOperationException_NamingPolicyReturnNull(JsonNamingPolicy namingPolicy)
	{
		throw new InvalidOperationException(System.SR.Format(System.SR.NamingPolicyReturnNull, namingPolicy));
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowInvalidOperationException_SerializerConverterFactoryReturnsNull(Type converterType)
	{
		throw new InvalidOperationException(System.SR.Format(System.SR.SerializerConverterFactoryReturnsNull, converterType));
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowInvalidOperationException_SerializerConverterFactoryReturnsJsonConverterFactorty(Type converterType)
	{
		throw new InvalidOperationException(System.SR.Format(System.SR.SerializerConverterFactoryReturnsJsonConverterFactory, converterType));
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowInvalidOperationException_MultiplePropertiesBindToConstructorParameters(Type parentType, string parameterName, string firstMatchName, string secondMatchName)
	{
		throw new InvalidOperationException(System.SR.Format(System.SR.MultipleMembersBindWithConstructorParameter, firstMatchName, secondMatchName, parentType, parameterName));
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowInvalidOperationException_ConstructorParameterIncompleteBinding(Type parentType)
	{
		throw new InvalidOperationException(System.SR.Format(System.SR.ConstructorParamIncompleteBinding, parentType));
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowInvalidOperationException_ExtensionDataCannotBindToCtorParam(string propertyName, JsonPropertyInfo jsonPropertyInfo)
	{
		throw new InvalidOperationException(System.SR.Format(System.SR.ExtensionDataCannotBindToCtorParam, propertyName, jsonPropertyInfo.DeclaringType));
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowInvalidOperationException_JsonIncludeOnInaccessibleProperty(string memberName, Type declaringType)
	{
		throw new InvalidOperationException(System.SR.Format(System.SR.JsonIncludeOnInaccessibleProperty, memberName, declaringType));
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowInvalidOperationException_IgnoreConditionOnValueTypeInvalid(string clrPropertyName, Type propertyDeclaringType)
	{
		throw new InvalidOperationException(System.SR.Format(System.SR.IgnoreConditionOnValueTypeInvalid, clrPropertyName, propertyDeclaringType));
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowInvalidOperationException_NumberHandlingOnPropertyInvalid(JsonPropertyInfo jsonPropertyInfo)
	{
		throw new InvalidOperationException(System.SR.Format(System.SR.NumberHandlingOnPropertyInvalid, jsonPropertyInfo.MemberName, jsonPropertyInfo.DeclaringType));
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowInvalidOperationException_ConverterCanConvertMultipleTypes(Type runtimePropertyType, JsonConverter jsonConverter)
	{
		throw new InvalidOperationException(System.SR.Format(System.SR.ConverterCanConvertMultipleTypes, jsonConverter.GetType(), jsonConverter.Type, runtimePropertyType));
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowNotSupportedException_ObjectWithParameterizedCtorRefMetadataNotSupported(ReadOnlySpan<byte> propertyName, ref Utf8JsonReader reader, scoped ref ReadStack state)
	{
		JsonTypeInfo topJsonTypeInfoWithParameterizedConstructor = state.GetTopJsonTypeInfoWithParameterizedConstructor();
		state.Current.JsonPropertyName = propertyName.ToArray();
		NotSupportedException innerException = new NotSupportedException(System.SR.Format(System.SR.ObjectWithParameterizedCtorRefMetadataNotSupported, topJsonTypeInfoWithParameterizedConstructor.Type));
		ThrowNotSupportedException(ref state, in reader, innerException);
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowInvalidOperationException_JsonTypeInfoOperationNotPossibleForKind(JsonTypeInfoKind kind)
	{
		throw new InvalidOperationException(System.SR.Format(System.SR.InvalidJsonTypeInfoOperationForKind, kind));
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowInvalidOperationException_JsonTypeInfoOnDeserializingCallbacksNotSupported(Type type)
	{
		throw new InvalidOperationException(System.SR.Format(System.SR.OnDeserializingCallbacksNotSupported, type));
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowInvalidOperationException_CreateObjectConverterNotCompatible(Type type)
	{
		throw new InvalidOperationException(System.SR.Format(System.SR.CreateObjectConverterNotCompatible, type));
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ReThrowWithPath(scoped ref ReadStack state, JsonReaderException ex)
	{
		string text = state.JsonPath();
		string message = ex.Message;
		int num = message.LastIndexOf(" LineNumber: ", StringComparison.Ordinal);
		message = ((num < 0) ? (message + " Path: " + text + ".") : (message.Substring(0, num) + " Path: " + text + " |" + message.Substring(num)));
		throw new JsonException(message, text, ex.LineNumber, ex.BytePositionInLine, ex);
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ReThrowWithPath(scoped ref ReadStack state, in Utf8JsonReader reader, Exception ex)
	{
		JsonException ex2 = new JsonException(null, ex);
		AddJsonExceptionInformation(ref state, in reader, ex2);
		throw ex2;
	}

	public static void AddJsonExceptionInformation(scoped ref ReadStack state, in Utf8JsonReader reader, JsonException ex)
	{
		long lineNumber = reader.CurrentState._lineNumber;
		ex.LineNumber = lineNumber;
		long bytePositionInLine = reader.CurrentState._bytePositionInLine;
		ex.BytePositionInLine = bytePositionInLine;
		string arg = (ex.Path = state.JsonPath());
		string text2 = ex._message;
		if (string.IsNullOrEmpty(text2))
		{
			Type p = state.Current.JsonPropertyInfo?.PropertyType ?? state.Current.JsonTypeInfo.Type;
			text2 = System.SR.Format(System.SR.DeserializeUnableToConvertValue, p);
			ex.AppendPathInformation = true;
		}
		if (ex.AppendPathInformation)
		{
			text2 += $" Path: {arg} | LineNumber: {lineNumber} | BytePositionInLine: {bytePositionInLine}.";
			ex.SetMessage(text2);
		}
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ReThrowWithPath(ref WriteStack state, Exception ex)
	{
		JsonException ex2 = new JsonException(null, ex);
		AddJsonExceptionInformation(ref state, ex2);
		throw ex2;
	}

	public static void AddJsonExceptionInformation(ref WriteStack state, JsonException ex)
	{
		string text = (ex.Path = state.PropertyPath());
		string text3 = ex._message;
		if (string.IsNullOrEmpty(text3))
		{
			text3 = System.SR.Format(System.SR.SerializeUnableToSerialize);
			ex.AppendPathInformation = true;
		}
		if (ex.AppendPathInformation)
		{
			text3 = text3 + " Path: " + text + ".";
			ex.SetMessage(text3);
		}
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowInvalidOperationException_SerializationDuplicateAttribute(Type attribute, MemberInfo memberInfo)
	{
		string p = ((memberInfo is Type type) ? type.ToString() : $"{memberInfo.DeclaringType}.{memberInfo.Name}");
		throw new InvalidOperationException(System.SR.Format(System.SR.SerializationDuplicateAttribute, attribute, p));
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowInvalidOperationException_SerializationDuplicateTypeAttribute(Type classType, Type attribute)
	{
		throw new InvalidOperationException(System.SR.Format(System.SR.SerializationDuplicateTypeAttribute, classType, attribute));
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowInvalidOperationException_SerializationDuplicateTypeAttribute<TAttribute>(Type classType)
	{
		throw new InvalidOperationException(System.SR.Format(System.SR.SerializationDuplicateTypeAttribute, classType, typeof(TAttribute)));
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowInvalidOperationException_ExtensionDataConflictsWithUnmappedMemberHandling(Type classType, JsonPropertyInfo jsonPropertyInfo)
	{
		throw new InvalidOperationException(System.SR.Format(System.SR.ExtensionDataConflictsWithUnmappedMemberHandling, classType, jsonPropertyInfo.MemberName));
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowInvalidOperationException_SerializationDataExtensionPropertyInvalid(JsonPropertyInfo jsonPropertyInfo)
	{
		throw new InvalidOperationException(System.SR.Format(System.SR.SerializationDataExtensionPropertyInvalid, jsonPropertyInfo.PropertyType, jsonPropertyInfo.MemberName));
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowInvalidOperationException_PropertyTypeNotNullable(JsonPropertyInfo jsonPropertyInfo)
	{
		throw new InvalidOperationException(System.SR.Format(System.SR.PropertyTypeNotNullable, jsonPropertyInfo.PropertyType));
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowInvalidOperationException_NodeJsonObjectCustomConverterNotAllowedOnExtensionProperty()
	{
		throw new InvalidOperationException(System.SR.NodeJsonObjectCustomConverterNotAllowedOnExtensionProperty);
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowNotSupportedException(scoped ref ReadStack state, in Utf8JsonReader reader, Exception innerException)
	{
		string text = innerException.Message;
		Type type = state.Current.JsonPropertyInfo?.PropertyType ?? state.Current.JsonTypeInfo.Type;
		if (!text.Contains(type.ToString()))
		{
			if (text.Length > 0)
			{
				text += " ";
			}
			text += System.SR.Format(System.SR.SerializationNotSupportedParentType, type);
		}
		long lineNumber = reader.CurrentState._lineNumber;
		long bytePositionInLine = reader.CurrentState._bytePositionInLine;
		text += $" Path: {state.JsonPath()} | LineNumber: {lineNumber} | BytePositionInLine: {bytePositionInLine}.";
		throw new NotSupportedException(text, innerException);
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowNotSupportedException(ref WriteStack state, Exception innerException)
	{
		string text = innerException.Message;
		Type type = state.Current.JsonPropertyInfo?.PropertyType ?? state.Current.JsonTypeInfo.Type;
		if (!text.Contains(type.ToString()))
		{
			if (text.Length > 0)
			{
				text += " ";
			}
			text += System.SR.Format(System.SR.SerializationNotSupportedParentType, type);
		}
		text = text + " Path: " + state.PropertyPath() + ".";
		throw new NotSupportedException(text, innerException);
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowNotSupportedException_DeserializeNoConstructor(JsonTypeInfo typeInfo, ref Utf8JsonReader reader, scoped ref ReadStack state)
	{
		Type type = typeInfo.Type;
		string message;
		if (type.IsInterface || type.IsAbstract)
		{
			if (typeInfo.PolymorphicTypeResolver?.UsesTypeDiscriminators ?? false)
			{
				message = System.SR.Format(System.SR.DeserializationMustSpecifyTypeDiscriminator, type);
			}
			else
			{
				JsonTypeInfoKind kind = typeInfo.Kind;
				bool flag = (uint)(kind - 2) <= 1u;
				message = ((!flag) ? System.SR.Format(System.SR.DeserializeInterfaceOrAbstractType, type) : System.SR.Format(System.SR.CannotPopulateCollection, type));
			}
		}
		else
		{
			message = System.SR.Format(System.SR.DeserializeNoConstructor, "JsonConstructorAttribute", type);
		}
		ThrowNotSupportedException(ref state, in reader, new NotSupportedException(message));
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowNotSupportedException_CannotPopulateCollection(Type type, ref Utf8JsonReader reader, scoped ref ReadStack state)
	{
		ThrowNotSupportedException(ref state, in reader, new NotSupportedException(System.SR.Format(System.SR.CannotPopulateCollection, type)));
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowJsonException_MetadataValuesInvalidToken(JsonTokenType tokenType)
	{
		ThrowJsonException(System.SR.Format(System.SR.MetadataInvalidTokenAfterValues, tokenType));
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowJsonException_MetadataReferenceNotFound(string id)
	{
		ThrowJsonException(System.SR.Format(System.SR.MetadataReferenceNotFound, id));
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowJsonException_MetadataValueWasNotString(JsonTokenType tokenType)
	{
		ThrowJsonException(System.SR.Format(System.SR.MetadataValueWasNotString, tokenType));
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowJsonException_MetadataValueWasNotString(JsonValueKind valueKind)
	{
		ThrowJsonException(System.SR.Format(System.SR.MetadataValueWasNotString, valueKind));
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowJsonException_MetadataReferenceObjectCannotContainOtherProperties(ReadOnlySpan<byte> propertyName, scoped ref ReadStack state)
	{
		state.Current.JsonPropertyName = propertyName.ToArray();
		ThrowJsonException_MetadataReferenceObjectCannotContainOtherProperties();
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowJsonException_MetadataUnexpectedProperty(ReadOnlySpan<byte> propertyName, scoped ref ReadStack state)
	{
		state.Current.JsonPropertyName = propertyName.ToArray();
		ThrowJsonException(System.SR.Format(System.SR.MetadataUnexpectedProperty));
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowJsonException_UnmappedJsonProperty(Type type, string unmappedPropertyName)
	{
		throw new JsonException(System.SR.Format(System.SR.UnmappedJsonProperty, unmappedPropertyName, type));
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowJsonException_MetadataReferenceObjectCannotContainOtherProperties()
	{
		ThrowJsonException(System.SR.MetadataReferenceCannotContainOtherProperties);
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowJsonException_MetadataIdCannotBeCombinedWithRef(ReadOnlySpan<byte> propertyName, scoped ref ReadStack state)
	{
		state.Current.JsonPropertyName = propertyName.ToArray();
		ThrowJsonException(System.SR.MetadataIdCannotBeCombinedWithRef);
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowJsonException_MetadataStandaloneValuesProperty(scoped ref ReadStack state, ReadOnlySpan<byte> propertyName)
	{
		state.Current.JsonPropertyName = propertyName.ToArray();
		ThrowJsonException(System.SR.MetadataStandaloneValuesProperty);
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowJsonException_MetadataInvalidPropertyWithLeadingDollarSign(ReadOnlySpan<byte> propertyName, scoped ref ReadStack state, in Utf8JsonReader reader)
	{
		if (state.Current.IsProcessingDictionary())
		{
			state.Current.JsonPropertyNameAsString = reader.GetString();
		}
		else
		{
			state.Current.JsonPropertyName = propertyName.ToArray();
		}
		ThrowJsonException(System.SR.MetadataInvalidPropertyWithLeadingDollarSign);
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowJsonException_MetadataDuplicateIdFound(string id)
	{
		ThrowJsonException(System.SR.Format(System.SR.MetadataDuplicateIdFound, id));
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowJsonException_DuplicateMetadataProperty(ReadOnlySpan<byte> utf8PropertyName)
	{
		ThrowJsonException(System.SR.Format(System.SR.DuplicateMetadataProperty, JsonHelpers.Utf8GetString(utf8PropertyName)));
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowJsonException_MetadataInvalidReferenceToValueType(Type propertyType)
	{
		ThrowJsonException(System.SR.Format(System.SR.MetadataInvalidReferenceToValueType, propertyType));
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowJsonException_MetadataInvalidPropertyInArrayMetadata(scoped ref ReadStack state, Type propertyType, in Utf8JsonReader reader)
	{
		state.Current.JsonPropertyName = (reader.HasValueSequence ? reader.ValueSequence.ToArray<byte>() : reader.ValueSpan.ToArray());
		string p = reader.GetString();
		ThrowJsonException(System.SR.Format(System.SR.MetadataPreservedArrayFailed, System.SR.Format(System.SR.MetadataInvalidPropertyInArrayMetadata, p), System.SR.Format(System.SR.DeserializeUnableToConvertValue, propertyType)));
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowJsonException_MetadataPreservedArrayValuesNotFound(scoped ref ReadStack state, Type propertyType)
	{
		state.Current.JsonPropertyName = null;
		ThrowJsonException(System.SR.Format(System.SR.MetadataPreservedArrayFailed, System.SR.MetadataStandaloneValuesProperty, System.SR.Format(System.SR.DeserializeUnableToConvertValue, propertyType)));
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowJsonException_MetadataCannotParsePreservedObjectIntoImmutable(Type propertyType)
	{
		ThrowJsonException(System.SR.Format(System.SR.MetadataCannotParsePreservedObjectToImmutable, propertyType));
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowInvalidOperationException_MetadataReferenceOfTypeCannotBeAssignedToType(string referenceId, Type currentType, Type typeToConvert)
	{
		throw new InvalidOperationException(System.SR.Format(System.SR.MetadataReferenceOfTypeCannotBeAssignedToType, referenceId, currentType, typeToConvert));
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowInvalidOperationException_JsonPropertyInfoIsBoundToDifferentJsonTypeInfo(JsonPropertyInfo propertyInfo)
	{
		throw new InvalidOperationException(System.SR.Format(System.SR.JsonPropertyInfoBoundToDifferentParent, propertyInfo.Name, propertyInfo.DeclaringTypeInfo.Type.FullName));
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	internal static void ThrowUnexpectedMetadataException(ReadOnlySpan<byte> propertyName, ref Utf8JsonReader reader, scoped ref ReadStack state)
	{
		if (JsonSerializer.GetMetadataPropertyName(propertyName, state.Current.BaseJsonTypeInfo.PolymorphicTypeResolver) != MetadataPropertyName.None)
		{
			ThrowJsonException_MetadataUnexpectedProperty(propertyName, ref state);
		}
		else
		{
			ThrowJsonException_MetadataInvalidPropertyWithLeadingDollarSign(propertyName, ref state, in reader);
		}
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowNotSupportedException_NoMetadataForType(Type type, IJsonTypeInfoResolver resolver)
	{
		throw new NotSupportedException(System.SR.Format(System.SR.NoMetadataForType, type, resolver?.ToString() ?? "<null>"));
	}

	public static NotSupportedException GetNotSupportedException_AmbiguousMetadataForType(Type type, Type match1, Type match2)
	{
		return new NotSupportedException(System.SR.Format(System.SR.AmbiguousMetadataForType, type, match1, match2));
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowNotSupportedException_ConstructorContainsNullParameterNames(Type declaringType)
	{
		throw new NotSupportedException(System.SR.Format(System.SR.ConstructorContainsNullParameterNames, declaringType));
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowInvalidOperationException_NoMetadataForType(Type type, IJsonTypeInfoResolver resolver)
	{
		throw new InvalidOperationException(System.SR.Format(System.SR.NoMetadataForType, type, resolver?.ToString() ?? "<null>"));
	}

	public static Exception GetInvalidOperationException_NoMetadataForTypeProperties(IJsonTypeInfoResolver resolver, Type type)
	{
		return new InvalidOperationException(System.SR.Format(System.SR.NoMetadataForTypeProperties, resolver?.ToString() ?? "<null>", type));
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowInvalidOperationException_NoMetadataForTypeProperties(IJsonTypeInfoResolver resolver, Type type)
	{
		throw GetInvalidOperationException_NoMetadataForTypeProperties(resolver, type);
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowMissingMemberException_MissingFSharpCoreMember(string missingFsharpCoreMember)
	{
		throw new MissingMemberException(System.SR.Format(System.SR.MissingFSharpCoreMember, missingFsharpCoreMember));
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowNotSupportedException_BaseConverterDoesNotSupportMetadata(Type derivedType)
	{
		throw new NotSupportedException(System.SR.Format(System.SR.Polymorphism_DerivedConverterDoesNotSupportMetadata, derivedType));
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowNotSupportedException_DerivedConverterDoesNotSupportMetadata(Type derivedType)
	{
		throw new NotSupportedException(System.SR.Format(System.SR.Polymorphism_DerivedConverterDoesNotSupportMetadata, derivedType));
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowNotSupportedException_RuntimeTypeNotSupported(Type baseType, Type runtimeType)
	{
		throw new NotSupportedException(System.SR.Format(System.SR.Polymorphism_RuntimeTypeNotSupported, runtimeType, baseType));
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowNotSupportedException_RuntimeTypeDiamondAmbiguity(Type baseType, Type runtimeType, Type derivedType1, Type derivedType2)
	{
		throw new NotSupportedException(System.SR.Format(System.SR.Polymorphism_RuntimeTypeDiamondAmbiguity, runtimeType, derivedType1, derivedType2, baseType));
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowInvalidOperationException_TypeDoesNotSupportPolymorphism(Type baseType)
	{
		throw new InvalidOperationException(System.SR.Format(System.SR.Polymorphism_TypeDoesNotSupportPolymorphism, baseType));
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowInvalidOperationException_DerivedTypeNotSupported(Type baseType, Type derivedType)
	{
		throw new InvalidOperationException(System.SR.Format(System.SR.Polymorphism_DerivedTypeIsNotSupported, derivedType, baseType));
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowInvalidOperationException_DerivedTypeIsAlreadySpecified(Type baseType, Type derivedType)
	{
		throw new InvalidOperationException(System.SR.Format(System.SR.Polymorphism_DerivedTypeIsAlreadySpecified, baseType, derivedType));
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowInvalidOperationException_TypeDicriminatorIdIsAlreadySpecified(Type baseType, object typeDiscriminator)
	{
		throw new InvalidOperationException(System.SR.Format(System.SR.Polymorphism_TypeDicriminatorIdIsAlreadySpecified, baseType, typeDiscriminator));
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowInvalidOperationException_InvalidCustomTypeDiscriminatorPropertyName()
	{
		throw new InvalidOperationException(System.SR.Polymorphism_InvalidCustomTypeDiscriminatorPropertyName);
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowInvalidOperationException_PolymorphicTypeConfigurationDoesNotSpecifyDerivedTypes(Type baseType)
	{
		throw new InvalidOperationException(System.SR.Format(System.SR.Polymorphism_ConfigurationDoesNotSpecifyDerivedTypes, baseType));
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowInvalidOperationException_UnsupportedEnumIdentifier(Type enumType, string enumName)
	{
		throw new InvalidOperationException(System.SR.Format(System.SR.UnsupportedEnumIdentifier, enumType.Name, enumName));
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowJsonException_UnrecognizedTypeDiscriminator(object typeDiscriminator)
	{
		ThrowJsonException(System.SR.Format(System.SR.Polymorphism_UnrecognizedTypeDiscriminator, typeDiscriminator));
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowArgumentException_JsonPolymorphismOptionsAssociatedWithDifferentJsonTypeInfo(string parameterName)
	{
		throw new ArgumentException(System.SR.JsonPolymorphismOptionsAssociatedWithDifferentJsonTypeInfo, parameterName);
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowOperationCanceledException_PipeWriteCanceled()
	{
		throw new OperationCanceledException(System.SR.PipeWriterCanceled);
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowInvalidOperationException_PipeWriterDoesNotImplementUnflushedBytes(PipeWriter pipeWriter)
	{
		throw new InvalidOperationException(System.SR.Format(System.SR.PipeWriter_DoesNotImplementUnflushedBytes, pipeWriter.GetType().Name));
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowNotSupportedException_JsonSchemaExporterDoesNotSupportReferenceHandlerPreserve()
	{
		throw new NotSupportedException(System.SR.JsonSchemaExporter_ReferenceHandlerPreserve_NotSupported);
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	public static void ThrowInvalidOperationException_JsonSchemaExporterDepthTooLarge()
	{
		throw new InvalidOperationException(System.SR.JsonSchemaExporter_DepthTooLarge);
	}
}
