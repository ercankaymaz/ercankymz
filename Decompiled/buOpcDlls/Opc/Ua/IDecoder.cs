using System;
using System.Runtime.InteropServices;
using System.Xml;

namespace Opc.Ua;

[ComVisible(true)]
public interface IDecoder : IDisposable
{
	EncodingType EncodingType { get; }

	IServiceMessageContext Context { get; }

	void Close();

	void SetMappingTables(NamespaceTable namespaceUris, StringTable serverUris);

	void PushNamespace(string namespaceUri);

	void PopNamespace();

	bool ReadBoolean(string fieldName);

	sbyte ReadSByte(string fieldName);

	byte ReadByte(string fieldName);

	short ReadInt16(string fieldName);

	ushort ReadUInt16(string fieldName);

	int ReadInt32(string fieldName);

	uint ReadUInt32(string fieldName);

	long ReadInt64(string fieldName);

	ulong ReadUInt64(string fieldName);

	float ReadFloat(string fieldName);

	double ReadDouble(string fieldName);

	string ReadString(string fieldName);

	DateTime ReadDateTime(string fieldName);

	Uuid ReadGuid(string fieldName);

	byte[] ReadByteString(string fieldName);

	XmlElement ReadXmlElement(string fieldName);

	NodeId ReadNodeId(string fieldName);

	ExpandedNodeId ReadExpandedNodeId(string fieldName);

	StatusCode ReadStatusCode(string fieldName);

	DiagnosticInfo ReadDiagnosticInfo(string fieldName);

	QualifiedName ReadQualifiedName(string fieldName);

	LocalizedText ReadLocalizedText(string fieldName);

	Variant ReadVariant(string fieldName);

	DataValue ReadDataValue(string fieldName);

	ExtensionObject ReadExtensionObject(string fieldName);

	IEncodeable ReadEncodeable(string fieldName, Type systemType, ExpandedNodeId encodeableTypeId = null);

	Enum ReadEnumerated(string fieldName, Type enumType);

	BooleanCollection ReadBooleanArray(string fieldName);

	SByteCollection ReadSByteArray(string fieldName);

	ByteCollection ReadByteArray(string fieldName);

	Int16Collection ReadInt16Array(string fieldName);

	UInt16Collection ReadUInt16Array(string fieldName);

	Int32Collection ReadInt32Array(string fieldName);

	UInt32Collection ReadUInt32Array(string fieldName);

	Int64Collection ReadInt64Array(string fieldName);

	UInt64Collection ReadUInt64Array(string fieldName);

	FloatCollection ReadFloatArray(string fieldName);

	DoubleCollection ReadDoubleArray(string fieldName);

	StringCollection ReadStringArray(string fieldName);

	DateTimeCollection ReadDateTimeArray(string fieldName);

	UuidCollection ReadGuidArray(string fieldName);

	ByteStringCollection ReadByteStringArray(string fieldName);

	XmlElementCollection ReadXmlElementArray(string fieldName);

	NodeIdCollection ReadNodeIdArray(string fieldName);

	ExpandedNodeIdCollection ReadExpandedNodeIdArray(string fieldName);

	StatusCodeCollection ReadStatusCodeArray(string fieldName);

	DiagnosticInfoCollection ReadDiagnosticInfoArray(string fieldName);

	QualifiedNameCollection ReadQualifiedNameArray(string fieldName);

	LocalizedTextCollection ReadLocalizedTextArray(string fieldName);

	VariantCollection ReadVariantArray(string fieldName);

	DataValueCollection ReadDataValueArray(string fieldName);

	ExtensionObjectCollection ReadExtensionObjectArray(string fieldName);

	Array ReadEncodeableArray(string fieldName, Type systemType, ExpandedNodeId encodeableTypeId = null);

	Array ReadEnumeratedArray(string fieldName, Type enumType);

	Array ReadArray(string fieldName, int valueRank, BuiltInType builtInType, Type systemType = null, ExpandedNodeId encodeableTypeId = null);
}
