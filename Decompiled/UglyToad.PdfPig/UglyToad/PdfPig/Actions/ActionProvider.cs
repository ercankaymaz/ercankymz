using System.Diagnostics.CodeAnalysis;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Logging;
using UglyToad.PdfPig.Outline.Destinations;
using UglyToad.PdfPig.Tokenization.Scanner;
using UglyToad.PdfPig.Tokens;
using UglyToad.PdfPig.Util;

namespace UglyToad.PdfPig.Actions;

internal static class ActionProvider
{
	internal static bool TryGetAction(DictionaryToken dictionary, NamedDestinations namedDestinations, IPdfTokenScanner pdfScanner, ILog log, [NotNullWhen(true)] out PdfAction? result)
	{
		result = null;
		if (!dictionary.TryGet<DictionaryToken>(NameToken.A, pdfScanner, out DictionaryToken token))
		{
			return false;
		}
		if (!token.TryGet<NameToken>(NameToken.S, pdfScanner, out NameToken token2))
		{
			throw new PdfDocumentFormatException($"No action type (/S) specified for action: {token}.");
		}
		if (token2.Equals(NameToken.GoTo))
		{
			if (DestinationProvider.TryGetDestination(token, NameToken.D, namedDestinations, pdfScanner, log, isRemoteDestination: false, out ExplicitDestination destination))
			{
				result = new GoToAction(destination);
				return true;
			}
		}
		else if (token2.Equals(NameToken.GoToR))
		{
			if (token.TryGetOptionalStringDirect(NameToken.F, pdfScanner, out string result2) && DestinationProvider.TryGetDestination(token, NameToken.D, namedDestinations, pdfScanner, log, isRemoteDestination: true, out ExplicitDestination destination2))
			{
				result = new GoToRAction(destination2, result2);
				return true;
			}
		}
		else if (token2.Equals(NameToken.GoToE))
		{
			if (DestinationProvider.TryGetDestination(token, NameToken.D, namedDestinations, pdfScanner, log, isRemoteDestination: true, out ExplicitDestination destination3))
			{
				if (!token.TryGetOptionalStringDirect(NameToken.F, pdfScanner, out string result3))
				{
					result3 = null;
				}
				result = new GoToEAction(destination3, result3);
				return true;
			}
		}
		else if (token2.Equals(NameToken.Uri))
		{
			if (!token.TryGetOptionalStringDirect(NameToken.Uri, pdfScanner, out string result4))
			{
				result4 = null;
			}
			result = new UriAction(result4);
			return true;
		}
		return false;
	}
}
