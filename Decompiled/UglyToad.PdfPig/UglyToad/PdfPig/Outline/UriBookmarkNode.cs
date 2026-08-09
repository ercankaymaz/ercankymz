using System;
using System.Collections.Generic;

namespace UglyToad.PdfPig.Outline;

public class UriBookmarkNode : BookmarkNode
{
	public string Uri { get; }

	public UriBookmarkNode(string title, int level, string uri, IReadOnlyList<BookmarkNode> children)
		: base(title, level, children)
	{
		Uri = uri ?? throw new ArgumentNullException("uri");
	}

	public override string ToString()
	{
		return $"URI '{Uri}', {base.Level}, {base.Title}";
	}
}
