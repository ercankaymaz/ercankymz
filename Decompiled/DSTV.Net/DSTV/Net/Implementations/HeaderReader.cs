using System;
using System.IO;
using System.Threading.Tasks;
using DSTV.Net.Data;
using DSTV.Net.Enums;
using DSTV.Net.Exceptions;
using DSTV.Net.Extensions;

namespace DSTV.Net.Implementations;

internal sealed class HeaderReader
{
	private const char Space = ' ';

	private const char Comment = '*';

	internal static async Task<DstvHeader> ParseAsync(ReaderContext context)
	{
		TextReader reader = context.Source;
		DstvHeader result = new DstvHeader();
		await Parse2XAsync(context).ConfigureAwait(continueOnCapturedContext: false);
		DstvHeader dstvHeader = result;
		dstvHeader.OrderIdentification = await reader.ParseFreeText(context).ConfigureAwait(continueOnCapturedContext: false);
		await Parse2XAsync(context).ConfigureAwait(continueOnCapturedContext: false);
		dstvHeader = result;
		dstvHeader.DrawingIdentification = await reader.ParseFreeText(context).ConfigureAwait(continueOnCapturedContext: false);
		await Parse2XAsync(context).ConfigureAwait(continueOnCapturedContext: false);
		dstvHeader = result;
		dstvHeader.PhaseIdentification = await reader.ParseFreeText(context).ConfigureAwait(continueOnCapturedContext: false);
		await Parse2XAsync(context).ConfigureAwait(continueOnCapturedContext: false);
		dstvHeader = result;
		dstvHeader.PieceIdentification = await reader.ParseFreeText(context).ConfigureAwait(continueOnCapturedContext: false);
		await Parse2XAsync(context).ConfigureAwait(continueOnCapturedContext: false);
		dstvHeader = result;
		dstvHeader.SteelQuality = await reader.ParseFreeText(context).ConfigureAwait(continueOnCapturedContext: false);
		await Parse2XAsync(context).ConfigureAwait(continueOnCapturedContext: false);
		dstvHeader = result;
		dstvHeader.QuantityOfPieces = await reader.ParseInteger(context).ConfigureAwait(continueOnCapturedContext: false);
		await Parse2XAsync(context).ConfigureAwait(continueOnCapturedContext: false);
		dstvHeader = result;
		dstvHeader.Profile = await reader.ParseFreeText(context).ConfigureAwait(continueOnCapturedContext: false);
		await Parse2XAsync(context).ConfigureAwait(continueOnCapturedContext: false);
		dstvHeader = result;
		dstvHeader.CodeProfile = await reader.ParseEnum<CodeProfile>(context).ConfigureAwait(continueOnCapturedContext: false);
		await Parse2XAsync(context).ConfigureAwait(continueOnCapturedContext: false);
		Tuple<double, double?> tuple = await reader.ParseTupleDouble(context).ConfigureAwait(continueOnCapturedContext: false);
		result.Length = tuple.Item1;
		result.SawLength = tuple.Item2;
		await Parse2XAsync(context).ConfigureAwait(continueOnCapturedContext: false);
		dstvHeader = result;
		dstvHeader.ProfileHeight = await reader.ParseDouble(context).ConfigureAwait(continueOnCapturedContext: false);
		await Parse2XAsync(context).ConfigureAwait(continueOnCapturedContext: false);
		dstvHeader = result;
		dstvHeader.FlangeWidth = await reader.ParseDouble(context).ConfigureAwait(continueOnCapturedContext: false);
		await Parse2XAsync(context).ConfigureAwait(continueOnCapturedContext: false);
		dstvHeader = result;
		dstvHeader.FlangeThickness = await reader.ParseDouble(context).ConfigureAwait(continueOnCapturedContext: false);
		await Parse2XAsync(context).ConfigureAwait(continueOnCapturedContext: false);
		dstvHeader = result;
		dstvHeader.WebThickness = await reader.ParseDouble(context).ConfigureAwait(continueOnCapturedContext: false);
		await Parse2XAsync(context).ConfigureAwait(continueOnCapturedContext: false);
		dstvHeader = result;
		dstvHeader.Radius = await reader.ParseDouble(context).ConfigureAwait(continueOnCapturedContext: false);
		await Parse2XAsync(context).ConfigureAwait(continueOnCapturedContext: false);
		dstvHeader = result;
		dstvHeader.WeightByMeter = await reader.ParseDouble(context).ConfigureAwait(continueOnCapturedContext: false);
		await Parse2XAsync(context).ConfigureAwait(continueOnCapturedContext: false);
		dstvHeader = result;
		dstvHeader.PaintingSurfaceByMeter = await reader.ParseDouble(context).ConfigureAwait(continueOnCapturedContext: false);
		await Parse2XAsync(context).ConfigureAwait(continueOnCapturedContext: false);
		dstvHeader = result;
		dstvHeader.WebStartCut = await reader.ParseDouble(context).ConfigureAwait(continueOnCapturedContext: false);
		await Parse2XAsync(context).ConfigureAwait(continueOnCapturedContext: false);
		dstvHeader = result;
		dstvHeader.WebEndCut = await reader.ParseDouble(context).ConfigureAwait(continueOnCapturedContext: false);
		await Parse2XAsync(context).ConfigureAwait(continueOnCapturedContext: false);
		dstvHeader = result;
		dstvHeader.FlangeStartCut = await reader.ParseDouble(context).ConfigureAwait(continueOnCapturedContext: false);
		await Parse2XAsync(context).ConfigureAwait(continueOnCapturedContext: false);
		dstvHeader = result;
		dstvHeader.FlangeEndCut = await reader.ParseDouble(context).ConfigureAwait(continueOnCapturedContext: false);
		dstvHeader = result;
		dstvHeader.Text1InfoOnPiece = await reader.ParseFreeText(context).ConfigureAwait(continueOnCapturedContext: false);
		dstvHeader = result;
		dstvHeader.Text2InfoOnPiece = await reader.ParseFreeText(context).ConfigureAwait(continueOnCapturedContext: false);
		dstvHeader = result;
		dstvHeader.Text3InfoOnPiece = await reader.ParseFreeText(context).ConfigureAwait(continueOnCapturedContext: false);
		dstvHeader = result;
		dstvHeader.Text4InfoOnPiece = await reader.ParseFreeText(context).ConfigureAwait(continueOnCapturedContext: false);
		return result;
	}

	private static async Task Parse2XAsync(ReaderContext context)
	{
		char[] buffer = new char[2];
		if (await context.Source.ReadAsync(buffer, 0, 2).ConfigureAwait(continueOnCapturedContext: false) != 2)
		{
			throw new UnexpectedEndException(context);
		}
		if (buffer[0] == '*' && buffer[1] == '*')
		{
			await context.Source.ReadLineAsync().ConfigureAwait(continueOnCapturedContext: false);
			context.IncrementLineNumber();
			await Parse2XAsync(context).ConfigureAwait(continueOnCapturedContext: false);
			return;
		}
		if (buffer[0] != ' ')
		{
			throw new UnexpectedCharacterException(context, ' ', buffer[0]);
		}
		if (buffer[1] != ' ')
		{
			throw new UnexpectedCharacterException(context, ' ', buffer[1]);
		}
	}
}
