// Decompiled with JetBrains decompiler
// Type: Opc.Ua.IEncoder
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Xml;

#nullable disable
namespace Opc.Ua;

[ComVisible(true)]
public interface IEncoder : IDisposable
{
  EncodingType EncodingType { get; }

  bool UseReversibleEncoding { get; }

  IServiceMessageContext Context { get; }

  int Close();

  string CloseAndReturnText();

  void SetMappingTables(NamespaceTable namespaceUris, StringTable serverUris);

  void PushNamespace(string namespaceUri);

  void PopNamespace();

  void WriteBoolean(string fieldName, bool value);

  void WriteSByte(string fieldName, sbyte value);

  void WriteByte(string fieldName, byte value);

  void WriteInt16(string fieldName, short value);

  void WriteUInt16(string fieldName, ushort value);

  void WriteInt32(string fieldName, int value);

  void WriteUInt32(string fieldName, uint value);

  void WriteInt64(string fieldName, long value);

  void WriteUInt64(string fieldName, ulong value);

  void WriteFloat(string fieldName, float value);

  void WriteDouble(string fieldName, double value);

  void WriteString(string fieldName, string value);

  void WriteDateTime(string fieldName, DateTime value);

  void WriteGuid(string fieldName, Uuid value);

  void WriteGuid(string fieldName, Guid value);

  void WriteByteString(string fieldName, byte[] value);

  void WriteXmlElement(string fieldName, XmlElement value);

  void WriteNodeId(string fieldName, NodeId value);

  void WriteExpandedNodeId(string fieldName, ExpandedNodeId value);

  void WriteStatusCode(string fieldName, StatusCode value);

  void WriteDiagnosticInfo(string fieldName, DiagnosticInfo value);

  void WriteQualifiedName(string fieldName, QualifiedName value);

  void WriteLocalizedText(string fieldName, LocalizedText value);

  void WriteVariant(string fieldName, Variant value);

  void WriteDataValue(string fieldName, DataValue value);

  void WriteExtensionObject(string fieldName, ExtensionObject value);

  void WriteEncodeable(string fieldName, IEncodeable value, Type systemType);

  void WriteEnumerated(string fieldName, Enum value);

  void WriteBooleanArray(string fieldName, IList<bool> values);

  void WriteSByteArray(string fieldName, IList<sbyte> values);

  void WriteByteArray(string fieldName, IList<byte> values);

  void WriteInt16Array(string fieldName, IList<short> values);

  void WriteUInt16Array(string fieldName, IList<ushort> values);

  void WriteInt32Array(string fieldName, IList<int> values);

  void WriteUInt32Array(string fieldName, IList<uint> values);

  void WriteInt64Array(string fieldName, IList<long> values);

  void WriteUInt64Array(string fieldName, IList<ulong> values);

  void WriteFloatArray(string fieldName, IList<float> values);

  void WriteDoubleArray(string fieldName, IList<double> values);

  void WriteStringArray(string fieldName, IList<string> values);

  void WriteDateTimeArray(string fieldName, IList<DateTime> values);

  void WriteGuidArray(string fieldName, IList<Uuid> values);

  void WriteGuidArray(string fieldName, IList<Guid> values);

  void WriteByteStringArray(string fieldName, IList<byte[]> values);

  void WriteXmlElementArray(string fieldName, IList<XmlElement> values);

  void WriteNodeIdArray(string fieldName, IList<NodeId> values);

  void WriteExpandedNodeIdArray(string fieldName, IList<ExpandedNodeId> values);

  void WriteStatusCodeArray(string fieldName, IList<StatusCode> values);

  void WriteDiagnosticInfoArray(string fieldName, IList<DiagnosticInfo> values);

  void WriteQualifiedNameArray(string fieldName, IList<QualifiedName> values);

  void WriteLocalizedTextArray(string fieldName, IList<LocalizedText> values);

  void WriteVariantArray(string fieldName, IList<Variant> values);

  void WriteDataValueArray(string fieldName, IList<DataValue> values);

  void WriteExtensionObjectArray(string fieldName, IList<ExtensionObject> values);

  void WriteEncodeableArray(string fieldName, IList<IEncodeable> values, Type systemType);

  void WriteEnumeratedArray(string fieldName, Array values, Type systemType);

  void WriteArray(string fieldName, object array, int valueRank, BuiltInType builtInType);
}
