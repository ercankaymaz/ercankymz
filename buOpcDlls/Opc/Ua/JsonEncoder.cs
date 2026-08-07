// Decompiled with JetBrains decompiler
// Type: Opc.Ua.JsonEncoder
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
public class JsonEncoder : IJsonEncoder, IEncoder, IDisposable
{
  private const int kStreamWriterBufferSize = 1024 /*0x0400*/;
  private Stream m_stream;
  private MemoryStream m_memoryStream;
  private StreamWriter m_writer;
  private Stack<string> m_namespaces;
  private bool m_commaRequired;
  private bool m_inVariantWithEncoding;
  private IServiceMessageContext m_context;
  private ushort[] m_namespaceMappings;
  private ushort[] m_serverMappings;
  private uint m_nestingLevel;
  private bool m_topLevelIsArray;
  private bool m_levelOneSkipped;
  private bool m_dontWriteClosing;
  private bool m_leaveOpen;
  private static readonly char[] m_specialChars = new char[7]
  {
    '"',
    '\\',
    '\n',
    '\r',
    '\t',
    '\b',
    '\f'
  };
  private static readonly char[] m_substitution = new char[7]
  {
    '"',
    '\\',
    'n',
    'r',
    't',
    'b',
    'f'
  };

  public JsonEncoder(IServiceMessageContext context, bool useReversibleEncoding)
    : this(context, useReversibleEncoding, false, (Stream) null, false, 1024 /*0x0400*/)
  {
  }

  public JsonEncoder(
    IServiceMessageContext context,
    bool useReversibleEncoding,
    bool topLevelIsArray = false,
    Stream stream = null,
    bool leaveOpen = false,
    int streamSize = 1024 /*0x0400*/)
  {
    this.Initialize();
    this.m_context = context;
    this.m_stream = stream;
    this.m_leaveOpen = leaveOpen;
    this.UseReversibleEncoding = useReversibleEncoding;
    this.m_topLevelIsArray = topLevelIsArray;
    if (this.m_stream == null)
    {
      this.m_memoryStream = new MemoryStream();
      this.m_writer = new StreamWriter((Stream) this.m_memoryStream, (Encoding) new UTF8Encoding(false), streamSize, false);
      this.m_leaveOpen = false;
    }
    else
      this.m_writer = new StreamWriter(this.m_stream, (Encoding) new UTF8Encoding(false), streamSize, this.m_leaveOpen);
    this.InitializeWriter();
  }

  public JsonEncoder(
    IServiceMessageContext context,
    bool useReversibleEncoding,
    StreamWriter writer,
    bool topLevelIsArray = false)
  {
    this.Initialize();
    this.m_context = context;
    this.m_writer = writer;
    this.UseReversibleEncoding = useReversibleEncoding;
    this.m_topLevelIsArray = topLevelIsArray;
    if (this.m_writer == null)
    {
      this.m_stream = (Stream) new MemoryStream();
      this.m_writer = new StreamWriter(this.m_stream, (Encoding) new UTF8Encoding(false), 1024 /*0x0400*/);
    }
    this.InitializeWriter();
  }

  private void Initialize()
  {
    this.m_stream = (Stream) null;
    this.m_writer = (StreamWriter) null;
    this.m_namespaces = new Stack<string>();
    this.m_commaRequired = false;
    this.m_leaveOpen = false;
    this.m_nestingLevel = 0U;
    this.m_levelOneSkipped = false;
    this.ForceNamespaceUri = false;
    this.IncludeDefaultValues = false;
    this.IncludeDefaultNumberValues = true;
  }

  private void InitializeWriter()
  {
    if (this.m_topLevelIsArray)
      this.m_writer.Write("[");
    else
      this.m_writer.Write("{");
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
    JsonEncoder jsonEncoder = new JsonEncoder(context, true, stream: stream, leaveOpen: leaveOpen);
    try
    {
      long position = stream.Position;
      new SessionLessServiceMessage()
      {
        NamespaceUris = context.NamespaceUris,
        ServerUris = context.ServerUris,
        Message = message
      }.Encode((IEncoder) jsonEncoder);
      if (context.MaxMessageSize > 0 && context.MaxMessageSize < (int) (stream.Position - position))
        throw ServiceResultException.Create(2148007936U /*0x80080000*/, "MaxMessageSize {0} < {1}", (object) context.MaxMessageSize, (object) (int) (stream.Position - position));
      jsonEncoder.Close();
    }
    finally
    {
      if (leaveOpen)
        stream.Position = 0L;
      jsonEncoder.Dispose();
    }
  }

  public static ArraySegment<byte> EncodeMessage(
    IEncodeable message,
    byte[] buffer,
    IServiceMessageContext context)
  {
    if (message == null)
      throw new ArgumentNullException(nameof (message));
    if (buffer == null)
      throw new ArgumentNullException(nameof (buffer));
    if (context == null)
      throw new ArgumentNullException(nameof (context));
    using (MemoryStream stream = new MemoryStream(buffer, true))
    {
      using (JsonEncoder jsonEncoder = new JsonEncoder(context, true, stream: (Stream) stream))
      {
        jsonEncoder.EncodeMessage(message);
        int count = jsonEncoder.Close();
        return new ArraySegment<byte>(buffer, 0, count);
      }
    }
  }

  public void EncodeMessage(IEncodeable message)
  {
    if (message == null)
      throw new ArgumentNullException(nameof (message));
    this.WriteNodeId("TypeId", ExpandedNodeId.ToNodeId(message.TypeId, this.m_context.NamespaceUris));
    this.WriteEncodeable("Body", message, message.GetType());
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

  public string CloseAndReturnText()
  {
    this.Close();
    if (this.m_memoryStream != null)
      return Encoding.UTF8.GetString(this.m_memoryStream.ToArray());
    return this.m_stream is MemoryStream stream ? Encoding.UTF8.GetString(stream.ToArray()) : throw new NotSupportedException("Cannot get text from external stream. Use Close or MemoryStream instead.");
  }

  public int Close()
  {
    if (!this.m_dontWriteClosing)
    {
      if (this.m_topLevelIsArray)
        this.m_writer.Write("]");
      else
        this.m_writer.Write("}");
    }
    this.m_writer.Flush();
    int position = (int) this.m_writer.BaseStream.Position;
    this.m_writer.Dispose();
    this.m_writer = (StreamWriter) null;
    return position;
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
      this.Close();
      this.m_writer = (StreamWriter) null;
    }
    if (this.m_leaveOpen)
      return;
    Utils.SilentDispose((IDisposable) this.m_memoryStream);
    Utils.SilentDispose((IDisposable) this.m_stream);
    this.m_memoryStream = (MemoryStream) null;
    this.m_stream = (Stream) null;
  }

  public void PushStructure(string fieldName)
  {
    ++this.m_nestingLevel;
    if (this.m_commaRequired)
      this.m_writer.Write(",");
    if (!string.IsNullOrEmpty(fieldName))
    {
      this.m_writer.Write("\"");
      this.EscapeString(fieldName);
      this.m_writer.Write("\":");
    }
    else if (!this.m_commaRequired && this.m_nestingLevel == 1U && !this.m_topLevelIsArray)
    {
      this.m_levelOneSkipped = true;
      return;
    }
    this.m_commaRequired = false;
    this.m_writer.Write("{");
  }

  public void PushArray(string fieldName)
  {
    ++this.m_nestingLevel;
    if (this.m_commaRequired)
      this.m_writer.Write(",");
    if (!string.IsNullOrEmpty(fieldName))
    {
      this.m_writer.Write("\"");
      this.EscapeString(fieldName);
      this.m_writer.Write("\":");
    }
    else if (!this.m_commaRequired && this.m_nestingLevel == 1U && !this.m_topLevelIsArray)
    {
      this.m_levelOneSkipped = true;
      return;
    }
    this.m_commaRequired = false;
    this.m_writer.Write("[");
  }

  public void PopStructure()
  {
    if (this.m_nestingLevel > 1U || this.m_topLevelIsArray || this.m_nestingLevel == 1U && !this.m_levelOneSkipped)
    {
      this.m_writer.Write("}");
      this.m_commaRequired = true;
    }
    --this.m_nestingLevel;
  }

  public void PopArray()
  {
    if (this.m_nestingLevel > 1U || this.m_topLevelIsArray || this.m_nestingLevel == 1U && !this.m_levelOneSkipped)
    {
      this.m_writer.Write("]");
      this.m_commaRequired = true;
    }
    --this.m_nestingLevel;
  }

  public void UsingReversibleEncoding<T>(
    Action<string, T> action,
    string fieldName,
    T value,
    bool useReversibleEncoding)
  {
    bool reversibleEncoding = this.UseReversibleEncoding;
    try
    {
      this.UseReversibleEncoding = useReversibleEncoding;
      action(fieldName, value);
    }
    finally
    {
      this.UseReversibleEncoding = reversibleEncoding;
    }
  }

  public EncodingType EncodingType => EncodingType.Json;

  public IServiceMessageContext Context => this.m_context;

  public bool UseReversibleEncoding { get; private set; }

  public bool ForceNamespaceUri { get; set; }

  public bool ForceNamespaceUriForIndex1 { get; set; }

  public bool IncludeDefaultValues { get; set; }

  public bool IncludeDefaultNumberValues { get; set; }

  public void PushNamespace(string namespaceUri) => this.m_namespaces.Push(namespaceUri);

  public void PopNamespace() => this.m_namespaces.Pop();

  private void EscapeString(string value)
  {
    foreach (char ch in value)
    {
      bool flag = false;
      for (int index = 0; index < JsonEncoder.m_specialChars.Length; ++index)
      {
        if ((int) JsonEncoder.m_specialChars[index] == (int) ch)
        {
          this.m_writer.Write('\\');
          this.m_writer.Write(JsonEncoder.m_substitution[index]);
          flag = true;
          break;
        }
      }
      if (!flag)
      {
        if (ch < ' ')
        {
          this.m_writer.Write("\\u");
          this.m_writer.Write("{0:X4}", (object) (int) ch);
        }
        else
          this.m_writer.Write(ch);
      }
    }
  }

  private void WriteSimpleField(string fieldName, string value, bool quotes)
  {
    if (!string.IsNullOrEmpty(fieldName))
    {
      if (value == null)
        return;
      if (this.m_commaRequired)
        this.m_writer.Write(",");
      this.m_writer.Write("\"");
      this.EscapeString(fieldName);
      this.m_writer.Write("\":");
    }
    else if (this.m_commaRequired)
      this.m_writer.Write(",");
    if (value != null)
    {
      if (quotes)
      {
        this.m_writer.Write("\"");
        this.EscapeString(value);
        this.m_writer.Write("\"");
      }
      else
        this.m_writer.Write(value);
    }
    else
      this.m_writer.Write("null");
    this.m_commaRequired = true;
  }

  public void WriteBoolean(string fieldName, bool value)
  {
    if (fieldName != null && !this.IncludeDefaultNumberValues && !value)
      this.WriteSimpleField(fieldName, (string) null, false);
    else if (value)
      this.WriteSimpleField(fieldName, "true", false);
    else
      this.WriteSimpleField(fieldName, "false", false);
  }

  public void WriteSByte(string fieldName, sbyte value)
  {
    if (fieldName != null && !this.IncludeDefaultNumberValues && value == (sbyte) 0)
      this.WriteSimpleField(fieldName, (string) null, false);
    else
      this.WriteSimpleField(fieldName, value.ToString((IFormatProvider) CultureInfo.InvariantCulture), false);
  }

  public void WriteByte(string fieldName, byte value)
  {
    if (fieldName != null && !this.IncludeDefaultNumberValues && value == (byte) 0)
      this.WriteSimpleField(fieldName, (string) null, false);
    else
      this.WriteSimpleField(fieldName, value.ToString((IFormatProvider) CultureInfo.InvariantCulture), false);
  }

  public void WriteInt16(string fieldName, short value)
  {
    if (fieldName != null && !this.IncludeDefaultNumberValues && value == (short) 0)
      this.WriteSimpleField(fieldName, (string) null, false);
    else
      this.WriteSimpleField(fieldName, value.ToString((IFormatProvider) CultureInfo.InvariantCulture), false);
  }

  public void WriteUInt16(string fieldName, ushort value)
  {
    if (fieldName != null && !this.IncludeDefaultNumberValues && value == (ushort) 0)
      this.WriteSimpleField(fieldName, (string) null, false);
    else
      this.WriteSimpleField(fieldName, value.ToString((IFormatProvider) CultureInfo.InvariantCulture), false);
  }

  public void WriteInt32(string fieldName, int value)
  {
    if (fieldName != null && !this.IncludeDefaultNumberValues && value == 0)
      this.WriteSimpleField(fieldName, (string) null, false);
    else
      this.WriteSimpleField(fieldName, value.ToString((IFormatProvider) CultureInfo.InvariantCulture), false);
  }

  public void WriteUInt32(string fieldName, uint value)
  {
    if (fieldName != null && !this.IncludeDefaultNumberValues && value == 0U)
      this.WriteSimpleField(fieldName, (string) null, false);
    else
      this.WriteSimpleField(fieldName, value.ToString((IFormatProvider) CultureInfo.InvariantCulture), false);
  }

  public void WriteInt64(string fieldName, long value)
  {
    if (fieldName != null && !this.IncludeDefaultNumberValues && value == 0L)
      this.WriteSimpleField(fieldName, (string) null, false);
    else
      this.WriteSimpleField(fieldName, value.ToString((IFormatProvider) CultureInfo.InvariantCulture), true);
  }

  public void WriteUInt64(string fieldName, ulong value)
  {
    if (fieldName != null && !this.IncludeDefaultNumberValues && value == 0UL)
      this.WriteSimpleField(fieldName, (string) null, false);
    else
      this.WriteSimpleField(fieldName, value.ToString((IFormatProvider) CultureInfo.InvariantCulture), true);
  }

  public void WriteFloat(string fieldName, float value)
  {
    if (fieldName != null && !this.IncludeDefaultNumberValues && (double) value > -1.4012984643248171E-45 && (double) value < 1.4012984643248171E-45)
      this.WriteSimpleField(fieldName, (string) null, false);
    else if (float.IsNaN(value))
      this.WriteSimpleField(fieldName, "NaN", true);
    else if (float.IsPositiveInfinity(value))
      this.WriteSimpleField(fieldName, "Infinity", true);
    else if (float.IsNegativeInfinity(value))
      this.WriteSimpleField(fieldName, "-Infinity", true);
    else
      this.WriteSimpleField(fieldName, value.ToString("R", (IFormatProvider) CultureInfo.InvariantCulture), false);
  }

  public void WriteDouble(string fieldName, double value)
  {
    if (fieldName != null && !this.IncludeDefaultNumberValues && value > -4.94065645841247E-324 && value < double.Epsilon)
      this.WriteSimpleField(fieldName, (string) null, false);
    else if (double.IsNaN(value))
      this.WriteSimpleField(fieldName, "NaN", true);
    else if (double.IsPositiveInfinity(value))
      this.WriteSimpleField(fieldName, "Infinity", true);
    else if (double.IsNegativeInfinity(value))
      this.WriteSimpleField(fieldName, "-Infinity", true);
    else
      this.WriteSimpleField(fieldName, value.ToString("R", (IFormatProvider) CultureInfo.InvariantCulture), false);
  }

  public void WriteString(string fieldName, string value)
  {
    if (fieldName != null && !this.IncludeDefaultValues && value == null)
      this.WriteSimpleField(fieldName, (string) null, false);
    else
      this.WriteSimpleField(fieldName, value, true);
  }

  public void WriteDateTime(string fieldName, DateTime value)
  {
    if (fieldName != null && !this.IncludeDefaultValues && value == DateTime.MinValue)
      this.WriteSimpleField(fieldName, (string) null, false);
    else if (value <= DateTime.MinValue)
      this.WriteSimpleField(fieldName, "0001-01-01T00:00:00Z", true);
    else if (value >= DateTime.MaxValue)
      this.WriteSimpleField(fieldName, "9999-12-31T23:59:59Z", true);
    else
      this.WriteSimpleField(fieldName, value.ToUniversalTime().ToString("yyyy-MM-dd'T'HH:mm:ss.FFFFFFFK", (IFormatProvider) CultureInfo.InvariantCulture), true);
  }

  public void WriteGuid(string fieldName, Uuid value)
  {
    if (fieldName != null && !this.IncludeDefaultValues && value == Uuid.Empty)
      this.WriteSimpleField(fieldName, (string) null, false);
    else
      this.WriteSimpleField(fieldName, value.ToString(), true);
  }

  public void WriteGuid(string fieldName, Guid value)
  {
    if (fieldName != null && !this.IncludeDefaultValues && value == Guid.Empty)
      this.WriteSimpleField(fieldName, (string) null, false);
    else
      this.WriteSimpleField(fieldName, value.ToString(), true);
  }

  public void WriteByteString(string fieldName, byte[] value)
  {
    if (value == null)
    {
      this.WriteSimpleField(fieldName, (string) null, false);
    }
    else
    {
      if (this.m_context.MaxByteStringLength > 0 && this.m_context.MaxByteStringLength < value.Length)
        throw new ServiceResultException(2148007936U /*0x80080000*/);
      this.WriteSimpleField(fieldName, Convert.ToBase64String(value), true);
    }
  }

  public void WriteXmlElement(string fieldName, XmlElement value)
  {
    if (value == null)
    {
      this.WriteSimpleField(fieldName, (string) null, false);
    }
    else
    {
      byte[] bytes = Encoding.UTF8.GetBytes(value.OuterXml);
      this.WriteSimpleField(fieldName, Convert.ToBase64String(bytes), true);
    }
  }

  private void WriteNamespaceIndex(string fieldName, ushort namespaceIndex)
  {
    if (namespaceIndex == (ushort) 0)
      return;
    if ((!this.UseReversibleEncoding || this.ForceNamespaceUri) && (int) namespaceIndex > (!this.ForceNamespaceUriForIndex1 ? 1 : 0))
    {
      string str = this.m_context.NamespaceUris.GetString((uint) namespaceIndex);
      if (!string.IsNullOrEmpty(str))
      {
        this.WriteSimpleField(fieldName, str, true);
        return;
      }
    }
    if (this.m_namespaceMappings != null && this.m_namespaceMappings.Length > (int) namespaceIndex)
      namespaceIndex = this.m_namespaceMappings[(int) namespaceIndex];
    if (namespaceIndex == (ushort) 0)
      return;
    this.WriteUInt16(fieldName, namespaceIndex);
  }

  private void WriteNodeIdContents(NodeId value, string namespaceUri = null)
  {
    if (value.IdType > IdType.Numeric)
      this.WriteInt32("IdType", (int) value.IdType);
    switch (value.IdType)
    {
      case IdType.Numeric:
        this.WriteUInt32("Id", (uint) value.Identifier);
        break;
      case IdType.String:
        this.WriteString("Id", (string) value.Identifier);
        break;
      case IdType.Guid:
        this.WriteGuid("Id", (Guid) value.Identifier);
        break;
      case IdType.Opaque:
        this.WriteByteString("Id", (byte[]) value.Identifier);
        break;
    }
    if (namespaceUri != null)
      this.WriteString("Namespace", namespaceUri);
    else
      this.WriteNamespaceIndex("Namespace", value.NamespaceIndex);
  }

  public void WriteNodeId(string fieldName, NodeId value)
  {
    if (!(value == (object) null) && (!NodeId.IsNull(value) || value.IdType != IdType.Numeric))
    {
      this.PushStructure(fieldName);
      ushort namespaceIndex = value.NamespaceIndex;
      if (this.ForceNamespaceUri && (int) namespaceIndex > (!this.ForceNamespaceUriForIndex1 ? 1 : 0))
      {
        string namespaceUri = this.Context.NamespaceUris.GetString((uint) namespaceIndex);
        this.WriteNodeIdContents(value, namespaceUri);
      }
      else
        this.WriteNodeIdContents(value);
      this.PopStructure();
    }
    else
      this.WriteSimpleField(fieldName, (string) null, false);
  }

  public void WriteExpandedNodeId(string fieldName, ExpandedNodeId value)
  {
    if (!(value == (object) null) && !(value.InnerNodeId == (object) null) && (this.UseReversibleEncoding || !NodeId.IsNull(value)))
    {
      this.PushStructure(fieldName);
      string namespaceUri = value.NamespaceUri;
      ushort namespaceIndex = value.InnerNodeId.NamespaceIndex;
      if (this.ForceNamespaceUri && namespaceUri == null && (int) namespaceIndex > (!this.ForceNamespaceUriForIndex1 ? 1 : 0))
        namespaceUri = this.Context.NamespaceUris.GetString((uint) namespaceIndex);
      this.WriteNodeIdContents(value.InnerNodeId, namespaceUri);
      uint index = value.ServerIndex;
      if (index >= 1U)
      {
        string str = this.m_context.ServerUris.GetString(index);
        if (!string.IsNullOrEmpty(str))
        {
          this.WriteSimpleField("ServerUri", str, true);
          this.PopStructure();
          return;
        }
        if (this.m_serverMappings != null && (long) this.m_serverMappings.Length > (long) index)
          index = (uint) this.m_serverMappings[(int) index];
        if (index != 0U)
          this.WriteUInt32("ServerUri", index);
      }
      this.PopStructure();
    }
    else
      this.WriteSimpleField(fieldName, (string) null, false);
  }

  public void WriteStatusCode(string fieldName, StatusCode value)
  {
    if (fieldName != null && !this.IncludeDefaultValues && value == 0U)
      this.WriteSimpleField(fieldName, (string) null, false);
    else if (this.UseReversibleEncoding)
    {
      this.WriteUInt32(fieldName, value.Code);
    }
    else
    {
      if (!(value != 0U))
        return;
      this.PushStructure(fieldName);
      this.WriteSimpleField("Code", value.Code.ToString((IFormatProvider) CultureInfo.InvariantCulture), false);
      this.WriteSimpleField("Symbol", StatusCode.LookupSymbolicId(value.CodeBits), true);
      this.PopStructure();
    }
  }

  public void WriteDiagnosticInfo(string fieldName, DiagnosticInfo value)
  {
    this.WriteDiagnosticInfo(fieldName, value, 0);
  }

  public void WriteQualifiedName(string fieldName, QualifiedName value)
  {
    if (QualifiedName.IsNull(value))
    {
      this.WriteSimpleField(fieldName, (string) null, false);
    }
    else
    {
      this.PushStructure(fieldName);
      this.WriteString("Name", value.Name);
      this.WriteNamespaceIndex("Uri", value.NamespaceIndex);
      this.PopStructure();
    }
  }

  public void WriteLocalizedText(string fieldName, LocalizedText value)
  {
    if (LocalizedText.IsNullOrEmpty(value))
      this.WriteSimpleField(fieldName, (string) null, false);
    else if (this.UseReversibleEncoding)
    {
      this.PushStructure(fieldName);
      this.WriteSimpleField("Text", value.Text, true);
      if (!string.IsNullOrEmpty(value.Locale))
        this.WriteSimpleField("Locale", value.Locale, true);
      this.PopStructure();
    }
    else
      this.WriteSimpleField(fieldName, value.Text, true);
  }

  public void WriteVariant(string fieldName, Variant value)
  {
    if (Variant.Null == value)
    {
      this.WriteSimpleField(fieldName, (string) null, false);
    }
    else
    {
      this.CheckAndIncrementNestingLevel();
      try
      {
        bool flag = value.TypeInfo == null || value.TypeInfo.BuiltInType == BuiltInType.Null || value.Value == null;
        if (this.UseReversibleEncoding && !flag)
        {
          this.PushStructure(fieldName);
          byte num = (byte) value.TypeInfo.BuiltInType;
          if (value.TypeInfo.BuiltInType == BuiltInType.Enumeration)
            num = (byte) 6;
          this.WriteByte("Type", num);
          fieldName = "Body";
        }
        if (this.m_commaRequired)
          this.m_writer.Write(",");
        if (!string.IsNullOrEmpty(fieldName))
        {
          this.m_writer.Write("\"");
          this.EscapeString(fieldName);
          this.m_writer.Write("\":");
        }
        this.WriteVariantContents(value.Value, value.TypeInfo);
        if (!this.UseReversibleEncoding || flag)
          return;
        if (value.Value is Matrix matrix)
          this.WriteInt32Array("Dimensions", (IList<int>) matrix.Dimensions);
        this.PopStructure();
      }
      finally
      {
        --this.m_nestingLevel;
      }
    }
  }

  public void WriteDataValue(string fieldName, DataValue value)
  {
    if (value == null)
    {
      this.WriteSimpleField(fieldName, (string) null, false);
    }
    else
    {
      this.PushStructure(fieldName);
      if (value != null)
      {
        Variant wrappedValue = value.WrappedValue;
        if (wrappedValue.TypeInfo != null)
        {
          wrappedValue = value.WrappedValue;
          if (wrappedValue.TypeInfo.BuiltInType != BuiltInType.Null)
            this.WriteVariant("Value", value.WrappedValue);
        }
        if (value.StatusCode != 0U)
          this.WriteStatusCode("StatusCode", value.StatusCode);
        if (value.SourceTimestamp != DateTime.MinValue)
        {
          this.WriteDateTime("SourceTimestamp", value.SourceTimestamp);
          if (value.SourcePicoseconds != (ushort) 0)
            this.WriteUInt16("SourcePicoseconds", value.SourcePicoseconds);
        }
        if (value.ServerTimestamp != DateTime.MinValue)
        {
          this.WriteDateTime("ServerTimestamp", value.ServerTimestamp);
          if (value.ServerPicoseconds != (ushort) 0)
            this.WriteUInt16("ServerPicoseconds", value.ServerPicoseconds);
        }
      }
      this.PopStructure();
    }
  }

  public void WriteExtensionObject(string fieldName, ExtensionObject value)
  {
    if (value != null && value.Encoding != ExtensionObjectEncoding.None)
    {
      IEncodeable body1 = value.Body as IEncodeable;
      if (!this.UseReversibleEncoding && body1 != null)
      {
        if (value.Body is IStructureTypeInfo body2 && body2.StructureType == StructureType.Union)
        {
          body1.Encode((IEncoder) this);
        }
        else
        {
          this.PushStructure(fieldName);
          body1.Encode((IEncoder) this);
          this.PopStructure();
        }
      }
      else
      {
        this.PushStructure(fieldName);
        ExpandedNodeId nodeId1 = value.TypeId;
        if (body1 != null)
        {
          switch (value.Encoding)
          {
            case ExtensionObjectEncoding.Binary:
              nodeId1 = body1.BinaryEncodingId;
              break;
            case ExtensionObjectEncoding.Xml:
              nodeId1 = body1.XmlEncodingId;
              break;
            default:
              nodeId1 = body1.TypeId;
              break;
          }
        }
        NodeId nodeId2 = ExpandedNodeId.ToNodeId(nodeId1, this.Context.NamespaceUris);
        if (this.UseReversibleEncoding)
          this.WriteNodeId("TypeId", nodeId2);
        else
          this.WriteExpandedNodeId("TypeId", nodeId1);
        if (body1 != null)
          this.WriteEncodeable("Body", body1, (Type) null);
        else if (value.Body != null)
        {
          if (value.Encoding == ExtensionObjectEncoding.Json)
          {
            this.WriteSimpleField("Body", value.Body as string, true);
          }
          else
          {
            this.WriteByte("Encoding", (byte) value.Encoding);
            if (value.Encoding == ExtensionObjectEncoding.Binary)
              this.WriteByteString("Body", value.Body as byte[]);
            else if (value.Encoding == ExtensionObjectEncoding.Xml)
              this.WriteXmlElement("Body", value.Body as XmlElement);
          }
        }
        this.PopStructure();
      }
    }
    else
      this.WriteSimpleField(fieldName, (string) null, false);
  }

  public void WriteEncodeable(string fieldName, IEncodeable value, Type systemType)
  {
    if (value == null)
    {
      this.WriteSimpleField(fieldName, (string) null, false);
    }
    else
    {
      if (this.m_nestingLevel == 0U && (this.m_commaRequired || this.m_topLevelIsArray) && string.IsNullOrWhiteSpace(fieldName) ^ this.m_topLevelIsArray)
        throw ServiceResultException.Create(2147876864U /*0x80060000*/, "With Array as top level, encodeables with fieldname will create invalid json");
      if (this.m_nestingLevel == 0U && !this.m_commaRequired && string.IsNullOrWhiteSpace(fieldName) && !this.m_topLevelIsArray)
      {
        this.m_writer.Flush();
        if (this.m_writer.BaseStream.Length == 1L)
          this.m_writer.BaseStream.Seek(0L, SeekOrigin.Begin);
        this.m_dontWriteClosing = true;
      }
      this.CheckAndIncrementNestingLevel();
      try
      {
        this.PushStructure(fieldName);
        value?.Encode((IEncoder) this);
        this.PopStructure();
      }
      finally
      {
        --this.m_nestingLevel;
      }
    }
  }

  public void WriteEnumerated(string fieldName, Enum value)
  {
    int int32 = Convert.ToInt32((object) value, (IFormatProvider) CultureInfo.InvariantCulture);
    string str = int32.ToString();
    if (this.UseReversibleEncoding)
      this.WriteSimpleField(fieldName, str, false);
    else if (value.ToString() == str)
      this.WriteSimpleField(fieldName, str, true);
    else
      this.WriteSimpleField(fieldName, Utils.Format("{0}_{1}", (object) value.ToString(), (object) int32), true);
  }

  public void WriteEnumerated(string fieldName, int numeric)
  {
    string str = numeric.ToString((IFormatProvider) CultureInfo.InvariantCulture);
    this.WriteSimpleField(fieldName, str, !this.UseReversibleEncoding);
  }

  public void WriteBooleanArray(string fieldName, IList<bool> values)
  {
    if (values != null && (values.Count != 0 || this.m_inVariantWithEncoding))
    {
      this.PushArray(fieldName);
      if (this.m_context.MaxArrayLength > 0 && this.m_context.MaxArrayLength < values.Count)
        throw new ServiceResultException(2148007936U /*0x80080000*/);
      for (int index = 0; index < values.Count; ++index)
        this.WriteBoolean((string) null, values[index]);
      this.PopArray();
    }
    else
      this.WriteSimpleField(fieldName, (string) null, false);
  }

  public void WriteSByteArray(string fieldName, IList<sbyte> values)
  {
    if (values != null && (values.Count != 0 || this.m_inVariantWithEncoding))
    {
      this.PushArray(fieldName);
      if (this.m_context.MaxArrayLength > 0 && this.m_context.MaxArrayLength < values.Count)
        throw new ServiceResultException(2148007936U /*0x80080000*/);
      for (int index = 0; index < values.Count; ++index)
        this.WriteSByte((string) null, values[index]);
      this.PopArray();
    }
    else
      this.WriteSimpleField(fieldName, (string) null, false);
  }

  public void WriteByteArray(string fieldName, IList<byte> values)
  {
    if (values != null && (values.Count != 0 || this.m_inVariantWithEncoding))
    {
      this.PushArray(fieldName);
      if (this.m_context.MaxArrayLength > 0 && this.m_context.MaxArrayLength < values.Count)
        throw new ServiceResultException(2148007936U /*0x80080000*/);
      for (int index = 0; index < values.Count; ++index)
        this.WriteByte((string) null, values[index]);
      this.PopArray();
    }
    else
      this.WriteSimpleField(fieldName, (string) null, false);
  }

  public void WriteInt16Array(string fieldName, IList<short> values)
  {
    if (values != null && (values.Count != 0 || this.m_inVariantWithEncoding))
    {
      this.PushArray(fieldName);
      if (this.m_context.MaxArrayLength > 0 && this.m_context.MaxArrayLength < values.Count)
        throw new ServiceResultException(2148007936U /*0x80080000*/);
      for (int index = 0; index < values.Count; ++index)
        this.WriteInt16((string) null, values[index]);
      this.PopArray();
    }
    else
      this.WriteSimpleField(fieldName, (string) null, false);
  }

  public void WriteUInt16Array(string fieldName, IList<ushort> values)
  {
    if (values != null && (values.Count != 0 || this.m_inVariantWithEncoding))
    {
      this.PushArray(fieldName);
      if (this.m_context.MaxArrayLength > 0 && this.m_context.MaxArrayLength < values.Count)
        throw new ServiceResultException(2148007936U /*0x80080000*/);
      for (int index = 0; index < values.Count; ++index)
        this.WriteUInt16((string) null, values[index]);
      this.PopArray();
    }
    else
      this.WriteSimpleField(fieldName, (string) null, false);
  }

  public void WriteInt32Array(string fieldName, IList<int> values)
  {
    if (values != null && (values.Count != 0 || this.m_inVariantWithEncoding))
    {
      this.PushArray(fieldName);
      if (this.m_context.MaxArrayLength > 0 && this.m_context.MaxArrayLength < values.Count)
        throw new ServiceResultException(2148007936U /*0x80080000*/);
      for (int index = 0; index < values.Count; ++index)
        this.WriteInt32((string) null, values[index]);
      this.PopArray();
    }
    else
      this.WriteSimpleField(fieldName, (string) null, false);
  }

  public void WriteUInt32Array(string fieldName, IList<uint> values)
  {
    if (values != null && (values.Count != 0 || this.m_inVariantWithEncoding))
    {
      this.PushArray(fieldName);
      if (this.m_context.MaxArrayLength > 0 && this.m_context.MaxArrayLength < values.Count)
        throw new ServiceResultException(2148007936U /*0x80080000*/);
      for (int index = 0; index < values.Count; ++index)
        this.WriteUInt32((string) null, values[index]);
      this.PopArray();
    }
    else
      this.WriteSimpleField(fieldName, (string) null, false);
  }

  public void WriteInt64Array(string fieldName, IList<long> values)
  {
    if (values != null && (values.Count != 0 || this.m_inVariantWithEncoding))
    {
      this.PushArray(fieldName);
      if (this.m_context.MaxArrayLength > 0 && this.m_context.MaxArrayLength < values.Count)
        throw new ServiceResultException(2148007936U /*0x80080000*/);
      for (int index = 0; index < values.Count; ++index)
        this.WriteInt64((string) null, values[index]);
      this.PopArray();
    }
    else
      this.WriteSimpleField(fieldName, (string) null, false);
  }

  public void WriteUInt64Array(string fieldName, IList<ulong> values)
  {
    if (values != null && (values.Count != 0 || this.m_inVariantWithEncoding))
    {
      this.PushArray(fieldName);
      if (this.m_context.MaxArrayLength > 0 && this.m_context.MaxArrayLength < values.Count)
        throw new ServiceResultException(2148007936U /*0x80080000*/);
      for (int index = 0; index < values.Count; ++index)
        this.WriteUInt64((string) null, values[index]);
      this.PopArray();
    }
    else
      this.WriteSimpleField(fieldName, (string) null, false);
  }

  public void WriteFloatArray(string fieldName, IList<float> values)
  {
    if (values != null && (values.Count != 0 || this.m_inVariantWithEncoding))
    {
      this.PushArray(fieldName);
      if (this.m_context.MaxArrayLength > 0 && this.m_context.MaxArrayLength < values.Count)
        throw new ServiceResultException(2148007936U /*0x80080000*/);
      for (int index = 0; index < values.Count; ++index)
        this.WriteFloat((string) null, values[index]);
      this.PopArray();
    }
    else
      this.WriteSimpleField(fieldName, (string) null, false);
  }

  public void WriteDoubleArray(string fieldName, IList<double> values)
  {
    if (values != null && (values.Count != 0 || this.m_inVariantWithEncoding))
    {
      this.PushArray(fieldName);
      if (this.m_context.MaxArrayLength > 0 && this.m_context.MaxArrayLength < values.Count)
        throw new ServiceResultException(2148007936U /*0x80080000*/);
      for (int index = 0; index < values.Count; ++index)
        this.WriteDouble((string) null, values[index]);
      this.PopArray();
    }
    else
      this.WriteSimpleField(fieldName, (string) null, false);
  }

  public void WriteStringArray(string fieldName, IList<string> values)
  {
    if (values != null && (values.Count != 0 || this.m_inVariantWithEncoding))
    {
      this.PushArray(fieldName);
      if (this.m_context.MaxArrayLength > 0 && this.m_context.MaxArrayLength < values.Count)
        throw new ServiceResultException(2148007936U /*0x80080000*/);
      for (int index = 0; index < values.Count; ++index)
        this.WriteString((string) null, values[index]);
      this.PopArray();
    }
    else
      this.WriteSimpleField(fieldName, (string) null, false);
  }

  public void WriteDateTimeArray(string fieldName, IList<DateTime> values)
  {
    if (values != null && (values.Count != 0 || this.m_inVariantWithEncoding))
    {
      this.PushArray(fieldName);
      if (this.m_context.MaxArrayLength > 0 && this.m_context.MaxArrayLength < values.Count)
        throw new ServiceResultException(2148007936U /*0x80080000*/);
      for (int index = 0; index < values.Count; ++index)
      {
        if (values[index] <= DateTime.MinValue)
          this.WriteSimpleField((string) null, (string) null, false);
        else
          this.WriteDateTime((string) null, values[index]);
      }
      this.PopArray();
    }
    else
      this.WriteSimpleField(fieldName, (string) null, false);
  }

  public void WriteGuidArray(string fieldName, IList<Uuid> values)
  {
    if (values != null && (values.Count != 0 || this.m_inVariantWithEncoding))
    {
      this.PushArray(fieldName);
      if (this.m_context.MaxArrayLength > 0 && this.m_context.MaxArrayLength < values.Count)
        throw new ServiceResultException(2148007936U /*0x80080000*/);
      for (int index = 0; index < values.Count; ++index)
        this.WriteGuid((string) null, values[index]);
      this.PopArray();
    }
    else
      this.WriteSimpleField(fieldName, (string) null, false);
  }

  public void WriteGuidArray(string fieldName, IList<Guid> values)
  {
    if (values != null && (values.Count != 0 || this.m_inVariantWithEncoding))
    {
      this.PushArray(fieldName);
      if (this.m_context.MaxArrayLength > 0 && this.m_context.MaxArrayLength < values.Count)
        throw new ServiceResultException(2148007936U /*0x80080000*/);
      for (int index = 0; index < values.Count; ++index)
        this.WriteGuid((string) null, values[index]);
      this.PopArray();
    }
    else
      this.WriteSimpleField(fieldName, (string) null, false);
  }

  public void WriteByteStringArray(string fieldName, IList<byte[]> values)
  {
    if (values != null && (values.Count != 0 || this.m_inVariantWithEncoding))
    {
      this.PushArray(fieldName);
      if (this.m_context.MaxArrayLength > 0 && this.m_context.MaxArrayLength < values.Count)
        throw new ServiceResultException(2148007936U /*0x80080000*/);
      for (int index = 0; index < values.Count; ++index)
        this.WriteByteString((string) null, values[index]);
      this.PopArray();
    }
    else
      this.WriteSimpleField(fieldName, (string) null, false);
  }

  public void WriteXmlElementArray(string fieldName, IList<XmlElement> values)
  {
    if (values != null && (values.Count != 0 || this.m_inVariantWithEncoding))
    {
      this.PushArray(fieldName);
      if (this.m_context.MaxArrayLength > 0 && this.m_context.MaxArrayLength < values.Count)
        throw new ServiceResultException(2148007936U /*0x80080000*/);
      for (int index = 0; index < values.Count; ++index)
        this.WriteXmlElement((string) null, values[index]);
      this.PopArray();
    }
    else
      this.WriteSimpleField(fieldName, (string) null, false);
  }

  public void WriteNodeIdArray(string fieldName, IList<NodeId> values)
  {
    if (values != null && (values.Count != 0 || this.m_inVariantWithEncoding))
    {
      this.PushArray(fieldName);
      if (this.m_context.MaxArrayLength > 0 && this.m_context.MaxArrayLength < values.Count)
        throw new ServiceResultException(2148007936U /*0x80080000*/);
      for (int index = 0; index < values.Count; ++index)
        this.WriteNodeId((string) null, values[index]);
      this.PopArray();
    }
    else
      this.WriteSimpleField(fieldName, (string) null, false);
  }

  public void WriteExpandedNodeIdArray(string fieldName, IList<ExpandedNodeId> values)
  {
    if (values != null && (values.Count != 0 || this.m_inVariantWithEncoding))
    {
      this.PushArray(fieldName);
      if (this.m_context.MaxArrayLength > 0 && this.m_context.MaxArrayLength < values.Count)
        throw new ServiceResultException(2148007936U /*0x80080000*/);
      for (int index = 0; index < values.Count; ++index)
        this.WriteExpandedNodeId((string) null, values[index]);
      this.PopArray();
    }
    else
      this.WriteSimpleField(fieldName, (string) null, false);
  }

  public void WriteStatusCodeArray(string fieldName, IList<StatusCode> values)
  {
    if (values != null && (values.Count != 0 || this.m_inVariantWithEncoding))
    {
      this.PushArray(fieldName);
      if (this.m_context.MaxArrayLength > 0 && this.m_context.MaxArrayLength < values.Count)
        throw new ServiceResultException(2148007936U /*0x80080000*/);
      for (int index = 0; index < values.Count; ++index)
      {
        if (!this.UseReversibleEncoding && values[index] == 0U)
          this.WriteSimpleField((string) null, (string) null, false);
        else
          this.WriteStatusCode((string) null, values[index]);
      }
      this.PopArray();
    }
    else
      this.WriteSimpleField(fieldName, (string) null, false);
  }

  public void WriteDiagnosticInfoArray(string fieldName, IList<DiagnosticInfo> values)
  {
    if (values != null && (values.Count != 0 || this.m_inVariantWithEncoding))
    {
      this.PushArray(fieldName);
      if (this.m_context.MaxArrayLength > 0 && this.m_context.MaxArrayLength < values.Count)
        throw new ServiceResultException(2148007936U /*0x80080000*/);
      for (int index = 0; index < values.Count; ++index)
        this.WriteDiagnosticInfo((string) null, values[index]);
      this.PopArray();
    }
    else
      this.WriteSimpleField(fieldName, (string) null, false);
  }

  public void WriteQualifiedNameArray(string fieldName, IList<QualifiedName> values)
  {
    if (values != null && (values.Count != 0 || this.m_inVariantWithEncoding))
    {
      this.PushArray(fieldName);
      if (this.m_context.MaxArrayLength > 0 && this.m_context.MaxArrayLength < values.Count)
        throw new ServiceResultException(2148007936U /*0x80080000*/);
      for (int index = 0; index < values.Count; ++index)
        this.WriteQualifiedName((string) null, values[index]);
      this.PopArray();
    }
    else
      this.WriteSimpleField(fieldName, (string) null, false);
  }

  public void WriteLocalizedTextArray(string fieldName, IList<LocalizedText> values)
  {
    if (values != null && (values.Count != 0 || this.m_inVariantWithEncoding))
    {
      this.PushArray(fieldName);
      if (this.m_context.MaxArrayLength > 0 && this.m_context.MaxArrayLength < values.Count)
        throw new ServiceResultException(2148007936U /*0x80080000*/);
      for (int index = 0; index < values.Count; ++index)
        this.WriteLocalizedText((string) null, values[index]);
      this.PopArray();
    }
    else
      this.WriteSimpleField(fieldName, (string) null, false);
  }

  public void WriteVariantArray(string fieldName, IList<Variant> values)
  {
    if (values != null && (values.Count != 0 || this.m_inVariantWithEncoding))
    {
      this.PushArray(fieldName);
      if (this.m_context.MaxArrayLength > 0 && this.m_context.MaxArrayLength < values.Count)
        throw new ServiceResultException(2148007936U /*0x80080000*/);
      for (int index = 0; index < values.Count; ++index)
      {
        if (values[index] == Variant.Null)
          this.WriteSimpleField((string) null, (string) null, false);
        else
          this.WriteVariant((string) null, values[index]);
      }
      this.PopArray();
    }
    else
      this.WriteSimpleField(fieldName, (string) null, false);
  }

  public void WriteDataValueArray(string fieldName, IList<DataValue> values)
  {
    if (values != null && (values.Count != 0 || this.m_inVariantWithEncoding))
    {
      this.PushArray(fieldName);
      if (this.m_context.MaxArrayLength > 0 && this.m_context.MaxArrayLength < values.Count)
        throw new ServiceResultException(2148007936U /*0x80080000*/);
      for (int index = 0; index < values.Count; ++index)
        this.WriteDataValue((string) null, values[index]);
      this.PopArray();
    }
    else
      this.WriteSimpleField(fieldName, (string) null, false);
  }

  public void WriteExtensionObjectArray(string fieldName, IList<ExtensionObject> values)
  {
    if (values != null && (values.Count != 0 || this.m_inVariantWithEncoding))
    {
      this.PushArray(fieldName);
      if (this.m_context.MaxArrayLength > 0 && this.m_context.MaxArrayLength < values.Count)
        throw new ServiceResultException(2148007936U /*0x80080000*/);
      for (int index = 0; index < values.Count; ++index)
        this.WriteExtensionObject((string) null, values[index]);
      this.PopArray();
    }
    else
      this.WriteSimpleField(fieldName, (string) null, false);
  }

  public void WriteEncodeableArray(string fieldName, IList<IEncodeable> values, Type systemType)
  {
    if (values != null && (values.Count != 0 || this.m_inVariantWithEncoding))
    {
      if (string.IsNullOrWhiteSpace(fieldName) && this.m_nestingLevel == 0U && !this.m_topLevelIsArray)
      {
        this.m_writer.Flush();
        if (this.m_writer.BaseStream.Length == 1L)
          this.m_writer.BaseStream.Seek(0L, SeekOrigin.Begin);
        ++this.m_nestingLevel;
        this.PushArray(fieldName);
        for (int index = 0; index < values.Count; ++index)
          this.WriteEncodeable((string) null, values[index], systemType);
        this.PopArray();
        this.m_dontWriteClosing = true;
        --this.m_nestingLevel;
      }
      else
      {
        if (!string.IsNullOrWhiteSpace(fieldName) && this.m_nestingLevel == 0U && this.m_topLevelIsArray)
          throw ServiceResultException.Create(2147876864U /*0x80060000*/, "With Array as top level, encodeables array with filename will create invalid json");
        this.PushArray(fieldName);
        if (this.m_context.MaxArrayLength > 0 && this.m_context.MaxArrayLength < values.Count)
          throw new ServiceResultException(2148007936U /*0x80080000*/);
        for (int index = 0; index < values.Count; ++index)
          this.WriteEncodeable((string) null, values[index], systemType);
        this.PopArray();
      }
    }
    else
      this.WriteSimpleField(fieldName, (string) null, false);
  }

  public void WriteEnumeratedArray(string fieldName, Array values, Type systemType)
  {
    if (values != null && values.Length != 0)
    {
      this.PushArray(fieldName);
      if (this.m_context.MaxArrayLength > 0 && this.m_context.MaxArrayLength < values.Length)
        throw new ServiceResultException(2148007936U /*0x80080000*/);
      Type elementType = values.GetType().GetElementType();
      if (elementType.IsEnum)
      {
        foreach (Enum @enum in values)
          this.WriteEnumerated((string) null, @enum);
      }
      else
      {
        if (elementType != typeof (int))
          throw new ServiceResultException(2147876864U /*0x80060000*/, Utils.Format("Type '{0}' is not allowed in an Enumeration.", (object) elementType.FullName));
        foreach (int numeric in values)
          this.WriteEnumerated((string) null, numeric);
      }
      this.PopArray();
    }
    else
      this.WriteSimpleField(fieldName, (string) null, false);
  }

  public void WriteVariantContents(object value, TypeInfo typeInfo)
  {
    try
    {
      this.m_inVariantWithEncoding = this.UseReversibleEncoding;
      if (value == null)
        return;
      this.m_commaRequired = false;
      if (typeInfo.ValueRank < 0)
      {
        switch (typeInfo.BuiltInType)
        {
          case BuiltInType.Boolean:
            this.WriteBoolean((string) null, (bool) value);
            break;
          case BuiltInType.SByte:
            this.WriteSByte((string) null, (sbyte) value);
            break;
          case BuiltInType.Byte:
            this.WriteByte((string) null, (byte) value);
            break;
          case BuiltInType.Int16:
            this.WriteInt16((string) null, (short) value);
            break;
          case BuiltInType.UInt16:
            this.WriteUInt16((string) null, (ushort) value);
            break;
          case BuiltInType.Int32:
            this.WriteInt32((string) null, (int) value);
            break;
          case BuiltInType.UInt32:
            this.WriteUInt32((string) null, (uint) value);
            break;
          case BuiltInType.Int64:
            this.WriteInt64((string) null, (long) value);
            break;
          case BuiltInType.UInt64:
            this.WriteUInt64((string) null, (ulong) value);
            break;
          case BuiltInType.Float:
            this.WriteFloat((string) null, (float) value);
            break;
          case BuiltInType.Double:
            this.WriteDouble((string) null, (double) value);
            break;
          case BuiltInType.String:
            this.WriteString((string) null, (string) value);
            break;
          case BuiltInType.DateTime:
            this.WriteDateTime((string) null, (DateTime) value);
            break;
          case BuiltInType.Guid:
            this.WriteGuid((string) null, (Uuid) value);
            break;
          case BuiltInType.ByteString:
            this.WriteByteString((string) null, (byte[]) value);
            break;
          case BuiltInType.XmlElement:
            this.WriteXmlElement((string) null, (XmlElement) value);
            break;
          case BuiltInType.NodeId:
            this.WriteNodeId((string) null, (NodeId) value);
            break;
          case BuiltInType.ExpandedNodeId:
            this.WriteExpandedNodeId((string) null, (ExpandedNodeId) value);
            break;
          case BuiltInType.StatusCode:
            this.WriteStatusCode((string) null, (StatusCode) value);
            break;
          case BuiltInType.QualifiedName:
            this.WriteQualifiedName((string) null, (QualifiedName) value);
            break;
          case BuiltInType.LocalizedText:
            this.WriteLocalizedText((string) null, (LocalizedText) value);
            break;
          case BuiltInType.ExtensionObject:
            this.WriteExtensionObject((string) null, (ExtensionObject) value);
            break;
          case BuiltInType.DataValue:
            this.WriteDataValue((string) null, (DataValue) value);
            break;
          case BuiltInType.DiagnosticInfo:
            this.WriteDiagnosticInfo((string) null, (DiagnosticInfo) value);
            break;
          case BuiltInType.Enumeration:
            this.WriteEnumerated((string) null, (Enum) value);
            break;
        }
      }
      else
      {
        if (typeInfo.ValueRank < 1)
          return;
        int valueRank = typeInfo.ValueRank;
        if (this.UseReversibleEncoding && value is Matrix matrix)
        {
          value = (object) matrix.Elements;
          valueRank = 1;
        }
        this.WriteArray((string) null, value, valueRank, typeInfo.BuiltInType);
      }
    }
    finally
    {
      this.m_inVariantWithEncoding = false;
    }
  }

  public void WriteObjectArray(string fieldName, IList<object> values)
  {
    if (values != null && (values.Count != 0 || this.m_inVariantWithEncoding))
    {
      this.PushArray(fieldName);
      if (values != null && this.m_context.MaxArrayLength > 0 && this.m_context.MaxArrayLength < values.Count)
        throw new ServiceResultException(2148007936U /*0x80080000*/);
      if (values != null)
      {
        for (int index = 0; index < values.Count; ++index)
          this.WriteVariant("Variant", new Variant(values[index]));
      }
      this.PopArray();
    }
    else
      this.WriteSimpleField(fieldName, (string) null, false);
  }

  public void WriteArray(string fieldName, object array, int valueRank, BuiltInType builtInType)
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
          if (!(array is Array values4))
            throw ServiceResultException.Create(2147876864U /*0x80060000*/, "Unexpected non Array type encountered while encoding an array of enumeration.");
          this.WriteEnumeratedArray(fieldName, values4, values4.GetType().GetElementType());
          break;
        default:
          if (array is IEncodeable[] values5)
          {
            this.WriteEncodeableArray(fieldName, (IList<IEncodeable>) values5, array.GetType().GetElementType());
            break;
          }
          if (array == null)
          {
            this.WriteSimpleField(fieldName, (string) null, false);
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
label_45:
          if (matrix == null)
            return;
          int index = 0;
          this.WriteStructureMatrix(fieldName, matrix, 0, ref index, matrix.TypeInfo);
          return;
        case Array array1:
          if (array1.Rank == valueRank)
          {
            matrix = new Matrix(array1, builtInType);
            goto label_45;
          }
          break;
      }
      throw ServiceResultException.Create(2147876864U /*0x80060000*/, "Unexpected array type encountered while encoding array: {0}", (object) array.GetType().Name);
    }
  }

  private void WriteDiagnosticInfo(string fieldName, DiagnosticInfo value, int depth)
  {
    if (value != null && !value.IsNullDiagnosticInfo)
    {
      this.CheckAndIncrementNestingLevel();
      try
      {
        this.PushStructure(fieldName);
        if (value.SymbolicId >= 0)
          this.WriteSimpleField("SymbolicId", value.SymbolicId.ToString((IFormatProvider) CultureInfo.InvariantCulture), false);
        if (value.NamespaceUri >= 0)
          this.WriteSimpleField("NamespaceUri", value.NamespaceUri.ToString((IFormatProvider) CultureInfo.InvariantCulture), false);
        if (value.Locale >= 0)
          this.WriteSimpleField("Locale", value.Locale.ToString((IFormatProvider) CultureInfo.InvariantCulture), false);
        if (value.LocalizedText >= 0)
          this.WriteSimpleField("LocalizedText", value.LocalizedText.ToString((IFormatProvider) CultureInfo.InvariantCulture), false);
        if (value.AdditionalInfo != null)
          this.WriteSimpleField("AdditionalInfo", value.AdditionalInfo, true);
        if (value.InnerStatusCode != 0U)
          this.WriteStatusCode("InnerStatusCode", value.InnerStatusCode);
        if (value.InnerDiagnosticInfo != null)
        {
          if (depth < DiagnosticInfo.MaxInnerDepth)
            this.WriteDiagnosticInfo("InnerDiagnosticInfo", value.InnerDiagnosticInfo, depth + 1);
          else
            Utils.LogWarning("InnerDiagnosticInfo dropped because nesting exceeds maximum of {0}.", (object) DiagnosticInfo.MaxInnerDepth);
        }
        this.PopStructure();
      }
      finally
      {
        --this.m_nestingLevel;
      }
    }
    else
      this.WriteSimpleField(fieldName, (string) null, false);
  }

  private void WriteStructureMatrix(
    string fieldName,
    Matrix matrix,
    int dim,
    ref int index,
    TypeInfo typeInfo)
  {
    (bool valid, int flatLength) = Matrix.ValidateDimensions(true, (Int32Collection) matrix.Dimensions, this.Context.MaxArrayLength);
    if (!valid || flatLength != matrix.Elements.Length)
      throw new ArgumentException("The number of elements in the matrix does not match the dimensions.");
    this.CheckAndIncrementNestingLevel();
    try
    {
      int dimension = matrix.Dimensions[dim];
      if (dim == matrix.Dimensions.Length - 1)
      {
        Array instance = Array.CreateInstance(matrix.Elements.GetType().GetElementType(), dimension);
        Array.Copy(matrix.Elements, index, instance, 0, dimension);
        if (this.m_commaRequired)
          this.m_writer.Write(",");
        this.WriteVariantContents((object) instance, new TypeInfo(typeInfo.BuiltInType, 1));
        index += dimension;
      }
      else
      {
        this.PushArray(fieldName);
        for (int index1 = 0; index1 < dimension; ++index1)
          this.WriteStructureMatrix((string) null, matrix, dim + 1, ref index, typeInfo);
        this.PopArray();
      }
    }
    finally
    {
      --this.m_nestingLevel;
    }
  }

  private void CheckAndIncrementNestingLevel()
  {
    if (this.m_nestingLevel > this.m_context.MaxEncodingNestingLevels)
      throw ServiceResultException.Create(2148007936U /*0x80080000*/, "Maximum nesting level of {0} was exceeded", (object) this.m_context.MaxEncodingNestingLevels);
    ++this.m_nestingLevel;
  }
}
