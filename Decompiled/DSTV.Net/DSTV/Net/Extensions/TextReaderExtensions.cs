using System;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using DSTV.Net.Exceptions;
using DSTV.Net.Implementations;

namespace DSTV.Net.Extensions;

internal static class TextReaderExtensions
{
	internal static async Task<string> ParseFreeText(this TextReader reader, ReaderContext context)
	{
		object obj = (await reader.ReadLineAsync().ConfigureAwait(continueOnCapturedContext: false))?.Trim();
		object obj2 = obj;
		if (obj2 != null && ((string)obj2).Length > 80)
		{
			throw new FreeTextTooLargeException(context);
		}
		context.IncrementLineNumber();
		if (obj == null)
		{
			obj = string.Empty;
		}
		return (string)obj;
	}

	internal static async Task<double> ParseDouble(this TextReader reader, ReaderContext context)
	{
		if (!double.TryParse(await reader.ReadLineAsync().ConfigureAwait(continueOnCapturedContext: false), NumberStyles.Float, CultureInfo.InvariantCulture, out var result))
		{
			throw new DoubleParseException(context);
		}
		context.IncrementLineNumber();
		return result;
	}

	internal static async Task<Tuple<double, double?>> ParseTupleDouble(this TextReader reader, ReaderContext context)
	{
		string[] array = (await reader.ReadLineAsync().ConfigureAwait(continueOnCapturedContext: false))?.Split(new char[1] { ',' });
		if (array == null || array.Length < 1 || array.Length > 2)
		{
			throw new TupleParseException<double>(context, "1 to 2");
		}
		if (!double.TryParse(array[0], NumberStyles.Float, CultureInfo.InvariantCulture, out var result))
		{
			throw new DoubleParseException(context);
		}
		context.IncrementLineNumber();
		if (array.Length == 2 && double.TryParse(array[1], NumberStyles.Float, CultureInfo.InvariantCulture, out var result2))
		{
			return new Tuple<double, double?>(result, result2);
		}
		return new Tuple<double, double?>(result, null);
	}

	internal static async Task<int> ParseInteger(this TextReader reader, ReaderContext context)
	{
		if (!int.TryParse(await reader.ReadLineAsync().ConfigureAwait(continueOnCapturedContext: false), NumberStyles.Integer, CultureInfo.InvariantCulture, out var result))
		{
			throw new IntegerParseException(context);
		}
		context.IncrementLineNumber();
		return result;
	}

	internal static async Task<TEnum> ParseEnum<TEnum>(this TextReader reader, ReaderContext context) where TEnum : struct, Enum
	{
		if (!Enum.TryParse<TEnum>(await reader.ReadLineAsync().ConfigureAwait(continueOnCapturedContext: false), out var result))
		{
			throw new EnumParseException<TEnum>(context);
		}
		context.IncrementLineNumber();
		return result;
	}
}
