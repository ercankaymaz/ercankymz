using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;

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

	public EncodingType EncodingType => EncodingType.Xml;

	public IServiceMessageContext Context => m_context;

	public bool UseReversibleEncoding => true;

	public XmlEncoder(IServiceMessageContext context)
	{
		Initialize();
		m_destination = new StringBuilder();
		m_context = context;
		m_nestingLevel = 0u;
		XmlWriterSettings xmlWriterSettings = Utils.DefaultXmlWriterSettings();
		xmlWriterSettings.CheckCharacters = false;
		xmlWriterSettings.ConformanceLevel = ConformanceLevel.Auto;
		xmlWriterSettings.NamespaceHandling = NamespaceHandling.OmitDuplicates;
		xmlWriterSettings.NewLineHandling = NewLineHandling.Replace;
		m_writer = XmlWriter.Create(m_destination, xmlWriterSettings);
	}

	public XmlEncoder(Type systemType, XmlWriter writer, IServiceMessageContext context)
		: this(EncodeableFactory.GetXmlName(systemType), writer, context)
	{
	}

	public XmlEncoder(XmlQualifiedName root, XmlWriter writer, IServiceMessageContext context)
	{
		Initialize();
		if (writer == null)
		{
			m_destination = new StringBuilder();
			m_writer = XmlWriter.Create(m_destination);
		}
		else
		{
			m_destination = null;
			m_writer = writer;
		}
		Initialize(root.Name, root.Namespace);
		m_context = context;
		m_nestingLevel = 0u;
	}

	private void Initialize()
	{
		m_destination = null;
		m_writer = null;
		m_namespaces = new Stack<string>();
		m_root = null;
	}

	private void Initialize(string fieldName, string namespaceUri)
	{
		m_root = new XmlQualifiedName(fieldName, namespaceUri);
		string text = m_writer.LookupPrefix("http://opcfoundation.org/UA/2008/02/Types.xsd");
		if (text == null)
		{
			text = "uax";
		}
		if (namespaceUri == "http://opcfoundation.org/UA/2008/02/Types.xsd")
		{
			m_writer.WriteStartElement(text, fieldName, namespaceUri);
		}
		else
		{
			m_writer.WriteStartElement(fieldName, namespaceUri);
		}
		if (m_writer.LookupPrefix("http://www.w3.org/2001/XMLSchema-instance") == null)
		{
			m_writer.WriteAttributeString("xmlns", "xsi", null, "http://www.w3.org/2001/XMLSchema-instance");
		}
		text = m_writer.LookupPrefix("http://opcfoundation.org/UA/2008/02/Types.xsd");
		if (text == null)
		{
			m_writer.WriteAttributeString("xmlns", "uax", null, "http://opcfoundation.org/UA/2008/02/Types.xsd");
		}
		PushNamespace(namespaceUri);
	}

	public void SetMappingTables(NamespaceTable namespaceUris, StringTable serverUris)
	{
		m_namespaceMappings = null;
		if (namespaceUris != null && m_context.NamespaceUris != null)
		{
			m_namespaceMappings = namespaceUris.CreateMapping(m_context.NamespaceUris, updateTable: false);
		}
		m_serverMappings = null;
		if (serverUris != null && m_context.ServerUris != null)
		{
			m_serverMappings = serverUris.CreateMapping(m_context.ServerUris, updateTable: false);
		}
	}

	public void SaveStringTable(string tableName, string elementName, StringTable stringTable)
	{
		if (stringTable == null || stringTable.Count <= 1)
		{
			return;
		}
		PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		try
		{
			Push(tableName, "http://opcfoundation.org/UA/2008/02/Types.xsd");
			for (ushort num = 1; num < stringTable.Count; num++)
			{
				WriteString(elementName, stringTable.GetString(num));
			}
			Pop();
		}
		finally
		{
			PopNamespace();
		}
	}

	public void Push(string fieldName, string namespaceUri)
	{
		m_writer.WriteStartElement(fieldName, namespaceUri);
		PushNamespace(namespaceUri);
	}

	public void Pop()
	{
		m_writer.WriteEndElement();
		PopNamespace();
	}

	public int Close()
	{
		if (m_root != null)
		{
			m_writer.WriteEndElement();
		}
		m_writer.Flush();
		m_writer.Dispose();
		if (m_destination != null)
		{
			return m_destination.Length;
		}
		return 0;
	}

	public string CloseAndReturnText()
	{
		Close();
		if (m_destination != null)
		{
			return m_destination.ToString();
		}
		return null;
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (disposing && m_writer != null)
		{
			m_writer.Flush();
			m_writer.Dispose();
			m_writer = null;
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

	public void WriteBoolean(string fieldName, bool value)
	{
		if (BeginField(fieldName, isDefault: false, isNillable: false))
		{
			m_writer.WriteValue(value);
			EndField(fieldName);
		}
	}

	public void WriteSByte(string fieldName, sbyte value)
	{
		if (BeginField(fieldName, isDefault: false, isNillable: false))
		{
			m_writer.WriteValue(value);
			EndField(fieldName);
		}
	}

	public void WriteByte(string fieldName, byte value)
	{
		if (BeginField(fieldName, isDefault: false, isNillable: false))
		{
			m_writer.WriteValue(value);
			EndField(fieldName);
		}
	}

	public void WriteInt16(string fieldName, short value)
	{
		if (BeginField(fieldName, isDefault: false, isNillable: false))
		{
			m_writer.WriteValue(value);
			EndField(fieldName);
		}
	}

	public void WriteUInt16(string fieldName, ushort value)
	{
		if (BeginField(fieldName, isDefault: false, isNillable: false))
		{
			m_writer.WriteValue(value);
			EndField(fieldName);
		}
	}

	public void WriteInt32(string fieldName, int value)
	{
		if (BeginField(fieldName, isDefault: false, isNillable: false))
		{
			m_writer.WriteValue(value);
			EndField(fieldName);
		}
	}

	public void WriteUInt32(string fieldName, uint value)
	{
		if (BeginField(fieldName, isDefault: false, isNillable: false))
		{
			m_writer.WriteValue(value);
			EndField(fieldName);
		}
	}

	public void WriteInt64(string fieldName, long value)
	{
		if (BeginField(fieldName, isDefault: false, isNillable: false))
		{
			m_writer.WriteValue(value);
			EndField(fieldName);
		}
	}

	public void WriteUInt64(string fieldName, ulong value)
	{
		if (BeginField(fieldName, isDefault: false, isNillable: false))
		{
			m_writer.WriteValue(XmlConvert.ToString(value));
			EndField(fieldName);
		}
	}

	public void WriteFloat(string fieldName, float value)
	{
		if (BeginField(fieldName, isDefault: false, isNillable: false))
		{
			if (float.IsNaN(value))
			{
				m_writer.WriteValue("NaN");
			}
			else if (float.IsPositiveInfinity(value))
			{
				m_writer.WriteValue("INF");
			}
			else if (float.IsNegativeInfinity(value))
			{
				m_writer.WriteValue("-INF");
			}
			else
			{
				m_writer.WriteValue(value);
			}
			EndField(fieldName);
		}
	}

	public void WriteDouble(string fieldName, double value)
	{
		if (BeginField(fieldName, isDefault: false, isNillable: false))
		{
			m_writer.WriteValue(value);
			EndField(fieldName);
		}
	}

	public void WriteString(string fieldName, string value)
	{
		WriteString(fieldName, value, isArrayElement: false);
	}

	private void WriteString(string fieldName, string value, bool isArrayElement)
	{
		if (BeginField(fieldName, value == null, isNillable: true, isArrayElement))
		{
			if (m_context.MaxStringLength > 0 && m_context.MaxStringLength < value.Length)
			{
				throw new ServiceResultException(2148007936u);
			}
			if (!string.IsNullOrWhiteSpace(value))
			{
				m_writer.WriteString(value);
			}
			EndField(fieldName);
		}
	}

	public void WriteDateTime(string fieldName, DateTime value)
	{
		if (BeginField(fieldName, isDefault: false, isNillable: false))
		{
			value = Utils.ToOpcUaUniversalTime(value);
			m_writer.WriteValue(value);
			EndField(fieldName);
		}
	}

	public void WriteGuid(string fieldName, Uuid value)
	{
		if (BeginField(fieldName, isDefault: false, isNillable: false))
		{
			PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
			WriteString("String", value.GuidString);
			PopNamespace();
			EndField(fieldName);
		}
	}

	public void WriteGuid(string fieldName, Guid value)
	{
		if (BeginField(fieldName, isDefault: false, isNillable: false))
		{
			PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
			WriteString("String", value.ToString());
			PopNamespace();
			EndField(fieldName);
		}
	}

	public void WriteByteString(string fieldName, byte[] value)
	{
		WriteByteString(fieldName, value, false);
	}

	private void WriteByteString(string fieldName, byte[] value, bool isArrayElement = false)
	{
		if (BeginField(fieldName, value == null, isNillable: true, isArrayElement))
		{
			if (m_context.MaxByteStringLength > 0 && m_context.MaxByteStringLength < value.Length)
			{
				throw new ServiceResultException(2148007936u);
			}
			m_writer.WriteValue(Convert.ToBase64String(value, Base64FormattingOptions.InsertLineBreaks));
			EndField(fieldName);
		}
	}

	public void WriteXmlElement(string fieldName, XmlElement value)
	{
		WriteXmlElement(fieldName, value, isArrayElement: false);
	}

	private void WriteXmlElement(string fieldName, XmlElement value, bool isArrayElement)
	{
		if (BeginField(fieldName, value == null, isNillable: true, isArrayElement))
		{
			m_writer.WriteRaw(value.OuterXml);
			EndField(fieldName);
		}
	}

	public void WriteNodeId(string fieldName, NodeId value)
	{
		if (!BeginField(fieldName, value == null, isNillable: true))
		{
			return;
		}
		PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		if (value != null)
		{
			ushort num = value.NamespaceIndex;
			if (m_namespaceMappings != null && m_namespaceMappings.Length > num)
			{
				num = m_namespaceMappings[num];
			}
			StringBuilder stringBuilder = new StringBuilder();
			NodeId.Format(stringBuilder, value.Identifier, value.IdType, num);
			WriteString("Identifier", stringBuilder.ToString());
		}
		PopNamespace();
		EndField(fieldName);
	}

	public void WriteExpandedNodeId(string fieldName, ExpandedNodeId value)
	{
		if (!BeginField(fieldName, value == null, isNillable: true))
		{
			return;
		}
		PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		if (value != null)
		{
			ushort num = value.NamespaceIndex;
			if (m_namespaceMappings != null && m_namespaceMappings.Length > num)
			{
				num = m_namespaceMappings[num];
			}
			uint num2 = value.ServerIndex;
			if (m_serverMappings != null && m_serverMappings.Length > num2)
			{
				num2 = m_serverMappings[num2];
			}
			StringBuilder stringBuilder = new StringBuilder();
			ExpandedNodeId.Format(stringBuilder, value.Identifier, value.IdType, num, value.NamespaceUri, num2);
			WriteString("Identifier", stringBuilder.ToString());
		}
		PopNamespace();
		EndField(fieldName);
	}

	public void WriteStatusCode(string fieldName, StatusCode value)
	{
		if (BeginField(fieldName, isDefault: false, isNillable: false))
		{
			PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
			WriteUInt32("Code", value.Code);
			PopNamespace();
			EndField(fieldName);
		}
	}

	public void WriteDiagnosticInfo(string fieldName, DiagnosticInfo value)
	{
		WriteDiagnosticInfo(fieldName, value, 0);
	}

	private void WriteDiagnosticInfo(string fieldName, DiagnosticInfo value, int depth)
	{
		CheckAndIncrementNestingLevel();
		if (BeginField(fieldName, value == null, isNillable: true))
		{
			PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
			if (value != null)
			{
				WriteInt32("SymbolicId", value.SymbolicId);
				WriteInt32("NamespaceUri", value.NamespaceUri);
				WriteInt32("Locale", value.Locale);
				WriteInt32("LocalizedText", value.LocalizedText);
				WriteString("AdditionalInfo", value.AdditionalInfo);
				WriteStatusCode("InnerStatusCode", value.InnerStatusCode);
				if (depth < DiagnosticInfo.MaxInnerDepth)
				{
					WriteDiagnosticInfo("InnerDiagnosticInfo", value.InnerDiagnosticInfo, depth + 1);
				}
				else
				{
					Utils.LogWarning("InnerDiagnosticInfo dropped because nesting exceeds maximum of {0}.", DiagnosticInfo.MaxInnerDepth);
				}
			}
			PopNamespace();
			EndField(fieldName);
		}
		m_nestingLevel--;
	}

	public void WriteQualifiedName(string fieldName, QualifiedName value)
	{
		if (BeginField(fieldName, value == null, isNillable: true))
		{
			PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
			ushort num = value.NamespaceIndex;
			if (m_namespaceMappings != null && m_namespaceMappings.Length > num)
			{
				num = m_namespaceMappings[num];
			}
			if (value != null)
			{
				WriteUInt16("NamespaceIndex", num);
				WriteString("Name", value.Name);
			}
			PopNamespace();
			EndField(fieldName);
		}
	}

	public void WriteLocalizedText(string fieldName, LocalizedText value)
	{
		if (!BeginField(fieldName, value == null, isNillable: true))
		{
			return;
		}
		PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		if (value != null)
		{
			if (!string.IsNullOrEmpty(value.Locale))
			{
				WriteString("Locale", value.Locale);
			}
			if (!string.IsNullOrEmpty(value.Text))
			{
				WriteString("Text", value.Text);
			}
		}
		PopNamespace();
		EndField(fieldName);
	}

	public void WriteVariant(string fieldName, Variant value)
	{
		CheckAndIncrementNestingLevel();
		try
		{
			if (BeginField(fieldName, isDefault: false, isNillable: false))
			{
				PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
				m_writer.WriteStartElement("Value", "http://opcfoundation.org/UA/2008/02/Types.xsd");
				WriteVariantContents(value.Value, value.TypeInfo);
				m_writer.WriteEndElement();
				PopNamespace();
				EndField(fieldName);
			}
		}
		finally
		{
			m_nestingLevel--;
		}
	}

	public void WriteDataValue(string fieldName, DataValue value)
	{
		if (BeginField(fieldName, value == null, isNillable: true))
		{
			PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
			if (value != null)
			{
				WriteVariant("Value", value.WrappedValue);
				WriteStatusCode("StatusCode", value.StatusCode);
				WriteDateTime("SourceTimestamp", value.SourceTimestamp);
				WriteUInt16("SourcePicoseconds", value.SourcePicoseconds);
				WriteDateTime("ServerTimestamp", value.ServerTimestamp);
				WriteUInt16("ServerPicoseconds", value.ServerPicoseconds);
			}
			PopNamespace();
			EndField(fieldName);
		}
	}

	public void WriteExtensionObject(string fieldName, ExtensionObject value)
	{
		if (!BeginField(fieldName, value == null, isNillable: true))
		{
			return;
		}
		PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		if (value == null)
		{
			EndField(fieldName);
			PopNamespace();
			return;
		}
		IEncodeable encodeable = value.Body as IEncodeable;
		ExpandedNodeId expandedNodeId = value.TypeId;
		if (encodeable != null)
		{
			expandedNodeId = ((value.Encoding != ExtensionObjectEncoding.Binary) ? encodeable.XmlEncodingId : encodeable.BinaryEncodingId);
		}
		NodeId nodeId = ExpandedNodeId.ToNodeId(expandedNodeId, m_context.NamespaceUris);
		if (NodeId.IsNull(nodeId) && !NodeId.IsNull(expandedNodeId))
		{
			if (encodeable != null)
			{
				throw ServiceResultException.Create(2147876864u, "Cannot encode bodies of type '{0}' in ExtensionObject unless the NamespaceUri ({1}) is in the encoder's NamespaceTable.", encodeable.GetType().FullName, expandedNodeId.NamespaceUri);
			}
			nodeId = NodeId.Null;
		}
		WriteNodeId("TypeId", nodeId);
		object body = value.Body;
		if (body == null)
		{
			EndField(fieldName);
			PopNamespace();
			return;
		}
		m_writer.WriteStartElement("Body", "http://opcfoundation.org/UA/2008/02/Types.xsd");
		WriteExtensionObjectBody(body);
		m_writer.WriteEndElement();
		EndField(fieldName);
		PopNamespace();
	}

	public void WriteEncodeable(string fieldName, IEncodeable value, Type systemType)
	{
		CheckAndIncrementNestingLevel();
		if (BeginField(fieldName, value == null, isNillable: true))
		{
			value?.Encode(this);
			EndField(fieldName);
		}
		m_nestingLevel--;
	}

	public void WriteEnumerated(string fieldName, Enum value)
	{
		if (!BeginField(fieldName, value == null, isNillable: true))
		{
			return;
		}
		if (value != null)
		{
			string text = value.ToString();
			string text2 = Convert.ToInt32(value, CultureInfo.InvariantCulture).ToString();
			if (text != text2)
			{
				m_writer.WriteString(Utils.Format("{0}_{1}", text, text2));
			}
			else
			{
				m_writer.WriteString(text);
			}
		}
		EndField(fieldName);
	}

	public void WriteBooleanArray(string fieldName, IList<bool> values)
	{
		if (!BeginField(fieldName, values == null, isNillable: true, isArrayElement: true))
		{
			return;
		}
		if (m_context.MaxArrayLength > 0 && m_context.MaxArrayLength < values.Count)
		{
			throw new ServiceResultException(2148007936u);
		}
		PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		if (values != null)
		{
			for (int i = 0; i < values.Count; i++)
			{
				WriteBoolean("Boolean", values[i]);
			}
		}
		PopNamespace();
		EndField(fieldName);
	}

	public void WriteSByteArray(string fieldName, IList<sbyte> values)
	{
		if (!BeginField(fieldName, values == null, isNillable: true, isArrayElement: true))
		{
			return;
		}
		if (m_context.MaxArrayLength > 0 && m_context.MaxArrayLength < values.Count)
		{
			throw new ServiceResultException(2148007936u);
		}
		PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		if (values != null)
		{
			for (int i = 0; i < values.Count; i++)
			{
				WriteSByte("SByte", values[i]);
			}
		}
		PopNamespace();
		EndField(fieldName);
	}

	public void WriteByteArray(string fieldName, IList<byte> values)
	{
		if (!BeginField(fieldName, values == null, isNillable: true, isArrayElement: true))
		{
			return;
		}
		if (m_context.MaxArrayLength > 0 && m_context.MaxArrayLength < values.Count)
		{
			throw new ServiceResultException(2148007936u);
		}
		PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		if (values != null)
		{
			for (int i = 0; i < values.Count; i++)
			{
				WriteByte("Byte", values[i]);
			}
		}
		PopNamespace();
		EndField(fieldName);
	}

	public void WriteInt16Array(string fieldName, IList<short> values)
	{
		if (!BeginField(fieldName, values == null, isNillable: true, isArrayElement: true))
		{
			return;
		}
		if (m_context.MaxArrayLength > 0 && m_context.MaxArrayLength < values.Count)
		{
			throw new ServiceResultException(2148007936u);
		}
		PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		if (values != null)
		{
			for (int i = 0; i < values.Count; i++)
			{
				WriteInt16("Int16", values[i]);
			}
		}
		PopNamespace();
		EndField(fieldName);
	}

	public void WriteUInt16Array(string fieldName, IList<ushort> values)
	{
		if (!BeginField(fieldName, values == null, isNillable: true, isArrayElement: true))
		{
			return;
		}
		if (m_context.MaxArrayLength > 0 && m_context.MaxArrayLength < values.Count)
		{
			throw new ServiceResultException(2148007936u);
		}
		PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		if (values != null)
		{
			for (int i = 0; i < values.Count; i++)
			{
				WriteUInt16("UInt16", values[i]);
			}
		}
		PopNamespace();
		EndField(fieldName);
	}

	public void WriteInt32Array(string fieldName, IList<int> values)
	{
		if (!BeginField(fieldName, values == null, isNillable: true, isArrayElement: true))
		{
			return;
		}
		if (m_context.MaxArrayLength > 0 && m_context.MaxArrayLength < values.Count)
		{
			throw new ServiceResultException(2148007936u);
		}
		PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		if (values != null)
		{
			for (int i = 0; i < values.Count; i++)
			{
				WriteInt32("Int32", values[i]);
			}
		}
		PopNamespace();
		EndField(fieldName);
	}

	public void WriteUInt32Array(string fieldName, IList<uint> values)
	{
		if (!BeginField(fieldName, values == null, isNillable: true, isArrayElement: true))
		{
			return;
		}
		if (m_context.MaxArrayLength > 0 && m_context.MaxArrayLength < values.Count)
		{
			throw new ServiceResultException(2148007936u);
		}
		PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		if (values != null)
		{
			for (int i = 0; i < values.Count; i++)
			{
				WriteUInt32("UInt32", values[i]);
			}
		}
		PopNamespace();
		EndField(fieldName);
	}

	public void WriteInt64Array(string fieldName, IList<long> values)
	{
		if (!BeginField(fieldName, values == null, isNillable: true, isArrayElement: true))
		{
			return;
		}
		if (m_context.MaxArrayLength > 0 && m_context.MaxArrayLength < values.Count)
		{
			throw new ServiceResultException(2148007936u);
		}
		PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		if (values != null)
		{
			for (int i = 0; i < values.Count; i++)
			{
				WriteInt64("Int64", values[i]);
			}
		}
		PopNamespace();
		EndField(fieldName);
	}

	public void WriteUInt64Array(string fieldName, IList<ulong> values)
	{
		if (!BeginField(fieldName, values == null, isNillable: true, isArrayElement: true))
		{
			return;
		}
		if (m_context.MaxArrayLength > 0 && m_context.MaxArrayLength < values.Count)
		{
			throw new ServiceResultException(2148007936u);
		}
		PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		if (values != null)
		{
			for (int i = 0; i < values.Count; i++)
			{
				WriteUInt64("UInt64", values[i]);
			}
		}
		PopNamespace();
		EndField(fieldName);
	}

	public void WriteFloatArray(string fieldName, IList<float> values)
	{
		if (!BeginField(fieldName, values == null, isNillable: true, isArrayElement: true))
		{
			return;
		}
		if (m_context.MaxArrayLength > 0 && m_context.MaxArrayLength < values.Count)
		{
			throw new ServiceResultException(2148007936u);
		}
		PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		if (values != null)
		{
			for (int i = 0; i < values.Count; i++)
			{
				WriteFloat("Float", values[i]);
			}
		}
		PopNamespace();
		EndField(fieldName);
	}

	public void WriteDoubleArray(string fieldName, IList<double> values)
	{
		if (!BeginField(fieldName, values == null, isNillable: true, isArrayElement: true))
		{
			return;
		}
		if (m_context.MaxArrayLength > 0 && m_context.MaxArrayLength < values.Count)
		{
			throw new ServiceResultException(2148007936u);
		}
		PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		if (values != null)
		{
			for (int i = 0; i < values.Count; i++)
			{
				WriteDouble("Double", values[i]);
			}
		}
		PopNamespace();
		EndField(fieldName);
	}

	public void WriteStringArray(string fieldName, IList<string> values)
	{
		if (!BeginField(fieldName, values == null, isNillable: true, isArrayElement: true))
		{
			return;
		}
		if (m_context.MaxArrayLength > 0 && m_context.MaxArrayLength < values.Count)
		{
			throw new ServiceResultException(2148007936u);
		}
		PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		if (values != null)
		{
			for (int i = 0; i < values.Count; i++)
			{
				WriteString("String", values[i], isArrayElement: true);
			}
		}
		PopNamespace();
		EndField(fieldName);
	}

	public void WriteDateTimeArray(string fieldName, IList<DateTime> values)
	{
		if (!BeginField(fieldName, values == null, isNillable: true, isArrayElement: true))
		{
			return;
		}
		if (m_context.MaxArrayLength > 0 && m_context.MaxArrayLength < values.Count)
		{
			throw new ServiceResultException(2148007936u);
		}
		PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		if (values != null)
		{
			for (int i = 0; i < values.Count; i++)
			{
				WriteDateTime("DateTime", values[i]);
			}
		}
		PopNamespace();
		EndField(fieldName);
	}

	public void WriteGuidArray(string fieldName, IList<Uuid> values)
	{
		if (!BeginField(fieldName, values == null, isNillable: true, isArrayElement: true))
		{
			return;
		}
		if (m_context.MaxArrayLength > 0 && m_context.MaxArrayLength < values.Count)
		{
			throw new ServiceResultException(2148007936u);
		}
		PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		if (values != null)
		{
			for (int i = 0; i < values.Count; i++)
			{
				WriteGuid("Guid", values[i]);
			}
		}
		PopNamespace();
		EndField(fieldName);
	}

	public void WriteGuidArray(string fieldName, IList<Guid> values)
	{
		if (!BeginField(fieldName, values == null, isNillable: true, isArrayElement: true))
		{
			return;
		}
		if (m_context.MaxArrayLength > 0 && m_context.MaxArrayLength < values.Count)
		{
			throw new ServiceResultException(2148007936u);
		}
		PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		if (values != null)
		{
			for (int i = 0; i < values.Count; i++)
			{
				WriteGuid("Guid", values[i]);
			}
		}
		PopNamespace();
		EndField(fieldName);
	}

	public void WriteByteStringArray(string fieldName, IList<byte[]> values)
	{
		if (!BeginField(fieldName, values == null, isNillable: true, isArrayElement: true))
		{
			return;
		}
		if (m_context.MaxArrayLength > 0 && m_context.MaxArrayLength < values.Count)
		{
			throw new ServiceResultException(2148007936u);
		}
		PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		if (values != null)
		{
			for (int i = 0; i < values.Count; i++)
			{
				WriteByteString("ByteString", values[i], isArrayElement: true);
			}
		}
		PopNamespace();
		EndField(fieldName);
	}

	public void WriteXmlElementArray(string fieldName, IList<XmlElement> values)
	{
		if (!BeginField(fieldName, values == null, isNillable: true, isArrayElement: true))
		{
			return;
		}
		if (m_context.MaxArrayLength > 0 && m_context.MaxArrayLength < values.Count)
		{
			throw new ServiceResultException(2148007936u);
		}
		PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		if (values != null)
		{
			for (int i = 0; i < values.Count; i++)
			{
				WriteXmlElement("XmlElement", values[i], isArrayElement: true);
			}
		}
		PopNamespace();
		EndField(fieldName);
	}

	public void WriteNodeIdArray(string fieldName, IList<NodeId> values)
	{
		if (!BeginField(fieldName, values == null, isNillable: true, isArrayElement: true))
		{
			return;
		}
		if (m_context.MaxArrayLength > 0 && m_context.MaxArrayLength < values.Count)
		{
			throw new ServiceResultException(2148007936u);
		}
		PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		if (values != null)
		{
			for (int i = 0; i < values.Count; i++)
			{
				WriteNodeId("NodeId", values[i]);
			}
		}
		PopNamespace();
		EndField(fieldName);
	}

	public void WriteExpandedNodeIdArray(string fieldName, IList<ExpandedNodeId> values)
	{
		if (!BeginField(fieldName, values == null, isNillable: true, isArrayElement: true))
		{
			return;
		}
		if (m_context.MaxArrayLength > 0 && m_context.MaxArrayLength < values.Count)
		{
			throw new ServiceResultException(2148007936u);
		}
		PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		if (values != null)
		{
			for (int i = 0; i < values.Count; i++)
			{
				WriteExpandedNodeId("ExpandedNodeId", values[i]);
			}
		}
		PopNamespace();
		EndField(fieldName);
	}

	public void WriteStatusCodeArray(string fieldName, IList<StatusCode> values)
	{
		if (!BeginField(fieldName, values == null, isNillable: true, isArrayElement: true))
		{
			return;
		}
		if (m_context.MaxArrayLength > 0 && m_context.MaxArrayLength < values.Count)
		{
			throw new ServiceResultException(2148007936u);
		}
		PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		if (values != null)
		{
			for (int i = 0; i < values.Count; i++)
			{
				WriteStatusCode("StatusCode", values[i]);
			}
		}
		PopNamespace();
		EndField(fieldName);
	}

	public void WriteDiagnosticInfoArray(string fieldName, IList<DiagnosticInfo> values)
	{
		if (!BeginField(fieldName, values == null, isNillable: true, isArrayElement: true))
		{
			return;
		}
		if (m_context.MaxArrayLength > 0 && m_context.MaxArrayLength < values.Count)
		{
			throw new ServiceResultException(2148007936u);
		}
		PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		if (values != null)
		{
			for (int i = 0; i < values.Count; i++)
			{
				WriteDiagnosticInfo("DiagnosticInfo", values[i]);
			}
		}
		PopNamespace();
		EndField(fieldName);
	}

	public void WriteQualifiedNameArray(string fieldName, IList<QualifiedName> values)
	{
		if (!BeginField(fieldName, values == null, isNillable: true, isArrayElement: true))
		{
			return;
		}
		if (m_context.MaxArrayLength > 0 && m_context.MaxArrayLength < values.Count)
		{
			throw new ServiceResultException(2148007936u);
		}
		PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		if (values != null)
		{
			for (int i = 0; i < values.Count; i++)
			{
				WriteQualifiedName("QualifiedName", values[i]);
			}
		}
		PopNamespace();
		EndField(fieldName);
	}

	public void WriteLocalizedTextArray(string fieldName, IList<LocalizedText> values)
	{
		if (!BeginField(fieldName, values == null, isNillable: true, isArrayElement: true))
		{
			return;
		}
		if (m_context.MaxArrayLength > 0 && m_context.MaxArrayLength < values.Count)
		{
			throw new ServiceResultException(2148007936u);
		}
		PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		if (values != null)
		{
			for (int i = 0; i < values.Count; i++)
			{
				WriteLocalizedText("LocalizedText", values[i]);
			}
		}
		PopNamespace();
		EndField(fieldName);
	}

	public void WriteVariantArray(string fieldName, IList<Variant> values)
	{
		if (!BeginField(fieldName, values == null, isNillable: true, isArrayElement: true))
		{
			return;
		}
		if (m_context.MaxArrayLength > 0 && m_context.MaxArrayLength < values.Count)
		{
			throw new ServiceResultException(2148007936u);
		}
		PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		if (values != null)
		{
			for (int i = 0; i < values.Count; i++)
			{
				WriteVariant("Variant", values[i]);
			}
		}
		PopNamespace();
		EndField(fieldName);
	}

	public void WriteDataValueArray(string fieldName, IList<DataValue> values)
	{
		if (!BeginField(fieldName, values == null, isNillable: true, isArrayElement: true))
		{
			return;
		}
		if (m_context.MaxArrayLength > 0 && m_context.MaxArrayLength < values.Count)
		{
			throw new ServiceResultException(2148007936u);
		}
		PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		if (values != null)
		{
			for (int i = 0; i < values.Count; i++)
			{
				WriteDataValue("DataValue", values[i]);
			}
		}
		PopNamespace();
		EndField(fieldName);
	}

	public void WriteExtensionObjectArray(string fieldName, IList<ExtensionObject> values)
	{
		if (!BeginField(fieldName, values == null, isNillable: true, isArrayElement: true))
		{
			return;
		}
		if (m_context.MaxArrayLength > 0 && m_context.MaxArrayLength < values.Count)
		{
			throw new ServiceResultException(2148007936u);
		}
		PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		if (values != null)
		{
			for (int i = 0; i < values.Count; i++)
			{
				WriteExtensionObject("ExtensionObject", values[i]);
			}
		}
		PopNamespace();
		EndField(fieldName);
	}

	public void WriteEncodeableArray(string fieldName, IList<IEncodeable> values, Type systemType)
	{
		if (!BeginField(fieldName, values == null, isNillable: true, isArrayElement: true))
		{
			return;
		}
		if (m_context.MaxArrayLength > 0 && m_context.MaxArrayLength < values.Count)
		{
			throw new ServiceResultException(2148007936u);
		}
		XmlQualifiedName xmlQualifiedName = EncodeableFactory.GetXmlName(systemType);
		if (xmlQualifiedName == null)
		{
			xmlQualifiedName = new XmlQualifiedName("IEncodeable", "http://opcfoundation.org/UA/2008/02/Types.xsd");
		}
		PushNamespace(xmlQualifiedName.Namespace);
		for (int i = 0; i < values.Count; i++)
		{
			IEncodeable encodeable = values[i];
			if (systemType != null)
			{
				if (!systemType.IsInstanceOfType(encodeable))
				{
					throw new ServiceResultException(2147876864u, Utils.Format("Objects with type '{0}' are not allowed in the array being serialized.", systemType.FullName));
				}
				WriteEncodeable(xmlQualifiedName.Name, encodeable, systemType);
			}
		}
		PopNamespace();
		EndField(fieldName);
	}

	public void WriteEnumeratedArray(string fieldName, Array values, Type systemType)
	{
		if (!BeginField(fieldName, values == null, isNillable: true, isArrayElement: true))
		{
			return;
		}
		if (m_context.MaxArrayLength > 0 && m_context.MaxArrayLength < values.Length)
		{
			throw new ServiceResultException(2148007936u);
		}
		XmlQualifiedName xmlQualifiedName = EncodeableFactory.GetXmlName(systemType);
		if (xmlQualifiedName == null)
		{
			xmlQualifiedName = new XmlQualifiedName("Enumerated", "http://opcfoundation.org/UA/2008/02/Types.xsd");
		}
		PushNamespace(xmlQualifiedName.Namespace);
		if (values != null)
		{
			foreach (Enum value in values)
			{
				WriteEnumerated(xmlQualifiedName.Name, value);
			}
		}
		PopNamespace();
		EndField(fieldName);
	}

	public void WriteVariantContents(object value, TypeInfo typeInfo)
	{
		if (value == null)
		{
			m_writer.WriteStartElement("Null", "http://opcfoundation.org/UA/2008/02/Types.xsd");
			m_writer.WriteEndElement();
			return;
		}
		try
		{
			PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
			if (typeInfo.ValueRank < 0)
			{
				switch (typeInfo.BuiltInType)
				{
				case BuiltInType.Boolean:
					WriteBoolean("Boolean", (bool)value);
					return;
				case BuiltInType.SByte:
					WriteSByte("SByte", (sbyte)value);
					return;
				case BuiltInType.Byte:
					WriteByte("Byte", (byte)value);
					return;
				case BuiltInType.Int16:
					WriteInt16("Int16", (short)value);
					return;
				case BuiltInType.UInt16:
					WriteUInt16("UInt16", (ushort)value);
					return;
				case BuiltInType.Int32:
					WriteInt32("Int32", (int)value);
					return;
				case BuiltInType.UInt32:
					WriteUInt32("UInt32", (uint)value);
					return;
				case BuiltInType.Int64:
					WriteInt64("Int64", (long)value);
					return;
				case BuiltInType.UInt64:
					WriteUInt64("UInt64", (ulong)value);
					return;
				case BuiltInType.Float:
					WriteFloat("Float", (float)value);
					return;
				case BuiltInType.Double:
					WriteDouble("Double", (double)value);
					return;
				case BuiltInType.String:
					WriteString("String", (string)value);
					return;
				case BuiltInType.DateTime:
					WriteDateTime("DateTime", (DateTime)value);
					return;
				case BuiltInType.Guid:
					WriteGuid("Guid", (Uuid)value);
					return;
				case BuiltInType.ByteString:
					WriteByteString("ByteString", (byte[])value);
					return;
				case BuiltInType.XmlElement:
					WriteXmlElement("XmlElement", (XmlElement)value);
					return;
				case BuiltInType.NodeId:
					WriteNodeId("NodeId", (NodeId)value);
					return;
				case BuiltInType.ExpandedNodeId:
					WriteExpandedNodeId("ExpandedNodeId", (ExpandedNodeId)value);
					return;
				case BuiltInType.StatusCode:
					WriteStatusCode("StatusCode", (StatusCode)value);
					return;
				case BuiltInType.QualifiedName:
					WriteQualifiedName("QualifiedName", (QualifiedName)value);
					return;
				case BuiltInType.LocalizedText:
					WriteLocalizedText("LocalizedText", (LocalizedText)value);
					return;
				case BuiltInType.ExtensionObject:
					WriteExtensionObject("ExtensionObject", (ExtensionObject)value);
					return;
				case BuiltInType.DataValue:
					WriteDataValue("DataValue", (DataValue)value);
					return;
				case BuiltInType.Enumeration:
					WriteInt32("Int32", (int)value);
					return;
				}
			}
			else if (typeInfo.ValueRank <= 1)
			{
				switch (typeInfo.BuiltInType)
				{
				case BuiltInType.Boolean:
					WriteBooleanArray("ListOfBoolean", (bool[])value);
					return;
				case BuiltInType.SByte:
					WriteSByteArray("ListOfSByte", (sbyte[])value);
					return;
				case BuiltInType.Byte:
					WriteByteArray("ListOfByte", (byte[])value);
					return;
				case BuiltInType.Int16:
					WriteInt16Array("ListOfInt16", (short[])value);
					return;
				case BuiltInType.UInt16:
					WriteUInt16Array("ListOfUInt16", (ushort[])value);
					return;
				case BuiltInType.Int32:
					WriteInt32Array("ListOfInt32", (int[])value);
					return;
				case BuiltInType.UInt32:
					WriteUInt32Array("ListOfUInt32", (uint[])value);
					return;
				case BuiltInType.Int64:
					WriteInt64Array("ListOfInt64", (long[])value);
					return;
				case BuiltInType.UInt64:
					WriteUInt64Array("ListOfUInt64", (ulong[])value);
					return;
				case BuiltInType.Float:
					WriteFloatArray("ListOfFloat", (float[])value);
					return;
				case BuiltInType.Double:
					WriteDoubleArray("ListOfDouble", (double[])value);
					return;
				case BuiltInType.String:
					WriteStringArray("ListOfString", (string[])value);
					return;
				case BuiltInType.DateTime:
					WriteDateTimeArray("ListOfDateTime", (DateTime[])value);
					return;
				case BuiltInType.Guid:
					WriteGuidArray("ListOfGuid", (Uuid[])value);
					return;
				case BuiltInType.ByteString:
					WriteByteStringArray("ListOfByteString", (byte[][])value);
					return;
				case BuiltInType.XmlElement:
					WriteXmlElementArray("ListOfXmlElement", (XmlElement[])value);
					return;
				case BuiltInType.NodeId:
					WriteNodeIdArray("ListOfNodeId", (NodeId[])value);
					return;
				case BuiltInType.ExpandedNodeId:
					WriteExpandedNodeIdArray("ListOfExpandedNodeId", (ExpandedNodeId[])value);
					return;
				case BuiltInType.StatusCode:
					WriteStatusCodeArray("ListOfStatusCode", (StatusCode[])value);
					return;
				case BuiltInType.QualifiedName:
					WriteQualifiedNameArray("ListOfQualifiedName", (QualifiedName[])value);
					return;
				case BuiltInType.LocalizedText:
					WriteLocalizedTextArray("ListOfLocalizedText", (LocalizedText[])value);
					return;
				case BuiltInType.ExtensionObject:
					WriteExtensionObjectArray("ListOfExtensionObject", (ExtensionObject[])value);
					return;
				case BuiltInType.DataValue:
					WriteDataValueArray("ListOfDataValue", (DataValue[])value);
					return;
				case BuiltInType.Enumeration:
				{
					int[] array = value as int[];
					if (array == null)
					{
						if (!(value is Enum[] array2))
						{
							throw new ServiceResultException(2147876864u, Utils.Format("Type '{0}' is not allowed in an Enumeration.", value.GetType().FullName));
						}
						array = new int[array2.Length];
						for (int i = 0; i < array2.Length; i++)
						{
							array[i] = (int)(object)array2[i];
						}
					}
					WriteInt32Array("ListOfInt32", array);
					return;
				}
				case BuiltInType.Variant:
					if (value is Variant[] values)
					{
						WriteVariantArray("ListOfVariant", values);
						return;
					}
					if (value is object[] values2)
					{
						WriteObjectArray("ListOfVariant", values2);
						return;
					}
					throw ServiceResultException.Create(2147876864u, "Unexpected type encountered while encoding an array of Variants: {0}", value.GetType());
				}
			}
			else if (typeInfo.ValueRank > 1)
			{
				WriteMatrix("Matrix", (Matrix)value);
				return;
			}
			throw new ServiceResultException(2147876864u, Utils.Format("Type '{0}' is not allowed in an Variant.", value.GetType().FullName));
		}
		finally
		{
			PopNamespace();
		}
	}

	public void WriteExtensionObjectBody(object body)
	{
		if (body == null)
		{
			return;
		}
		if (body is byte[] inArray)
		{
			m_writer.WriteStartElement("ByteString", "http://opcfoundation.org/UA/2008/02/Types.xsd");
			m_writer.WriteString(Convert.ToBase64String(inArray, Base64FormattingOptions.InsertLineBreaks));
			m_writer.WriteEndElement();
			return;
		}
		if (body is XmlElement xmlElement)
		{
			using XmlReader reader = XmlReader.Create(new StringReader(xmlElement.OuterXml), Utils.DefaultXmlReaderSettings());
			m_writer.WriteNode(reader, defattr: false);
			return;
		}
		if (!(body is IEncodeable encodeable))
		{
			throw new ServiceResultException(2147876864u, Utils.Format("Don't know how to encode extension object body with type '{0}'.", body.GetType().FullName));
		}
		XmlQualifiedName xmlName = EncodeableFactory.GetXmlName(encodeable, Context);
		m_writer.WriteStartElement(xmlName.Name, xmlName.Namespace);
		encodeable.Encode(this);
		m_writer.WriteEndElement();
	}

	public void WriteObjectArray(string fieldName, IList<object> values)
	{
		if (!BeginField(fieldName, values == null, isNillable: true, isArrayElement: true))
		{
			return;
		}
		if (values != null && m_context.MaxArrayLength > 0 && m_context.MaxArrayLength < values.Count)
		{
			throw new ServiceResultException(2148007936u);
		}
		PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		if (values != null)
		{
			for (int i = 0; i < values.Count; i++)
			{
				WriteVariant("Variant", new Variant(values[i]));
			}
		}
		PopNamespace();
		EndField(fieldName);
	}

	public void WriteArray(string fieldName, object array, int valueRank, BuiltInType builtInType)
	{
		CheckAndIncrementNestingLevel();
		try
		{
			if (valueRank == 1)
			{
				switch (builtInType)
				{
				case BuiltInType.Boolean:
					WriteBooleanArray(fieldName, (bool[])array);
					break;
				case BuiltInType.SByte:
					WriteSByteArray(fieldName, (sbyte[])array);
					break;
				case BuiltInType.Byte:
					WriteByteArray(fieldName, (byte[])array);
					break;
				case BuiltInType.Int16:
					WriteInt16Array(fieldName, (short[])array);
					break;
				case BuiltInType.UInt16:
					WriteUInt16Array(fieldName, (ushort[])array);
					break;
				case BuiltInType.Int32:
					WriteInt32Array(fieldName, (int[])array);
					break;
				case BuiltInType.UInt32:
					WriteUInt32Array(fieldName, (uint[])array);
					break;
				case BuiltInType.Int64:
					WriteInt64Array(fieldName, (long[])array);
					break;
				case BuiltInType.UInt64:
					WriteUInt64Array(fieldName, (ulong[])array);
					break;
				case BuiltInType.Float:
					WriteFloatArray(fieldName, (float[])array);
					break;
				case BuiltInType.Double:
					WriteDoubleArray(fieldName, (double[])array);
					break;
				case BuiltInType.String:
					WriteStringArray(fieldName, (string[])array);
					break;
				case BuiltInType.DateTime:
					WriteDateTimeArray(fieldName, (DateTime[])array);
					break;
				case BuiltInType.Guid:
					WriteGuidArray(fieldName, (Uuid[])array);
					break;
				case BuiltInType.ByteString:
					WriteByteStringArray(fieldName, (byte[][])array);
					break;
				case BuiltInType.XmlElement:
					WriteXmlElementArray(fieldName, (XmlElement[])array);
					break;
				case BuiltInType.NodeId:
					WriteNodeIdArray(fieldName, (NodeId[])array);
					break;
				case BuiltInType.ExpandedNodeId:
					WriteExpandedNodeIdArray(fieldName, (ExpandedNodeId[])array);
					break;
				case BuiltInType.StatusCode:
					WriteStatusCodeArray(fieldName, (StatusCode[])array);
					break;
				case BuiltInType.QualifiedName:
					WriteQualifiedNameArray(fieldName, (QualifiedName[])array);
					break;
				case BuiltInType.LocalizedText:
					WriteLocalizedTextArray(fieldName, (LocalizedText[])array);
					break;
				case BuiltInType.ExtensionObject:
					WriteExtensionObjectArray(fieldName, (ExtensionObject[])array);
					break;
				case BuiltInType.DataValue:
					WriteDataValueArray(fieldName, (DataValue[])array);
					break;
				case BuiltInType.DiagnosticInfo:
					WriteDiagnosticInfoArray(fieldName, (DiagnosticInfo[])array);
					break;
				case BuiltInType.Enumeration:
				{
					int[] array2 = array as int[];
					if (array2 == null)
					{
						if (!(array is Enum[] array3))
						{
							throw new ServiceResultException(2147876864u, Utils.Format("Type '{0}' is not allowed in an Enumeration.", array.GetType().FullName));
						}
						array2 = new int[array3.Length];
						for (int i = 0; i < array3.Length; i++)
						{
							array2[i] = Convert.ToInt32(array3[i], CultureInfo.InvariantCulture);
						}
					}
					WriteInt32Array(fieldName, array2);
					break;
				}
				case BuiltInType.Variant:
					if (array is Variant[] values2)
					{
						WriteVariantArray(fieldName, values2);
						break;
					}
					if (array is IEncodeable[] values3)
					{
						WriteEncodeableArray(fieldName, values3, array.GetType().GetElementType());
						break;
					}
					if (array is object[] values4)
					{
						WriteObjectArray(fieldName, values4);
						break;
					}
					throw ServiceResultException.Create(2147876864u, "Unexpected type encountered while encoding an array of Variants: {0}", array.GetType());
				default:
					if (array is IEncodeable[] values)
					{
						WriteEncodeableArray(fieldName, values, array.GetType().GetElementType());
						break;
					}
					throw ServiceResultException.Create(2147876864u, "Unexpected BuiltInType encountered while encoding an array: {0}", builtInType);
				}
			}
			else
			{
				if (valueRank <= 1)
				{
					return;
				}
				Matrix matrix = array as Matrix;
				if (matrix == null)
				{
					if (!(array is Array array4) || array4.Rank != valueRank)
					{
						throw ServiceResultException.Create(2147876864u, "Unexpected array type encountered while encoding array: {0}", array.GetType().Name);
					}
					matrix = new Matrix(array4, builtInType);
				}
				if (BeginField(fieldName, matrix == null, isNillable: true, isArrayElement: true))
				{
					PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
					if (matrix != null)
					{
						WriteInt32Array("Dimensions", matrix.Dimensions);
						WriteArray("Elements", matrix.Elements, 1, builtInType);
					}
					PopNamespace();
					EndField(fieldName);
				}
			}
		}
		finally
		{
			m_nestingLevel--;
		}
	}

	private void WriteMatrix(string fieldName, Matrix value)
	{
		CheckAndIncrementNestingLevel();
		if (BeginField(fieldName, value == null, isNillable: true, isArrayElement: true))
		{
			PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
			if (value != null)
			{
				m_writer.WriteStartElement("Elements", "http://opcfoundation.org/UA/2008/02/Types.xsd");
				WriteVariantContents(value.Elements, new TypeInfo(value.TypeInfo.BuiltInType, 1));
				m_writer.WriteEndElement();
				WriteInt32Array("Dimensions", value.Dimensions);
			}
			PopNamespace();
			EndField(fieldName);
		}
		m_nestingLevel--;
	}

	private bool BeginField(string fieldName, bool isDefault, bool isNillable, bool isArrayElement = false)
	{
		if (!string.IsNullOrEmpty(fieldName))
		{
			if (isNillable && isDefault && !isArrayElement)
			{
				return false;
			}
			m_writer.WriteStartElement(fieldName, m_namespaces.Peek());
			if (isDefault)
			{
				if (isNillable)
				{
					m_writer.WriteAttributeString("nil", "http://www.w3.org/2001/XMLSchema-instance", "true");
				}
				m_writer.WriteEndElement();
				return false;
			}
		}
		return !isDefault;
	}

	private void EndField(string fieldName)
	{
		if (!string.IsNullOrEmpty(fieldName))
		{
			m_writer.WriteEndElement();
		}
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
