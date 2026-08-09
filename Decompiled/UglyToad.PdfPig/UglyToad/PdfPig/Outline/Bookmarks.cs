using System.Collections.Generic;

namespace UglyToad.PdfPig.Outline;

public class Bookmarks
{
	public IReadOnlyList<BookmarkNode> Roots { get; }

	public Bookmarks(IReadOnlyList<BookmarkNode> roots)
	{
		Roots = roots;
	}

	public IEnumerable<BookmarkNode> GetNodes()
	{
		foreach (BookmarkNode root in Roots)
		{
			foreach (BookmarkNode node in GetNodes(root))
			{
				yield return node;
			}
		}
	}

	private static IEnumerable<BookmarkNode> GetNodes(BookmarkNode node)
	{
		yield return node;
		foreach (BookmarkNode child in node.Children)
		{
			foreach (BookmarkNode node2 in GetNodes(child))
			{
				yield return node2;
			}
		}
	}
}
