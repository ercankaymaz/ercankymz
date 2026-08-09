using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;

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

	public int Position => (int)m_reader.BaseStream.Position;

	public Stream BaseStream => m_reader.BaseStream;

	public EncodingType EncodingType => EncodingType.Binary;

	public IServiceMessageContext Context => m_context;

	public BinaryDecoder(byte[] buffer, IServiceMessageContext context)
		: this(buffer, 0, buffer.Length, context)
	{
	}

	public BinaryDecoder(byte[] buffer, int start, int count, IServiceMessageContext context)
	{
		m_istrm = new MemoryStream(buffer, start, count, writable: false);
		m_reader = new BinaryReader(m_istrm);
		m_context = context;
		m_nestingLevel = 0u;
	}

	public BinaryDecoder(Stream stream, IServiceMessageContext context)
	{
		if (stream == null)
		{
			throw new ArgumentNullException("stream");
		}
		m_istrm = stream;
		m_reader = new BinaryReader(m_istrm);
		m_context = context;
		m_nestingLevel = 0u;
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (disposing)
		{
			if (m_reader != null)
			{
				m_reader.Dispose();
			}
			if (m_istrm != null)
			{
				m_istrm.Dispose();
			}
		}
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

	public void Close()
	{
		m_reader.Dispose();
	}

	public static IEncodeable DecodeMessage(Stream stream, Type expectedType, IServiceMessageContext context)
	{
		if (stream == null)
		{
			throw new ArgumentNullException("stream");
		}
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		BinaryDecoder binaryDecoder = new BinaryDecoder(stream, context);
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
		{
			throw new ArgumentNullException("buffer");
		}
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		BinaryDecoder binaryDecoder = new BinaryDecoder(buffer, context);
		try
		{
			ExpandedNodeId expandedNodeId = NodeId.ToExpandedNodeId(binaryDecoder.ReadNodeId(null), context.NamespaceUris);
			Type systemType = context.Factory.GetSystemType(expandedNodeId);
			if (systemType == null || systemType != typeof(SessionlessInvokeRequestType))
			{
				throw new ServiceResultException(2147942400u, Utils.Format("Cannot decode session-less service message with type id: {0}.", expandedNodeId));
			}
			SessionLessServiceMessage sessionLessServiceMessage = new SessionLessServiceMessage();
			sessionLessServiceMessage.Decode(binaryDecoder);
			return sessionLessServiceMessage.Message;
		}
		finally
		{
			binaryDecoder.Close();
		}
	}

	public static IEncodeable DecodeMessage(byte[] buffer, Type expectedType, IServiceMessageContext context)
	{
		if (buffer == null)
		{
			throw new ArgumentNullException("buffer");
		}
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		BinaryDecoder binaryDecoder = new BinaryDecoder(buffer, context);
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
		long position = m_istrm.Position;
		ExpandedNodeId expandedNodeId = NodeId.ToExpandedNodeId(ReadNodeId(null), m_context.NamespaceUris);
		Type systemType = m_context.Factory.GetSystemType(expandedNodeId);
		if (systemType == null)
		{
			throw new ServiceResultException(2147942400u, Utils.Format("Cannot decode message with type id: {0}.", expandedNodeId));
		}
		IEncodeable result = ReadEncodeable(null, systemType, expandedNodeId);
		if (m_context.MaxMessageSize > 0 && m_context.MaxMessageSize < (int)(m_istrm.Position - position))
		{
			throw ServiceResultException.Create(2148007936u, "MaxMessageSize {0} < {1}", m_context.MaxMessageSize, (int)(m_istrm.Position - position));
		}
		return result;
	}

	public bool LoadStringTable(StringTable stringTable)
	{
		int num = ReadInt32(null);
		if (num < 0)
		{
			return false;
		}
		for (uint num2 = 0u; num2 < num; num2++)
		{
			stringTable.Append(ReadString(null));
		}
		return true;
	}

	public void PushNamespace(string namespaceUri)
	{
	}

	public void PopNamespace()
	{
	}

	public bool ReadBoolean(string fieldName)
	{
		return m_reader.ReadBoolean();
	}

	public sbyte ReadSByte(string fieldName)
	{
		return m_reader.ReadSByte();
	}

	public byte ReadByte(string fieldName)
	{
		return m_reader.ReadByte();
	}

	public short ReadInt16(string fieldName)
	{
		return m_reader.ReadInt16();
	}

	public ushort ReadUInt16(string fieldName)
	{
		return m_reader.ReadUInt16();
	}

	public int ReadInt32(string fieldName)
	{
		return m_reader.ReadInt32();
	}

	public uint ReadUInt32(string fieldName)
	{
		return m_reader.ReadUInt32();
	}

	public long ReadInt64(string fieldName)
	{
		return m_reader.ReadInt64();
	}

	public ulong ReadUInt64(string fieldName)
	{
		return m_reader.ReadUInt64();
	}

	public float ReadFloat(string fieldName)
	{
		return m_reader.ReadSingle();
	}

	public double ReadDouble(string fieldName)
	{
		return m_reader.ReadDouble();
	}

	public string ReadString(string fieldName)
	{
		return ReadString(fieldName, m_context.MaxStringLength);
	}

	public string ReadString(string fieldName, int maxStringLength)
	{
		int num = m_reader.ReadInt32();
		if (num < 0)
		{
			return null;
		}
		if (num == 0)
		{
			return string.Empty;
		}
		if (maxStringLength > 0 && maxStringLength < num)
		{
			throw ServiceResultException.Create(2148007936u, "MaxStringLength {0} < {1}", maxStringLength, num);
		}
		byte[] array = m_reader.ReadBytes(num);
		int count = ((array[array.Length - 1] == 0) ? (array.Length - 1) : array.Length);
		return Encoding.UTF8.GetString(array, 0, count);
	}

	public DateTime ReadDateTime(string fieldName)
	{
		long num = m_reader.ReadInt64();
		if (num >= long.MaxValue - Utils.TimeBase.Ticks)
		{
			return DateTime.MaxValue;
		}
		num += Utils.TimeBase.Ticks;
		if (num >= DateTime.MaxValue.Ticks)
		{
			return DateTime.MaxValue;
		}
		if (num <= Utils.TimeBase.Ticks)
		{
			return DateTime.MinValue;
		}
		return new DateTime(num, DateTimeKind.Utc);
	}

	public Uuid ReadGuid(string fieldName)
	{
		return new Uuid(new Guid(m_reader.ReadBytes(16)));
	}

	public byte[] ReadByteString(string fieldName)
	{
		return ReadByteString(fieldName, m_context.MaxByteStringLength);
	}

	public byte[] ReadByteString(string fieldName, int maxByteStringLength)
	{
		int num = m_reader.ReadInt32();
		if (num < 0)
		{
			return null;
		}
		if (maxByteStringLength > 0 && maxByteStringLength < num)
		{
			throw ServiceResultException.Create(2148007936u, "MaxByteStringLength {0} < {1}", maxByteStringLength, num);
		}
		return m_reader.ReadBytes(num);
	}

	public XmlElement ReadXmlElement(string fieldName)
	{
		byte[] array = ReadByteString(fieldName);
		if (array == null || array.Length == 0)
		{
			return null;
		}
		XmlDocument xmlDocument = new XmlDocument();
		try
		{
			int count = ((array[array.Length - 1] == 0) ? (array.Length - 1) : array.Length);
			using StringReader input = new StringReader(Encoding.UTF8.GetString(array, 0, count));
			using XmlReader reader = XmlReader.Create(input, Utils.DefaultXmlReaderSettings());
			xmlDocument.Load(reader);
		}
		catch (XmlException)
		{
			return null;
		}
		return xmlDocument.DocumentElement;
	}

	public NodeId ReadNodeId(string fieldName)
	{
		byte encodingByte = m_reader.ReadByte();
		NodeId nodeId = new NodeId();
		ReadNodeIdBody(encodingByte, nodeId);
		if (m_namespaceMappings != null && m_namespaceMappings.Length > nodeId.NamespaceIndex)
		{
			nodeId.SetNamespaceIndex(m_namespaceMappings[nodeId.NamespaceIndex]);
		}
		return nodeId;
	}

	public ExpandedNodeId ReadExpandedNodeId(string fieldName)
	{
		byte b = m_reader.ReadByte();
		ExpandedNodeId expandedNodeId = new ExpandedNodeId();
		NodeId nodeId = new NodeId();
		ReadNodeIdBody(b, nodeId);
		expandedNodeId.InnerNodeId = nodeId;
		string text = null;
		uint num = 0u;
		if ((b & 0x80) != 0)
		{
			text = ReadString(null);
			expandedNodeId.SetNamespaceUri(text);
		}
		if ((b & 0x40) != 0)
		{
			num = ReadUInt32(null);
			expandedNodeId.SetServerIndex(num);
		}
		if (m_namespaceMappings != null && m_namespaceMappings.Length > expandedNodeId.NamespaceIndex)
		{
			expandedNodeId.SetNamespaceIndex(m_namespaceMappings[expandedNodeId.NamespaceIndex]);
		}
		if (m_serverMappings != null && m_serverMappings.Length > expandedNodeId.ServerIndex)
		{
			expandedNodeId.SetServerIndex(m_serverMappings[expandedNodeId.NamespaceIndex]);
		}
		return expandedNodeId;
	}

	public StatusCode ReadStatusCode(string fieldName)
	{
		return m_reader.ReadUInt32();
	}

	public DiagnosticInfo ReadDiagnosticInfo(string fieldName)
	{
		return ReadDiagnosticInfo(fieldName, 0);
	}

	public QualifiedName ReadQualifiedName(string fieldName)
	{
		ushort num = ReadUInt16(null);
		string name = ReadString(null);
		if (m_namespaceMappings != null && m_namespaceMappings.Length > num)
		{
			num = m_namespaceMappings[num];
		}
		return new QualifiedName(name, num);
	}

	public LocalizedText ReadLocalizedText(string fieldName)
	{
		byte num = m_reader.ReadByte();
		string text = null;
		string locale = null;
		if ((num & 1) != 0)
		{
			locale = ReadString(null);
		}
		if ((num & 2) != 0)
		{
			text = ReadString(null);
		}
		return new LocalizedText(locale, text);
	}

	public Variant ReadVariant(string fieldName)
	{
		CheckAndIncrementNestingLevel();
		try
		{
			return ReadVariantValue(fieldName);
		}
		finally
		{
			m_nestingLevel--;
		}
	}

	public DataValue ReadDataValue(string fieldName)
	{
		byte num = m_reader.ReadByte();
		DataValue dataValue = new DataValue();
		if ((num & 1) != 0)
		{
			dataValue.WrappedValue = ReadVariant(null);
		}
		if ((num & 2) != 0)
		{
			dataValue.StatusCode = ReadStatusCode(null);
		}
		if ((num & 4) != 0)
		{
			dataValue.SourceTimestamp = ReadDateTime(null);
		}
		if ((num & 0x10) != 0)
		{
			dataValue.SourcePicoseconds = ReadUInt16(null);
		}
		if ((num & 8) != 0)
		{
			dataValue.ServerTimestamp = ReadDateTime(null);
		}
		if ((num & 0x20) != 0)
		{
			dataValue.ServerPicoseconds = ReadUInt16(null);
		}
		return dataValue;
	}

	public ExtensionObject ReadExtensionObject(string fieldName)
	{
		return ReadExtensionObject();
	}

	public IEncodeable ReadEncodeable(string fieldName, Type systemType, ExpandedNodeId encodeableTypeId = null)
	{
		if (systemType == null)
		{
			throw new ArgumentNullException("systemType");
		}
		if (!(Activator.CreateInstance(systemType) is IEncodeable encodeable))
		{
			throw new ServiceResultException(2147942400u, Utils.Format("Cannot decode type '{0}'.", systemType.FullName));
		}
		if (encodeableTypeId != null && encodeable is IComplexTypeInstance complexTypeInstance)
		{
			complexTypeInstance.TypeId = encodeableTypeId;
		}
		CheckAndIncrementNestingLevel();
		try
		{
			encodeable.Decode(this);
			return encodeable;
		}
		finally
		{
			m_nestingLevel--;
		}
	}

	public Enum ReadEnumerated(string fieldName, Type enumType)
	{
		return (Enum)Enum.ToObject(enumType, m_reader.ReadInt32());
	}

	public BooleanCollection ReadBooleanArray(string fieldName)
	{
		int num = ReadArrayLength();
		if (num == -1)
		{
			return null;
		}
		BooleanCollection booleanCollection = new BooleanCollection(num);
		for (int i = 0; i < num; i++)
		{
			booleanCollection.Add(ReadBoolean(null));
		}
		return booleanCollection;
	}

	public SByteCollection ReadSByteArray(string fieldName)
	{
		int num = ReadArrayLength();
		if (num == -1)
		{
			return null;
		}
		SByteCollection sByteCollection = new SByteCollection(num);
		for (int i = 0; i < num; i++)
		{
			sByteCollection.Add(ReadSByte(null));
		}
		return sByteCollection;
	}

	public ByteCollection ReadByteArray(string fieldName)
	{
		int num = ReadArrayLength();
		if (num == -1)
		{
			return null;
		}
		ByteCollection byteCollection = new ByteCollection(num);
		for (int i = 0; i < num; i++)
		{
			byteCollection.Add(ReadByte(null));
		}
		return byteCollection;
	}

	public Int16Collection ReadInt16Array(string fieldName)
	{
		int num = ReadArrayLength();
		if (num == -1)
		{
			return null;
		}
		Int16Collection int16Collection = new Int16Collection(num);
		for (int i = 0; i < num; i++)
		{
			int16Collection.Add(ReadInt16(null));
		}
		return int16Collection;
	}

	public UInt16Collection ReadUInt16Array(string fieldName)
	{
		int num = ReadArrayLength();
		if (num == -1)
		{
			return null;
		}
		UInt16Collection uInt16Collection = new UInt16Collection(num);
		for (int i = 0; i < num; i++)
		{
			uInt16Collection.Add(ReadUInt16(null));
		}
		return uInt16Collection;
	}

	public Int32Collection ReadInt32Array(string fieldName)
	{
		int num = ReadArrayLength();
		if (num == -1)
		{
			return null;
		}
		Int32Collection int32Collection = new Int32Collection(num);
		for (int i = 0; i < num; i++)
		{
			int32Collection.Add(ReadInt32(null));
		}
		return int32Collection;
	}

	public UInt32Collection ReadUInt32Array(string fieldName)
	{
		int num = ReadArrayLength();
		if (num == -1)
		{
			return null;
		}
		UInt32Collection uInt32Collection = new UInt32Collection(num);
		for (int i = 0; i < num; i++)
		{
			uInt32Collection.Add(ReadUInt32(null));
		}
		return uInt32Collection;
	}

	public Int64Collection ReadInt64Array(string fieldName)
	{
		int num = ReadArrayLength();
		if (num == -1)
		{
			return null;
		}
		Int64Collection int64Collection = new Int64Collection(num);
		for (int i = 0; i < num; i++)
		{
			int64Collection.Add(ReadInt64(null));
		}
		return int64Collection;
	}

	public UInt64Collection ReadUInt64Array(string fieldName)
	{
		int num = ReadArrayLength();
		if (num == -1)
		{
			return null;
		}
		UInt64Collection uInt64Collection = new UInt64Collection(num);
		for (int i = 0; i < num; i++)
		{
			uInt64Collection.Add(ReadUInt64(null));
		}
		return uInt64Collection;
	}

	public FloatCollection ReadFloatArray(string fieldName)
	{
		int num = ReadArrayLength();
		if (num == -1)
		{
			return null;
		}
		FloatCollection floatCollection = new FloatCollection(num);
		for (int i = 0; i < num; i++)
		{
			floatCollection.Add(ReadFloat(null));
		}
		return floatCollection;
	}

	public DoubleCollection ReadDoubleArray(string fieldName)
	{
		int num = ReadArrayLength();
		if (num == -1)
		{
			return null;
		}
		DoubleCollection doubleCollection = new DoubleCollection(num);
		for (int i = 0; i < num; i++)
		{
			doubleCollection.Add(ReadDouble(null));
		}
		return doubleCollection;
	}

	public StringCollection ReadStringArray(string fieldName)
	{
		int num = ReadArrayLength();
		if (num == -1)
		{
			return null;
		}
		StringCollection stringCollection = new StringCollection(num);
		for (int i = 0; i < num; i++)
		{
			stringCollection.Add(ReadString(null));
		}
		return stringCollection;
	}

	public DateTimeCollection ReadDateTimeArray(string fieldName)
	{
		int num = ReadArrayLength();
		if (num == -1)
		{
			return null;
		}
		DateTimeCollection dateTimeCollection = new DateTimeCollection(num);
		for (int i = 0; i < num; i++)
		{
			dateTimeCollection.Add(ReadDateTime(null));
		}
		return dateTimeCollection;
	}

	public UuidCollection ReadGuidArray(string fieldName)
	{
		int num = ReadArrayLength();
		if (num == -1)
		{
			return null;
		}
		UuidCollection uuidCollection = new UuidCollection(num);
		for (int i = 0; i < num; i++)
		{
			uuidCollection.Add(ReadGuid(null));
		}
		return uuidCollection;
	}

	public ByteStringCollection ReadByteStringArray(string fieldName)
	{
		int num = ReadArrayLength();
		if (num == -1)
		{
			return null;
		}
		ByteStringCollection byteStringCollection = new ByteStringCollection(num);
		for (int i = 0; i < num; i++)
		{
			byteStringCollection.Add(ReadByteString(null));
		}
		return byteStringCollection;
	}

	public XmlElementCollection ReadXmlElementArray(string fieldName)
	{
		int num = ReadArrayLength();
		if (num == -1)
		{
			return null;
		}
		XmlElementCollection xmlElementCollection = new XmlElementCollection(num);
		for (int i = 0; i < num; i++)
		{
			xmlElementCollection.Add(ReadXmlElement(null));
		}
		return xmlElementCollection;
	}

	public NodeIdCollection ReadNodeIdArray(string fieldName)
	{
		int num = ReadArrayLength();
		if (num == -1)
		{
			return null;
		}
		NodeIdCollection nodeIdCollection = new NodeIdCollection(num);
		for (int i = 0; i < num; i++)
		{
			nodeIdCollection.Add(ReadNodeId(null));
		}
		return nodeIdCollection;
	}

	public ExpandedNodeIdCollection ReadExpandedNodeIdArray(string fieldName)
	{
		int num = ReadArrayLength();
		if (num == -1)
		{
			return null;
		}
		ExpandedNodeIdCollection expandedNodeIdCollection = new ExpandedNodeIdCollection(num);
		for (int i = 0; i < num; i++)
		{
			expandedNodeIdCollection.Add(ReadExpandedNodeId(null));
		}
		return expandedNodeIdCollection;
	}

	public StatusCodeCollection ReadStatusCodeArray(string fieldName)
	{
		int num = ReadArrayLength();
		if (num == -1)
		{
			return null;
		}
		StatusCodeCollection statusCodeCollection = new StatusCodeCollection(num);
		for (int i = 0; i < num; i++)
		{
			statusCodeCollection.Add(ReadStatusCode(null));
		}
		return statusCodeCollection;
	}

	public DiagnosticInfoCollection ReadDiagnosticInfoArray(string fieldName)
	{
		int num = ReadArrayLength();
		if (num == -1)
		{
			return null;
		}
		DiagnosticInfoCollection diagnosticInfoCollection = new DiagnosticInfoCollection(num);
		for (int i = 0; i < num; i++)
		{
			diagnosticInfoCollection.Add(ReadDiagnosticInfo(null));
		}
		return diagnosticInfoCollection;
	}

	public QualifiedNameCollection ReadQualifiedNameArray(string fieldName)
	{
		int num = ReadArrayLength();
		if (num == -1)
		{
			return null;
		}
		QualifiedNameCollection qualifiedNameCollection = new QualifiedNameCollection(num);
		for (int i = 0; i < num; i++)
		{
			qualifiedNameCollection.Add(ReadQualifiedName(null));
		}
		return qualifiedNameCollection;
	}

	public LocalizedTextCollection ReadLocalizedTextArray(string fieldName)
	{
		int num = ReadArrayLength();
		if (num == -1)
		{
			return null;
		}
		LocalizedTextCollection localizedTextCollection = new LocalizedTextCollection(num);
		for (int i = 0; i < num; i++)
		{
			localizedTextCollection.Add(ReadLocalizedText(null));
		}
		return localizedTextCollection;
	}

	public VariantCollection ReadVariantArray(string fieldName)
	{
		int num = ReadArrayLength();
		if (num == -1)
		{
			return null;
		}
		VariantCollection variantCollection = new VariantCollection(num);
		for (int i = 0; i < num; i++)
		{
			variantCollection.Add(ReadVariant(null));
		}
		return variantCollection;
	}

	public DataValueCollection ReadDataValueArray(string fieldName)
	{
		int num = ReadArrayLength();
		if (num == -1)
		{
			return null;
		}
		DataValueCollection dataValueCollection = new DataValueCollection(num);
		for (int i = 0; i < num; i++)
		{
			dataValueCollection.Add(ReadDataValue(null));
		}
		return dataValueCollection;
	}

	public ExtensionObjectCollection ReadExtensionObjectArray(string fieldName)
	{
		int num = ReadArrayLength();
		if (num == -1)
		{
			return null;
		}
		ExtensionObjectCollection extensionObjectCollection = new ExtensionObjectCollection(num);
		for (int i = 0; i < num; i++)
		{
			extensionObjectCollection.Add(ReadExtensionObject(null));
		}
		return extensionObjectCollection;
	}

	public Array ReadEncodeableArray(string fieldName, Type systemType, ExpandedNodeId encodeableTypeId = null)
	{
		int num = ReadArrayLength();
		if (num == -1)
		{
			return null;
		}
		Array array = Array.CreateInstance(systemType, num);
		for (int i = 0; i < num; i++)
		{
			array.SetValue(ReadEncodeable(null, systemType, encodeableTypeId), i);
		}
		return array;
	}

	public Array ReadEnumeratedArray(string fieldName, Type enumType)
	{
		int num = ReadArrayLength();
		if (num == -1)
		{
			return null;
		}
		Array array = Array.CreateInstance(enumType, num);
		for (int i = 0; i < num; i++)
		{
			array.SetValue(ReadEnumerated(null, enumType), i);
		}
		return array;
	}

	public Array ReadArray(string fieldName, int valueRank, BuiltInType builtInType, Type systemType = null, ExpandedNodeId encodeableTypeId = null)
	{
		if (valueRank == 1)
		{
			switch (builtInType)
			{
			case BuiltInType.Boolean:
				return ReadBooleanArray(fieldName).ToArray();
			case BuiltInType.SByte:
				return ReadSByteArray(fieldName).ToArray();
			case BuiltInType.Byte:
				return ReadByteArray(fieldName).ToArray();
			case BuiltInType.Int16:
				return ReadInt16Array(fieldName).ToArray();
			case BuiltInType.UInt16:
				return ReadUInt16Array(fieldName).ToArray();
			case BuiltInType.Enumeration:
				DetermineIEncodeableSystemType(ref systemType, encodeableTypeId);
				if ((object)systemType != null && systemType.IsEnum)
				{
					return ReadEnumeratedArray(fieldName, systemType);
				}
				goto case BuiltInType.Int32;
			case BuiltInType.Int32:
				return ReadInt32Array(fieldName).ToArray();
			case BuiltInType.UInt32:
				return ReadUInt32Array(fieldName).ToArray();
			case BuiltInType.Int64:
				return ReadInt64Array(fieldName).ToArray();
			case BuiltInType.UInt64:
				return ReadUInt64Array(fieldName).ToArray();
			case BuiltInType.Float:
				return ReadFloatArray(fieldName).ToArray();
			case BuiltInType.Double:
				return ReadDoubleArray(fieldName).ToArray();
			case BuiltInType.String:
				return ReadStringArray(fieldName).ToArray();
			case BuiltInType.DateTime:
				return ReadDateTimeArray(fieldName).ToArray();
			case BuiltInType.Guid:
				return ReadGuidArray(fieldName).ToArray();
			case BuiltInType.ByteString:
				return ReadByteStringArray(fieldName).ToArray();
			case BuiltInType.XmlElement:
				return ReadXmlElementArray(fieldName).ToArray();
			case BuiltInType.NodeId:
				return ReadNodeIdArray(fieldName).ToArray();
			case BuiltInType.ExpandedNodeId:
				return ReadExpandedNodeIdArray(fieldName).ToArray();
			case BuiltInType.StatusCode:
				return ReadStatusCodeArray(fieldName).ToArray();
			case BuiltInType.QualifiedName:
				return ReadQualifiedNameArray(fieldName).ToArray();
			case BuiltInType.LocalizedText:
				return ReadLocalizedTextArray(fieldName).ToArray();
			case BuiltInType.DataValue:
				return ReadDataValueArray(fieldName).ToArray();
			case BuiltInType.Variant:
				if (DetermineIEncodeableSystemType(ref systemType, encodeableTypeId))
				{
					return ReadEncodeableArray(fieldName, systemType, encodeableTypeId);
				}
				return ReadVariantArray(fieldName).ToArray();
			case BuiltInType.ExtensionObject:
				return ReadExtensionObjectArray(fieldName).ToArray();
			case BuiltInType.DiagnosticInfo:
				return ReadDiagnosticInfoArray(fieldName).ToArray();
			default:
				if (DetermineIEncodeableSystemType(ref systemType, encodeableTypeId))
				{
					return ReadEncodeableArray(fieldName, systemType, encodeableTypeId);
				}
				throw new ServiceResultException(2147942400u, Utils.Format("Cannot decode unknown type in Array object with BuiltInType: {0}.", builtInType));
			}
		}
		if (valueRank >= 2)
		{
			Int32Collection int32Collection = ReadInt32Array(null);
			if (int32Collection != null && int32Collection.Count > 0)
			{
				int item = Matrix.ValidateDimensions(allowZeroDimension: false, int32Collection, Context.MaxArrayLength).flatLength;
				Array array = null;
				if (DetermineIEncodeableSystemType(ref systemType, encodeableTypeId))
				{
					array = Array.CreateInstance(systemType, item);
					for (int i = 0; i < item; i++)
					{
						IEncodeable value = ReadEncodeable(null, systemType, encodeableTypeId);
						array.SetValue(Convert.ChangeType(value, systemType), i);
					}
				}
				if (array == null)
				{
					array = ReadArrayElements(item, builtInType);
				}
				if (array == null)
				{
					throw ServiceResultException.Create(2147942400u, "Unexpected null Array for multidimensional matrix with {0} elements.", item);
				}
				if (builtInType == BuiltInType.Enumeration && (object)systemType != null && systemType.IsEnum)
				{
					Array array2 = Array.CreateInstance(systemType, array.Length);
					int num = 0;
					foreach (object item2 in array)
					{
						array2.SetValue(Enum.ToObject(systemType, item2), num++);
					}
					array = array2;
				}
				return new Matrix(array, builtInType, int32Collection.ToArray()).ToArray();
			}
			throw ServiceResultException.Create(2147942400u, "Unexpected null or empty Dimensions for multidimensional matrix.");
		}
		return null;
	}

	private DiagnosticInfo ReadDiagnosticInfo(string fieldName, int depth)
	{
		if (depth >= DiagnosticInfo.MaxInnerDepth)
		{
			throw ServiceResultException.Create(2148007936u, "Maximum nesting level of InnerDiagnosticInfo was exceeded");
		}
		CheckAndIncrementNestingLevel();
		try
		{
			byte b = m_reader.ReadByte();
			if (b == 0)
			{
				return null;
			}
			DiagnosticInfo diagnosticInfo = new DiagnosticInfo();
			if ((b & 1) != 0)
			{
				diagnosticInfo.SymbolicId = ReadInt32(null);
			}
			if ((b & 2) != 0)
			{
				diagnosticInfo.NamespaceUri = ReadInt32(null);
			}
			if ((b & 8) != 0)
			{
				diagnosticInfo.Locale = ReadInt32(null);
			}
			if ((b & 4) != 0)
			{
				diagnosticInfo.LocalizedText = ReadInt32(null);
			}
			if ((b & 0x10) != 0)
			{
				diagnosticInfo.AdditionalInfo = ReadString(null);
			}
			if ((b & 0x20) != 0)
			{
				diagnosticInfo.InnerStatusCode = ReadStatusCode(null);
			}
			if ((b & 0x40) != 0)
			{
				diagnosticInfo.InnerDiagnosticInfo = ReadDiagnosticInfo(null, depth + 1);
			}
			return diagnosticInfo;
		}
		finally
		{
			m_nestingLevel--;
		}
	}

	private bool DetermineIEncodeableSystemType(ref Type systemType, ExpandedNodeId encodeableTypeId)
	{
		if (encodeableTypeId != null && systemType == null)
		{
			systemType = Context.Factory.GetSystemType(encodeableTypeId);
		}
		return typeof(IEncodeable).IsAssignableFrom(systemType);
	}

	private Array ReadArrayElements(int length, BuiltInType builtInType)
	{
		Array result = null;
		switch (builtInType)
		{
		case BuiltInType.Boolean:
		{
			bool[] array9 = new bool[length];
			for (int num3 = 0; num3 < array9.Length; num3++)
			{
				array9[num3] = ReadBoolean(null);
			}
			result = array9;
			break;
		}
		case BuiltInType.SByte:
		{
			sbyte[] array23 = new sbyte[length];
			for (int num17 = 0; num17 < array23.Length; num17++)
			{
				array23[num17] = ReadSByte(null);
			}
			result = array23;
			break;
		}
		case BuiltInType.Byte:
		{
			byte[] array12 = new byte[length];
			for (int num6 = 0; num6 < array12.Length; num6++)
			{
				array12[num6] = ReadByte(null);
			}
			result = array12;
			break;
		}
		case BuiltInType.Int16:
		{
			short[] array18 = new short[length];
			for (int num12 = 0; num12 < array18.Length; num12++)
			{
				array18[num12] = ReadInt16(null);
			}
			result = array18;
			break;
		}
		case BuiltInType.UInt16:
		{
			ushort[] array2 = new ushort[length];
			for (int j = 0; j < array2.Length; j++)
			{
				array2[j] = ReadUInt16(null);
			}
			result = array2;
			break;
		}
		case BuiltInType.Int32:
		case BuiltInType.Enumeration:
		{
			int[] array17 = new int[length];
			for (int num11 = 0; num11 < array17.Length; num11++)
			{
				array17[num11] = ReadInt32(null);
			}
			result = array17;
			break;
		}
		case BuiltInType.UInt32:
		{
			uint[] array3 = new uint[length];
			for (int k = 0; k < array3.Length; k++)
			{
				array3[k] = ReadUInt32(null);
			}
			result = array3;
			break;
		}
		case BuiltInType.Int64:
		{
			long[] array21 = new long[length];
			for (int num15 = 0; num15 < array21.Length; num15++)
			{
				array21[num15] = ReadInt64(null);
			}
			result = array21;
			break;
		}
		case BuiltInType.UInt64:
		{
			ulong[] array14 = new ulong[length];
			for (int num8 = 0; num8 < array14.Length; num8++)
			{
				array14[num8] = ReadUInt64(null);
			}
			result = array14;
			break;
		}
		case BuiltInType.Float:
		{
			float[] array8 = new float[length];
			for (int num2 = 0; num2 < array8.Length; num2++)
			{
				array8[num2] = ReadFloat(null);
			}
			result = array8;
			break;
		}
		case BuiltInType.Double:
		{
			double[] array24 = new double[length];
			for (int num18 = 0; num18 < array24.Length; num18++)
			{
				array24[num18] = ReadDouble(null);
			}
			result = array24;
			break;
		}
		case BuiltInType.String:
		{
			string[] array20 = new string[length];
			for (int num14 = 0; num14 < array20.Length; num14++)
			{
				array20[num14] = ReadString(null);
			}
			result = array20;
			break;
		}
		case BuiltInType.DateTime:
		{
			DateTime[] array15 = new DateTime[length];
			for (int num9 = 0; num9 < array15.Length; num9++)
			{
				array15[num9] = ReadDateTime(null);
			}
			result = array15;
			break;
		}
		case BuiltInType.Guid:
		{
			Uuid[] array11 = new Uuid[length];
			for (int num5 = 0; num5 < array11.Length; num5++)
			{
				array11[num5] = ReadGuid(null);
			}
			result = array11;
			break;
		}
		case BuiltInType.ByteString:
		{
			byte[][] array6 = new byte[length][];
			for (int n = 0; n < array6.Length; n++)
			{
				array6[n] = ReadByteString(null);
			}
			result = array6;
			break;
		}
		case BuiltInType.XmlElement:
			try
			{
				XmlElement[] array5 = new XmlElement[length];
				for (int m = 0; m < array5.Length; m++)
				{
					array5[m] = ReadXmlElement(null);
				}
				result = array5;
			}
			catch (Exception exception)
			{
				Utils.LogError(exception, "Error reading array of XmlElement.");
			}
			break;
		case BuiltInType.NodeId:
		{
			NodeId[] array25 = new NodeId[length];
			for (int num19 = 0; num19 < array25.Length; num19++)
			{
				array25[num19] = ReadNodeId(null);
			}
			result = array25;
			break;
		}
		case BuiltInType.ExpandedNodeId:
		{
			ExpandedNodeId[] array22 = new ExpandedNodeId[length];
			for (int num16 = 0; num16 < array22.Length; num16++)
			{
				array22[num16] = ReadExpandedNodeId(null);
			}
			result = array22;
			break;
		}
		case BuiltInType.StatusCode:
		{
			StatusCode[] array19 = new StatusCode[length];
			for (int num13 = 0; num13 < array19.Length; num13++)
			{
				array19[num13] = ReadStatusCode(null);
			}
			result = array19;
			break;
		}
		case BuiltInType.QualifiedName:
		{
			QualifiedName[] array16 = new QualifiedName[length];
			for (int num10 = 0; num10 < array16.Length; num10++)
			{
				array16[num10] = ReadQualifiedName(null);
			}
			result = array16;
			break;
		}
		case BuiltInType.LocalizedText:
		{
			LocalizedText[] array13 = new LocalizedText[length];
			for (int num7 = 0; num7 < array13.Length; num7++)
			{
				array13[num7] = ReadLocalizedText(null);
			}
			result = array13;
			break;
		}
		case BuiltInType.ExtensionObject:
		{
			ExtensionObject[] array10 = new ExtensionObject[length];
			for (int num4 = 0; num4 < array10.Length; num4++)
			{
				array10[num4] = ReadExtensionObject();
			}
			result = array10;
			break;
		}
		case BuiltInType.DataValue:
		{
			DataValue[] array7 = new DataValue[length];
			for (int num = 0; num < array7.Length; num++)
			{
				array7[num] = ReadDataValue(null);
			}
			result = array7;
			break;
		}
		case BuiltInType.Variant:
		{
			Variant[] array4 = new Variant[length];
			for (int l = 0; l < array4.Length; l++)
			{
				array4[l] = ReadVariant(null);
			}
			result = array4;
			break;
		}
		case BuiltInType.DiagnosticInfo:
		{
			DiagnosticInfo[] array = new DiagnosticInfo[length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = ReadDiagnosticInfo(null);
			}
			result = array;
			break;
		}
		default:
			throw new ServiceResultException(2147942400u, Utils.Format("Cannot decode unknown type in Variant object with BuiltInType: {0}.", builtInType));
		}
		return result;
	}

	private int ReadArrayLength()
	{
		int num = m_reader.ReadInt32();
		if (num < 0)
		{
			return -1;
		}
		if (m_context.MaxArrayLength > 0 && m_context.MaxArrayLength < num)
		{
			throw ServiceResultException.Create(2148007936u, "MaxArrayLength {0} < {1}", m_context.MaxArrayLength, num);
		}
		return num;
	}

	private void ReadNodeIdBody(byte encodingByte, NodeId value)
	{
		switch ((NodeIdEncodingBits)(encodingByte & 0x3F))
		{
		case NodeIdEncodingBits.TwoByte:
			value.SetNamespaceIndex(0);
			value.SetIdentifier(IdType.Numeric, (uint)m_reader.ReadByte());
			break;
		case NodeIdEncodingBits.FourByte:
			value.SetNamespaceIndex(m_reader.ReadByte());
			value.SetIdentifier(IdType.Numeric, (uint)m_reader.ReadUInt16());
			break;
		case NodeIdEncodingBits.Numeric:
			value.SetNamespaceIndex(m_reader.ReadUInt16());
			value.SetIdentifier(IdType.Numeric, m_reader.ReadUInt32());
			break;
		case NodeIdEncodingBits.String:
			value.SetNamespaceIndex(m_reader.ReadUInt16());
			value.SetIdentifier(IdType.String, ReadString(null));
			break;
		case NodeIdEncodingBits.Guid:
			value.SetNamespaceIndex(m_reader.ReadUInt16());
			value.SetIdentifier(IdType.Guid, (Guid)ReadGuid(null));
			break;
		case NodeIdEncodingBits.ByteString:
			value.SetNamespaceIndex(m_reader.ReadUInt16());
			value.SetIdentifier(IdType.Opaque, ReadByteString(null));
			break;
		default:
			throw new ServiceResultException(2147942400u, Utils.Format("Invald encoding byte (0x{0:X2}) for NodeId.", encodingByte));
		}
	}

	private ExtensionObject ReadExtensionObject()
	{
		ExtensionObject extensionObject = new ExtensionObject();
		NodeId nodeId = ReadNodeId(null);
		extensionObject.TypeId = NodeId.ToExpandedNodeId(nodeId, m_context.NamespaceUris);
		if (!NodeId.IsNull(nodeId) && NodeId.IsNull(extensionObject.TypeId))
		{
			Utils.LogWarning("Cannot de-serialized extension objects if the NamespaceUri is not in the NamespaceTable: Type = {0}", nodeId);
		}
		ExtensionObjectEncoding extensionObjectEncoding = (ExtensionObjectEncoding)Enum.ToObject(typeof(ExtensionObjectEncoding), m_reader.ReadByte());
		if (extensionObjectEncoding == ExtensionObjectEncoding.None)
		{
			return extensionObject;
		}
		Type systemType = m_context.Factory.GetSystemType(extensionObject.TypeId);
		if (extensionObjectEncoding == ExtensionObjectEncoding.Xml)
		{
			extensionObject.Body = ReadXmlElement(null);
			if (systemType != null && extensionObject.Body != null)
			{
				XmlElement xmlElement = extensionObject.Body as XmlElement;
				XmlDecoder xmlDecoder = new XmlDecoder(xmlElement, Context);
				try
				{
					xmlDecoder.PushNamespace(xmlElement.NamespaceURI);
					IEncodeable body = xmlDecoder.ReadEncodeable(xmlElement.LocalName, systemType, extensionObject.TypeId);
					xmlDecoder.PopNamespace();
					extensionObject.Body = body;
				}
				catch (Exception ex)
				{
					Utils.LogError("Could not decode known type {0}. Error={1}, Value={2}", systemType.FullName, ex.Message, xmlElement.OuterXml);
				}
			}
			return extensionObject;
		}
		IEncodeable encodeable = null;
		if (systemType != null)
		{
			encodeable = Activator.CreateInstance(systemType) as IEncodeable;
			if (encodeable is IComplexTypeInstance complexTypeInstance)
			{
				complexTypeInstance.TypeId = extensionObject.TypeId;
			}
		}
		int num = ReadInt32(null);
		int position = Position;
		if (encodeable != null)
		{
			uint nestingLevel = m_nestingLevel;
			CheckAndIncrementNestingLevel();
			try
			{
				encodeable.Decode(this);
				int num2 = Position - position;
				if (num != num2)
				{
					throw ServiceResultException.Create(2147942400u, "The encodeable.Decoder operation did not match the length of the extension object. {0} != {1}", num2, num);
				}
			}
			catch (EndOfStreamException exception)
			{
				m_reader.BaseStream.Position = position;
				encodeable = null;
				Utils.LogWarning(exception, "End of stream, failed to decode encodeable type '{0}', NodeId='{1}'. BinaryDecoder recovered.", systemType.Name, extensionObject.TypeId);
			}
			catch (ServiceResultException ex2) when (ex2.StatusCode == 2148007936u || ex2.StatusCode == 2147942400u)
			{
				m_reader.BaseStream.Position = position;
				encodeable = null;
				Utils.LogWarning(ex2, "{0}, failed to decode encodeable type '{1}', NodeId='{2}'. BinaryDecoder recovered.", ex2.Message, systemType.Name, extensionObject.TypeId);
			}
			finally
			{
				m_nestingLevel = nestingLevel;
			}
		}
		if (encodeable == null)
		{
			if (num < 0)
			{
				throw new ServiceResultException(2147942400u, Utils.Format("Cannot determine length of unknown extension object body with type '{0}'.", extensionObject.TypeId));
			}
			if (m_context.MaxByteStringLength > 0 && m_context.MaxByteStringLength < num)
			{
				throw ServiceResultException.Create(2148007936u, "MaxByteStringLength {0} < {1}", m_context.MaxByteStringLength, num);
			}
			extensionObject.Body = m_reader.ReadBytes(num);
			return extensionObject;
		}
		int num3 = num - (Position - position);
		if (num3 > 0)
		{
			m_reader.ReadBytes(num3);
		}
		if (encodeable != null)
		{
			extensionObject.TypeId = encodeable.TypeId;
		}
		extensionObject.Body = encodeable;
		return extensionObject;
	}

	private Variant ReadVariantValue(string fieldName)
	{
		byte b = m_reader.ReadByte();
		Variant result = default(Variant);
		if ((b & 0x80) != 0)
		{
			int num = ReadArrayLength();
			if (num < 0)
			{
				return result;
			}
			BuiltInType builtInType = (BuiltInType)(b & 0x3F);
			Array array = ReadArrayElements(num, builtInType);
			if (array == null)
			{
				result = new Variant(2147942400u);
			}
			else if ((b & 0x40) != 0)
			{
				Int32Collection int32Collection = ReadInt32Array(null);
				if (int32Collection == null || int32Collection.Count == 0)
				{
					throw new ServiceResultException(2147942400u, "ArrayDimensions not specified when ArrayDimensions encoding bit was set in Variant object.");
				}
				var (flag, num2) = Matrix.ValidateDimensions(int32Collection.ToArray(), num, Context.MaxArrayLength);
				if (!flag || num2 != num)
				{
					throw new ServiceResultException(2147942400u, "ArrayDimensions does not match with the ArrayLength in Variant object.");
				}
				result = new Variant(new Matrix(array, builtInType, int32Collection.ToArray()));
			}
			else
			{
				result = new Variant(array, new TypeInfo(builtInType, 1));
			}
		}
		else
		{
			switch ((BuiltInType)b)
			{
			case BuiltInType.Null:
				result.Value = null;
				break;
			case BuiltInType.Boolean:
				result.Set(ReadBoolean(null));
				break;
			case BuiltInType.SByte:
				result.Set(ReadSByte(null));
				break;
			case BuiltInType.Byte:
				result.Set(ReadByte(null));
				break;
			case BuiltInType.Int16:
				result.Set(ReadInt16(null));
				break;
			case BuiltInType.UInt16:
				result.Set(ReadUInt16(null));
				break;
			case BuiltInType.Int32:
			case BuiltInType.Enumeration:
				result.Set(ReadInt32(null));
				break;
			case BuiltInType.UInt32:
				result.Set(ReadUInt32(null));
				break;
			case BuiltInType.Int64:
				result.Set(ReadInt64(null));
				break;
			case BuiltInType.UInt64:
				result.Set(ReadUInt64(null));
				break;
			case BuiltInType.Float:
				result.Set(ReadFloat(null));
				break;
			case BuiltInType.Double:
				result.Set(ReadDouble(null));
				break;
			case BuiltInType.String:
				result.Set(ReadString(null));
				break;
			case BuiltInType.DateTime:
				result.Set(ReadDateTime(null));
				break;
			case BuiltInType.Guid:
				result.Set(ReadGuid(null));
				break;
			case BuiltInType.ByteString:
				result.Set(ReadByteString(null));
				break;
			case BuiltInType.XmlElement:
				try
				{
					result.Set(ReadXmlElement(null));
				}
				catch (Exception exception)
				{
					Utils.LogError(exception, "Error reading xml element for variant.");
					result.Set(2147942400u);
				}
				break;
			case BuiltInType.NodeId:
				result.Set(ReadNodeId(null));
				break;
			case BuiltInType.ExpandedNodeId:
				result.Set(ReadExpandedNodeId(null));
				break;
			case BuiltInType.StatusCode:
				result.Set(ReadStatusCode(null));
				break;
			case BuiltInType.QualifiedName:
				result.Set(ReadQualifiedName(null));
				break;
			case BuiltInType.LocalizedText:
				result.Set(ReadLocalizedText(null));
				break;
			case BuiltInType.ExtensionObject:
				result.Set(ReadExtensionObject());
				break;
			case BuiltInType.DataValue:
				result.Set(ReadDataValue(null));
				break;
			default:
				throw new ServiceResultException(2147942400u, Utils.Format("Cannot decode unknown type in Variant object (0x{0:X2}).", b));
			}
		}
		return result;
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
