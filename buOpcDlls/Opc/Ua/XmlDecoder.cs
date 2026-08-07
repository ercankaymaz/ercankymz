// Decompiled with JetBrains decompiler
// Type: Opc.Ua.XmlDecoder
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
public class XmlDecoder : IDecoder, IDisposable
{
  private XmlReader m_reader;
  private Stack<string> m_namespaces;
  private IServiceMessageContext m_context;
  private ushort[] m_namespaceMappings;
  private ushort[] m_serverMappings;
  private uint m_nestingLevel;

  public XmlDecoder(IServiceMessageContext context)
  {
    if (context == null)
      throw new ArgumentNullException(nameof (context));
    this.Initialize();
    this.m_context = context;
    this.m_nestingLevel = 0U;
  }

  public XmlDecoder(XmlElement element, IServiceMessageContext context)
  {
    if (context == null)
      throw new ArgumentNullException(nameof (context));
    this.Initialize();
    this.m_reader = XmlReader.Create((TextReader) new StringReader(element.OuterXml), Utils.DefaultXmlReaderSettings());
    this.m_context = context;
    this.m_nestingLevel = 0U;
  }

  public XmlDecoder(Type systemType, XmlReader reader, IServiceMessageContext context)
  {
    this.Initialize();
    this.m_reader = reader;
    this.m_context = context;
    this.m_nestingLevel = 0U;
    string namespaceUri = (string) null;
    string fieldName = (string) null;
    if (systemType != (Type) null)
    {
      XmlQualifiedName xmlName = EncodeableFactory.GetXmlName(systemType);
      namespaceUri = xmlName.Namespace;
      fieldName = xmlName.Name;
    }
    if (namespaceUri == null)
    {
      int content = (int) this.m_reader.MoveToContent();
      namespaceUri = this.m_reader.NamespaceURI;
      fieldName = this.m_reader.Name;
    }
    int num = fieldName.IndexOf(':');
    if (num != -1)
      fieldName = fieldName.Substring(num + 1);
    this.PushNamespace(namespaceUri);
    this.BeginField(fieldName, false);
  }

  private void Initialize()
  {
    this.m_reader = (XmlReader) null;
    this.m_namespaces = new Stack<string>();
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

  public bool LoadStringTable(string tableName, string elementName, StringTable stringTable)
  {
    this.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    try
    {
      if (!this.Peek(tableName))
        return false;
      this.ReadStartElement();
      while (this.Peek(elementName))
      {
        string str = this.ReadString(elementName);
        stringTable.Append(str);
      }
      this.Skip(new XmlQualifiedName(tableName, "http://opcfoundation.org/UA/2008/02/Types.xsd"));
      return true;
    }
    finally
    {
      this.PopNamespace();
    }
  }

  public void Close() => this.m_reader.Dispose();

  public void Close(bool checkEof)
  {
    if (checkEof && this.m_reader.NodeType != XmlNodeType.None)
      this.m_reader.ReadEndElement();
    this.m_reader.Dispose();
  }

  public XmlQualifiedName Peek(XmlNodeType nodeType)
  {
    int content = (int) this.m_reader.MoveToContent();
    return nodeType != XmlNodeType.None && nodeType != this.m_reader.NodeType ? (XmlQualifiedName) null : new XmlQualifiedName(this.m_reader.LocalName, this.m_reader.NamespaceURI);
  }

  public bool Peek(string fieldName)
  {
    int content = (int) this.m_reader.MoveToContent();
    return XmlNodeType.Element == this.m_reader.NodeType && !(fieldName != this.m_reader.LocalName) && !(this.m_namespaces.Peek() != this.m_reader.NamespaceURI);
  }

  public void ReadStartElement()
  {
    int num = this.m_reader.IsEmptyElement ? 1 : 0;
    this.m_reader.ReadStartElement();
    if (num != 0)
      return;
    int content = (int) this.m_reader.MoveToContent();
  }

  public void Skip(XmlQualifiedName qname)
  {
    int content1 = (int) this.m_reader.MoveToContent();
    int num = 1;
    while (num > 0)
    {
      if (this.m_reader.NodeType == XmlNodeType.EndElement)
      {
        if (this.m_reader.LocalName == qname.Name && this.m_reader.NamespaceURI == qname.Namespace)
          --num;
      }
      else if (this.m_reader.NodeType == XmlNodeType.Element && this.m_reader.LocalName == qname.Name && this.m_reader.NamespaceURI == qname.Namespace)
        ++num;
      this.m_reader.Skip();
      int content2 = (int) this.m_reader.MoveToContent();
    }
  }

  public object ReadVariantContents(out TypeInfo typeInfo)
  {
    typeInfo = TypeInfo.Unknown;
    while (this.m_reader.NodeType != XmlNodeType.Element)
      this.m_reader.Read();
    try
    {
      this.m_namespaces.Push("http://opcfoundation.org/UA/2008/02/Types.xsd");
      string localName = this.m_reader.LocalName;
      if (localName.StartsWith("ListOf", StringComparison.Ordinal))
      {
        string str = localName.Substring("ListOf".Length);
        if (str != null)
        {
          switch (str.Length)
          {
            case 4:
              switch (str[0])
              {
                case 'B':
                  if (str == "Byte")
                  {
                    typeInfo = TypeInfo.Arrays.Byte;
                    ByteCollection byteCollection = this.ReadByteArray(localName);
                    return byteCollection != null ? (object) byteCollection.ToArray() : (object) null;
                  }
                  break;
                case 'G':
                  if (str == "Guid")
                  {
                    typeInfo = TypeInfo.Arrays.Guid;
                    UuidCollection uuidCollection = this.ReadGuidArray(localName);
                    return uuidCollection != null ? (object) uuidCollection.ToArray() : (object) null;
                  }
                  break;
              }
              break;
            case 5:
              switch (str[3])
              {
                case '1':
                  if (str == "Int16")
                  {
                    typeInfo = TypeInfo.Arrays.Int16;
                    Int16Collection int16Collection = this.ReadInt16Array(localName);
                    return int16Collection != null ? (object) int16Collection.ToArray() : (object) null;
                  }
                  break;
                case '3':
                  if (str == "Int32")
                  {
                    typeInfo = TypeInfo.Arrays.Int32;
                    Int32Collection int32Collection = this.ReadInt32Array(localName);
                    return int32Collection != null ? (object) int32Collection.ToArray() : (object) null;
                  }
                  break;
                case '6':
                  if (str == "Int64")
                  {
                    typeInfo = TypeInfo.Arrays.Int64;
                    Int64Collection int64Collection = this.ReadInt64Array(localName);
                    return int64Collection != null ? (object) int64Collection.ToArray() : (object) null;
                  }
                  break;
                case 'a':
                  if (str == "Float")
                  {
                    typeInfo = TypeInfo.Arrays.Float;
                    FloatCollection floatCollection = this.ReadFloatArray(localName);
                    return floatCollection != null ? (object) floatCollection.ToArray() : (object) null;
                  }
                  break;
                case 't':
                  if (str == "SByte")
                  {
                    typeInfo = TypeInfo.Arrays.SByte;
                    SByteCollection sbyteCollection = this.ReadSByteArray(localName);
                    return sbyteCollection != null ? (object) sbyteCollection.ToArray() : (object) null;
                  }
                  break;
              }
              break;
            case 6:
              switch (str[4])
              {
                case '1':
                  if (str == "UInt16")
                  {
                    typeInfo = TypeInfo.Arrays.UInt16;
                    UInt16Collection uint16Collection = this.ReadUInt16Array(localName);
                    return uint16Collection != null ? (object) uint16Collection.ToArray() : (object) null;
                  }
                  break;
                case '3':
                  if (str == "UInt32")
                  {
                    typeInfo = TypeInfo.Arrays.UInt32;
                    UInt32Collection uint32Collection = this.ReadUInt32Array(localName);
                    return uint32Collection != null ? (object) uint32Collection.ToArray() : (object) null;
                  }
                  break;
                case '6':
                  if (str == "UInt64")
                  {
                    typeInfo = TypeInfo.Arrays.UInt64;
                    UInt64Collection uint64Collection = this.ReadUInt64Array(localName);
                    return uint64Collection != null ? (object) uint64Collection.ToArray() : (object) null;
                  }
                  break;
                case 'I':
                  if (str == "NodeId")
                  {
                    typeInfo = TypeInfo.Arrays.NodeId;
                    NodeIdCollection nodeIdCollection = this.ReadNodeIdArray(localName);
                    return nodeIdCollection != null ? (object) nodeIdCollection.ToArray() : (object) null;
                  }
                  break;
                case 'l':
                  if (str == "Double")
                  {
                    typeInfo = TypeInfo.Arrays.Double;
                    DoubleCollection doubleCollection = this.ReadDoubleArray(localName);
                    return doubleCollection != null ? (object) doubleCollection.ToArray() : (object) null;
                  }
                  break;
                case 'n':
                  if (str == "String")
                  {
                    typeInfo = TypeInfo.Arrays.String;
                    StringCollection stringCollection = this.ReadStringArray(localName);
                    return stringCollection != null ? (object) stringCollection.ToArray() : (object) null;
                  }
                  break;
              }
              break;
            case 7:
              switch (str[0])
              {
                case 'B':
                  if (str == "Boolean")
                  {
                    typeInfo = TypeInfo.Arrays.Boolean;
                    BooleanCollection booleanCollection = this.ReadBooleanArray(localName);
                    return booleanCollection != null ? (object) booleanCollection.ToArray() : (object) null;
                  }
                  break;
                case 'V':
                  if (str == "Variant")
                  {
                    typeInfo = TypeInfo.Arrays.Variant;
                    VariantCollection variantCollection = this.ReadVariantArray(localName);
                    return variantCollection != null ? (object) variantCollection.ToArray() : (object) null;
                  }
                  break;
              }
              break;
            case 8:
              if (str == "DateTime")
              {
                typeInfo = TypeInfo.Arrays.DateTime;
                DateTimeCollection dateTimeCollection = this.ReadDateTimeArray(localName);
                return dateTimeCollection != null ? (object) dateTimeCollection.ToArray() : (object) null;
              }
              break;
            case 9:
              if (str == "DataValue")
              {
                typeInfo = TypeInfo.Arrays.DataValue;
                DataValueCollection dataValueCollection = this.ReadDataValueArray(localName);
                return dataValueCollection != null ? (object) dataValueCollection.ToArray() : (object) null;
              }
              break;
            case 10:
              switch (str[0])
              {
                case 'B':
                  if (str == "ByteString")
                  {
                    typeInfo = TypeInfo.Arrays.ByteString;
                    ByteStringCollection stringCollection = this.ReadByteStringArray(localName);
                    return stringCollection != null ? (object) stringCollection.ToArray() : (object) null;
                  }
                  break;
                case 'S':
                  if (str == "StatusCode")
                  {
                    typeInfo = TypeInfo.Arrays.StatusCode;
                    StatusCodeCollection statusCodeCollection = this.ReadStatusCodeArray(localName);
                    return statusCodeCollection != null ? (object) statusCodeCollection.ToArray() : (object) null;
                  }
                  break;
                case 'X':
                  if (str == "XmlElement")
                  {
                    typeInfo = TypeInfo.Arrays.XmlElement;
                    XmlElementCollection elementCollection = this.ReadXmlElementArray(localName);
                    return elementCollection != null ? (object) elementCollection.ToArray() : (object) null;
                  }
                  break;
              }
              break;
            case 13:
              switch (str[0])
              {
                case 'L':
                  if (str == "LocalizedText")
                  {
                    typeInfo = TypeInfo.Arrays.LocalizedText;
                    LocalizedTextCollection localizedTextCollection = this.ReadLocalizedTextArray(localName);
                    return localizedTextCollection != null ? (object) localizedTextCollection.ToArray() : (object) null;
                  }
                  break;
                case 'Q':
                  if (str == "QualifiedName")
                  {
                    typeInfo = TypeInfo.Arrays.QualifiedName;
                    QualifiedNameCollection qualifiedNameCollection = this.ReadQualifiedNameArray(localName);
                    return qualifiedNameCollection != null ? (object) qualifiedNameCollection.ToArray() : (object) null;
                  }
                  break;
              }
              break;
            case 14:
              switch (str[0])
              {
                case 'D':
                  if (str == "DiagnosticInfo")
                  {
                    typeInfo = TypeInfo.Arrays.DiagnosticInfo;
                    DiagnosticInfoCollection diagnosticInfoCollection = this.ReadDiagnosticInfoArray(localName);
                    return diagnosticInfoCollection != null ? (object) diagnosticInfoCollection.ToArray() : (object) null;
                  }
                  break;
                case 'E':
                  if (str == "ExpandedNodeId")
                  {
                    typeInfo = TypeInfo.Arrays.ExpandedNodeId;
                    ExpandedNodeIdCollection nodeIdCollection = this.ReadExpandedNodeIdArray(localName);
                    return nodeIdCollection != null ? (object) nodeIdCollection.ToArray() : (object) null;
                  }
                  break;
              }
              break;
            case 15:
              if (str == "ExtensionObject")
              {
                typeInfo = TypeInfo.Arrays.ExtensionObject;
                ExtensionObjectCollection objectCollection = this.ReadExtensionObjectArray(localName);
                return objectCollection != null ? (object) objectCollection.ToArray() : (object) null;
              }
              break;
          }
        }
      }
      else if (localName != null)
      {
        switch (localName.Length)
        {
          case 4:
            switch (localName[0])
            {
              case 'B':
                if (localName == "Byte")
                {
                  typeInfo = TypeInfo.Scalars.Byte;
                  return (object) this.ReadByte(localName);
                }
                break;
              case 'G':
                if (localName == "Guid")
                {
                  typeInfo = TypeInfo.Scalars.Guid;
                  return (object) this.ReadGuid(localName);
                }
                break;
              case 'N':
                if (localName == "Null")
                {
                  if (this.BeginField(localName, true))
                    this.EndField(localName);
                  return (object) null;
                }
                break;
            }
            break;
          case 5:
            switch (localName[3])
            {
              case '1':
                if (localName == "Int16")
                {
                  typeInfo = TypeInfo.Scalars.Int16;
                  return (object) this.ReadInt16(localName);
                }
                break;
              case '3':
                if (localName == "Int32")
                {
                  typeInfo = TypeInfo.Scalars.Int32;
                  return (object) this.ReadInt32(localName);
                }
                break;
              case '6':
                if (localName == "Int64")
                {
                  typeInfo = TypeInfo.Scalars.Int64;
                  return (object) this.ReadInt64(localName);
                }
                break;
              case 'a':
                if (localName == "Float")
                {
                  typeInfo = TypeInfo.Scalars.Float;
                  return (object) this.ReadFloat(localName);
                }
                break;
              case 't':
                if (localName == "SByte")
                {
                  typeInfo = TypeInfo.Scalars.SByte;
                  return (object) this.ReadSByte(localName);
                }
                break;
            }
            break;
          case 6:
            switch (localName[4])
            {
              case '1':
                if (localName == "UInt16")
                {
                  typeInfo = TypeInfo.Scalars.UInt16;
                  return (object) this.ReadUInt16(localName);
                }
                break;
              case '3':
                if (localName == "UInt32")
                {
                  typeInfo = TypeInfo.Scalars.UInt32;
                  return (object) this.ReadUInt32(localName);
                }
                break;
              case '6':
                if (localName == "UInt64")
                {
                  typeInfo = TypeInfo.Scalars.UInt64;
                  return (object) this.ReadUInt64(localName);
                }
                break;
              case 'I':
                if (localName == "NodeId")
                {
                  typeInfo = TypeInfo.Scalars.NodeId;
                  return (object) this.ReadNodeId(localName);
                }
                break;
              case 'i':
                if (localName == "Matrix")
                {
                  Matrix matrix = this.ReadMatrix(localName);
                  typeInfo = matrix.TypeInfo;
                  return (object) matrix;
                }
                break;
              case 'l':
                if (localName == "Double")
                {
                  typeInfo = TypeInfo.Scalars.Double;
                  return (object) this.ReadDouble(localName);
                }
                break;
              case 'n':
                if (localName == "String")
                {
                  typeInfo = TypeInfo.Scalars.String;
                  return (object) this.ReadString(localName);
                }
                break;
            }
            break;
          case 7:
            if (localName == "Boolean")
            {
              typeInfo = TypeInfo.Scalars.Boolean;
              return (object) this.ReadBoolean(localName);
            }
            break;
          case 8:
            if (localName == "DateTime")
            {
              typeInfo = TypeInfo.Scalars.DateTime;
              return (object) this.ReadDateTime(localName);
            }
            break;
          case 9:
            if (localName == "DataValue")
            {
              typeInfo = TypeInfo.Scalars.DataValue;
              return (object) this.ReadDataValue(localName);
            }
            break;
          case 10:
            switch (localName[0])
            {
              case 'B':
                if (localName == "ByteString")
                {
                  typeInfo = TypeInfo.Scalars.ByteString;
                  return (object) this.ReadByteString(localName);
                }
                break;
              case 'S':
                if (localName == "StatusCode")
                {
                  typeInfo = TypeInfo.Scalars.StatusCode;
                  return (object) this.ReadStatusCode(localName);
                }
                break;
              case 'X':
                if (localName == "XmlElement")
                {
                  typeInfo = TypeInfo.Scalars.XmlElement;
                  return (object) this.ReadXmlElement(localName);
                }
                break;
            }
            break;
          case 13:
            switch (localName[0])
            {
              case 'L':
                if (localName == "LocalizedText")
                {
                  typeInfo = TypeInfo.Scalars.LocalizedText;
                  return (object) this.ReadLocalizedText(localName);
                }
                break;
              case 'Q':
                if (localName == "QualifiedName")
                {
                  typeInfo = TypeInfo.Scalars.QualifiedName;
                  return (object) this.ReadQualifiedName(localName);
                }
                break;
            }
            break;
          case 14:
            switch (localName[0])
            {
              case 'D':
                if (localName == "DiagnosticInfo")
                {
                  typeInfo = TypeInfo.Scalars.DiagnosticInfo;
                  return (object) this.ReadDiagnosticInfo(localName);
                }
                break;
              case 'E':
                if (localName == "ExpandedNodeId")
                {
                  typeInfo = TypeInfo.Scalars.ExpandedNodeId;
                  return (object) this.ReadExpandedNodeId(localName);
                }
                break;
            }
            break;
          case 15:
            if (localName == "ExtensionObject")
            {
              typeInfo = TypeInfo.Scalars.ExtensionObject;
              return (object) this.ReadExtensionObject(localName);
            }
            break;
        }
      }
      throw new ServiceResultException(2147942400U /*0x80070000*/, Utils.Format("Element '{1}:{0}' is not allowed in an Variant.", (object) this.m_reader.LocalName, (object) this.m_reader.NamespaceURI));
    }
    finally
    {
      this.m_namespaces.Pop();
    }
  }

  public object ReadExtensionObjectBody(ExpandedNodeId typeId)
  {
    int content = (int) this.m_reader.MoveToContent();
    if (this.m_reader.LocalName == "ByteString" && this.m_reader.NamespaceURI == "http://opcfoundation.org/UA/2008/02/Types.xsd")
    {
      this.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
      byte[] numArray = this.ReadByteString("ByteString");
      this.PopNamespace();
      return (object) numArray;
    }
    Type systemType = this.m_context.Factory.GetSystemType(typeId);
    if (systemType != (Type) null)
    {
      this.PushNamespace(this.m_reader.NamespaceURI);
      IEncodeable encodeable = this.ReadEncodeable(this.m_reader.LocalName, systemType, typeId);
      this.PopNamespace();
      return (object) encodeable;
    }
    XmlDocument xmlDocument = new XmlDocument();
    using (StringReader input = new StringReader(this.m_reader.ReadOuterXml()))
    {
      using (XmlReader reader = XmlReader.Create((TextReader) input, Utils.DefaultXmlReaderSettings()))
        xmlDocument.Load(reader);
    }
    return (object) xmlDocument.DocumentElement;
  }

  public void Dispose()
  {
    this.Dispose(true);
    GC.SuppressFinalize((object) this);
  }

  protected virtual void Dispose(bool disposing)
  {
    if (!disposing || this.m_reader == null)
      return;
    this.m_reader.Dispose();
  }

  public EncodingType EncodingType => EncodingType.Xml;

  public IServiceMessageContext Context => this.m_context;

  public void PushNamespace(string namespaceUri) => this.m_namespaces.Push(namespaceUri);

  public void PopNamespace() => this.m_namespaces.Pop();

  public bool ReadBoolean(string fieldName)
  {
    if (this.BeginField(fieldName, true))
    {
      string str = this.ReadString();
      if (!string.IsNullOrEmpty(str))
      {
        int num = XmlConvert.ToBoolean(str.ToLowerInvariant()) ? 1 : 0;
        this.EndField(fieldName);
        return num != 0;
      }
    }
    return false;
  }

  public sbyte ReadSByte(string fieldName)
  {
    if (this.BeginField(fieldName, true))
    {
      string s = this.ReadString();
      if (!string.IsNullOrEmpty(s))
      {
        int num = (int) XmlConvert.ToSByte(s);
        this.EndField(fieldName);
        return (sbyte) num;
      }
    }
    return 0;
  }

  public byte ReadByte(string fieldName)
  {
    if (this.BeginField(fieldName, true))
    {
      string s = this.ReadString();
      if (!string.IsNullOrEmpty(s))
      {
        int num = (int) XmlConvert.ToByte(s);
        this.EndField(fieldName);
        return (byte) num;
      }
    }
    return 0;
  }

  public short ReadInt16(string fieldName)
  {
    if (this.BeginField(fieldName, true))
    {
      string s = this.ReadString();
      if (!string.IsNullOrEmpty(s))
      {
        int int16 = (int) XmlConvert.ToInt16(s);
        this.EndField(fieldName);
        return (short) int16;
      }
    }
    return 0;
  }

  public ushort ReadUInt16(string fieldName)
  {
    if (this.BeginField(fieldName, true))
    {
      string s = this.ReadString();
      if (!string.IsNullOrEmpty(s))
      {
        int uint16 = (int) XmlConvert.ToUInt16(s);
        this.EndField(fieldName);
        return (ushort) uint16;
      }
    }
    return 0;
  }

  public int ReadInt32(string fieldName)
  {
    if (this.BeginField(fieldName, true))
    {
      string s = this.ReadString();
      if (!string.IsNullOrEmpty(s))
      {
        int int32 = XmlConvert.ToInt32(s);
        this.EndField(fieldName);
        return int32;
      }
    }
    return 0;
  }

  public uint ReadUInt32(string fieldName)
  {
    if (this.BeginField(fieldName, true))
    {
      string s = this.ReadString();
      if (!string.IsNullOrEmpty(s))
      {
        int uint32 = (int) XmlConvert.ToUInt32(s);
        this.EndField(fieldName);
        return (uint) uint32;
      }
    }
    return 0;
  }

  public long ReadInt64(string fieldName)
  {
    if (this.BeginField(fieldName, true))
    {
      string s = this.ReadString();
      if (!string.IsNullOrEmpty(s))
      {
        long int64 = XmlConvert.ToInt64(s);
        this.EndField(fieldName);
        return int64;
      }
    }
    return 0;
  }

  public ulong ReadUInt64(string fieldName)
  {
    if (this.BeginField(fieldName, true))
    {
      string s = this.ReadString();
      if (!string.IsNullOrEmpty(s))
      {
        long uint64 = (long) XmlConvert.ToUInt64(s);
        this.EndField(fieldName);
        return (ulong) uint64;
      }
    }
    return 0;
  }

  public float ReadFloat(string fieldName)
  {
    if (this.BeginField(fieldName, true))
    {
      string s = this.ReadString();
      if (!string.IsNullOrEmpty(s))
      {
        float num = 0.0f;
        if (s.Length == 3)
        {
          if (s == "NaN")
            num = float.NaN;
          if (s == "INF")
            num = float.PositiveInfinity;
        }
        if (s.Length == 4 && s == "-INF")
          num = float.NegativeInfinity;
        if ((double) num == 0.0)
          num = XmlConvert.ToSingle(s);
        this.EndField(fieldName);
        return num;
      }
    }
    return 0.0f;
  }

  public double ReadDouble(string fieldName)
  {
    if (this.BeginField(fieldName, true))
    {
      string s = this.ReadString();
      if (!string.IsNullOrEmpty(s))
      {
        double num = 0.0;
        if (s.Length == 3)
        {
          if (s == "NaN")
            num = double.NaN;
          if (s == "INF")
            num = double.PositiveInfinity;
        }
        if (s.Length == 4 && s == "-INF")
          num = double.NegativeInfinity;
        if (num == 0.0)
          num = XmlConvert.ToDouble(s);
        this.EndField(fieldName);
        return num;
      }
    }
    return 0.0;
  }

  public string ReadString(string fieldName)
  {
    bool isNil = false;
    if (this.BeginField(fieldName, true, out isNil))
    {
      string str = this.ReadString();
      if (str != null)
        str = str.Trim();
      this.EndField(fieldName);
      return str;
    }
    return !isNil ? string.Empty : (string) null;
  }

  public DateTime ReadDateTime(string fieldName)
  {
    if (this.BeginField(fieldName, true))
    {
      string s = this.ReadString();
      if (this.m_context.MaxStringLength > 0 && this.m_context.MaxStringLength < s.Length)
        throw new ServiceResultException(2148007936U /*0x80080000*/);
      if (!string.IsNullOrEmpty(s))
      {
        DateTime dateTime = XmlConvert.ToDateTime(s, XmlDateTimeSerializationMode.Utc);
        this.EndField(fieldName);
        return dateTime;
      }
    }
    return DateTime.MinValue;
  }

  public Uuid ReadGuid(string fieldName)
  {
    Uuid uuid = new Uuid();
    if (this.BeginField(fieldName, true))
    {
      this.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
      uuid.GuidString = this.ReadString("String");
      this.PopNamespace();
      this.EndField(fieldName);
    }
    return uuid;
  }

  public byte[] ReadByteString(string fieldName)
  {
    bool isNil = false;
    if (this.BeginField(fieldName, true, out isNil))
    {
      string s = this.m_reader.ReadContentAsString();
      byte[] numArray = string.IsNullOrEmpty(s) ? Array.Empty<byte>() : Convert.FromBase64String(s);
      if (this.m_context.MaxByteStringLength > 0 && this.m_context.MaxByteStringLength < numArray.Length)
        throw new ServiceResultException(2148007936U /*0x80080000*/);
      this.EndField(fieldName);
      return numArray;
    }
    return !isNil ? Array.Empty<byte>() : (byte[]) null;
  }

  private void ExtractXml(StringBuilder builder)
  {
    builder.Append('<');
    builder.Append(this.m_reader.Prefix);
    builder.Append(':');
    builder.Append(this.m_reader.LocalName);
    if (this.m_reader.HasAttributes)
    {
      for (int i = 0; i < this.m_reader.AttributeCount; ++i)
      {
        this.m_reader.MoveToAttribute(i);
        builder.Append(' ');
        builder.Append(this.m_reader.Name);
        builder.Append("='");
        builder.Append(this.m_reader.Value);
        builder.Append('\'');
      }
      this.m_reader.MoveToElement();
    }
    int content = (int) this.m_reader.MoveToContent();
    while (this.m_reader.NodeType != XmlNodeType.EndElement)
    {
      if (this.m_reader.IsStartElement())
        this.ExtractXml(builder);
      else
        builder.Append(this.m_reader.ReadContentAsString());
    }
    this.m_reader.ReadEndElement();
  }

  public XmlElement ReadXmlElement(string fieldName)
  {
    if (!this.BeginField(fieldName, true) || !this.MoveToElement((string) null))
      return (XmlElement) null;
    XmlDocument xmlDocument = new XmlDocument();
    XmlElement element = xmlDocument.CreateElement(this.m_reader.Prefix, this.m_reader.LocalName, this.m_reader.NamespaceURI);
    xmlDocument.AppendChild((XmlNode) element);
    if (this.m_reader.MoveToFirstAttribute())
    {
      do
      {
        XmlAttribute attribute = xmlDocument.CreateAttribute(this.m_reader.Name);
        attribute.Value = this.m_reader.Value;
        element.Attributes.Append(attribute);
      }
      while (this.m_reader.MoveToNextAttribute());
      int content = (int) this.m_reader.MoveToContent();
    }
    element.InnerXml = this.m_reader.ReadInnerXml();
    this.EndField(fieldName);
    return element;
  }

  public NodeId ReadNodeId(string fieldName)
  {
    NodeId nodeId = new NodeId();
    if (this.BeginField(fieldName, true))
    {
      this.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
      nodeId.IdentifierText = this.ReadString("Identifier");
      this.PopNamespace();
      this.EndField(fieldName);
    }
    if (this.m_namespaceMappings != null && this.m_namespaceMappings.Length > (int) nodeId.NamespaceIndex)
      nodeId.SetNamespaceIndex(this.m_namespaceMappings[(int) nodeId.NamespaceIndex]);
    return nodeId;
  }

  public ExpandedNodeId ReadExpandedNodeId(string fieldName)
  {
    ExpandedNodeId expandedNodeId = new ExpandedNodeId();
    if (this.BeginField(fieldName, true))
    {
      this.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
      expandedNodeId.IdentifierText = this.ReadString("Identifier");
      this.PopNamespace();
      this.EndField(fieldName);
    }
    if (this.m_namespaceMappings != null && this.m_namespaceMappings.Length > (int) expandedNodeId.NamespaceIndex)
      expandedNodeId.SetNamespaceIndex(this.m_namespaceMappings[(int) expandedNodeId.NamespaceIndex]);
    if (this.m_serverMappings != null && (long) this.m_serverMappings.Length > (long) expandedNodeId.ServerIndex)
      expandedNodeId.SetServerIndex((uint) this.m_serverMappings[(int) expandedNodeId.ServerIndex]);
    return expandedNodeId;
  }

  public StatusCode ReadStatusCode(string fieldName)
  {
    StatusCode statusCode = new StatusCode();
    if (this.BeginField(fieldName, true))
    {
      this.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
      statusCode.Code = this.ReadUInt32("Code");
      this.PopNamespace();
      this.EndField(fieldName);
    }
    return statusCode;
  }

  public DiagnosticInfo ReadDiagnosticInfo(string fieldName)
  {
    DiagnosticInfo diagnosticInfo1 = (DiagnosticInfo) null;
    if (!this.BeginField(fieldName, true))
      return diagnosticInfo1;
    this.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    DiagnosticInfo diagnosticInfo2 = this.ReadDiagnosticInfo(0);
    this.PopNamespace();
    this.EndField(fieldName);
    return diagnosticInfo2;
  }

  public QualifiedName ReadQualifiedName(string fieldName)
  {
    if (!this.BeginField(fieldName, true))
      return new QualifiedName();
    this.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    ushort namespaceIndex = 0;
    if (this.BeginField("NamespaceIndex", true))
    {
      namespaceIndex = this.ReadUInt16((string) null);
      this.EndField("NamespaceIndex");
    }
    bool isNil = false;
    string name = (string) null;
    if (this.BeginField("Name", true, out isNil))
    {
      name = this.ReadString((string) null);
      this.EndField("Name");
    }
    else if (!isNil)
      name = string.Empty;
    this.PopNamespace();
    this.EndField(fieldName);
    if (this.m_namespaceMappings != null && this.m_namespaceMappings.Length > (int) namespaceIndex)
      namespaceIndex = this.m_namespaceMappings[(int) namespaceIndex];
    return new QualifiedName(name, namespaceIndex);
  }

  public LocalizedText ReadLocalizedText(string fieldName)
  {
    if (!this.BeginField(fieldName, true))
      return LocalizedText.Null;
    this.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    bool isNil = false;
    string text = (string) null;
    string locale = (string) null;
    if (this.BeginField("Locale", true, out isNil))
    {
      locale = this.ReadString((string) null);
      this.EndField("Locale");
    }
    else if (!isNil)
      locale = string.Empty;
    if (this.BeginField("Text", true, out isNil))
    {
      text = this.ReadString((string) null);
      this.EndField("Text");
    }
    else if (!isNil)
      text = string.Empty;
    LocalizedText localizedText = new LocalizedText(locale, text);
    this.PopNamespace();
    this.EndField(fieldName);
    return localizedText;
  }

  public Variant ReadVariant(string fieldName)
  {
    this.CheckAndIncrementNestingLevel();
    try
    {
      Variant variant = new Variant();
      if (this.BeginField(fieldName, true))
      {
        this.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
        if (this.BeginField("Value", true))
        {
          try
          {
            TypeInfo typeInfo = (TypeInfo) null;
            variant = new Variant(this.ReadVariantContents(out typeInfo), typeInfo);
          }
          catch (Exception ex)
          {
            object[] objArray = Array.Empty<object>();
            Utils.LogError(ex, "XmlDecoder: Error reading variant.", objArray);
            variant = new Variant(2147942400U /*0x80070000*/);
          }
          this.EndField("Value");
        }
        this.PopNamespace();
        this.EndField(fieldName);
      }
      return variant;
    }
    finally
    {
      --this.m_nestingLevel;
    }
  }

  public DataValue ReadDataValue(string fieldName)
  {
    DataValue dataValue = new DataValue();
    if (this.BeginField(fieldName, true))
    {
      this.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
      dataValue.WrappedValue = this.ReadVariant("Value");
      dataValue.StatusCode = this.ReadStatusCode("StatusCode");
      dataValue.SourceTimestamp = this.ReadDateTime("SourceTimestamp");
      dataValue.SourcePicoseconds = this.ReadUInt16("SourcePicoseconds");
      dataValue.ServerTimestamp = this.ReadDateTime("ServerTimestamp");
      dataValue.ServerPicoseconds = this.ReadUInt16("ServerPicoseconds");
      this.PopNamespace();
      this.EndField(fieldName);
    }
    return dataValue;
  }

  public ExtensionObject ReadExtensionObject(string fieldName)
  {
    bool isNil;
    if (!this.BeginField(fieldName, true, out isNil))
      return isNil ? (ExtensionObject) null : ExtensionObject.Null;
    this.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    NodeId nodeId = this.ReadNodeId("TypeId");
    ExpandedNodeId expandedNodeId = NodeId.ToExpandedNodeId(nodeId, this.m_context.NamespaceUris);
    if (!NodeId.IsNull(nodeId) && NodeId.IsNull(expandedNodeId))
      Utils.LogWarning("Cannot de-serialized extension objects if the NamespaceUri is not in the NamespaceTable: Type = {0}", (object) nodeId);
    if (!this.BeginField("Body", true))
    {
      this.EndField(fieldName);
      this.PopNamespace();
      return new ExtensionObject(expandedNodeId);
    }
    object body = this.ReadExtensionObjectBody(expandedNodeId);
    this.EndField("Body");
    this.PopNamespace();
    this.EndField(fieldName);
    if (body is IEncodeable encodeable)
      expandedNodeId = encodeable.TypeId;
    return new ExtensionObject(expandedNodeId, body);
  }

  public IEncodeable ReadEncodeable(
    string fieldName,
    Type systemType,
    ExpandedNodeId encodeableTypeId = null)
  {
    if (systemType == (Type) null)
      throw new ArgumentNullException(nameof (systemType));
    if (!(Activator.CreateInstance(systemType) is IEncodeable instance))
      throw new ServiceResultException(2147942400U /*0x80070000*/, Utils.Format("Type does not support IEncodeable interface: '{0}'", (object) systemType.FullName));
    if (encodeableTypeId != (object) null && instance is IComplexTypeInstance complexTypeInstance)
      complexTypeInstance.TypeId = encodeableTypeId;
    this.CheckAndIncrementNestingLevel();
    try
    {
      if (this.BeginField(fieldName, true))
      {
        this.PushNamespace(EncodeableFactory.GetXmlName((object) instance, this.Context).Namespace);
        instance.Decode((IDecoder) this);
        this.PopNamespace();
        int content1 = (int) this.m_reader.MoveToContent();
        while (this.m_reader.NodeType != XmlNodeType.EndElement || !(this.m_reader.LocalName == fieldName) || !(this.m_reader.NamespaceURI == this.m_namespaces.Peek()))
        {
          if (this.m_reader.NodeType != XmlNodeType.None)
          {
            this.m_reader.Skip();
            int content2 = (int) this.m_reader.MoveToContent();
          }
          else
            throw new ServiceResultException(2147942400U /*0x80070000*/, Utils.Format("Unexpected end of stream decoding field '{0}' for type '{1}'.", (object) fieldName, (object) systemType.FullName));
        }
        this.EndField(fieldName);
      }
    }
    finally
    {
      --this.m_nestingLevel;
    }
    return instance;
  }

  public Enum ReadEnumerated(string fieldName, Type enumType)
  {
    Enum @enum = (Enum) Enum.GetValues(enumType).GetValue(0);
    if (this.BeginField(fieldName, true))
    {
      string str = this.ReadString();
      if (!string.IsNullOrEmpty(str))
      {
        int num = str.LastIndexOf('_');
        if (num != -1)
        {
          int int32 = Convert.ToInt32(str.Substring(num + 1), (IFormatProvider) CultureInfo.InvariantCulture);
          @enum = (Enum) Enum.ToObject(enumType, int32);
        }
        else
          @enum = (Enum) Enum.Parse(enumType, str, false);
      }
      this.EndField(fieldName);
    }
    return @enum;
  }

  public BooleanCollection ReadBooleanArray(string fieldName)
  {
    bool isNil = false;
    BooleanCollection booleanCollection = new BooleanCollection();
    if (this.BeginField(fieldName, true, out isNil))
    {
      this.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
      while (this.MoveToElement("Boolean"))
        booleanCollection.Add(this.ReadBoolean("Boolean"));
      if (this.m_context.MaxArrayLength > 0 && this.m_context.MaxArrayLength < booleanCollection.Count)
        throw new ServiceResultException(2148007936U /*0x80080000*/);
      this.PopNamespace();
      this.EndField(fieldName);
      return booleanCollection;
    }
    return isNil ? (BooleanCollection) null : booleanCollection;
  }

  public SByteCollection ReadSByteArray(string fieldName)
  {
    bool isNil = false;
    SByteCollection sbyteCollection = new SByteCollection();
    if (this.BeginField(fieldName, true, out isNil))
    {
      this.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
      while (this.MoveToElement("SByte"))
        sbyteCollection.Add(this.ReadSByte("SByte"));
      if (this.m_context.MaxArrayLength > 0 && this.m_context.MaxArrayLength < sbyteCollection.Count)
        throw new ServiceResultException(2148007936U /*0x80080000*/);
      this.PopNamespace();
      this.EndField(fieldName);
      return sbyteCollection;
    }
    return isNil ? (SByteCollection) null : sbyteCollection;
  }

  public ByteCollection ReadByteArray(string fieldName)
  {
    bool isNil = false;
    ByteCollection byteCollection = new ByteCollection();
    if (this.BeginField(fieldName, true, out isNil))
    {
      this.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
      while (this.MoveToElement("Byte"))
        byteCollection.Add(this.ReadByte("Byte"));
      if (this.m_context.MaxArrayLength > 0 && this.m_context.MaxArrayLength < byteCollection.Count)
        throw new ServiceResultException(2148007936U /*0x80080000*/);
      this.PopNamespace();
      this.EndField(fieldName);
      return byteCollection;
    }
    return isNil ? (ByteCollection) null : byteCollection;
  }

  public Int16Collection ReadInt16Array(string fieldName)
  {
    bool isNil = false;
    Int16Collection int16Collection = new Int16Collection();
    if (this.BeginField(fieldName, true, out isNil))
    {
      this.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
      while (this.MoveToElement("Int16"))
        int16Collection.Add(this.ReadInt16("Int16"));
      if (this.m_context.MaxArrayLength > 0 && this.m_context.MaxArrayLength < int16Collection.Count)
        throw new ServiceResultException(2148007936U /*0x80080000*/);
      this.PopNamespace();
      this.EndField(fieldName);
      return int16Collection;
    }
    return isNil ? (Int16Collection) null : int16Collection;
  }

  public UInt16Collection ReadUInt16Array(string fieldName)
  {
    bool isNil = false;
    UInt16Collection uint16Collection = new UInt16Collection();
    if (this.BeginField(fieldName, true, out isNil))
    {
      this.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
      while (this.MoveToElement("UInt16"))
        uint16Collection.Add(this.ReadUInt16("UInt16"));
      if (this.m_context.MaxArrayLength > 0 && this.m_context.MaxArrayLength < uint16Collection.Count)
        throw new ServiceResultException(2148007936U /*0x80080000*/);
      this.PopNamespace();
      this.EndField(fieldName);
      return uint16Collection;
    }
    return isNil ? (UInt16Collection) null : uint16Collection;
  }

  public Int32Collection ReadInt32Array(string fieldName)
  {
    bool isNil = false;
    Int32Collection int32Collection = new Int32Collection();
    if (this.BeginField(fieldName, true, out isNil))
    {
      this.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
      while (this.MoveToElement("Int32"))
        int32Collection.Add(this.ReadInt32("Int32"));
      if (this.m_context.MaxArrayLength > 0 && this.m_context.MaxArrayLength < int32Collection.Count)
        throw new ServiceResultException(2148007936U /*0x80080000*/);
      this.PopNamespace();
      this.EndField(fieldName);
      return int32Collection;
    }
    return isNil ? (Int32Collection) null : int32Collection;
  }

  public UInt32Collection ReadUInt32Array(string fieldName)
  {
    bool isNil = false;
    UInt32Collection uint32Collection = new UInt32Collection();
    if (this.BeginField(fieldName, true, out isNil))
    {
      this.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
      while (this.MoveToElement("UInt32"))
        uint32Collection.Add(this.ReadUInt32("UInt32"));
      if (this.m_context.MaxArrayLength > 0 && this.m_context.MaxArrayLength < uint32Collection.Count)
        throw new ServiceResultException(2148007936U /*0x80080000*/);
      this.PopNamespace();
      this.EndField(fieldName);
      return uint32Collection;
    }
    return isNil ? (UInt32Collection) null : uint32Collection;
  }

  public Int64Collection ReadInt64Array(string fieldName)
  {
    bool isNil = false;
    Int64Collection int64Collection = new Int64Collection();
    if (this.BeginField(fieldName, true, out isNil))
    {
      this.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
      while (this.MoveToElement("Int64"))
        int64Collection.Add(this.ReadInt64("Int64"));
      if (this.m_context.MaxArrayLength > 0 && this.m_context.MaxArrayLength < int64Collection.Count)
        throw new ServiceResultException(2148007936U /*0x80080000*/);
      this.PopNamespace();
      this.EndField(fieldName);
      return int64Collection;
    }
    return isNil ? (Int64Collection) null : int64Collection;
  }

  public UInt64Collection ReadUInt64Array(string fieldName)
  {
    bool isNil = false;
    UInt64Collection uint64Collection = new UInt64Collection();
    if (this.BeginField(fieldName, true, out isNil))
    {
      this.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
      while (this.MoveToElement("UInt64"))
        uint64Collection.Add(this.ReadUInt64("UInt64"));
      if (this.m_context.MaxArrayLength > 0 && this.m_context.MaxArrayLength < uint64Collection.Count)
        throw new ServiceResultException(2148007936U /*0x80080000*/);
      this.PopNamespace();
      this.EndField(fieldName);
      return uint64Collection;
    }
    return isNil ? (UInt64Collection) null : uint64Collection;
  }

  public FloatCollection ReadFloatArray(string fieldName)
  {
    bool isNil = false;
    FloatCollection floatCollection = new FloatCollection();
    if (this.BeginField(fieldName, true, out isNil))
    {
      this.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
      while (this.MoveToElement("Float"))
        floatCollection.Add(this.ReadFloat("Float"));
      if (this.m_context.MaxArrayLength > 0 && this.m_context.MaxArrayLength < floatCollection.Count)
        throw new ServiceResultException(2148007936U /*0x80080000*/);
      this.PopNamespace();
      this.EndField(fieldName);
      return floatCollection;
    }
    return isNil ? (FloatCollection) null : floatCollection;
  }

  public DoubleCollection ReadDoubleArray(string fieldName)
  {
    bool isNil = false;
    DoubleCollection doubleCollection = new DoubleCollection();
    if (this.BeginField(fieldName, true, out isNil))
    {
      this.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
      while (this.MoveToElement("Double"))
        doubleCollection.Add(this.ReadDouble("Double"));
      if (this.m_context.MaxArrayLength > 0 && this.m_context.MaxArrayLength < doubleCollection.Count)
        throw new ServiceResultException(2148007936U /*0x80080000*/);
      this.PopNamespace();
      this.EndField(fieldName);
      return doubleCollection;
    }
    return isNil ? (DoubleCollection) null : doubleCollection;
  }

  public StringCollection ReadStringArray(string fieldName)
  {
    bool isNil = false;
    StringCollection stringCollection = new StringCollection();
    if (this.BeginField(fieldName, true, out isNil))
    {
      this.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
      while (this.MoveToElement("String"))
        stringCollection.Add(this.ReadString("String"));
      if (this.m_context.MaxArrayLength > 0 && this.m_context.MaxArrayLength < stringCollection.Count)
        throw new ServiceResultException(2148007936U /*0x80080000*/);
      this.PopNamespace();
      this.EndField(fieldName);
      return stringCollection;
    }
    return isNil ? (StringCollection) null : stringCollection;
  }

  public DateTimeCollection ReadDateTimeArray(string fieldName)
  {
    bool isNil = false;
    DateTimeCollection dateTimeCollection = new DateTimeCollection();
    if (this.BeginField(fieldName, true, out isNil))
    {
      this.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
      while (this.MoveToElement("DateTime"))
        dateTimeCollection.Add(this.ReadDateTime("DateTime"));
      if (this.m_context.MaxArrayLength > 0 && this.m_context.MaxArrayLength < dateTimeCollection.Count)
        throw new ServiceResultException(2148007936U /*0x80080000*/);
      this.PopNamespace();
      this.EndField(fieldName);
      return dateTimeCollection;
    }
    return isNil ? (DateTimeCollection) null : dateTimeCollection;
  }

  public UuidCollection ReadGuidArray(string fieldName)
  {
    bool isNil = false;
    UuidCollection uuidCollection = new UuidCollection();
    if (this.BeginField(fieldName, true, out isNil))
    {
      this.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
      while (this.MoveToElement("Guid"))
        uuidCollection.Add(this.ReadGuid("Guid"));
      if (this.m_context.MaxArrayLength > 0 && this.m_context.MaxArrayLength < uuidCollection.Count)
        throw new ServiceResultException(2148007936U /*0x80080000*/);
      this.PopNamespace();
      this.EndField(fieldName);
      return uuidCollection;
    }
    return isNil ? (UuidCollection) null : uuidCollection;
  }

  public ByteStringCollection ReadByteStringArray(string fieldName)
  {
    bool isNil = false;
    ByteStringCollection stringCollection = new ByteStringCollection();
    if (this.BeginField(fieldName, true, out isNil))
    {
      this.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
      while (this.MoveToElement("ByteString"))
        stringCollection.Add(this.ReadByteString("ByteString"));
      if (this.m_context.MaxArrayLength > 0 && this.m_context.MaxArrayLength < stringCollection.Count)
        throw new ServiceResultException(2148007936U /*0x80080000*/);
      this.PopNamespace();
      this.EndField(fieldName);
      return stringCollection;
    }
    return isNil ? (ByteStringCollection) null : stringCollection;
  }

  public XmlElementCollection ReadXmlElementArray(string fieldName)
  {
    bool isNil = false;
    XmlElementCollection elementCollection = new XmlElementCollection();
    if (this.BeginField(fieldName, true, out isNil))
    {
      this.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
      while (this.MoveToElement("XmlElement"))
        elementCollection.Add(this.ReadXmlElement("XmlElement"));
      if (this.m_context.MaxArrayLength > 0 && this.m_context.MaxArrayLength < elementCollection.Count)
        throw new ServiceResultException(2148007936U /*0x80080000*/);
      this.PopNamespace();
      this.EndField(fieldName);
      return elementCollection;
    }
    return isNil ? (XmlElementCollection) null : elementCollection;
  }

  public NodeIdCollection ReadNodeIdArray(string fieldName)
  {
    bool isNil = false;
    NodeIdCollection nodeIdCollection = new NodeIdCollection();
    if (this.BeginField(fieldName, true, out isNil))
    {
      this.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
      while (this.MoveToElement("NodeId"))
        nodeIdCollection.Add(this.ReadNodeId("NodeId"));
      if (this.m_context.MaxArrayLength > 0 && this.m_context.MaxArrayLength < nodeIdCollection.Count)
        throw new ServiceResultException(2148007936U /*0x80080000*/);
      this.PopNamespace();
      this.EndField(fieldName);
      return nodeIdCollection;
    }
    return isNil ? (NodeIdCollection) null : nodeIdCollection;
  }

  public ExpandedNodeIdCollection ReadExpandedNodeIdArray(string fieldName)
  {
    bool isNil = false;
    ExpandedNodeIdCollection nodeIdCollection = new ExpandedNodeIdCollection();
    if (this.BeginField(fieldName, true, out isNil))
    {
      this.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
      while (this.MoveToElement("ExpandedNodeId"))
        nodeIdCollection.Add(this.ReadExpandedNodeId("ExpandedNodeId"));
      if (this.m_context.MaxArrayLength > 0 && this.m_context.MaxArrayLength < nodeIdCollection.Count)
        throw new ServiceResultException(2148007936U /*0x80080000*/);
      this.PopNamespace();
      this.EndField(fieldName);
      return nodeIdCollection;
    }
    return isNil ? (ExpandedNodeIdCollection) null : nodeIdCollection;
  }

  public StatusCodeCollection ReadStatusCodeArray(string fieldName)
  {
    bool isNil = false;
    StatusCodeCollection statusCodeCollection = new StatusCodeCollection();
    if (this.BeginField(fieldName, true, out isNil))
    {
      this.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
      while (this.MoveToElement("StatusCode"))
        statusCodeCollection.Add(this.ReadStatusCode("StatusCode"));
      if (this.m_context.MaxArrayLength > 0 && this.m_context.MaxArrayLength < statusCodeCollection.Count)
        throw new ServiceResultException(2148007936U /*0x80080000*/);
      this.PopNamespace();
      this.EndField(fieldName);
      return statusCodeCollection;
    }
    return isNil ? (StatusCodeCollection) null : statusCodeCollection;
  }

  public DiagnosticInfoCollection ReadDiagnosticInfoArray(string fieldName)
  {
    bool isNil = false;
    DiagnosticInfoCollection diagnosticInfoCollection = new DiagnosticInfoCollection();
    if (this.BeginField(fieldName, true, out isNil))
    {
      this.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
      while (this.MoveToElement("DiagnosticInfo"))
        diagnosticInfoCollection.Add(this.ReadDiagnosticInfo("DiagnosticInfo"));
      if (this.m_context.MaxArrayLength > 0 && this.m_context.MaxArrayLength < diagnosticInfoCollection.Count)
        throw new ServiceResultException(2148007936U /*0x80080000*/);
      this.PopNamespace();
      this.EndField(fieldName);
      return diagnosticInfoCollection;
    }
    return isNil ? (DiagnosticInfoCollection) null : diagnosticInfoCollection;
  }

  public QualifiedNameCollection ReadQualifiedNameArray(string fieldName)
  {
    bool isNil = false;
    QualifiedNameCollection qualifiedNameCollection = new QualifiedNameCollection();
    if (this.BeginField(fieldName, true, out isNil))
    {
      this.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
      while (this.MoveToElement("QualifiedName"))
        qualifiedNameCollection.Add(this.ReadQualifiedName("QualifiedName"));
      if (this.m_context.MaxArrayLength > 0 && this.m_context.MaxArrayLength < qualifiedNameCollection.Count)
        throw new ServiceResultException(2148007936U /*0x80080000*/);
      this.PopNamespace();
      this.EndField(fieldName);
      return qualifiedNameCollection;
    }
    return isNil ? (QualifiedNameCollection) null : qualifiedNameCollection;
  }

  public LocalizedTextCollection ReadLocalizedTextArray(string fieldName)
  {
    bool isNil = false;
    LocalizedTextCollection localizedTextCollection = new LocalizedTextCollection();
    if (this.BeginField(fieldName, true, out isNil))
    {
      this.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
      while (this.MoveToElement("LocalizedText"))
        localizedTextCollection.Add(this.ReadLocalizedText("LocalizedText"));
      if (this.m_context.MaxArrayLength > 0 && this.m_context.MaxArrayLength < localizedTextCollection.Count)
        throw new ServiceResultException(2148007936U /*0x80080000*/);
      this.PopNamespace();
      this.EndField(fieldName);
      return localizedTextCollection;
    }
    return isNil ? (LocalizedTextCollection) null : localizedTextCollection;
  }

  public VariantCollection ReadVariantArray(string fieldName)
  {
    bool isNil = false;
    VariantCollection variantCollection = new VariantCollection();
    if (this.BeginField(fieldName, true, out isNil))
    {
      this.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
      while (this.MoveToElement("Variant"))
        variantCollection.Add(this.ReadVariant("Variant"));
      if (this.m_context.MaxArrayLength > 0 && this.m_context.MaxArrayLength < variantCollection.Count)
        throw new ServiceResultException(2148007936U /*0x80080000*/);
      this.PopNamespace();
      this.EndField(fieldName);
      return variantCollection;
    }
    return isNil ? (VariantCollection) null : variantCollection;
  }

  public DataValueCollection ReadDataValueArray(string fieldName)
  {
    bool isNil = false;
    DataValueCollection dataValueCollection = new DataValueCollection();
    if (this.BeginField(fieldName, true, out isNil))
    {
      this.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
      while (this.MoveToElement("DataValue"))
        dataValueCollection.Add(this.ReadDataValue("DataValue"));
      if (this.m_context.MaxArrayLength > 0 && this.m_context.MaxArrayLength < dataValueCollection.Count)
        throw new ServiceResultException(2148007936U /*0x80080000*/);
      this.PopNamespace();
      this.EndField(fieldName);
      return dataValueCollection;
    }
    return isNil ? (DataValueCollection) null : dataValueCollection;
  }

  public ExtensionObjectCollection ReadExtensionObjectArray(string fieldName)
  {
    bool isNil = false;
    ExtensionObjectCollection objectCollection = new ExtensionObjectCollection();
    if (this.BeginField(fieldName, true, out isNil))
    {
      this.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
      while (this.MoveToElement("ExtensionObject"))
        objectCollection.Add(this.ReadExtensionObject("ExtensionObject"));
      if (this.m_context.MaxArrayLength > 0 && this.m_context.MaxArrayLength < objectCollection.Count)
        throw new ServiceResultException(2148007936U /*0x80080000*/);
      this.PopNamespace();
      this.EndField(fieldName);
      return objectCollection;
    }
    return isNil ? (ExtensionObjectCollection) null : objectCollection;
  }

  public Array ReadEncodeableArray(
    string fieldName,
    Type systemType,
    ExpandedNodeId encodeableTypeId = null)
  {
    if (systemType == (Type) null)
      throw new ArgumentNullException(nameof (systemType));
    bool isNil = false;
    IEncodeableCollection iencodeableCollection = new IEncodeableCollection();
    if (this.BeginField(fieldName, true, out isNil))
    {
      XmlQualifiedName xmlName = EncodeableFactory.GetXmlName(systemType);
      this.PushNamespace(xmlName.Namespace);
      while (this.MoveToElement(xmlName.Name))
        iencodeableCollection.Add(this.ReadEncodeable(xmlName.Name, systemType, encodeableTypeId));
      if (this.m_context.MaxArrayLength > 0 && this.m_context.MaxArrayLength < iencodeableCollection.Count)
        throw new ServiceResultException(2148007936U /*0x80080000*/);
      this.PopNamespace();
      this.EndField(fieldName);
      Array instance = Array.CreateInstance(systemType, iencodeableCollection.Count);
      for (int index = 0; index < iencodeableCollection.Count; ++index)
        instance.SetValue((object) iencodeableCollection[index], index);
      return instance;
    }
    return isNil ? (Array) null : Array.CreateInstance(systemType, 0);
  }

  public Array ReadEnumeratedArray(string fieldName, Type enumType)
  {
    if (enumType == (Type) null)
      throw new ArgumentNullException(nameof (enumType));
    bool isNil = false;
    List<Enum> enumList = new List<Enum>();
    if (this.BeginField(fieldName, true, out isNil))
    {
      XmlQualifiedName xmlName = EncodeableFactory.GetXmlName(enumType);
      this.PushNamespace(xmlName.Namespace);
      while (this.MoveToElement(xmlName.Name))
        enumList.Add(this.ReadEnumerated(xmlName.Name, enumType));
      if (this.m_context.MaxArrayLength > 0 && this.m_context.MaxArrayLength < enumList.Count)
        throw new ServiceResultException(2148007936U /*0x80080000*/);
      this.PopNamespace();
      this.EndField(fieldName);
      Array instance = Array.CreateInstance(enumType, enumList.Count);
      for (int index = 0; index < enumList.Count; ++index)
        instance.SetValue((object) enumList[index], index);
      return instance;
    }
    return isNil ? (Array) null : Array.CreateInstance(enumType, 0);
  }

  public Array ReadArray(
    string fieldName,
    int valueRank,
    BuiltInType builtInType,
    Type systemType,
    ExpandedNodeId encodeableTypeId = null)
  {
    if (valueRank == 1)
      return this.ReadArrayElements(fieldName, builtInType, systemType, encodeableTypeId);
    if (valueRank > 1)
    {
      Array elements = (Array) null;
      Int32Collection int32Collection = (Int32Collection) null;
      if (this.BeginField(fieldName, true))
      {
        this.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
        int32Collection = this.ReadInt32Array("Dimensions");
        elements = this.ReadArrayElements("Elements", builtInType, systemType, encodeableTypeId);
        this.PopNamespace();
        this.EndField(fieldName);
      }
      if (elements == null)
        throw new ServiceResultException(2147942400U /*0x80070000*/, "The Matrix contains invalid elements");
      return (int32Collection == null || int32Collection.Count <= 0 ? new Matrix(elements, builtInType) : new Matrix(elements, builtInType, int32Collection.ToArray())).ToArray();
    }
    throw ServiceResultException.Create(2147942400U /*0x80070000*/, "Invalid ValueRank {0} for Array", (object) valueRank);
  }

  private DiagnosticInfo ReadDiagnosticInfo(int depth)
  {
    if (depth >= DiagnosticInfo.MaxInnerDepth)
      throw ServiceResultException.Create(2148007936U /*0x80080000*/, "Maximum nesting level of InnerDiagnosticInfo was exceeded");
    this.CheckAndIncrementNestingLevel();
    try
    {
      DiagnosticInfo diagnosticInfo = new DiagnosticInfo();
      bool flag1 = false;
      if (this.BeginField("SymbolicId", true))
      {
        diagnosticInfo.SymbolicId = this.ReadInt32((string) null);
        this.EndField("SymbolicId");
        flag1 = true;
      }
      if (this.BeginField("NamespaceUri", true))
      {
        diagnosticInfo.NamespaceUri = this.ReadInt32((string) null);
        this.EndField("NamespaceUri");
        flag1 = true;
      }
      if (this.BeginField("Locale", true))
      {
        diagnosticInfo.Locale = this.ReadInt32((string) null);
        this.EndField("Locale");
        flag1 = true;
      }
      if (this.BeginField("LocalizedText", true))
      {
        diagnosticInfo.LocalizedText = this.ReadInt32((string) null);
        this.EndField("LocalizedText");
        flag1 = true;
      }
      diagnosticInfo.AdditionalInfo = this.ReadString("AdditionalInfo");
      diagnosticInfo.InnerStatusCode = this.ReadStatusCode("InnerStatusCode");
      bool flag2 = flag1 || diagnosticInfo.AdditionalInfo != null || diagnosticInfo.InnerStatusCode != 0U;
      if (this.BeginField("InnerDiagnosticInfo", true))
      {
        diagnosticInfo.InnerDiagnosticInfo = this.ReadDiagnosticInfo(depth + 1);
        this.EndField("InnerDiagnosticInfo");
        flag2 = true;
      }
      return flag2 ? diagnosticInfo : (DiagnosticInfo) null;
    }
    finally
    {
      --this.m_nestingLevel;
    }
  }

  private Matrix ReadMatrix(string fieldName)
  {
    this.CheckAndIncrementNestingLevel();
    try
    {
      Array elements = (Array) null;
      Int32Collection int32Collection = (Int32Collection) null;
      TypeInfo typeInfo = (TypeInfo) null;
      if (this.BeginField(fieldName, true))
      {
        this.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
        if (this.BeginField("Elements", true))
        {
          elements = this.ReadVariantContents(out typeInfo) as Array;
          this.EndField("Elements");
        }
        int32Collection = this.ReadInt32Array("Dimensions");
        this.PopNamespace();
        this.EndField(fieldName);
      }
      if (elements == null)
        throw new ServiceResultException(2147942400U /*0x80070000*/, "The Matrix contains invalid elements");
      return int32Collection != null && int32Collection.Count > 0 ? new Matrix(elements, typeInfo.BuiltInType, int32Collection.ToArray()) : new Matrix(elements, typeInfo.BuiltInType);
    }
    finally
    {
      --this.m_nestingLevel;
    }
  }

  private Array ReadArrayElements(
    string fieldName,
    BuiltInType builtInType,
    Type systemType,
    ExpandedNodeId encodeableTypeId)
  {
    this.CheckAndIncrementNestingLevel();
    try
    {
      while (this.m_reader.NodeType != XmlNodeType.Element)
        this.m_reader.Read();
      switch (builtInType)
      {
        case BuiltInType.Boolean:
          BooleanCollection booleanCollection = this.ReadBooleanArray(fieldName);
          return booleanCollection != null ? (Array) booleanCollection.ToArray() : (Array) null;
        case BuiltInType.SByte:
          SByteCollection sbyteCollection = this.ReadSByteArray(fieldName);
          return sbyteCollection != null ? (Array) sbyteCollection.ToArray() : (Array) null;
        case BuiltInType.Byte:
          ByteCollection byteCollection = this.ReadByteArray(fieldName);
          return byteCollection != null ? (Array) byteCollection.ToArray() : (Array) null;
        case BuiltInType.Int16:
          Int16Collection int16Collection = this.ReadInt16Array(fieldName);
          return int16Collection != null ? (Array) int16Collection.ToArray() : (Array) null;
        case BuiltInType.UInt16:
          UInt16Collection uint16Collection = this.ReadUInt16Array(fieldName);
          return uint16Collection != null ? (Array) uint16Collection.ToArray() : (Array) null;
        case BuiltInType.Int32:
        case BuiltInType.Enumeration:
          Int32Collection int32Collection = this.ReadInt32Array(fieldName);
          if (int32Collection == null)
            return (Array) null;
          if (builtInType == BuiltInType.Enumeration)
          {
            this.DetermineIEncodeableSystemType(ref systemType, encodeableTypeId);
            if ((object) systemType != null && systemType.IsEnum)
            {
              Array instance = Array.CreateInstance(systemType, int32Collection.Count);
              int num1 = 0;
              foreach (int num2 in (List<int>) int32Collection)
                instance.SetValue(Enum.ToObject(systemType, num2), num1++);
              return instance;
            }
          }
          return (Array) int32Collection.ToArray();
        case BuiltInType.UInt32:
          UInt32Collection uint32Collection = this.ReadUInt32Array(fieldName);
          return uint32Collection != null ? (Array) uint32Collection.ToArray() : (Array) null;
        case BuiltInType.Int64:
          Int64Collection int64Collection = this.ReadInt64Array(fieldName);
          return int64Collection != null ? (Array) int64Collection.ToArray() : (Array) null;
        case BuiltInType.UInt64:
          UInt64Collection uint64Collection = this.ReadUInt64Array(fieldName);
          return uint64Collection != null ? (Array) uint64Collection.ToArray() : (Array) null;
        case BuiltInType.Float:
          FloatCollection floatCollection = this.ReadFloatArray(fieldName);
          return floatCollection != null ? (Array) floatCollection.ToArray() : (Array) null;
        case BuiltInType.Double:
          DoubleCollection doubleCollection = this.ReadDoubleArray(fieldName);
          return doubleCollection != null ? (Array) doubleCollection.ToArray() : (Array) null;
        case BuiltInType.String:
          StringCollection stringCollection1 = this.ReadStringArray(fieldName);
          return stringCollection1 != null ? (Array) stringCollection1.ToArray() : (Array) null;
        case BuiltInType.DateTime:
          DateTimeCollection dateTimeCollection = this.ReadDateTimeArray(fieldName);
          return dateTimeCollection != null ? (Array) dateTimeCollection.ToArray() : (Array) null;
        case BuiltInType.Guid:
          UuidCollection uuidCollection = this.ReadGuidArray(fieldName);
          return uuidCollection != null ? (Array) uuidCollection.ToArray() : (Array) null;
        case BuiltInType.ByteString:
          ByteStringCollection stringCollection2 = this.ReadByteStringArray(fieldName);
          return stringCollection2 != null ? (Array) stringCollection2.ToArray() : (Array) null;
        case BuiltInType.XmlElement:
          XmlElementCollection elementCollection = this.ReadXmlElementArray(fieldName);
          return elementCollection != null ? (Array) elementCollection.ToArray() : (Array) null;
        case BuiltInType.NodeId:
          NodeIdCollection nodeIdCollection1 = this.ReadNodeIdArray(fieldName);
          return nodeIdCollection1 != null ? (Array) nodeIdCollection1.ToArray() : (Array) null;
        case BuiltInType.ExpandedNodeId:
          ExpandedNodeIdCollection nodeIdCollection2 = this.ReadExpandedNodeIdArray(fieldName);
          return nodeIdCollection2 != null ? (Array) nodeIdCollection2.ToArray() : (Array) null;
        case BuiltInType.StatusCode:
          StatusCodeCollection statusCodeCollection = this.ReadStatusCodeArray(fieldName);
          return statusCodeCollection != null ? (Array) statusCodeCollection.ToArray() : (Array) null;
        case BuiltInType.QualifiedName:
          QualifiedNameCollection qualifiedNameCollection = this.ReadQualifiedNameArray(fieldName);
          return qualifiedNameCollection != null ? (Array) qualifiedNameCollection.ToArray() : (Array) null;
        case BuiltInType.LocalizedText:
          LocalizedTextCollection localizedTextCollection = this.ReadLocalizedTextArray(fieldName);
          return localizedTextCollection != null ? (Array) localizedTextCollection.ToArray() : (Array) null;
        case BuiltInType.ExtensionObject:
          ExtensionObjectCollection objectCollection = this.ReadExtensionObjectArray(fieldName);
          return objectCollection != null ? (Array) objectCollection.ToArray() : (Array) null;
        case BuiltInType.DataValue:
          DataValueCollection dataValueCollection = this.ReadDataValueArray(fieldName);
          return dataValueCollection != null ? (Array) dataValueCollection.ToArray() : (Array) null;
        case BuiltInType.Variant:
          if (this.DetermineIEncodeableSystemType(ref systemType, encodeableTypeId))
            return this.ReadEncodeableArray(fieldName, systemType, encodeableTypeId);
          VariantCollection variantCollection = this.ReadVariantArray(fieldName);
          return variantCollection != null ? (Array) variantCollection.ToArray() : (Array) null;
        case BuiltInType.DiagnosticInfo:
          DiagnosticInfoCollection diagnosticInfoCollection = this.ReadDiagnosticInfoArray(fieldName);
          return diagnosticInfoCollection != null ? (Array) diagnosticInfoCollection.ToArray() : (Array) null;
        default:
          if (this.DetermineIEncodeableSystemType(ref systemType, encodeableTypeId))
            return this.ReadEncodeableArray(fieldName, systemType, encodeableTypeId);
          throw ServiceResultException.Create(2147942400U /*0x80070000*/, "Cannot decode unknown type in Array object with BuiltInType: {0}.", (object) builtInType);
      }
    }
    finally
    {
      --this.m_nestingLevel;
    }
  }

  private string ReadString()
  {
    string str = this.m_reader.ReadContentAsString();
    if (str != null && this.m_context.MaxStringLength > 0 && this.m_context.MaxStringLength < str.Length)
      throw new ServiceResultException(2148007936U /*0x80080000*/);
    return str;
  }

  private bool BeginField(string fieldName, bool isOptional)
  {
    bool isNil = false;
    return this.BeginField(fieldName, isOptional, out isNil);
  }

  private bool BeginField(string fieldName, bool isOptional, out bool isNil)
  {
    isNil = false;
    int content1 = (int) this.m_reader.MoveToContent();
    if (string.IsNullOrEmpty(fieldName))
      return true;
    if (!this.m_reader.IsStartElement(fieldName, this.m_namespaces.Peek()))
    {
      if (!isOptional)
        throw new ServiceResultException(2147942400U /*0x80070000*/, Utils.Format("Encountered element: '{1}:{0}' when expecting element: '{2}:{3}'.", (object) this.m_reader.LocalName, (object) this.m_reader.NamespaceURI, (object) fieldName, (object) this.m_namespaces.Peek()));
      isNil = true;
      return false;
    }
    if (this.m_reader.HasAttributes)
    {
      string attribute = this.m_reader.GetAttribute("nil", "http://www.w3.org/2001/XMLSchema-instance");
      if (!string.IsNullOrEmpty(attribute) && XmlConvert.ToBoolean(attribute))
        isNil = true;
    }
    bool isEmptyElement = this.m_reader.IsEmptyElement;
    this.m_reader.ReadStartElement();
    if (!isEmptyElement)
    {
      int content2 = (int) this.m_reader.MoveToContent();
      if (this.m_reader.NodeType == XmlNodeType.EndElement && this.m_reader.LocalName == fieldName && this.m_reader.NamespaceURI == this.m_namespaces.Peek())
      {
        this.m_reader.ReadEndElement();
        return false;
      }
    }
    return !isNil && !isEmptyElement;
  }

  private void EndField(string fieldName)
  {
    if (string.IsNullOrEmpty(fieldName))
      return;
    int content = (int) this.m_reader.MoveToContent();
    if (this.m_reader.NodeType == XmlNodeType.EndElement && !(this.m_reader.LocalName != fieldName) && !(this.m_reader.NamespaceURI != this.m_namespaces.Peek()))
      this.m_reader.ReadEndElement();
    else
      throw new ServiceResultException(2147942400U /*0x80070000*/, Utils.Format("Encountered end element: '{1}:{0}' when expecting element: '{3}:{2}'.", (object) this.m_reader.LocalName, (object) this.m_reader.NamespaceURI, (object) fieldName, (object) this.m_namespaces.Peek()));
  }

  private bool MoveToElement(string elementName)
  {
    while (!this.m_reader.IsStartElement())
    {
      if (this.m_reader.NodeType == XmlNodeType.None || this.m_reader.NodeType == XmlNodeType.EndElement)
        return false;
      this.m_reader.Read();
    }
    if (string.IsNullOrEmpty(elementName))
      return true;
    return this.m_reader.LocalName == elementName && this.m_reader.NamespaceURI == this.m_namespaces.Peek();
  }

  private bool DetermineIEncodeableSystemType(ref Type systemType, ExpandedNodeId encodeableTypeId)
  {
    if (encodeableTypeId != (object) null && systemType == (Type) null)
      systemType = this.Context.Factory.GetSystemType(encodeableTypeId);
    return typeof (IEncodeable).IsAssignableFrom(systemType);
  }

  private void CheckAndIncrementNestingLevel()
  {
    if (this.m_nestingLevel > this.m_context.MaxEncodingNestingLevels)
      throw ServiceResultException.Create(2148007936U /*0x80080000*/, "Maximum nesting level of {0} was exceeded", (object) this.m_context.MaxEncodingNestingLevels);
    ++this.m_nestingLevel;
  }
}
