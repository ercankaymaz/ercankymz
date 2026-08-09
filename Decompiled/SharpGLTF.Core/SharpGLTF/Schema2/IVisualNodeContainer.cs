using System.Collections.Generic;

namespace SharpGLTF.Schema2;

public interface IVisualNodeContainer
{
	IEnumerable<Node> VisualChildren { get; }

	Node CreateNode(string name = null);
}
