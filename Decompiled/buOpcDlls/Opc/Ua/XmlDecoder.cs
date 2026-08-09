using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;

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

	public EncodingType EncodingType => EncodingType.Xml;

	public IServiceMessageContext Context => m_context;

	public XmlDecoder(IServiceMessageContext context)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		Initialize();
		m_context = context;
		m_nestingLevel = 0u;
	}

	public XmlDecoder(XmlElement element, IServiceMessageContext context)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		Initialize();
		m_reader = XmlReader.Create(new StringReader(element.OuterXml), Utils.DefaultXmlReaderSettings());
		m_context = context;
		m_nestingLevel = 0u;
	}

	public XmlDecoder(Type systemType, XmlReader reader, IServiceMessageContext context)
	{
		Initialize();
		m_reader = reader;
		m_context = context;
		m_nestingLevel = 0u;
		string text = null;
		string text2 = null;
		if (systemType != null)
		{
			XmlQualifiedName xmlName = EncodeableFactory.GetXmlName(systemType);
			text = xmlName.Namespace;
			text2 = xmlName.Name;
		}
		if (text == null)
		{
			m_reader.MoveToContent();
			text = m_reader.NamespaceURI;
			text2 = m_reader.Name;
		}
		int num = text2.IndexOf(':');
		if (num != -1)
		{
			text2 = text2.Substring(num + 1);
		}
		PushNamespace(text);
		BeginField(text2, isOptional: false);
	}

	private void Initialize()
	{
		m_reader = null;
		m_namespaces = new Stack<string>();
	}

	public void SetMappingTables(NamespaceTable namespaceUris, StringTable serverUris)
	{
		m_namespaceMappings = null;
		if (namespaceUris != null && m_context.NamespaceUris != null)
		{
			m_namespaceMappings = m_context.NamespaceUris.CreateMapping(namespaceUris, updateTable: false);
		}
		m_serverMappings = null;
		if (serverUris != null && m_context.ServerUris != null)
		{
			m_serverMappings = m_context.ServerUris.CreateMapping(serverUris, updateTable: false);
		}
	}

	public bool LoadStringTable(string tableName, string elementName, StringTable stringTable)
	{
		PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		try
		{
			if (!Peek(tableName))
			{
				return false;
			}
			ReadStartElement();
			while (Peek(elementName))
			{
				string value = ReadString(elementName);
				stringTable.Append(value);
			}
			Skip(new XmlQualifiedName(tableName, "http://opcfoundation.org/UA/2008/02/Types.xsd"));
			return true;
		}
		finally
		{
			PopNamespace();
		}
	}

	public void Close()
	{
		m_reader.Dispose();
	}

	public void Close(bool checkEof)
	{
		if (checkEof && m_reader.NodeType != XmlNodeType.None)
		{
			m_reader.ReadEndElement();
		}
		m_reader.Dispose();
	}

	public XmlQualifiedName Peek(XmlNodeType nodeType)
	{
		m_reader.MoveToContent();
		if (nodeType != XmlNodeType.None && nodeType != m_reader.NodeType)
		{
			return null;
		}
		return new XmlQualifiedName(m_reader.LocalName, m_reader.NamespaceURI);
	}

	public bool Peek(string fieldName)
	{
		m_reader.MoveToContent();
		if (XmlNodeType.Element != m_reader.NodeType)
		{
			return false;
		}
		if (fieldName != m_reader.LocalName)
		{
			return false;
		}
		if (m_namespaces.Peek() != m_reader.NamespaceURI)
		{
			return false;
		}
		return true;
	}

	public void ReadStartElement()
	{
		bool isEmptyElement = m_reader.IsEmptyElement;
		m_reader.ReadStartElement();
		if (!isEmptyElement)
		{
			m_reader.MoveToContent();
		}
	}

	public void Skip(XmlQualifiedName qname)
	{
		m_reader.MoveToContent();
		int num = 1;
		while (num > 0)
		{
			if (m_reader.NodeType == XmlNodeType.EndElement)
			{
				if (m_reader.LocalName == qname.Name && m_reader.NamespaceURI == qname.Namespace)
				{
					num--;
				}
			}
			else if (m_reader.NodeType == XmlNodeType.Element && m_reader.LocalName == qname.Name && m_reader.NamespaceURI == qname.Namespace)
			{
				num++;
			}
			m_reader.Skip();
			m_reader.MoveToContent();
		}
	}

	public object ReadVariantContents(out TypeInfo typeInfo)
	{
		typeInfo = TypeInfo.Unknown;
		while (m_reader.NodeType != XmlNodeType.Element)
		{
			m_reader.Read();
		}
		try
		{
			m_namespaces.Push("http://opcfoundation.org/UA/2008/02/Types.xsd");
			string localName = m_reader.LocalName;
			if (localName.StartsWith("ListOf", StringComparison.Ordinal))
			{
				switch (localName.Substring("ListOf".Length))
				{
				case "Boolean":
					typeInfo = TypeInfo.Arrays.Boolean;
					return ReadBooleanArray(localName)?.ToArray();
				case "SByte":
					typeInfo = TypeInfo.Arrays.SByte;
					return ReadSByteArray(localName)?.ToArray();
				case "Byte":
					typeInfo = TypeInfo.Arrays.Byte;
					return ReadByteArray(localName)?.ToArray();
				case "Int16":
					typeInfo = TypeInfo.Arrays.Int16;
					return ReadInt16Array(localName)?.ToArray();
				case "UInt16":
					typeInfo = TypeInfo.Arrays.UInt16;
					return ReadUInt16Array(localName)?.ToArray();
				case "Int32":
					typeInfo = TypeInfo.Arrays.Int32;
					return ReadInt32Array(localName)?.ToArray();
				case "UInt32":
					typeInfo = TypeInfo.Arrays.UInt32;
					return ReadUInt32Array(localName)?.ToArray();
				case "Int64":
					typeInfo = TypeInfo.Arrays.Int64;
					return ReadInt64Array(localName)?.ToArray();
				case "UInt64":
					typeInfo = TypeInfo.Arrays.UInt64;
					return ReadUInt64Array(localName)?.ToArray();
				case "Float":
					typeInfo = TypeInfo.Arrays.Float;
					return ReadFloatArray(localName)?.ToArray();
				case "Double":
					typeInfo = TypeInfo.Arrays.Double;
					return ReadDoubleArray(localName)?.ToArray();
				case "String":
					typeInfo = TypeInfo.Arrays.String;
					return ReadStringArray(localName)?.ToArray();
				case "DateTime":
					typeInfo = TypeInfo.Arrays.DateTime;
					return ReadDateTimeArray(localName)?.ToArray();
				case "Guid":
					typeInfo = TypeInfo.Arrays.Guid;
					return ReadGuidArray(localName)?.ToArray();
				case "ByteString":
					typeInfo = TypeInfo.Arrays.ByteString;
					return ReadByteStringArray(localName)?.ToArray();
				case "XmlElement":
					typeInfo = TypeInfo.Arrays.XmlElement;
					return ReadXmlElementArray(localName)?.ToArray();
				case "NodeId":
					typeInfo = TypeInfo.Arrays.NodeId;
					return ReadNodeIdArray(localName)?.ToArray();
				case "ExpandedNodeId":
					typeInfo = TypeInfo.Arrays.ExpandedNodeId;
					return ReadExpandedNodeIdArray(localName)?.ToArray();
				case "StatusCode":
					typeInfo = TypeInfo.Arrays.StatusCode;
					return ReadStatusCodeArray(localName)?.ToArray();
				case "DiagnosticInfo":
					typeInfo = TypeInfo.Arrays.DiagnosticInfo;
					return ReadDiagnosticInfoArray(localName)?.ToArray();
				case "QualifiedName":
					typeInfo = TypeInfo.Arrays.QualifiedName;
					return ReadQualifiedNameArray(localName)?.ToArray();
				case "LocalizedText":
					typeInfo = TypeInfo.Arrays.LocalizedText;
					return ReadLocalizedTextArray(localName)?.ToArray();
				case "ExtensionObject":
					typeInfo = TypeInfo.Arrays.ExtensionObject;
					return ReadExtensionObjectArray(localName)?.ToArray();
				case "DataValue":
					typeInfo = TypeInfo.Arrays.DataValue;
					return ReadDataValueArray(localName)?.ToArray();
				case "Variant":
					typeInfo = TypeInfo.Arrays.Variant;
					return ReadVariantArray(localName)?.ToArray();
				}
			}
			else
			{
				switch (localName)
				{
				case "Null":
					if (BeginField(localName, isOptional: true))
					{
						EndField(localName);
					}
					return null;
				case "Boolean":
					typeInfo = TypeInfo.Scalars.Boolean;
					return ReadBoolean(localName);
				case "SByte":
					typeInfo = TypeInfo.Scalars.SByte;
					return ReadSByte(localName);
				case "Byte":
					typeInfo = TypeInfo.Scalars.Byte;
					return ReadByte(localName);
				case "Int16":
					typeInfo = TypeInfo.Scalars.Int16;
					return ReadInt16(localName);
				case "UInt16":
					typeInfo = TypeInfo.Scalars.UInt16;
					return ReadUInt16(localName);
				case "Int32":
					typeInfo = TypeInfo.Scalars.Int32;
					return ReadInt32(localName);
				case "UInt32":
					typeInfo = TypeInfo.Scalars.UInt32;
					return ReadUInt32(localName);
				case "Int64":
					typeInfo = TypeInfo.Scalars.Int64;
					return ReadInt64(localName);
				case "UInt64":
					typeInfo = TypeInfo.Scalars.UInt64;
					return ReadUInt64(localName);
				case "Float":
					typeInfo = TypeInfo.Scalars.Float;
					return ReadFloat(localName);
				case "Double":
					typeInfo = TypeInfo.Scalars.Double;
					return ReadDouble(localName);
				case "String":
					typeInfo = TypeInfo.Scalars.String;
					return ReadString(localName);
				case "DateTime":
					typeInfo = TypeInfo.Scalars.DateTime;
					return ReadDateTime(localName);
				case "Guid":
					typeInfo = TypeInfo.Scalars.Guid;
					return ReadGuid(localName);
				case "ByteString":
					typeInfo = TypeInfo.Scalars.ByteString;
					return ReadByteString(localName);
				case "XmlElement":
					typeInfo = TypeInfo.Scalars.XmlElement;
					return ReadXmlElement(localName);
				case "NodeId":
					typeInfo = TypeInfo.Scalars.NodeId;
					return ReadNodeId(localName);
				case "ExpandedNodeId":
					typeInfo = TypeInfo.Scalars.ExpandedNodeId;
					return ReadExpandedNodeId(localName);
				case "StatusCode":
					typeInfo = TypeInfo.Scalars.StatusCode;
					return ReadStatusCode(localName);
				case "DiagnosticInfo":
					typeInfo = TypeInfo.Scalars.DiagnosticInfo;
					return ReadDiagnosticInfo(localName);
				case "QualifiedName":
					typeInfo = TypeInfo.Scalars.QualifiedName;
					return ReadQualifiedName(localName);
				case "LocalizedText":
					typeInfo = TypeInfo.Scalars.LocalizedText;
					return ReadLocalizedText(localName);
				case "ExtensionObject":
					typeInfo = TypeInfo.Scalars.ExtensionObject;
					return ReadExtensionObject(localName);
				case "DataValue":
					typeInfo = TypeInfo.Scalars.DataValue;
					return ReadDataValue(localName);
				case "Matrix":
				{
					Matrix matrix = ReadMatrix(localName);
					typeInfo = matrix.TypeInfo;
					return matrix;
				}
				}
			}
			throw new ServiceResultException(2147942400u, Utils.Format("Element '{1}:{0}' is not allowed in an Variant.", m_reader.LocalName, m_reader.NamespaceURI));
		}
		finally
		{
			m_namespaces.Pop();
		}
	}

	public object ReadExtensionObjectBody(ExpandedNodeId typeId)
	{
		m_reader.MoveToContent();
		if (m_reader.LocalName == "ByteString" && m_reader.NamespaceURI == "http://opcfoundation.org/UA/2008/02/Types.xsd")
		{
			PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
			byte[] result = ReadByteString("ByteString");
			PopNamespace();
			return result;
		}
		Type systemType = m_context.Factory.GetSystemType(typeId);
		if (systemType != null)
		{
			PushNamespace(m_reader.NamespaceURI);
			IEncodeable result2 = ReadEncodeable(m_reader.LocalName, systemType, typeId);
			PopNamespace();
			return result2;
		}
		XmlDocument xmlDocument = new XmlDocument();
		using (StringReader input = new StringReader(m_reader.ReadOuterXml()))
		{
			using XmlReader reader = XmlReader.Create(input, Utils.DefaultXmlReaderSettings());
			xmlDocument.Load(reader);
		}
		return xmlDocument.DocumentElement;
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (disposing && m_reader != null)
		{
			m_reader.Dispose();
		}
	}

	public void PushNamespace(string namespaceUri)
	{
		m_namespaces.Push(namespaceUri);
	}

	public void PopNamespace()
	{
		m_namespaces.Pop();
	}

	public bool ReadBoolean(string fieldName)
	{
		if (BeginField(fieldName, isOptional: true))
		{
			string text = ReadString();
			if (!string.IsNullOrEmpty(text))
			{
				bool result = XmlConvert.ToBoolean(text.ToLowerInvariant());
				EndField(fieldName);
				return result;
			}
		}
		return false;
	}

	public sbyte ReadSByte(string fieldName)
	{
		if (BeginField(fieldName, isOptional: true))
		{
			string text = ReadString();
			if (!string.IsNullOrEmpty(text))
			{
				sbyte result = XmlConvert.ToSByte(text);
				EndField(fieldName);
				return result;
			}
		}
		return 0;
	}

	public byte ReadByte(string fieldName)
	{
		if (BeginField(fieldName, isOptional: true))
		{
			string text = ReadString();
			if (!string.IsNullOrEmpty(text))
			{
				byte result = XmlConvert.ToByte(text);
				EndField(fieldName);
				return result;
			}
		}
		return 0;
	}

	public short ReadInt16(string fieldName)
	{
		if (BeginField(fieldName, isOptional: true))
		{
			string text = ReadString();
			if (!string.IsNullOrEmpty(text))
			{
				short result = XmlConvert.ToInt16(text);
				EndField(fieldName);
				return result;
			}
		}
		return 0;
	}

	public ushort ReadUInt16(string fieldName)
	{
		if (BeginField(fieldName, isOptional: true))
		{
			string text = ReadString();
			if (!string.IsNullOrEmpty(text))
			{
				ushort result = XmlConvert.ToUInt16(text);
				EndField(fieldName);
				return result;
			}
		}
		return 0;
	}

	public int ReadInt32(string fieldName)
	{
		if (BeginField(fieldName, isOptional: true))
		{
			string text = ReadString();
			if (!string.IsNullOrEmpty(text))
			{
				int result = XmlConvert.ToInt32(text);
				EndField(fieldName);
				return result;
			}
		}
		return 0;
	}

	public uint ReadUInt32(string fieldName)
	{
		if (BeginField(fieldName, isOptional: true))
		{
			string text = ReadString();
			if (!string.IsNullOrEmpty(text))
			{
				uint result = XmlConvert.ToUInt32(text);
				EndField(fieldName);
				return result;
			}
		}
		return 0u;
	}

	public long ReadInt64(string fieldName)
	{
		if (BeginField(fieldName, isOptional: true))
		{
			string text = ReadString();
			if (!string.IsNullOrEmpty(text))
			{
				long result = XmlConvert.ToInt64(text);
				EndField(fieldName);
				return result;
			}
		}
		return 0L;
	}

	public ulong ReadUInt64(string fieldName)
	{
		if (BeginField(fieldName, isOptional: true))
		{
			string text = ReadString();
			if (!string.IsNullOrEmpty(text))
			{
				ulong result = XmlConvert.ToUInt64(text);
				EndField(fieldName);
				return result;
			}
		}
		return 0uL;
	}

	public float ReadFloat(string fieldName)
	{
		if (BeginField(fieldName, isOptional: true))
		{
			string text = ReadString();
			if (!string.IsNullOrEmpty(text))
			{
				float num = 0f;
				if (text.Length == 3)
				{
					if (text == "NaN")
					{
						num = float.NaN;
					}
					if (text == "INF")
					{
						num = float.PositiveInfinity;
					}
				}
				if (text.Length == 4 && text == "-INF")
				{
					num = float.NegativeInfinity;
				}
				if (num == 0f)
				{
					num = XmlConvert.ToSingle(text);
				}
				EndField(fieldName);
				return num;
			}
		}
		return 0f;
	}

	public double ReadDouble(string fieldName)
	{
		if (BeginField(fieldName, isOptional: true))
		{
			string text = ReadString();
			if (!string.IsNullOrEmpty(text))
			{
				double num = 0.0;
				if (text.Length == 3)
				{
					if (text == "NaN")
					{
						num = double.NaN;
					}
					if (text == "INF")
					{
						num = double.PositiveInfinity;
					}
				}
				if (text.Length == 4 && text == "-INF")
				{
					num = double.NegativeInfinity;
				}
				if (num == 0.0)
				{
					num = XmlConvert.ToDouble(text);
				}
				EndField(fieldName);
				return num;
			}
		}
		return 0.0;
	}

	public string ReadString(string fieldName)
	{
		bool isNil = false;
		if (BeginField(fieldName, isOptional: true, out isNil))
		{
			string text = ReadString();
			if (text != null)
			{
				text = text.Trim();
			}
			EndField(fieldName);
			return text;
		}
		if (!isNil)
		{
			return string.Empty;
		}
		return null;
	}

	public DateTime ReadDateTime(string fieldName)
	{
		if (BeginField(fieldName, isOptional: true))
		{
			string text = ReadString();
			if (m_context.MaxStringLength > 0 && m_context.MaxStringLength < text.Length)
			{
				throw new ServiceResultException(2148007936u);
			}
			if (!string.IsNullOrEmpty(text))
			{
				DateTime result = XmlConvert.ToDateTime(text, XmlDateTimeSerializationMode.Utc);
				EndField(fieldName);
				return result;
			}
		}
		return DateTime.MinValue;
	}

	public Uuid ReadGuid(string fieldName)
	{
		Uuid result = default(Uuid);
		if (BeginField(fieldName, isOptional: true))
		{
			PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
			result.GuidString = ReadString("String");
			PopNamespace();
			EndField(fieldName);
		}
		return result;
	}

	public byte[] ReadByteString(string fieldName)
	{
		bool isNil = false;
		if (BeginField(fieldName, isOptional: true, out isNil))
		{
			byte[] array = null;
			string text = m_reader.ReadContentAsString();
			array = (string.IsNullOrEmpty(text) ? Array.Empty<byte>() : Convert.FromBase64String(text));
			if (m_context.MaxByteStringLength > 0 && m_context.MaxByteStringLength < array.Length)
			{
				throw new ServiceResultException(2148007936u);
			}
			EndField(fieldName);
			return array;
		}
		if (!isNil)
		{
			return Array.Empty<byte>();
		}
		return null;
	}

	private void ExtractXml(StringBuilder builder)
	{
		builder.Append('<');
		builder.Append(m_reader.Prefix);
		builder.Append(':');
		builder.Append(m_reader.LocalName);
		if (m_reader.HasAttributes)
		{
			for (int i = 0; i < m_reader.AttributeCount; i++)
			{
				m_reader.MoveToAttribute(i);
				builder.Append(' ');
				builder.Append(m_reader.Name);
				builder.Append("='");
				builder.Append(m_reader.Value);
				builder.Append('\'');
			}
			m_reader.MoveToElement();
		}
		m_reader.MoveToContent();
		while (m_reader.NodeType != XmlNodeType.EndElement)
		{
			if (m_reader.IsStartElement())
			{
				ExtractXml(builder);
			}
			else
			{
				builder.Append(m_reader.ReadContentAsString());
			}
		}
		m_reader.ReadEndElement();
	}

	public XmlElement ReadXmlElement(string fieldName)
	{
		if (BeginField(fieldName, isOptional: true) && MoveToElement(null))
		{
			XmlDocument xmlDocument = new XmlDocument();
			XmlElement xmlElement = xmlDocument.CreateElement(m_reader.Prefix, m_reader.LocalName, m_reader.NamespaceURI);
			xmlDocument.AppendChild(xmlElement);
			if (m_reader.MoveToFirstAttribute())
			{
				do
				{
					XmlAttribute xmlAttribute = xmlDocument.CreateAttribute(m_reader.Name);
					xmlAttribute.Value = m_reader.Value;
					xmlElement.Attributes.Append(xmlAttribute);
				}
				while (m_reader.MoveToNextAttribute());
				m_reader.MoveToContent();
			}
			xmlElement.InnerXml = m_reader.ReadInnerXml();
			EndField(fieldName);
			return xmlElement;
		}
		return null;
	}

	public NodeId ReadNodeId(string fieldName)
	{
		NodeId nodeId = new NodeId();
		if (BeginField(fieldName, isOptional: true))
		{
			PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
			nodeId.IdentifierText = ReadString("Identifier");
			PopNamespace();
			EndField(fieldName);
		}
		if (m_namespaceMappings != null && m_namespaceMappings.Length > nodeId.NamespaceIndex)
		{
			nodeId.SetNamespaceIndex(m_namespaceMappings[nodeId.NamespaceIndex]);
		}
		return nodeId;
	}

	public ExpandedNodeId ReadExpandedNodeId(string fieldName)
	{
		ExpandedNodeId expandedNodeId = new ExpandedNodeId();
		if (BeginField(fieldName, isOptional: true))
		{
			PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
			expandedNodeId.IdentifierText = ReadString("Identifier");
			PopNamespace();
			EndField(fieldName);
		}
		if (m_namespaceMappings != null && m_namespaceMappings.Length > expandedNodeId.NamespaceIndex)
		{
			expandedNodeId.SetNamespaceIndex(m_namespaceMappings[expandedNodeId.NamespaceIndex]);
		}
		if (m_serverMappings != null && m_serverMappings.Length > expandedNodeId.ServerIndex)
		{
			expandedNodeId.SetServerIndex(m_serverMappings[expandedNodeId.ServerIndex]);
		}
		return expandedNodeId;
	}

	public StatusCode ReadStatusCode(string fieldName)
	{
		StatusCode result = default(StatusCode);
		if (BeginField(fieldName, isOptional: true))
		{
			PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
			result.Code = ReadUInt32("Code");
			PopNamespace();
			EndField(fieldName);
		}
		return result;
	}

	public DiagnosticInfo ReadDiagnosticInfo(string fieldName)
	{
		DiagnosticInfo result = null;
		if (BeginField(fieldName, isOptional: true))
		{
			PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
			result = ReadDiagnosticInfo(0);
			PopNamespace();
			EndField(fieldName);
			return result;
		}
		return result;
	}

	public QualifiedName ReadQualifiedName(string fieldName)
	{
		if (BeginField(fieldName, isOptional: true))
		{
			PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
			ushort num = 0;
			if (BeginField("NamespaceIndex", isOptional: true))
			{
				num = ReadUInt16(null);
				EndField("NamespaceIndex");
			}
			bool isNil = false;
			string name = null;
			if (BeginField("Name", isOptional: true, out isNil))
			{
				name = ReadString(null);
				EndField("Name");
			}
			else if (!isNil)
			{
				name = string.Empty;
			}
			PopNamespace();
			EndField(fieldName);
			if (m_namespaceMappings != null && m_namespaceMappings.Length > num)
			{
				num = m_namespaceMappings[num];
			}
			return new QualifiedName(name, num);
		}
		return new QualifiedName();
	}

	public LocalizedText ReadLocalizedText(string fieldName)
	{
		if (BeginField(fieldName, isOptional: true))
		{
			PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
			bool isNil = false;
			string text = null;
			string locale = null;
			if (BeginField("Locale", isOptional: true, out isNil))
			{
				locale = ReadString(null);
				EndField("Locale");
			}
			else if (!isNil)
			{
				locale = string.Empty;
			}
			if (BeginField("Text", isOptional: true, out isNil))
			{
				text = ReadString(null);
				EndField("Text");
			}
			else if (!isNil)
			{
				text = string.Empty;
			}
			LocalizedText result = new LocalizedText(locale, text);
			PopNamespace();
			EndField(fieldName);
			return result;
		}
		return LocalizedText.Null;
	}

	public Variant ReadVariant(string fieldName)
	{
		CheckAndIncrementNestingLevel();
		try
		{
			Variant result = default(Variant);
			if (BeginField(fieldName, isOptional: true))
			{
				PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
				if (BeginField("Value", isOptional: true))
				{
					try
					{
						TypeInfo typeInfo = null;
						object value = ReadVariantContents(out typeInfo);
						result = new Variant(value, typeInfo);
					}
					catch (Exception exception)
					{
						Utils.LogError(exception, "XmlDecoder: Error reading variant.");
						result = new Variant(2147942400u);
					}
					EndField("Value");
				}
				PopNamespace();
				EndField(fieldName);
			}
			return result;
		}
		finally
		{
			m_nestingLevel--;
		}
	}

	public DataValue ReadDataValue(string fieldName)
	{
		DataValue dataValue = new DataValue();
		if (BeginField(fieldName, isOptional: true))
		{
			PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
			dataValue.WrappedValue = ReadVariant("Value");
			dataValue.StatusCode = ReadStatusCode("StatusCode");
			dataValue.SourceTimestamp = ReadDateTime("SourceTimestamp");
			dataValue.SourcePicoseconds = ReadUInt16("SourcePicoseconds");
			dataValue.ServerTimestamp = ReadDateTime("ServerTimestamp");
			dataValue.ServerPicoseconds = ReadUInt16("ServerPicoseconds");
			PopNamespace();
			EndField(fieldName);
		}
		return dataValue;
	}

	public ExtensionObject ReadExtensionObject(string fieldName)
	{
		if (!BeginField(fieldName, isOptional: true, out var isNil))
		{
			if (isNil)
			{
				return null;
			}
			return ExtensionObject.Null;
		}
		PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		NodeId nodeId = ReadNodeId("TypeId");
		ExpandedNodeId expandedNodeId = NodeId.ToExpandedNodeId(nodeId, m_context.NamespaceUris);
		if (!NodeId.IsNull(nodeId) && NodeId.IsNull(expandedNodeId))
		{
			Utils.LogWarning("Cannot de-serialized extension objects if the NamespaceUri is not in the NamespaceTable: Type = {0}", nodeId);
		}
		if (!BeginField("Body", isOptional: true))
		{
			EndField(fieldName);
			PopNamespace();
			return new ExtensionObject(expandedNodeId);
		}
		object obj = ReadExtensionObjectBody(expandedNodeId);
		EndField("Body");
		PopNamespace();
		EndField(fieldName);
		if (obj is IEncodeable encodeable)
		{
			expandedNodeId = encodeable.TypeId;
		}
		return new ExtensionObject(expandedNodeId, obj);
	}

	public IEncodeable ReadEncodeable(string fieldName, Type systemType, ExpandedNodeId encodeableTypeId = null)
	{
		if (systemType == null)
		{
			throw new ArgumentNullException("systemType");
		}
		if (!(Activator.CreateInstance(systemType) is IEncodeable encodeable))
		{
			throw new ServiceResultException(2147942400u, Utils.Format("Type does not support IEncodeable interface: '{0}'", systemType.FullName));
		}
		if (encodeableTypeId != null && encodeable is IComplexTypeInstance complexTypeInstance)
		{
			complexTypeInstance.TypeId = encodeableTypeId;
		}
		CheckAndIncrementNestingLevel();
		try
		{
			if (BeginField(fieldName, isOptional: true))
			{
				XmlQualifiedName xmlName = EncodeableFactory.GetXmlName(encodeable, Context);
				PushNamespace(xmlName.Namespace);
				encodeable.Decode(this);
				PopNamespace();
				m_reader.MoveToContent();
				while (m_reader.NodeType != XmlNodeType.EndElement || !(m_reader.LocalName == fieldName) || !(m_reader.NamespaceURI == m_namespaces.Peek()))
				{
					if (m_reader.NodeType == XmlNodeType.None)
					{
						throw new ServiceResultException(2147942400u, Utils.Format("Unexpected end of stream decoding field '{0}' for type '{1}'.", fieldName, systemType.FullName));
					}
					m_reader.Skip();
					m_reader.MoveToContent();
				}
				EndField(fieldName);
			}
		}
		finally
		{
			m_nestingLevel--;
		}
		return encodeable;
	}

	public Enum ReadEnumerated(string fieldName, Type enumType)
	{
		Enum result = (Enum)Enum.GetValues(enumType).GetValue(0);
		if (BeginField(fieldName, isOptional: true))
		{
			string text = ReadString();
			if (!string.IsNullOrEmpty(text))
			{
				int num = text.LastIndexOf('_');
				if (num != -1)
				{
					int value = Convert.ToInt32(text.Substring(num + 1), CultureInfo.InvariantCulture);
					result = (Enum)Enum.ToObject(enumType, value);
				}
				else
				{
					result = (Enum)Enum.Parse(enumType, text, ignoreCase: false);
				}
			}
			EndField(fieldName);
		}
		return result;
	}

	public BooleanCollection ReadBooleanArray(string fieldName)
	{
		bool isNil = false;
		BooleanCollection booleanCollection = new BooleanCollection();
		if (BeginField(fieldName, isOptional: true, out isNil))
		{
			PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
			while (MoveToElement("Boolean"))
			{
				booleanCollection.Add(ReadBoolean("Boolean"));
			}
			if (m_context.MaxArrayLength > 0 && m_context.MaxArrayLength < booleanCollection.Count)
			{
				throw new ServiceResultException(2148007936u);
			}
			PopNamespace();
			EndField(fieldName);
			return booleanCollection;
		}
		if (isNil)
		{
			return null;
		}
		return booleanCollection;
	}

	public SByteCollection ReadSByteArray(string fieldName)
	{
		bool isNil = false;
		SByteCollection sByteCollection = new SByteCollection();
		if (BeginField(fieldName, isOptional: true, out isNil))
		{
			PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
			while (MoveToElement("SByte"))
			{
				sByteCollection.Add(ReadSByte("SByte"));
			}
			if (m_context.MaxArrayLength > 0 && m_context.MaxArrayLength < sByteCollection.Count)
			{
				throw new ServiceResultException(2148007936u);
			}
			PopNamespace();
			EndField(fieldName);
			return sByteCollection;
		}
		if (isNil)
		{
			return null;
		}
		return sByteCollection;
	}

	public ByteCollection ReadByteArray(string fieldName)
	{
		bool isNil = false;
		ByteCollection byteCollection = new ByteCollection();
		if (BeginField(fieldName, isOptional: true, out isNil))
		{
			PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
			while (MoveToElement("Byte"))
			{
				byteCollection.Add(ReadByte("Byte"));
			}
			if (m_context.MaxArrayLength > 0 && m_context.MaxArrayLength < byteCollection.Count)
			{
				throw new ServiceResultException(2148007936u);
			}
			PopNamespace();
			EndField(fieldName);
			return byteCollection;
		}
		if (isNil)
		{
			return null;
		}
		return byteCollection;
	}

	public Int16Collection ReadInt16Array(string fieldName)
	{
		bool isNil = false;
		Int16Collection int16Collection = new Int16Collection();
		if (BeginField(fieldName, isOptional: true, out isNil))
		{
			PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
			while (MoveToElement("Int16"))
			{
				int16Collection.Add(ReadInt16("Int16"));
			}
			if (m_context.MaxArrayLength > 0 && m_context.MaxArrayLength < int16Collection.Count)
			{
				throw new ServiceResultException(2148007936u);
			}
			PopNamespace();
			EndField(fieldName);
			return int16Collection;
		}
		if (isNil)
		{
			return null;
		}
		return int16Collection;
	}

	public UInt16Collection ReadUInt16Array(string fieldName)
	{
		bool isNil = false;
		UInt16Collection uInt16Collection = new UInt16Collection();
		if (BeginField(fieldName, isOptional: true, out isNil))
		{
			PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
			while (MoveToElement("UInt16"))
			{
				uInt16Collection.Add(ReadUInt16("UInt16"));
			}
			if (m_context.MaxArrayLength > 0 && m_context.MaxArrayLength < uInt16Collection.Count)
			{
				throw new ServiceResultException(2148007936u);
			}
			PopNamespace();
			EndField(fieldName);
			return uInt16Collection;
		}
		if (isNil)
		{
			return null;
		}
		return uInt16Collection;
	}

	public Int32Collection ReadInt32Array(string fieldName)
	{
		bool isNil = false;
		Int32Collection int32Collection = new Int32Collection();
		if (BeginField(fieldName, isOptional: true, out isNil))
		{
			PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
			while (MoveToElement("Int32"))
			{
				int32Collection.Add(ReadInt32("Int32"));
			}
			if (m_context.MaxArrayLength > 0 && m_context.MaxArrayLength < int32Collection.Count)
			{
				throw new ServiceResultException(2148007936u);
			}
			PopNamespace();
			EndField(fieldName);
			return int32Collection;
		}
		if (isNil)
		{
			return null;
		}
		return int32Collection;
	}

	public UInt32Collection ReadUInt32Array(string fieldName)
	{
		bool isNil = false;
		UInt32Collection uInt32Collection = new UInt32Collection();
		if (BeginField(fieldName, isOptional: true, out isNil))
		{
			PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
			while (MoveToElement("UInt32"))
			{
				uInt32Collection.Add(ReadUInt32("UInt32"));
			}
			if (m_context.MaxArrayLength > 0 && m_context.MaxArrayLength < uInt32Collection.Count)
			{
				throw new ServiceResultException(2148007936u);
			}
			PopNamespace();
			EndField(fieldName);
			return uInt32Collection;
		}
		if (isNil)
		{
			return null;
		}
		return uInt32Collection;
	}

	public Int64Collection ReadInt64Array(string fieldName)
	{
		bool isNil = false;
		Int64Collection int64Collection = new Int64Collection();
		if (BeginField(fieldName, isOptional: true, out isNil))
		{
			PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
			while (MoveToElement("Int64"))
			{
				int64Collection.Add(ReadInt64("Int64"));
			}
			if (m_context.MaxArrayLength > 0 && m_context.MaxArrayLength < int64Collection.Count)
			{
				throw new ServiceResultException(2148007936u);
			}
			PopNamespace();
			EndField(fieldName);
			return int64Collection;
		}
		if (isNil)
		{
			return null;
		}
		return int64Collection;
	}

	public UInt64Collection ReadUInt64Array(string fieldName)
	{
		bool isNil = false;
		UInt64Collection uInt64Collection = new UInt64Collection();
		if (BeginField(fieldName, isOptional: true, out isNil))
		{
			PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
			while (MoveToElement("UInt64"))
			{
				uInt64Collection.Add(ReadUInt64("UInt64"));
			}
			if (m_context.MaxArrayLength > 0 && m_context.MaxArrayLength < uInt64Collection.Count)
			{
				throw new ServiceResultException(2148007936u);
			}
			PopNamespace();
			EndField(fieldName);
			return uInt64Collection;
		}
		if (isNil)
		{
			return null;
		}
		return uInt64Collection;
	}

	public FloatCollection ReadFloatArray(string fieldName)
	{
		bool isNil = false;
		FloatCollection floatCollection = new FloatCollection();
		if (BeginField(fieldName, isOptional: true, out isNil))
		{
			PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
			while (MoveToElement("Float"))
			{
				floatCollection.Add(ReadFloat("Float"));
			}
			if (m_context.MaxArrayLength > 0 && m_context.MaxArrayLength < floatCollection.Count)
			{
				throw new ServiceResultException(2148007936u);
			}
			PopNamespace();
			EndField(fieldName);
			return floatCollection;
		}
		if (isNil)
		{
			return null;
		}
		return floatCollection;
	}

	public DoubleCollection ReadDoubleArray(string fieldName)
	{
		bool isNil = false;
		DoubleCollection doubleCollection = new DoubleCollection();
		if (BeginField(fieldName, isOptional: true, out isNil))
		{
			PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
			while (MoveToElement("Double"))
			{
				doubleCollection.Add(ReadDouble("Double"));
			}
			if (m_context.MaxArrayLength > 0 && m_context.MaxArrayLength < doubleCollection.Count)
			{
				throw new ServiceResultException(2148007936u);
			}
			PopNamespace();
			EndField(fieldName);
			return doubleCollection;
		}
		if (isNil)
		{
			return null;
		}
		return doubleCollection;
	}

	public StringCollection ReadStringArray(string fieldName)
	{
		bool isNil = false;
		StringCollection stringCollection = new StringCollection();
		if (BeginField(fieldName, isOptional: true, out isNil))
		{
			PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
			while (MoveToElement("String"))
			{
				stringCollection.Add(ReadString("String"));
			}
			if (m_context.MaxArrayLength > 0 && m_context.MaxArrayLength < stringCollection.Count)
			{
				throw new ServiceResultException(2148007936u);
			}
			PopNamespace();
			EndField(fieldName);
			return stringCollection;
		}
		if (isNil)
		{
			return null;
		}
		return stringCollection;
	}

	public DateTimeCollection ReadDateTimeArray(string fieldName)
	{
		bool isNil = false;
		DateTimeCollection dateTimeCollection = new DateTimeCollection();
		if (BeginField(fieldName, isOptional: true, out isNil))
		{
			PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
			while (MoveToElement("DateTime"))
			{
				dateTimeCollection.Add(ReadDateTime("DateTime"));
			}
			if (m_context.MaxArrayLength > 0 && m_context.MaxArrayLength < dateTimeCollection.Count)
			{
				throw new ServiceResultException(2148007936u);
			}
			PopNamespace();
			EndField(fieldName);
			return dateTimeCollection;
		}
		if (isNil)
		{
			return null;
		}
		return dateTimeCollection;
	}

	public UuidCollection ReadGuidArray(string fieldName)
	{
		bool isNil = false;
		UuidCollection uuidCollection = new UuidCollection();
		if (BeginField(fieldName, isOptional: true, out isNil))
		{
			PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
			while (MoveToElement("Guid"))
			{
				uuidCollection.Add(ReadGuid("Guid"));
			}
			if (m_context.MaxArrayLength > 0 && m_context.MaxArrayLength < uuidCollection.Count)
			{
				throw new ServiceResultException(2148007936u);
			}
			PopNamespace();
			EndField(fieldName);
			return uuidCollection;
		}
		if (isNil)
		{
			return null;
		}
		return uuidCollection;
	}

	public ByteStringCollection ReadByteStringArray(string fieldName)
	{
		bool isNil = false;
		ByteStringCollection byteStringCollection = new ByteStringCollection();
		if (BeginField(fieldName, isOptional: true, out isNil))
		{
			PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
			while (MoveToElement("ByteString"))
			{
				byteStringCollection.Add(ReadByteString("ByteString"));
			}
			if (m_context.MaxArrayLength > 0 && m_context.MaxArrayLength < byteStringCollection.Count)
			{
				throw new ServiceResultException(2148007936u);
			}
			PopNamespace();
			EndField(fieldName);
			return byteStringCollection;
		}
		if (isNil)
		{
			return null;
		}
		return byteStringCollection;
	}

	public XmlElementCollection ReadXmlElementArray(string fieldName)
	{
		bool isNil = false;
		XmlElementCollection xmlElementCollection = new XmlElementCollection();
		if (BeginField(fieldName, isOptional: true, out isNil))
		{
			PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
			while (MoveToElement("XmlElement"))
			{
				xmlElementCollection.Add(ReadXmlElement("XmlElement"));
			}
			if (m_context.MaxArrayLength > 0 && m_context.MaxArrayLength < xmlElementCollection.Count)
			{
				throw new ServiceResultException(2148007936u);
			}
			PopNamespace();
			EndField(fieldName);
			return xmlElementCollection;
		}
		if (isNil)
		{
			return null;
		}
		return xmlElementCollection;
	}

	public NodeIdCollection ReadNodeIdArray(string fieldName)
	{
		bool isNil = false;
		NodeIdCollection nodeIdCollection = new NodeIdCollection();
		if (BeginField(fieldName, isOptional: true, out isNil))
		{
			PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
			while (MoveToElement("NodeId"))
			{
				nodeIdCollection.Add(ReadNodeId("NodeId"));
			}
			if (m_context.MaxArrayLength > 0 && m_context.MaxArrayLength < nodeIdCollection.Count)
			{
				throw new ServiceResultException(2148007936u);
			}
			PopNamespace();
			EndField(fieldName);
			return nodeIdCollection;
		}
		if (isNil)
		{
			return null;
		}
		return nodeIdCollection;
	}

	public ExpandedNodeIdCollection ReadExpandedNodeIdArray(string fieldName)
	{
		bool isNil = false;
		ExpandedNodeIdCollection expandedNodeIdCollection = new ExpandedNodeIdCollection();
		if (BeginField(fieldName, isOptional: true, out isNil))
		{
			PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
			while (MoveToElement("ExpandedNodeId"))
			{
				expandedNodeIdCollection.Add(ReadExpandedNodeId("ExpandedNodeId"));
			}
			if (m_context.MaxArrayLength > 0 && m_context.MaxArrayLength < expandedNodeIdCollection.Count)
			{
				throw new ServiceResultException(2148007936u);
			}
			PopNamespace();
			EndField(fieldName);
			return expandedNodeIdCollection;
		}
		if (isNil)
		{
			return null;
		}
		return expandedNodeIdCollection;
	}

	public StatusCodeCollection ReadStatusCodeArray(string fieldName)
	{
		bool isNil = false;
		StatusCodeCollection statusCodeCollection = new StatusCodeCollection();
		if (BeginField(fieldName, isOptional: true, out isNil))
		{
			PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
			while (MoveToElement("StatusCode"))
			{
				statusCodeCollection.Add(ReadStatusCode("StatusCode"));
			}
			if (m_context.MaxArrayLength > 0 && m_context.MaxArrayLength < statusCodeCollection.Count)
			{
				throw new ServiceResultException(2148007936u);
			}
			PopNamespace();
			EndField(fieldName);
			return statusCodeCollection;
		}
		if (isNil)
		{
			return null;
		}
		return statusCodeCollection;
	}

	public DiagnosticInfoCollection ReadDiagnosticInfoArray(string fieldName)
	{
		bool isNil = false;
		DiagnosticInfoCollection diagnosticInfoCollection = new DiagnosticInfoCollection();
		if (BeginField(fieldName, isOptional: true, out isNil))
		{
			PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
			while (MoveToElement("DiagnosticInfo"))
			{
				diagnosticInfoCollection.Add(ReadDiagnosticInfo("DiagnosticInfo"));
			}
			if (m_context.MaxArrayLength > 0 && m_context.MaxArrayLength < diagnosticInfoCollection.Count)
			{
				throw new ServiceResultException(2148007936u);
			}
			PopNamespace();
			EndField(fieldName);
			return diagnosticInfoCollection;
		}
		if (isNil)
		{
			return null;
		}
		return diagnosticInfoCollection;
	}

	public QualifiedNameCollection ReadQualifiedNameArray(string fieldName)
	{
		bool isNil = false;
		QualifiedNameCollection qualifiedNameCollection = new QualifiedNameCollection();
		if (BeginField(fieldName, isOptional: true, out isNil))
		{
			PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
			while (MoveToElement("QualifiedName"))
			{
				qualifiedNameCollection.Add(ReadQualifiedName("QualifiedName"));
			}
			if (m_context.MaxArrayLength > 0 && m_context.MaxArrayLength < qualifiedNameCollection.Count)
			{
				throw new ServiceResultException(2148007936u);
			}
			PopNamespace();
			EndField(fieldName);
			return qualifiedNameCollection;
		}
		if (isNil)
		{
			return null;
		}
		return qualifiedNameCollection;
	}

	public LocalizedTextCollection ReadLocalizedTextArray(string fieldName)
	{
		bool isNil = false;
		LocalizedTextCollection localizedTextCollection = new LocalizedTextCollection();
		if (BeginField(fieldName, isOptional: true, out isNil))
		{
			PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
			while (MoveToElement("LocalizedText"))
			{
				localizedTextCollection.Add(ReadLocalizedText("LocalizedText"));
			}
			if (m_context.MaxArrayLength > 0 && m_context.MaxArrayLength < localizedTextCollection.Count)
			{
				throw new ServiceResultException(2148007936u);
			}
			PopNamespace();
			EndField(fieldName);
			return localizedTextCollection;
		}
		if (isNil)
		{
			return null;
		}
		return localizedTextCollection;
	}

	public VariantCollection ReadVariantArray(string fieldName)
	{
		bool isNil = false;
		VariantCollection variantCollection = new VariantCollection();
		if (BeginField(fieldName, isOptional: true, out isNil))
		{
			PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
			while (MoveToElement("Variant"))
			{
				variantCollection.Add(ReadVariant("Variant"));
			}
			if (m_context.MaxArrayLength > 0 && m_context.MaxArrayLength < variantCollection.Count)
			{
				throw new ServiceResultException(2148007936u);
			}
			PopNamespace();
			EndField(fieldName);
			return variantCollection;
		}
		if (isNil)
		{
			return null;
		}
		return variantCollection;
	}

	public DataValueCollection ReadDataValueArray(string fieldName)
	{
		bool isNil = false;
		DataValueCollection dataValueCollection = new DataValueCollection();
		if (BeginField(fieldName, isOptional: true, out isNil))
		{
			PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
			while (MoveToElement("DataValue"))
			{
				dataValueCollection.Add(ReadDataValue("DataValue"));
			}
			if (m_context.MaxArrayLength > 0 && m_context.MaxArrayLength < dataValueCollection.Count)
			{
				throw new ServiceResultException(2148007936u);
			}
			PopNamespace();
			EndField(fieldName);
			return dataValueCollection;
		}
		if (isNil)
		{
			return null;
		}
		return dataValueCollection;
	}

	public ExtensionObjectCollection ReadExtensionObjectArray(string fieldName)
	{
		bool isNil = false;
		ExtensionObjectCollection extensionObjectCollection = new ExtensionObjectCollection();
		if (BeginField(fieldName, isOptional: true, out isNil))
		{
			PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
			while (MoveToElement("ExtensionObject"))
			{
				extensionObjectCollection.Add(ReadExtensionObject("ExtensionObject"));
			}
			if (m_context.MaxArrayLength > 0 && m_context.MaxArrayLength < extensionObjectCollection.Count)
			{
				throw new ServiceResultException(2148007936u);
			}
			PopNamespace();
			EndField(fieldName);
			return extensionObjectCollection;
		}
		if (isNil)
		{
			return null;
		}
		return extensionObjectCollection;
	}

	public Array ReadEncodeableArray(string fieldName, Type systemType, ExpandedNodeId encodeableTypeId = null)
	{
		if (systemType == null)
		{
			throw new ArgumentNullException("systemType");
		}
		bool isNil = false;
		IEncodeableCollection encodeableCollection = new IEncodeableCollection();
		if (BeginField(fieldName, isOptional: true, out isNil))
		{
			XmlQualifiedName xmlName = EncodeableFactory.GetXmlName(systemType);
			PushNamespace(xmlName.Namespace);
			while (MoveToElement(xmlName.Name))
			{
				encodeableCollection.Add(ReadEncodeable(xmlName.Name, systemType, encodeableTypeId));
			}
			if (m_context.MaxArrayLength > 0 && m_context.MaxArrayLength < encodeableCollection.Count)
			{
				throw new ServiceResultException(2148007936u);
			}
			PopNamespace();
			EndField(fieldName);
			Array array = Array.CreateInstance(systemType, encodeableCollection.Count);
			for (int i = 0; i < encodeableCollection.Count; i++)
			{
				array.SetValue(encodeableCollection[i], i);
			}
			return array;
		}
		if (isNil)
		{
			return null;
		}
		return Array.CreateInstance(systemType, 0);
	}

	public Array ReadEnumeratedArray(string fieldName, Type enumType)
	{
		if (enumType == null)
		{
			throw new ArgumentNullException("enumType");
		}
		bool isNil = false;
		List<Enum> list = new List<Enum>();
		if (BeginField(fieldName, isOptional: true, out isNil))
		{
			XmlQualifiedName xmlName = EncodeableFactory.GetXmlName(enumType);
			PushNamespace(xmlName.Namespace);
			while (MoveToElement(xmlName.Name))
			{
				list.Add(ReadEnumerated(xmlName.Name, enumType));
			}
			if (m_context.MaxArrayLength > 0 && m_context.MaxArrayLength < list.Count)
			{
				throw new ServiceResultException(2148007936u);
			}
			PopNamespace();
			EndField(fieldName);
			Array array = Array.CreateInstance(enumType, list.Count);
			for (int i = 0; i < list.Count; i++)
			{
				array.SetValue(list[i], i);
			}
			return array;
		}
		if (isNil)
		{
			return null;
		}
		return Array.CreateInstance(enumType, 0);
	}

	public Array ReadArray(string fieldName, int valueRank, BuiltInType builtInType, Type systemType, ExpandedNodeId encodeableTypeId = null)
	{
		if (valueRank == 1)
		{
			return ReadArrayElements(fieldName, builtInType, systemType, encodeableTypeId);
		}
		if (valueRank > 1)
		{
			Array array = null;
			Int32Collection int32Collection = null;
			if (BeginField(fieldName, isOptional: true))
			{
				PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
				int32Collection = ReadInt32Array("Dimensions");
				array = ReadArrayElements("Elements", builtInType, systemType, encodeableTypeId);
				PopNamespace();
				EndField(fieldName);
			}
			if (array == null)
			{
				throw new ServiceResultException(2147942400u, "The Matrix contains invalid elements");
			}
			Matrix matrix = ((int32Collection == null || int32Collection.Count <= 0) ? new Matrix(array, builtInType) : new Matrix(array, builtInType, int32Collection.ToArray()));
			return matrix.ToArray();
		}
		throw ServiceResultException.Create(2147942400u, "Invalid ValueRank {0} for Array", valueRank);
	}

	private DiagnosticInfo ReadDiagnosticInfo(int depth)
	{
		if (depth >= DiagnosticInfo.MaxInnerDepth)
		{
			throw ServiceResultException.Create(2148007936u, "Maximum nesting level of InnerDiagnosticInfo was exceeded");
		}
		CheckAndIncrementNestingLevel();
		try
		{
			DiagnosticInfo diagnosticInfo = new DiagnosticInfo();
			bool flag = false;
			if (BeginField("SymbolicId", isOptional: true))
			{
				diagnosticInfo.SymbolicId = ReadInt32(null);
				EndField("SymbolicId");
				flag = true;
			}
			if (BeginField("NamespaceUri", isOptional: true))
			{
				diagnosticInfo.NamespaceUri = ReadInt32(null);
				EndField("NamespaceUri");
				flag = true;
			}
			if (BeginField("Locale", isOptional: true))
			{
				diagnosticInfo.Locale = ReadInt32(null);
				EndField("Locale");
				flag = true;
			}
			if (BeginField("LocalizedText", isOptional: true))
			{
				diagnosticInfo.LocalizedText = ReadInt32(null);
				EndField("LocalizedText");
				flag = true;
			}
			diagnosticInfo.AdditionalInfo = ReadString("AdditionalInfo");
			diagnosticInfo.InnerStatusCode = ReadStatusCode("InnerStatusCode");
			flag = flag || diagnosticInfo.AdditionalInfo != null || diagnosticInfo.InnerStatusCode != 0u;
			if (BeginField("InnerDiagnosticInfo", isOptional: true))
			{
				diagnosticInfo.InnerDiagnosticInfo = ReadDiagnosticInfo(depth + 1);
				EndField("InnerDiagnosticInfo");
				flag = true;
			}
			return flag ? diagnosticInfo : null;
		}
		finally
		{
			m_nestingLevel--;
		}
	}

	private Matrix ReadMatrix(string fieldName)
	{
		CheckAndIncrementNestingLevel();
		try
		{
			Array array = null;
			Int32Collection int32Collection = null;
			TypeInfo typeInfo = null;
			if (BeginField(fieldName, isOptional: true))
			{
				PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
				if (BeginField("Elements", isOptional: true))
				{
					array = ReadVariantContents(out typeInfo) as Array;
					EndField("Elements");
				}
				int32Collection = ReadInt32Array("Dimensions");
				PopNamespace();
				EndField(fieldName);
			}
			if (array == null)
			{
				throw new ServiceResultException(2147942400u, "The Matrix contains invalid elements");
			}
			if (int32Collection != null && int32Collection.Count > 0)
			{
				return new Matrix(array, typeInfo.BuiltInType, int32Collection.ToArray());
			}
			return new Matrix(array, typeInfo.BuiltInType);
		}
		finally
		{
			m_nestingLevel--;
		}
	}

	private Array ReadArrayElements(string fieldName, BuiltInType builtInType, Type systemType, ExpandedNodeId encodeableTypeId)
	{
		CheckAndIncrementNestingLevel();
		try
		{
			while (m_reader.NodeType != XmlNodeType.Element)
			{
				m_reader.Read();
			}
			switch (builtInType)
			{
			case BuiltInType.Boolean:
				return ReadBooleanArray(fieldName)?.ToArray();
			case BuiltInType.SByte:
				return ReadSByteArray(fieldName)?.ToArray();
			case BuiltInType.Byte:
				return ReadByteArray(fieldName)?.ToArray();
			case BuiltInType.Int16:
				return ReadInt16Array(fieldName)?.ToArray();
			case BuiltInType.UInt16:
				return ReadUInt16Array(fieldName)?.ToArray();
			case BuiltInType.Int32:
			case BuiltInType.Enumeration:
			{
				Int32Collection int32Collection = ReadInt32Array(fieldName);
				if (int32Collection != null)
				{
					if (builtInType == BuiltInType.Enumeration)
					{
						DetermineIEncodeableSystemType(ref systemType, encodeableTypeId);
						if ((object)systemType != null && systemType.IsEnum)
						{
							Array array = Array.CreateInstance(systemType, int32Collection.Count);
							int num = 0;
							foreach (int item in int32Collection)
							{
								array.SetValue(Enum.ToObject(systemType, item), num++);
							}
							return array;
						}
					}
					return int32Collection.ToArray();
				}
				return null;
			}
			case BuiltInType.UInt32:
				return ReadUInt32Array(fieldName)?.ToArray();
			case BuiltInType.Int64:
				return ReadInt64Array(fieldName)?.ToArray();
			case BuiltInType.UInt64:
				return ReadUInt64Array(fieldName)?.ToArray();
			case BuiltInType.Float:
				return ReadFloatArray(fieldName)?.ToArray();
			case BuiltInType.Double:
				return ReadDoubleArray(fieldName)?.ToArray();
			case BuiltInType.String:
				return ReadStringArray(fieldName)?.ToArray();
			case BuiltInType.DateTime:
				return ReadDateTimeArray(fieldName)?.ToArray();
			case BuiltInType.Guid:
				return ReadGuidArray(fieldName)?.ToArray();
			case BuiltInType.ByteString:
				return ReadByteStringArray(fieldName)?.ToArray();
			case BuiltInType.XmlElement:
				return ReadXmlElementArray(fieldName)?.ToArray();
			case BuiltInType.NodeId:
				return ReadNodeIdArray(fieldName)?.ToArray();
			case BuiltInType.ExpandedNodeId:
				return ReadExpandedNodeIdArray(fieldName)?.ToArray();
			case BuiltInType.StatusCode:
				return ReadStatusCodeArray(fieldName)?.ToArray();
			case BuiltInType.DiagnosticInfo:
				return ReadDiagnosticInfoArray(fieldName)?.ToArray();
			case BuiltInType.QualifiedName:
				return ReadQualifiedNameArray(fieldName)?.ToArray();
			case BuiltInType.LocalizedText:
				return ReadLocalizedTextArray(fieldName)?.ToArray();
			case BuiltInType.ExtensionObject:
				return ReadExtensionObjectArray(fieldName)?.ToArray();
			case BuiltInType.DataValue:
				return ReadDataValueArray(fieldName)?.ToArray();
			case BuiltInType.Variant:
				if (DetermineIEncodeableSystemType(ref systemType, encodeableTypeId))
				{
					return ReadEncodeableArray(fieldName, systemType, encodeableTypeId);
				}
				return ReadVariantArray(fieldName)?.ToArray();
			default:
				if (DetermineIEncodeableSystemType(ref systemType, encodeableTypeId))
				{
					return ReadEncodeableArray(fieldName, systemType, encodeableTypeId);
				}
				throw ServiceResultException.Create(2147942400u, "Cannot decode unknown type in Array object with BuiltInType: {0}.", builtInType);
			}
		}
		finally
		{
			m_nestingLevel--;
		}
	}

	private string ReadString()
	{
		string text = m_reader.ReadContentAsString();
		if (text != null && m_context.MaxStringLength > 0 && m_context.MaxStringLength < text.Length)
		{
			throw new ServiceResultException(2148007936u);
		}
		return text;
	}

	private bool BeginField(string fieldName, bool isOptional)
	{
		bool isNil = false;
		return BeginField(fieldName, isOptional, out isNil);
	}

	private bool BeginField(string fieldName, bool isOptional, out bool isNil)
	{
		isNil = false;
		m_reader.MoveToContent();
		if (string.IsNullOrEmpty(fieldName))
		{
			return true;
		}
		if (!m_reader.IsStartElement(fieldName, m_namespaces.Peek()))
		{
			if (!isOptional)
			{
				throw new ServiceResultException(2147942400u, Utils.Format("Encountered element: '{1}:{0}' when expecting element: '{2}:{3}'.", m_reader.LocalName, m_reader.NamespaceURI, fieldName, m_namespaces.Peek()));
			}
			isNil = true;
			return false;
		}
		if (m_reader.HasAttributes)
		{
			string attribute = m_reader.GetAttribute("nil", "http://www.w3.org/2001/XMLSchema-instance");
			if (!string.IsNullOrEmpty(attribute) && XmlConvert.ToBoolean(attribute))
			{
				isNil = true;
			}
		}
		bool isEmptyElement = m_reader.IsEmptyElement;
		m_reader.ReadStartElement();
		if (!isEmptyElement)
		{
			m_reader.MoveToContent();
			if (m_reader.NodeType == XmlNodeType.EndElement && m_reader.LocalName == fieldName && m_reader.NamespaceURI == m_namespaces.Peek())
			{
				m_reader.ReadEndElement();
				return false;
			}
		}
		if (!isNil)
		{
			return !isEmptyElement;
		}
		return false;
	}

	private void EndField(string fieldName)
	{
		if (!string.IsNullOrEmpty(fieldName))
		{
			m_reader.MoveToContent();
			if (m_reader.NodeType != XmlNodeType.EndElement || m_reader.LocalName != fieldName || m_reader.NamespaceURI != m_namespaces.Peek())
			{
				throw new ServiceResultException(2147942400u, Utils.Format("Encountered end element: '{1}:{0}' when expecting element: '{3}:{2}'.", m_reader.LocalName, m_reader.NamespaceURI, fieldName, m_namespaces.Peek()));
			}
			m_reader.ReadEndElement();
		}
	}

	private bool MoveToElement(string elementName)
	{
		while (!m_reader.IsStartElement())
		{
			if (m_reader.NodeType == XmlNodeType.None || m_reader.NodeType == XmlNodeType.EndElement)
			{
				return false;
			}
			m_reader.Read();
		}
		if (string.IsNullOrEmpty(elementName))
		{
			return true;
		}
		if (m_reader.LocalName == elementName)
		{
			return m_reader.NamespaceURI == m_namespaces.Peek();
		}
		return false;
	}

	private bool DetermineIEncodeableSystemType(ref Type systemType, ExpandedNodeId encodeableTypeId)
	{
		if (encodeableTypeId != null && systemType == null)
		{
			systemType = Context.Factory.GetSystemType(encodeableTypeId);
		}
		return typeof(IEncodeable).IsAssignableFrom(systemType);
	}

	private void CheckAndIncrementNestingLevel()
	{
		if (m_nestingLevel > m_context.MaxEncodingNestingLevels)
		{
			throw ServiceResultException.Create(2148007936u, "Maximum nesting level of {0} was exceeded", m_context.MaxEncodingNestingLevels);
		}
		m_nestingLevel++;
	}
}
