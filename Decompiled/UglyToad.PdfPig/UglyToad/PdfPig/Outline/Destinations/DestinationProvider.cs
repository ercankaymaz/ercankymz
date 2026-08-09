using System.Diagnostics.CodeAnalysis;
using UglyToad.PdfPig.Logging;
using UglyToad.PdfPig.Tokenization.Scanner;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Outline.Destinations;

internal static class DestinationProvider
{
	internal static bool TryGetDestination(DictionaryToken dictionary, NameToken destinationToken, NamedDestinations namedDestinations, IPdfTokenScanner pdfScanner, ILog log, bool isRemoteDestination, [NotNullWhen(true)] out ExplicitDestination? destination)
	{
		if (dictionary.TryGet<ArrayToken>(destinationToken, pdfScanner, out ArrayToken token))
		{
			return namedDestinations.TryGetExplicitDestination(token, log, isRemoteDestination, out destination);
		}
		if (dictionary.TryGet<IDataToken<string>>(destinationToken, pdfScanner, out IDataToken<string> token2))
		{
			return namedDestinations.TryGet(token2.Data, out destination);
		}
		destination = null;
		return false;
	}
}
