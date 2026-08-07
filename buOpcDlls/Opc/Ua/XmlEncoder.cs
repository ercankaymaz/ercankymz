// Decompiled with JetBrains decompiler
// Type: Opc.Ua.XmlEncoder
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;

#nullable disable
namespace Opc.Ua;

[ComVisible(true)]
public class XmlEncoder : IEncoder, IDisposable
{
  private StringBuilder m_destination;
  private XmlWriter m_writer;
  private Stack<string> m_namespaces;
  private XmlQualifiedName m_root;
  private IServiceMessageContext m_context;
  private ushort[] m_namespaceMappings;
  private ushort[] m_serverMappings;
  private uint m_nestingLevel;

  public XmlEncoder(IServiceMessageContext context)
  {
    this.Initialize();
    this.m_destination = new StringBuilder();
    this.m_context = context;
    this.m_nestingLevel = 0U;
    XmlWriterSettings settings = Utils.DefaultXmlWriterSettings();
    settings.CheckCharacters = false;
    settings.ConformanceLevel = ConformanceLevel.Auto;
    settings.NamespaceHandling = NamespaceHandling.OmitDuplicates;
    settings.NewLineHandling = NewLineHandling.Replace;
    this.m_writer = XmlWriter.Create(this.m_destination, settings);
  }

  public XmlEncoder(Type systemType, XmlWriter writer, IServiceMessageContext context)
    : this(EncodeableFactory.GetXmlName(systemType), writer, context)
  {
  }

  public XmlEncoder(XmlQualifiedName root, XmlWriter writer, IServiceMessageContext context)
  {
    this.Initialize();
    if (writer == null)
    {
      this.m_destination = new StringBuilder();
      this.m_writer = XmlWriter.Create(this.m_destination);
    }
    else
    {
      this.m_destination = (StringBuilder) null;
      this.m_writer = writer;
    }
    this.Initialize(root.Name, root.Namespace);
    this.m_context = context;
    this.m_nestingLevel = 0U;
  }

  private void Initialize()
  {
    this.m_destination = (StringBuilder) null;
    this.m_writer = (XmlWriter) null;
    this.m_namespaces = new Stack<string>();
    this.m_root = (XmlQualifiedName) null;
  }

  private void Initialize(string fieldName, string namespaceUri)
  {
    this.m_root = new XmlQualifiedName(fieldName, namespaceUri);
    string prefix = this.m_writer.LookupPrefix("http://opcfoundation.org/UA/2008/02/Types.xsd") ?? "uax";
    if (namespaceUri == "http://opcfoundation.org/UA/2008/02/Types.xsd")
      this.m_writer.WriteStartElement(prefix, fieldName, namespaceUri);
    else
      this.m_writer.WriteStartElement(fieldName, namespaceUri);
    if (this.m_writer.LookupPrefix("http://www.w3.org/2001/XMLSchema-instance") == null)
      this.m_writer.WriteAttributeString("xmlns", "xsi", (string) null, "http://www.w3.org/2001/XMLSchema-instance");
    if (this.m_writer.LookupPrefix("http://opcfoundation.org/UA/2008/02/Types.xsd") == null)
      this.m_writer.WriteAttributeString("xmlns", "uax", (string) null, "http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.PushNamespace(namespaceUri);
  }

  public void SetMappingTables(NamespaceTable namespaceUris, StringTable serverUris)
  {
    this.m_namespaceMappings = (ushort[]) null;
    if (namespaceUris != null && this.m_context.NamespaceUris != null)
      this.m_namespaceMappings = namespaceUris.CreateMapping((StringTable) this.m_context.NamespaceUris, false);
    this.m_serverMappings = (ushort[]) null;
    if (serverUris == null || this.m_context.ServerUris == null)
      return;
    this.m_serverMappings = serverUris.CreateMapping(this.m_context.ServerUris, false);
  }

  public void SaveStringTable(string tableName, string elementName, StringTable stringTable)
  {
    if (stringTable == null || stringTable.Count <= 1)
      return;
    this.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    try
    {
      this.Push(tableName, "http://opcfoundation.org/UA/2008/02/Types.xsd");
      for (ushort index = 1; (int) index < stringTable.Count; ++index)
        this.WriteString(elementName, stringTable.GetString((uint) index));
      this.Pop();
    }
    finally
    {
      this.PopNamespace();
    }
  }

  public void Push(string fieldName, string namespaceUri)
  {
    this.m_writer.WriteStartElement(fieldName, namespaceUri);
    this.PushNamespace(namespaceUri);
  }

  public void Pop()
  {
    this.m_writer.WriteEndElement();
    this.PopNamespace();
  }

  public int Close()
  {
    if (this.m_root != (XmlQualifiedName) null)
      this.m_writer.WriteEndElement();
    this.m_writer.Flush();
    this.m_writer.Dispose();
    return this.m_destination != null ? this.m_destination.Length : 0;
  }

  public string CloseAndReturnText()
  {
    this.Close();
    return this.m_destination != null ? this.m_destination.ToString() : (string) null;
  }

  public void Dispose()
  {
    this.Dispose(true);
    GC.SuppressFinalize((object) this);
  }

  protected virtual void Dispose(bool disposing)
  {
    if (!disposing || this.m_writer == null)
      return;
    this.m_writer.Flush();
    this.m_writer.Dispose();
    this.m_writer = (XmlWriter) null;
  }

  public EncodingType EncodingType => EncodingType.Xml;

  public IServiceMessageContext Context => this.m_context;

  public bool UseReversibleEncoding => true;

  public void PushNamespace(string namespaceUri) => this.m_namespaces.Push(namespaceUri);

  public void PopNamespace() => this.m_namespaces.Pop();

  public void WriteBoolean(string fieldName, bool value)
  {
    if (!this.BeginField(fieldName, false, false))
      return;
    this.m_writer.WriteValue(value);
    this.EndField(fieldName);
  }

  public void WriteSByte(string fieldName, sbyte value)
  {
    if (!this.BeginField(fieldName, false, false))
      return;
    this.m_writer.WriteValue((int) value);
    this.EndField(fieldName);
  }

  public void WriteByte(string fieldName, byte value)
  {
    if (!this.BeginField(fieldName, false, false))
      return;
    this.m_writer.WriteValue((int) value);
    this.EndField(fieldName);
  }

  public void WriteInt16(string fieldName, short value)
  {
    if (!this.BeginField(fieldName, false, false))
      return;
    this.m_writer.WriteValue((int) value);
    this.EndField(fieldName);
  }

  public void WriteUInt16(string fieldName, ushort value)
  {
    if (!this.BeginField(fieldName, false, false))
      return;
    this.m_writer.WriteValue((int) value);
    this.EndField(fieldName);
  }

  public void WriteInt32(string fieldName, int value)
  {
    if (!this.BeginField(fieldName, false, false))
      return;
    this.m_writer.WriteValue(value);
    this.EndField(fieldName);
  }

  public void WriteUInt32(string fieldName, uint value)
  {
    if (!this.BeginField(fieldName, false, false))
      return;
    this.m_writer.WriteValue((long) value);
    this.EndField(fieldName);
  }

  public void WriteInt64(string fieldName, long value)
  {
    if (!this.BeginField(fieldName, false, false))
      return;
    this.m_writer.WriteValue(value);
    this.EndField(fieldName);
  }

  public void WriteUInt64(string fieldName, ulong value)
  {
    if (!this.BeginField(fieldName, false, false))
      return;
    this.m_writer.WriteValue(XmlConvert.ToString(value));
    this.EndField(fieldName);
  }

  public void WriteFloat(string fieldName, float value)
  {
    if (!this.BeginField(fieldName, false, false))
      return;
    if (float.IsNaN(value))
      this.m_writer.WriteValue("NaN");
    else if (float.IsPositiveInfinity(value))
      this.m_writer.WriteValue("INF");
    else if (float.IsNegativeInfinity(value))
      this.m_writer.WriteValue("-INF");
    else
      this.m_writer.WriteValue(value);
    this.EndField(fieldName);
  }

  public void WriteDouble(string fieldName, double value)
  {
    if (!this.BeginField(fieldName, false, false))
      return;
    this.m_writer.WriteValue(value);
    this.EndField(fieldName);
  }

  public void WriteString(string fieldName, string value)
  {
    this.WriteString(fieldName, value, false);
  }

  private void WriteString(string fieldName, string value, bool isArrayElement)
  {
    if (!this.BeginField(fieldName, value == null, true, isArrayElement))
      return;
    if (this.m_context.MaxStringLength > 0 && this.m_context.MaxStringLength < value.Length)
      throw new ServiceResultException(2148007936U /*0x80080000*/);
    if (!string.IsNullOrWhiteSpace(value))
      this.m_writer.WriteString(value);
    this.EndField(fieldName);
  }

  public void WriteDateTime(string fieldName, DateTime value)
  {
    if (!this.BeginField(fieldName, false, false))
      return;
    value = Utils.ToOpcUaUniversalTime(value);
    this.m_writer.WriteValue(value);
    this.EndField(fieldName);
  }

  public void WriteGuid(string fieldName, Uuid value)
  {
    if (!this.BeginField(fieldName, false, false))
      return;
    this.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.WriteString("String", value.GuidString);
    this.PopNamespace();
    this.EndField(fieldName);
  }

  public void WriteGuid(string fieldName, Guid value)
  {
    if (!this.BeginField(fieldName, false, false))
      return;
    this.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.WriteString("String", value.ToString());
    this.PopNamespace();
    this.EndField(fieldName);
  }

  public void WriteByteString(string fieldName, byte[] value)
  {
    this.WriteByteString(fieldName, value, false);
  }

  private void WriteByteString(string fieldName, byte[] value, bool isArrayElement = false)
  {
    if (!this.BeginField(fieldName, value == null, true, isArrayElement))
      return;
    if (this.m_context.MaxByteStringLength > 0 && this.m_context.MaxByteStringLength < value.Length)
      throw new ServiceResultException(2148007936U /*0x80080000*/);
    this.m_writer.WriteValue(Convert.ToBase64String(value, Base64FormattingOptions.InsertLineBreaks));
    this.EndField(fieldName);
  }

  public void WriteXmlElement(string fieldName, XmlElement value)
  {
    this.WriteXmlElement(fieldName, value, false);
  }

  private void WriteXmlElement(string fieldName, XmlElement value, bool isArrayElement)
  {
    if (!this.BeginField(fieldName, value == null, true, isArrayElement))
      return;
    this.m_writer.WriteRaw(value.OuterXml);
    this.EndField(fieldName);
  }

  public void WriteNodeId(string fieldName, NodeId value)
  {
    if (!this.BeginField(fieldName, value == (object) null, true))
      return;
    this.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    if (value != (object) null)
    {
      ushort namespaceIndex = value.NamespaceIndex;
      if (this.m_namespaceMappings != null && this.m_namespaceMappings.Length > (int) namespaceIndex)
        namespaceIndex = this.m_namespaceMappings[(int) namespaceIndex];
      StringBuilder buffer = new StringBuilder();
      NodeId.Format(buffer, value.Identifier, value.IdType, namespaceIndex);
      this.WriteString("Identifier", buffer.ToString());
    }
    this.PopNamespace();
    this.EndField(fieldName);
  }

  public void WriteExpandedNodeId(string fieldName, ExpandedNodeId value)
  {
    if (!this.BeginField(fieldName, value == (object) null, true))
      return;
    this.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    if (value != (object) null)
    {
      ushort namespaceIndex = value.NamespaceIndex;
      if (this.m_namespaceMappings != null && this.m_namespaceMappings.Length > (int) namespaceIndex)
        namespaceIndex = this.m_namespaceMappings[(int) namespaceIndex];
      uint serverIndex = value.ServerIndex;
      if (this.m_serverMappings != null && (long) this.m_serverMappings.Length > (long) serverIndex)
        serverIndex = (uint) this.m_serverMappings[(int) serverIndex];
      StringBuilder buffer = new StringBuilder();
      ExpandedNodeId.Format(buffer, value.Identifier, value.IdType, namespaceIndex, value.NamespaceUri, serverIndex);
      this.WriteString("Identifier", buffer.ToString());
    }
    this.PopNamespace();
    this.EndField(fieldName);
  }

  public void WriteStatusCode(string fieldName, StatusCode value)
  {
    if (!this.BeginField(fieldName, false, false))
      return;
    this.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.WriteUInt32("Code", value.Code);
    this.PopNamespace();
    this.EndField(fieldName);
  }

  public void WriteDiagnosticInfo(string fieldName, DiagnosticInfo value)
  {
    this.WriteDiagnosticInfo(fieldName, value, 0);
  }

  private void WriteDiagnosticInfo(string fieldName, DiagnosticInfo value, int depth)
  {
    this.CheckAndIncrementNestingLevel();
    if (this.BeginField(fieldName, value == null, true))
    {
      this.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
      if (value != null)
      {
        this.WriteInt32("SymbolicId", value.SymbolicId);
        this.WriteInt32("NamespaceUri", value.NamespaceUri);
        this.WriteInt32("Locale", value.Locale);
        this.WriteInt32("LocalizedText", value.LocalizedText);
        this.WriteString("AdditionalInfo", value.AdditionalInfo);
        this.WriteStatusCode("InnerStatusCode", value.InnerStatusCode);
        if (depth < DiagnosticInfo.MaxInnerDepth)
          this.WriteDiagnosticInfo("InnerDiagnosticInfo", value.InnerDiagnosticInfo, depth + 1);
        else
          Utils.LogWarning("InnerDiagnosticInfo dropped because nesting exceeds maximum of {0}.", (object) DiagnosticInfo.MaxInnerDepth);
      }
      this.PopNamespace();
      this.EndField(fieldName);
    }
    --this.m_nestingLevel;
  }

  public void WriteQualifiedName(string fieldName, QualifiedName value)
  {
    if (!this.BeginField(fieldName, value == (QualifiedName) null, true))
      return;
    this.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    ushort index = value.NamespaceIndex;
    if (this.m_namespaceMappings != null && this.m_namespaceMappings.Length > (int) index)
      index = this.m_namespaceMappings[(int) index];
    if (value != (QualifiedName) null)
    {
      this.WriteUInt16("NamespaceIndex", index);
      this.WriteString("Name", value.Name);
    }
    this.PopNamespace();
    this.EndField(fieldName);
  }

  public void WriteLocalizedText(string fieldName, LocalizedText value)
  {
    if (!this.BeginField(fieldName, value == (LocalizedText) null, true))
      return;
    this.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    if (value != (LocalizedText) null)
    {
      if (!string.IsNullOrEmpty(value.Locale))
        this.WriteString("Locale", value.Locale);
      if (!string.IsNullOrEmpty(value.Text))
        this.WriteString("Text", value.Text);
    }
    this.PopNamespace();
    this.EndField(fieldName);
  }

  public void WriteVariant(string fieldName, Variant value)
  {
    this.CheckAndIncrementNestingLevel();
    try
    {
      if (!this.BeginField(fieldName, false, false))
        return;
      this.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
      this.m_writer.WriteStartElement("Value", "http://opcfoundation.org/UA/2008/02/Types.xsd");
      this.WriteVariantContents(value.Value, value.TypeInfo);
      this.m_writer.WriteEndElement();
      this.PopNamespace();
      this.EndField(fieldName);
    }
    finally
    {
      --this.m_nestingLevel;
    }
  }

  public void WriteDataValue(string fieldName, DataValue value)
  {
    if (!this.BeginField(fieldName, value == null, true))
      return;
    this.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    if (value != null)
    {
      this.WriteVariant("Value", value.WrappedValue);
      this.WriteStatusCode("StatusCode", value.StatusCode);
      this.WriteDateTime("SourceTimestamp", value.SourceTimestamp);
      this.WriteUInt16("SourcePicoseconds", value.SourcePicoseconds);
      this.WriteDateTime("ServerTimestamp", value.ServerTimestamp);
      this.WriteUInt16("ServerPicoseconds", value.ServerPicoseconds);
    }
    this.PopNamespace();
    this.EndField(fieldName);
  }

  public void WriteExtensionObject(string fieldName, ExtensionObject value)
  {
    if (!this.BeginField(fieldName, value == null, true))
      return;
    this.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    if (value == null)
    {
      this.EndField(fieldName);
      this.PopNamespace();
    }
    else
    {
      IEncodeable body1 = value.Body as IEncodeable;
      ExpandedNodeId nodeId1 = value.TypeId;
      if (body1 != null)
        nodeId1 = value.Encoding != ExtensionObjectEncoding.Binary ? body1.XmlEncodingId : body1.BinaryEncodingId;
      NodeId nodeId2 = ExpandedNodeId.ToNodeId(nodeId1, this.m_context.NamespaceUris);
      if (NodeId.IsNull(nodeId2) && !NodeId.IsNull(nodeId1))
      {
        if (body1 != null)
          throw ServiceResultException.Create(2147876864U /*0x80060000*/, "Cannot encode bodies of type '{0}' in ExtensionObject unless the NamespaceUri ({1}) is in the encoder's NamespaceTable.", (object) body1.GetType().FullName, (object) nodeId1.NamespaceUri);
        nodeId2 = NodeId.Null;
      }
      this.WriteNodeId("TypeId", nodeId2);
      object body2 = value.Body;
      if (body2 == null)
      {
        this.EndField(fieldName);
        this.PopNamespace();
      }
      else
      {
        this.m_writer.WriteStartElement("Body", "http://opcfoundation.org/UA/2008/02/Types.xsd");
        this.WriteExtensionObjectBody(body2);
        this.m_writer.WriteEndElement();
        this.EndField(fieldName);
        this.PopNamespace();
      }
    }
  }

  public void WriteEncodeable(string fieldName, IEncodeable value, Type systemType)
  {
    this.CheckAndIncrementNestingLevel();
    if (this.BeginField(fieldName, value == null, true))
    {
      value?.Encode((IEncoder) this);
      this.EndField(fieldName);
    }
    --this.m_nestingLevel;
  }

  public void WriteEnumerated(string fieldName, Enum value)
  {
    if (!this.BeginField(fieldName, value == null, true))
      return;
    if (value != null)
    {
      string text = value.ToString();
      string str = Convert.ToInt32((object) value, (IFormatProvider) CultureInfo.InvariantCulture).ToString();
      if (text != str)
        this.m_writer.WriteString(Utils.Format("{0}_{1}", (object) text, (object) str));
      else
        this.m_writer.WriteString(text);
    }
    this.EndField(fieldName);
  }

  public void WriteBooleanArray(string fieldName, IList<bool> values)
  {
    if (!this.BeginField(fieldName, values == null, true, true))
      return;
    if (this.m_context.MaxArrayLength > 0 && this.m_context.MaxArrayLength < values.Count)
      throw new ServiceResultException(2148007936U /*0x80080000*/);
    this.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    if (values != null)
    {
      for (int index = 0; index < values.Count; ++index)
        this.WriteBoolean("Boolean", values[index]);
    }
    this.PopNamespace();
    this.EndField(fieldName);
  }

  public void WriteSByteArray(string fieldName, IList<sbyte> values)
  {
    if (!this.BeginField(fieldName, values == null, true, true))
      return;
    if (this.m_context.MaxArrayLength > 0 && this.m_context.MaxArrayLength < values.Count)
      throw new ServiceResultException(2148007936U /*0x80080000*/);
    this.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    if (values != null)
    {
      for (int index = 0; index < values.Count; ++index)
        this.WriteSByte("SByte", values[index]);
    }
    this.PopNamespace();
    this.EndField(fieldName);
  }

  public void WriteByteArray(string fieldName, IList<byte> values)
  {
    if (!this.BeginField(fieldName, values == null, true, true))
      return;
    if (this.m_context.MaxArrayLength > 0 && this.m_context.MaxArrayLength < values.Count)
      throw new ServiceResultException(2148007936U /*0x80080000*/);
    this.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    if (values != null)
    {
      for (int index = 0; index < values.Count; ++index)
        this.WriteByte("Byte", values[index]);
    }
    this.PopNamespace();
    this.EndField(fieldName);
  }

  public void WriteInt16Array(string fieldName, IList<short> values)
  {
    if (!this.BeginField(fieldName, values == null, true, true))
      return;
    if (this.m_context.MaxArrayLength > 0 && this.m_context.MaxArrayLength < values.Count)
      throw new ServiceResultException(2148007936U /*0x80080000*/);
    this.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    if (values != null)
    {
      for (int index = 0; index < values.Count; ++index)
        this.WriteInt16("Int16", values[index]);
    }
    this.PopNamespace();
    this.EndField(fieldName);
  }

  public void WriteUInt16Array(string fieldName, IList<ushort> values)
  {
    if (!this.BeginField(fieldName, values == null, true, true))
      return;
    if (this.m_context.MaxArrayLength > 0 && this.m_context.MaxArrayLength < values.Count)
      throw new ServiceResultException(2148007936U /*0x80080000*/);
    this.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    if (values != null)
    {
      for (int index = 0; index < values.Count; ++index)
        this.WriteUInt16("UInt16", values[index]);
    }
    this.PopNamespace();
    this.EndField(fieldName);
  }

  public void WriteInt32Array(string fieldName, IList<int> values)
  {
    if (!this.BeginField(fieldName, values == null, true, true))
      return;
    if (this.m_context.MaxArrayLength > 0 && this.m_context.MaxArrayLength < values.Count)
      throw new ServiceResultException(2148007936U /*0x80080000*/);
    this.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    if (values != null)
    {
      for (int index = 0; index < values.Count; ++index)
        this.WriteInt32("Int32", values[index]);
    }
    this.PopNamespace();
    this.EndField(fieldName);
  }

  public void WriteUInt32Array(string fieldName, IList<uint> values)
  {
    if (!this.BeginField(fieldName, values == null, true, true))
      return;
    if (this.m_context.MaxArrayLength > 0 && this.m_context.MaxArrayLength < values.Count)
      throw new ServiceResultException(2148007936U /*0x80080000*/);
    this.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    if (values != null)
    {
      for (int index = 0; index < values.Count; ++index)
        this.WriteUInt32("UInt32", values[index]);
    }
    this.PopNamespace();
    this.EndField(fieldName);
  }

  public void WriteInt64Array(string fieldName, IList<long> values)
  {
    if (!this.BeginField(fieldName, values == null, true, true))
      return;
    if (this.m_context.MaxArrayLength > 0 && this.m_context.MaxArrayLength < values.Count)
      throw new ServiceResultException(2148007936U /*0x80080000*/);
    this.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    if (values != null)
    {
      for (int index = 0; index < values.Count; ++index)
        this.WriteInt64("Int64", values[index]);
    }
    this.PopNamespace();
    this.EndField(fieldName);
  }

  public void WriteUInt64Array(string fieldName, IList<ulong> values)
  {
    if (!this.BeginField(fieldName, values == null, true, true))
      return;
    if (this.m_context.MaxArrayLength > 0 && this.m_context.MaxArrayLength < values.Count)
      throw new ServiceResultException(2148007936U /*0x80080000*/);
    this.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    if (values != null)
    {
      for (int index = 0; index < values.Count; ++index)
        this.WriteUInt64("UInt64", values[index]);
    }
    this.PopNamespace();
    this.EndField(fieldName);
  }

  public void WriteFloatArray(string fieldName, IList<float> values)
  {
    if (!this.BeginField(fieldName, values == null, true, true))
      return;
    if (this.m_context.MaxArrayLength > 0 && this.m_context.MaxArrayLength < values.Count)
      throw new ServiceResultException(2148007936U /*0x80080000*/);
    this.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    if (values != null)
    {
      for (int index = 0; index < values.Count; ++index)
        this.WriteFloat("Float", values[index]);
    }
    this.PopNamespace();
    this.EndField(fieldName);
  }

  public void WriteDoubleArray(string fieldName, IList<double> values)
  {
    if (!this.BeginField(fieldName, values == null, true, true))
      return;
    if (this.m_context.MaxArrayLength > 0 && this.m_context.MaxArrayLength < values.Count)
      throw new ServiceResultException(2148007936U /*0x80080000*/);
    this.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    if (values != null)
    {
      for (int index = 0; index < values.Count; ++index)
        this.WriteDouble("Double", values[index]);
    }
    this.PopNamespace();
    this.EndField(fieldName);
  }

  public void WriteStringArray(string fieldName, IList<string> values)
  {
    if (!this.BeginField(fieldName, values == null, true, true))
      return;
    if (this.m_context.MaxArrayLength > 0 && this.m_context.MaxArrayLength < values.Count)
      throw new ServiceResultException(2148007936U /*0x80080000*/);
    this.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    if (values != null)
    {
      for (int index = 0; index < values.Count; ++index)
        this.WriteString("String", values[index], true);
    }
    this.PopNamespace();
    this.EndField(fieldName);
  }

  public void WriteDateTimeArray(string fieldName, IList<DateTime> values)
  {
    if (!this.BeginField(fieldName, values == null, true, true))
      return;
    if (this.m_context.MaxArrayLength > 0 && this.m_context.MaxArrayLength < values.Count)
      throw new ServiceResultException(2148007936U /*0x80080000*/);
    this.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    if (values != null)
    {
      for (int index = 0; index < values.Count; ++index)
        this.WriteDateTime("DateTime", values[index]);
    }
    this.PopNamespace();
    this.EndField(fieldName);
  }

  public void WriteGuidArray(string fieldName, IList<Uuid> values)
  {
    if (!this.BeginField(fieldName, values == null, true, true))
      return;
    if (this.m_context.MaxArrayLength > 0 && this.m_context.MaxArrayLength < values.Count)
      throw new ServiceResultException(2148007936U /*0x80080000*/);
    this.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    if (values != null)
    {
      for (int index = 0; index < values.Count; ++index)
        this.WriteGuid("Guid", values[index]);
    }
    this.PopNamespace();
    this.EndField(fieldName);
  }

  public void WriteGuidArray(string fieldName, IList<Guid> values)
  {
    if (!this.BeginField(fieldName, values == null, true, true))
      return;
    if (this.m_context.MaxArrayLength > 0 && this.m_context.MaxArrayLength < values.Count)
      throw new ServiceResultException(2148007936U /*0x80080000*/);
    this.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    if (values != null)
    {
      for (int index = 0; index < values.Count; ++index)
        this.WriteGuid("Guid", values[index]);
    }
    this.PopNamespace();
    this.EndField(fieldName);
  }

  public void WriteByteStringArray(string fieldName, IList<byte[]> values)
  {
    if (!this.BeginField(fieldName, values == null, true, true))
      return;
    if (this.m_context.MaxArrayLength > 0 && this.m_context.MaxArrayLength < values.Count)
      throw new ServiceResultException(2148007936U /*0x80080000*/);
    this.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    if (values != null)
    {
      for (int index = 0; index < values.Count; ++index)
        this.WriteByteString("ByteString", values[index], true);
    }
    this.PopNamespace();
    this.EndField(fieldName);
  }

  public void WriteXmlElementArray(string fieldName, IList<XmlElement> values)
  {
    if (!this.BeginField(fieldName, values == null, true, true))
      return;
    if (this.m_context.MaxArrayLength > 0 && this.m_context.MaxArrayLength < values.Count)
      throw new ServiceResultException(2148007936U /*0x80080000*/);
    this.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    if (values != null)
    {
      for (int index = 0; index < values.Count; ++index)
        this.WriteXmlElement("XmlElement", values[index], true);
    }
    this.PopNamespace();
    this.EndField(fieldName);
  }

  public void WriteNodeIdArray(string fieldName, IList<NodeId> values)
  {
    if (!this.BeginField(fieldName, values == null, true, true))
      return;
    if (this.m_context.MaxArrayLength > 0 && this.m_context.MaxArrayLength < values.Count)
      throw new ServiceResultException(2148007936U /*0x80080000*/);
    this.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    if (values != null)
    {
      for (int index = 0; index < values.Count; ++index)
        this.WriteNodeId("NodeId", values[index]);
    }
    this.PopNamespace();
    this.EndField(fieldName);
  }

  public void WriteExpandedNodeIdArray(string fieldName, IList<ExpandedNodeId> values)
  {
    if (!this.BeginField(fieldName, values == null, true, true))
      return;
    if (this.m_context.MaxArrayLength > 0 && this.m_context.MaxArrayLength < values.Count)
      throw new ServiceResultException(2148007936U /*0x80080000*/);
    this.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    if (values != null)
    {
      for (int index = 0; index < values.Count; ++index)
        this.WriteExpandedNodeId("ExpandedNodeId", values[index]);
    }
    this.PopNamespace();
    this.EndField(fieldName);
  }

  public void WriteStatusCodeArray(string fieldName, IList<StatusCode> values)
  {
    if (!this.BeginField(fieldName, values == null, true, true))
      return;
    if (this.m_context.MaxArrayLength > 0 && this.m_context.MaxArrayLength < values.Count)
      throw new ServiceResultException(2148007936U /*0x80080000*/);
    this.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    if (values != null)
    {
      for (int index = 0; index < values.Count; ++index)
        this.WriteStatusCode("StatusCode", values[index]);
    }
    this.PopNamespace();
    this.EndField(fieldName);
  }

  public void WriteDiagnosticInfoArray(string fieldName, IList<DiagnosticInfo> values)
  {
    if (!this.BeginField(fieldName, values == null, true, true))
      return;
    if (this.m_context.MaxArrayLength > 0 && this.m_context.MaxArrayLength < values.Count)
      throw new ServiceResultException(2148007936U /*0x80080000*/);
    this.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    if (values != null)
    {
      for (int index = 0; index < values.Count; ++index)
        this.WriteDiagnosticInfo("DiagnosticInfo", values[index]);
    }
    this.PopNamespace();
    this.EndField(fieldName);
  }

  public void WriteQualifiedNameArray(string fieldName, IList<QualifiedName> values)
  {
    if (!this.BeginField(fieldName, values == null, true, true))
      return;
    if (this.m_context.MaxArrayLength > 0 && this.m_context.MaxArrayLength < values.Count)
      throw new ServiceResultException(2148007936U /*0x80080000*/);
    this.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    if (values != null)
    {
      for (int index = 0; index < values.Count; ++index)
        this.WriteQualifiedName("QualifiedName", values[index]);
    }
    this.PopNamespace();
    this.EndField(fieldName);
  }

  public void WriteLocalizedTextArray(string fieldName, IList<LocalizedText> values)
  {
    if (!this.BeginField(fieldName, values == null, true, true))
      return;
    if (this.m_context.MaxArrayLength > 0 && this.m_context.MaxArrayLength < values.Count)
      throw new ServiceResultException(2148007936U /*0x80080000*/);
    this.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    if (values != null)
    {
      for (int index = 0; index < values.Count; ++index)
        this.WriteLocalizedText("LocalizedText", values[index]);
    }
    this.PopNamespace();
    this.EndField(fieldName);
  }

  public void WriteVariantArray(string fieldName, IList<Variant> values)
  {
    if (!this.BeginField(fieldName, values == null, true, true))
      return;
    if (this.m_context.MaxArrayLength > 0 && this.m_context.MaxArrayLength < values.Count)
      throw new ServiceResultException(2148007936U /*0x80080000*/);
    this.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    if (values != null)
    {
      for (int index = 0; index < values.Count; ++index)
        this.WriteVariant("Variant", values[index]);
    }
    this.PopNamespace();
    this.EndField(fieldName);
  }

  public void WriteDataValueArray(string fieldName, IList<DataValue> values)
  {
    if (!this.BeginField(fieldName, values == null, true, true))
      return;
    if (this.m_context.MaxArrayLength > 0 && this.m_context.MaxArrayLength < values.Count)
      throw new ServiceResultException(2148007936U /*0x80080000*/);
    this.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    if (values != null)
    {
      for (int index = 0; index < values.Count; ++index)
        this.WriteDataValue("DataValue", values[index]);
    }
    this.PopNamespace();
    this.EndField(fieldName);
  }

  public void WriteExtensionObjectArray(string fieldName, IList<ExtensionObject> values)
  {
    if (!this.BeginField(fieldName, values == null, true, true))
      return;
    if (this.m_context.MaxArrayLength > 0 && this.m_context.MaxArrayLength < values.Count)
      throw new ServiceResultException(2148007936U /*0x80080000*/);
    this.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    if (values != null)
    {
      for (int index = 0; index < values.Count; ++index)
        this.WriteExtensionObject("ExtensionObject", values[index]);
    }
    this.PopNamespace();
    this.EndField(fieldName);
  }

  public void WriteEncodeableArray(string fieldName, IList<IEncodeable> values, Type systemType)
  {
    if (!this.BeginField(fieldName, values == null, true, true))
      return;
    if (this.m_context.MaxArrayLength > 0 && this.m_context.MaxArrayLength < values.Count)
      throw new ServiceResultException(2148007936U /*0x80080000*/);
    XmlQualifiedName xmlQualifiedName = EncodeableFactory.GetXmlName(systemType);
    if (xmlQualifiedName == (XmlQualifiedName) null)
      xmlQualifiedName = new XmlQualifiedName("IEncodeable", "http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.PushNamespace(xmlQualifiedName.Namespace);
    for (int index = 0; index < values.Count; ++index)
    {
      IEncodeable o = values[index];
      if (systemType != (Type) null)
      {
        if (systemType.IsInstanceOfType((object) o))
          this.WriteEncodeable(xmlQualifiedName.Name, o, systemType);
        else
          throw new ServiceResultException(2147876864U /*0x80060000*/, Utils.Format("Objects with type '{0}' are not allowed in the array being serialized.", (object) systemType.FullName));
      }
    }
    this.PopNamespace();
    this.EndField(fieldName);
  }

  public void WriteEnumeratedArray(string fieldName, Array values, Type systemType)
  {
    if (!this.BeginField(fieldName, values == null, true, true))
      return;
    if (this.m_context.MaxArrayLength > 0 && this.m_context.MaxArrayLength < values.Length)
      throw new ServiceResultException(2148007936U /*0x80080000*/);
    XmlQualifiedName xmlQualifiedName = EncodeableFactory.GetXmlName(systemType);
    if (xmlQualifiedName == (XmlQualifiedName) null)
      xmlQualifiedName = new XmlQualifiedName("Enumerated", "http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.PushNamespace(xmlQualifiedName.Namespace);
    if (values != null)
    {
      foreach (Enum @enum in values)
        this.WriteEnumerated(xmlQualifiedName.Name, @enum);
    }
    this.PopNamespace();
    this.EndField(fieldName);
  }

  public void WriteVariantContents(object value, TypeInfo typeInfo)
  {
    if (value == null)
    {
      this.m_writer.WriteStartElement("Null", "http://opcfoundation.org/UA/2008/02/Types.xsd");
      this.m_writer.WriteEndElement();
    }
    else
    {
      try
      {
        this.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
        if (typeInfo.ValueRank < 0)
        {
          switch (typeInfo.BuiltInType)
          {
            case BuiltInType.Boolean:
              this.WriteBoolean("Boolean", (bool) value);
              return;
            case BuiltInType.SByte:
              this.WriteSByte("SByte", (sbyte) value);
              return;
            case BuiltInType.Byte:
              this.WriteByte("Byte", (byte) value);
              return;
            case BuiltInType.Int16:
              this.WriteInt16("Int16", (short) value);
              return;
            case BuiltInType.UInt16:
              this.WriteUInt16("UInt16", (ushort) value);
              return;
            case BuiltInType.Int32:
              this.WriteInt32("Int32", (int) value);
              return;
            case BuiltInType.UInt32:
              this.WriteUInt32("UInt32", (uint) value);
              return;
            case BuiltInType.Int64:
              this.WriteInt64("Int64", (long) value);
              return;
            case BuiltInType.UInt64:
              this.WriteUInt64("UInt64", (ulong) value);
              return;
            case BuiltInType.Float:
              this.WriteFloat("Float", (float) value);
              return;
            case BuiltInType.Double:
              this.WriteDouble("Double", (double) value);
              return;
            case BuiltInType.String:
              this.WriteString("String", (string) value);
              return;
            case BuiltInType.DateTime:
              this.WriteDateTime("DateTime", (DateTime) value);
              return;
            case BuiltInType.Guid:
              this.WriteGuid("Guid", (Uuid) value);
              return;
            case BuiltInType.ByteString:
              this.WriteByteString("ByteString", (byte[]) value);
              return;
            case BuiltInType.XmlElement:
              this.WriteXmlElement("XmlElement", (XmlElement) value);
              return;
            case BuiltInType.NodeId:
              this.WriteNodeId("NodeId", (NodeId) value);
              return;
            case BuiltInType.ExpandedNodeId:
              this.WriteExpandedNodeId("ExpandedNodeId", (ExpandedNodeId) value);
              return;
            case BuiltInType.StatusCode:
              this.WriteStatusCode("StatusCode", (StatusCode) value);
              return;
            case BuiltInType.QualifiedName:
              this.WriteQualifiedName("QualifiedName", (QualifiedName) value);
              return;
            case BuiltInType.LocalizedText:
              this.WriteLocalizedText("LocalizedText", (LocalizedText) value);
              return;
            case BuiltInType.ExtensionObject:
              this.WriteExtensionObject("ExtensionObject", (ExtensionObject) value);
              return;
            case BuiltInType.DataValue:
              this.WriteDataValue("DataValue", (DataValue) value);
              return;
            case BuiltInType.Enumeration:
              this.WriteInt32("Int32", (int) value);
              return;
          }
        }
        else if (typeInfo.ValueRank <= 1)
        {
          switch (typeInfo.BuiltInType)
          {
            case BuiltInType.Boolean:
              this.WriteBooleanArray("ListOfBoolean", (IList<bool>) (bool[]) value);
              return;
            case BuiltInType.SByte:
              this.WriteSByteArray("ListOfSByte", (IList<sbyte>) (sbyte[]) value);
              return;
            case BuiltInType.Byte:
              this.WriteByteArray("ListOfByte", (IList<byte>) (byte[]) value);
              return;
            case BuiltInType.Int16:
              this.WriteInt16Array("ListOfInt16", (IList<short>) (short[]) value);
              return;
            case BuiltInType.UInt16:
              this.WriteUInt16Array("ListOfUInt16", (IList<ushort>) (ushort[]) value);
              return;
            case BuiltInType.Int32:
              this.WriteInt32Array("ListOfInt32", (IList<int>) (int[]) value);
              return;
            case BuiltInType.UInt32:
              this.WriteUInt32Array("ListOfUInt32", (IList<uint>) (uint[]) value);
              return;
            case BuiltInType.Int64:
              this.WriteInt64Array("ListOfInt64", (IList<long>) (long[]) value);
              return;
            case BuiltInType.UInt64:
              this.WriteUInt64Array("ListOfUInt64", (IList<ulong>) (ulong[]) value);
              return;
            case BuiltInType.Float:
              this.WriteFloatArray("ListOfFloat", (IList<float>) (float[]) value);
              return;
            case BuiltInType.Double:
              this.WriteDoubleArray("ListOfDouble", (IList<double>) (double[]) value);
              return;
            case BuiltInType.String:
              this.WriteStringArray("ListOfString", (IList<string>) (string[]) value);
              return;
            case BuiltInType.DateTime:
              this.WriteDateTimeArray("ListOfDateTime", (IList<DateTime>) (DateTime[]) value);
              return;
            case BuiltInType.Guid:
              this.WriteGuidArray("ListOfGuid", (IList<Uuid>) (Uuid[]) value);
              return;
            case BuiltInType.ByteString:
              this.WriteByteStringArray("ListOfByteString", (IList<byte[]>) (byte[][]) value);
              return;
            case BuiltInType.XmlElement:
              this.WriteXmlElementArray("ListOfXmlElement", (IList<XmlElement>) (XmlElement[]) value);
              return;
            case BuiltInType.NodeId:
              this.WriteNodeIdArray("ListOfNodeId", (IList<NodeId>) (NodeId[]) value);
              return;
            case BuiltInType.ExpandedNodeId:
              this.WriteExpandedNodeIdArray("ListOfExpandedNodeId", (IList<ExpandedNodeId>) (ExpandedNodeId[]) value);
              return;
            case BuiltInType.StatusCode:
              this.WriteStatusCodeArray("ListOfStatusCode", (IList<StatusCode>) (StatusCode[]) value);
              return;
            case BuiltInType.QualifiedName:
              this.WriteQualifiedNameArray("ListOfQualifiedName", (IList<QualifiedName>) (QualifiedName[]) value);
              return;
            case BuiltInType.LocalizedText:
              this.WriteLocalizedTextArray("ListOfLocalizedText", (IList<LocalizedText>) (LocalizedText[]) value);
              return;
            case BuiltInType.ExtensionObject:
              this.WriteExtensionObjectArray("ListOfExtensionObject", (IList<ExtensionObject>) (ExtensionObject[]) value);
              return;
            case BuiltInType.DataValue:
              this.WriteDataValueArray("ListOfDataValue", (IList<DataValue>) (DataValue[]) value);
              return;
            case BuiltInType.Variant:
              switch (value)
              {
                case Variant[] values1:
                  this.WriteVariantArray("ListOfVariant", (IList<Variant>) values1);
                  return;
                case object[] values2:
                  this.WriteObjectArray("ListOfVariant", (IList<object>) values2);
                  return;
                default:
                  throw ServiceResultException.Create(2147876864U /*0x80060000*/, "Unexpected type encountered while encoding an array of Variants: {0}", (object) value.GetType());
              }
            case BuiltInType.Enumeration:
              switch (value)
              {
                case int[] values3:
label_62:
                  this.WriteInt32Array("ListOfInt32", (IList<int>) values3);
                  return;
                case Enum[] enumArray:
                  values3 = new int[enumArray.Length];
                  for (int index = 0; index < enumArray.Length; ++index)
                    values3[index] = (int) enumArray[index];
                  goto label_62;
                default:
                  throw new ServiceResultException(2147876864U /*0x80060000*/, Utils.Format("Type '{0}' is not allowed in an Enumeration.", (object) value.GetType().FullName));
              }
          }
        }
        else if (typeInfo.ValueRank > 1)
        {
          this.WriteMatrix("Matrix", (Matrix) value);
          return;
        }
        throw new ServiceResultException(2147876864U /*0x80060000*/, Utils.Format("Type '{0}' is not allowed in an Variant.", (object) value.GetType().FullName));
      }
      finally
      {
        this.PopNamespace();
      }
    }
  }

  public void WriteExtensionObjectBody(object body)
  {
    switch (body)
    {
      case null:
        break;
      case byte[] inArray:
        this.m_writer.WriteStartElement("ByteString", "http://opcfoundation.org/UA/2008/02/Types.xsd");
        this.m_writer.WriteString(Convert.ToBase64String(inArray, Base64FormattingOptions.InsertLineBreaks));
        this.m_writer.WriteEndElement();
        break;
      case XmlElement xmlElement:
        using (XmlReader reader = XmlReader.Create((TextReader) new StringReader(xmlElement.OuterXml), Utils.DefaultXmlReaderSettings()))
        {
          this.m_writer.WriteNode(reader, false);
          break;
        }
      case IEncodeable encodeable:
        XmlQualifiedName xmlName = EncodeableFactory.GetXmlName((object) encodeable, this.Context);
        this.m_writer.WriteStartElement(xmlName.Name, xmlName.Namespace);
        encodeable.Encode((IEncoder) this);
        this.m_writer.WriteEndElement();
        break;
      default:
        throw new ServiceResultException(2147876864U /*0x80060000*/, Utils.Format("Don't know how to encode extension object body with type '{0}'.", (object) body.GetType().FullName));
    }
  }

  public void WriteObjectArray(string fieldName, IList<object> values)
  {
    if (!this.BeginField(fieldName, values == null, true, true))
      return;
    if (values != null && this.m_context.MaxArrayLength > 0 && this.m_context.MaxArrayLength < values.Count)
      throw new ServiceResultException(2148007936U /*0x80080000*/);
    this.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    if (values != null)
    {
      for (int index = 0; index < values.Count; ++index)
        this.WriteVariant("Variant", new Variant(values[index]));
    }
    this.PopNamespace();
    this.EndField(fieldName);
  }

  public void WriteArray(string fieldName, object array, int valueRank, BuiltInType builtInType)
  {
    this.CheckAndIncrementNestingLevel();
    try
    {
      if (valueRank == 1)
      {
        switch (builtInType)
        {
          case BuiltInType.Boolean:
            this.WriteBooleanArray(fieldName, (IList<bool>) (bool[]) array);
            break;
          case BuiltInType.SByte:
            this.WriteSByteArray(fieldName, (IList<sbyte>) (sbyte[]) array);
            break;
          case BuiltInType.Byte:
            this.WriteByteArray(fieldName, (IList<byte>) (byte[]) array);
            break;
          case BuiltInType.Int16:
            this.WriteInt16Array(fieldName, (IList<short>) (short[]) array);
            break;
          case BuiltInType.UInt16:
            this.WriteUInt16Array(fieldName, (IList<ushort>) (ushort[]) array);
            break;
          case BuiltInType.Int32:
            this.WriteInt32Array(fieldName, (IList<int>) (int[]) array);
            break;
          case BuiltInType.UInt32:
            this.WriteUInt32Array(fieldName, (IList<uint>) (uint[]) array);
            break;
          case BuiltInType.Int64:
            this.WriteInt64Array(fieldName, (IList<long>) (long[]) array);
            break;
          case BuiltInType.UInt64:
            this.WriteUInt64Array(fieldName, (IList<ulong>) (ulong[]) array);
            break;
          case BuiltInType.Float:
            this.WriteFloatArray(fieldName, (IList<float>) (float[]) array);
            break;
          case BuiltInType.Double:
            this.WriteDoubleArray(fieldName, (IList<double>) (double[]) array);
            break;
          case BuiltInType.String:
            this.WriteStringArray(fieldName, (IList<string>) (string[]) array);
            break;
          case BuiltInType.DateTime:
            this.WriteDateTimeArray(fieldName, (IList<DateTime>) (DateTime[]) array);
            break;
          case BuiltInType.Guid:
            this.WriteGuidArray(fieldName, (IList<Uuid>) (Uuid[]) array);
            break;
          case BuiltInType.ByteString:
            this.WriteByteStringArray(fieldName, (IList<byte[]>) (byte[][]) array);
            break;
          case BuiltInType.XmlElement:
            this.WriteXmlElementArray(fieldName, (IList<XmlElement>) (XmlElement[]) array);
            break;
          case BuiltInType.NodeId:
            this.WriteNodeIdArray(fieldName, (IList<NodeId>) (NodeId[]) array);
            break;
          case BuiltInType.ExpandedNodeId:
            this.WriteExpandedNodeIdArray(fieldName, (IList<ExpandedNodeId>) (ExpandedNodeId[]) array);
            break;
          case BuiltInType.StatusCode:
            this.WriteStatusCodeArray(fieldName, (IList<StatusCode>) (StatusCode[]) array);
            break;
          case BuiltInType.QualifiedName:
            this.WriteQualifiedNameArray(fieldName, (IList<QualifiedName>) (QualifiedName[]) array);
            break;
          case BuiltInType.LocalizedText:
            this.WriteLocalizedTextArray(fieldName, (IList<LocalizedText>) (LocalizedText[]) array);
            break;
          case BuiltInType.ExtensionObject:
            this.WriteExtensionObjectArray(fieldName, (IList<ExtensionObject>) (ExtensionObject[]) array);
            break;
          case BuiltInType.DataValue:
            this.WriteDataValueArray(fieldName, (IList<DataValue>) (DataValue[]) array);
            break;
          case BuiltInType.Variant:
            switch (array)
            {
              case Variant[] values1:
                this.WriteVariantArray(fieldName, (IList<Variant>) values1);
                return;
              case IEncodeable[] values2:
                this.WriteEncodeableArray(fieldName, (IList<IEncodeable>) values2, array.GetType().GetElementType());
                return;
              case object[] values3:
                this.WriteObjectArray(fieldName, (IList<object>) values3);
                return;
              default:
                throw ServiceResultException.Create(2147876864U /*0x80060000*/, "Unexpected type encountered while encoding an array of Variants: {0}", (object) array.GetType());
            }
          case BuiltInType.DiagnosticInfo:
            this.WriteDiagnosticInfoArray(fieldName, (IList<DiagnosticInfo>) (DiagnosticInfo[]) array);
            break;
          case BuiltInType.Enumeration:
            switch (array)
            {
              case int[] values4:
label_40:
                this.WriteInt32Array(fieldName, (IList<int>) values4);
                return;
              case Enum[] enumArray:
                values4 = new int[enumArray.Length];
                for (int index = 0; index < enumArray.Length; ++index)
                  values4[index] = Convert.ToInt32((object) enumArray[index], (IFormatProvider) CultureInfo.InvariantCulture);
                goto label_40;
              default:
                throw new ServiceResultException(2147876864U /*0x80060000*/, Utils.Format("Type '{0}' is not allowed in an Enumeration.", (object) array.GetType().FullName));
            }
          default:
            if (array is IEncodeable[] values5)
            {
              this.WriteEncodeableArray(fieldName, (IList<IEncodeable>) values5, array.GetType().GetElementType());
              break;
            }
            throw ServiceResultException.Create(2147876864U /*0x80060000*/, "Unexpected BuiltInType encountered while encoding an array: {0}", (object) builtInType);
        }
      }
      else if (valueRank > 1)
      {
        switch (array)
        {
          case Matrix matrix:
label_46:
            if (!this.BeginField(fieldName, matrix == null, true, true))
              return;
            this.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
            if (matrix != null)
            {
              this.WriteInt32Array("Dimensions", (IList<int>) matrix.Dimensions);
              this.WriteArray("Elements", (object) matrix.Elements, 1, builtInType);
            }
            this.PopNamespace();
            this.EndField(fieldName);
            return;
          case Array array1:
            if (array1.Rank == valueRank)
            {
              matrix = new Matrix(array1, builtInType);
              goto label_46;
            }
            break;
        }
        throw ServiceResultException.Create(2147876864U /*0x80060000*/, "Unexpected array type encountered while encoding array: {0}", (object) array.GetType().Name);
      }
    }
    finally
    {
      --this.m_nestingLevel;
    }
  }

  private void WriteMatrix(string fieldName, Matrix value)
  {
    this.CheckAndIncrementNestingLevel();
    if (this.BeginField(fieldName, value == null, true, true))
    {
      this.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
      if (value != null)
      {
        this.m_writer.WriteStartElement("Elements", "http://opcfoundation.org/UA/2008/02/Types.xsd");
        this.WriteVariantContents((object) value.Elements, new TypeInfo(value.TypeInfo.BuiltInType, 1));
        this.m_writer.WriteEndElement();
        this.WriteInt32Array("Dimensions", (IList<int>) value.Dimensions);
      }
      this.PopNamespace();
      this.EndField(fieldName);
    }
    --this.m_nestingLevel;
  }

  private bool BeginField(string fieldName, bool isDefault, bool isNillable, bool isArrayElement = false)
  {
    if (!string.IsNullOrEmpty(fieldName))
    {
      if (isNillable & isDefault && !isArrayElement)
        return false;
      this.m_writer.WriteStartElement(fieldName, this.m_namespaces.Peek());
      if (isDefault)
      {
        if (isNillable)
          this.m_writer.WriteAttributeString("nil", "http://www.w3.org/2001/XMLSchema-instance", "true");
        this.m_writer.WriteEndElement();
        return false;
      }
    }
    return !isDefault;
  }

  private void EndField(string fieldName)
  {
    if (string.IsNullOrEmpty(fieldName))
      return;
    this.m_writer.WriteEndElement();
  }

  private void CheckAndIncrementNestingLevel()
  {
    if (this.m_nestingLevel > this.m_context.MaxEncodingNestingLevels)
      throw ServiceResultException.Create(2148007936U /*0x80080000*/, "Maximum nesting level of {0} was exceeded", (object) this.m_context.MaxEncodingNestingLevels);
    ++this.m_nestingLevel;
  }
}
