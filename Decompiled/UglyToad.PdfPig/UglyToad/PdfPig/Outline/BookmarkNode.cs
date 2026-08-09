using System;
using System.Collections.Generic;

namespace UglyToad.PdfPig.Outline;

public abstract class BookmarkNode
{
	public string Title { get; }

	public IReadOnlyList<BookmarkNode> Children { get; }

	public bool IsLeaf { get; }

	public int Level { get; }

	protected BookmarkNode(string title, int level, IReadOnlyList<BookmarkNode> children)
	{
		Title = title;
		Level = level;
		Children = children ?? throw new ArgumentNullException("children");
		IsLeaf = children.Count == 0;
	}
}
