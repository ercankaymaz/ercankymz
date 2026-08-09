using System;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public interface IEncodeable : ICloneable
{
	ExpandedNodeId TypeId { get; }

	ExpandedNodeId BinaryEncodingId { get; }

	ExpandedNodeId XmlEncodingId { get; }

	void Encode(IEncoder encoder);

	void Decode(IDecoder decoder);

	bool IsEqual(IEncodeable encodeable);
}
