using System;
using System.Collections.Generic;
using System.Linq;
using UglyToad.PdfPig.Core;

namespace UglyToad.PdfPig.DocumentLayoutAnalysis.PageSegmenter;

internal class XYNode
{
	public virtual bool IsLeaf => false;

	public PdfRectangle BoundingBox { get; set; }

	public XYNode[] Children { get; set; }

	public XYNode(params XYNode[] children)
		: this(children?.ToList())
	{
	}

	public XYNode(IEnumerable<XYNode> children)
	{
		if (children != null && children.Any())
		{
			Children = children.ToArray();
			BoundingBox = new PdfRectangle(children.Min((XYNode b) => b.BoundingBox.Left), children.Min((XYNode b) => b.BoundingBox.Bottom), children.Max((XYNode b) => b.BoundingBox.Right), children.Max((XYNode b) => b.BoundingBox.Top));
		}
		else
		{
			Children = Array.Empty<XYNode>();
		}
	}

	public virtual int CountWords()
	{
		if (Children == null)
		{
			return 0;
		}
		int count = 0;
		RecursiveCount(Children, ref count);
		return count;
	}

	public virtual List<XYLeaf> GetLeaves()
	{
		List<XYLeaf> leaves = new List<XYLeaf>();
		if (Children == null || Children.Length == 0)
		{
			return leaves;
		}
		int level = 0;
		RecursiveGetLeaves(Children, ref leaves, level);
		return leaves;
	}

	private void RecursiveCount(IEnumerable<XYNode> children, ref int count)
	{
		if (!children.Any())
		{
			return;
		}
		foreach (XYNode item in children.Where((XYNode x) => x.IsLeaf))
		{
			count += item.CountWords();
		}
		foreach (XYNode item2 in children.Where((XYNode x) => !x.IsLeaf))
		{
			RecursiveCount(item2.Children, ref count);
		}
	}

	private void RecursiveGetLeaves(IEnumerable<XYNode> children, ref List<XYLeaf> leaves, int level)
	{
		if (!children.Any())
		{
			return;
		}
		bool flag = level % 2 == 0;
		foreach (XYLeaf item in children.Where((XYNode x) => x.IsLeaf))
		{
			leaves.Add(item);
		}
		level++;
		IEnumerable<XYNode> source = children.Where((XYNode x) => !x.IsLeaf);
		source = ((!flag) ? source.OrderByDescending((XYNode x) => x.BoundingBox.Top).ToList() : source.OrderBy((XYNode x) => x.BoundingBox.Left).ToList());
		foreach (XYNode item2 in source)
		{
			RecursiveGetLeaves(item2.Children, ref leaves, level);
		}
	}

	public override string ToString()
	{
		if (!IsLeaf)
		{
			return "Node";
		}
		return "Leaf";
	}
}
