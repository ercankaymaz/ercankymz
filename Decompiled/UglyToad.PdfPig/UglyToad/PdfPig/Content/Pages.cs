using System;
using System.Collections.Generic;
using System.Reflection;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Filters;
using UglyToad.PdfPig.Outline.Destinations;
using UglyToad.PdfPig.Parser;
using UglyToad.PdfPig.Tokenization.Scanner;
using UglyToad.PdfPig.Tokens;
using UglyToad.PdfPig.Util;

namespace UglyToad.PdfPig.Content;

internal sealed class Pages : IDisposable
{
	private readonly Dictionary<Type, object> pageFactoryCache;

	private readonly PageFactory defaultPageFactory;

	private readonly IPdfTokenScanner pdfScanner;

	private readonly Dictionary<int, PageTreeNode> pagesByNumber;

	public int Count => pagesByNumber.Count;

	public PageTreeNode PageTree { get; }

	internal Pages(IPageFactory<Page> pageFactory, IPdfTokenScanner pdfScanner, PageTreeNode pageTree, Dictionary<int, PageTreeNode> pagesByNumber)
	{
		pageFactoryCache = new Dictionary<Type, object>();
		defaultPageFactory = ((PageFactory)pageFactory) ?? throw new ArgumentNullException("pageFactory");
		this.pdfScanner = pdfScanner ?? throw new ArgumentNullException("pdfScanner");
		this.pagesByNumber = pagesByNumber;
		PageTree = pageTree;
		AddPageFactory(defaultPageFactory);
	}

	internal Page GetPage(int pageNumber, NamedDestinations namedDestinations, ParsingOptions parsingOptions)
	{
		return GetPage(defaultPageFactory, pageNumber, namedDestinations, parsingOptions);
	}

	internal TPage GetPage<TPage>(int pageNumber, NamedDestinations namedDestinations, ParsingOptions parsingOptions)
	{
		if (pageFactoryCache.TryGetValue(typeof(TPage), out object value) && value is IPageFactory<TPage> pageFactory)
		{
			return GetPage(pageFactory, pageNumber, namedDestinations, parsingOptions);
		}
		throw new InvalidOperationException($"Could not find page factory of type '{typeof(IPageFactory<TPage>)}' for page type {typeof(TPage)}.");
	}

	private TPage GetPage<TPage>(IPageFactory<TPage> pageFactory, int pageNumber, NamedDestinations namedDestinations, ParsingOptions parsingOptions)
	{
		if (pageNumber <= 0 || pageNumber > Count)
		{
			parsingOptions.Logger.Error($"Page {pageNumber} requested but is out of range.");
			throw new ArgumentOutOfRangeException("pageNumber", $"Page number {pageNumber} invalid, must be between 1 and {Count}.");
		}
		PageTreeNode pageNode = GetPageNode(pageNumber);
		Stack<PageTreeNode> stack = new Stack<PageTreeNode>();
		for (PageTreeNode pageTreeNode = pageNode; pageTreeNode != null; pageTreeNode = pageTreeNode.Parent)
		{
			stack.Push(pageTreeNode);
		}
		PageTreeMembers pageTreeMembers = new PageTreeMembers();
		while (stack.Count > 0)
		{
			PageTreeNode pageTreeNode = stack.Pop();
			if (pageTreeNode.NodeDictionary.TryGet<DictionaryToken>(NameToken.Resources, pdfScanner, out DictionaryToken token))
			{
				pageTreeMembers.ParentResources.Enqueue(token);
			}
			if (pageTreeNode.NodeDictionary.TryGet<ArrayToken>(NameToken.MediaBox, pdfScanner, out ArrayToken token2))
			{
				pageTreeMembers.MediaBox = new MediaBox(token2.ToRectangle(pdfScanner));
			}
			if (pageTreeNode.NodeDictionary.TryGet<NumericToken>(NameToken.Rotate, pdfScanner, out NumericToken token3))
			{
				pageTreeMembers.Rotation = token3.Int;
			}
		}
		return pageFactory.Create(pageNumber, pageNode.NodeDictionary, pageTreeMembers, namedDestinations);
	}

	internal void AddPageFactory<TPage>(IPageFactory<TPage> pageFactory)
	{
		Type typeFromHandle = typeof(TPage);
		if (pageFactoryCache.ContainsKey(typeFromHandle))
		{
			throw new InvalidOperationException($"Could not add page factory for page type '{typeFromHandle}' as it was already added.");
		}
		pageFactoryCache.Add(typeFromHandle, pageFactory);
	}

	internal void AddPageFactory<TPage, TPageFactory>() where TPageFactory : IPageFactory<TPage>
	{
		ConstructorInfo constructor = typeof(TPageFactory).GetConstructor(new Type[5]
		{
			typeof(IPdfTokenScanner),
			typeof(IResourceStore),
			typeof(ILookupFilterProvider),
			typeof(IPageContentParser),
			typeof(ParsingOptions)
		});
		if ((object)constructor == null)
		{
			throw new InvalidOperationException($"Could not find valid constructor for page factory of type '{typeof(TPageFactory)}'. " + "The page factory should have a constructor with the following parameters: " + $"{typeof(IPdfTokenScanner)}, {typeof(IResourceStore)}, {typeof(ILookupFilterProvider)}, {typeof(IPageContentParser)}, {typeof(ParsingOptions)}.");
		}
		if (!(constructor.Invoke(new object[5] { defaultPageFactory.PdfScanner, defaultPageFactory.ResourceStore, defaultPageFactory.FilterProvider, defaultPageFactory.PageContentParser, defaultPageFactory.ParsingOptions }) is IPageFactory<TPage> pageFactory))
		{
			throw new InvalidOperationException($"Something wrong happened while creating page factory of type '{typeof(TPageFactory)}' for page type '{typeof(TPage)}'.");
		}
		AddPageFactory(pageFactory);
	}

	internal PageTreeNode GetPageNode(int pageNumber)
	{
		if (!pagesByNumber.TryGetValue(pageNumber, out PageTreeNode value))
		{
			throw new InvalidOperationException($"Could not find page node by number for: {pageNumber}.");
		}
		return value;
	}

	internal PageTreeNode? GetPageByReference(IndirectReference reference)
	{
		foreach (KeyValuePair<int, PageTreeNode> item in pagesByNumber)
		{
			if (item.Value.Reference.Equals(reference))
			{
				return item.Value;
			}
		}
		return null;
	}

	public void Dispose()
	{
		foreach (object value in pageFactoryCache.Values)
		{
			if (value is IDisposable disposable)
			{
				disposable.Dispose();
			}
		}
		pageFactoryCache.Clear();
	}
}
