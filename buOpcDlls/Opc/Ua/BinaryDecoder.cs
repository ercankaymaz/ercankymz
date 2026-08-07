// Decompiled with JetBrains decompiler
// Type: Opc.Ua.BinaryDecoder
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;

#nullable disable
namespace Opc.Ua;

[ComVisible(true)]
public class BinaryDecoder : IDecoder, IDisposable
{
  private Stream m_istrm;
  private BinaryReader m_reader;
  private IServiceMessageContext m_context;
  private ushort[] m_namespaceMappings;
  private ushort[] m_serverMappings;
  private uint m_nestingLevel;

  public BinaryDecoder(byte[] buffer, IServiceMessageContext context)
    : this(buffer, 0, buffer.Length, context)
  {
  }

  public BinaryDecoder(byte[] buffer, int start, int count, IServiceMessageContext context)
  {
    this.m_istrm = (Stream) new MemoryStream(buffer, start, count, false);
    this.m_reader = new BinaryReader(this.m_istrm);
    this.m_context = context;
    this.m_nestingLevel = 0U;
  }

  public BinaryDecoder(Stream stream, IServiceMessageContext context)
  {
    this.m_istrm = stream != null ? stream : throw new ArgumentNullException(nameof (stream));
    this.m_reader = new BinaryReader(this.m_istrm);
    this.m_context = context;
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
    if (this.m_reader != null)
      this.m_reader.Dispose();
    if (this.m_istrm == null)
      return;
    this.m_istrm.Dispose();
  }

  public void SetMappingTables(NamespaceTable namespaceUris, StringTable serverUris)
  {
    this.m_namespaceMappings = (ushort[]) null;
    if (namespaceUris != null && this.m_context.NamespaceUris != null)
      this.m_namespaceMappings = this.m_context.NamespaceUris.CreateMapping((StringTable) namespaceUris, false);
    this.m_serverMappings = (ushort[]) null;
    if (serverUris == null || this.m_context.ServerUris == null)
      return;
    this.m_serverMappings = this.m_context.ServerUris.CreateMapping(serverUris, false);
  }

  public void Close() => this.m_reader.Dispose();

  public int Position => (int) this.m_reader.BaseStream.Position;

  public Stream BaseStream => this.m_reader.BaseStream;

  public static IEncodeable DecodeMessage(
    Stream stream,
    Type expectedType,
    IServiceMessageContext context)
  {
    if (stream == null)
      throw new ArgumentNullException(nameof (stream));
    BinaryDecoder binaryDecoder = context != null ? new BinaryDecoder(stream, context) : throw new ArgumentNullException(nameof (context));
    try
    {
      return binaryDecoder.DecodeMessage(expectedType);
    }
    finally
    {
      binaryDecoder.Close();
    }
  }

  public static IEncodeable DecodeSessionLessMessage(byte[] buffer, IServiceMessageContext context)
  {
    if (buffer == null)
      throw new ArgumentNullException(nameof (buffer));
    BinaryDecoder binaryDecoder = context != null ? new BinaryDecoder(buffer, context) : throw new ArgumentNullException(nameof (context));
    try
    {
      ExpandedNodeId expandedNodeId = NodeId.ToExpandedNodeId(binaryDecoder.ReadNodeId((string) null), context.NamespaceUris);
      Type systemType = context.Factory.GetSystemType(expandedNodeId);
      if (systemType == (Type) null || systemType != typeof (SessionlessInvokeRequestType))
        throw new ServiceResultException(2147942400U /*0x80070000*/, Utils.Format("Cannot decode session-less service message with type id: {0}.", (object) expandedNodeId));
      SessionLessServiceMessage lessServiceMessage = new SessionLessServiceMessage();
      lessServiceMessage.Decode((IDecoder) binaryDecoder);
      return lessServiceMessage.Message;
    }
    finally
    {
      binaryDecoder.Close();
    }
  }

  public static IEncodeable DecodeMessage(
    byte[] buffer,
    Type expectedType,
    IServiceMessageContext context)
  {
    if (buffer == null)
      throw new ArgumentNullException(nameof (buffer));
    BinaryDecoder binaryDecoder = context != null ? new BinaryDecoder(buffer, context) : throw new ArgumentNullException(nameof (context));
    try
    {
      return binaryDecoder.DecodeMessage(expectedType);
    }
    finally
    {
      binaryDecoder.Close();
    }
  }

  public IEncodeable DecodeMessage(Type expectedType)
  {
    long position = this.m_istrm.Position;
    ExpandedNodeId expandedNodeId = NodeId.ToExpandedNodeId(this.ReadNodeId((string) null), this.m_context.NamespaceUris);
    Type systemType = this.m_context.Factory.GetSystemType(expandedNodeId);
    IEncodeable encodeable = !(systemType == (Type) null) ? this.ReadEncodeable((string) null, systemType, expandedNodeId) : throw new ServiceResultException(2147942400U /*0x80070000*/, Utils.Format("Cannot decode message with type id: {0}.", (object) expandedNodeId));
    if (this.m_context.MaxMessageSize > 0 && this.m_context.MaxMessageSize < (int) (this.m_istrm.Position - position))
      throw ServiceResultException.Create(2148007936U /*0x80080000*/, "MaxMessageSize {0} < {1}", (object) this.m_context.MaxMessageSize, (object) (int) (this.m_istrm.Position - position));
    return encodeable;
  }

  public bool LoadStringTable(StringTable stringTable)
  {
    int num = this.ReadInt32((string) null);
    if (num < 0)
      return false;
    for (uint index = 0; (long) index < (long) num; ++index)
      stringTable.Append(this.ReadString((string) null));
    return true;
  }

  public EncodingType EncodingType => EncodingType.Binary;

  public IServiceMessageContext Context => this.m_context;

  public void PushNamespace(string namespaceUri)
  {
  }

  public void PopNamespace()
  {
  }

  public bool ReadBoolean(string fieldName) => this.m_reader.ReadBoolean();

  public sbyte ReadSByte(string fieldName) => this.m_reader.ReadSByte();

  public byte ReadByte(string fieldName) => this.m_reader.ReadByte();

  public short ReadInt16(string fieldName) => this.m_reader.ReadInt16();

  public ushort ReadUInt16(string fieldName) => this.m_reader.ReadUInt16();

  public int ReadInt32(string fieldName) => this.m_reader.ReadInt32();

  public uint ReadUInt32(string fieldName) => this.m_reader.ReadUInt32();

  public long ReadInt64(string fieldName) => this.m_reader.ReadInt64();

  public ulong ReadUInt64(string fieldName) => this.m_reader.ReadUInt64();

  public float ReadFloat(string fieldName) => this.m_reader.ReadSingle();

  public double ReadDouble(string fieldName) => this.m_reader.ReadDouble();

  public string ReadString(string fieldName)
  {
    return this.ReadString(fieldName, this.m_context.MaxStringLength);
  }

  public string ReadString(string fieldName, int maxStringLength)
  {
    int count1 = this.m_reader.ReadInt32();
    if (count1 < 0)
      return (string) null;
    if (count1 == 0)
      return string.Empty;
    byte[] bytes = maxStringLength <= 0 || maxStringLength >= count1 ? this.m_reader.ReadBytes(count1) : throw ServiceResultException.Create(2148007936U /*0x80080000*/, "MaxStringLength {0} < {1}", (object) maxStringLength, (object) count1);
    int count2 = bytes[bytes.Length - 1] == (byte) 0 ? bytes.Length - 1 : bytes.Length;
    return Encoding.UTF8.GetString(bytes, 0, count2);
  }

  public DateTime ReadDateTime(string fieldName)
  {
    long num1 = this.m_reader.ReadInt64();
    if (num1 >= long.MaxValue - Utils.TimeBase.Ticks)
      return DateTime.MaxValue;
    long num2 = num1;
    DateTime dateTime = Utils.TimeBase;
    long ticks1 = dateTime.Ticks;
    long ticks2 = num2 + ticks1;
    long num3 = ticks2;
    dateTime = DateTime.MaxValue;
    long ticks3 = dateTime.Ticks;
    if (num3 >= ticks3)
      return DateTime.MaxValue;
    long num4 = ticks2;
    dateTime = Utils.TimeBase;
    long ticks4 = dateTime.Ticks;
    return num4 <= ticks4 ? DateTime.MinValue : new DateTime(ticks2, DateTimeKind.Utc);
  }

  public Uuid ReadGuid(string fieldName)
  {
    return new Uuid(new Guid(this.m_reader.ReadBytes(16 /*0x10*/)));
  }

  public byte[] ReadByteString(string fieldName)
  {
    return this.ReadByteString(fieldName, this.m_context.MaxByteStringLength);
  }

  public byte[] ReadByteString(string fieldName, int maxByteStringLength)
  {
    int count = this.m_reader.ReadInt32();
    if (count < 0)
      return (byte[]) null;
    return maxByteStringLength <= 0 || maxByteStringLength >= count ? this.m_reader.ReadBytes(count) : throw ServiceResultException.Create(2148007936U /*0x80080000*/, "MaxByteStringLength {0} < {1}", (object) maxByteStringLength, (object) count);
  }

  public XmlElement ReadXmlElement(string fieldName)
  {
    byte[] bytes = this.ReadByteString(fieldName);
    if (bytes == null || bytes.Length == 0)
      return (XmlElement) null;
    XmlDocument xmlDocument = new XmlDocument();
    try
    {
      int count = bytes[bytes.Length - 1] == (byte) 0 ? bytes.Length - 1 : bytes.Length;
      using (StringReader input = new StringReader(Encoding.UTF8.GetString(bytes, 0, count)))
      {
        using (XmlReader reader = XmlReader.Create((TextReader) input, Utils.DefaultXmlReaderSettings()))
          xmlDocument.Load(reader);
      }
    }
    catch (XmlException ex)
    {
      return (XmlElement) null;
    }
    return xmlDocument.DocumentElement;
  }

  public NodeId ReadNodeId(string fieldName)
  {
    byte encodingByte = this.m_reader.ReadByte();
    NodeId nodeId = new NodeId();
    this.ReadNodeIdBody(encodingByte, nodeId);
    if (this.m_namespaceMappings != null && this.m_namespaceMappings.Length > (int) nodeId.NamespaceIndex)
      nodeId.SetNamespaceIndex(this.m_namespaceMappings[(int) nodeId.NamespaceIndex]);
    return nodeId;
  }

  public ExpandedNodeId ReadExpandedNodeId(string fieldName)
  {
    byte encodingByte = this.m_reader.ReadByte();
    ExpandedNodeId expandedNodeId = new ExpandedNodeId();
    NodeId nodeId = new NodeId();
    this.ReadNodeIdBody(encodingByte, nodeId);
    expandedNodeId.InnerNodeId = nodeId;
    if (((int) encodingByte & 128 /*0x80*/) != 0)
    {
      string uri = this.ReadString((string) null);
      expandedNodeId.SetNamespaceUri(uri);
    }
    if (((int) encodingByte & 64 /*0x40*/) != 0)
    {
      uint serverIndex = this.ReadUInt32((string) null);
      expandedNodeId.SetServerIndex(serverIndex);
    }
    if (this.m_namespaceMappings != null && this.m_namespaceMappings.Length > (int) expandedNodeId.NamespaceIndex)
      expandedNodeId.SetNamespaceIndex(this.m_namespaceMappings[(int) expandedNodeId.NamespaceIndex]);
    if (this.m_serverMappings != null && (long) this.m_serverMappings.Length > (long) expandedNodeId.ServerIndex)
      expandedNodeId.SetServerIndex((uint) this.m_serverMappings[(int) expandedNodeId.NamespaceIndex]);
    return expandedNodeId;
  }

  public StatusCode ReadStatusCode(string fieldName) => (StatusCode) this.m_reader.ReadUInt32();

  public DiagnosticInfo ReadDiagnosticInfo(string fieldName)
  {
    return this.ReadDiagnosticInfo(fieldName, 0);
  }

  public QualifiedName ReadQualifiedName(string fieldName)
  {
    ushort index = this.ReadUInt16((string) null);
    string name = this.ReadString((string) null);
    if (this.m_namespaceMappings != null && this.m_namespaceMappings.Length > (int) index)
      index = this.m_namespaceMappings[(int) index];
    int namespaceIndex = (int) index;
    return new QualifiedName(name, (ushort) namespaceIndex);
  }

  public LocalizedText ReadLocalizedText(string fieldName)
  {
    int num = (int) this.m_reader.ReadByte();
    string text = (string) null;
    string locale = (string) null;
    if ((num & 1) != 0)
      locale = this.ReadString((string) null);
    if ((num & 2) != 0)
      text = this.ReadString((string) null);
    return new LocalizedText(locale, text);
  }

  public Variant ReadVariant(string fieldName)
  {
    this.CheckAndIncrementNestingLevel();
    try
    {
      return this.ReadVariantValue(fieldName);
    }
    finally
    {
      --this.m_nestingLevel;
    }
  }

  public DataValue ReadDataValue(string fieldName)
  {
    int num = (int) this.m_reader.ReadByte();
    DataValue dataValue = new DataValue();
    if ((num & 1) != 0)
      dataValue.WrappedValue = this.ReadVariant((string) null);
    if ((num & 2) != 0)
      dataValue.StatusCode = this.ReadStatusCode((string) null);
    if ((num & 4) != 0)
      dataValue.SourceTimestamp = this.ReadDateTime((string) null);
    if ((num & 16 /*0x10*/) != 0)
      dataValue.SourcePicoseconds = this.ReadUInt16((string) null);
    if ((num & 8) != 0)
      dataValue.ServerTimestamp = this.ReadDateTime((string) null);
    if ((num & 32 /*0x20*/) != 0)
      dataValue.ServerPicoseconds = this.ReadUInt16((string) null);
    return dataValue;
  }

  public ExtensionObject ReadExtensionObject(string fieldName) => this.ReadExtensionObject();

  public IEncodeable ReadEncodeable(
    string fieldName,
    Type systemType,
    ExpandedNodeId encodeableTypeId = null)
  {
    if (systemType == (Type) null)
      throw new ArgumentNullException(nameof (systemType));
    if (!(Activator.CreateInstance(systemType) is IEncodeable instance))
      throw new ServiceResultException(2147942400U /*0x80070000*/, Utils.Format("Cannot decode type '{0}'.", (object) systemType.FullName));
    if (encodeableTypeId != (object) null && instance is IComplexTypeInstance complexTypeInstance)
      complexTypeInstance.TypeId = encodeableTypeId;
    this.CheckAndIncrementNestingLevel();
    try
    {
      instance.Decode((IDecoder) this);
    }
    finally
    {
      --this.m_nestingLevel;
    }
    return instance;
  }

  public Enum ReadEnumerated(string fieldName, Type enumType)
  {
    return (Enum) Enum.ToObject(enumType, this.m_reader.ReadInt32());
  }

  public BooleanCollection ReadBooleanArray(string fieldName)
  {
    int capacity = this.ReadArrayLength();
    if (capacity == -1)
      return (BooleanCollection) null;
    BooleanCollection booleanCollection = new BooleanCollection(capacity);
    for (int index = 0; index < capacity; ++index)
      booleanCollection.Add(this.ReadBoolean((string) null));
    return booleanCollection;
  }

  public SByteCollection ReadSByteArray(string fieldName)
  {
    int capacity = this.ReadArrayLength();
    if (capacity == -1)
      return (SByteCollection) null;
    SByteCollection sbyteCollection = new SByteCollection(capacity);
    for (int index = 0; index < capacity; ++index)
      sbyteCollection.Add(this.ReadSByte((string) null));
    return sbyteCollection;
  }

  public ByteCollection ReadByteArray(string fieldName)
  {
    int capacity = this.ReadArrayLength();
    if (capacity == -1)
      return (ByteCollection) null;
    ByteCollection byteCollection = new ByteCollection(capacity);
    for (int index = 0; index < capacity; ++index)
      byteCollection.Add(this.ReadByte((string) null));
    return byteCollection;
  }

  public Int16Collection ReadInt16Array(string fieldName)
  {
    int capacity = this.ReadArrayLength();
    if (capacity == -1)
      return (Int16Collection) null;
    Int16Collection int16Collection = new Int16Collection(capacity);
    for (int index = 0; index < capacity; ++index)
      int16Collection.Add(this.ReadInt16((string) null));
    return int16Collection;
  }

  public UInt16Collection ReadUInt16Array(string fieldName)
  {
    int capacity = this.ReadArrayLength();
    if (capacity == -1)
      return (UInt16Collection) null;
    UInt16Collection uint16Collection = new UInt16Collection(capacity);
    for (int index = 0; index < capacity; ++index)
      uint16Collection.Add(this.ReadUInt16((string) null));
    return uint16Collection;
  }

  public Int32Collection ReadInt32Array(string fieldName)
  {
    int capacity = this.ReadArrayLength();
    if (capacity == -1)
      return (Int32Collection) null;
    Int32Collection int32Collection = new Int32Collection(capacity);
    for (int index = 0; index < capacity; ++index)
      int32Collection.Add(this.ReadInt32((string) null));
    return int32Collection;
  }

  public UInt32Collection ReadUInt32Array(string fieldName)
  {
    int capacity = this.ReadArrayLength();
    if (capacity == -1)
      return (UInt32Collection) null;
    UInt32Collection uint32Collection = new UInt32Collection(capacity);
    for (int index = 0; index < capacity; ++index)
      uint32Collection.Add(this.ReadUInt32((string) null));
    return uint32Collection;
  }

  public Int64Collection ReadInt64Array(string fieldName)
  {
    int capacity = this.ReadArrayLength();
    if (capacity == -1)
      return (Int64Collection) null;
    Int64Collection int64Collection = new Int64Collection(capacity);
    for (int index = 0; index < capacity; ++index)
      int64Collection.Add(this.ReadInt64((string) null));
    return int64Collection;
  }

  public UInt64Collection ReadUInt64Array(string fieldName)
  {
    int capacity = this.ReadArrayLength();
    if (capacity == -1)
      return (UInt64Collection) null;
    UInt64Collection uint64Collection = new UInt64Collection(capacity);
    for (int index = 0; index < capacity; ++index)
      uint64Collection.Add(this.ReadUInt64((string) null));
    return uint64Collection;
  }

  public FloatCollection ReadFloatArray(string fieldName)
  {
    int capacity = this.ReadArrayLength();
    if (capacity == -1)
      return (FloatCollection) null;
    FloatCollection floatCollection = new FloatCollection(capacity);
    for (int index = 0; index < capacity; ++index)
      floatCollection.Add(this.ReadFloat((string) null));
    return floatCollection;
  }

  public DoubleCollection ReadDoubleArray(string fieldName)
  {
    int capacity = this.ReadArrayLength();
    if (capacity == -1)
      return (DoubleCollection) null;
    DoubleCollection doubleCollection = new DoubleCollection(capacity);
    for (int index = 0; index < capacity; ++index)
      doubleCollection.Add(this.ReadDouble((string) null));
    return doubleCollection;
  }

  public StringCollection ReadStringArray(string fieldName)
  {
    int capacity = this.ReadArrayLength();
    if (capacity == -1)
      return (StringCollection) null;
    StringCollection stringCollection = new StringCollection(capacity);
    for (int index = 0; index < capacity; ++index)
      stringCollection.Add(this.ReadString((string) null));
    return stringCollection;
  }

  public DateTimeCollection ReadDateTimeArray(string fieldName)
  {
    int capacity = this.ReadArrayLength();
    if (capacity == -1)
      return (DateTimeCollection) null;
    DateTimeCollection dateTimeCollection = new DateTimeCollection(capacity);
    for (int index = 0; index < capacity; ++index)
      dateTimeCollection.Add(this.ReadDateTime((string) null));
    return dateTimeCollection;
  }

  public UuidCollection ReadGuidArray(string fieldName)
  {
    int capacity = this.ReadArrayLength();
    if (capacity == -1)
      return (UuidCollection) null;
    UuidCollection uuidCollection = new UuidCollection(capacity);
    for (int index = 0; index < capacity; ++index)
      uuidCollection.Add(this.ReadGuid((string) null));
    return uuidCollection;
  }

  public ByteStringCollection ReadByteStringArray(string fieldName)
  {
    int capacity = this.ReadArrayLength();
    if (capacity == -1)
      return (ByteStringCollection) null;
    ByteStringCollection stringCollection = new ByteStringCollection(capacity);
    for (int index = 0; index < capacity; ++index)
      stringCollection.Add(this.ReadByteString((string) null));
    return stringCollection;
  }

  public XmlElementCollection ReadXmlElementArray(string fieldName)
  {
    int capacity = this.ReadArrayLength();
    if (capacity == -1)
      return (XmlElementCollection) null;
    XmlElementCollection elementCollection = new XmlElementCollection(capacity);
    for (int index = 0; index < capacity; ++index)
      elementCollection.Add(this.ReadXmlElement((string) null));
    return elementCollection;
  }

  public NodeIdCollection ReadNodeIdArray(string fieldName)
  {
    int capacity = this.ReadArrayLength();
    if (capacity == -1)
      return (NodeIdCollection) null;
    NodeIdCollection nodeIdCollection = new NodeIdCollection(capacity);
    for (int index = 0; index < capacity; ++index)
      nodeIdCollection.Add(this.ReadNodeId((string) null));
    return nodeIdCollection;
  }

  public ExpandedNodeIdCollection ReadExpandedNodeIdArray(string fieldName)
  {
    int capacity = this.ReadArrayLength();
    if (capacity == -1)
      return (ExpandedNodeIdCollection) null;
    ExpandedNodeIdCollection nodeIdCollection = new ExpandedNodeIdCollection(capacity);
    for (int index = 0; index < capacity; ++index)
      nodeIdCollection.Add(this.ReadExpandedNodeId((string) null));
    return nodeIdCollection;
  }

  public StatusCodeCollection ReadStatusCodeArray(string fieldName)
  {
    int capacity = this.ReadArrayLength();
    if (capacity == -1)
      return (StatusCodeCollection) null;
    StatusCodeCollection statusCodeCollection = new StatusCodeCollection(capacity);
    for (int index = 0; index < capacity; ++index)
      statusCodeCollection.Add(this.ReadStatusCode((string) null));
    return statusCodeCollection;
  }

  public DiagnosticInfoCollection ReadDiagnosticInfoArray(string fieldName)
  {
    int capacity = this.ReadArrayLength();
    if (capacity == -1)
      return (DiagnosticInfoCollection) null;
    DiagnosticInfoCollection diagnosticInfoCollection = new DiagnosticInfoCollection(capacity);
    for (int index = 0; index < capacity; ++index)
      diagnosticInfoCollection.Add(this.ReadDiagnosticInfo((string) null));
    return diagnosticInfoCollection;
  }

  public QualifiedNameCollection ReadQualifiedNameArray(string fieldName)
  {
    int capacity = this.ReadArrayLength();
    if (capacity == -1)
      return (QualifiedNameCollection) null;
    QualifiedNameCollection qualifiedNameCollection = new QualifiedNameCollection(capacity);
    for (int index = 0; index < capacity; ++index)
      qualifiedNameCollection.Add(this.ReadQualifiedName((string) null));
    return qualifiedNameCollection;
  }

  public LocalizedTextCollection ReadLocalizedTextArray(string fieldName)
  {
    int capacity = this.ReadArrayLength();
    if (capacity == -1)
      return (LocalizedTextCollection) null;
    LocalizedTextCollection localizedTextCollection = new LocalizedTextCollection(capacity);
    for (int index = 0; index < capacity; ++index)
      localizedTextCollection.Add(this.ReadLocalizedText((string) null));
    return localizedTextCollection;
  }

  public VariantCollection ReadVariantArray(string fieldName)
  {
    int capacity = this.ReadArrayLength();
    if (capacity == -1)
      return (VariantCollection) null;
    VariantCollection variantCollection = new VariantCollection(capacity);
    for (int index = 0; index < capacity; ++index)
      variantCollection.Add(this.ReadVariant((string) null));
    return variantCollection;
  }

  public DataValueCollection ReadDataValueArray(string fieldName)
  {
    int capacity = this.ReadArrayLength();
    if (capacity == -1)
      return (DataValueCollection) null;
    DataValueCollection dataValueCollection = new DataValueCollection(capacity);
    for (int index = 0; index < capacity; ++index)
      dataValueCollection.Add(this.ReadDataValue((string) null));
    return dataValueCollection;
  }

  public ExtensionObjectCollection ReadExtensionObjectArray(string fieldName)
  {
    int capacity = this.ReadArrayLength();
    if (capacity == -1)
      return (ExtensionObjectCollection) null;
    ExtensionObjectCollection objectCollection = new ExtensionObjectCollection(capacity);
    for (int index = 0; index < capacity; ++index)
      objectCollection.Add(this.ReadExtensionObject((string) null));
    return objectCollection;
  }

  public Array ReadEncodeableArray(
    string fieldName,
    Type systemType,
    ExpandedNodeId encodeableTypeId = null)
  {
    int length = this.ReadArrayLength();
    if (length == -1)
      return (Array) null;
    Array instance = Array.CreateInstance(systemType, length);
    for (int index = 0; index < length; ++index)
      instance.SetValue((object) this.ReadEncodeable((string) null, systemType, encodeableTypeId), index);
    return instance;
  }

  public Array ReadEnumeratedArray(string fieldName, Type enumType)
  {
    int length = this.ReadArrayLength();
    if (length == -1)
      return (Array) null;
    Array instance = Array.CreateInstance(enumType, length);
    for (int index = 0; index < length; ++index)
      instance.SetValue((object) this.ReadEnumerated((string) null, enumType), index);
    return instance;
  }

  public Array ReadArray(
    string fieldName,
    int valueRank,
    BuiltInType builtInType,
    Type systemType = null,
    ExpandedNodeId encodeableTypeId = null)
  {
    if (valueRank == 1)
    {
      switch (builtInType)
      {
        case BuiltInType.Boolean:
          return (Array) this.ReadBooleanArray(fieldName).ToArray();
        case BuiltInType.SByte:
          return (Array) this.ReadSByteArray(fieldName).ToArray();
        case BuiltInType.Byte:
          return (Array) this.ReadByteArray(fieldName).ToArray();
        case BuiltInType.Int16:
          return (Array) this.ReadInt16Array(fieldName).ToArray();
        case BuiltInType.UInt16:
          return (Array) this.ReadUInt16Array(fieldName).ToArray();
        case BuiltInType.Int32:
          return (Array) this.ReadInt32Array(fieldName).ToArray();
        case BuiltInType.UInt32:
          return (Array) this.ReadUInt32Array(fieldName).ToArray();
        case BuiltInType.Int64:
          return (Array) this.ReadInt64Array(fieldName).ToArray();
        case BuiltInType.UInt64:
          return (Array) this.ReadUInt64Array(fieldName).ToArray();
        case BuiltInType.Float:
          return (Array) this.ReadFloatArray(fieldName).ToArray();
        case BuiltInType.Double:
          return (Array) this.ReadDoubleArray(fieldName).ToArray();
        case BuiltInType.String:
          return (Array) this.ReadStringArray(fieldName).ToArray();
        case BuiltInType.DateTime:
          return (Array) this.ReadDateTimeArray(fieldName).ToArray();
        case BuiltInType.Guid:
          return (Array) this.ReadGuidArray(fieldName).ToArray();
        case BuiltInType.ByteString:
          return (Array) this.ReadByteStringArray(fieldName).ToArray();
        case BuiltInType.XmlElement:
          return (Array) this.ReadXmlElementArray(fieldName).ToArray();
        case BuiltInType.NodeId:
          return (Array) this.ReadNodeIdArray(fieldName).ToArray();
        case BuiltInType.ExpandedNodeId:
          return (Array) this.ReadExpandedNodeIdArray(fieldName).ToArray();
        case BuiltInType.StatusCode:
          return (Array) this.ReadStatusCodeArray(fieldName).ToArray();
        case BuiltInType.QualifiedName:
          return (Array) this.ReadQualifiedNameArray(fieldName).ToArray();
        case BuiltInType.LocalizedText:
          return (Array) this.ReadLocalizedTextArray(fieldName).ToArray();
        case BuiltInType.ExtensionObject:
          return (Array) this.ReadExtensionObjectArray(fieldName).ToArray();
        case BuiltInType.DataValue:
          return (Array) this.ReadDataValueArray(fieldName).ToArray();
        case BuiltInType.Variant:
          return this.DetermineIEncodeableSystemType(ref systemType, encodeableTypeId) ? this.ReadEncodeableArray(fieldName, systemType, encodeableTypeId) : (Array) this.ReadVariantArray(fieldName).ToArray();
        case BuiltInType.DiagnosticInfo:
          return (Array) this.ReadDiagnosticInfoArray(fieldName).ToArray();
        case BuiltInType.Enumeration:
          this.DetermineIEncodeableSystemType(ref systemType, encodeableTypeId);
          if ((object) systemType != null && systemType.IsEnum)
            return this.ReadEnumeratedArray(fieldName, systemType);
          goto case BuiltInType.Int32;
        default:
          if (this.DetermineIEncodeableSystemType(ref systemType, encodeableTypeId))
            return this.ReadEncodeableArray(fieldName, systemType, encodeableTypeId);
          throw new ServiceResultException(2147942400U /*0x80070000*/, Utils.Format("Cannot decode unknown type in Array object with BuiltInType: {0}.", (object) builtInType));
      }
    }
    else
    {
      if (valueRank < 2)
        return (Array) null;
      Int32Collection dimensions = this.ReadInt32Array((string) null);
      if (dimensions == null || dimensions.Count <= 0)
        throw ServiceResultException.Create(2147942400U /*0x80070000*/, "Unexpected null or empty Dimensions for multidimensional matrix.");
      int flatLength = Matrix.ValidateDimensions(false, dimensions, this.Context.MaxArrayLength).flatLength;
      Array elements = (Array) null;
      if (this.DetermineIEncodeableSystemType(ref systemType, encodeableTypeId))
      {
        elements = Array.CreateInstance(systemType, flatLength);
        for (int index = 0; index < flatLength; ++index)
        {
          IEncodeable encodeable = this.ReadEncodeable((string) null, systemType, encodeableTypeId);
          elements.SetValue(Convert.ChangeType((object) encodeable, systemType), index);
        }
      }
      if (elements == null)
        elements = this.ReadArrayElements(flatLength, builtInType);
      if (elements == null)
        throw ServiceResultException.Create(2147942400U /*0x80070000*/, "Unexpected null Array for multidimensional matrix with {0} elements.", (object) flatLength);
      if (builtInType == BuiltInType.Enumeration && (object) systemType != null && systemType.IsEnum)
      {
        Array instance = Array.CreateInstance(systemType, elements.Length);
        int num = 0;
        foreach (object obj in elements)
          instance.SetValue(Enum.ToObject(systemType, obj), num++);
        elements = instance;
      }
      return new Matrix(elements, builtInType, dimensions.ToArray()).ToArray();
    }
  }

  private DiagnosticInfo ReadDiagnosticInfo(string fieldName, int depth)
  {
    if (depth >= DiagnosticInfo.MaxInnerDepth)
      throw ServiceResultException.Create(2148007936U /*0x80080000*/, "Maximum nesting level of InnerDiagnosticInfo was exceeded");
    this.CheckAndIncrementNestingLevel();
    try
    {
      byte num = this.m_reader.ReadByte();
      if (num == (byte) 0)
        return (DiagnosticInfo) null;
      DiagnosticInfo diagnosticInfo = new DiagnosticInfo();
      if (((int) num & 1) != 0)
        diagnosticInfo.SymbolicId = this.ReadInt32((string) null);
      if (((int) num & 2) != 0)
        diagnosticInfo.NamespaceUri = this.ReadInt32((string) null);
      if (((int) num & 8) != 0)
        diagnosticInfo.Locale = this.ReadInt32((string) null);
      if (((int) num & 4) != 0)
        diagnosticInfo.LocalizedText = this.ReadInt32((string) null);
      if (((int) num & 16 /*0x10*/) != 0)
        diagnosticInfo.AdditionalInfo = this.ReadString((string) null);
      if (((int) num & 32 /*0x20*/) != 0)
        diagnosticInfo.InnerStatusCode = this.ReadStatusCode((string) null);
      if (((int) num & 64 /*0x40*/) != 0)
        diagnosticInfo.InnerDiagnosticInfo = this.ReadDiagnosticInfo((string) null, depth + 1);
      return diagnosticInfo;
    }
    finally
    {
      --this.m_nestingLevel;
    }
  }

  private bool DetermineIEncodeableSystemType(ref Type systemType, ExpandedNodeId encodeableTypeId)
  {
    if (encodeableTypeId != (object) null && systemType == (Type) null)
      systemType = this.Context.Factory.GetSystemType(encodeableTypeId);
    return typeof (IEncodeable).IsAssignableFrom(systemType);
  }

  private Array ReadArrayElements(int length, BuiltInType builtInType)
  {
    Array array = (Array) null;
    switch (builtInType)
    {
      case BuiltInType.Boolean:
        bool[] flagArray = new bool[length];
        for (int index = 0; index < flagArray.Length; ++index)
          flagArray[index] = this.ReadBoolean((string) null);
        array = (Array) flagArray;
        break;
      case BuiltInType.SByte:
        sbyte[] numArray1 = new sbyte[length];
        for (int index = 0; index < numArray1.Length; ++index)
          numArray1[index] = this.ReadSByte((string) null);
        array = (Array) numArray1;
        break;
      case BuiltInType.Byte:
        byte[] numArray2 = new byte[length];
        for (int index = 0; index < numArray2.Length; ++index)
          numArray2[index] = this.ReadByte((string) null);
        array = (Array) numArray2;
        break;
      case BuiltInType.Int16:
        short[] numArray3 = new short[length];
        for (int index = 0; index < numArray3.Length; ++index)
          numArray3[index] = this.ReadInt16((string) null);
        array = (Array) numArray3;
        break;
      case BuiltInType.UInt16:
        ushort[] numArray4 = new ushort[length];
        for (int index = 0; index < numArray4.Length; ++index)
          numArray4[index] = this.ReadUInt16((string) null);
        array = (Array) numArray4;
        break;
      case BuiltInType.Int32:
      case BuiltInType.Enumeration:
        int[] numArray5 = new int[length];
        for (int index = 0; index < numArray5.Length; ++index)
          numArray5[index] = this.ReadInt32((string) null);
        array = (Array) numArray5;
        break;
      case BuiltInType.UInt32:
        uint[] numArray6 = new uint[length];
        for (int index = 0; index < numArray6.Length; ++index)
          numArray6[index] = this.ReadUInt32((string) null);
        array = (Array) numArray6;
        break;
      case BuiltInType.Int64:
        long[] numArray7 = new long[length];
        for (int index = 0; index < numArray7.Length; ++index)
          numArray7[index] = this.ReadInt64((string) null);
        array = (Array) numArray7;
        break;
      case BuiltInType.UInt64:
        ulong[] numArray8 = new ulong[length];
        for (int index = 0; index < numArray8.Length; ++index)
          numArray8[index] = this.ReadUInt64((string) null);
        array = (Array) numArray8;
        break;
      case BuiltInType.Float:
        float[] numArray9 = new float[length];
        for (int index = 0; index < numArray9.Length; ++index)
          numArray9[index] = this.ReadFloat((string) null);
        array = (Array) numArray9;
        break;
      case BuiltInType.Double:
        double[] numArray10 = new double[length];
        for (int index = 0; index < numArray10.Length; ++index)
          numArray10[index] = this.ReadDouble((string) null);
        array = (Array) numArray10;
        break;
      case BuiltInType.String:
        string[] strArray = new string[length];
        for (int index = 0; index < strArray.Length; ++index)
          strArray[index] = this.ReadString((string) null);
        array = (Array) strArray;
        break;
      case BuiltInType.DateTime:
        DateTime[] dateTimeArray = new DateTime[length];
        for (int index = 0; index < dateTimeArray.Length; ++index)
          dateTimeArray[index] = this.ReadDateTime((string) null);
        array = (Array) dateTimeArray;
        break;
      case BuiltInType.Guid:
        Uuid[] uuidArray = new Uuid[length];
        for (int index = 0; index < uuidArray.Length; ++index)
          uuidArray[index] = this.ReadGuid((string) null);
        array = (Array) uuidArray;
        break;
      case BuiltInType.ByteString:
        byte[][] numArray11 = new byte[length][];
        for (int index = 0; index < numArray11.Length; ++index)
          numArray11[index] = this.ReadByteString((string) null);
        array = (Array) numArray11;
        break;
      case BuiltInType.XmlElement:
        try
        {
          XmlElement[] xmlElementArray = new XmlElement[length];
          for (int index = 0; index < xmlElementArray.Length; ++index)
            xmlElementArray[index] = this.ReadXmlElement((string) null);
          array = (Array) xmlElementArray;
          break;
        }
        catch (Exception ex)
        {
          object[] objArray = Array.Empty<object>();
          Utils.LogError(ex, "Error reading array of XmlElement.", objArray);
          break;
        }
      case BuiltInType.NodeId:
        NodeId[] nodeIdArray = new NodeId[length];
        for (int index = 0; index < nodeIdArray.Length; ++index)
          nodeIdArray[index] = this.ReadNodeId((string) null);
        array = (Array) nodeIdArray;
        break;
      case BuiltInType.ExpandedNodeId:
        ExpandedNodeId[] expandedNodeIdArray = new ExpandedNodeId[length];
        for (int index = 0; index < expandedNodeIdArray.Length; ++index)
          expandedNodeIdArray[index] = this.ReadExpandedNodeId((string) null);
        array = (Array) expandedNodeIdArray;
        break;
      case BuiltInType.StatusCode:
        StatusCode[] statusCodeArray = new StatusCode[length];
        for (int index = 0; index < statusCodeArray.Length; ++index)
          statusCodeArray[index] = this.ReadStatusCode((string) null);
        array = (Array) statusCodeArray;
        break;
      case BuiltInType.QualifiedName:
        QualifiedName[] qualifiedNameArray = new QualifiedName[length];
        for (int index = 0; index < qualifiedNameArray.Length; ++index)
          qualifiedNameArray[index] = this.ReadQualifiedName((string) null);
        array = (Array) qualifiedNameArray;
        break;
      case BuiltInType.LocalizedText:
        LocalizedText[] localizedTextArray = new LocalizedText[length];
        for (int index = 0; index < localizedTextArray.Length; ++index)
          localizedTextArray[index] = this.ReadLocalizedText((string) null);
        array = (Array) localizedTextArray;
        break;
      case BuiltInType.ExtensionObject:
        ExtensionObject[] extensionObjectArray = new ExtensionObject[length];
        for (int index = 0; index < extensionObjectArray.Length; ++index)
          extensionObjectArray[index] = this.ReadExtensionObject();
        array = (Array) extensionObjectArray;
        break;
      case BuiltInType.DataValue:
        DataValue[] dataValueArray = new DataValue[length];
        for (int index = 0; index < dataValueArray.Length; ++index)
          dataValueArray[index] = this.ReadDataValue((string) null);
        array = (Array) dataValueArray;
        break;
      case BuiltInType.Variant:
        Variant[] variantArray = new Variant[length];
        for (int index = 0; index < variantArray.Length; ++index)
          variantArray[index] = this.ReadVariant((string) null);
        array = (Array) variantArray;
        break;
      case BuiltInType.DiagnosticInfo:
        DiagnosticInfo[] diagnosticInfoArray = new DiagnosticInfo[length];
        for (int index = 0; index < diagnosticInfoArray.Length; ++index)
          diagnosticInfoArray[index] = this.ReadDiagnosticInfo((string) null);
        array = (Array) diagnosticInfoArray;
        break;
      default:
        throw new ServiceResultException(2147942400U /*0x80070000*/, Utils.Format("Cannot decode unknown type in Variant object with BuiltInType: {0}.", (object) builtInType));
    }
    return array;
  }

  private int ReadArrayLength()
  {
    int num = this.m_reader.ReadInt32();
    if (num < 0)
      return -1;
    if (this.m_context.MaxArrayLength > 0 && this.m_context.MaxArrayLength < num)
      throw ServiceResultException.Create(2148007936U /*0x80080000*/, "MaxArrayLength {0} < {1}", (object) this.m_context.MaxArrayLength, (object) num);
    return num;
  }

  private void ReadNodeIdBody(byte encodingByte, NodeId value)
  {
    switch ((int) encodingByte & 63 /*0x3F*/)
    {
      case 0:
        value.SetNamespaceIndex((ushort) 0);
        value.SetIdentifier(IdType.Numeric, (object) (uint) this.m_reader.ReadByte());
        break;
      case 1:
        value.SetNamespaceIndex((ushort) this.m_reader.ReadByte());
        value.SetIdentifier(IdType.Numeric, (object) (uint) this.m_reader.ReadUInt16());
        break;
      case 2:
        value.SetNamespaceIndex(this.m_reader.ReadUInt16());
        value.SetIdentifier(IdType.Numeric, (object) this.m_reader.ReadUInt32());
        break;
      case 3:
        value.SetNamespaceIndex(this.m_reader.ReadUInt16());
        value.SetIdentifier(IdType.String, (object) this.ReadString((string) null));
        break;
      case 4:
        value.SetNamespaceIndex(this.m_reader.ReadUInt16());
        value.SetIdentifier(IdType.Guid, (object) (Guid) this.ReadGuid((string) null));
        break;
      case 5:
        value.SetNamespaceIndex(this.m_reader.ReadUInt16());
        value.SetIdentifier(IdType.Opaque, (object) this.ReadByteString((string) null));
        break;
      default:
        throw new ServiceResultException(2147942400U /*0x80070000*/, Utils.Format("Invald encoding byte (0x{0:X2}) for NodeId.", (object) encodingByte));
    }
  }

  private ExtensionObject ReadExtensionObject()
  {
    ExtensionObject extensionObject = new ExtensionObject();
    NodeId nodeId = this.ReadNodeId((string) null);
    extensionObject.TypeId = NodeId.ToExpandedNodeId(nodeId, this.m_context.NamespaceUris);
    if (!NodeId.IsNull(nodeId) && NodeId.IsNull(extensionObject.TypeId))
      Utils.LogWarning("Cannot de-serialized extension objects if the NamespaceUri is not in the NamespaceTable: Type = {0}", (object) nodeId);
    ExtensionObjectEncoding extensionObjectEncoding = (ExtensionObjectEncoding) Enum.ToObject(typeof (ExtensionObjectEncoding), this.m_reader.ReadByte());
    if (extensionObjectEncoding == ExtensionObjectEncoding.None)
      return extensionObject;
    Type systemType = this.m_context.Factory.GetSystemType(extensionObject.TypeId);
    if (extensionObjectEncoding == ExtensionObjectEncoding.Xml)
    {
      extensionObject.Body = (object) this.ReadXmlElement((string) null);
      if (systemType != (Type) null && extensionObject.Body != null)
      {
        XmlElement body = extensionObject.Body as XmlElement;
        XmlDecoder xmlDecoder = new XmlDecoder(body, this.Context);
        try
        {
          xmlDecoder.PushNamespace(body.NamespaceURI);
          IEncodeable encodeable = xmlDecoder.ReadEncodeable(body.LocalName, systemType, extensionObject.TypeId);
          xmlDecoder.PopNamespace();
          extensionObject.Body = (object) encodeable;
        }
        catch (Exception ex)
        {
          Utils.LogError("Could not decode known type {0}. Error={1}, Value={2}", (object) systemType.FullName, (object) ex.Message, (object) body.OuterXml);
        }
      }
      return extensionObject;
    }
    IEncodeable encodeable1 = (IEncodeable) null;
    if (systemType != (Type) null)
    {
      encodeable1 = Activator.CreateInstance(systemType) as IEncodeable;
      if (encodeable1 is IComplexTypeInstance complexTypeInstance)
        complexTypeInstance.TypeId = extensionObject.TypeId;
    }
    int count1 = this.ReadInt32((string) null);
    int position = this.Position;
    if (encodeable1 != null)
    {
      uint nestingLevel = this.m_nestingLevel;
      this.CheckAndIncrementNestingLevel();
      try
      {
        encodeable1.Decode((IDecoder) this);
        int num = this.Position - position;
        if (count1 != num)
          throw ServiceResultException.Create(2147942400U /*0x80070000*/, "The encodeable.Decoder operation did not match the length of the extension object. {0} != {1}", (object) num, (object) count1);
      }
      catch (EndOfStreamException ex)
      {
        this.m_reader.BaseStream.Position = (long) position;
        encodeable1 = (IEncodeable) null;
        object[] objArray = new object[2]
        {
          (object) systemType.Name,
          (object) extensionObject.TypeId
        };
        Utils.LogWarning((Exception) ex, "End of stream, failed to decode encodeable type '{0}', NodeId='{1}'. BinaryDecoder recovered.", objArray);
      }
      catch (ServiceResultException ex) when (ex.StatusCode == 2148007936U /*0x80080000*/ || ex.StatusCode == 2147942400U /*0x80070000*/)
      {
        this.m_reader.BaseStream.Position = (long) position;
        encodeable1 = (IEncodeable) null;
        Utils.LogWarning((Exception) ex, "{0}, failed to decode encodeable type '{1}', NodeId='{2}'. BinaryDecoder recovered.", (object) ex.Message, (object) systemType.Name, (object) extensionObject.TypeId);
      }
      finally
      {
        this.m_nestingLevel = nestingLevel;
      }
    }
    if (encodeable1 == null)
    {
      if (count1 < 0)
        throw new ServiceResultException(2147942400U /*0x80070000*/, Utils.Format("Cannot determine length of unknown extension object body with type '{0}'.", (object) extensionObject.TypeId));
      if (this.m_context.MaxByteStringLength > 0 && this.m_context.MaxByteStringLength < count1)
        throw ServiceResultException.Create(2148007936U /*0x80080000*/, "MaxByteStringLength {0} < {1}", (object) this.m_context.MaxByteStringLength, (object) count1);
      extensionObject.Body = (object) this.m_reader.ReadBytes(count1);
      return extensionObject;
    }
    int count2 = count1 - (this.Position - position);
    if (count2 > 0)
      this.m_reader.ReadBytes(count2);
    if (encodeable1 != null)
      extensionObject.TypeId = encodeable1.TypeId;
    extensionObject.Body = (object) encodeable1;
    return extensionObject;
  }

  private Variant ReadVariantValue(string fieldName)
  {
    byte num1 = this.m_reader.ReadByte();
    Variant variant = new Variant();
    if (((int) num1 & 128 /*0x80*/) != 0)
    {
      int num2 = this.ReadArrayLength();
      if (num2 < 0)
        return variant;
      BuiltInType builtInType = (BuiltInType) ((int) num1 & 63 /*0x3F*/);
      Array elements = this.ReadArrayElements(num2, builtInType);
      if (elements == null)
        variant = new Variant(2147942400U /*0x80070000*/);
      else if (((int) num1 & 64 /*0x40*/) != 0)
      {
        Int32Collection int32Collection = this.ReadInt32Array((string) null);
        if (int32Collection == null || int32Collection.Count == 0)
          throw new ServiceResultException(2147942400U /*0x80070000*/, "ArrayDimensions not specified when ArrayDimensions encoding bit was set in Variant object.");
        (bool valid, int flatLength) = Matrix.ValidateDimensions((Int32Collection) int32Collection.ToArray(), num2, this.Context.MaxArrayLength);
        if (!valid || flatLength != num2)
          throw new ServiceResultException(2147942400U /*0x80070000*/, "ArrayDimensions does not match with the ArrayLength in Variant object.");
        variant = new Variant(new Matrix(elements, builtInType, int32Collection.ToArray()));
      }
      else
        variant = new Variant((object) elements, new TypeInfo(builtInType, 1));
    }
    else
    {
      switch (num1)
      {
        case 0:
          variant.Value = (object) null;
          break;
        case 1:
          variant.Set(this.ReadBoolean((string) null));
          break;
        case 2:
          variant.Set(this.ReadSByte((string) null));
          break;
        case 3:
          variant.Set(this.ReadByte((string) null));
          break;
        case 4:
          variant.Set(this.ReadInt16((string) null));
          break;
        case 5:
          variant.Set(this.ReadUInt16((string) null));
          break;
        case 6:
        case 29:
          variant.Set(this.ReadInt32((string) null));
          break;
        case 7:
          variant.Set(this.ReadUInt32((string) null));
          break;
        case 8:
          variant.Set(this.ReadInt64((string) null));
          break;
        case 9:
          variant.Set(this.ReadUInt64((string) null));
          break;
        case 10:
          variant.Set(this.ReadFloat((string) null));
          break;
        case 11:
          variant.Set(this.ReadDouble((string) null));
          break;
        case 12:
          variant.Set(this.ReadString((string) null));
          break;
        case 13:
          variant.Set(this.ReadDateTime((string) null));
          break;
        case 14:
          variant.Set(this.ReadGuid((string) null));
          break;
        case 15:
          variant.Set(this.ReadByteString((string) null));
          break;
        case 16 /*0x10*/:
          try
          {
            variant.Set(this.ReadXmlElement((string) null));
            break;
          }
          catch (Exception ex)
          {
            object[] objArray = Array.Empty<object>();
            Utils.LogError(ex, "Error reading xml element for variant.", objArray);
            variant.Set(2147942400U /*0x80070000*/);
            break;
          }
        case 17:
          variant.Set(this.ReadNodeId((string) null));
          break;
        case 18:
          variant.Set(this.ReadExpandedNodeId((string) null));
          break;
        case 19:
          variant.Set(this.ReadStatusCode((string) null));
          break;
        case 20:
          variant.Set(this.ReadQualifiedName((string) null));
          break;
        case 21:
          variant.Set(this.ReadLocalizedText((string) null));
          break;
        case 22:
          variant.Set(this.ReadExtensionObject());
          break;
        case 23:
          variant.Set(this.ReadDataValue((string) null));
          break;
        default:
          throw new ServiceResultException(2147942400U /*0x80070000*/, Utils.Format("Cannot decode unknown type in Variant object (0x{0:X2}).", (object) num1));
      }
    }
    return variant;
  }

  private void CheckAndIncrementNestingLevel()
  {
    if (this.m_nestingLevel > this.m_context.MaxEncodingNestingLevels)
      throw ServiceResultException.Create(2148007936U /*0x80080000*/, "Maximum nesting level of {0} was exceeded", (object) this.m_context.MaxEncodingNestingLevels);
    ++this.m_nestingLevel;
  }
}
