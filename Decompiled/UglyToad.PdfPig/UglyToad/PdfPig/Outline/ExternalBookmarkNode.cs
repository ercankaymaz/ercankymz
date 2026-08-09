using System;
using System.Collections.Generic;
using UglyToad.PdfPig.Outline.Destinations;

namespace UglyToad.PdfPig.Outline;

public class ExternalBookmarkNode : DocumentBookmarkNode
{
	public string FileName { get; }

	public ExternalBookmarkNode(string title, int level, ExplicitDestination destination, IReadOnlyList<BookmarkNode> children, string fileName)
		: base(title, level, destination, children)
	{
		FileName = fileName ?? throw new ArgumentNullException("fileName");
	}

	public override string ToString()
	{
		return $"file '{FileName}', {base.Level}, {base.Title}";
	}
}
