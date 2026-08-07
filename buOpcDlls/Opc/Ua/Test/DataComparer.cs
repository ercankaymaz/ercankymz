// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Test.DataComparer
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Xml;

#nullable disable
namespace Opc.Ua.Test;

[ComVisible(true)]
public class DataComparer
{
  private static IEncodeableFactory s_Factory = (IEncodeableFactory) new Opc.Ua.EncodeableFactory();
  private IServiceMessageContext m_context;
  private bool m_throwOnError;

  public DataComparer(IServiceMessageContext context)
  {
    this.m_context = context;
    this.m_throwOnError = true;
  }

  public bool ThrowOnError
  {
    get => this.m_throwOnError;
    set => this.m_throwOnError = value;
  }

  public bool CompareBoolean(bool value1, bool value2)
  {
    return value1 == value2 || this.ReportError((object) value1, (object) value2);
  }

  public bool CompareSByte(sbyte value1, sbyte value2)
  {
    return (int) value1 == (int) value2 || this.ReportError((object) value1, (object) value2);
  }

  public bool CompareByte(byte value1, byte value2)
  {
    return (int) value1 == (int) value2 || this.ReportError((object) value1, (object) value2);
  }

  public bool CompareInt16(short value1, short value2)
  {
    return (int) value1 == (int) value2 || this.ReportError((object) value1, (object) value2);
  }

  public bool CompareUInt16(ushort value1, ushort value2)
  {
    return (int) value1 == (int) value2 || this.ReportError((object) value1, (object) value2);
  }

  public bool CompareInt32(int value1, int value2)
  {
    return value1 == value2 || this.ReportError((object) value1, (object) value2);
  }

  public bool CompareUInt32(uint value1, uint value2)
  {
    return (int) value1 == (int) value2 || this.ReportError((object) value1, (object) value2);
  }

  public bool CompareInt64(long value1, long value2)
  {
    return value1 == value2 || this.ReportError((object) value1, (object) value2);
  }

  public bool CompareUInt64(ulong value1, ulong value2)
  {
    return (long) value1 == (long) value2 || this.ReportError((object) value1, (object) value2);
  }

  public bool CompareFloat(float value1, float value2)
  {
    return (double) value1 == (double) value2 || float.IsNaN(value1) && float.IsNaN(value2) || this.ReportError((object) value1, (object) value2);
  }

  public bool CompareDouble(double value1, double value2)
  {
    if (value1 == value2 || double.IsNaN(value1) && double.IsNaN(value2))
      return true;
    double num = Math.Abs(value1 - value2);
    return num < Math.Abs(value1 / 1E+15) || this.ReportError((object) value1, (object) num);
  }

  public bool CompareString(string value1, string value2)
  {
    return !(value1 != value2) || this.ReportError((object) value1, (object) value2);
  }

  public bool CompareDateTime(DateTime value1, DateTime value2)
  {
    if (value1.Kind != value2.Kind)
    {
      value1 = Utils.ToOpcUaUniversalTime(value1);
      value2 = Utils.ToOpcUaUniversalTime(value2);
    }
    if (value1 < Utils.TimeBase)
      value1 = DateTime.MinValue;
    if (value2 < Utils.TimeBase)
      value2 = DateTime.MinValue;
    return value1 == value2 || Math.Abs((value1 - value2).Ticks) < 10000L;
  }

  public bool CompareUuid(Uuid value1, Uuid value2)
  {
    return !(value1 != value2) || this.ReportError((object) value1, (object) value2);
  }

  public bool CompareByteString(byte[] value1, byte[] value2)
  {
    if (value1 != null && value2 != null)
    {
      if (value1.Length != value2.Length)
        return this.ReportError((object) value1, (object) value2);
      for (int index = 0; index < value1.Length; ++index)
      {
        if ((int) value1[index] != (int) value2[index])
          return this.ReportError((object) value1[index], (object) value1[index]);
      }
      return true;
    }
    return value1 == value2 || this.ReportError((object) value1, (object) value2);
  }

  public bool CompareXmlElement(XmlElement value1, XmlElement value2)
  {
    if (value1 != null && value2 != null)
    {
      if (value1.LocalName != value2.LocalName)
        return this.ReportError((object) value1.LocalName, (object) value2.LocalName);
      if (value1.NamespaceURI != value2.NamespaceURI)
        return this.ReportError((object) value1.NamespaceURI, (object) value2.NamespaceURI);
      foreach (XmlAttribute attribute in (XmlNamedNodeMap) value1.Attributes)
      {
        XmlAttribute attributeNode = value2.GetAttributeNode(attribute.Name);
        if (attributeNode == null)
        {
          if (!attribute.Name.StartsWith("xmlns", StringComparison.Ordinal))
            return this.ReportError((object) attribute, (object) attributeNode);
          string prefix = attribute.Name.Length > 5 ? attribute.Name.Substring(6) : string.Empty;
          if (attribute.Value != value2.GetNamespaceOfPrefix(prefix))
            return this.ReportError((object) attribute.Value, (object) value2.GetNamespaceOfPrefix(prefix));
        }
        else if (attributeNode.Value != attribute.Value)
          return this.ReportError((object) attributeNode.Value, (object) attribute.Value);
      }
      XmlNode xmlNode1 = value1.FirstChild;
      XmlNode xmlNode2 = value2.FirstChild;
      while (xmlNode1 != null && xmlNode2 != null)
      {
        while (xmlNode1 != null && xmlNode1.NodeType != XmlNodeType.Element)
          xmlNode1 = xmlNode1.NextSibling;
        while (xmlNode2 != null && xmlNode2.NodeType != XmlNodeType.Element)
          xmlNode2 = xmlNode2.NextSibling;
        if (!this.CompareXmlElement((XmlElement) xmlNode1, (XmlElement) xmlNode2))
          return false;
        if (xmlNode1 != null)
          xmlNode1 = xmlNode1.NextSibling;
        if (xmlNode2 != null)
          xmlNode2 = xmlNode2.NextSibling;
      }
      return xmlNode1 == xmlNode2 || this.ReportError((object) xmlNode1, (object) xmlNode2);
    }
    return value1 == value2 || this.ReportError((object) value1, (object) value2);
  }

  public bool CompareNodeId(NodeId value1, NodeId value2)
  {
    if (NodeId.IsNull(value1) && NodeId.IsNull(value2))
      return true;
    return !(value1 == (object) null) && !(value2 == (object) null) ? !(value1 != (object) value2) || this.ReportError((object) value1, (object) value2) : !(value1 != (object) value2) || this.ReportError((object) value1, (object) value2);
  }

  public bool CompareExpandedNodeId(ExpandedNodeId value1, ExpandedNodeId value2)
  {
    if (NodeId.IsNull(value1) && NodeId.IsNull(value2))
      return true;
    return !(value1 == (object) null) && !(value2 == (object) null) ? !(value1 != (object) value2) || !(ExpandedNodeId.ToNodeId(value1, this.m_context.NamespaceUris) != (object) ExpandedNodeId.ToNodeId(value2, this.m_context.NamespaceUris)) || this.ReportError((object) value1, (object) value2) : !(value1 != (object) value2);
  }

  public bool CompareStatusCode(StatusCode value1, StatusCode value2)
  {
    return !(value1 != value2) || this.ReportError((object) value1, (object) value2);
  }

  public bool CompareDiagnosticInfo(DiagnosticInfo value1, DiagnosticInfo value2)
  {
    if (value1 == null && value2 == null)
      return true;
    if (value1 == null)
      value1 = new DiagnosticInfo();
    if (value2 == null)
      value2 = new DiagnosticInfo();
    return this.CompareInt32(value1.SymbolicId, value2.SymbolicId) && this.CompareInt32(value1.NamespaceUri, value2.NamespaceUri) && this.CompareInt32(value1.Locale, value2.Locale) && this.CompareInt32(value1.LocalizedText, value2.LocalizedText) && this.CompareString(value1.AdditionalInfo, value2.AdditionalInfo) && this.CompareStatusCode(value1.InnerStatusCode, value2.InnerStatusCode) && this.CompareDiagnosticInfo(value1.InnerDiagnosticInfo, value2.InnerDiagnosticInfo);
  }

  public bool CompareQualifiedName(QualifiedName value1, QualifiedName value2)
  {
    return value1 == (QualifiedName) null ? value2 == (QualifiedName) null || value2 == QualifiedName.Null : (value2 == (QualifiedName) null ? value1 == (QualifiedName) null || value1 == QualifiedName.Null : value1.Equals((object) value2) || this.ReportError((object) value1, (object) value1));
  }

  public bool CompareLocalizedText(LocalizedText value1, LocalizedText value2)
  {
    return value1 == (LocalizedText) null ? value2 == (LocalizedText) null || value2 == LocalizedText.Null : (value2 == (LocalizedText) null ? value1 == (LocalizedText) null || value1 == LocalizedText.Null : value1.Equals((object) value2) || this.ReportError((object) value1, (object) value1));
  }

  public bool CompareVariant(Opc.Ua.Variant value1, Opc.Ua.Variant value2)
  {
    if (value1.Value != null && value2.Value != null)
    {
      Type type = value1.Value.GetType();
      if (type != value2.Value.GetType())
        return this.ReportError(value1.Value, value2.Value);
      if (type.IsArray && !(type == typeof (byte[])))
      {
        if (type == typeof (bool[]))
          return this.CompareArray<bool>((IEnumerable<bool>) (bool[]) value1.Value, (IEnumerable<bool>) (bool[]) value2.Value, new DataComparer.Comparator<bool>(this.CompareBoolean));
        if (type == typeof (sbyte[]))
          return this.CompareArray<sbyte>((IEnumerable<sbyte>) (sbyte[]) value1.Value, (IEnumerable<sbyte>) (sbyte[]) value2.Value, new DataComparer.Comparator<sbyte>(this.CompareSByte));
        if (type == typeof (short[]))
          return this.CompareArray<short>((IEnumerable<short>) (short[]) value1.Value, (IEnumerable<short>) (short[]) value2.Value, new DataComparer.Comparator<short>(this.CompareInt16));
        if (type == typeof (ushort[]))
          return this.CompareArray<ushort>((IEnumerable<ushort>) (ushort[]) value1.Value, (IEnumerable<ushort>) (ushort[]) value2.Value, new DataComparer.Comparator<ushort>(this.CompareUInt16));
        if (type == typeof (int[]))
          return this.CompareArray<int>((IEnumerable<int>) (int[]) value1.Value, (IEnumerable<int>) (int[]) value2.Value, new DataComparer.Comparator<int>(this.CompareInt32));
        if (type == typeof (uint[]))
          return this.CompareArray<uint>((IEnumerable<uint>) (uint[]) value1.Value, (IEnumerable<uint>) (uint[]) value2.Value, new DataComparer.Comparator<uint>(this.CompareUInt32));
        if (type == typeof (long[]))
          return this.CompareArray<long>((IEnumerable<long>) (long[]) value1.Value, (IEnumerable<long>) (long[]) value2.Value, new DataComparer.Comparator<long>(this.CompareInt64));
        if (type == typeof (ulong[]))
          return this.CompareArray<ulong>((IEnumerable<ulong>) (ulong[]) value1.Value, (IEnumerable<ulong>) (ulong[]) value2.Value, new DataComparer.Comparator<ulong>(this.CompareUInt64));
        if (type == typeof (float[]))
          return this.CompareArray<float>((IEnumerable<float>) (float[]) value1.Value, (IEnumerable<float>) (float[]) value2.Value, new DataComparer.Comparator<float>(this.CompareFloat));
        if (type == typeof (double[]))
          return this.CompareArray<double>((IEnumerable<double>) (double[]) value1.Value, (IEnumerable<double>) (double[]) value2.Value, new DataComparer.Comparator<double>(this.CompareDouble));
        if (type == typeof (string[]))
          return this.CompareArray<string>((IEnumerable<string>) (string[]) value1.Value, (IEnumerable<string>) (string[]) value2.Value, new DataComparer.Comparator<string>(this.CompareString));
        if (type == typeof (DateTime[]))
          return this.CompareArray<DateTime>((IEnumerable<DateTime>) (DateTime[]) value1.Value, (IEnumerable<DateTime>) (DateTime[]) value2.Value, new DataComparer.Comparator<DateTime>(this.CompareDateTime));
        if (type == typeof (Uuid[]))
          return this.CompareArray<Uuid>((IEnumerable<Uuid>) (Uuid[]) value1.Value, (IEnumerable<Uuid>) (Uuid[]) value2.Value, new DataComparer.Comparator<Uuid>(this.CompareUuid));
        if (type == typeof (byte[][]))
          return this.CompareArray<byte[]>((IEnumerable<byte[]>) (byte[][]) value1.Value, (IEnumerable<byte[]>) (byte[][]) value2.Value, new DataComparer.Comparator<byte[]>(this.CompareByteString));
        if (type == typeof (XmlElement[]))
          return this.CompareArray<XmlElement>((IEnumerable<XmlElement>) (XmlElement[]) value1.Value, (IEnumerable<XmlElement>) (XmlElement[]) value2.Value, new DataComparer.Comparator<XmlElement>(this.CompareXmlElement));
        if (type == typeof (NodeId[]))
          return this.CompareArray<NodeId>((IEnumerable<NodeId>) (NodeId[]) value1.Value, (IEnumerable<NodeId>) (NodeId[]) value2.Value, new DataComparer.Comparator<NodeId>(this.CompareNodeId));
        if (type == typeof (ExpandedNodeId[]))
          return this.CompareArray<ExpandedNodeId>((IEnumerable<ExpandedNodeId>) (ExpandedNodeId[]) value1.Value, (IEnumerable<ExpandedNodeId>) (ExpandedNodeId[]) value2.Value, new DataComparer.Comparator<ExpandedNodeId>(this.CompareExpandedNodeId));
        if (type == typeof (StatusCode[]))
          return this.CompareArray<StatusCode>((IEnumerable<StatusCode>) (StatusCode[]) value1.Value, (IEnumerable<StatusCode>) (StatusCode[]) value2.Value, new DataComparer.Comparator<StatusCode>(this.CompareStatusCode));
        if (type == typeof (DiagnosticInfo[]))
          return this.CompareArray<DiagnosticInfo>((IEnumerable<DiagnosticInfo>) (DiagnosticInfo[]) value1.Value, (IEnumerable<DiagnosticInfo>) (DiagnosticInfo[]) value2.Value, new DataComparer.Comparator<DiagnosticInfo>(this.CompareDiagnosticInfo));
        if (type == typeof (QualifiedName[]))
          return this.CompareArray<QualifiedName>((IEnumerable<QualifiedName>) (QualifiedName[]) value1.Value, (IEnumerable<QualifiedName>) (QualifiedName[]) value2.Value, new DataComparer.Comparator<QualifiedName>(this.CompareQualifiedName));
        if (type == typeof (LocalizedText[]))
          return this.CompareArray<LocalizedText>((IEnumerable<LocalizedText>) (LocalizedText[]) value1.Value, (IEnumerable<LocalizedText>) (LocalizedText[]) value2.Value, new DataComparer.Comparator<LocalizedText>(this.CompareLocalizedText));
        if (type == typeof (ExtensionObject[]))
          return this.CompareArray<ExtensionObject>((IEnumerable<ExtensionObject>) (ExtensionObject[]) value1.Value, (IEnumerable<ExtensionObject>) (ExtensionObject[]) value2.Value, new DataComparer.Comparator<ExtensionObject>(this.CompareExtensionObject));
        if (type == typeof (DataValue[]))
          return this.CompareArray<DataValue>((IEnumerable<DataValue>) (DataValue[]) value1.Value, (IEnumerable<DataValue>) (DataValue[]) value2.Value, new DataComparer.Comparator<DataValue>(this.CompareDataValue));
        if (type == typeof (Opc.Ua.Variant[]))
          return this.CompareArray<Opc.Ua.Variant>((IEnumerable<Opc.Ua.Variant>) (Opc.Ua.Variant[]) value1.Value, (IEnumerable<Opc.Ua.Variant>) (Opc.Ua.Variant[]) value2.Value, new DataComparer.Comparator<Opc.Ua.Variant>(this.CompareVariant));
      }
      else
      {
        if (type == typeof (bool))
          return this.CompareBoolean((bool) value1.Value, (bool) value2.Value);
        if (type == typeof (sbyte))
          return this.CompareSByte((sbyte) value1.Value, (sbyte) value2.Value);
        if (type == typeof (byte))
          return this.CompareByte((byte) value1.Value, (byte) value2.Value);
        if (type == typeof (short))
          return this.CompareInt16((short) value1.Value, (short) value2.Value);
        if (type == typeof (ushort))
          return this.CompareUInt16((ushort) value1.Value, (ushort) value2.Value);
        if (type == typeof (int))
          return this.CompareInt32((int) value1.Value, (int) value2.Value);
        if (type == typeof (uint))
          return this.CompareUInt32((uint) value1.Value, (uint) value2.Value);
        if (type == typeof (long))
          return this.CompareInt64((long) value1.Value, (long) value2.Value);
        if (type == typeof (ulong))
          return this.CompareUInt64((ulong) value1.Value, (ulong) value2.Value);
        if (type == typeof (float))
          return this.CompareFloat((float) value1.Value, (float) value2.Value);
        if (type == typeof (double))
          return this.CompareDouble((double) value1.Value, (double) value2.Value);
        if (type == typeof (string))
          return this.CompareString((string) value1.Value, (string) value2.Value);
        if (type == typeof (DateTime))
          return this.CompareDateTime((DateTime) value1.Value, (DateTime) value2.Value);
        if (type == typeof (Uuid))
          return this.CompareUuid((Uuid) value1.Value, (Uuid) value2.Value);
        if (type == typeof (byte[]))
          return this.CompareByteString((byte[]) value1.Value, (byte[]) value2.Value);
        if (type == typeof (XmlElement))
          return this.CompareXmlElement((XmlElement) value1.Value, (XmlElement) value2.Value);
        if (type == typeof (NodeId))
          return this.CompareNodeId((NodeId) value1.Value, (NodeId) value2.Value);
        if (type == typeof (ExpandedNodeId))
          return this.CompareExpandedNodeId((ExpandedNodeId) value1.Value, (ExpandedNodeId) value2.Value);
        if (type == typeof (StatusCode))
          return this.CompareStatusCode((StatusCode) value1.Value, (StatusCode) value2.Value);
        if (type == typeof (DiagnosticInfo))
          return this.CompareDiagnosticInfo((DiagnosticInfo) value1.Value, (DiagnosticInfo) value2.Value);
        if (type == typeof (QualifiedName))
          return this.CompareQualifiedName((QualifiedName) value1.Value, (QualifiedName) value2.Value);
        if (type == typeof (LocalizedText))
          return this.CompareLocalizedText((LocalizedText) value1.Value, (LocalizedText) value2.Value);
        if (type == typeof (ExtensionObject))
          return this.CompareExtensionObject((ExtensionObject) value1.Value, (ExtensionObject) value2.Value);
        if (type == typeof (DataValue))
          return this.CompareDataValue((DataValue) value1.Value, (DataValue) value2.Value);
        if (type == typeof (Opc.Ua.Variant))
          return this.CompareVariant((Opc.Ua.Variant) value1.Value, (Opc.Ua.Variant) value2.Value);
        if (type == typeof (Matrix))
          return this.CompareMatrix((Matrix) value1.Value, (Matrix) value2.Value);
      }
      return this.ReportError(value1.Value, value2.Value);
    }
    return value1.Value == value2.Value || this.ReportError(value1.Value, value2.Value);
  }

  public bool CompareDataValue(DataValue value1, DataValue value2)
  {
    return value1 != null && value2 != null ? this.CompareVariant(value1.WrappedValue, value2.WrappedValue) && this.CompareStatusCode(value1.StatusCode, value2.StatusCode) && this.CompareDateTime(value1.SourceTimestamp, value2.SourceTimestamp) && this.CompareUInt16(value1.SourcePicoseconds, value2.SourcePicoseconds) && this.CompareDateTime(value1.ServerTimestamp, value2.ServerTimestamp) && this.CompareUInt16(value1.ServerPicoseconds, value2.ServerPicoseconds) : value1 == value2 || this.ReportError((object) value1, (object) value2);
  }

  public bool CompareMatrix(Matrix value1, Matrix value2)
  {
    return value1 != null && value2 != null ? this.CompareVariant(new Opc.Ua.Variant((object) value1.Elements), new Opc.Ua.Variant((object) value2.Elements)) && this.CompareArray<int>((IEnumerable<int>) value1.Dimensions, (IEnumerable<int>) value2.Dimensions, new DataComparer.Comparator<int>(this.CompareInt32)) : value1 == value2 || this.ReportError((object) value1, (object) value2);
  }

  public static IEncodeableFactory EncodeableFactory
  {
    get
    {
      if (DataComparer.s_Factory == null)
      {
        DataComparer.s_Factory = (IEncodeableFactory) new Opc.Ua.EncodeableFactory();
        DataComparer.s_Factory.AddEncodeableTypes(typeof (DataComparer).GetTypeInfo().Assembly);
      }
      return DataComparer.s_Factory;
    }
  }

  public static object GetExtensionObjectBody(ExtensionObject value)
  {
    object body = value.Body;
    if (body is IEncodeable extensionObjectBody1)
      return (object) extensionObjectBody1;
    Type systemType = DataComparer.EncodeableFactory.GetSystemType(value.TypeId);
    if (systemType == (Type) null)
      return body;
    IServiceMessageContext context = (IServiceMessageContext) new ServiceMessageContext()
    {
      Factory = DataComparer.EncodeableFactory
    };
    switch (body)
    {
      case XmlElement element:
        XmlQualifiedName xmlName = Opc.Ua.EncodeableFactory.GetXmlName(systemType);
        XmlDecoder xmlDecoder = new XmlDecoder(element, context);
        xmlDecoder.PushNamespace(xmlName.Namespace);
        object extensionObjectBody2 = (object) xmlDecoder.ReadEncodeable(xmlName.Name, systemType, (ExpandedNodeId) null);
        xmlDecoder.PopNamespace();
        xmlDecoder.Close();
        return (object) (IEncodeable) extensionObjectBody2;
      case byte[] buffer:
        BinaryDecoder binaryDecoder = new BinaryDecoder(buffer, context);
        object extensionObjectBody3 = (object) binaryDecoder.ReadEncodeable((string) null, systemType, (ExpandedNodeId) null);
        binaryDecoder.Close();
        return (object) (IEncodeable) extensionObjectBody3;
      default:
        return body;
    }
  }

  public bool CompareExtensionObject(ExtensionObject value1, ExtensionObject value2)
  {
    if (value1 != null && value2 != null)
    {
      object body1 = value1.Body;
      object body2 = value2.Body;
      if (body1 == null || body2 == null)
        return body1 == body2;
      return value1.Body is byte[] body3 && value2.Body is byte[] body4 ? (!this.CompareExpandedNodeId(value1.TypeId, value2.TypeId) ? this.ReportError((object) value1.TypeId, (object) value2.TypeId) : this.CompareByteString(body3, body4)) : (value1.Body is XmlElement body5 && value2.Body is XmlElement body6 ? (!this.CompareExpandedNodeId(value1.TypeId, value2.TypeId) ? this.ReportError((object) value1.TypeId, (object) value2.TypeId) : this.CompareXmlElement(body5, body6)) : this.CompareExtensionObjectBody(DataComparer.GetExtensionObjectBody(value1), DataComparer.GetExtensionObjectBody(value2)) || this.ReportError((object) value1, (object) value2));
    }
    return value1 == value2 || this.ReportError((object) value1, (object) value2);
  }

  protected virtual bool CompareExtensionObjectBody(object value1, object value2)
  {
    return value1 == value2 || value1 is IEncodeable encodeable1 && value2 is IEncodeable encodeable2 && encodeable1.IsEqual(encodeable2);
  }

  private bool CompareArray<T>(
    IEnumerable<T> value1,
    IEnumerable<T> value2,
    DataComparer.Comparator<T> comparator)
  {
    if (value1 == null)
      return value2 == null || !value2.GetEnumerator().MoveNext();
    if (value2 == null)
      return value1 == null || !value1.GetEnumerator().MoveNext();
    IEnumerator<T> enumerator1 = value1.GetEnumerator();
    IEnumerator<T> enumerator2 = value2.GetEnumerator();
    while (enumerator1.MoveNext())
    {
      if (!enumerator2.MoveNext())
        return this.ReportError((object) value1, (object) value2);
      if (!comparator(enumerator1.Current, enumerator2.Current))
        return false;
    }
    return !enumerator2.MoveNext() || this.ReportError((object) value1, (object) value2);
  }

  private bool ReportError(object value1, object value2)
  {
    if (this.m_throwOnError)
      throw ServiceResultException.Create(2147549184U /*0x80010000*/, "'{0}' is not equal to '{1}'.", value1, value2);
    return false;
  }

  private delegate bool Comparator<T>(T value1, T value2);
}
