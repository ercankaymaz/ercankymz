using System.Collections.Generic;
using UglyToad.PdfPig.Outline.Destinations;

namespace UglyToad.PdfPig.Outline;

public class DocumentBookmarkNode : BookmarkNode
{
	public int PageNumber => Destination.PageNumber;

	public ExplicitDestination Destination { get; }

	public DocumentBookmarkNode(string title, int level, ExplicitDestination destination, IReadOnlyList<BookmarkNode> children)
		: base(title, level, children)
	{
		Destination = destination;
	}

	public override string ToString()
	{
		return $"page #{PageNumber}, {base.Level}, {base.Title}";
	}
}
