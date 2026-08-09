using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public interface IReferenceType : ILocalNode, INode
{
	bool IsAbstract { get; set; }

	bool Symmetric { get; set; }

	LocalizedText InverseName { get; set; }
}
