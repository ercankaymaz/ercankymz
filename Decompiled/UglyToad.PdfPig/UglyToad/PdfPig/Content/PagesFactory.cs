using System;
using System.Collections.Generic;
using System.Linq;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Logging;
using UglyToad.PdfPig.Parser.Parts;
using UglyToad.PdfPig.Tokenization.Scanner;
using UglyToad.PdfPig.Tokens;
using UglyToad.PdfPig.Util;

namespace UglyToad.PdfPig.Content;

internal static class PagesFactory
{
	private sealed class PageCounter
	{
		public int PageCount { get; private set; }

		public void Increment()
		{
			PageCount++;
		}
	}

	public static Pages Create(IndirectReference pagesReference, DictionaryToken pagesDictionary, IPdfTokenScanner scanner, IPageFactory<Page> pageFactory, ILog log, bool isLenientParsing)
	{
		PageCounter pageNumber = new PageCounter();
		PageTreeNode pageTreeNode = ProcessPagesNode(pagesReference, pagesDictionary, new IndirectReference(1L, 0), isRoot: true, scanner, isLenientParsing, pageNumber);
		if (!pageTreeNode.IsRoot)
		{
			throw new ArgumentException("Page tree must be the root page tree node.", "pageTree");
		}
		Dictionary<int, PageTreeNode> dictionary = new Dictionary<int, PageTreeNode>();
		PopulatePageByNumberDictionary(pageTreeNode, dictionary);
		int intOrDefault = pagesDictionary.GetIntOrDefault(NameToken.Count);
		if (intOrDefault != dictionary.Count)
		{
			log.Warn($"Dictionary Page Count {intOrDefault} different to discovered pages {dictionary.Count}. Using {dictionary.Count}.");
		}
		return new Pages(pageFactory, scanner, pageTreeNode, dictionary);
	}

	private static PageTreeNode ProcessPagesNode(IndirectReference referenceInput, DictionaryToken nodeDictionaryInput, IndirectReference parentReferenceInput, bool isRoot, IPdfTokenScanner pdfTokenScanner, bool isLenientParsing, PageCounter pageNumber)
	{
		if (CheckIfIsPage(nodeDictionaryInput, parentReferenceInput, isRoot, pdfTokenScanner, isLenientParsing))
		{
			pageNumber.Increment();
			return new PageTreeNode(nodeDictionaryInput, referenceInput, isPage: true, pageNumber.PageCount).WithChildren(Array.Empty<PageTreeNode>());
		}
		Dictionary<long, HashSet<int>> dictionary = new Dictionary<long, HashSet<int>>();
		Queue<(long, int)> queue = new Queue<(long, int)>(1000);
		Queue<(PageTreeNode, IndirectReference, DictionaryToken, IndirectReference, List<PageTreeNode>)> queue2 = new Queue<(PageTreeNode, IndirectReference, DictionaryToken, IndirectReference, List<PageTreeNode>)>();
		PageTreeNode firstPage = new PageTreeNode(nodeDictionaryInput, referenceInput, isPage: false, null);
		List<Action> list = new List<Action>();
		List<PageTreeNode> firstPageChildren = new List<PageTreeNode>();
		list.Add(delegate
		{
			firstPage.WithChildren(firstPageChildren);
		});
		queue2.Enqueue((firstPage, referenceInput, nodeDictionaryInput, parentReferenceInput, firstPageChildren));
		do
		{
			(PageTreeNode, IndirectReference, DictionaryToken, IndirectReference, List<PageTreeNode>) tuple = queue2.Dequeue();
			long objectNumber = tuple.Item2.ObjectNumber;
			int generation = tuple.Item2.Generation;
			if (dictionary.ContainsKey(objectNumber))
			{
				HashSet<int> hashSet = dictionary[objectNumber];
				if (hashSet.Contains(generation))
				{
					List<(long, int)> list2 = queue.ToList();
					Math.Abs(list2.IndexOf((objectNumber, generation)) - list2.Count);
					continue;
				}
				hashSet.Add(generation);
				dictionary[objectNumber] = hashSet;
			}
			else
			{
				dictionary.Add(objectNumber, new HashSet<int> { generation });
				queue.Enqueue((objectNumber, generation));
				if (queue.Count >= 1000)
				{
					(long, int) tuple2 = queue.Dequeue();
					long item = tuple2.Item1;
					int item2 = tuple2.Item2;
					HashSet<int> hashSet2 = dictionary[item];
					hashSet2.Remove(item2);
					if (hashSet2.Count == 0)
					{
						dictionary.Remove(item);
					}
					else
					{
						dictionary[item] = hashSet2;
					}
				}
			}
			if (!tuple.Item3.TryGet<ArrayToken>(NameToken.Kids, pdfTokenScanner, out ArrayToken token))
			{
				if (!isLenientParsing)
				{
					throw new PdfDocumentFormatException($"Pages node in the document pages tree did not define a kids array: {tuple.Item3}.");
				}
				token = new ArrayToken(Array.Empty<IToken>());
			}
			foreach (IToken datum in token.Data)
			{
				DictionaryToken tokenResult = null;
				if (!(datum is IndirectReferenceToken indirectReferenceToken))
				{
					throw new PdfDocumentFormatException($"Kids array contained invalid entry (must be indirect reference): {datum}.");
				}
				if (!DirectObjectFinder.TryGet<DictionaryToken>(indirectReferenceToken, pdfTokenScanner, out tokenResult) && !isLenientParsing)
				{
					throw new PdfDocumentFormatException($"Could not find dictionary associated with reference in pages kids array: {indirectReferenceToken}.");
				}
				if (tokenResult == null)
				{
					tokenResult = new DictionaryToken(new Dictionary<NameToken, IToken>());
				}
				if (CheckIfIsPage(tokenResult, tuple.Item2, isRoot: false, pdfTokenScanner, isLenientParsing))
				{
					PageTreeNode item3 = new PageTreeNode(tokenResult, indirectReferenceToken.Data, isPage: true, pageNumber.PageCount).WithChildren(Array.Empty<PageTreeNode>());
					tuple.Item5.Add(item3);
					continue;
				}
				PageTreeNode kidChildNode = new PageTreeNode(tokenResult, indirectReferenceToken.Data, isPage: false, null);
				List<PageTreeNode> kidChildren = new List<PageTreeNode>();
				queue2.Enqueue((kidChildNode, indirectReferenceToken.Data, tokenResult, tuple.Item2, kidChildren));
				list.Add(delegate
				{
					kidChildNode.WithChildren(kidChildren);
				});
				tuple.Item5.Add(kidChildNode);
			}
		}
		while (queue2.Count > 0);
		foreach (Action item4 in list)
		{
			item4();
		}
		foreach (PageTreeNode item5 in from child in firstPage.Children.ToRecursiveOrderList((PageTreeNode x) => x.Children)
			where child.IsPage
			select child)
		{
			pageNumber.Increment();
			item5.PageNumber = pageNumber.PageCount;
		}
		return firstPage;
	}

	private static bool CheckIfIsPage(DictionaryToken nodeDictionary, IndirectReference parentReference, bool isRoot, IPdfTokenScanner pdfTokenScanner, bool isLenientParsing)
	{
		bool flag = false;
		if (!nodeDictionary.TryGet<NameToken>(NameToken.Type, pdfTokenScanner, out NameToken token))
		{
			if (!isLenientParsing)
			{
				throw new PdfDocumentFormatException($"Node in the document pages tree did not define a type: {nodeDictionary}.");
			}
			if (!nodeDictionary.TryGet<ArrayToken>(NameToken.Kids, pdfTokenScanner, out ArrayToken _))
			{
				flag = true;
			}
		}
		else
		{
			flag = token.Equals(NameToken.Page);
			if (!flag && !token.Equals(NameToken.Pages) && !isLenientParsing)
			{
				throw new PdfDocumentFormatException($"Node in the document pages tree defined invalid type: {nodeDictionary}.");
			}
		}
		if (!isLenientParsing && !isRoot)
		{
			if (!nodeDictionary.TryGet<IndirectReferenceToken>(NameToken.Parent, pdfTokenScanner, out IndirectReferenceToken token3))
			{
				throw new PdfDocumentFormatException($"Could not find parent indirect reference token on pages tree node: {nodeDictionary}.");
			}
			if (!token3.Data.Equals(parentReference))
			{
				throw new PdfDocumentFormatException($"Pages tree node parent reference {token3.Data} did not match actual parent {parentReference}.");
			}
		}
		return flag;
	}

	private static void PopulatePageByNumberDictionary(PageTreeNode node, Dictionary<int, PageTreeNode> result)
	{
		if (node.IsPage)
		{
			if (!node.PageNumber.HasValue)
			{
				throw new InvalidOperationException($"Node was page but did not have page number: {node}.");
			}
			result[node.PageNumber.Value] = node;
			return;
		}
		foreach (PageTreeNode child in node.Children)
		{
			PopulatePageByNumberDictionary(child, result);
		}
	}
}
