using System.Collections.Generic;

namespace UglyToad.PdfPig.Outline;

public class ContainerBookmarkNode : BookmarkNode
{
	public ContainerBookmarkNode(string title, int level, IReadOnlyList<BookmarkNode> children)
		: base(title, level, children)
	{
	}
}
