// Decompiled with JetBrains decompiler
// Type: Opc.Ua.JsonDecoder
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;

#nullable disable
namespace Opc.Ua;

[ComVisible(true)]
public class JsonDecoder : IJsonDecoder, IDecoder, IDisposable
{
  public const string RootArrayName = "___root_array___";
  private JsonTextReader m_reader;
  private Dictionary<string, object> m_root;
  private Stack<object> m_stack;
  private IServiceMessageContext m_context;
  private ushort[] m_namespaceMappings;
  private ushort[] m_serverMappings;
  private uint m_nestingLevel;
  private DateTime m_dateTimeMaxJsonValue = new DateTime(3155378975990000000L);

  public JsonDecoder(string json, IServiceMessageContext context)
  {
    if (context == null)
      throw new ArgumentNullException(nameof (context));
    this.Initialize();
    this.m_context = context;
    this.m_nestingLevel = 0U;
    this.m_reader = new JsonTextReader((TextReader) new StringReader(json));
    this.m_root = this.ReadObject();
    this.m_stack = new Stack<object>();
    this.m_stack.Push((object) this.m_root);
  }

  public JsonDecoder(Type systemType, JsonTextReader reader, IServiceMessageContext context)
  {
    this.Initialize();
    this.m_context = context;
    this.m_nestingLevel = 0U;
    this.m_reader = reader;
    this.m_root = this.ReadObject();
    this.m_stack = new Stack<object>();
    this.m_stack.Push((object) this.m_root);
  }

  private void Initialize() => this.m_reader = (JsonTextReader) null;

  public static IEncodeable DecodeSessionLessMessage(byte[] buffer, IServiceMessageContext context)
  {
    if (buffer == null)
      throw new ArgumentNullException(nameof (buffer));
    if (context == null)
      throw new ArgumentNullException(nameof (context));
    using (IJsonDecoder jsonDecoder = (IJsonDecoder) new JsonDecoder(Encoding.UTF8.GetString(buffer), context))
    {
      SessionLessServiceMessage lessServiceMessage = new SessionLessServiceMessage();
      lessServiceMessage.Decode((IDecoder) jsonDecoder);
      return lessServiceMessage.Message;
    }
  }

  public static IEncodeable DecodeMessage(
    byte[] buffer,
    Type expectedType,
    IServiceMessageContext context)
  {
    return JsonDecoder.DecodeMessage(new ArraySegment<byte>(buffer), expectedType, context);
  }

  public static IEncodeable DecodeMessage(
    ArraySegment<byte> buffer,
    Type expectedType,
    IServiceMessageContext context)
  {
    if (context == null)
      throw new ArgumentNullException(nameof (context));
    if (context.MaxMessageSize > 0 && context.MaxMessageSize < buffer.Count)
      throw ServiceResultException.Create(2148007936U /*0x80080000*/, "MaxMessageSize {0} < {1}", (object) context.MaxMessageSize, (object) buffer.Count);
    using (JsonDecoder jsonDecoder = new JsonDecoder(Encoding.UTF8.GetString(buffer.Array, buffer.Offset, buffer.Count), context))
      return jsonDecoder.DecodeMessage(expectedType);
  }

  public IEncodeable DecodeMessage(Type expectedType)
  {
    StringCollection namespaceUris = this.ReadStringArray("NamespaceUris");
    StringCollection stringCollection = this.ReadStringArray("ServerUris");
    if (namespaceUris != null && namespaceUris.Count > 0 || stringCollection != null && stringCollection.Count > 0)
      this.SetMappingTables(namespaceUris == null || namespaceUris.Count == 0 ? this.m_context.NamespaceUris : new NamespaceTable((IEnumerable<string>) namespaceUris), stringCollection == null || stringCollection.Count == 0 ? this.m_context.ServerUris : new StringTable((IEnumerable<string>) stringCollection));
    ExpandedNodeId expandedNodeId = NodeId.ToExpandedNodeId(this.ReadNodeId("TypeId"), this.m_context.NamespaceUris);
    Type systemType = this.m_context.Factory.GetSystemType(expandedNodeId);
    return !(systemType == (Type) null) ? this.ReadEncodeable("Body", systemType, expandedNodeId) : throw new ServiceResultException(2147942400U /*0x80070000*/, Utils.Format("Cannot decode message with type id: {0}.", (object) expandedNodeId));
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

  public void Close() => this.m_reader.Close();

  public void Close(bool checkEof)
  {
    if (checkEof && this.m_reader.TokenType != JsonToken.EndObject)
    {
      while (this.m_reader.Read() && this.m_reader.TokenType != JsonToken.EndObject)
        ;
    }
    this.m_reader.Close();
  }

  public object ReadExtensionObjectBody(ExpandedNodeId typeId) => (object) null;

  public void Dispose()
  {
    this.Dispose(true);
    GC.SuppressFinalize((object) this);
  }

  protected virtual void Dispose(bool disposing)
  {
    if (!disposing || this.m_reader == null)
      return;
    this.m_reader.Close();
    this.m_reader = (JsonTextReader) null;
  }

  public EncodingType EncodingType => EncodingType.Json;

  public IServiceMessageContext Context => this.m_context;

  public void PushNamespace(string namespaceUri)
  {
  }

  public void PopNamespace()
  {
  }

  public bool ReadField(string fieldName, out object token)
  {
    token = (object) null;
    if (string.IsNullOrEmpty(fieldName))
    {
      token = this.m_stack.Peek();
      return true;
    }
    return this.m_stack.Peek() is Dictionary<string, object> dictionary && dictionary.TryGetValue(fieldName, out token);
  }

  public bool ReadBoolean(string fieldName)
  {
    object token = (object) null;
    return this.ReadField(fieldName, out token) && (token as bool?).HasValue && (bool) token;
  }

  public sbyte ReadSByte(string fieldName)
  {
    object token = (object) null;
    if (!this.ReadField(fieldName, out token))
      return 0;
    long? nullable1 = token as long?;
    if (!nullable1.HasValue)
      return 0;
    long? nullable2 = nullable1;
    if (!(nullable2.GetValueOrDefault() < (long) sbyte.MinValue & nullable2.HasValue))
    {
      nullable2 = nullable1;
      if (!(nullable2.GetValueOrDefault() > (long) sbyte.MaxValue & nullable2.HasValue))
        return (sbyte) nullable1.Value;
    }
    return 0;
  }

  public byte ReadByte(string fieldName)
  {
    object token = (object) null;
    if (!this.ReadField(fieldName, out token))
      return 0;
    long? nullable1 = token as long?;
    if (!nullable1.HasValue)
      return 0;
    long? nullable2 = nullable1;
    if (!(nullable2.GetValueOrDefault() < 0L & nullable2.HasValue))
    {
      nullable2 = nullable1;
      if (!(nullable2.GetValueOrDefault() > (long) byte.MaxValue & nullable2.HasValue))
        return (byte) nullable1.Value;
    }
    return 0;
  }

  public short ReadInt16(string fieldName)
  {
    object token = (object) null;
    if (!this.ReadField(fieldName, out token))
      return 0;
    long? nullable1 = token as long?;
    if (!nullable1.HasValue)
      return 0;
    long? nullable2 = nullable1;
    if (!(nullable2.GetValueOrDefault() < (long) short.MinValue & nullable2.HasValue))
    {
      nullable2 = nullable1;
      if (!(nullable2.GetValueOrDefault() > (long) short.MaxValue & nullable2.HasValue))
        return (short) nullable1.Value;
    }
    return 0;
  }

  public ushort ReadUInt16(string fieldName)
  {
    object token = (object) null;
    if (!this.ReadField(fieldName, out token))
      return 0;
    long? nullable1 = token as long?;
    if (!nullable1.HasValue)
      return 0;
    long? nullable2 = nullable1;
    if (!(nullable2.GetValueOrDefault() < 0L & nullable2.HasValue))
    {
      nullable2 = nullable1;
      if (!(nullable2.GetValueOrDefault() > (long) ushort.MaxValue & nullable2.HasValue))
        return (ushort) nullable1.Value;
    }
    return 0;
  }

  public int ReadInt32(string fieldName)
  {
    object token = (object) null;
    if (!this.ReadField(fieldName, out token))
      return 0;
    long? nullable1 = token as long?;
    if (!nullable1.HasValue)
      return 0;
    long? nullable2 = nullable1;
    if (!(nullable2.GetValueOrDefault() < (long) int.MinValue & nullable2.HasValue))
    {
      nullable2 = nullable1;
      if (!(nullable2.GetValueOrDefault() > (long) int.MaxValue & nullable2.HasValue))
        return (int) nullable1.Value;
    }
    return 0;
  }

  public uint ReadUInt32(string fieldName)
  {
    object token = (object) null;
    if (!this.ReadField(fieldName, out token))
      return 0;
    long? nullable1 = token as long?;
    if (!nullable1.HasValue)
    {
      uint result = 0;
      return token is string s && uint.TryParse(s, NumberStyles.Integer, (IFormatProvider) CultureInfo.InvariantCulture, out result) ? result : 0U;
    }
    long? nullable2 = nullable1;
    if (!(nullable2.GetValueOrDefault() < 0L & nullable2.HasValue))
    {
      nullable2 = nullable1;
      if (!(nullable2.GetValueOrDefault() > (long) uint.MaxValue & nullable2.HasValue))
        return (uint) nullable1.Value;
    }
    return 0;
  }

  public long ReadInt64(string fieldName)
  {
    object token = (object) null;
    if (!this.ReadField(fieldName, out token))
      return 0;
    long? nullable1 = token as long?;
    if (!nullable1.HasValue)
    {
      long result = 0;
      return token is string s && long.TryParse(s, NumberStyles.Integer, (IFormatProvider) CultureInfo.InvariantCulture, out result) ? result : 0L;
    }
    long? nullable2 = nullable1;
    if (!(nullable2.GetValueOrDefault() < long.MinValue & nullable2.HasValue))
    {
      nullable2 = nullable1;
      if (!(nullable2.GetValueOrDefault() > long.MaxValue & nullable2.HasValue))
        return nullable1.Value;
    }
    return 0;
  }

  public ulong ReadUInt64(string fieldName)
  {
    object token = (object) null;
    if (!this.ReadField(fieldName, out token))
      return 0;
    long? nullable1 = token as long?;
    if (!nullable1.HasValue)
    {
      ulong result = 0;
      return token is string s && ulong.TryParse(s, NumberStyles.Integer, (IFormatProvider) CultureInfo.InvariantCulture, out result) ? result : 0UL;
    }
    long? nullable2 = nullable1;
    return nullable2.GetValueOrDefault() < 0L & nullable2.HasValue ? 0UL : (ulong) nullable1.Value;
  }

  public float ReadFloat(string fieldName)
  {
    object token = (object) null;
    if (!this.ReadField(fieldName, out token))
      return 0.0f;
    double? nullable1 = token as double?;
    if (!nullable1.HasValue)
    {
      string str = token as string;
      float result = 0.0f;
      if (str != null && float.TryParse(str, NumberStyles.Float, (IFormatProvider) CultureInfo.InvariantCulture, out result))
        return result;
      if (str != null)
      {
        if (string.Equals(str, "Infinity", StringComparison.OrdinalIgnoreCase))
          return float.PositiveInfinity;
        if (string.Equals(str, "-Infinity", StringComparison.OrdinalIgnoreCase))
          return float.NegativeInfinity;
        if (string.Equals(str, "NaN", StringComparison.OrdinalIgnoreCase))
          return float.NaN;
      }
      long? nullable2 = token as long?;
      return !nullable2.HasValue ? 0.0f : (float) nullable2.Value;
    }
    float num = (float) nullable1.Value;
    return (double) num >= -3.4028234663852886E+38 && (double) num <= 3.4028234663852886E+38 ? (float) nullable1.Value : 0.0f;
  }

  public double ReadDouble(string fieldName)
  {
    object token = (object) null;
    if (!this.ReadField(fieldName, out token))
      return 0.0;
    double? nullable1 = token as double?;
    if (nullable1.HasValue)
      return nullable1.Value;
    string str = token as string;
    double result = 0.0;
    if (str != null && double.TryParse(str, NumberStyles.Float, (IFormatProvider) CultureInfo.InvariantCulture, out result))
      return result;
    if (str != null)
    {
      if (string.Equals(str, "Infinity", StringComparison.OrdinalIgnoreCase))
        return double.PositiveInfinity;
      if (string.Equals(str, "-Infinity", StringComparison.OrdinalIgnoreCase))
        return double.NegativeInfinity;
      if (string.Equals(str, "NaN", StringComparison.OrdinalIgnoreCase))
        return double.NaN;
    }
    long? nullable2 = token as long?;
    return !nullable2.HasValue ? 0.0 : (double) nullable2.Value;
  }

  public string ReadString(string fieldName)
  {
    object token = (object) null;
    if (!this.ReadField(fieldName, out token))
      return (string) null;
    if (!(token is string str))
      return (string) null;
    if (this.m_context.MaxStringLength > 0 && this.m_context.MaxStringLength < str.Length)
      throw new ServiceResultException(2148007936U /*0x80080000*/);
    return str;
  }

  public DateTime ReadDateTime(string fieldName)
  {
    object token = (object) null;
    if (!this.ReadField(fieldName, out token))
      return DateTime.MinValue;
    DateTime? nullable = token as DateTime?;
    if (nullable.HasValue)
      return !(nullable.Value >= this.m_dateTimeMaxJsonValue) ? nullable.Value : DateTime.MaxValue;
    if (!(token is string s))
      return DateTime.MinValue;
    DateTime dateTime = XmlConvert.ToDateTime(s, XmlDateTimeSerializationMode.Utc);
    return !(dateTime >= this.m_dateTimeMaxJsonValue) ? dateTime : DateTime.MaxValue;
  }

  public Uuid ReadGuid(string fieldName)
  {
    object token = (object) null;
    return !this.ReadField(fieldName, out token) || !(token is string text) ? Uuid.Empty : new Uuid(text);
  }

  public byte[] ReadByteString(string fieldName)
  {
    object token = (object) null;
    if (!this.ReadField(fieldName, out token))
      return (byte[]) null;
    switch (token)
    {
      case JsonDecoder.JTokenNullObject _:
        return (byte[]) null;
      case string s:
        byte[] numArray = Convert.FromBase64String(s);
        if (this.m_context.MaxByteStringLength > 0 && this.m_context.MaxByteStringLength < numArray.Length)
          throw new ServiceResultException(2148007936U /*0x80080000*/);
        return numArray;
      default:
        return Array.Empty<byte>();
    }
  }

  public XmlElement ReadXmlElement(string fieldName)
  {
    object token = (object) null;
    if (!this.ReadField(fieldName, out token))
      return (XmlElement) null;
    if (!(token is string s))
      return (XmlElement) null;
    byte[] bytes = Convert.FromBase64String(s);
    if (bytes == null || bytes.Length == 0)
      return (XmlElement) null;
    XmlDocument xmlDocument = new XmlDocument();
    using (XmlReader reader = XmlReader.Create((TextReader) new StringReader(Encoding.UTF8.GetString(bytes, 0, bytes.Length)), Utils.DefaultXmlReaderSettings()))
      xmlDocument.Load(reader);
    return xmlDocument.DocumentElement;
  }

  public NodeId ReadNodeId(string fieldName)
  {
    object token1 = (object) null;
    if (!this.ReadField(fieldName, out token1) || !(token1 is Dictionary<string, object> dictionary))
      return NodeId.Null;
    IdType idType = IdType.Numeric;
    ushort namespaceIndex = 0;
    try
    {
      this.m_stack.Push((object) dictionary);
      if (dictionary.ContainsKey("IdType"))
        idType = (IdType) this.ReadInt32("IdType");
      object token2 = (object) null;
      if (this.ReadField("Namespace", out token2))
      {
        long? nullable = token2 as long?;
        if (!nullable.HasValue)
        {
          if (token2 is string str)
            namespaceIndex = this.m_context.NamespaceUris.GetIndexOrAppend(str);
        }
        else if (nullable.Value >= 0L || nullable.Value < (long) ushort.MaxValue)
          namespaceIndex = (ushort) nullable.Value;
      }
      if (!dictionary.ContainsKey("Id"))
        return this.DefaultNodeId(idType, namespaceIndex);
      switch (idType)
      {
        case IdType.String:
          return new NodeId(this.ReadString("Id"), namespaceIndex);
        case IdType.Guid:
          return new NodeId((Guid) this.ReadGuid("Id"), namespaceIndex);
        case IdType.Opaque:
          return new NodeId(this.ReadByteString("Id"), namespaceIndex);
        default:
          return new NodeId(this.ReadUInt32("Id"), namespaceIndex);
      }
    }
    finally
    {
      this.m_stack.Pop();
    }
  }

  public ExpandedNodeId ReadExpandedNodeId(string fieldName)
  {
    object token1 = (object) null;
    if (!this.ReadField(fieldName, out token1) || !(token1 is Dictionary<string, object> dictionary))
      return ExpandedNodeId.Null;
    IdType idType = IdType.Numeric;
    ushort namespaceIndex = 0;
    string namespaceUri = (string) null;
    uint serverIndex = 0;
    try
    {
      this.m_stack.Push((object) dictionary);
      if (dictionary.ContainsKey("IdType"))
        idType = (IdType) this.ReadInt32("IdType");
      object token2 = (object) null;
      if (this.ReadField("Namespace", out token2))
      {
        long? nullable = token2 as long?;
        if (!nullable.HasValue)
          namespaceUri = token2 as string;
        else if (nullable.Value >= 0L || nullable.Value < (long) ushort.MaxValue)
          namespaceIndex = (ushort) nullable.Value;
      }
      if (dictionary.ContainsKey("ServerUri"))
        serverIndex = this.ReadUInt32("ServerUri");
      if (!dictionary.ContainsKey("Id"))
        return new ExpandedNodeId(this.DefaultNodeId(idType, namespaceIndex), namespaceUri, serverIndex);
      switch (idType)
      {
        case IdType.String:
          return new ExpandedNodeId((object) this.ReadString("Id"), namespaceIndex, namespaceUri, serverIndex);
        case IdType.Guid:
          return new ExpandedNodeId((object) this.ReadGuid("Id"), namespaceIndex, namespaceUri, serverIndex);
        case IdType.Opaque:
          return new ExpandedNodeId((object) this.ReadByteString("Id"), namespaceIndex, namespaceUri, serverIndex);
        default:
          return new ExpandedNodeId((object) this.ReadUInt32("Id"), namespaceIndex, namespaceUri, serverIndex);
      }
    }
    finally
    {
      this.m_stack.Pop();
    }
  }

  public StatusCode ReadStatusCode(string fieldName)
  {
    object token;
    if (!this.ReadField(fieldName, out token))
      return (StatusCode) 0U;
    bool flag = this.PushStructure(fieldName);
    try
    {
      return this.ReadField("Code", out token) ? (StatusCode) this.ReadUInt32("Code") : (StatusCode) this.ReadUInt32((string) null);
    }
    finally
    {
      if (flag)
        this.Pop();
    }
  }

  public DiagnosticInfo ReadDiagnosticInfo(string fieldName)
  {
    return this.ReadDiagnosticInfo(fieldName, 0);
  }

  public QualifiedName ReadQualifiedName(string fieldName)
  {
    object token1 = (object) null;
    if (!this.ReadField(fieldName, out token1) || !(token1 is Dictionary<string, object> dictionary))
      return QualifiedName.Null;
    ushort namespaceIndex = 0;
    string name = (string) null;
    try
    {
      this.m_stack.Push((object) dictionary);
      if (dictionary.ContainsKey("Name"))
        name = this.ReadString("Name");
      object token2 = (object) null;
      if (this.ReadField("Uri", out token2))
      {
        long? nullable = token2 as long?;
        if (!nullable.HasValue)
        {
          if (token2 is string str)
            namespaceIndex = this.m_context.NamespaceUris.GetIndexOrAppend(str);
        }
        else
        {
          if (nullable.Value < 0L)
          {
            if (nullable.Value >= (long) ushort.MaxValue)
              goto label_13;
          }
          namespaceIndex = (ushort) nullable.Value;
        }
      }
    }
    finally
    {
      this.m_stack.Pop();
    }
label_13:
    return new QualifiedName(name, namespaceIndex);
  }

  public LocalizedText ReadLocalizedText(string fieldName)
  {
    object token = (object) null;
    if (!this.ReadField(fieldName, out token))
      return LocalizedText.Null;
    string locale = (string) null;
    string text1 = (string) null;
    switch (token)
    {
      case Dictionary<string, object> dictionary:
        try
        {
          this.m_stack.Push((object) dictionary);
          if (dictionary.ContainsKey("Locale"))
            locale = this.ReadString("Locale");
          if (dictionary.ContainsKey("Text"))
            text1 = this.ReadString("Text");
        }
        finally
        {
          this.m_stack.Pop();
        }
        return new LocalizedText(locale, text1);
      case string text2:
        return new LocalizedText(text2);
      default:
        return LocalizedText.Null;
    }
  }

  public Variant ReadVariant(string fieldName)
  {
    object token = (object) null;
    if (!this.ReadField(fieldName, out token) || !(token is Dictionary<string, object> dictionary))
      return Variant.Null;
    this.CheckAndIncrementNestingLevel();
    try
    {
      this.m_stack.Push((object) dictionary);
      BuiltInType builtInType = (BuiltInType) this.ReadByte("Type");
      if (!(this.m_stack.Peek() as Dictionary<string, object>).TryGetValue("Body", out token))
        return Variant.Null;
      Variant variant;
      switch (token)
      {
        case Array _:
          variant = this.ReadVariantBody("Body", builtInType);
          break;
        case List<object> _:
          variant = this.ReadVariantArrayBody("Body", builtInType);
          break;
        default:
          return this.ReadVariantBody("Body", builtInType);
      }
      Int32Collection int32Collection = this.ReadInt32Array("Dimensions");
      if (variant.Value is Array && int32Collection != null && int32Collection.Count > 1)
        variant = new Variant(new Matrix((Array) variant.Value, builtInType, int32Collection.ToArray()));
      return variant;
    }
    finally
    {
      --this.m_nestingLevel;
      this.m_stack.Pop();
    }
  }

  public DataValue ReadDataValue(string fieldName)
  {
    object token = (object) null;
    if (!this.ReadField(fieldName, out token))
      return (DataValue) null;
    if (!(token is Dictionary<string, object> dictionary))
      return (DataValue) null;
    DataValue dataValue = new DataValue();
    try
    {
      this.m_stack.Push((object) dictionary);
      dataValue.WrappedValue = this.ReadVariant("Value");
      dataValue.StatusCode = this.ReadStatusCode("StatusCode");
      dataValue.SourceTimestamp = this.ReadDateTime("SourceTimestamp");
      dataValue.SourcePicoseconds = this.ReadUInt16("SourcePicoseconds");
      dataValue.ServerTimestamp = this.ReadDateTime("ServerTimestamp");
      dataValue.ServerPicoseconds = this.ReadUInt16("ServerPicoseconds");
    }
    finally
    {
      this.m_stack.Pop();
    }
    return dataValue;
  }

  public ExtensionObject ReadExtensionObject(string fieldName)
  {
    ExtensionObject extensionObject = ExtensionObject.Null;
    object token = (object) null;
    if (!this.ReadField(fieldName, out token))
      return extensionObject;
    if (!(token is Dictionary<string, object> dictionary))
      return extensionObject;
    try
    {
      this.m_stack.Push((object) dictionary);
      ExpandedNodeId expandedNodeId = this.ReadExpandedNodeId("TypeId");
      ExpandedNodeId nodeId = expandedNodeId.IsAbsolute ? expandedNodeId : NodeId.ToExpandedNodeId(expandedNodeId.InnerNodeId, this.m_context.NamespaceUris);
      if (!NodeId.IsNull(expandedNodeId) && NodeId.IsNull(nodeId))
        Utils.LogWarning("Cannot de-serialized extension objects if the NamespaceUri is not in the NamespaceTable: Type = {0}", (object) expandedNodeId);
      else
        expandedNodeId = nodeId;
      switch (this.ReadByte("Encoding"))
      {
        case 1:
          byte[] numArray = this.ReadByteString("Body");
          return new ExtensionObject(expandedNodeId, (object) (numArray ?? Array.Empty<byte>()));
        case 2:
          XmlElement body1 = this.ReadXmlElement("Body");
          return body1 == null ? extensionObject : new ExtensionObject(expandedNodeId, (object) body1);
        case 4:
          string body2 = this.ReadString("Body");
          return string.IsNullOrEmpty(body2) ? extensionObject : new ExtensionObject(expandedNodeId, (object) body2);
        default:
          Type systemType = this.m_context.Factory.GetSystemType(expandedNodeId);
          if (systemType != (Type) null)
          {
            IEncodeable body3 = this.ReadEncodeable("Body", systemType, expandedNodeId);
            return body3 == null ? extensionObject : new ExtensionObject(expandedNodeId, (object) body3);
          }
          using (MemoryStream memoryStream = new MemoryStream())
          {
            using (StreamWriter streamWriter = new StreamWriter((Stream) memoryStream))
            {
              using (JsonTextWriter writer = new JsonTextWriter((TextWriter) streamWriter))
                this.EncodeAsJson(writer, token);
            }
            return new ExtensionObject(expandedNodeId, (object) memoryStream.ToArray());
          }
      }
    }
    finally
    {
      this.m_stack.Pop();
    }
  }

  public IEncodeable ReadEncodeable(
    string fieldName,
    Type systemType,
    ExpandedNodeId encodeableTypeId = null)
  {
    if (systemType == (Type) null)
      throw new ArgumentNullException(nameof (systemType));
    object token = (object) null;
    if (!this.ReadField(fieldName, out token))
      return (IEncodeable) null;
    if (!(Activator.CreateInstance(systemType) is IEncodeable instance))
      throw new ServiceResultException(2147942400U /*0x80070000*/, Utils.Format("Type does not support IEncodeable interface: '{0}'", (object) systemType.FullName));
    if (encodeableTypeId != (object) null && instance is IComplexTypeInstance complexTypeInstance)
      complexTypeInstance.TypeId = encodeableTypeId;
    this.CheckAndIncrementNestingLevel();
    try
    {
      this.m_stack.Push(token);
      instance.Decode((IDecoder) this);
    }
    finally
    {
      this.m_stack.Pop();
      --this.m_nestingLevel;
    }
    return instance;
  }

  public Enum ReadEnumerated(string fieldName, Type enumType)
  {
    return !(enumType == (Type) null) ? (Enum) Enum.ToObject(enumType, this.ReadInt32(fieldName)) : throw new ArgumentNullException(nameof (enumType));
  }

  public BooleanCollection ReadBooleanArray(string fieldName)
  {
    BooleanCollection booleanCollection = new BooleanCollection();
    List<object> array = (List<object>) null;
    if (!this.ReadArrayField(fieldName, out array))
      return booleanCollection;
    for (int index = 0; index < array.Count; ++index)
    {
      try
      {
        this.m_stack.Push(array[index]);
        booleanCollection.Add(this.ReadBoolean((string) null));
      }
      finally
      {
        this.m_stack.Pop();
      }
    }
    return booleanCollection;
  }

  public SByteCollection ReadSByteArray(string fieldName)
  {
    SByteCollection sbyteCollection = new SByteCollection();
    List<object> array = (List<object>) null;
    if (!this.ReadArrayField(fieldName, out array))
      return sbyteCollection;
    for (int index = 0; index < array.Count; ++index)
    {
      try
      {
        this.m_stack.Push(array[index]);
        sbyteCollection.Add(this.ReadSByte((string) null));
      }
      finally
      {
        this.m_stack.Pop();
      }
    }
    return sbyteCollection;
  }

  public ByteCollection ReadByteArray(string fieldName)
  {
    ByteCollection byteCollection = new ByteCollection();
    List<object> array = (List<object>) null;
    string s = this.ReadString(fieldName);
    if (s != null)
      return (ByteCollection) Convert.FromBase64String(s);
    if (!this.ReadArrayField(fieldName, out array))
      return byteCollection;
    for (int index = 0; index < array.Count; ++index)
    {
      try
      {
        this.m_stack.Push(array[index]);
        byteCollection.Add(this.ReadByte((string) null));
      }
      finally
      {
        this.m_stack.Pop();
      }
    }
    return byteCollection;
  }

  public Int16Collection ReadInt16Array(string fieldName)
  {
    Int16Collection int16Collection = new Int16Collection();
    List<object> array = (List<object>) null;
    if (!this.ReadArrayField(fieldName, out array))
      return int16Collection;
    for (int index = 0; index < array.Count; ++index)
    {
      try
      {
        this.m_stack.Push(array[index]);
        int16Collection.Add(this.ReadInt16((string) null));
      }
      finally
      {
        this.m_stack.Pop();
      }
    }
    return int16Collection;
  }

  public UInt16Collection ReadUInt16Array(string fieldName)
  {
    UInt16Collection uint16Collection = new UInt16Collection();
    List<object> array = (List<object>) null;
    if (!this.ReadArrayField(fieldName, out array))
      return uint16Collection;
    for (int index = 0; index < array.Count; ++index)
    {
      try
      {
        this.m_stack.Push(array[index]);
        uint16Collection.Add(this.ReadUInt16((string) null));
      }
      finally
      {
        this.m_stack.Pop();
      }
    }
    return uint16Collection;
  }

  public Int32Collection ReadInt32Array(string fieldName)
  {
    Int32Collection int32Collection = new Int32Collection();
    List<object> array = (List<object>) null;
    if (!this.ReadArrayField(fieldName, out array))
      return int32Collection;
    for (int index = 0; index < array.Count; ++index)
    {
      try
      {
        this.m_stack.Push(array[index]);
        int32Collection.Add(this.ReadInt32((string) null));
      }
      finally
      {
        this.m_stack.Pop();
      }
    }
    return int32Collection;
  }

  public UInt32Collection ReadUInt32Array(string fieldName)
  {
    UInt32Collection uint32Collection = new UInt32Collection();
    List<object> array = (List<object>) null;
    if (!this.ReadArrayField(fieldName, out array))
      return uint32Collection;
    for (int index = 0; index < array.Count; ++index)
    {
      try
      {
        this.m_stack.Push(array[index]);
        uint32Collection.Add(this.ReadUInt32((string) null));
      }
      finally
      {
        this.m_stack.Pop();
      }
    }
    return uint32Collection;
  }

  public Int64Collection ReadInt64Array(string fieldName)
  {
    Int64Collection int64Collection = new Int64Collection();
    List<object> array = (List<object>) null;
    if (!this.ReadArrayField(fieldName, out array))
      return int64Collection;
    for (int index = 0; index < array.Count; ++index)
    {
      try
      {
        this.m_stack.Push(array[index]);
        int64Collection.Add(this.ReadInt64((string) null));
      }
      finally
      {
        this.m_stack.Pop();
      }
    }
    return int64Collection;
  }

  public UInt64Collection ReadUInt64Array(string fieldName)
  {
    UInt64Collection uint64Collection = new UInt64Collection();
    List<object> array = (List<object>) null;
    if (!this.ReadArrayField(fieldName, out array))
      return uint64Collection;
    for (int index = 0; index < array.Count; ++index)
    {
      try
      {
        this.m_stack.Push(array[index]);
        uint64Collection.Add(this.ReadUInt64((string) null));
      }
      finally
      {
        this.m_stack.Pop();
      }
    }
    return uint64Collection;
  }

  public FloatCollection ReadFloatArray(string fieldName)
  {
    FloatCollection floatCollection = new FloatCollection();
    List<object> array = (List<object>) null;
    if (!this.ReadArrayField(fieldName, out array))
      return floatCollection;
    for (int index = 0; index < array.Count; ++index)
    {
      try
      {
        this.m_stack.Push(array[index]);
        floatCollection.Add(this.ReadFloat((string) null));
      }
      finally
      {
        this.m_stack.Pop();
      }
    }
    return floatCollection;
  }

  public DoubleCollection ReadDoubleArray(string fieldName)
  {
    DoubleCollection doubleCollection = new DoubleCollection();
    List<object> array = (List<object>) null;
    if (!this.ReadArrayField(fieldName, out array))
      return doubleCollection;
    for (int index = 0; index < array.Count; ++index)
    {
      try
      {
        this.m_stack.Push(array[index]);
        doubleCollection.Add(this.ReadDouble((string) null));
      }
      finally
      {
        this.m_stack.Pop();
      }
    }
    return doubleCollection;
  }

  public StringCollection ReadStringArray(string fieldName)
  {
    StringCollection stringCollection = new StringCollection();
    List<object> array = (List<object>) null;
    if (!this.ReadArrayField(fieldName, out array))
      return stringCollection;
    for (int index = 0; index < array.Count; ++index)
    {
      try
      {
        this.m_stack.Push(array[index]);
        stringCollection.Add(this.ReadString((string) null));
      }
      finally
      {
        this.m_stack.Pop();
      }
    }
    return stringCollection;
  }

  public DateTimeCollection ReadDateTimeArray(string fieldName)
  {
    DateTimeCollection dateTimeCollection = new DateTimeCollection();
    List<object> array = (List<object>) null;
    if (!this.ReadArrayField(fieldName, out array))
      return dateTimeCollection;
    for (int index = 0; index < array.Count; ++index)
    {
      try
      {
        this.m_stack.Push(array[index]);
        dateTimeCollection.Add(this.ReadDateTime((string) null));
      }
      finally
      {
        this.m_stack.Pop();
      }
    }
    return dateTimeCollection;
  }

  public UuidCollection ReadGuidArray(string fieldName)
  {
    UuidCollection uuidCollection = new UuidCollection();
    List<object> array = (List<object>) null;
    if (!this.ReadArrayField(fieldName, out array))
      return uuidCollection;
    for (int index = 0; index < array.Count; ++index)
    {
      try
      {
        this.m_stack.Push(array[index]);
        Uuid uuid = this.ReadGuid((string) null);
        uuidCollection.Add(uuid);
      }
      finally
      {
        this.m_stack.Pop();
      }
    }
    return uuidCollection;
  }

  public ByteStringCollection ReadByteStringArray(string fieldName)
  {
    ByteStringCollection stringCollection = new ByteStringCollection();
    List<object> array = (List<object>) null;
    if (!this.ReadArrayField(fieldName, out array))
      return stringCollection;
    for (int index = 0; index < array.Count; ++index)
    {
      try
      {
        this.m_stack.Push(array[index]);
        byte[] numArray = this.ReadByteString((string) null);
        stringCollection.Add(numArray);
      }
      finally
      {
        this.m_stack.Pop();
      }
    }
    return stringCollection;
  }

  public XmlElementCollection ReadXmlElementArray(string fieldName)
  {
    XmlElementCollection elementCollection = new XmlElementCollection();
    List<object> array = (List<object>) null;
    if (!this.ReadArrayField(fieldName, out array))
      return elementCollection;
    for (int index = 0; index < array.Count; ++index)
    {
      try
      {
        this.m_stack.Push(array[index]);
        XmlElement xmlElement = this.ReadXmlElement((string) null);
        elementCollection.Add(xmlElement);
      }
      finally
      {
        this.m_stack.Pop();
      }
    }
    return elementCollection;
  }

  public NodeIdCollection ReadNodeIdArray(string fieldName)
  {
    NodeIdCollection nodeIdCollection = new NodeIdCollection();
    List<object> array = (List<object>) null;
    if (!this.ReadArrayField(fieldName, out array))
      return nodeIdCollection;
    for (int index = 0; index < array.Count; ++index)
    {
      try
      {
        this.m_stack.Push(array[index]);
        NodeId nodeId = this.ReadNodeId((string) null);
        nodeIdCollection.Add(nodeId);
      }
      finally
      {
        this.m_stack.Pop();
      }
    }
    return nodeIdCollection;
  }

  public ExpandedNodeIdCollection ReadExpandedNodeIdArray(string fieldName)
  {
    ExpandedNodeIdCollection nodeIdCollection = new ExpandedNodeIdCollection();
    List<object> array = (List<object>) null;
    if (!this.ReadArrayField(fieldName, out array))
      return nodeIdCollection;
    for (int index = 0; index < array.Count; ++index)
    {
      try
      {
        this.m_stack.Push(array[index]);
        ExpandedNodeId expandedNodeId = this.ReadExpandedNodeId((string) null);
        nodeIdCollection.Add(expandedNodeId);
      }
      finally
      {
        this.m_stack.Pop();
      }
    }
    return nodeIdCollection;
  }

  public StatusCodeCollection ReadStatusCodeArray(string fieldName)
  {
    StatusCodeCollection statusCodeCollection = new StatusCodeCollection();
    List<object> array = (List<object>) null;
    if (!this.ReadArrayField(fieldName, out array))
      return statusCodeCollection;
    for (int index = 0; index < array.Count; ++index)
    {
      try
      {
        this.m_stack.Push(array[index]);
        StatusCode statusCode = this.ReadStatusCode((string) null);
        statusCodeCollection.Add(statusCode);
      }
      finally
      {
        this.m_stack.Pop();
      }
    }
    return statusCodeCollection;
  }

  public DiagnosticInfoCollection ReadDiagnosticInfoArray(string fieldName)
  {
    DiagnosticInfoCollection diagnosticInfoCollection = new DiagnosticInfoCollection();
    List<object> array = (List<object>) null;
    if (!this.ReadArrayField(fieldName, out array))
      return diagnosticInfoCollection;
    for (int index = 0; index < array.Count; ++index)
    {
      try
      {
        this.m_stack.Push(array[index]);
        DiagnosticInfo diagnosticInfo = this.ReadDiagnosticInfo((string) null);
        diagnosticInfoCollection.Add(diagnosticInfo);
      }
      finally
      {
        this.m_stack.Pop();
      }
    }
    return diagnosticInfoCollection;
  }

  public QualifiedNameCollection ReadQualifiedNameArray(string fieldName)
  {
    QualifiedNameCollection qualifiedNameCollection = new QualifiedNameCollection();
    List<object> array = (List<object>) null;
    if (!this.ReadArrayField(fieldName, out array))
      return qualifiedNameCollection;
    for (int index = 0; index < array.Count; ++index)
    {
      try
      {
        this.m_stack.Push(array[index]);
        QualifiedName qualifiedName = this.ReadQualifiedName((string) null);
        qualifiedNameCollection.Add(qualifiedName);
      }
      finally
      {
        this.m_stack.Pop();
      }
    }
    return qualifiedNameCollection;
  }

  public LocalizedTextCollection ReadLocalizedTextArray(string fieldName)
  {
    LocalizedTextCollection localizedTextCollection = new LocalizedTextCollection();
    List<object> array = (List<object>) null;
    if (!this.ReadArrayField(fieldName, out array))
      return localizedTextCollection;
    for (int index = 0; index < array.Count; ++index)
    {
      try
      {
        this.m_stack.Push(array[index]);
        LocalizedText localizedText = this.ReadLocalizedText((string) null);
        localizedTextCollection.Add(localizedText);
      }
      finally
      {
        this.m_stack.Pop();
      }
    }
    return localizedTextCollection;
  }

  public VariantCollection ReadVariantArray(string fieldName)
  {
    VariantCollection variantCollection = new VariantCollection();
    List<object> array = (List<object>) null;
    if (!this.ReadArrayField(fieldName, out array))
      return variantCollection;
    for (int index = 0; index < array.Count; ++index)
    {
      try
      {
        this.m_stack.Push(array[index]);
        Variant variant = this.ReadVariant((string) null);
        variantCollection.Add(variant);
      }
      finally
      {
        this.m_stack.Pop();
      }
    }
    return variantCollection;
  }

  public DataValueCollection ReadDataValueArray(string fieldName)
  {
    DataValueCollection dataValueCollection = new DataValueCollection();
    List<object> array = (List<object>) null;
    if (!this.ReadArrayField(fieldName, out array))
      return dataValueCollection;
    for (int index = 0; index < array.Count; ++index)
    {
      try
      {
        this.m_stack.Push(array[index]);
        DataValue dataValue = this.ReadDataValue((string) null);
        dataValueCollection.Add(dataValue);
      }
      finally
      {
        this.m_stack.Pop();
      }
    }
    return dataValueCollection;
  }

  public ExtensionObjectCollection ReadExtensionObjectArray(string fieldName)
  {
    ExtensionObjectCollection objectCollection = new ExtensionObjectCollection();
    List<object> array = (List<object>) null;
    if (!this.ReadArrayField(fieldName, out array))
      return objectCollection;
    for (int index = 0; index < array.Count; ++index)
    {
      try
      {
        this.m_stack.Push(array[index]);
        ExtensionObject extensionObject = this.ReadExtensionObject((string) null);
        objectCollection.Add(extensionObject);
      }
      finally
      {
        this.m_stack.Pop();
      }
    }
    return objectCollection;
  }

  public Array ReadEncodeableArray(
    string fieldName,
    Type systemType,
    ExpandedNodeId encodeableTypeId = null)
  {
    if (systemType == (Type) null)
      throw new ArgumentNullException(nameof (systemType));
    List<object> array = (List<object>) null;
    if (!this.ReadArrayField(fieldName, out array))
      return Array.CreateInstance(systemType, 0);
    Array instance = Array.CreateInstance(systemType, array.Count);
    for (int index = 0; index < array.Count; ++index)
    {
      try
      {
        this.m_stack.Push(array[index]);
        IEncodeable encodeable = this.ReadEncodeable((string) null, systemType, encodeableTypeId);
        instance.SetValue((object) encodeable, index);
      }
      finally
      {
        this.m_stack.Pop();
      }
    }
    return instance;
  }

  public Array ReadEnumeratedArray(string fieldName, Type enumType)
  {
    if (enumType == (Type) null)
      throw new ArgumentNullException(nameof (enumType));
    List<object> array = (List<object>) null;
    if (!this.ReadArrayField(fieldName, out array))
      return Array.CreateInstance(enumType, 0);
    Array instance = Array.CreateInstance(enumType, array.Count);
    for (int index = 0; index < array.Count; ++index)
    {
      try
      {
        this.m_stack.Push(array[index]);
        Enum @enum = this.ReadEnumerated((string) null, enumType);
        instance.SetValue((object) @enum, index);
      }
      finally
      {
        this.m_stack.Pop();
      }
    }
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
      List<object> array;
      if (!this.ReadArrayField(fieldName, out array))
        return (Array) null;
      List<object> elements = new List<object>();
      List<int> dimensions = new List<int>();
      if (builtInType == BuiltInType.Enumeration || builtInType == BuiltInType.Variant || builtInType == BuiltInType.Null)
        this.DetermineIEncodeableSystemType(ref systemType, encodeableTypeId);
      this.ReadMatrixPart(fieldName, array, builtInType, ref elements, ref dimensions, 0, systemType, encodeableTypeId);
      if (dimensions.Count == 0)
        dimensions = ((IEnumerable<int>) new int[valueRank]).ToList<int>();
      else if (dimensions.Count < 2)
        throw ServiceResultException.Create(2147942400U /*0x80070000*/, "The ValueRank {0} of the decoded array doesn't match the desired ValueRank {1}.", (object) dimensions.Count, (object) valueRank);
      Matrix matrix;
      switch (builtInType)
      {
        case BuiltInType.Boolean:
          matrix = new Matrix((Array) elements.Cast<bool>().ToArray<bool>(), builtInType, dimensions.ToArray());
          break;
        case BuiltInType.SByte:
          matrix = new Matrix((Array) elements.Cast<sbyte>().ToArray<sbyte>(), builtInType, dimensions.ToArray());
          break;
        case BuiltInType.Byte:
          matrix = new Matrix((Array) elements.Cast<byte>().ToArray<byte>(), builtInType, dimensions.ToArray());
          break;
        case BuiltInType.Int16:
          matrix = new Matrix((Array) elements.Cast<short>().ToArray<short>(), builtInType, dimensions.ToArray());
          break;
        case BuiltInType.UInt16:
          matrix = new Matrix((Array) elements.Cast<ushort>().ToArray<ushort>(), builtInType, dimensions.ToArray());
          break;
        case BuiltInType.Int32:
          matrix = new Matrix((Array) elements.Cast<int>().ToArray<int>(), builtInType, dimensions.ToArray());
          break;
        case BuiltInType.UInt32:
          matrix = new Matrix((Array) elements.Cast<uint>().ToArray<uint>(), builtInType, dimensions.ToArray());
          break;
        case BuiltInType.Int64:
          matrix = new Matrix((Array) elements.Cast<long>().ToArray<long>(), builtInType, dimensions.ToArray());
          break;
        case BuiltInType.UInt64:
          matrix = new Matrix((Array) elements.Cast<ulong>().ToArray<ulong>(), builtInType, dimensions.ToArray());
          break;
        case BuiltInType.Float:
          matrix = new Matrix((Array) elements.Cast<float>().ToArray<float>(), builtInType, dimensions.ToArray());
          break;
        case BuiltInType.Double:
          matrix = new Matrix((Array) elements.Cast<double>().ToArray<double>(), builtInType, dimensions.ToArray());
          break;
        case BuiltInType.String:
          matrix = new Matrix((Array) elements.Cast<string>().ToArray<string>(), builtInType, dimensions.ToArray());
          break;
        case BuiltInType.DateTime:
          matrix = new Matrix((Array) elements.Cast<DateTime>().ToArray<DateTime>(), builtInType, dimensions.ToArray());
          break;
        case BuiltInType.Guid:
          matrix = new Matrix((Array) elements.Cast<Uuid>().ToArray<Uuid>(), builtInType, dimensions.ToArray());
          break;
        case BuiltInType.ByteString:
          matrix = new Matrix((Array) elements.Cast<byte[]>().ToArray<byte[]>(), builtInType, dimensions.ToArray());
          break;
        case BuiltInType.XmlElement:
          matrix = new Matrix((Array) elements.Cast<XmlElement>().ToArray<XmlElement>(), builtInType, dimensions.ToArray());
          break;
        case BuiltInType.NodeId:
          matrix = new Matrix((Array) elements.Cast<NodeId>().ToArray<NodeId>(), builtInType, dimensions.ToArray());
          break;
        case BuiltInType.ExpandedNodeId:
          matrix = new Matrix((Array) elements.Cast<ExpandedNodeId>().ToArray<ExpandedNodeId>(), builtInType, dimensions.ToArray());
          break;
        case BuiltInType.StatusCode:
          matrix = new Matrix((Array) elements.Cast<StatusCode>().ToArray<StatusCode>(), builtInType, dimensions.ToArray());
          break;
        case BuiltInType.QualifiedName:
          matrix = new Matrix((Array) elements.Cast<QualifiedName>().ToArray<QualifiedName>(), builtInType, dimensions.ToArray());
          break;
        case BuiltInType.LocalizedText:
          matrix = new Matrix((Array) elements.Cast<LocalizedText>().ToArray<LocalizedText>(), builtInType, dimensions.ToArray());
          break;
        case BuiltInType.ExtensionObject:
          matrix = new Matrix((Array) elements.Cast<ExtensionObject>().ToArray<ExtensionObject>(), builtInType, dimensions.ToArray());
          break;
        case BuiltInType.DataValue:
          matrix = new Matrix((Array) elements.Cast<DataValue>().ToArray<DataValue>(), builtInType, dimensions.ToArray());
          break;
        case BuiltInType.Variant:
          if (this.DetermineIEncodeableSystemType(ref systemType, encodeableTypeId))
          {
            Array instance = Array.CreateInstance(systemType, elements.Count);
            for (int index = 0; index < elements.Count; ++index)
              instance.SetValue(Convert.ChangeType(elements[index], systemType), index);
            matrix = new Matrix(instance, builtInType, dimensions.ToArray());
            break;
          }
          matrix = new Matrix((Array) elements.Cast<Variant>().ToArray<Variant>(), builtInType, dimensions.ToArray());
          break;
        case BuiltInType.DiagnosticInfo:
          matrix = new Matrix((Array) elements.Cast<DiagnosticInfo>().ToArray<DiagnosticInfo>(), builtInType, dimensions.ToArray());
          break;
        case BuiltInType.Enumeration:
          if ((object) systemType != null && systemType.IsEnum)
          {
            Array instance = Array.CreateInstance(systemType, elements.Count);
            int num = 0;
            foreach (object obj in elements)
              instance.SetValue(Convert.ChangeType(obj, systemType), num++);
            matrix = new Matrix(instance, builtInType, dimensions.ToArray());
            break;
          }
          matrix = new Matrix((Array) elements.Cast<int>().ToArray<int>(), builtInType, dimensions.ToArray());
          break;
        default:
          if (this.DetermineIEncodeableSystemType(ref systemType, encodeableTypeId))
          {
            Array instance = Array.CreateInstance(systemType, elements.Count);
            for (int index = 0; index < elements.Count; ++index)
              instance.SetValue(Convert.ChangeType(elements[index], systemType), index);
            matrix = new Matrix(instance, builtInType, dimensions.ToArray());
            break;
          }
          throw ServiceResultException.Create(2147942400U /*0x80070000*/, "Cannot decode unknown type in Array object with BuiltInType: {0}.", (object) builtInType);
      }
      return matrix.ToArray();
    }
  }

  public bool PushStructure(string fieldName)
  {
    object token = (object) null;
    if (!this.ReadField(fieldName, out token) || token == null)
      return false;
    this.m_stack.Push(token);
    return true;
  }

  public bool PushArray(string fieldName, int index)
  {
    List<object> array = (List<object>) null;
    if (!this.ReadArrayField(fieldName, out array) || index >= array.Count)
      return false;
    this.m_stack.Push(array[index]);
    return true;
  }

  public void Pop() => this.m_stack.Pop();

  private DiagnosticInfo ReadDiagnosticInfo(string fieldName, int depth)
  {
    object token = (object) null;
    if (!this.ReadField(fieldName, out token))
      return (DiagnosticInfo) null;
    if (!(token is Dictionary<string, object> dictionary))
      return (DiagnosticInfo) null;
    if (depth >= DiagnosticInfo.MaxInnerDepth)
      throw ServiceResultException.Create(2148007936U /*0x80080000*/, "Maximum nesting level of InnerDiagnosticInfo was exceeded");
    this.CheckAndIncrementNestingLevel();
    try
    {
      this.m_stack.Push((object) dictionary);
      DiagnosticInfo diagnosticInfo = new DiagnosticInfo();
      bool flag = false;
      if (dictionary.ContainsKey("SymbolicId"))
      {
        diagnosticInfo.SymbolicId = this.ReadInt32("SymbolicId");
        flag = true;
      }
      if (dictionary.ContainsKey("NamespaceUri"))
      {
        diagnosticInfo.NamespaceUri = this.ReadInt32("NamespaceUri");
        flag = true;
      }
      if (dictionary.ContainsKey("Locale"))
      {
        diagnosticInfo.Locale = this.ReadInt32("Locale");
        flag = true;
      }
      if (dictionary.ContainsKey("LocalizedText"))
      {
        diagnosticInfo.LocalizedText = this.ReadInt32("LocalizedText");
        flag = true;
      }
      if (dictionary.ContainsKey("AdditionalInfo"))
      {
        diagnosticInfo.AdditionalInfo = this.ReadString("AdditionalInfo");
        flag = true;
      }
      if (dictionary.ContainsKey("InnerStatusCode"))
      {
        diagnosticInfo.InnerStatusCode = this.ReadStatusCode("InnerStatusCode");
        flag = true;
      }
      if (dictionary.ContainsKey("InnerDiagnosticInfo") && depth < DiagnosticInfo.MaxInnerDepth)
      {
        diagnosticInfo.InnerDiagnosticInfo = this.ReadDiagnosticInfo("InnerDiagnosticInfo", depth + 1);
        flag = true;
      }
      return flag ? diagnosticInfo : (DiagnosticInfo) null;
    }
    finally
    {
      --this.m_nestingLevel;
      this.m_stack.Pop();
    }
  }

  private bool DetermineIEncodeableSystemType(ref Type systemType, ExpandedNodeId encodeableTypeId)
  {
    if (encodeableTypeId != (object) null && systemType == (Type) null)
      systemType = this.Context.Factory.GetSystemType(encodeableTypeId);
    return typeof (IEncodeable).IsAssignableFrom(systemType);
  }

  private Variant ReadVariantBody(string fieldName, BuiltInType type)
  {
    switch (type)
    {
      case BuiltInType.Boolean:
        return new Variant((object) this.ReadBoolean(fieldName), TypeInfo.Scalars.Boolean);
      case BuiltInType.SByte:
        return new Variant((object) this.ReadSByte(fieldName), TypeInfo.Scalars.SByte);
      case BuiltInType.Byte:
        return new Variant((object) this.ReadByte(fieldName), TypeInfo.Scalars.Byte);
      case BuiltInType.Int16:
        return new Variant((object) this.ReadInt16(fieldName), TypeInfo.Scalars.Int16);
      case BuiltInType.UInt16:
        return new Variant((object) this.ReadUInt16(fieldName), TypeInfo.Scalars.UInt16);
      case BuiltInType.Int32:
        return new Variant((object) this.ReadInt32(fieldName), TypeInfo.Scalars.Int32);
      case BuiltInType.UInt32:
        return new Variant((object) this.ReadUInt32(fieldName), TypeInfo.Scalars.UInt32);
      case BuiltInType.Int64:
        return new Variant((object) this.ReadInt64(fieldName), TypeInfo.Scalars.Int64);
      case BuiltInType.UInt64:
        return new Variant((object) this.ReadUInt64(fieldName), TypeInfo.Scalars.UInt64);
      case BuiltInType.Float:
        return new Variant((object) this.ReadFloat(fieldName), TypeInfo.Scalars.Float);
      case BuiltInType.Double:
        return new Variant((object) this.ReadDouble(fieldName), TypeInfo.Scalars.Double);
      case BuiltInType.String:
        return new Variant((object) this.ReadString(fieldName), TypeInfo.Scalars.String);
      case BuiltInType.DateTime:
        return new Variant((object) this.ReadDateTime(fieldName), TypeInfo.Scalars.DateTime);
      case BuiltInType.Guid:
        return new Variant((object) this.ReadGuid(fieldName), TypeInfo.Scalars.Guid);
      case BuiltInType.ByteString:
        return new Variant((object) this.ReadByteString(fieldName), TypeInfo.Scalars.ByteString);
      case BuiltInType.XmlElement:
        return new Variant((object) this.ReadXmlElement(fieldName), TypeInfo.Scalars.XmlElement);
      case BuiltInType.NodeId:
        return new Variant((object) this.ReadNodeId(fieldName), TypeInfo.Scalars.NodeId);
      case BuiltInType.ExpandedNodeId:
        return new Variant((object) this.ReadExpandedNodeId(fieldName), TypeInfo.Scalars.ExpandedNodeId);
      case BuiltInType.StatusCode:
        return new Variant((object) this.ReadStatusCode(fieldName), TypeInfo.Scalars.StatusCode);
      case BuiltInType.QualifiedName:
        return new Variant((object) this.ReadQualifiedName(fieldName), TypeInfo.Scalars.QualifiedName);
      case BuiltInType.LocalizedText:
        return new Variant((object) this.ReadLocalizedText(fieldName), TypeInfo.Scalars.LocalizedText);
      case BuiltInType.ExtensionObject:
        return new Variant((object) this.ReadExtensionObject(fieldName), TypeInfo.Scalars.ExtensionObject);
      case BuiltInType.DataValue:
        return new Variant((object) this.ReadDataValue(fieldName), TypeInfo.Scalars.DataValue);
      case BuiltInType.Variant:
        return new Variant((object) this.ReadVariant(fieldName), TypeInfo.Scalars.Variant);
      case BuiltInType.DiagnosticInfo:
        return new Variant((object) this.ReadDiagnosticInfo(fieldName), TypeInfo.Scalars.DiagnosticInfo);
      default:
        return Variant.Null;
    }
  }

  private Variant ReadVariantArrayBody(string fieldName, BuiltInType type)
  {
    switch (type)
    {
      case BuiltInType.Boolean:
        return new Variant((object) this.ReadBooleanArray(fieldName), TypeInfo.Arrays.Boolean);
      case BuiltInType.SByte:
        return new Variant((object) this.ReadSByteArray(fieldName), TypeInfo.Arrays.SByte);
      case BuiltInType.Byte:
        return new Variant((object) this.ReadByteArray(fieldName), TypeInfo.Arrays.Byte);
      case BuiltInType.Int16:
        return new Variant((object) this.ReadInt16Array(fieldName), TypeInfo.Arrays.Int16);
      case BuiltInType.UInt16:
        return new Variant((object) this.ReadUInt16Array(fieldName), TypeInfo.Arrays.UInt16);
      case BuiltInType.Int32:
        return new Variant((object) this.ReadInt32Array(fieldName), TypeInfo.Arrays.Int32);
      case BuiltInType.UInt32:
        return new Variant((object) this.ReadUInt32Array(fieldName), TypeInfo.Arrays.UInt32);
      case BuiltInType.Int64:
        return new Variant((object) this.ReadInt64Array(fieldName), TypeInfo.Arrays.Int64);
      case BuiltInType.UInt64:
        return new Variant((object) this.ReadUInt64Array(fieldName), TypeInfo.Arrays.UInt64);
      case BuiltInType.Float:
        return new Variant((object) this.ReadFloatArray(fieldName), TypeInfo.Arrays.Float);
      case BuiltInType.Double:
        return new Variant((object) this.ReadDoubleArray(fieldName), TypeInfo.Arrays.Double);
      case BuiltInType.String:
        return new Variant((object) this.ReadStringArray(fieldName), TypeInfo.Arrays.String);
      case BuiltInType.DateTime:
        return new Variant((object) this.ReadDateTimeArray(fieldName), TypeInfo.Arrays.DateTime);
      case BuiltInType.Guid:
        return new Variant((object) this.ReadGuidArray(fieldName), TypeInfo.Arrays.Guid);
      case BuiltInType.ByteString:
        return new Variant((object) this.ReadByteStringArray(fieldName), TypeInfo.Arrays.ByteString);
      case BuiltInType.XmlElement:
        return new Variant((object) this.ReadXmlElementArray(fieldName), TypeInfo.Arrays.XmlElement);
      case BuiltInType.NodeId:
        return new Variant((object) this.ReadNodeIdArray(fieldName), TypeInfo.Arrays.NodeId);
      case BuiltInType.ExpandedNodeId:
        return new Variant((object) this.ReadExpandedNodeIdArray(fieldName), TypeInfo.Arrays.ExpandedNodeId);
      case BuiltInType.StatusCode:
        return new Variant((object) this.ReadStatusCodeArray(fieldName), TypeInfo.Arrays.StatusCode);
      case BuiltInType.QualifiedName:
        return new Variant((object) this.ReadQualifiedNameArray(fieldName), TypeInfo.Arrays.QualifiedName);
      case BuiltInType.LocalizedText:
        return new Variant((object) this.ReadLocalizedTextArray(fieldName), TypeInfo.Arrays.LocalizedText);
      case BuiltInType.ExtensionObject:
        return new Variant((object) this.ReadExtensionObjectArray(fieldName), TypeInfo.Arrays.ExtensionObject);
      case BuiltInType.DataValue:
        return new Variant((object) this.ReadDataValueArray(fieldName), TypeInfo.Arrays.DataValue);
      case BuiltInType.Variant:
        return new Variant((object) this.ReadVariantArray(fieldName), TypeInfo.Arrays.Variant);
      case BuiltInType.DiagnosticInfo:
        return new Variant((object) this.ReadDiagnosticInfoArray(fieldName), TypeInfo.Arrays.DiagnosticInfo);
      default:
        return Variant.Null;
    }
  }

  private List<object> ReadArray()
  {
    this.CheckAndIncrementNestingLevel();
    try
    {
      List<object> objectList = new List<object>();
      while (this.m_reader.Read() && this.m_reader.TokenType != JsonToken.EndArray)
      {
        switch (this.m_reader.TokenType)
        {
          case JsonToken.StartObject:
            objectList.Add((object) this.ReadObject());
            continue;
          case JsonToken.StartArray:
            objectList.Add((object) this.ReadArray());
            continue;
          case JsonToken.Integer:
          case JsonToken.Float:
          case JsonToken.String:
          case JsonToken.Boolean:
          case JsonToken.Date:
            objectList.Add(this.m_reader.Value);
            continue;
          case JsonToken.Null:
            objectList.Add((object) JsonDecoder.JTokenNullObject.Array);
            continue;
          default:
            continue;
        }
      }
      return objectList;
    }
    finally
    {
      --this.m_nestingLevel;
    }
  }

  private Dictionary<string, object> ReadObject()
  {
    Dictionary<string, object> dictionary = new Dictionary<string, object>();
    while (this.m_reader.Read() && this.m_reader.TokenType != JsonToken.EndObject)
    {
      if (this.m_reader.TokenType == JsonToken.StartArray)
        dictionary["___root_array___"] = (object) this.ReadArray();
      else if (this.m_reader.TokenType == JsonToken.PropertyName)
      {
        string key = (string) this.m_reader.Value;
        if (this.m_reader.Read() && this.m_reader.TokenType != JsonToken.EndObject)
        {
          switch (this.m_reader.TokenType)
          {
            case JsonToken.StartObject:
              dictionary[key] = (object) this.ReadObject();
              continue;
            case JsonToken.StartArray:
              dictionary[key] = (object) this.ReadArray();
              continue;
            case JsonToken.Integer:
            case JsonToken.Float:
            case JsonToken.String:
            case JsonToken.Boolean:
            case JsonToken.Date:
            case JsonToken.Bytes:
              dictionary[key] = this.m_reader.Value;
              continue;
            case JsonToken.Null:
              dictionary[key] = (object) JsonDecoder.JTokenNullObject.Object;
              continue;
            default:
              continue;
          }
        }
      }
    }
    return dictionary;
  }

  private void ReadMatrixPart(
    string fieldName,
    List<object> currentArray,
    BuiltInType builtInType,
    ref List<object> elements,
    ref List<int> dimensions,
    int level,
    Type systemType,
    ExpandedNodeId encodeableTypeId)
  {
    this.CheckAndIncrementNestingLevel();
    try
    {
      // ISSUE: explicit non-virtual call
      if (currentArray == null || __nonvirtual (currentArray.Count) <= 0)
        return;
      bool flag = false;
      for (int index = 0; index < currentArray.Count; ++index)
      {
        if (index == 0 && dimensions.Count <= level)
          dimensions.Add(currentArray.Count);
        if (currentArray[index] is List<object>)
        {
          flag = true;
          this.PushArray(fieldName, index);
          this.ReadMatrixPart((string) null, currentArray[index] as List<object>, builtInType, ref elements, ref dimensions, level + 1, systemType, encodeableTypeId);
          this.Pop();
        }
        else
          break;
      }
      if (flag)
        return;
      Array array = this.ReadArray((string) null, 1, builtInType, systemType, encodeableTypeId);
      if (array == null || array.Length <= 0)
        return;
      foreach (object obj in array)
        elements.Add(obj);
    }
    finally
    {
      --this.m_nestingLevel;
    }
  }

  private NodeId DefaultNodeId(IdType idType, ushort namespaceIndex)
  {
    switch (idType)
    {
      case IdType.String:
        return new NodeId("", namespaceIndex);
      case IdType.Guid:
        return new NodeId(Guid.Empty, namespaceIndex);
      case IdType.Opaque:
        return new NodeId(Array.Empty<byte>(), namespaceIndex);
      default:
        return new NodeId(0U, namespaceIndex);
    }
  }

  private void EncodeAsJson(JsonTextWriter writer, object value)
  {
    switch (value)
    {
      case Dictionary<string, object> dictionary:
        this.EncodeAsJson(writer, dictionary);
        break;
      case List<object> objectList:
        writer.WriteStartArray();
        foreach (object obj in objectList)
          this.EncodeAsJson(writer, obj);
        writer.WriteStartArray();
        break;
      default:
        writer.WriteValue(value);
        break;
    }
  }

  private void EncodeAsJson(JsonTextWriter writer, Dictionary<string, object> value)
  {
    writer.WriteStartObject();
    foreach (KeyValuePair<string, object> keyValuePair in value)
    {
      writer.WritePropertyName(keyValuePair.Key);
      this.EncodeAsJson(writer, keyValuePair.Value);
    }
    writer.WriteEndObject();
  }

  private bool ReadArrayField(string fieldName, out List<object> array)
  {
    array = (List<object>) null;
    object token;
    if (!this.ReadField(fieldName, out token))
      return false;
    array = token as List<object>;
    if (array == null)
      return false;
    if (this.m_context.MaxArrayLength > 0 && this.m_context.MaxArrayLength < array.Count)
      throw new ServiceResultException(2148007936U /*0x80080000*/);
    return true;
  }

  private void CheckAndIncrementNestingLevel()
  {
    if (this.m_nestingLevel > this.m_context.MaxEncodingNestingLevels)
      throw ServiceResultException.Create(2148007936U /*0x80080000*/, "Maximum nesting level of {0} was exceeded", (object) this.m_context.MaxEncodingNestingLevels);
    ++this.m_nestingLevel;
  }

  private enum JTokenNullObject
  {
    Undefined,
    Object,
    Array,
  }
}
