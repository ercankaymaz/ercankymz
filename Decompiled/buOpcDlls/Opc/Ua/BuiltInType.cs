using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public enum BuiltInType
{
	Null,
	Boolean,
	SByte,
	Byte,
	Int16,
	UInt16,
	Int32,
	UInt32,
	Int64,
	UInt64,
	Float,
	Double,
	String,
	DateTime,
	Guid,
	ByteString,
	XmlElement,
	NodeId,
	ExpandedNodeId,
	StatusCode,
	QualifiedName,
	LocalizedText,
	ExtensionObject,
	DataValue,
	Variant,
	DiagnosticInfo,
	Number,
	Integer,
	UInteger,
	Enumeration
}
