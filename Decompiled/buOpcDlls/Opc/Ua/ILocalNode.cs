using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public interface ILocalNode : INode
{
	object DataLock { get; }

	object Handle { get; set; }

	new NodeId NodeId { get; }

	new QualifiedName BrowseName { get; set; }

	new LocalizedText DisplayName { get; set; }

	LocalizedText Description { get; set; }

	AttributeWriteMask WriteMask { get; set; }

	AttributeWriteMask UserWriteMask { get; set; }

	NodeId ModellingRule { get; }

	IReferenceCollection References { get; }

	ILocalNode CreateCopy(NodeId nodeId);

	bool SupportsAttribute(uint attributeId);

	ServiceResult Read(IOperationContext context, uint attributeId, DataValue value);

	ServiceResult Write(uint attributeId, DataValue value);
}
