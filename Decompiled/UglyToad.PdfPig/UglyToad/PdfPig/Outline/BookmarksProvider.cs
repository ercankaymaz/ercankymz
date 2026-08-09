using System.Collections.Generic;
using UglyToad.PdfPig.Actions;
using UglyToad.PdfPig.Content;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Logging;
using UglyToad.PdfPig.Outline.Destinations;
using UglyToad.PdfPig.Parser.Parts;
using UglyToad.PdfPig.Tokenization.Scanner;
using UglyToad.PdfPig.Tokens;
using UglyToad.PdfPig.Util;

namespace UglyToad.PdfPig.Outline;

internal class BookmarksProvider
{
	private readonly ILog log;

	private readonly IPdfTokenScanner pdfScanner;

	public BookmarksProvider(ILog log, IPdfTokenScanner pdfScanner)
	{
		this.log = log;
		this.pdfScanner = pdfScanner;
	}

	public Bookmarks? GetBookmarks(Catalog catalog, bool allowContainerNode = false)
	{
		if (!catalog.CatalogDictionary.TryGet<DictionaryToken>(NameToken.Outlines, pdfScanner, out DictionaryToken token))
		{
			return null;
		}
		if (token.TryGet<NameToken>(NameToken.Type, pdfScanner, out NameToken token2) && token2 != NameToken.Outlines)
		{
			log?.Error($"Outlines (bookmarks) dictionary did not have correct type specified: {token2}.");
		}
		if (!token.TryGet<DictionaryToken>(NameToken.First, pdfScanner, out DictionaryToken token3))
		{
			return null;
		}
		List<BookmarkNode> list = new List<BookmarkNode>();
		HashSet<IndirectReference> hashSet = new HashSet<IndirectReference>();
		while (token3 != null)
		{
			ReadBookmarksRecursively(token3, 0, readSiblings: false, hashSet, catalog.NamedDestinations, list, allowContainerNode);
			if (!token3.TryGet(NameToken.Next, out IndirectReferenceToken token4) || !hashSet.Add(token4.Data))
			{
				break;
			}
			token3 = DirectObjectFinder.Get<DictionaryToken>(token4, pdfScanner);
		}
		return new Bookmarks(list);
	}

	private void ReadBookmarksRecursively(DictionaryToken nodeDictionary, int level, bool readSiblings, HashSet<IndirectReference> seen, NamedDestinations namedDestinations, List<BookmarkNode> list, bool allowContainerNode = false)
	{
		if (!nodeDictionary.TryGetOptionalStringDirect(NameToken.Title, pdfScanner, out string result))
		{
			throw new PdfDocumentFormatException($"Invalid title for outline (bookmark) node: {nodeDictionary}.");
		}
		List<BookmarkNode> list2 = new List<BookmarkNode>();
		if (nodeDictionary.TryGet<DictionaryToken>(NameToken.First, pdfScanner, out DictionaryToken token))
		{
			ReadBookmarksRecursively(token, level + 1, readSiblings: true, seen, namedDestinations, list2, allowContainerNode);
		}
		BookmarkNode item;
		PdfAction result2;
		if (DestinationProvider.TryGetDestination(nodeDictionary, NameToken.Dest, namedDestinations, pdfScanner, log, isRemoteDestination: false, out ExplicitDestination destination))
		{
			item = new DocumentBookmarkNode(result, level, destination, list2);
		}
		else if (ActionProvider.TryGetAction(nodeDictionary, namedDestinations, pdfScanner, log, out result2))
		{
			if (result2 is GoToRAction goToRAction)
			{
				item = new ExternalBookmarkNode(result, level, goToRAction.Destination, list2, goToRAction.Filename);
			}
			else if (result2 is GoToAction goToAction)
			{
				item = new DocumentBookmarkNode(result, level, goToAction.Destination, list2);
			}
			else
			{
				if (!(result2 is UriAction uriAction))
				{
					return;
				}
				item = new UriBookmarkNode(result, level, uriAction.Uri, list2);
			}
		}
		else
		{
			if (!allowContainerNode)
			{
				log.Error($"No /Dest(ination) or /A(ction) entry found for bookmark node: {nodeDictionary}.");
				return;
			}
			item = new ContainerBookmarkNode(result, level, list2);
			log.Warn($"No /Dest(ination) or /A(ction) entry found for bookmark node: {nodeDictionary}.");
		}
		list.Add(item);
		if (!readSiblings)
		{
			return;
		}
		DictionaryToken dictionaryToken = nodeDictionary;
		IndirectReferenceToken token2;
		while (dictionaryToken.TryGet(NameToken.Next, out token2) && seen.Add(token2.Data))
		{
			dictionaryToken = DirectObjectFinder.Get<DictionaryToken>(token2, pdfScanner);
			if (dictionaryToken != null)
			{
				ReadBookmarksRecursively(dictionaryToken, level, readSiblings: false, seen, namedDestinations, list, allowContainerNode);
				continue;
			}
			break;
		}
	}
}
