using System;
using System.Collections.Generic;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Content;

public class PageTreeNode
{
	public DictionaryToken NodeDictionary { get; }

	public IndirectReference Reference { get; }

	public bool IsPage { get; }

	public int? PageNumber { get; internal set; }

	public IReadOnlyList<PageTreeNode>? Children { get; private set; }

	public PageTreeNode? Parent { get; private set; }

	public bool IsRoot => Parent == null;

	internal PageTreeNode(DictionaryToken nodeDictionary, IndirectReference reference, bool isPage, int? pageNumber)
	{
		NodeDictionary = nodeDictionary ?? throw new ArgumentNullException("nodeDictionary");
		Reference = reference;
		IsPage = isPage;
		PageNumber = pageNumber;
		if (!IsPage && PageNumber.HasValue)
		{
			throw new ArgumentException("Cannot define page number for a pages node.", "pageNumber");
		}
	}

	internal PageTreeNode WithChildren(IReadOnlyList<PageTreeNode> children)
	{
		Children = children ?? throw new ArgumentNullException("children");
		if (IsPage && Children.Count > 0)
		{
			throw new ArgumentException("Cannot define children on a page node.", "children");
		}
		foreach (PageTreeNode child in Children)
		{
			child.Parent = this;
		}
		return this;
	}

	public override string ToString()
	{
		if (IsPage)
		{
			return $"Page #{PageNumber}: {NodeDictionary}.";
		}
		return $"Pages ({Children?.Count ?? 0} children): {NodeDictionary}";
	}
}
