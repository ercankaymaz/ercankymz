// Decompiled with JetBrains decompiler
// Type: Opc.Ua.BinaryEncoder
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
public class BinaryEncoder : IEncoder, IDisposable
{
  private Stream m_ostrm;
  private BinaryWriter m_writer;
  private bool m_leaveOpen;
  private IServiceMessageContext m_context;
  private ushort[] m_namespaceMappings;
  private ushort[] m_serverMappings;
  private uint m_nestingLevel;

  public BinaryEncoder(IServiceMessageContext context)
  {
    this.m_ostrm = (Stream) new MemoryStream();
    this.m_writer = new BinaryWriter(this.m_ostrm);
    this.m_context = context;
    this.m_leaveOpen = false;
    this.m_nestingLevel = 0U;
  }

  public BinaryEncoder(byte[] buffer, int start, int count, IServiceMessageContext context)
  {
    if (buffer == null)
      throw new ArgumentNullException(nameof (buffer));
    this.m_ostrm = (Stream) new MemoryStream(buffer, start, count);
    this.m_writer = new BinaryWriter(this.m_ostrm);
    this.m_context = context;
    this.m_leaveOpen = false;
    this.m_nestingLevel = 0U;
  }

  public BinaryEncoder(Stream stream, IServiceMessageContext context, bool leaveOpen)
  {
    this.m_ostrm = stream != null ? stream : throw new ArgumentNullException(nameof (stream));
    this.m_writer = new BinaryWriter(this.m_ostrm, Encoding.UTF8, leaveOpen);
    this.m_context = context;
    this.m_leaveOpen = leaveOpen;
    this.m_nestingLevel = 0U;
  }

  public void Dispose()
  {
    this.Dispose(true);
    GC.SuppressFinalize((object) this);
  }

  protected virtual void Dispose(bool disposing)
  {
    if (!disposing)
      return;
    if (this.m_writer != null)
    {
      this.m_writer.Flush();
      this.m_writer.Dispose();
      this.m_writer = (BinaryWriter) null;
    }
    if (this.m_leaveOpen)
      return;
    this.m_ostrm?.Dispose();
    this.m_ostrm = (Stream) null;
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

  public byte[] CloseAndReturnBuffer()
  {
    this.Close();
    return this.m_ostrm is MemoryStream ostrm ? ostrm.ToArray() : (byte[]) null;
  }

  public string CloseAndReturnText()
  {
    this.Close();
    return this.m_ostrm is MemoryStream ostrm ? Convert.ToBase64String(ostrm.ToArray()) : (string) null;
  }

  public int Close()
  {
    int position = (int) this.m_writer.BaseStream.Position;
    this.m_writer.Flush();
    this.m_writer.Dispose();
    return position;
  }

  public int Position
  {
    get => (int) this.m_writer.BaseStream.Position;
    set => this.m_writer.Seek(value, SeekOrigin.Begin);
  }

  public void WriteRawBytes(byte[] buffer, int offset, int count)
  {
    this.m_writer.Write(buffer, offset, count);
  }

  public static byte[] EncodeMessage(IEncodeable message, IServiceMessageContext context)
  {
    if (message == null)
      throw new ArgumentNullException(nameof (message));
    if (context == null)
      throw new ArgumentNullException(nameof (context));
    using (BinaryEncoder binaryEncoder = new BinaryEncoder(context))
    {
      binaryEncoder.EncodeMessage(message);
      return binaryEncoder.CloseAndReturnBuffer();
    }
  }

  public static void EncodeSessionLessMessage(
    IEncodeable message,
    Stream stream,
    IServiceMessageContext context,
    bool leaveOpen)
  {
    if (message == null)
      throw new ArgumentNullException(nameof (message));
    if (context == null)
      throw new ArgumentNullException(nameof (context));
    using (BinaryEncoder binaryEncoder = new BinaryEncoder(stream, context, leaveOpen))
    {
      long position = binaryEncoder.m_ostrm.Position;
      binaryEncoder.WriteNodeId((string) null, DataTypeIds.SessionlessInvokeRequestType);
      new SessionLessServiceMessage()
      {
        NamespaceUris = context.NamespaceUris,
        ServerUris = context.ServerUris,
        Message = message
      }.Encode((IEncoder) binaryEncoder);
      if (context.MaxMessageSize > 0 && context.MaxMessageSize < (int) (binaryEncoder.m_ostrm.Position - position))
        throw ServiceResultException.Create(2148007936U /*0x80080000*/, "MaxMessageSize {0} < {1}", (object) context.MaxMessageSize, (object) (int) (binaryEncoder.m_ostrm.Position - position));
    }
  }

  public static void EncodeMessage(
    IEncodeable message,
    Stream stream,
    IServiceMessageContext context,
    bool leaveOpen)
  {
    if (message == null)
      throw new ArgumentNullException(nameof (message));
    if (stream == null)
      throw new ArgumentNullException(nameof (stream));
    if (context == null)
      throw new ArgumentNullException(nameof (context));
    using (BinaryEncoder binaryEncoder = new BinaryEncoder(stream, context, leaveOpen))
      binaryEncoder.EncodeMessage(message);
  }

  public void EncodeMessage(IEncodeable message)
  {
    if (message == null)
      throw new ArgumentNullException(nameof (message));
    long position = this.m_ostrm.Position;
    this.WriteNodeId((string) null, ExpandedNodeId.ToNodeId(message.BinaryEncodingId, this.m_context.NamespaceUris));
    this.WriteEncodeable((string) null, message, message.GetType());
    if (this.m_context.MaxMessageSize > 0 && this.m_context.MaxMessageSize < (int) (this.m_ostrm.Position - position))
      throw ServiceResultException.Create(2148007936U /*0x80080000*/, "MaxMessageSize {0} < {1}", (object) this.m_context.MaxMessageSize, (object) (int) (this.m_ostrm.Position - position));
  }

  public void SaveStringTable(StringTable stringTable)
  {
    if (stringTable != null && stringTable.Count > 1)
    {
      this.WriteInt32((string) null, stringTable.Count - 1);
      for (uint index = 1; (long) index < (long) stringTable.Count; ++index)
        this.WriteString((string) null, stringTable.GetString(index));
    }
    else
      this.WriteInt32((string) null, -1);
  }

  public EncodingType EncodingType => EncodingType.Binary;

  public IServiceMessageContext Context => this.m_context;

  public bool UseReversibleEncoding => true;

  public void PushNamespace(string namespaceUri)
  {
  }

  public void PopNamespace()
  {
  }

  public void WriteBoolean(string fieldName, bool value) => this.m_writer.Write(value);

  public void WriteSByte(string fieldName, sbyte value) => this.m_writer.Write(value);

  public void WriteByte(string fieldName, byte value) => this.m_writer.Write(value);

  public void WriteInt16(string fieldName, short value) => this.m_writer.Write(value);

  public void WriteUInt16(string fieldName, ushort value) => this.m_writer.Write(value);

  public void WriteInt32(string fieldName, int value) => this.m_writer.Write(value);

  public void WriteUInt32(string fieldName, uint value) => this.m_writer.Write(value);

  public void WriteInt64(string fieldName, long value) => this.m_writer.Write(value);

  public void WriteUInt64(string fieldName, ulong value) => this.m_writer.Write(value);

  public void WriteFloat(string fieldName, float value) => this.m_writer.Write(value);

  public void WriteDouble(string fieldName, double value) => this.m_writer.Write(value);

  public void WriteString(string fieldName, string value)
  {
    if (value == null)
    {
      this.WriteInt32((string) null, -1);
    }
    else
    {
      byte[] bytes = Encoding.UTF8.GetBytes(value);
      if (this.m_context.MaxStringLength > 0 && this.m_context.MaxStringLength < bytes.Length)
        throw ServiceResultException.Create(2148007936U /*0x80080000*/, "MaxStringLength {0} < {1}", (object) this.m_context.MaxStringLength, (object) bytes.Length);
      this.WriteByteString((string) null, Encoding.UTF8.GetBytes(value));
    }
  }

  public void WriteDateTime(string fieldName, DateTime value)
  {
    value = Utils.ToOpcUaUniversalTime(value);
    long ticks = value.Ticks;
    long num;
    if (ticks >= DateTime.MaxValue.Ticks)
    {
      num = long.MaxValue;
    }
    else
    {
      num = ticks - Utils.TimeBase.Ticks;
      if (num <= 0L)
        num = 0L;
    }
    this.m_writer.Write(num);
  }

  public void WriteGuid(string fieldName, Uuid value)
  {
    this.m_writer.Write(((Guid) value).ToByteArray());
  }

  public void WriteGuid(string fieldName, Guid value) => this.m_writer.Write(value.ToByteArray());

  public void WriteByteString(string fieldName, byte[] value)
  {
    if (value == null)
    {
      this.WriteInt32((string) null, -1);
    }
    else
    {
      if (this.m_context.MaxByteStringLength > 0 && this.m_context.MaxByteStringLength < value.Length)
        throw ServiceResultException.Create(2148007936U /*0x80080000*/, "MaxByteStringLength {0} < {1}", (object) this.m_context.MaxByteStringLength, (object) value.Length);
      this.WriteInt32((string) null, value.Length);
      this.m_writer.Write(value);
    }
  }

  public void WriteXmlElement(string fieldName, XmlElement value)
  {
    if (value == null)
      this.WriteInt32((string) null, -1);
    else
      this.WriteByteString((string) null, Encoding.UTF8.GetBytes(value.OuterXml));
  }

  public void WriteNodeId(string fieldName, NodeId value)
  {
    if (value == (object) null)
    {
      this.WriteUInt16((string) null, (ushort) 0);
    }
    else
    {
      ushort namespaceIndex = value.NamespaceIndex;
      if (this.m_namespaceMappings != null && this.m_namespaceMappings.Length > (int) namespaceIndex)
        namespaceIndex = this.m_namespaceMappings[(int) namespaceIndex];
      byte nodeIdEncoding = BinaryEncoder.GetNodeIdEncoding(value.IdType, value.Identifier, (uint) namespaceIndex);
      this.WriteByte((string) null, nodeIdEncoding);
      this.WriteNodeIdBody(nodeIdEncoding, value.Identifier, namespaceIndex);
    }
  }

  public void WriteExpandedNodeId(string fieldName, ExpandedNodeId value)
  {
    if (value == (object) null)
    {
      this.WriteUInt16((string) null, (ushort) 0);
    }
    else
    {
      ushort namespaceIndex = value.NamespaceIndex;
      if (this.m_namespaceMappings != null && this.m_namespaceMappings.Length > (int) namespaceIndex)
        namespaceIndex = this.m_namespaceMappings[(int) namespaceIndex];
      uint index = value.ServerIndex;
      if (this.m_serverMappings != null && (long) this.m_serverMappings.Length > (long) index)
        index = (uint) this.m_serverMappings[(int) index];
      byte nodeIdEncoding = BinaryEncoder.GetNodeIdEncoding(value.IdType, value.Identifier, (uint) namespaceIndex);
      if (!string.IsNullOrEmpty(value.NamespaceUri))
        nodeIdEncoding |= (byte) 128 /*0x80*/;
      if (index > 0U)
        nodeIdEncoding |= (byte) 64 /*0x40*/;
      this.WriteByte((string) null, nodeIdEncoding);
      this.WriteNodeIdBody(nodeIdEncoding, value.Identifier, namespaceIndex);
      if (((int) nodeIdEncoding & 128 /*0x80*/) != 0)
        this.WriteString((string) null, value.NamespaceUri);
      if (((int) nodeIdEncoding & 64 /*0x40*/) == 0)
        return;
      this.WriteUInt32((string) null, index);
    }
  }

  public void WriteStatusCode(string fieldName, StatusCode value)
  {
    this.WriteUInt32((string) null, value.Code);
  }

  public void WriteDiagnosticInfo(string fieldName, DiagnosticInfo value)
  {
    this.WriteDiagnosticInfo(fieldName, value, 0);
  }

  public void WriteQualifiedName(string fieldName, QualifiedName value)
  {
    if (value == (QualifiedName) null)
      value = new QualifiedName();
    ushort index = value.NamespaceIndex;
    if (this.m_namespaceMappings != null && this.m_namespaceMappings.Length > (int) index)
      index = this.m_namespaceMappings[(int) index];
    this.WriteUInt16((string) null, index);
    this.WriteString((string) null, value.Name);
  }

  public void WriteLocalizedText(string fieldName, LocalizedText value)
  {
    if (value == (LocalizedText) null)
    {
      this.WriteByte((string) null, (byte) 0);
    }
    else
    {
      byte num = 0;
      if (value.Locale != null)
        num |= (byte) 1;
      if (value.Text != null)
        num |= (byte) 2;
      this.WriteByte((string) null, num);
      if (((int) num & 1) != 0)
        this.WriteString((string) null, value.Locale);
      if (((int) num & 2) == 0)
        return;
      this.WriteString((string) null, value.Text);
    }
  }

  public void WriteVariant(string fieldName, Variant value)
  {
    this.CheckAndIncrementNestingLevel();
    try
    {
      this.WriteVariantValue(fieldName, value);
    }
    finally
    {
      --this.m_nestingLevel;
    }
  }

  public void WriteDataValue(string fieldName, DataValue value)
  {
    if (value == null)
    {
      this.WriteByte((string) null, (byte) 0);
    }
    else
    {
      byte num = 0;
      if (value.Value != null)
        num |= (byte) 1;
      if (value.StatusCode != 0U)
        num |= (byte) 2;
      if (value.SourceTimestamp != DateTime.MinValue)
        num |= (byte) 4;
      if (value.SourcePicoseconds != (ushort) 0)
        num |= (byte) 16 /*0x10*/;
      if (value.ServerTimestamp != DateTime.MinValue)
        num |= (byte) 8;
      if (value.ServerPicoseconds != (ushort) 0)
        num |= (byte) 32 /*0x20*/;
      this.WriteByte((string) null, num);
      if (((int) num & 1) != 0)
        this.WriteVariant((string) null, value.WrappedValue);
      if (((int) num & 2) != 0)
        this.WriteStatusCode((string) null, value.StatusCode);
      if (((int) num & 4) != 0)
        this.WriteDateTime((string) null, value.SourceTimestamp);
      if (((int) num & 16 /*0x10*/) != 0)
        this.WriteUInt16((string) null, value.SourcePicoseconds);
      if (((int) num & 8) != 0)
        this.WriteDateTime((string) null, value.ServerTimestamp);
      if (((int) num & 32 /*0x20*/) == 0)
        return;
      this.WriteUInt16((string) null, value.ServerPicoseconds);
    }
  }

  public void WriteExtensionObject(string fieldName, ExtensionObject value)
  {
    if (value == null)
    {
      this.WriteNodeId((string) null, NodeId.Null);
      this.WriteByte((string) null, Convert.ToByte((object) ExtensionObjectEncoding.None, (IFormatProvider) CultureInfo.InvariantCulture));
    }
    else
    {
      IEncodeable body1 = value.Body as IEncodeable;
      ExpandedNodeId nodeId1 = value.TypeId;
      if (body1 != null)
        nodeId1 = value.Encoding != ExtensionObjectEncoding.Xml ? body1.BinaryEncodingId : body1.XmlEncodingId;
      NodeId nodeId2 = ExpandedNodeId.ToNodeId(nodeId1, this.m_context.NamespaceUris);
      if (NodeId.IsNull(nodeId2) && !NodeId.IsNull(nodeId1))
      {
        if (body1 != null)
          throw ServiceResultException.Create(2147876864U /*0x80060000*/, "Cannot encode bodies of type '{0}' in ExtensionObject unless the NamespaceUri ({1}) is in the encoder's NamespaceTable.", (object) body1.GetType().FullName, (object) nodeId1.NamespaceUri);
        nodeId2 = NodeId.Null;
      }
      this.WriteNodeId((string) null, nodeId2);
      byte num1 = Convert.ToByte((object) value.Encoding, (IFormatProvider) CultureInfo.InvariantCulture);
      if (value.Encoding == ExtensionObjectEncoding.EncodeableObject)
        num1 = Convert.ToByte((object) ExtensionObjectEncoding.Binary, (IFormatProvider) CultureInfo.InvariantCulture);
      object body2 = value.Body;
      if (body2 == null)
        num1 = Convert.ToByte((object) ExtensionObjectEncoding.None, (IFormatProvider) CultureInfo.InvariantCulture);
      this.WriteByte((string) null, num1);
      if (body2 == null)
        return;
      if (body2 is byte[] numArray)
        this.WriteByteString((string) null, numArray);
      else if (body2 is XmlElement xmlElement)
      {
        this.WriteXmlElement((string) null, xmlElement);
      }
      else
      {
        if (body1 == null)
          throw new ServiceResultException(2147876864U /*0x80060000*/, Utils.Format("Cannot encode bodies of type '{0}' in extension objects.", (object) body2.GetType().FullName));
        if (this.m_writer.BaseStream.CanSeek)
        {
          long position = this.m_writer.BaseStream.Position;
          this.WriteInt32((string) null, -1);
          body1.Encode((IEncoder) this);
          long num2 = this.m_writer.BaseStream.Position - position;
          this.m_writer.Seek((int) -num2, SeekOrigin.Current);
          this.WriteInt32((string) null, (int) (num2 - 4L));
          this.m_writer.Seek((int) (num2 - 4L), SeekOrigin.Current);
        }
        else
        {
          using (BinaryEncoder binaryEncoder = new BinaryEncoder(this.m_context))
          {
            binaryEncoder.WriteEncodeable((string) null, body1, (Type) null);
            this.WriteByteString((string) null, binaryEncoder.CloseAndReturnBuffer());
          }
        }
      }
    }
  }

  public void WriteEncodeable(string fieldName, IEncodeable value, Type systemType)
  {
    this.CheckAndIncrementNestingLevel();
    try
    {
      if (value == null)
        value = !(systemType == (Type) null) ? Activator.CreateInstance(systemType) as IEncodeable : throw new ArgumentNullException(nameof (systemType));
      value?.Encode((IEncoder) this);
    }
    finally
    {
      --this.m_nestingLevel;
    }
  }

  public void WriteEnumerated(string fieldName, Enum value)
  {
    if (value == null)
      throw new ArgumentNullException(nameof (value));
    this.WriteInt32((string) null, Convert.ToInt32((object) value, (IFormatProvider) CultureInfo.InvariantCulture));
  }

  public void WriteBooleanArray(string fieldName, IList<bool> values)
  {
    if (this.WriteArrayLength<bool>((ICollection<bool>) values))
      return;
    for (int index = 0; index < values.Count; ++index)
      this.WriteBoolean((string) null, values[index]);
  }

  public void WriteSByteArray(string fieldName, IList<sbyte> values)
  {
    if (this.WriteArrayLength<sbyte>((ICollection<sbyte>) values))
      return;
    for (int index = 0; index < values.Count; ++index)
      this.WriteSByte((string) null, values[index]);
  }

  public void WriteByteArray(string fieldName, IList<byte> values)
  {
    if (this.WriteArrayLength<byte>((ICollection<byte>) values))
      return;
    for (int index = 0; index < values.Count; ++index)
      this.WriteByte((string) null, values[index]);
  }

  public void WriteInt16Array(string fieldName, IList<short> values)
  {
    if (this.WriteArrayLength<short>((ICollection<short>) values))
      return;
    for (int index = 0; index < values.Count; ++index)
      this.WriteInt16((string) null, values[index]);
  }

  public void WriteUInt16Array(string fieldName, IList<ushort> values)
  {
    if (this.WriteArrayLength<ushort>((ICollection<ushort>) values))
      return;
    for (int index = 0; index < values.Count; ++index)
      this.WriteUInt16((string) null, values[index]);
  }

  public void WriteInt32Array(string fieldName, IList<int> values)
  {
    if (this.WriteArrayLength<int>((ICollection<int>) values))
      return;
    for (int index = 0; index < values.Count; ++index)
      this.WriteInt32((string) null, values[index]);
  }

  public void WriteUInt32Array(string fieldName, IList<uint> values)
  {
    if (this.WriteArrayLength<uint>((ICollection<uint>) values))
      return;
    for (int index = 0; index < values.Count; ++index)
      this.WriteUInt32((string) null, values[index]);
  }

  public void WriteInt64Array(string fieldName, IList<long> values)
  {
    if (this.WriteArrayLength<long>((ICollection<long>) values))
      return;
    for (int index = 0; index < values.Count; ++index)
      this.WriteInt64((string) null, values[index]);
  }

  public void WriteUInt64Array(string fieldName, IList<ulong> values)
  {
    if (this.WriteArrayLength<ulong>((ICollection<ulong>) values))
      return;
    for (int index = 0; index < values.Count; ++index)
      this.WriteUInt64((string) null, values[index]);
  }

  public void WriteFloatArray(string fieldName, IList<float> values)
  {
    if (this.WriteArrayLength<float>((ICollection<float>) values))
      return;
    for (int index = 0; index < values.Count; ++index)
      this.WriteFloat((string) null, values[index]);
  }

  public void WriteDoubleArray(string fieldName, IList<double> values)
  {
    if (this.WriteArrayLength<double>((ICollection<double>) values))
      return;
    for (int index = 0; index < values.Count; ++index)
      this.WriteDouble((string) null, values[index]);
  }

  public void WriteStringArray(string fieldName, IList<string> values)
  {
    if (this.WriteArrayLength<string>((ICollection<string>) values))
      return;
    for (int index = 0; index < values.Count; ++index)
      this.WriteString((string) null, values[index]);
  }

  public void WriteDateTimeArray(string fieldName, IList<DateTime> values)
  {
    if (this.WriteArrayLength<DateTime>((ICollection<DateTime>) values))
      return;
    for (int index = 0; index < values.Count; ++index)
      this.WriteDateTime((string) null, values[index]);
  }

  public void WriteGuidArray(string fieldName, IList<Uuid> values)
  {
    if (this.WriteArrayLength<Uuid>((ICollection<Uuid>) values))
      return;
    for (int index = 0; index < values.Count; ++index)
      this.WriteGuid((string) null, values[index]);
  }

  public void WriteGuidArray(string fieldName, IList<Guid> values)
  {
    if (this.WriteArrayLength<Guid>((ICollection<Guid>) values))
      return;
    for (int index = 0; index < values.Count; ++index)
      this.WriteGuid((string) null, values[index]);
  }

  public void WriteByteStringArray(string fieldName, IList<byte[]> values)
  {
    if (this.WriteArrayLength<byte[]>((ICollection<byte[]>) values))
      return;
    for (int index = 0; index < values.Count; ++index)
      this.WriteByteString((string) null, values[index]);
  }

  public void WriteXmlElementArray(string fieldName, IList<XmlElement> values)
  {
    if (this.WriteArrayLength<XmlElement>((ICollection<XmlElement>) values))
      return;
    for (int index = 0; index < values.Count; ++index)
      this.WriteXmlElement((string) null, values[index]);
  }

  public void WriteNodeIdArray(string fieldName, IList<NodeId> values)
  {
    if (this.WriteArrayLength<NodeId>((ICollection<NodeId>) values))
      return;
    for (int index = 0; index < values.Count; ++index)
      this.WriteNodeId((string) null, values[index]);
  }

  public void WriteExpandedNodeIdArray(string fieldName, IList<ExpandedNodeId> values)
  {
    if (this.WriteArrayLength<ExpandedNodeId>((ICollection<ExpandedNodeId>) values))
      return;
    for (int index = 0; index < values.Count; ++index)
      this.WriteExpandedNodeId((string) null, values[index]);
  }

  public void WriteStatusCodeArray(string fieldName, IList<StatusCode> values)
  {
    if (this.WriteArrayLength<StatusCode>((ICollection<StatusCode>) values))
      return;
    for (int index = 0; index < values.Count; ++index)
      this.WriteStatusCode((string) null, values[index]);
  }

  public void WriteDiagnosticInfoArray(string fieldName, IList<DiagnosticInfo> values)
  {
    if (this.WriteArrayLength<DiagnosticInfo>((ICollection<DiagnosticInfo>) values))
      return;
    for (int index = 0; index < values.Count; ++index)
      this.WriteDiagnosticInfo((string) null, values[index]);
  }

  public void WriteQualifiedNameArray(string fieldName, IList<QualifiedName> values)
  {
    if (this.WriteArrayLength<QualifiedName>((ICollection<QualifiedName>) values))
      return;
    for (int index = 0; index < values.Count; ++index)
      this.WriteQualifiedName((string) null, values[index]);
  }

  public void WriteLocalizedTextArray(string fieldName, IList<LocalizedText> values)
  {
    if (this.WriteArrayLength<LocalizedText>((ICollection<LocalizedText>) values))
      return;
    for (int index = 0; index < values.Count; ++index)
      this.WriteLocalizedText((string) null, values[index]);
  }

  public void WriteVariantArray(string fieldName, IList<Variant> values)
  {
    if (this.WriteArrayLength<Variant>((ICollection<Variant>) values))
      return;
    for (int index = 0; index < values.Count; ++index)
      this.WriteVariant((string) null, values[index]);
  }

  public void WriteDataValueArray(string fieldName, IList<DataValue> values)
  {
    if (this.WriteArrayLength<DataValue>((ICollection<DataValue>) values))
      return;
    for (int index = 0; index < values.Count; ++index)
      this.WriteDataValue((string) null, values[index]);
  }

  public void WriteExtensionObjectArray(string fieldName, IList<ExtensionObject> values)
  {
    if (this.WriteArrayLength<ExtensionObject>((ICollection<ExtensionObject>) values))
      return;
    for (int index = 0; index < values.Count; ++index)
      this.WriteExtensionObject((string) null, values[index]);
  }

  public void WriteEncodeableArray(string fieldName, IList<IEncodeable> values, Type systemType)
  {
    if (this.WriteArrayLength((Array) values))
      return;
    for (int index = 0; index < values.Count; ++index)
      this.WriteEncodeable((string) null, values[index], systemType);
  }

  public void WriteEnumeratedArray(string fieldName, Array values, Type systemType)
  {
    if (this.WriteArrayLength(values))
      return;
    for (int index = 0; index < values.Length; ++index)
      this.WriteEnumerated((string) null, (Enum) values.GetValue(index));
  }

  public void WriteArray(string fieldName, object array, int valueRank, BuiltInType builtInType)
  {
    if (valueRank == 1)
    {
      switch (builtInType)
      {
        case BuiltInType.Boolean:
          this.WriteBooleanArray((string) null, (IList<bool>) (bool[]) array);
          break;
        case BuiltInType.SByte:
          this.WriteSByteArray((string) null, (IList<sbyte>) (sbyte[]) array);
          break;
        case BuiltInType.Byte:
          this.WriteByteArray((string) null, (IList<byte>) (byte[]) array);
          break;
        case BuiltInType.Int16:
          this.WriteInt16Array((string) null, (IList<short>) (short[]) array);
          break;
        case BuiltInType.UInt16:
          this.WriteUInt16Array((string) null, (IList<ushort>) (ushort[]) array);
          break;
        case BuiltInType.Int32:
          this.WriteInt32Array((string) null, (IList<int>) (int[]) array);
          break;
        case BuiltInType.UInt32:
          this.WriteUInt32Array((string) null, (IList<uint>) (uint[]) array);
          break;
        case BuiltInType.Int64:
          this.WriteInt64Array((string) null, (IList<long>) (long[]) array);
          break;
        case BuiltInType.UInt64:
          this.WriteUInt64Array((string) null, (IList<ulong>) (ulong[]) array);
          break;
        case BuiltInType.Float:
          this.WriteFloatArray((string) null, (IList<float>) (float[]) array);
          break;
        case BuiltInType.Double:
          this.WriteDoubleArray((string) null, (IList<double>) (double[]) array);
          break;
        case BuiltInType.String:
          this.WriteStringArray((string) null, (IList<string>) (string[]) array);
          break;
        case BuiltInType.DateTime:
          this.WriteDateTimeArray((string) null, (IList<DateTime>) (DateTime[]) array);
          break;
        case BuiltInType.Guid:
          this.WriteGuidArray((string) null, (IList<Uuid>) (Uuid[]) array);
          break;
        case BuiltInType.ByteString:
          this.WriteByteStringArray((string) null, (IList<byte[]>) (byte[][]) array);
          break;
        case BuiltInType.XmlElement:
          this.WriteXmlElementArray((string) null, (IList<XmlElement>) (XmlElement[]) array);
          break;
        case BuiltInType.NodeId:
          this.WriteNodeIdArray((string) null, (IList<NodeId>) (NodeId[]) array);
          break;
        case BuiltInType.ExpandedNodeId:
          this.WriteExpandedNodeIdArray((string) null, (IList<ExpandedNodeId>) (ExpandedNodeId[]) array);
          break;
        case BuiltInType.StatusCode:
          this.WriteStatusCodeArray((string) null, (IList<StatusCode>) (StatusCode[]) array);
          break;
        case BuiltInType.QualifiedName:
          this.WriteQualifiedNameArray((string) null, (IList<QualifiedName>) (QualifiedName[]) array);
          break;
        case BuiltInType.LocalizedText:
          this.WriteLocalizedTextArray((string) null, (IList<LocalizedText>) (LocalizedText[]) array);
          break;
        case BuiltInType.ExtensionObject:
          this.WriteExtensionObjectArray((string) null, (IList<ExtensionObject>) (ExtensionObject[]) array);
          break;
        case BuiltInType.DataValue:
          this.WriteDataValueArray((string) null, (IList<DataValue>) (DataValue[]) array);
          break;
        case BuiltInType.Variant:
          if (array is IEncodeable[] values1)
          {
            this.WriteEncodeableArray(fieldName, (IList<IEncodeable>) values1, array.GetType().GetElementType());
            break;
          }
          this.WriteVariantArray((string) null, (IList<Variant>) (Variant[]) array);
          break;
        case BuiltInType.DiagnosticInfo:
          this.WriteDiagnosticInfoArray((string) null, (IList<DiagnosticInfo>) (DiagnosticInfo[]) array);
          break;
        case BuiltInType.Enumeration:
          if (!(array is int[] values2) && array is Enum[] enumArray)
          {
            values2 = new int[enumArray.Length];
            for (int index = 0; index < enumArray.Length; ++index)
              values2[index] = Convert.ToInt32((object) enumArray[index], (IFormatProvider) CultureInfo.InvariantCulture);
          }
          if (values2 == null)
            throw ServiceResultException.Create(2147876864U /*0x80060000*/, "Unexpected type encountered while encoding an Enumeration Array.");
          this.WriteInt32Array((string) null, (IList<int>) values2);
          break;
        default:
          if (array is IEncodeable[] values3)
          {
            this.WriteEncodeableArray(fieldName, (IList<IEncodeable>) values3, array.GetType().GetElementType());
            break;
          }
          if (array == null)
          {
            this.WriteInt32((string) null, -1);
            break;
          }
          throw ServiceResultException.Create(2147876864U /*0x80060000*/, "Unexpected type encountered while encoding an Array with BuiltInType: {0}", (object) builtInType);
      }
    }
    else
    {
      if (valueRank <= 1)
        return;
      switch (array)
      {
        case Matrix matrix:
label_46:
          this.WriteInt32Array((string) null, (IList<int>) matrix.Dimensions);
          switch (matrix.TypeInfo.BuiltInType)
          {
            case BuiltInType.Boolean:
              foreach (bool element in (bool[]) matrix.Elements)
                this.WriteBoolean((string) null, element);
              return;
            case BuiltInType.SByte:
              foreach (sbyte element in (sbyte[]) matrix.Elements)
                this.WriteSByte((string) null, element);
              return;
            case BuiltInType.Byte:
              foreach (byte element in (byte[]) matrix.Elements)
                this.WriteByte((string) null, element);
              return;
            case BuiltInType.Int16:
              foreach (short element in (short[]) matrix.Elements)
                this.WriteInt16((string) null, element);
              return;
            case BuiltInType.UInt16:
              foreach (ushort element in (ushort[]) matrix.Elements)
                this.WriteUInt16((string) null, element);
              return;
            case BuiltInType.Int32:
              foreach (int element in (int[]) matrix.Elements)
                this.WriteInt32((string) null, element);
              return;
            case BuiltInType.UInt32:
              foreach (uint element in (uint[]) matrix.Elements)
                this.WriteUInt32((string) null, element);
              return;
            case BuiltInType.Int64:
              foreach (long element in (long[]) matrix.Elements)
                this.WriteInt64((string) null, element);
              return;
            case BuiltInType.UInt64:
              foreach (ulong element in (ulong[]) matrix.Elements)
                this.WriteUInt64((string) null, element);
              return;
            case BuiltInType.Float:
              foreach (float element in (float[]) matrix.Elements)
                this.WriteFloat((string) null, element);
              return;
            case BuiltInType.Double:
              foreach (double element in (double[]) matrix.Elements)
                this.WriteDouble((string) null, element);
              return;
            case BuiltInType.String:
              foreach (string element in (string[]) matrix.Elements)
                this.WriteString((string) null, element);
              return;
            case BuiltInType.DateTime:
              foreach (DateTime element in (DateTime[]) matrix.Elements)
                this.WriteDateTime((string) null, element);
              return;
            case BuiltInType.Guid:
              foreach (Uuid element in (Uuid[]) matrix.Elements)
                this.WriteGuid((string) null, element);
              return;
            case BuiltInType.ByteString:
              foreach (byte[] element in (byte[][]) matrix.Elements)
                this.WriteByteString((string) null, element);
              return;
            case BuiltInType.XmlElement:
              foreach (XmlElement element in (XmlElement[]) matrix.Elements)
                this.WriteXmlElement((string) null, element);
              return;
            case BuiltInType.NodeId:
              foreach (NodeId element in (NodeId[]) matrix.Elements)
                this.WriteNodeId((string) null, element);
              return;
            case BuiltInType.ExpandedNodeId:
              foreach (ExpandedNodeId element in (ExpandedNodeId[]) matrix.Elements)
                this.WriteExpandedNodeId((string) null, element);
              return;
            case BuiltInType.StatusCode:
              foreach (StatusCode element in (StatusCode[]) matrix.Elements)
                this.WriteStatusCode((string) null, element);
              return;
            case BuiltInType.QualifiedName:
              foreach (QualifiedName element in (QualifiedName[]) matrix.Elements)
                this.WriteQualifiedName((string) null, element);
              return;
            case BuiltInType.LocalizedText:
              foreach (LocalizedText element in (LocalizedText[]) matrix.Elements)
                this.WriteLocalizedText((string) null, element);
              return;
            case BuiltInType.ExtensionObject:
              foreach (ExtensionObject element in (ExtensionObject[]) matrix.Elements)
                this.WriteExtensionObject((string) null, element);
              return;
            case BuiltInType.DataValue:
              foreach (DataValue element in (DataValue[]) matrix.Elements)
                this.WriteDataValue((string) null, element);
              return;
            case BuiltInType.Variant:
              if (matrix.Elements is Variant[] elements1)
              {
                for (int index = 0; index < elements1.Length; ++index)
                  this.WriteVariant((string) null, elements1[index]);
                return;
              }
              if (matrix.Elements is IEncodeable[] elements2)
              {
                for (int index = 0; index < elements2.Length; ++index)
                  this.WriteEncodeable((string) null, elements2[index], (Type) null);
                return;
              }
              if (!(matrix.Elements is object[] elements3))
                throw ServiceResultException.Create(2147876864U /*0x80060000*/, "Unexpected type encountered while encoding a Matrix.");
              for (int index = 0; index < elements3.Length; ++index)
                this.WriteVariant((string) null, new Variant(elements3[index]));
              return;
            case BuiltInType.DiagnosticInfo:
              foreach (DiagnosticInfo element in (DiagnosticInfo[]) matrix.Elements)
                this.WriteDiagnosticInfo((string) null, element);
              return;
            case BuiltInType.Enumeration:
              if (matrix.Elements is Enum[] elements4)
              {
                for (int index = 0; index < elements4.Length; ++index)
                  this.WriteEnumerated((string) null, elements4[index]);
                return;
              }
              goto case BuiltInType.Int32;
            default:
              if (matrix.Elements is IEncodeable[] elements5)
              {
                for (int index = 0; index < elements5.Length; ++index)
                  this.WriteEncodeable((string) null, elements5[index], (Type) null);
                return;
              }
              throw ServiceResultException.Create(2147876864U /*0x80060000*/, "Unexpected type encountered while encoding a Matrix with BuiltInType: {0}", (object) matrix.TypeInfo.BuiltInType);
          }
        case Array array1:
          if (array1.Rank == valueRank)
          {
            matrix = new Matrix(array1, builtInType);
            goto label_46;
          }
          break;
      }
      this.WriteInt32((string) null, -1);
    }
  }

  private void WriteDiagnosticInfo(string fieldName, DiagnosticInfo value, int depth)
  {
    if (value == null)
    {
      this.WriteByte((string) null, (byte) 0);
    }
    else
    {
      this.CheckAndIncrementNestingLevel();
      try
      {
        byte num = 0;
        if (value.SymbolicId >= 0)
          num |= (byte) 1;
        if (value.NamespaceUri >= 0)
          num |= (byte) 2;
        if (value.Locale >= 0)
          num |= (byte) 8;
        if (value.LocalizedText >= 0)
          num |= (byte) 4;
        if (value.AdditionalInfo != null)
          num |= (byte) 16 /*0x10*/;
        if (value.InnerStatusCode != 0U)
          num |= (byte) 32 /*0x20*/;
        if (value.InnerDiagnosticInfo != null)
        {
          if (depth < DiagnosticInfo.MaxInnerDepth)
            num |= (byte) 64 /*0x40*/;
          else
            Utils.LogWarning("InnerDiagnosticInfo dropped because nesting exceeds maximum of {0}.", (object) DiagnosticInfo.MaxInnerDepth);
        }
        this.WriteByte((string) null, num);
        if (((int) num & 1) != 0)
          this.WriteInt32((string) null, value.SymbolicId);
        if (((int) num & 2) != 0)
          this.WriteInt32((string) null, value.NamespaceUri);
        if (((int) num & 8) != 0)
          this.WriteInt32((string) null, value.Locale);
        if (((int) num & 4) != 0)
          this.WriteInt32((string) null, value.LocalizedText);
        if (((int) num & 16 /*0x10*/) != 0)
          this.WriteString((string) null, value.AdditionalInfo);
        if (((int) num & 32 /*0x20*/) != 0)
          this.WriteStatusCode((string) null, value.InnerStatusCode);
        if (((int) num & 64 /*0x40*/) == 0)
          return;
        this.WriteDiagnosticInfo((string) null, value.InnerDiagnosticInfo, depth + 1);
      }
      finally
      {
        --this.m_nestingLevel;
      }
    }
  }

  private void WriteObjectArray(string fieldName, IList<object> values)
  {
    if (this.WriteArrayLength<object>((ICollection<object>) values))
      return;
    for (int index = 0; index < values.Count; ++index)
      this.WriteVariant((string) null, new Variant(values[index]));
  }

  private bool WriteArrayLength<T>(ICollection<T> values)
  {
    if (values == null)
    {
      this.WriteInt32((string) null, -1);
      return true;
    }
    if (this.m_context.MaxArrayLength > 0 && this.m_context.MaxArrayLength < values.Count)
      throw ServiceResultException.Create(2148007936U /*0x80080000*/, "MaxArrayLength {0} < {1}", (object) this.m_context.MaxArrayLength, (object) values.Count);
    this.WriteInt32((string) null, values.Count);
    return values.Count == 0;
  }

  private bool WriteArrayLength(Array values)
  {
    if (values == null)
    {
      this.WriteInt32((string) null, -1);
      return true;
    }
    if (this.m_context.MaxArrayLength > 0 && this.m_context.MaxArrayLength < values.Length)
      throw ServiceResultException.Create(2148007936U /*0x80080000*/, "MaxArrayLength {0} < {1}", (object) this.m_context.MaxArrayLength, (object) values.Length);
    this.WriteInt32((string) null, values.Length);
    return values.Length == 0;
  }

  private static byte GetNodeIdEncoding(IdType idType, object identifier, uint namespaceIndex)
  {
    NodeIdEncodingBits nodeIdEncodingBits;
    switch (idType)
    {
      case IdType.Numeric:
        uint uint32 = Convert.ToUInt32(identifier, (IFormatProvider) CultureInfo.InvariantCulture);
        nodeIdEncodingBits = uint32 > (uint) byte.MaxValue || namespaceIndex != 0U ? (uint32 > (uint) ushort.MaxValue || namespaceIndex > (uint) byte.MaxValue ? NodeIdEncodingBits.Numeric : NodeIdEncodingBits.FourByte) : NodeIdEncodingBits.TwoByte;
        break;
      case IdType.String:
        nodeIdEncodingBits = NodeIdEncodingBits.String;
        break;
      case IdType.Guid:
        nodeIdEncodingBits = NodeIdEncodingBits.Guid;
        break;
      case IdType.Opaque:
        nodeIdEncodingBits = NodeIdEncodingBits.ByteString;
        break;
      default:
        throw new ServiceResultException(2147876864U /*0x80060000*/, Utils.Format("NodeId identifier type '{0}' not supported.", (object) idType));
    }
    return Convert.ToByte((object) nodeIdEncodingBits, (IFormatProvider) CultureInfo.InvariantCulture);
  }

  private void WriteNodeIdBody(byte encoding, object identifier, ushort namespaceIndex)
  {
    switch (63 /*0x3F*/ & (int) encoding)
    {
      case 0:
        this.WriteByte((string) null, Convert.ToByte(identifier, (IFormatProvider) CultureInfo.InvariantCulture));
        break;
      case 1:
        this.WriteByte((string) null, Convert.ToByte(namespaceIndex));
        this.WriteUInt16((string) null, Convert.ToUInt16(identifier, (IFormatProvider) CultureInfo.InvariantCulture));
        break;
      case 2:
        this.WriteUInt16((string) null, namespaceIndex);
        this.WriteUInt32((string) null, Convert.ToUInt32(identifier, (IFormatProvider) CultureInfo.InvariantCulture));
        break;
      case 3:
        this.WriteUInt16((string) null, namespaceIndex);
        this.WriteString((string) null, (string) identifier);
        break;
      case 4:
        this.WriteUInt16((string) null, namespaceIndex);
        this.WriteGuid((string) null, new Uuid((Guid) identifier));
        break;
      case 5:
        this.WriteUInt16((string) null, namespaceIndex);
        this.WriteByteString((string) null, (byte[]) identifier);
        break;
    }
  }

  private void WriteVariantValue(string fieldName, Variant value)
  {
    if (value.Value != null && value.TypeInfo != null && value.TypeInfo.BuiltInType != BuiltInType.Null)
    {
      byte num1 = (byte) value.TypeInfo.BuiltInType;
      if (value.TypeInfo.BuiltInType == BuiltInType.Enumeration)
        num1 = (byte) 6;
      object elements = value.Value;
      if (value.TypeInfo.ValueRank < 0)
      {
        this.WriteByte((string) null, num1);
        switch (value.TypeInfo.BuiltInType)
        {
          case BuiltInType.Boolean:
            this.WriteBoolean((string) null, (bool) elements);
            return;
          case BuiltInType.SByte:
            this.WriteSByte((string) null, (sbyte) elements);
            return;
          case BuiltInType.Byte:
            this.WriteByte((string) null, (byte) elements);
            return;
          case BuiltInType.Int16:
            this.WriteInt16((string) null, (short) elements);
            return;
          case BuiltInType.UInt16:
            this.WriteUInt16((string) null, (ushort) elements);
            return;
          case BuiltInType.Int32:
            this.WriteInt32((string) null, (int) elements);
            return;
          case BuiltInType.UInt32:
            this.WriteUInt32((string) null, (uint) elements);
            return;
          case BuiltInType.Int64:
            this.WriteInt64((string) null, (long) elements);
            return;
          case BuiltInType.UInt64:
            this.WriteUInt64((string) null, (ulong) elements);
            return;
          case BuiltInType.Float:
            this.WriteFloat((string) null, (float) elements);
            return;
          case BuiltInType.Double:
            this.WriteDouble((string) null, (double) elements);
            return;
          case BuiltInType.String:
            this.WriteString((string) null, (string) elements);
            return;
          case BuiltInType.DateTime:
            this.WriteDateTime((string) null, (DateTime) elements);
            return;
          case BuiltInType.Guid:
            this.WriteGuid((string) null, (Uuid) elements);
            return;
          case BuiltInType.ByteString:
            this.WriteByteString((string) null, (byte[]) elements);
            return;
          case BuiltInType.XmlElement:
            this.WriteXmlElement((string) null, (XmlElement) elements);
            return;
          case BuiltInType.NodeId:
            this.WriteNodeId((string) null, (NodeId) elements);
            return;
          case BuiltInType.ExpandedNodeId:
            this.WriteExpandedNodeId((string) null, (ExpandedNodeId) elements);
            return;
          case BuiltInType.StatusCode:
            this.WriteStatusCode((string) null, (StatusCode) elements);
            return;
          case BuiltInType.QualifiedName:
            this.WriteQualifiedName((string) null, (QualifiedName) elements);
            return;
          case BuiltInType.LocalizedText:
            this.WriteLocalizedText((string) null, (LocalizedText) elements);
            return;
          case BuiltInType.ExtensionObject:
            this.WriteExtensionObject((string) null, (ExtensionObject) elements);
            return;
          case BuiltInType.DataValue:
            this.WriteDataValue((string) null, (DataValue) elements);
            return;
          case BuiltInType.DiagnosticInfo:
            this.WriteDiagnosticInfo((string) null, (DiagnosticInfo) elements);
            break;
          case BuiltInType.Enumeration:
            this.WriteInt32((string) null, Convert.ToInt32(elements));
            return;
        }
        throw ServiceResultException.Create(2147876864U /*0x80060000*/, "Unexpected type encountered while encoding a Variant: {0}", (object) value.TypeInfo.BuiltInType);
      }
      if (value.TypeInfo.ValueRank < 0)
        return;
      Matrix matrix = (Matrix) null;
      byte num2 = (byte) ((uint) num1 | 128U /*0x80*/);
      if (value.TypeInfo.ValueRank > 1)
      {
        num2 |= (byte) 64 /*0x40*/;
        matrix = (Matrix) elements;
        elements = (object) matrix.Elements;
      }
      this.WriteByte((string) null, num2);
      switch (value.TypeInfo.BuiltInType)
      {
        case BuiltInType.Boolean:
          this.WriteBooleanArray((string) null, (IList<bool>) (bool[]) elements);
          break;
        case BuiltInType.SByte:
          this.WriteSByteArray((string) null, (IList<sbyte>) (sbyte[]) elements);
          break;
        case BuiltInType.Byte:
          this.WriteByteArray((string) null, (IList<byte>) (byte[]) elements);
          break;
        case BuiltInType.Int16:
          this.WriteInt16Array((string) null, (IList<short>) (short[]) elements);
          break;
        case BuiltInType.UInt16:
          this.WriteUInt16Array((string) null, (IList<ushort>) (ushort[]) elements);
          break;
        case BuiltInType.Int32:
          this.WriteInt32Array((string) null, (IList<int>) (int[]) elements);
          break;
        case BuiltInType.UInt32:
          this.WriteUInt32Array((string) null, (IList<uint>) (uint[]) elements);
          break;
        case BuiltInType.Int64:
          this.WriteInt64Array((string) null, (IList<long>) (long[]) elements);
          break;
        case BuiltInType.UInt64:
          this.WriteUInt64Array((string) null, (IList<ulong>) (ulong[]) elements);
          break;
        case BuiltInType.Float:
          this.WriteFloatArray((string) null, (IList<float>) (float[]) elements);
          break;
        case BuiltInType.Double:
          this.WriteDoubleArray((string) null, (IList<double>) (double[]) elements);
          break;
        case BuiltInType.String:
          this.WriteStringArray((string) null, (IList<string>) (string[]) elements);
          break;
        case BuiltInType.DateTime:
          this.WriteDateTimeArray((string) null, (IList<DateTime>) (DateTime[]) elements);
          break;
        case BuiltInType.Guid:
          this.WriteGuidArray((string) null, (IList<Uuid>) (Uuid[]) elements);
          break;
        case BuiltInType.ByteString:
          this.WriteByteStringArray((string) null, (IList<byte[]>) (byte[][]) elements);
          break;
        case BuiltInType.XmlElement:
          this.WriteXmlElementArray((string) null, (IList<XmlElement>) (XmlElement[]) elements);
          break;
        case BuiltInType.NodeId:
          this.WriteNodeIdArray((string) null, (IList<NodeId>) (NodeId[]) elements);
          break;
        case BuiltInType.ExpandedNodeId:
          this.WriteExpandedNodeIdArray((string) null, (IList<ExpandedNodeId>) (ExpandedNodeId[]) elements);
          break;
        case BuiltInType.StatusCode:
          this.WriteStatusCodeArray((string) null, (IList<StatusCode>) (StatusCode[]) elements);
          break;
        case BuiltInType.QualifiedName:
          this.WriteQualifiedNameArray((string) null, (IList<QualifiedName>) (QualifiedName[]) elements);
          break;
        case BuiltInType.LocalizedText:
          this.WriteLocalizedTextArray((string) null, (IList<LocalizedText>) (LocalizedText[]) elements);
          break;
        case BuiltInType.ExtensionObject:
          this.WriteExtensionObjectArray((string) null, (IList<ExtensionObject>) (ExtensionObject[]) elements);
          break;
        case BuiltInType.DataValue:
          this.WriteDataValueArray((string) null, (IList<DataValue>) (DataValue[]) elements);
          break;
        case BuiltInType.Variant:
          switch (elements)
          {
            case Variant[] values1:
              this.WriteVariantArray((string) null, (IList<Variant>) values1);
              break;
            case object[] values2:
              this.WriteObjectArray((string) null, (IList<object>) values2);
              break;
            default:
              throw ServiceResultException.Create(2147876864U /*0x80060000*/, "Unexpected type encountered while encoding a Matrix: {0}", (object) elements.GetType());
          }
          break;
        case BuiltInType.DiagnosticInfo:
          this.WriteDiagnosticInfoArray((string) null, (IList<DiagnosticInfo>) (DiagnosticInfo[]) elements);
          break;
        case BuiltInType.Enumeration:
          switch (elements)
          {
            case int[] values3:
label_71:
              this.WriteInt32Array((string) null, (IList<int>) values3);
              break;
            case Enum[] enumArray:
              values3 = new int[enumArray.Length];
              for (int index = 0; index < enumArray.Length; ++index)
                values3[index] = (int) enumArray[index];
              goto label_71;
            default:
              throw new ServiceResultException(2147876864U /*0x80060000*/, Utils.Format("Type '{0}' is not allowed in an Enumeration.", (object) value.GetType().FullName));
          }
          break;
        default:
          throw ServiceResultException.Create(2147876864U /*0x80060000*/, "Unexpected type encountered while encoding a Variant: {0}", (object) value.TypeInfo.BuiltInType);
      }
      if (value.TypeInfo.ValueRank <= 1)
        return;
      this.WriteInt32Array((string) null, (IList<int>) matrix.Dimensions);
    }
    else
      this.WriteByte((string) null, (byte) 0);
  }

  private void CheckAndIncrementNestingLevel()
  {
    if (this.m_nestingLevel > this.m_context.MaxEncodingNestingLevels)
      throw ServiceResultException.Create(2148007936U /*0x80080000*/, "Maximum nesting level of {0} was exceeded", (object) this.m_context.MaxEncodingNestingLevels);
    ++this.m_nestingLevel;
  }
}
