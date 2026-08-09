using System;
using System.Collections.Generic;
using UglyToad.PdfPig.Outline.Destinations;

namespace UglyToad.PdfPig.Outline;

public class EmbeddedBookmarkNode : DocumentBookmarkNode
{
	public string FileSpecification { get; }

	public EmbeddedBookmarkNode(string title, int level, ExplicitDestination destination, IReadOnlyList<BookmarkNode> children, string fileSpecification)
		: base(title, level, destination, children)
	{
		FileSpecification = fileSpecification ?? throw new ArgumentNullException("fileSpecification");
	}

	public override string ToString()
	{
		return $"Embedded file '{FileSpecification}', {base.Level}, {base.Title}";
	}
}
