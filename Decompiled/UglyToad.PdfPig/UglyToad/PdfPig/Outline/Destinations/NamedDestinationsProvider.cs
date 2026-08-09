using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UglyToad.PdfPig.Content;
using UglyToad.PdfPig.Logging;
using UglyToad.PdfPig.Parser.Parts;
using UglyToad.PdfPig.Tokenization.Scanner;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Outline.Destinations;

internal static class NamedDestinationsProvider
{
	internal static NamedDestinations Read(DictionaryToken catalogDictionary, IPdfTokenScanner pdfScanner, Pages pages, ILog? log)
	{
		Dictionary<string, ExplicitDestination> dictionary = new Dictionary<string, ExplicitDestination>();
		DictionaryToken token2;
		if (catalogDictionary.TryGet<DictionaryToken>(NameToken.Dests, pdfScanner, out DictionaryToken token))
		{
			foreach (KeyValuePair<string, IToken> datum in token.Data)
			{
				if (TryReadExplicitDestination(datum.Value, pdfScanner, pages, log, isRemoteDestination: false, out ExplicitDestination destination))
				{
					dictionary[datum.Key] = destination;
				}
			}
		}
		else if (catalogDictionary.TryGet<DictionaryToken>(NameToken.Names, pdfScanner, out token2) && token2.TryGet<DictionaryToken>(NameToken.Dests, pdfScanner, out token))
		{
			NameTreeParser.FlattenNameTree(token, pdfScanner, (IToken value) => TryReadExplicitDestination(value, pdfScanner, pages, log, isRemoteDestination: false, out ExplicitDestination destination2) ? destination2 : null, dictionary);
		}
		return new NamedDestinations(dictionary, pages);
	}

	private static bool TryReadExplicitDestination(IToken value, IPdfTokenScanner pdfScanner, Pages pages, ILog? log, bool isRemoteDestination, [NotNullWhen(true)] out ExplicitDestination? destination)
	{
		destination = null;
		if (DirectObjectFinder.TryGet<ArrayToken>(value, pdfScanner, out ArrayToken tokenResult) && TryGetExplicitDestination(tokenResult, pages, log, isRemoteDestination, out destination))
		{
			return true;
		}
		if (DirectObjectFinder.TryGet<DictionaryToken>(value, pdfScanner, out DictionaryToken tokenResult2) && tokenResult2.TryGet<ArrayToken>(NameToken.D, pdfScanner, out tokenResult) && TryGetExplicitDestination(tokenResult, pages, log, isRemoteDestination, out destination))
		{
			return true;
		}
		return false;
	}

	internal static bool TryGetExplicitDestination(ArrayToken explicitDestinationArray, Pages pages, ILog? log, bool isRemoteDestination, [NotNullWhen(true)] out ExplicitDestination? destination)
	{
		destination = null;
		if (explicitDestinationArray == null || explicitDestinationArray.Length == 0)
		{
			return false;
		}
		IToken token = explicitDestinationArray[0];
		int pageNumber;
		if (token is IndirectReferenceToken indirectReferenceToken)
		{
			if (isRemoteDestination)
			{
				string message = "TryGetExplicitDestination Cannot use indirect reference for remote destination.";
				log?.Error(message);
				return false;
			}
			PageTreeNode pageByReference = pages.GetPageByReference(indirectReferenceToken.Data);
			if (!(pageByReference?.PageNumber).HasValue)
			{
				return false;
			}
			pageNumber = pageByReference.PageNumber.Value;
		}
		else if (token is NumericToken numericToken)
		{
			pageNumber = numericToken.Int + 1;
		}
		else
		{
			string message2 = string.Format("{0} No page number given in 'Dest': '{1}', defaulting to 0.", "TryGetExplicitDestination", explicitDestinationArray);
			log?.Error(message2);
			pageNumber = 0;
		}
		NameToken nameToken = null;
		if (explicitDestinationArray.Length > 1)
		{
			nameToken = explicitDestinationArray[1] as NameToken;
		}
		if ((object)nameToken == null)
		{
			string message3 = $"Missing name token as second argument to explicit destination: {explicitDestinationArray}.";
			log?.Error(message3);
			destination = new ExplicitDestination(pageNumber, ExplicitDestinationType.FitPage, ExplicitDestinationCoordinates.Empty);
			return true;
		}
		if (nameToken.Equals(NameToken.XYZ))
		{
			double? left = GetPossibleEntry(2);
			double? top = GetPossibleEntry(3);
			destination = new ExplicitDestination(pageNumber, ExplicitDestinationType.XyzCoordinates, new ExplicitDestinationCoordinates(left, top));
			return true;
		}
		if (nameToken.Equals(NameToken.Fit))
		{
			destination = new ExplicitDestination(pageNumber, ExplicitDestinationType.FitPage, ExplicitDestinationCoordinates.Empty);
			return true;
		}
		if (nameToken.Equals(NameToken.FitH))
		{
			double? top2 = GetPossibleEntry(2);
			destination = new ExplicitDestination(pageNumber, ExplicitDestinationType.FitHorizontally, new ExplicitDestinationCoordinates(null, top2));
			return true;
		}
		if (nameToken.Equals(NameToken.FitV))
		{
			double? left2 = GetPossibleEntry(2);
			destination = new ExplicitDestination(pageNumber, ExplicitDestinationType.FitVertically, new ExplicitDestinationCoordinates(left2));
			return true;
		}
		if (nameToken.Equals(NameToken.FitR))
		{
			double? left3 = GetPossibleEntry(2);
			double? bottom = GetPossibleEntry(3);
			double? right = GetPossibleEntry(4);
			double? top3 = GetPossibleEntry(5);
			destination = new ExplicitDestination(pageNumber, ExplicitDestinationType.FitRectangle, new ExplicitDestinationCoordinates(left3, top3, right, bottom));
			return true;
		}
		if (nameToken.Equals(NameToken.FitB))
		{
			destination = new ExplicitDestination(pageNumber, ExplicitDestinationType.FitBoundingBox, ExplicitDestinationCoordinates.Empty);
			return true;
		}
		if (nameToken.Equals(NameToken.FitBH))
		{
			double? top4 = GetPossibleEntry(2);
			destination = new ExplicitDestination(pageNumber, ExplicitDestinationType.FitBoundingBoxHorizontally, new ExplicitDestinationCoordinates(null, top4));
			return true;
		}
		if (nameToken.Equals(NameToken.FitBV))
		{
			double? left4 = GetPossibleEntry(2);
			destination = new ExplicitDestination(pageNumber, ExplicitDestinationType.FitBoundingBoxVertically, new ExplicitDestinationCoordinates(left4));
			return true;
		}
		return false;
		double? GetPossibleEntry(int index)
		{
			if (index >= explicitDestinationArray.Length)
			{
				return null;
			}
			if (explicitDestinationArray[index] is NumericToken numericToken2)
			{
				return numericToken2.Data;
			}
			return null;
		}
	}
}
