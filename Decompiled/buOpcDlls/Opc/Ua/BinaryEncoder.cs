using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;

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

	public int Position
	{
		get
		{
			return (int)m_writer.BaseStream.Position;
		}
		set
		{
			m_writer.Seek(value, SeekOrigin.Begin);
		}
	}

	public EncodingType EncodingType => EncodingType.Binary;

	public IServiceMessageContext Context => m_context;

	public bool UseReversibleEncoding => true;

	public BinaryEncoder(IServiceMessageContext context)
	{
		m_ostrm = new MemoryStream();
		m_writer = new BinaryWriter(m_ostrm);
		m_context = context;
		m_leaveOpen = false;
		m_nestingLevel = 0u;
	}

	public BinaryEncoder(byte[] buffer, int start, int count, IServiceMessageContext context)
	{
		if (buffer == null)
		{
			throw new ArgumentNullException("buffer");
		}
		m_ostrm = new MemoryStream(buffer, start, count);
		m_writer = new BinaryWriter(m_ostrm);
		m_context = context;
		m_leaveOpen = false;
		m_nestingLevel = 0u;
	}

	public BinaryEncoder(Stream stream, IServiceMessageContext context, bool leaveOpen)
	{
		if (stream == null)
		{
			throw new ArgumentNullException("stream");
		}
		m_ostrm = stream;
		m_writer = new BinaryWriter(m_ostrm, Encoding.UTF8, leaveOpen);
		m_context = context;
		m_leaveOpen = leaveOpen;
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
			if (m_writer != null)
			{
				m_writer.Flush();
				m_writer.Dispose();
				m_writer = null;
			}
			if (!m_leaveOpen)
			{
				m_ostrm?.Dispose();
				m_ostrm = null;
			}
		}
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

	public byte[] CloseAndReturnBuffer()
	{
		Close();
		if (m_ostrm is MemoryStream memoryStream)
		{
			return memoryStream.ToArray();
		}
		return null;
	}

	public string CloseAndReturnText()
	{
		Close();
		if (m_ostrm is MemoryStream memoryStream)
		{
			return Convert.ToBase64String(memoryStream.ToArray());
		}
		return null;
	}

	public int Close()
	{
		int result = (int)m_writer.BaseStream.Position;
		m_writer.Flush();
		m_writer.Dispose();
		return result;
	}

	public void WriteRawBytes(byte[] buffer, int offset, int count)
	{
		m_writer.Write(buffer, offset, count);
	}

	public static byte[] EncodeMessage(IEncodeable message, IServiceMessageContext context)
	{
		if (message == null)
		{
			throw new ArgumentNullException("message");
		}
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		using BinaryEncoder binaryEncoder = new BinaryEncoder(context);
		binaryEncoder.EncodeMessage(message);
		return binaryEncoder.CloseAndReturnBuffer();
	}

	public static void EncodeSessionLessMessage(IEncodeable message, Stream stream, IServiceMessageContext context, bool leaveOpen)
	{
		if (message == null)
		{
			throw new ArgumentNullException("message");
		}
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		using BinaryEncoder binaryEncoder = new BinaryEncoder(stream, context, leaveOpen);
		long position = binaryEncoder.m_ostrm.Position;
		binaryEncoder.WriteNodeId(null, DataTypeIds.SessionlessInvokeRequestType);
		SessionLessServiceMessage sessionLessServiceMessage = new SessionLessServiceMessage();
		sessionLessServiceMessage.NamespaceUris = context.NamespaceUris;
		sessionLessServiceMessage.ServerUris = context.ServerUris;
		sessionLessServiceMessage.Message = message;
		sessionLessServiceMessage.Encode(binaryEncoder);
		if (context.MaxMessageSize > 0 && context.MaxMessageSize < (int)(binaryEncoder.m_ostrm.Position - position))
		{
			throw ServiceResultException.Create(2148007936u, "MaxMessageSize {0} < {1}", context.MaxMessageSize, (int)(binaryEncoder.m_ostrm.Position - position));
		}
	}

	public static void EncodeMessage(IEncodeable message, Stream stream, IServiceMessageContext context, bool leaveOpen)
	{
		if (message == null)
		{
			throw new ArgumentNullException("message");
		}
		if (stream == null)
		{
			throw new ArgumentNullException("stream");
		}
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		using BinaryEncoder binaryEncoder = new BinaryEncoder(stream, context, leaveOpen);
		binaryEncoder.EncodeMessage(message);
	}

	public void EncodeMessage(IEncodeable message)
	{
		if (message == null)
		{
			throw new ArgumentNullException("message");
		}
		long position = m_ostrm.Position;
		NodeId value = ExpandedNodeId.ToNodeId(message.BinaryEncodingId, m_context.NamespaceUris);
		WriteNodeId(null, value);
		WriteEncodeable(null, message, message.GetType());
		if (m_context.MaxMessageSize > 0 && m_context.MaxMessageSize < (int)(m_ostrm.Position - position))
		{
			throw ServiceResultException.Create(2148007936u, "MaxMessageSize {0} < {1}", m_context.MaxMessageSize, (int)(m_ostrm.Position - position));
		}
	}

	public void SaveStringTable(StringTable stringTable)
	{
		if (stringTable == null || stringTable.Count <= 1)
		{
			WriteInt32(null, -1);
			return;
		}
		WriteInt32(null, stringTable.Count - 1);
		for (uint num = 1u; num < stringTable.Count; num++)
		{
			WriteString(null, stringTable.GetString(num));
		}
	}

	public void PushNamespace(string namespaceUri)
	{
	}

	public void PopNamespace()
	{
	}

	public void WriteBoolean(string fieldName, bool value)
	{
		m_writer.Write(value);
	}

	public void WriteSByte(string fieldName, sbyte value)
	{
		m_writer.Write(value);
	}

	public void WriteByte(string fieldName, byte value)
	{
		m_writer.Write(value);
	}

	public void WriteInt16(string fieldName, short value)
	{
		m_writer.Write(value);
	}

	public void WriteUInt16(string fieldName, ushort value)
	{
		m_writer.Write(value);
	}

	public void WriteInt32(string fieldName, int value)
	{
		m_writer.Write(value);
	}

	public void WriteUInt32(string fieldName, uint value)
	{
		m_writer.Write(value);
	}

	public void WriteInt64(string fieldName, long value)
	{
		m_writer.Write(value);
	}

	public void WriteUInt64(string fieldName, ulong value)
	{
		m_writer.Write(value);
	}

	public void WriteFloat(string fieldName, float value)
	{
		m_writer.Write(value);
	}

	public void WriteDouble(string fieldName, double value)
	{
		m_writer.Write(value);
	}

	public void WriteString(string fieldName, string value)
	{
		if (value == null)
		{
			WriteInt32(null, -1);
			return;
		}
		byte[] bytes = Encoding.UTF8.GetBytes(value);
		if (m_context.MaxStringLength > 0 && m_context.MaxStringLength < bytes.Length)
		{
			throw ServiceResultException.Create(2148007936u, "MaxStringLength {0} < {1}", m_context.MaxStringLength, bytes.Length);
		}
		WriteByteString(null, Encoding.UTF8.GetBytes(value));
	}

	public void WriteDateTime(string fieldName, DateTime value)
	{
		value = Utils.ToOpcUaUniversalTime(value);
		long ticks = value.Ticks;
		if (ticks >= DateTime.MaxValue.Ticks)
		{
			ticks = long.MaxValue;
		}
		else
		{
			ticks -= Utils.TimeBase.Ticks;
			if (ticks <= 0)
			{
				ticks = 0L;
			}
		}
		m_writer.Write(ticks);
	}

	public void WriteGuid(string fieldName, Uuid value)
	{
		m_writer.Write(((Guid)value).ToByteArray());
	}

	public void WriteGuid(string fieldName, Guid value)
	{
		BinaryWriter writer = m_writer;
		Guid guid = value;
		writer.Write(guid.ToByteArray());
	}

	public void WriteByteString(string fieldName, byte[] value)
	{
		if (value == null)
		{
			WriteInt32(null, -1);
			return;
		}
		if (m_context.MaxByteStringLength > 0 && m_context.MaxByteStringLength < value.Length)
		{
			throw ServiceResultException.Create(2148007936u, "MaxByteStringLength {0} < {1}", m_context.MaxByteStringLength, value.Length);
		}
		WriteInt32(null, value.Length);
		m_writer.Write(value);
	}

	public void WriteXmlElement(string fieldName, XmlElement value)
	{
		if (value == null)
		{
			WriteInt32(null, -1);
		}
		else
		{
			WriteByteString(null, Encoding.UTF8.GetBytes(value.OuterXml));
		}
	}

	public void WriteNodeId(string fieldName, NodeId value)
	{
		if (value == null)
		{
			WriteUInt16(null, 0);
			return;
		}
		ushort num = value.NamespaceIndex;
		if (m_namespaceMappings != null && m_namespaceMappings.Length > num)
		{
			num = m_namespaceMappings[num];
		}
		byte nodeIdEncoding = GetNodeIdEncoding(value.IdType, value.Identifier, num);
		WriteByte(null, nodeIdEncoding);
		WriteNodeIdBody(nodeIdEncoding, value.Identifier, num);
	}

	public void WriteExpandedNodeId(string fieldName, ExpandedNodeId value)
	{
		if (value == null)
		{
			WriteUInt16(null, 0);
			return;
		}
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
		byte b = GetNodeIdEncoding(value.IdType, value.Identifier, num);
		if (!string.IsNullOrEmpty(value.NamespaceUri))
		{
			b |= 0x80;
		}
		if (num2 != 0)
		{
			b |= 0x40;
		}
		WriteByte(null, b);
		WriteNodeIdBody(b, value.Identifier, num);
		if ((b & 0x80) != 0)
		{
			WriteString(null, value.NamespaceUri);
		}
		if ((b & 0x40) != 0)
		{
			WriteUInt32(null, num2);
		}
	}

	public void WriteStatusCode(string fieldName, StatusCode value)
	{
		WriteUInt32(null, value.Code);
	}

	public void WriteDiagnosticInfo(string fieldName, DiagnosticInfo value)
	{
		WriteDiagnosticInfo(fieldName, value, 0);
	}

	public void WriteQualifiedName(string fieldName, QualifiedName value)
	{
		if (value == null)
		{
			value = new QualifiedName();
		}
		ushort num = value.NamespaceIndex;
		if (m_namespaceMappings != null && m_namespaceMappings.Length > num)
		{
			num = m_namespaceMappings[num];
		}
		WriteUInt16(null, num);
		WriteString(null, value.Name);
	}

	public void WriteLocalizedText(string fieldName, LocalizedText value)
	{
		if (value == null)
		{
			WriteByte(null, 0);
			return;
		}
		byte b = 0;
		if (value.Locale != null)
		{
			b |= 1;
		}
		if (value.Text != null)
		{
			b |= 2;
		}
		WriteByte(null, b);
		if ((b & 1) != 0)
		{
			WriteString(null, value.Locale);
		}
		if ((b & 2) != 0)
		{
			WriteString(null, value.Text);
		}
	}

	public void WriteVariant(string fieldName, Variant value)
	{
		CheckAndIncrementNestingLevel();
		try
		{
			WriteVariantValue(fieldName, value);
		}
		finally
		{
			m_nestingLevel--;
		}
	}

	public void WriteDataValue(string fieldName, DataValue value)
	{
		if (value == null)
		{
			WriteByte(null, 0);
			return;
		}
		byte b = 0;
		if (value.Value != null)
		{
			b |= 1;
		}
		if (value.StatusCode != 0u)
		{
			b |= 2;
		}
		if (value.SourceTimestamp != DateTime.MinValue)
		{
			b |= 4;
		}
		if (value.SourcePicoseconds != 0)
		{
			b |= 0x10;
		}
		if (value.ServerTimestamp != DateTime.MinValue)
		{
			b |= 8;
		}
		if (value.ServerPicoseconds != 0)
		{
			b |= 0x20;
		}
		WriteByte(null, b);
		if ((b & 1) != 0)
		{
			WriteVariant(null, value.WrappedValue);
		}
		if ((b & 2) != 0)
		{
			WriteStatusCode(null, value.StatusCode);
		}
		if ((b & 4) != 0)
		{
			WriteDateTime(null, value.SourceTimestamp);
		}
		if ((b & 0x10) != 0)
		{
			WriteUInt16(null, value.SourcePicoseconds);
		}
		if ((b & 8) != 0)
		{
			WriteDateTime(null, value.ServerTimestamp);
		}
		if ((b & 0x20) != 0)
		{
			WriteUInt16(null, value.ServerPicoseconds);
		}
	}

	public void WriteExtensionObject(string fieldName, ExtensionObject value)
	{
		if (value == null)
		{
			WriteNodeId(null, NodeId.Null);
			WriteByte(null, Convert.ToByte(ExtensionObjectEncoding.None, CultureInfo.InvariantCulture));
			return;
		}
		IEncodeable encodeable = value.Body as IEncodeable;
		ExpandedNodeId expandedNodeId = value.TypeId;
		if (encodeable != null)
		{
			expandedNodeId = ((value.Encoding != ExtensionObjectEncoding.Xml) ? encodeable.BinaryEncodingId : encodeable.XmlEncodingId);
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
		WriteNodeId(null, nodeId);
		byte value2 = Convert.ToByte(value.Encoding, CultureInfo.InvariantCulture);
		if (value.Encoding == ExtensionObjectEncoding.EncodeableObject)
		{
			value2 = Convert.ToByte(ExtensionObjectEncoding.Binary, CultureInfo.InvariantCulture);
		}
		object body = value.Body;
		if (body == null)
		{
			value2 = Convert.ToByte(ExtensionObjectEncoding.None, CultureInfo.InvariantCulture);
		}
		WriteByte(null, value2);
		if (body == null)
		{
			return;
		}
		if (body is byte[] value3)
		{
			WriteByteString(null, value3);
			return;
		}
		if (body is XmlElement value4)
		{
			WriteXmlElement(null, value4);
			return;
		}
		if (encodeable == null)
		{
			throw new ServiceResultException(2147876864u, Utils.Format("Cannot encode bodies of type '{0}' in extension objects.", body.GetType().FullName));
		}
		if (m_writer.BaseStream.CanSeek)
		{
			long position = m_writer.BaseStream.Position;
			WriteInt32(null, -1);
			encodeable.Encode(this);
			long num = m_writer.BaseStream.Position - position;
			m_writer.Seek((int)(-num), SeekOrigin.Current);
			WriteInt32(null, (int)(num - 4));
			m_writer.Seek((int)(num - 4), SeekOrigin.Current);
			return;
		}
		using BinaryEncoder binaryEncoder = new BinaryEncoder(m_context);
		binaryEncoder.WriteEncodeable(null, encodeable, null);
		byte[] value5 = binaryEncoder.CloseAndReturnBuffer();
		WriteByteString(null, value5);
	}

	public void WriteEncodeable(string fieldName, IEncodeable value, Type systemType)
	{
		CheckAndIncrementNestingLevel();
		try
		{
			if (value == null)
			{
				if (systemType == null)
				{
					throw new ArgumentNullException("systemType");
				}
				value = Activator.CreateInstance(systemType) as IEncodeable;
			}
			value?.Encode(this);
		}
		finally
		{
			m_nestingLevel--;
		}
	}

	public void WriteEnumerated(string fieldName, Enum value)
	{
		if (value == null)
		{
			throw new ArgumentNullException("value");
		}
		WriteInt32(null, Convert.ToInt32(value, CultureInfo.InvariantCulture));
	}

	public void WriteBooleanArray(string fieldName, IList<bool> values)
	{
		if (!WriteArrayLength(values))
		{
			for (int i = 0; i < values.Count; i++)
			{
				WriteBoolean(null, values[i]);
			}
		}
	}

	public void WriteSByteArray(string fieldName, IList<sbyte> values)
	{
		if (!WriteArrayLength(values))
		{
			for (int i = 0; i < values.Count; i++)
			{
				WriteSByte(null, values[i]);
			}
		}
	}

	public void WriteByteArray(string fieldName, IList<byte> values)
	{
		if (!WriteArrayLength(values))
		{
			for (int i = 0; i < values.Count; i++)
			{
				WriteByte(null, values[i]);
			}
		}
	}

	public void WriteInt16Array(string fieldName, IList<short> values)
	{
		if (!WriteArrayLength(values))
		{
			for (int i = 0; i < values.Count; i++)
			{
				WriteInt16(null, values[i]);
			}
		}
	}

	public void WriteUInt16Array(string fieldName, IList<ushort> values)
	{
		if (!WriteArrayLength(values))
		{
			for (int i = 0; i < values.Count; i++)
			{
				WriteUInt16(null, values[i]);
			}
		}
	}

	public void WriteInt32Array(string fieldName, IList<int> values)
	{
		if (!WriteArrayLength(values))
		{
			for (int i = 0; i < values.Count; i++)
			{
				WriteInt32(null, values[i]);
			}
		}
	}

	public void WriteUInt32Array(string fieldName, IList<uint> values)
	{
		if (!WriteArrayLength(values))
		{
			for (int i = 0; i < values.Count; i++)
			{
				WriteUInt32(null, values[i]);
			}
		}
	}

	public void WriteInt64Array(string fieldName, IList<long> values)
	{
		if (!WriteArrayLength(values))
		{
			for (int i = 0; i < values.Count; i++)
			{
				WriteInt64(null, values[i]);
			}
		}
	}

	public void WriteUInt64Array(string fieldName, IList<ulong> values)
	{
		if (!WriteArrayLength(values))
		{
			for (int i = 0; i < values.Count; i++)
			{
				WriteUInt64(null, values[i]);
			}
		}
	}

	public void WriteFloatArray(string fieldName, IList<float> values)
	{
		if (!WriteArrayLength(values))
		{
			for (int i = 0; i < values.Count; i++)
			{
				WriteFloat(null, values[i]);
			}
		}
	}

	public void WriteDoubleArray(string fieldName, IList<double> values)
	{
		if (!WriteArrayLength(values))
		{
			for (int i = 0; i < values.Count; i++)
			{
				WriteDouble(null, values[i]);
			}
		}
	}

	public void WriteStringArray(string fieldName, IList<string> values)
	{
		if (!WriteArrayLength(values))
		{
			for (int i = 0; i < values.Count; i++)
			{
				WriteString(null, values[i]);
			}
		}
	}

	public void WriteDateTimeArray(string fieldName, IList<DateTime> values)
	{
		if (!WriteArrayLength(values))
		{
			for (int i = 0; i < values.Count; i++)
			{
				WriteDateTime(null, values[i]);
			}
		}
	}

	public void WriteGuidArray(string fieldName, IList<Uuid> values)
	{
		if (!WriteArrayLength(values))
		{
			for (int i = 0; i < values.Count; i++)
			{
				WriteGuid(null, values[i]);
			}
		}
	}

	public void WriteGuidArray(string fieldName, IList<Guid> values)
	{
		if (!WriteArrayLength(values))
		{
			for (int i = 0; i < values.Count; i++)
			{
				WriteGuid(null, values[i]);
			}
		}
	}

	public void WriteByteStringArray(string fieldName, IList<byte[]> values)
	{
		if (!WriteArrayLength(values))
		{
			for (int i = 0; i < values.Count; i++)
			{
				WriteByteString(null, values[i]);
			}
		}
	}

	public void WriteXmlElementArray(string fieldName, IList<XmlElement> values)
	{
		if (!WriteArrayLength(values))
		{
			for (int i = 0; i < values.Count; i++)
			{
				WriteXmlElement(null, values[i]);
			}
		}
	}

	public void WriteNodeIdArray(string fieldName, IList<NodeId> values)
	{
		if (!WriteArrayLength(values))
		{
			for (int i = 0; i < values.Count; i++)
			{
				WriteNodeId(null, values[i]);
			}
		}
	}

	public void WriteExpandedNodeIdArray(string fieldName, IList<ExpandedNodeId> values)
	{
		if (!WriteArrayLength(values))
		{
			for (int i = 0; i < values.Count; i++)
			{
				WriteExpandedNodeId(null, values[i]);
			}
		}
	}

	public void WriteStatusCodeArray(string fieldName, IList<StatusCode> values)
	{
		if (!WriteArrayLength(values))
		{
			for (int i = 0; i < values.Count; i++)
			{
				WriteStatusCode(null, values[i]);
			}
		}
	}

	public void WriteDiagnosticInfoArray(string fieldName, IList<DiagnosticInfo> values)
	{
		if (!WriteArrayLength(values))
		{
			for (int i = 0; i < values.Count; i++)
			{
				WriteDiagnosticInfo(null, values[i]);
			}
		}
	}

	public void WriteQualifiedNameArray(string fieldName, IList<QualifiedName> values)
	{
		if (!WriteArrayLength(values))
		{
			for (int i = 0; i < values.Count; i++)
			{
				WriteQualifiedName(null, values[i]);
			}
		}
	}

	public void WriteLocalizedTextArray(string fieldName, IList<LocalizedText> values)
	{
		if (!WriteArrayLength(values))
		{
			for (int i = 0; i < values.Count; i++)
			{
				WriteLocalizedText(null, values[i]);
			}
		}
	}

	public void WriteVariantArray(string fieldName, IList<Variant> values)
	{
		if (!WriteArrayLength(values))
		{
			for (int i = 0; i < values.Count; i++)
			{
				WriteVariant(null, values[i]);
			}
		}
	}

	public void WriteDataValueArray(string fieldName, IList<DataValue> values)
	{
		if (!WriteArrayLength(values))
		{
			for (int i = 0; i < values.Count; i++)
			{
				WriteDataValue(null, values[i]);
			}
		}
	}

	public void WriteExtensionObjectArray(string fieldName, IList<ExtensionObject> values)
	{
		if (!WriteArrayLength(values))
		{
			for (int i = 0; i < values.Count; i++)
			{
				WriteExtensionObject(null, values[i]);
			}
		}
	}

	public void WriteEncodeableArray(string fieldName, IList<IEncodeable> values, Type systemType)
	{
		if (!WriteArrayLength((Array)values))
		{
			for (int i = 0; i < values.Count; i++)
			{
				WriteEncodeable(null, values[i], systemType);
			}
		}
	}

	public void WriteEnumeratedArray(string fieldName, Array values, Type systemType)
	{
		if (!WriteArrayLength(values))
		{
			for (int i = 0; i < values.Length; i++)
			{
				WriteEnumerated(null, (Enum)values.GetValue(i));
			}
		}
	}

	public void WriteArray(string fieldName, object array, int valueRank, BuiltInType builtInType)
	{
		if (valueRank == 1)
		{
			switch (builtInType)
			{
			case BuiltInType.Boolean:
				WriteBooleanArray(null, (bool[])array);
				break;
			case BuiltInType.SByte:
				WriteSByteArray(null, (sbyte[])array);
				break;
			case BuiltInType.Byte:
				WriteByteArray(null, (byte[])array);
				break;
			case BuiltInType.Int16:
				WriteInt16Array(null, (short[])array);
				break;
			case BuiltInType.UInt16:
				WriteUInt16Array(null, (ushort[])array);
				break;
			case BuiltInType.Int32:
				WriteInt32Array(null, (int[])array);
				break;
			case BuiltInType.UInt32:
				WriteUInt32Array(null, (uint[])array);
				break;
			case BuiltInType.Int64:
				WriteInt64Array(null, (long[])array);
				break;
			case BuiltInType.UInt64:
				WriteUInt64Array(null, (ulong[])array);
				break;
			case BuiltInType.Float:
				WriteFloatArray(null, (float[])array);
				break;
			case BuiltInType.Double:
				WriteDoubleArray(null, (double[])array);
				break;
			case BuiltInType.DateTime:
				WriteDateTimeArray(null, (DateTime[])array);
				break;
			case BuiltInType.Guid:
				WriteGuidArray(null, (Uuid[])array);
				break;
			case BuiltInType.String:
				WriteStringArray(null, (string[])array);
				break;
			case BuiltInType.ByteString:
				WriteByteStringArray(null, (byte[][])array);
				break;
			case BuiltInType.QualifiedName:
				WriteQualifiedNameArray(null, (QualifiedName[])array);
				break;
			case BuiltInType.LocalizedText:
				WriteLocalizedTextArray(null, (LocalizedText[])array);
				break;
			case BuiltInType.NodeId:
				WriteNodeIdArray(null, (NodeId[])array);
				break;
			case BuiltInType.ExpandedNodeId:
				WriteExpandedNodeIdArray(null, (ExpandedNodeId[])array);
				break;
			case BuiltInType.StatusCode:
				WriteStatusCodeArray(null, (StatusCode[])array);
				break;
			case BuiltInType.XmlElement:
				WriteXmlElementArray(null, (XmlElement[])array);
				break;
			case BuiltInType.Variant:
				if (array is IEncodeable[] values2)
				{
					WriteEncodeableArray(fieldName, values2, array.GetType().GetElementType());
				}
				else
				{
					WriteVariantArray(null, (Variant[])array);
				}
				break;
			case BuiltInType.Enumeration:
			{
				int[] array2 = array as int[];
				if (array2 == null && array is Enum[] array3)
				{
					array2 = new int[array3.Length];
					for (int i = 0; i < array3.Length; i++)
					{
						array2[i] = Convert.ToInt32(array3[i], CultureInfo.InvariantCulture);
					}
				}
				if (array2 != null)
				{
					WriteInt32Array(null, array2);
					break;
				}
				throw ServiceResultException.Create(2147876864u, "Unexpected type encountered while encoding an Enumeration Array.");
			}
			case BuiltInType.ExtensionObject:
				WriteExtensionObjectArray(null, (ExtensionObject[])array);
				break;
			case BuiltInType.DiagnosticInfo:
				WriteDiagnosticInfoArray(null, (DiagnosticInfo[])array);
				break;
			case BuiltInType.DataValue:
				WriteDataValueArray(null, (DataValue[])array);
				break;
			default:
				if (array is IEncodeable[] values)
				{
					WriteEncodeableArray(fieldName, values, array.GetType().GetElementType());
					break;
				}
				if (array == null)
				{
					WriteInt32(null, -1);
					break;
				}
				throw ServiceResultException.Create(2147876864u, "Unexpected type encountered while encoding an Array with BuiltInType: {0}", builtInType);
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
					WriteInt32(null, -1);
					return;
				}
				matrix = new Matrix(array4, builtInType);
			}
			WriteInt32Array(null, matrix.Dimensions);
			switch (matrix.TypeInfo.BuiltInType)
			{
			case BuiltInType.Boolean:
			{
				bool[] array21 = (bool[])matrix.Elements;
				for (int num12 = 0; num12 < array21.Length; num12++)
				{
					WriteBoolean(null, array21[num12]);
				}
				return;
			}
			case BuiltInType.SByte:
			{
				sbyte[] array25 = (sbyte[])matrix.Elements;
				for (int num16 = 0; num16 < array25.Length; num16++)
				{
					WriteSByte(null, array25[num16]);
				}
				return;
			}
			case BuiltInType.Byte:
			{
				byte[] array7 = (byte[])matrix.Elements;
				for (int l = 0; l < array7.Length; l++)
				{
					WriteByte(null, array7[l]);
				}
				return;
			}
			case BuiltInType.Int16:
			{
				short[] array14 = (short[])matrix.Elements;
				for (int num5 = 0; num5 < array14.Length; num5++)
				{
					WriteInt16(null, array14[num5]);
				}
				return;
			}
			case BuiltInType.UInt16:
			{
				ushort[] array15 = (ushort[])matrix.Elements;
				for (int num6 = 0; num6 < array15.Length; num6++)
				{
					WriteUInt16(null, array15[num6]);
				}
				return;
			}
			case BuiltInType.Enumeration:
				if (matrix.Elements is Enum[] array20)
				{
					for (int num11 = 0; num11 < array20.Length; num11++)
					{
						WriteEnumerated(null, array20[num11]);
					}
					return;
				}
				goto case BuiltInType.Int32;
			case BuiltInType.Int32:
			{
				int[] array29 = (int[])matrix.Elements;
				for (int num20 = 0; num20 < array29.Length; num20++)
				{
					WriteInt32(null, array29[num20]);
				}
				return;
			}
			case BuiltInType.UInt32:
			{
				uint[] array18 = (uint[])matrix.Elements;
				for (int num9 = 0; num9 < array18.Length; num9++)
				{
					WriteUInt32(null, array18[num9]);
				}
				return;
			}
			case BuiltInType.Int64:
			{
				long[] array6 = (long[])matrix.Elements;
				for (int k = 0; k < array6.Length; k++)
				{
					WriteInt64(null, array6[k]);
				}
				return;
			}
			case BuiltInType.UInt64:
			{
				ulong[] array31 = (ulong[])matrix.Elements;
				for (int num22 = 0; num22 < array31.Length; num22++)
				{
					WriteUInt64(null, array31[num22]);
				}
				return;
			}
			case BuiltInType.Float:
			{
				float[] array27 = (float[])matrix.Elements;
				for (int num18 = 0; num18 < array27.Length; num18++)
				{
					WriteFloat(null, array27[num18]);
				}
				return;
			}
			case BuiltInType.Double:
			{
				double[] array23 = (double[])matrix.Elements;
				for (int num14 = 0; num14 < array23.Length; num14++)
				{
					WriteDouble(null, array23[num14]);
				}
				return;
			}
			case BuiltInType.String:
			{
				string[] array17 = (string[])matrix.Elements;
				for (int num8 = 0; num8 < array17.Length; num8++)
				{
					WriteString(null, array17[num8]);
				}
				return;
			}
			case BuiltInType.DateTime:
			{
				DateTime[] array19 = (DateTime[])matrix.Elements;
				for (int num10 = 0; num10 < array19.Length; num10++)
				{
					WriteDateTime(null, array19[num10]);
				}
				return;
			}
			case BuiltInType.Guid:
			{
				Uuid[] array16 = (Uuid[])matrix.Elements;
				for (int num7 = 0; num7 < array16.Length; num7++)
				{
					WriteGuid(null, array16[num7]);
				}
				return;
			}
			case BuiltInType.ByteString:
			{
				byte[][] array13 = (byte[][])matrix.Elements;
				for (int num4 = 0; num4 < array13.Length; num4++)
				{
					WriteByteString(null, array13[num4]);
				}
				return;
			}
			case BuiltInType.XmlElement:
			{
				XmlElement[] array9 = (XmlElement[])matrix.Elements;
				for (int n = 0; n < array9.Length; n++)
				{
					WriteXmlElement(null, array9[n]);
				}
				return;
			}
			case BuiltInType.NodeId:
			{
				NodeId[] array5 = (NodeId[])matrix.Elements;
				for (int j = 0; j < array5.Length; j++)
				{
					WriteNodeId(null, array5[j]);
				}
				return;
			}
			case BuiltInType.ExpandedNodeId:
			{
				ExpandedNodeId[] array32 = (ExpandedNodeId[])matrix.Elements;
				for (int num23 = 0; num23 < array32.Length; num23++)
				{
					WriteExpandedNodeId(null, array32[num23]);
				}
				return;
			}
			case BuiltInType.StatusCode:
			{
				StatusCode[] array30 = (StatusCode[])matrix.Elements;
				for (int num21 = 0; num21 < array30.Length; num21++)
				{
					WriteStatusCode(null, array30[num21]);
				}
				return;
			}
			case BuiltInType.QualifiedName:
			{
				QualifiedName[] array28 = (QualifiedName[])matrix.Elements;
				for (int num19 = 0; num19 < array28.Length; num19++)
				{
					WriteQualifiedName(null, array28[num19]);
				}
				return;
			}
			case BuiltInType.LocalizedText:
			{
				LocalizedText[] array26 = (LocalizedText[])matrix.Elements;
				for (int num17 = 0; num17 < array26.Length; num17++)
				{
					WriteLocalizedText(null, array26[num17]);
				}
				return;
			}
			case BuiltInType.ExtensionObject:
			{
				ExtensionObject[] array24 = (ExtensionObject[])matrix.Elements;
				for (int num15 = 0; num15 < array24.Length; num15++)
				{
					WriteExtensionObject(null, array24[num15]);
				}
				return;
			}
			case BuiltInType.DataValue:
			{
				DataValue[] array22 = (DataValue[])matrix.Elements;
				for (int num13 = 0; num13 < array22.Length; num13++)
				{
					WriteDataValue(null, array22[num13]);
				}
				return;
			}
			case BuiltInType.Variant:
				if (matrix.Elements is Variant[] array10)
				{
					for (int num = 0; num < array10.Length; num++)
					{
						WriteVariant(null, array10[num]);
					}
					return;
				}
				if (matrix.Elements is IEncodeable[] array11)
				{
					for (int num2 = 0; num2 < array11.Length; num2++)
					{
						WriteEncodeable(null, array11[num2], null);
					}
					return;
				}
				if (matrix.Elements is object[] array12)
				{
					for (int num3 = 0; num3 < array12.Length; num3++)
					{
						WriteVariant(null, new Variant(array12[num3]));
					}
					return;
				}
				throw ServiceResultException.Create(2147876864u, "Unexpected type encountered while encoding a Matrix.");
			case BuiltInType.DiagnosticInfo:
			{
				DiagnosticInfo[] array8 = (DiagnosticInfo[])matrix.Elements;
				for (int m = 0; m < array8.Length; m++)
				{
					WriteDiagnosticInfo(null, array8[m]);
				}
				return;
			}
			}
			if (matrix.Elements is IEncodeable[] array33)
			{
				for (int num24 = 0; num24 < array33.Length; num24++)
				{
					WriteEncodeable(null, array33[num24], null);
				}
				return;
			}
			throw ServiceResultException.Create(2147876864u, "Unexpected type encountered while encoding a Matrix with BuiltInType: {0}", matrix.TypeInfo.BuiltInType);
		}
	}

	private void WriteDiagnosticInfo(string fieldName, DiagnosticInfo value, int depth)
	{
		if (value == null)
		{
			WriteByte(null, 0);
			return;
		}
		CheckAndIncrementNestingLevel();
		try
		{
			byte b = 0;
			if (value.SymbolicId >= 0)
			{
				b |= 1;
			}
			if (value.NamespaceUri >= 0)
			{
				b |= 2;
			}
			if (value.Locale >= 0)
			{
				b |= 8;
			}
			if (value.LocalizedText >= 0)
			{
				b |= 4;
			}
			if (value.AdditionalInfo != null)
			{
				b |= 0x10;
			}
			if (value.InnerStatusCode != 0u)
			{
				b |= 0x20;
			}
			if (value.InnerDiagnosticInfo != null)
			{
				if (depth < DiagnosticInfo.MaxInnerDepth)
				{
					b |= 0x40;
				}
				else
				{
					Utils.LogWarning("InnerDiagnosticInfo dropped because nesting exceeds maximum of {0}.", DiagnosticInfo.MaxInnerDepth);
				}
			}
			WriteByte(null, b);
			if ((b & 1) != 0)
			{
				WriteInt32(null, value.SymbolicId);
			}
			if ((b & 2) != 0)
			{
				WriteInt32(null, value.NamespaceUri);
			}
			if ((b & 8) != 0)
			{
				WriteInt32(null, value.Locale);
			}
			if ((b & 4) != 0)
			{
				WriteInt32(null, value.LocalizedText);
			}
			if ((b & 0x10) != 0)
			{
				WriteString(null, value.AdditionalInfo);
			}
			if ((b & 0x20) != 0)
			{
				WriteStatusCode(null, value.InnerStatusCode);
			}
			if ((b & 0x40) != 0)
			{
				WriteDiagnosticInfo(null, value.InnerDiagnosticInfo, depth + 1);
			}
		}
		finally
		{
			m_nestingLevel--;
		}
	}

	private void WriteObjectArray(string fieldName, IList<object> values)
	{
		if (!WriteArrayLength(values))
		{
			for (int i = 0; i < values.Count; i++)
			{
				WriteVariant(null, new Variant(values[i]));
			}
		}
	}

	private bool WriteArrayLength<T>(ICollection<T> values)
	{
		if (values == null)
		{
			WriteInt32(null, -1);
			return true;
		}
		if (m_context.MaxArrayLength > 0 && m_context.MaxArrayLength < values.Count)
		{
			throw ServiceResultException.Create(2148007936u, "MaxArrayLength {0} < {1}", m_context.MaxArrayLength, values.Count);
		}
		WriteInt32(null, values.Count);
		return values.Count == 0;
	}

	private bool WriteArrayLength(Array values)
	{
		if (values == null)
		{
			WriteInt32(null, -1);
			return true;
		}
		if (m_context.MaxArrayLength > 0 && m_context.MaxArrayLength < values.Length)
		{
			throw ServiceResultException.Create(2148007936u, "MaxArrayLength {0} < {1}", m_context.MaxArrayLength, values.Length);
		}
		WriteInt32(null, values.Length);
		return values.Length == 0;
	}

	private static byte GetNodeIdEncoding(IdType idType, object identifier, uint namespaceIndex)
	{
		NodeIdEncodingBits nodeIdEncodingBits = NodeIdEncodingBits.Numeric;
		switch (idType)
		{
		case IdType.Numeric:
		{
			uint num = Convert.ToUInt32(identifier, CultureInfo.InvariantCulture);
			nodeIdEncodingBits = ((num > 255 || namespaceIndex != 0) ? ((num <= 65535 && namespaceIndex <= 255) ? NodeIdEncodingBits.FourByte : NodeIdEncodingBits.Numeric) : NodeIdEncodingBits.TwoByte);
			break;
		}
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
			throw new ServiceResultException(2147876864u, Utils.Format("NodeId identifier type '{0}' not supported.", idType));
		}
		return Convert.ToByte(nodeIdEncodingBits, CultureInfo.InvariantCulture);
	}

	private void WriteNodeIdBody(byte encoding, object identifier, ushort namespaceIndex)
	{
		switch ((NodeIdEncodingBits)(0x3F & encoding))
		{
		case NodeIdEncodingBits.TwoByte:
			WriteByte(null, Convert.ToByte(identifier, CultureInfo.InvariantCulture));
			break;
		case NodeIdEncodingBits.FourByte:
			WriteByte(null, Convert.ToByte(namespaceIndex));
			WriteUInt16(null, Convert.ToUInt16(identifier, CultureInfo.InvariantCulture));
			break;
		case NodeIdEncodingBits.Numeric:
			WriteUInt16(null, namespaceIndex);
			WriteUInt32(null, Convert.ToUInt32(identifier, CultureInfo.InvariantCulture));
			break;
		case NodeIdEncodingBits.String:
			WriteUInt16(null, namespaceIndex);
			WriteString(null, (string)identifier);
			break;
		case NodeIdEncodingBits.Guid:
			WriteUInt16(null, namespaceIndex);
			WriteGuid(null, new Uuid((Guid)identifier));
			break;
		case NodeIdEncodingBits.ByteString:
			WriteUInt16(null, namespaceIndex);
			WriteByteString(null, (byte[])identifier);
			break;
		}
	}

	private void WriteVariantValue(string fieldName, Variant value)
	{
		if (value.Value == null || value.TypeInfo == null || value.TypeInfo.BuiltInType == BuiltInType.Null)
		{
			WriteByte(null, 0);
			return;
		}
		byte b = (byte)value.TypeInfo.BuiltInType;
		if (value.TypeInfo.BuiltInType == BuiltInType.Enumeration)
		{
			b = 6;
		}
		object obj = value.Value;
		if (value.TypeInfo.ValueRank < 0)
		{
			WriteByte(null, b);
			switch (value.TypeInfo.BuiltInType)
			{
			case BuiltInType.Boolean:
				WriteBoolean(null, (bool)obj);
				return;
			case BuiltInType.SByte:
				WriteSByte(null, (sbyte)obj);
				return;
			case BuiltInType.Byte:
				WriteByte(null, (byte)obj);
				return;
			case BuiltInType.Int16:
				WriteInt16(null, (short)obj);
				return;
			case BuiltInType.UInt16:
				WriteUInt16(null, (ushort)obj);
				return;
			case BuiltInType.Int32:
				WriteInt32(null, (int)obj);
				return;
			case BuiltInType.UInt32:
				WriteUInt32(null, (uint)obj);
				return;
			case BuiltInType.Int64:
				WriteInt64(null, (long)obj);
				return;
			case BuiltInType.UInt64:
				WriteUInt64(null, (ulong)obj);
				return;
			case BuiltInType.Float:
				WriteFloat(null, (float)obj);
				return;
			case BuiltInType.Double:
				WriteDouble(null, (double)obj);
				return;
			case BuiltInType.String:
				WriteString(null, (string)obj);
				return;
			case BuiltInType.DateTime:
				WriteDateTime(null, (DateTime)obj);
				return;
			case BuiltInType.Guid:
				WriteGuid(null, (Uuid)obj);
				return;
			case BuiltInType.ByteString:
				WriteByteString(null, (byte[])obj);
				return;
			case BuiltInType.XmlElement:
				WriteXmlElement(null, (XmlElement)obj);
				return;
			case BuiltInType.NodeId:
				WriteNodeId(null, (NodeId)obj);
				return;
			case BuiltInType.ExpandedNodeId:
				WriteExpandedNodeId(null, (ExpandedNodeId)obj);
				return;
			case BuiltInType.StatusCode:
				WriteStatusCode(null, (StatusCode)obj);
				return;
			case BuiltInType.QualifiedName:
				WriteQualifiedName(null, (QualifiedName)obj);
				return;
			case BuiltInType.LocalizedText:
				WriteLocalizedText(null, (LocalizedText)obj);
				return;
			case BuiltInType.ExtensionObject:
				WriteExtensionObject(null, (ExtensionObject)obj);
				return;
			case BuiltInType.DataValue:
				WriteDataValue(null, (DataValue)obj);
				return;
			case BuiltInType.Enumeration:
				WriteInt32(null, Convert.ToInt32(obj));
				return;
			case BuiltInType.DiagnosticInfo:
				WriteDiagnosticInfo(null, (DiagnosticInfo)obj);
				break;
			}
			throw ServiceResultException.Create(2147876864u, "Unexpected type encountered while encoding a Variant: {0}", value.TypeInfo.BuiltInType);
		}
		if (value.TypeInfo.ValueRank < 0)
		{
			return;
		}
		Matrix matrix = null;
		b |= 0x80;
		if (value.TypeInfo.ValueRank > 1)
		{
			b |= 0x40;
			matrix = (Matrix)obj;
			obj = matrix.Elements;
		}
		WriteByte(null, b);
		switch (value.TypeInfo.BuiltInType)
		{
		case BuiltInType.Boolean:
			WriteBooleanArray(null, (bool[])obj);
			break;
		case BuiltInType.SByte:
			WriteSByteArray(null, (sbyte[])obj);
			break;
		case BuiltInType.Byte:
			WriteByteArray(null, (byte[])obj);
			break;
		case BuiltInType.Int16:
			WriteInt16Array(null, (short[])obj);
			break;
		case BuiltInType.UInt16:
			WriteUInt16Array(null, (ushort[])obj);
			break;
		case BuiltInType.Int32:
			WriteInt32Array(null, (int[])obj);
			break;
		case BuiltInType.UInt32:
			WriteUInt32Array(null, (uint[])obj);
			break;
		case BuiltInType.Int64:
			WriteInt64Array(null, (long[])obj);
			break;
		case BuiltInType.UInt64:
			WriteUInt64Array(null, (ulong[])obj);
			break;
		case BuiltInType.Float:
			WriteFloatArray(null, (float[])obj);
			break;
		case BuiltInType.Double:
			WriteDoubleArray(null, (double[])obj);
			break;
		case BuiltInType.String:
			WriteStringArray(null, (string[])obj);
			break;
		case BuiltInType.DateTime:
			WriteDateTimeArray(null, (DateTime[])obj);
			break;
		case BuiltInType.Guid:
			WriteGuidArray(null, (Uuid[])obj);
			break;
		case BuiltInType.ByteString:
			WriteByteStringArray(null, (byte[][])obj);
			break;
		case BuiltInType.XmlElement:
			WriteXmlElementArray(null, (XmlElement[])obj);
			break;
		case BuiltInType.NodeId:
			WriteNodeIdArray(null, (NodeId[])obj);
			break;
		case BuiltInType.ExpandedNodeId:
			WriteExpandedNodeIdArray(null, (ExpandedNodeId[])obj);
			break;
		case BuiltInType.StatusCode:
			WriteStatusCodeArray(null, (StatusCode[])obj);
			break;
		case BuiltInType.QualifiedName:
			WriteQualifiedNameArray(null, (QualifiedName[])obj);
			break;
		case BuiltInType.LocalizedText:
			WriteLocalizedTextArray(null, (LocalizedText[])obj);
			break;
		case BuiltInType.ExtensionObject:
			WriteExtensionObjectArray(null, (ExtensionObject[])obj);
			break;
		case BuiltInType.DataValue:
			WriteDataValueArray(null, (DataValue[])obj);
			break;
		case BuiltInType.Enumeration:
		{
			int[] array = obj as int[];
			if (array == null)
			{
				if (!(obj is Enum[] array2))
				{
					throw new ServiceResultException(2147876864u, Utils.Format("Type '{0}' is not allowed in an Enumeration.", value.GetType().FullName));
				}
				array = new int[array2.Length];
				for (int i = 0; i < array2.Length; i++)
				{
					array[i] = (int)(object)array2[i];
				}
			}
			WriteInt32Array(null, array);
			break;
		}
		case BuiltInType.Variant:
			if (obj is Variant[] values)
			{
				WriteVariantArray(null, values);
				break;
			}
			if (obj is object[] values2)
			{
				WriteObjectArray(null, values2);
				break;
			}
			throw ServiceResultException.Create(2147876864u, "Unexpected type encountered while encoding a Matrix: {0}", obj.GetType());
		case BuiltInType.DiagnosticInfo:
			WriteDiagnosticInfoArray(null, (DiagnosticInfo[])obj);
			break;
		default:
			throw ServiceResultException.Create(2147876864u, "Unexpected type encountered while encoding a Variant: {0}", value.TypeInfo.BuiltInType);
		}
		if (value.TypeInfo.ValueRank > 1)
		{
			WriteInt32Array(null, matrix.Dimensions);
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
