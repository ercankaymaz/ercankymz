using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;
using Newtonsoft.Json;

namespace Opc.Ua;

[ComVisible(true)]
public class JsonDecoder : IJsonDecoder, IDecoder, IDisposable
{
	private enum JTokenNullObject
	{
		Undefined,
		Object,
		Array
	}

	public const string RootArrayName = "___root_array___";

	private JsonTextReader m_reader;

	private Dictionary<string, object> m_root;

	private Stack<object> m_stack;

	private IServiceMessageContext m_context;

	private ushort[] m_namespaceMappings;

	private ushort[] m_serverMappings;

	private uint m_nestingLevel;

	private DateTime m_dateTimeMaxJsonValue = new DateTime(3155378975990000000L);

	public EncodingType EncodingType => EncodingType.Json;

	public IServiceMessageContext Context => m_context;

	public JsonDecoder(string json, IServiceMessageContext context)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		Initialize();
		m_context = context;
		m_nestingLevel = 0u;
		m_reader = new JsonTextReader(new StringReader(json));
		m_root = ReadObject();
		m_stack = new Stack<object>();
		m_stack.Push(m_root);
	}

	public JsonDecoder(Type systemType, JsonTextReader reader, IServiceMessageContext context)
	{
		Initialize();
		m_context = context;
		m_nestingLevel = 0u;
		m_reader = reader;
		m_root = ReadObject();
		m_stack = new Stack<object>();
		m_stack.Push(m_root);
	}

	private void Initialize()
	{
		m_reader = null;
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
		using IJsonDecoder decoder = new JsonDecoder(Encoding.UTF8.GetString(buffer), context);
		SessionLessServiceMessage sessionLessServiceMessage = new SessionLessServiceMessage();
		sessionLessServiceMessage.Decode(decoder);
		return sessionLessServiceMessage.Message;
	}

	public static IEncodeable DecodeMessage(byte[] buffer, Type expectedType, IServiceMessageContext context)
	{
		return DecodeMessage(new ArraySegment<byte>(buffer), expectedType, context);
	}

	public static IEncodeable DecodeMessage(ArraySegment<byte> buffer, Type expectedType, IServiceMessageContext context)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		if (context.MaxMessageSize > 0 && context.MaxMessageSize < buffer.Count)
		{
			throw ServiceResultException.Create(2148007936u, "MaxMessageSize {0} < {1}", context.MaxMessageSize, buffer.Count);
		}
		using JsonDecoder jsonDecoder = new JsonDecoder(Encoding.UTF8.GetString(buffer.Array, buffer.Offset, buffer.Count), context);
		return jsonDecoder.DecodeMessage(expectedType);
	}

	public IEncodeable DecodeMessage(Type expectedType)
	{
		StringCollection stringCollection = ReadStringArray("NamespaceUris");
		StringCollection stringCollection2 = ReadStringArray("ServerUris");
		if ((stringCollection != null && stringCollection.Count > 0) || (stringCollection2 != null && stringCollection2.Count > 0))
		{
			NamespaceTable namespaceUris = ((stringCollection == null || stringCollection.Count == 0) ? m_context.NamespaceUris : new NamespaceTable(stringCollection));
			StringTable serverUris = ((stringCollection2 == null || stringCollection2.Count == 0) ? m_context.ServerUris : new StringTable(stringCollection2));
			SetMappingTables(namespaceUris, serverUris);
		}
		ExpandedNodeId expandedNodeId = NodeId.ToExpandedNodeId(ReadNodeId("TypeId"), m_context.NamespaceUris);
		Type systemType = m_context.Factory.GetSystemType(expandedNodeId);
		if (systemType == null)
		{
			throw new ServiceResultException(2147942400u, Utils.Format("Cannot decode message with type id: {0}.", expandedNodeId));
		}
		return ReadEncodeable("Body", systemType, expandedNodeId);
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
		m_reader.Close();
	}

	public void Close(bool checkEof)
	{
		if (checkEof && m_reader.TokenType != JsonToken.EndObject)
		{
			while (m_reader.Read() && m_reader.TokenType != JsonToken.EndObject)
			{
			}
		}
		m_reader.Close();
	}

	public object ReadExtensionObjectBody(ExpandedNodeId typeId)
	{
		return null;
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
			m_reader.Close();
			m_reader = null;
		}
	}

	public void PushNamespace(string namespaceUri)
	{
	}

	public void PopNamespace()
	{
	}

	public bool ReadField(string fieldName, out object token)
	{
		token = null;
		if (string.IsNullOrEmpty(fieldName))
		{
			token = m_stack.Peek();
			return true;
		}
		if (!(m_stack.Peek() is Dictionary<string, object> dictionary) || !dictionary.TryGetValue(fieldName, out token))
		{
			return false;
		}
		return true;
	}

	public bool ReadBoolean(string fieldName)
	{
		object token = null;
		if (!ReadField(fieldName, out token))
		{
			return false;
		}
		if (!(token as bool?).HasValue)
		{
			return false;
		}
		return (bool)token;
	}

	public sbyte ReadSByte(string fieldName)
	{
		object token = null;
		if (!ReadField(fieldName, out token))
		{
			return 0;
		}
		long? num = token as long?;
		if (!num.HasValue)
		{
			return 0;
		}
		if (num < -128 || num > 127)
		{
			return 0;
		}
		return (sbyte)num.Value;
	}

	public byte ReadByte(string fieldName)
	{
		object token = null;
		if (!ReadField(fieldName, out token))
		{
			return 0;
		}
		long? num = token as long?;
		if (!num.HasValue)
		{
			return 0;
		}
		if (num < 0 || num > 255u)
		{
			return 0;
		}
		return (byte)num.Value;
	}

	public short ReadInt16(string fieldName)
	{
		object token = null;
		if (!ReadField(fieldName, out token))
		{
			return 0;
		}
		long? num = token as long?;
		if (!num.HasValue)
		{
			return 0;
		}
		if (num < -32768 || num > 32767)
		{
			return 0;
		}
		return (short)num.Value;
	}

	public ushort ReadUInt16(string fieldName)
	{
		object token = null;
		if (!ReadField(fieldName, out token))
		{
			return 0;
		}
		long? num = token as long?;
		if (!num.HasValue)
		{
			return 0;
		}
		if (num < 0 || num > 65535u)
		{
			return 0;
		}
		return (ushort)num.Value;
	}

	public int ReadInt32(string fieldName)
	{
		object token = null;
		if (!ReadField(fieldName, out token))
		{
			return 0;
		}
		long? num = token as long?;
		if (!num.HasValue)
		{
			return 0;
		}
		if (num < int.MinValue || num > int.MaxValue)
		{
			return 0;
		}
		return (int)num.Value;
	}

	public uint ReadUInt32(string fieldName)
	{
		object token = null;
		if (!ReadField(fieldName, out token))
		{
			return 0u;
		}
		long? num = token as long?;
		if (!num.HasValue)
		{
			uint result = 0u;
			if (!(token is string s) || !uint.TryParse(s, NumberStyles.Integer, CultureInfo.InvariantCulture, out result))
			{
				return 0u;
			}
			return result;
		}
		if (num < 0 || num > uint.MaxValue)
		{
			return 0u;
		}
		return (uint)num.Value;
	}

	public long ReadInt64(string fieldName)
	{
		object token = null;
		if (!ReadField(fieldName, out token))
		{
			return 0L;
		}
		long? num = token as long?;
		if (!num.HasValue)
		{
			long result = 0L;
			if (!(token is string s) || !long.TryParse(s, NumberStyles.Integer, CultureInfo.InvariantCulture, out result))
			{
				return 0L;
			}
			return result;
		}
		if (num < long.MinValue || num > long.MaxValue)
		{
			return 0L;
		}
		return num.Value;
	}

	public ulong ReadUInt64(string fieldName)
	{
		object token = null;
		if (!ReadField(fieldName, out token))
		{
			return 0uL;
		}
		long? num = token as long?;
		if (!num.HasValue)
		{
			ulong result = 0uL;
			if (!(token is string s) || !ulong.TryParse(s, NumberStyles.Integer, CultureInfo.InvariantCulture, out result))
			{
				return 0uL;
			}
			return result;
		}
		if (num < 0)
		{
			return 0uL;
		}
		return (ulong)num.Value;
	}

	public float ReadFloat(string fieldName)
	{
		object token = null;
		if (!ReadField(fieldName, out token))
		{
			return 0f;
		}
		double? num = token as double?;
		if (!num.HasValue)
		{
			string text = token as string;
			float result = 0f;
			if (text == null || !float.TryParse(text, NumberStyles.Float, CultureInfo.InvariantCulture, out result))
			{
				if (text != null)
				{
					if (string.Equals(text, "Infinity", StringComparison.OrdinalIgnoreCase))
					{
						return float.PositiveInfinity;
					}
					if (string.Equals(text, "-Infinity", StringComparison.OrdinalIgnoreCase))
					{
						return float.NegativeInfinity;
					}
					if (string.Equals(text, "NaN", StringComparison.OrdinalIgnoreCase))
					{
						return float.NaN;
					}
				}
				long? num2 = token as long?;
				if (!num2.HasValue)
				{
					return 0f;
				}
				return num2.Value;
			}
			return result;
		}
		float num3 = (float)num.Value;
		if (num3 >= float.MinValue && num3 <= float.MaxValue)
		{
			return (float)num.Value;
		}
		return 0f;
	}

	public double ReadDouble(string fieldName)
	{
		object token = null;
		if (!ReadField(fieldName, out token))
		{
			return 0.0;
		}
		double? num = token as double?;
		if (!num.HasValue)
		{
			string text = token as string;
			double result = 0.0;
			if (text == null || !double.TryParse(text, NumberStyles.Float, CultureInfo.InvariantCulture, out result))
			{
				if (text != null)
				{
					if (string.Equals(text, "Infinity", StringComparison.OrdinalIgnoreCase))
					{
						return double.PositiveInfinity;
					}
					if (string.Equals(text, "-Infinity", StringComparison.OrdinalIgnoreCase))
					{
						return double.NegativeInfinity;
					}
					if (string.Equals(text, "NaN", StringComparison.OrdinalIgnoreCase))
					{
						return double.NaN;
					}
				}
				long? num2 = token as long?;
				if (!num2.HasValue)
				{
					return 0.0;
				}
				return num2.Value;
			}
			return result;
		}
		return num.Value;
	}

	public string ReadString(string fieldName)
	{
		object token = null;
		if (!ReadField(fieldName, out token))
		{
			return null;
		}
		if (!(token is string text))
		{
			return null;
		}
		if (m_context.MaxStringLength > 0 && m_context.MaxStringLength < text.Length)
		{
			throw new ServiceResultException(2148007936u);
		}
		return text;
	}

	public DateTime ReadDateTime(string fieldName)
	{
		object token = null;
		if (!ReadField(fieldName, out token))
		{
			return DateTime.MinValue;
		}
		DateTime? dateTime = token as DateTime?;
		if (dateTime.HasValue)
		{
			if (!(dateTime.Value >= m_dateTimeMaxJsonValue))
			{
				return dateTime.Value;
			}
			return DateTime.MaxValue;
		}
		if (token is string s)
		{
			DateTime dateTime2 = XmlConvert.ToDateTime(s, XmlDateTimeSerializationMode.Utc);
			if (!(dateTime2 >= m_dateTimeMaxJsonValue))
			{
				return dateTime2;
			}
			return DateTime.MaxValue;
		}
		return DateTime.MinValue;
	}

	public Uuid ReadGuid(string fieldName)
	{
		object token = null;
		if (!ReadField(fieldName, out token))
		{
			return Uuid.Empty;
		}
		if (!(token is string text))
		{
			return Uuid.Empty;
		}
		return new Uuid(text);
	}

	public byte[] ReadByteString(string fieldName)
	{
		object token = null;
		if (!ReadField(fieldName, out token))
		{
			return null;
		}
		if (token is JTokenNullObject)
		{
			return null;
		}
		if (!(token is string s))
		{
			return Array.Empty<byte>();
		}
		byte[] array = Convert.FromBase64String(s);
		if (m_context.MaxByteStringLength > 0 && m_context.MaxByteStringLength < array.Length)
		{
			throw new ServiceResultException(2148007936u);
		}
		return array;
	}

	public XmlElement ReadXmlElement(string fieldName)
	{
		object token = null;
		if (!ReadField(fieldName, out token))
		{
			return null;
		}
		if (!(token is string s))
		{
			return null;
		}
		byte[] array = Convert.FromBase64String(s);
		if (array != null && array.Length != 0)
		{
			XmlDocument xmlDocument = new XmlDocument();
			using (XmlReader reader = XmlReader.Create(new StringReader(Encoding.UTF8.GetString(array, 0, array.Length)), Utils.DefaultXmlReaderSettings()))
			{
				xmlDocument.Load(reader);
			}
			return xmlDocument.DocumentElement;
		}
		return null;
	}

	public NodeId ReadNodeId(string fieldName)
	{
		object token = null;
		if (!ReadField(fieldName, out token))
		{
			return NodeId.Null;
		}
		if (!(token is Dictionary<string, object> dictionary))
		{
			return NodeId.Null;
		}
		IdType idType = IdType.Numeric;
		ushort namespaceIndex = 0;
		try
		{
			m_stack.Push(dictionary);
			if (dictionary.ContainsKey("IdType"))
			{
				idType = (IdType)ReadInt32("IdType");
			}
			object token2 = null;
			if (ReadField("Namespace", out token2))
			{
				long? num = token2 as long?;
				if (!num.HasValue)
				{
					if (token2 is string value)
					{
						namespaceIndex = m_context.NamespaceUris.GetIndexOrAppend(value);
					}
				}
				else if (num.Value >= 0 || num.Value < 65535)
				{
					namespaceIndex = (ushort)num.Value;
				}
			}
			if (dictionary.ContainsKey("Id"))
			{
				return idType switch
				{
					IdType.Opaque => new NodeId(ReadByteString("Id"), namespaceIndex), 
					IdType.String => new NodeId(ReadString("Id"), namespaceIndex), 
					IdType.Guid => new NodeId(ReadGuid("Id"), namespaceIndex), 
					_ => new NodeId(ReadUInt32("Id"), namespaceIndex), 
				};
			}
			return DefaultNodeId(idType, namespaceIndex);
		}
		finally
		{
			m_stack.Pop();
		}
	}

	public ExpandedNodeId ReadExpandedNodeId(string fieldName)
	{
		object token = null;
		if (!ReadField(fieldName, out token))
		{
			return ExpandedNodeId.Null;
		}
		if (!(token is Dictionary<string, object> dictionary))
		{
			return ExpandedNodeId.Null;
		}
		IdType idType = IdType.Numeric;
		ushort namespaceIndex = 0;
		string namespaceUri = null;
		uint serverIndex = 0u;
		try
		{
			m_stack.Push(dictionary);
			if (dictionary.ContainsKey("IdType"))
			{
				idType = (IdType)ReadInt32("IdType");
			}
			object token2 = null;
			if (ReadField("Namespace", out token2))
			{
				long? num = token2 as long?;
				if (!num.HasValue)
				{
					namespaceUri = token2 as string;
				}
				else if (num.Value >= 0 || num.Value < 65535)
				{
					namespaceIndex = (ushort)num.Value;
				}
			}
			if (dictionary.ContainsKey("ServerUri"))
			{
				serverIndex = ReadUInt32("ServerUri");
			}
			if (dictionary.ContainsKey("Id"))
			{
				return idType switch
				{
					IdType.Opaque => new ExpandedNodeId(ReadByteString("Id"), namespaceIndex, namespaceUri, serverIndex), 
					IdType.String => new ExpandedNodeId(ReadString("Id"), namespaceIndex, namespaceUri, serverIndex), 
					IdType.Guid => new ExpandedNodeId(ReadGuid("Id"), namespaceIndex, namespaceUri, serverIndex), 
					_ => new ExpandedNodeId(ReadUInt32("Id"), namespaceIndex, namespaceUri, serverIndex), 
				};
			}
			return new ExpandedNodeId(DefaultNodeId(idType, namespaceIndex), namespaceUri, serverIndex);
		}
		finally
		{
			m_stack.Pop();
		}
	}

	public StatusCode ReadStatusCode(string fieldName)
	{
		if (!ReadField(fieldName, out var token))
		{
			return 0u;
		}
		bool flag = PushStructure(fieldName);
		try
		{
			if (ReadField("Code", out token))
			{
				return ReadUInt32("Code");
			}
			return ReadUInt32(null);
		}
		finally
		{
			if (flag)
			{
				Pop();
			}
		}
	}

	public DiagnosticInfo ReadDiagnosticInfo(string fieldName)
	{
		return ReadDiagnosticInfo(fieldName, 0);
	}

	public QualifiedName ReadQualifiedName(string fieldName)
	{
		object token = null;
		if (!ReadField(fieldName, out token))
		{
			return QualifiedName.Null;
		}
		if (!(token is Dictionary<string, object> dictionary))
		{
			return QualifiedName.Null;
		}
		ushort namespaceIndex = 0;
		string name = null;
		try
		{
			m_stack.Push(dictionary);
			if (dictionary.ContainsKey("Name"))
			{
				name = ReadString("Name");
			}
			object token2 = null;
			if (ReadField("Uri", out token2))
			{
				long? num = token2 as long?;
				if (!num.HasValue)
				{
					if (token2 is string value)
					{
						namespaceIndex = m_context.NamespaceUris.GetIndexOrAppend(value);
					}
				}
				else if (num.Value >= 0 || num.Value < 65535)
				{
					namespaceIndex = (ushort)num.Value;
				}
			}
		}
		finally
		{
			m_stack.Pop();
		}
		return new QualifiedName(name, namespaceIndex);
	}

	public LocalizedText ReadLocalizedText(string fieldName)
	{
		object token = null;
		if (!ReadField(fieldName, out token))
		{
			return LocalizedText.Null;
		}
		string locale = null;
		string text = null;
		if (!(token is Dictionary<string, object> dictionary))
		{
			if (token is string text2)
			{
				return new LocalizedText(text2);
			}
			return LocalizedText.Null;
		}
		try
		{
			m_stack.Push(dictionary);
			if (dictionary.ContainsKey("Locale"))
			{
				locale = ReadString("Locale");
			}
			if (dictionary.ContainsKey("Text"))
			{
				text = ReadString("Text");
			}
		}
		finally
		{
			m_stack.Pop();
		}
		return new LocalizedText(locale, text);
	}

	public Variant ReadVariant(string fieldName)
	{
		object token = null;
		if (!ReadField(fieldName, out token))
		{
			return Variant.Null;
		}
		if (!(token is Dictionary<string, object> item))
		{
			return Variant.Null;
		}
		CheckAndIncrementNestingLevel();
		try
		{
			m_stack.Push(item);
			BuiltInType builtInType = (BuiltInType)ReadByte("Type");
			if (!(m_stack.Peek() as Dictionary<string, object>).TryGetValue("Body", out token))
			{
				return Variant.Null;
			}
			Variant result;
			if (token is Array)
			{
				result = ReadVariantBody("Body", builtInType);
			}
			else
			{
				if (!(token is List<object>))
				{
					return ReadVariantBody("Body", builtInType);
				}
				result = ReadVariantArrayBody("Body", builtInType);
			}
			Int32Collection int32Collection = ReadInt32Array("Dimensions");
			if (result.Value is Array && int32Collection != null && int32Collection.Count > 1)
			{
				result = new Variant(new Matrix((Array)result.Value, builtInType, int32Collection.ToArray()));
			}
			return result;
		}
		finally
		{
			m_nestingLevel--;
			m_stack.Pop();
		}
	}

	public DataValue ReadDataValue(string fieldName)
	{
		object token = null;
		if (!ReadField(fieldName, out token))
		{
			return null;
		}
		if (!(token is Dictionary<string, object> item))
		{
			return null;
		}
		DataValue dataValue = new DataValue();
		try
		{
			m_stack.Push(item);
			dataValue.WrappedValue = ReadVariant("Value");
			dataValue.StatusCode = ReadStatusCode("StatusCode");
			dataValue.SourceTimestamp = ReadDateTime("SourceTimestamp");
			dataValue.SourcePicoseconds = ReadUInt16("SourcePicoseconds");
			dataValue.ServerTimestamp = ReadDateTime("ServerTimestamp");
			dataValue.ServerPicoseconds = ReadUInt16("ServerPicoseconds");
			return dataValue;
		}
		finally
		{
			m_stack.Pop();
		}
	}

	public ExtensionObject ReadExtensionObject(string fieldName)
	{
		ExtensionObject result = ExtensionObject.Null;
		object token = null;
		if (!ReadField(fieldName, out token))
		{
			return result;
		}
		if (!(token is Dictionary<string, object> item))
		{
			return result;
		}
		try
		{
			m_stack.Push(item);
			ExpandedNodeId expandedNodeId = ReadExpandedNodeId("TypeId");
			ExpandedNodeId expandedNodeId2 = (expandedNodeId.IsAbsolute ? expandedNodeId : NodeId.ToExpandedNodeId(expandedNodeId.InnerNodeId, m_context.NamespaceUris));
			if (!NodeId.IsNull(expandedNodeId) && NodeId.IsNull(expandedNodeId2))
			{
				Utils.LogWarning("Cannot de-serialized extension objects if the NamespaceUri is not in the NamespaceTable: Type = {0}", expandedNodeId);
			}
			else
			{
				expandedNodeId = expandedNodeId2;
			}
			switch (ReadByte("Encoding"))
			{
			case 1:
			{
				byte[] array = ReadByteString("Body");
				return new ExtensionObject(expandedNodeId, array ?? Array.Empty<byte>());
			}
			case 2:
			{
				XmlElement xmlElement = ReadXmlElement("Body");
				if (xmlElement == null)
				{
					return result;
				}
				return new ExtensionObject(expandedNodeId, xmlElement);
			}
			case 4:
			{
				string text = ReadString("Body");
				if (string.IsNullOrEmpty(text))
				{
					return result;
				}
				return new ExtensionObject(expandedNodeId, text);
			}
			default:
			{
				Type systemType = m_context.Factory.GetSystemType(expandedNodeId);
				if (systemType != null)
				{
					IEncodeable encodeable = ReadEncodeable("Body", systemType, expandedNodeId);
					if (encodeable == null)
					{
						return result;
					}
					return new ExtensionObject(expandedNodeId, encodeable);
				}
				using MemoryStream memoryStream = new MemoryStream();
				using (StreamWriter textWriter = new StreamWriter(memoryStream))
				{
					using JsonTextWriter writer = new JsonTextWriter(textWriter);
					EncodeAsJson(writer, token);
				}
				return new ExtensionObject(expandedNodeId, memoryStream.ToArray());
			}
			}
		}
		finally
		{
			m_stack.Pop();
		}
	}

	public IEncodeable ReadEncodeable(string fieldName, Type systemType, ExpandedNodeId encodeableTypeId = null)
	{
		if (systemType == null)
		{
			throw new ArgumentNullException("systemType");
		}
		object token = null;
		if (!ReadField(fieldName, out token))
		{
			return null;
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
			m_stack.Push(token);
			encodeable.Decode(this);
			return encodeable;
		}
		finally
		{
			m_stack.Pop();
			m_nestingLevel--;
		}
	}

	public Enum ReadEnumerated(string fieldName, Type enumType)
	{
		if (enumType == null)
		{
			throw new ArgumentNullException("enumType");
		}
		return (Enum)Enum.ToObject(enumType, ReadInt32(fieldName));
	}

	public BooleanCollection ReadBooleanArray(string fieldName)
	{
		BooleanCollection booleanCollection = new BooleanCollection();
		List<object> array = null;
		if (!ReadArrayField(fieldName, out array))
		{
			return booleanCollection;
		}
		for (int i = 0; i < array.Count; i++)
		{
			try
			{
				m_stack.Push(array[i]);
				booleanCollection.Add(ReadBoolean(null));
			}
			finally
			{
				m_stack.Pop();
			}
		}
		return booleanCollection;
	}

	public SByteCollection ReadSByteArray(string fieldName)
	{
		SByteCollection sByteCollection = new SByteCollection();
		List<object> array = null;
		if (!ReadArrayField(fieldName, out array))
		{
			return sByteCollection;
		}
		for (int i = 0; i < array.Count; i++)
		{
			try
			{
				m_stack.Push(array[i]);
				sByteCollection.Add(ReadSByte(null));
			}
			finally
			{
				m_stack.Pop();
			}
		}
		return sByteCollection;
	}

	public ByteCollection ReadByteArray(string fieldName)
	{
		ByteCollection byteCollection = new ByteCollection();
		List<object> array = null;
		string text = ReadString(fieldName);
		if (text != null)
		{
			return Convert.FromBase64String(text);
		}
		if (!ReadArrayField(fieldName, out array))
		{
			return byteCollection;
		}
		for (int i = 0; i < array.Count; i++)
		{
			try
			{
				m_stack.Push(array[i]);
				byteCollection.Add(ReadByte(null));
			}
			finally
			{
				m_stack.Pop();
			}
		}
		return byteCollection;
	}

	public Int16Collection ReadInt16Array(string fieldName)
	{
		Int16Collection int16Collection = new Int16Collection();
		List<object> array = null;
		if (!ReadArrayField(fieldName, out array))
		{
			return int16Collection;
		}
		for (int i = 0; i < array.Count; i++)
		{
			try
			{
				m_stack.Push(array[i]);
				int16Collection.Add(ReadInt16(null));
			}
			finally
			{
				m_stack.Pop();
			}
		}
		return int16Collection;
	}

	public UInt16Collection ReadUInt16Array(string fieldName)
	{
		UInt16Collection uInt16Collection = new UInt16Collection();
		List<object> array = null;
		if (!ReadArrayField(fieldName, out array))
		{
			return uInt16Collection;
		}
		for (int i = 0; i < array.Count; i++)
		{
			try
			{
				m_stack.Push(array[i]);
				uInt16Collection.Add(ReadUInt16(null));
			}
			finally
			{
				m_stack.Pop();
			}
		}
		return uInt16Collection;
	}

	public Int32Collection ReadInt32Array(string fieldName)
	{
		Int32Collection int32Collection = new Int32Collection();
		List<object> array = null;
		if (!ReadArrayField(fieldName, out array))
		{
			return int32Collection;
		}
		for (int i = 0; i < array.Count; i++)
		{
			try
			{
				m_stack.Push(array[i]);
				int32Collection.Add(ReadInt32(null));
			}
			finally
			{
				m_stack.Pop();
			}
		}
		return int32Collection;
	}

	public UInt32Collection ReadUInt32Array(string fieldName)
	{
		UInt32Collection uInt32Collection = new UInt32Collection();
		List<object> array = null;
		if (!ReadArrayField(fieldName, out array))
		{
			return uInt32Collection;
		}
		for (int i = 0; i < array.Count; i++)
		{
			try
			{
				m_stack.Push(array[i]);
				uInt32Collection.Add(ReadUInt32(null));
			}
			finally
			{
				m_stack.Pop();
			}
		}
		return uInt32Collection;
	}

	public Int64Collection ReadInt64Array(string fieldName)
	{
		Int64Collection int64Collection = new Int64Collection();
		List<object> array = null;
		if (!ReadArrayField(fieldName, out array))
		{
			return int64Collection;
		}
		for (int i = 0; i < array.Count; i++)
		{
			try
			{
				m_stack.Push(array[i]);
				int64Collection.Add(ReadInt64(null));
			}
			finally
			{
				m_stack.Pop();
			}
		}
		return int64Collection;
	}

	public UInt64Collection ReadUInt64Array(string fieldName)
	{
		UInt64Collection uInt64Collection = new UInt64Collection();
		List<object> array = null;
		if (!ReadArrayField(fieldName, out array))
		{
			return uInt64Collection;
		}
		for (int i = 0; i < array.Count; i++)
		{
			try
			{
				m_stack.Push(array[i]);
				uInt64Collection.Add(ReadUInt64(null));
			}
			finally
			{
				m_stack.Pop();
			}
		}
		return uInt64Collection;
	}

	public FloatCollection ReadFloatArray(string fieldName)
	{
		FloatCollection floatCollection = new FloatCollection();
		List<object> array = null;
		if (!ReadArrayField(fieldName, out array))
		{
			return floatCollection;
		}
		for (int i = 0; i < array.Count; i++)
		{
			try
			{
				m_stack.Push(array[i]);
				floatCollection.Add(ReadFloat(null));
			}
			finally
			{
				m_stack.Pop();
			}
		}
		return floatCollection;
	}

	public DoubleCollection ReadDoubleArray(string fieldName)
	{
		DoubleCollection doubleCollection = new DoubleCollection();
		List<object> array = null;
		if (!ReadArrayField(fieldName, out array))
		{
			return doubleCollection;
		}
		for (int i = 0; i < array.Count; i++)
		{
			try
			{
				m_stack.Push(array[i]);
				doubleCollection.Add(ReadDouble(null));
			}
			finally
			{
				m_stack.Pop();
			}
		}
		return doubleCollection;
	}

	public StringCollection ReadStringArray(string fieldName)
	{
		StringCollection stringCollection = new StringCollection();
		List<object> array = null;
		if (!ReadArrayField(fieldName, out array))
		{
			return stringCollection;
		}
		for (int i = 0; i < array.Count; i++)
		{
			try
			{
				m_stack.Push(array[i]);
				stringCollection.Add(ReadString(null));
			}
			finally
			{
				m_stack.Pop();
			}
		}
		return stringCollection;
	}

	public DateTimeCollection ReadDateTimeArray(string fieldName)
	{
		DateTimeCollection dateTimeCollection = new DateTimeCollection();
		List<object> array = null;
		if (!ReadArrayField(fieldName, out array))
		{
			return dateTimeCollection;
		}
		for (int i = 0; i < array.Count; i++)
		{
			try
			{
				m_stack.Push(array[i]);
				dateTimeCollection.Add(ReadDateTime(null));
			}
			finally
			{
				m_stack.Pop();
			}
		}
		return dateTimeCollection;
	}

	public UuidCollection ReadGuidArray(string fieldName)
	{
		UuidCollection uuidCollection = new UuidCollection();
		List<object> array = null;
		if (!ReadArrayField(fieldName, out array))
		{
			return uuidCollection;
		}
		for (int i = 0; i < array.Count; i++)
		{
			try
			{
				m_stack.Push(array[i]);
				Uuid item = ReadGuid(null);
				uuidCollection.Add(item);
			}
			finally
			{
				m_stack.Pop();
			}
		}
		return uuidCollection;
	}

	public ByteStringCollection ReadByteStringArray(string fieldName)
	{
		ByteStringCollection byteStringCollection = new ByteStringCollection();
		List<object> array = null;
		if (!ReadArrayField(fieldName, out array))
		{
			return byteStringCollection;
		}
		for (int i = 0; i < array.Count; i++)
		{
			try
			{
				m_stack.Push(array[i]);
				byte[] item = ReadByteString(null);
				byteStringCollection.Add(item);
			}
			finally
			{
				m_stack.Pop();
			}
		}
		return byteStringCollection;
	}

	public XmlElementCollection ReadXmlElementArray(string fieldName)
	{
		XmlElementCollection xmlElementCollection = new XmlElementCollection();
		List<object> array = null;
		if (!ReadArrayField(fieldName, out array))
		{
			return xmlElementCollection;
		}
		for (int i = 0; i < array.Count; i++)
		{
			try
			{
				m_stack.Push(array[i]);
				XmlElement item = ReadXmlElement(null);
				xmlElementCollection.Add(item);
			}
			finally
			{
				m_stack.Pop();
			}
		}
		return xmlElementCollection;
	}

	public NodeIdCollection ReadNodeIdArray(string fieldName)
	{
		NodeIdCollection nodeIdCollection = new NodeIdCollection();
		List<object> array = null;
		if (!ReadArrayField(fieldName, out array))
		{
			return nodeIdCollection;
		}
		for (int i = 0; i < array.Count; i++)
		{
			try
			{
				m_stack.Push(array[i]);
				NodeId item = ReadNodeId(null);
				nodeIdCollection.Add(item);
			}
			finally
			{
				m_stack.Pop();
			}
		}
		return nodeIdCollection;
	}

	public ExpandedNodeIdCollection ReadExpandedNodeIdArray(string fieldName)
	{
		ExpandedNodeIdCollection expandedNodeIdCollection = new ExpandedNodeIdCollection();
		List<object> array = null;
		if (!ReadArrayField(fieldName, out array))
		{
			return expandedNodeIdCollection;
		}
		for (int i = 0; i < array.Count; i++)
		{
			try
			{
				m_stack.Push(array[i]);
				ExpandedNodeId item = ReadExpandedNodeId(null);
				expandedNodeIdCollection.Add(item);
			}
			finally
			{
				m_stack.Pop();
			}
		}
		return expandedNodeIdCollection;
	}

	public StatusCodeCollection ReadStatusCodeArray(string fieldName)
	{
		StatusCodeCollection statusCodeCollection = new StatusCodeCollection();
		List<object> array = null;
		if (!ReadArrayField(fieldName, out array))
		{
			return statusCodeCollection;
		}
		for (int i = 0; i < array.Count; i++)
		{
			try
			{
				m_stack.Push(array[i]);
				StatusCode item = ReadStatusCode(null);
				statusCodeCollection.Add(item);
			}
			finally
			{
				m_stack.Pop();
			}
		}
		return statusCodeCollection;
	}

	public DiagnosticInfoCollection ReadDiagnosticInfoArray(string fieldName)
	{
		DiagnosticInfoCollection diagnosticInfoCollection = new DiagnosticInfoCollection();
		List<object> array = null;
		if (!ReadArrayField(fieldName, out array))
		{
			return diagnosticInfoCollection;
		}
		for (int i = 0; i < array.Count; i++)
		{
			try
			{
				m_stack.Push(array[i]);
				DiagnosticInfo item = ReadDiagnosticInfo(null);
				diagnosticInfoCollection.Add(item);
			}
			finally
			{
				m_stack.Pop();
			}
		}
		return diagnosticInfoCollection;
	}

	public QualifiedNameCollection ReadQualifiedNameArray(string fieldName)
	{
		QualifiedNameCollection qualifiedNameCollection = new QualifiedNameCollection();
		List<object> array = null;
		if (!ReadArrayField(fieldName, out array))
		{
			return qualifiedNameCollection;
		}
		for (int i = 0; i < array.Count; i++)
		{
			try
			{
				m_stack.Push(array[i]);
				QualifiedName item = ReadQualifiedName(null);
				qualifiedNameCollection.Add(item);
			}
			finally
			{
				m_stack.Pop();
			}
		}
		return qualifiedNameCollection;
	}

	public LocalizedTextCollection ReadLocalizedTextArray(string fieldName)
	{
		LocalizedTextCollection localizedTextCollection = new LocalizedTextCollection();
		List<object> array = null;
		if (!ReadArrayField(fieldName, out array))
		{
			return localizedTextCollection;
		}
		for (int i = 0; i < array.Count; i++)
		{
			try
			{
				m_stack.Push(array[i]);
				LocalizedText item = ReadLocalizedText(null);
				localizedTextCollection.Add(item);
			}
			finally
			{
				m_stack.Pop();
			}
		}
		return localizedTextCollection;
	}

	public VariantCollection ReadVariantArray(string fieldName)
	{
		VariantCollection variantCollection = new VariantCollection();
		List<object> array = null;
		if (!ReadArrayField(fieldName, out array))
		{
			return variantCollection;
		}
		for (int i = 0; i < array.Count; i++)
		{
			try
			{
				m_stack.Push(array[i]);
				Variant item = ReadVariant(null);
				variantCollection.Add(item);
			}
			finally
			{
				m_stack.Pop();
			}
		}
		return variantCollection;
	}

	public DataValueCollection ReadDataValueArray(string fieldName)
	{
		DataValueCollection dataValueCollection = new DataValueCollection();
		List<object> array = null;
		if (!ReadArrayField(fieldName, out array))
		{
			return dataValueCollection;
		}
		for (int i = 0; i < array.Count; i++)
		{
			try
			{
				m_stack.Push(array[i]);
				DataValue item = ReadDataValue(null);
				dataValueCollection.Add(item);
			}
			finally
			{
				m_stack.Pop();
			}
		}
		return dataValueCollection;
	}

	public ExtensionObjectCollection ReadExtensionObjectArray(string fieldName)
	{
		ExtensionObjectCollection extensionObjectCollection = new ExtensionObjectCollection();
		List<object> array = null;
		if (!ReadArrayField(fieldName, out array))
		{
			return extensionObjectCollection;
		}
		for (int i = 0; i < array.Count; i++)
		{
			try
			{
				m_stack.Push(array[i]);
				ExtensionObject item = ReadExtensionObject(null);
				extensionObjectCollection.Add(item);
			}
			finally
			{
				m_stack.Pop();
			}
		}
		return extensionObjectCollection;
	}

	public Array ReadEncodeableArray(string fieldName, Type systemType, ExpandedNodeId encodeableTypeId = null)
	{
		if (systemType == null)
		{
			throw new ArgumentNullException("systemType");
		}
		List<object> array = null;
		if (!ReadArrayField(fieldName, out array))
		{
			return Array.CreateInstance(systemType, 0);
		}
		Array array2 = Array.CreateInstance(systemType, array.Count);
		for (int i = 0; i < array.Count; i++)
		{
			try
			{
				m_stack.Push(array[i]);
				IEncodeable value = ReadEncodeable(null, systemType, encodeableTypeId);
				array2.SetValue(value, i);
			}
			finally
			{
				m_stack.Pop();
			}
		}
		return array2;
	}

	public Array ReadEnumeratedArray(string fieldName, Type enumType)
	{
		if (enumType == null)
		{
			throw new ArgumentNullException("enumType");
		}
		List<object> array = null;
		if (!ReadArrayField(fieldName, out array))
		{
			return Array.CreateInstance(enumType, 0);
		}
		Array array2 = Array.CreateInstance(enumType, array.Count);
		for (int i = 0; i < array.Count; i++)
		{
			try
			{
				m_stack.Push(array[i]);
				Enum value = ReadEnumerated(null, enumType);
				array2.SetValue(value, i);
			}
			finally
			{
				m_stack.Pop();
			}
		}
		return array2;
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
			if (!ReadArrayField(fieldName, out var array))
			{
				return null;
			}
			List<object> elements = new List<object>();
			List<int> dimensions = new List<int>();
			if (builtInType == BuiltInType.Enumeration || builtInType == BuiltInType.Variant || builtInType == BuiltInType.Null)
			{
				DetermineIEncodeableSystemType(ref systemType, encodeableTypeId);
			}
			ReadMatrixPart(fieldName, array, builtInType, ref elements, ref dimensions, 0, systemType, encodeableTypeId);
			if (dimensions.Count == 0)
			{
				dimensions = new int[valueRank].ToList();
			}
			else if (dimensions.Count < 2)
			{
				throw ServiceResultException.Create(2147942400u, "The ValueRank {0} of the decoded array doesn't match the desired ValueRank {1}.", dimensions.Count, valueRank);
			}
			Matrix matrix = null;
			switch (builtInType)
			{
			case BuiltInType.Boolean:
				matrix = new Matrix(elements.Cast<bool>().ToArray(), builtInType, dimensions.ToArray());
				break;
			case BuiltInType.SByte:
				matrix = new Matrix(elements.Cast<sbyte>().ToArray(), builtInType, dimensions.ToArray());
				break;
			case BuiltInType.Byte:
				matrix = new Matrix(elements.Cast<byte>().ToArray(), builtInType, dimensions.ToArray());
				break;
			case BuiltInType.Int16:
				matrix = new Matrix(elements.Cast<short>().ToArray(), builtInType, dimensions.ToArray());
				break;
			case BuiltInType.UInt16:
				matrix = new Matrix(elements.Cast<ushort>().ToArray(), builtInType, dimensions.ToArray());
				break;
			case BuiltInType.Int32:
				matrix = new Matrix(elements.Cast<int>().ToArray(), builtInType, dimensions.ToArray());
				break;
			case BuiltInType.UInt32:
				matrix = new Matrix(elements.Cast<uint>().ToArray(), builtInType, dimensions.ToArray());
				break;
			case BuiltInType.Int64:
				matrix = new Matrix(elements.Cast<long>().ToArray(), builtInType, dimensions.ToArray());
				break;
			case BuiltInType.UInt64:
				matrix = new Matrix(elements.Cast<ulong>().ToArray(), builtInType, dimensions.ToArray());
				break;
			case BuiltInType.Float:
				matrix = new Matrix(elements.Cast<float>().ToArray(), builtInType, dimensions.ToArray());
				break;
			case BuiltInType.Double:
				matrix = new Matrix(elements.Cast<double>().ToArray(), builtInType, dimensions.ToArray());
				break;
			case BuiltInType.String:
				matrix = new Matrix(elements.Cast<string>().ToArray(), builtInType, dimensions.ToArray());
				break;
			case BuiltInType.DateTime:
				matrix = new Matrix(elements.Cast<DateTime>().ToArray(), builtInType, dimensions.ToArray());
				break;
			case BuiltInType.Guid:
				matrix = new Matrix(elements.Cast<Uuid>().ToArray(), builtInType, dimensions.ToArray());
				break;
			case BuiltInType.ByteString:
				matrix = new Matrix(elements.Cast<byte[]>().ToArray(), builtInType, dimensions.ToArray());
				break;
			case BuiltInType.XmlElement:
				matrix = new Matrix(elements.Cast<XmlElement>().ToArray(), builtInType, dimensions.ToArray());
				break;
			case BuiltInType.NodeId:
				matrix = new Matrix(elements.Cast<NodeId>().ToArray(), builtInType, dimensions.ToArray());
				break;
			case BuiltInType.ExpandedNodeId:
				matrix = new Matrix(elements.Cast<ExpandedNodeId>().ToArray(), builtInType, dimensions.ToArray());
				break;
			case BuiltInType.StatusCode:
				matrix = new Matrix(elements.Cast<StatusCode>().ToArray(), builtInType, dimensions.ToArray());
				break;
			case BuiltInType.QualifiedName:
				matrix = new Matrix(elements.Cast<QualifiedName>().ToArray(), builtInType, dimensions.ToArray());
				break;
			case BuiltInType.LocalizedText:
				matrix = new Matrix(elements.Cast<LocalizedText>().ToArray(), builtInType, dimensions.ToArray());
				break;
			case BuiltInType.DataValue:
				matrix = new Matrix(elements.Cast<DataValue>().ToArray(), builtInType, dimensions.ToArray());
				break;
			case BuiltInType.Enumeration:
				if ((object)systemType != null && systemType.IsEnum)
				{
					Array array4 = Array.CreateInstance(systemType, elements.Count);
					int num = 0;
					foreach (object item in elements)
					{
						array4.SetValue(Convert.ChangeType(item, systemType), num++);
					}
					matrix = new Matrix(array4, builtInType, dimensions.ToArray());
				}
				else
				{
					matrix = new Matrix(elements.Cast<int>().ToArray(), builtInType, dimensions.ToArray());
				}
				break;
			case BuiltInType.Variant:
				if (DetermineIEncodeableSystemType(ref systemType, encodeableTypeId))
				{
					Array array3 = Array.CreateInstance(systemType, elements.Count);
					for (int j = 0; j < elements.Count; j++)
					{
						array3.SetValue(Convert.ChangeType(elements[j], systemType), j);
					}
					matrix = new Matrix(array3, builtInType, dimensions.ToArray());
				}
				else
				{
					matrix = new Matrix(elements.Cast<Variant>().ToArray(), builtInType, dimensions.ToArray());
				}
				break;
			case BuiltInType.ExtensionObject:
				matrix = new Matrix(elements.Cast<ExtensionObject>().ToArray(), builtInType, dimensions.ToArray());
				break;
			case BuiltInType.DiagnosticInfo:
				matrix = new Matrix(elements.Cast<DiagnosticInfo>().ToArray(), builtInType, dimensions.ToArray());
				break;
			default:
				if (DetermineIEncodeableSystemType(ref systemType, encodeableTypeId))
				{
					Array array2 = Array.CreateInstance(systemType, elements.Count);
					for (int i = 0; i < elements.Count; i++)
					{
						array2.SetValue(Convert.ChangeType(elements[i], systemType), i);
					}
					matrix = new Matrix(array2, builtInType, dimensions.ToArray());
					break;
				}
				throw ServiceResultException.Create(2147942400u, "Cannot decode unknown type in Array object with BuiltInType: {0}.", builtInType);
			}
			return matrix.ToArray();
		}
		return null;
	}

	public bool PushStructure(string fieldName)
	{
		object token = null;
		if (!ReadField(fieldName, out token))
		{
			return false;
		}
		if (token != null)
		{
			m_stack.Push(token);
			return true;
		}
		return false;
	}

	public bool PushArray(string fieldName, int index)
	{
		List<object> array = null;
		if (!ReadArrayField(fieldName, out array))
		{
			return false;
		}
		if (index < array.Count)
		{
			m_stack.Push(array[index]);
			return true;
		}
		return false;
	}

	public void Pop()
	{
		m_stack.Pop();
	}

	private DiagnosticInfo ReadDiagnosticInfo(string fieldName, int depth)
	{
		object token = null;
		if (!ReadField(fieldName, out token))
		{
			return null;
		}
		if (!(token is Dictionary<string, object> dictionary))
		{
			return null;
		}
		if (depth >= DiagnosticInfo.MaxInnerDepth)
		{
			throw ServiceResultException.Create(2148007936u, "Maximum nesting level of InnerDiagnosticInfo was exceeded");
		}
		CheckAndIncrementNestingLevel();
		try
		{
			m_stack.Push(dictionary);
			DiagnosticInfo diagnosticInfo = new DiagnosticInfo();
			bool flag = false;
			if (dictionary.ContainsKey("SymbolicId"))
			{
				diagnosticInfo.SymbolicId = ReadInt32("SymbolicId");
				flag = true;
			}
			if (dictionary.ContainsKey("NamespaceUri"))
			{
				diagnosticInfo.NamespaceUri = ReadInt32("NamespaceUri");
				flag = true;
			}
			if (dictionary.ContainsKey("Locale"))
			{
				diagnosticInfo.Locale = ReadInt32("Locale");
				flag = true;
			}
			if (dictionary.ContainsKey("LocalizedText"))
			{
				diagnosticInfo.LocalizedText = ReadInt32("LocalizedText");
				flag = true;
			}
			if (dictionary.ContainsKey("AdditionalInfo"))
			{
				diagnosticInfo.AdditionalInfo = ReadString("AdditionalInfo");
				flag = true;
			}
			if (dictionary.ContainsKey("InnerStatusCode"))
			{
				diagnosticInfo.InnerStatusCode = ReadStatusCode("InnerStatusCode");
				flag = true;
			}
			if (dictionary.ContainsKey("InnerDiagnosticInfo") && depth < DiagnosticInfo.MaxInnerDepth)
			{
				diagnosticInfo.InnerDiagnosticInfo = ReadDiagnosticInfo("InnerDiagnosticInfo", depth + 1);
				flag = true;
			}
			return flag ? diagnosticInfo : null;
		}
		finally
		{
			m_nestingLevel--;
			m_stack.Pop();
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

	private Variant ReadVariantBody(string fieldName, BuiltInType type)
	{
		return type switch
		{
			BuiltInType.Boolean => new Variant(ReadBoolean(fieldName), TypeInfo.Scalars.Boolean), 
			BuiltInType.SByte => new Variant(ReadSByte(fieldName), TypeInfo.Scalars.SByte), 
			BuiltInType.Byte => new Variant(ReadByte(fieldName), TypeInfo.Scalars.Byte), 
			BuiltInType.Int16 => new Variant(ReadInt16(fieldName), TypeInfo.Scalars.Int16), 
			BuiltInType.UInt16 => new Variant(ReadUInt16(fieldName), TypeInfo.Scalars.UInt16), 
			BuiltInType.Int32 => new Variant(ReadInt32(fieldName), TypeInfo.Scalars.Int32), 
			BuiltInType.UInt32 => new Variant(ReadUInt32(fieldName), TypeInfo.Scalars.UInt32), 
			BuiltInType.Int64 => new Variant(ReadInt64(fieldName), TypeInfo.Scalars.Int64), 
			BuiltInType.UInt64 => new Variant(ReadUInt64(fieldName), TypeInfo.Scalars.UInt64), 
			BuiltInType.Float => new Variant(ReadFloat(fieldName), TypeInfo.Scalars.Float), 
			BuiltInType.Double => new Variant(ReadDouble(fieldName), TypeInfo.Scalars.Double), 
			BuiltInType.String => new Variant(ReadString(fieldName), TypeInfo.Scalars.String), 
			BuiltInType.ByteString => new Variant(ReadByteString(fieldName), TypeInfo.Scalars.ByteString), 
			BuiltInType.DateTime => new Variant(ReadDateTime(fieldName), TypeInfo.Scalars.DateTime), 
			BuiltInType.Guid => new Variant(ReadGuid(fieldName), TypeInfo.Scalars.Guid), 
			BuiltInType.NodeId => new Variant(ReadNodeId(fieldName), TypeInfo.Scalars.NodeId), 
			BuiltInType.ExpandedNodeId => new Variant(ReadExpandedNodeId(fieldName), TypeInfo.Scalars.ExpandedNodeId), 
			BuiltInType.QualifiedName => new Variant(ReadQualifiedName(fieldName), TypeInfo.Scalars.QualifiedName), 
			BuiltInType.LocalizedText => new Variant(ReadLocalizedText(fieldName), TypeInfo.Scalars.LocalizedText), 
			BuiltInType.StatusCode => new Variant(ReadStatusCode(fieldName), TypeInfo.Scalars.StatusCode), 
			BuiltInType.XmlElement => new Variant(ReadXmlElement(fieldName), TypeInfo.Scalars.XmlElement), 
			BuiltInType.ExtensionObject => new Variant(ReadExtensionObject(fieldName), TypeInfo.Scalars.ExtensionObject), 
			BuiltInType.Variant => new Variant(ReadVariant(fieldName), TypeInfo.Scalars.Variant), 
			BuiltInType.DiagnosticInfo => new Variant(ReadDiagnosticInfo(fieldName), TypeInfo.Scalars.DiagnosticInfo), 
			BuiltInType.DataValue => new Variant(ReadDataValue(fieldName), TypeInfo.Scalars.DataValue), 
			_ => Variant.Null, 
		};
	}

	private Variant ReadVariantArrayBody(string fieldName, BuiltInType type)
	{
		return type switch
		{
			BuiltInType.Boolean => new Variant(ReadBooleanArray(fieldName), TypeInfo.Arrays.Boolean), 
			BuiltInType.SByte => new Variant(ReadSByteArray(fieldName), TypeInfo.Arrays.SByte), 
			BuiltInType.Byte => new Variant(ReadByteArray(fieldName), TypeInfo.Arrays.Byte), 
			BuiltInType.Int16 => new Variant(ReadInt16Array(fieldName), TypeInfo.Arrays.Int16), 
			BuiltInType.UInt16 => new Variant(ReadUInt16Array(fieldName), TypeInfo.Arrays.UInt16), 
			BuiltInType.Int32 => new Variant(ReadInt32Array(fieldName), TypeInfo.Arrays.Int32), 
			BuiltInType.UInt32 => new Variant(ReadUInt32Array(fieldName), TypeInfo.Arrays.UInt32), 
			BuiltInType.Int64 => new Variant(ReadInt64Array(fieldName), TypeInfo.Arrays.Int64), 
			BuiltInType.UInt64 => new Variant(ReadUInt64Array(fieldName), TypeInfo.Arrays.UInt64), 
			BuiltInType.Float => new Variant(ReadFloatArray(fieldName), TypeInfo.Arrays.Float), 
			BuiltInType.Double => new Variant(ReadDoubleArray(fieldName), TypeInfo.Arrays.Double), 
			BuiltInType.String => new Variant(ReadStringArray(fieldName), TypeInfo.Arrays.String), 
			BuiltInType.ByteString => new Variant(ReadByteStringArray(fieldName), TypeInfo.Arrays.ByteString), 
			BuiltInType.DateTime => new Variant(ReadDateTimeArray(fieldName), TypeInfo.Arrays.DateTime), 
			BuiltInType.Guid => new Variant(ReadGuidArray(fieldName), TypeInfo.Arrays.Guid), 
			BuiltInType.NodeId => new Variant(ReadNodeIdArray(fieldName), TypeInfo.Arrays.NodeId), 
			BuiltInType.ExpandedNodeId => new Variant(ReadExpandedNodeIdArray(fieldName), TypeInfo.Arrays.ExpandedNodeId), 
			BuiltInType.QualifiedName => new Variant(ReadQualifiedNameArray(fieldName), TypeInfo.Arrays.QualifiedName), 
			BuiltInType.LocalizedText => new Variant(ReadLocalizedTextArray(fieldName), TypeInfo.Arrays.LocalizedText), 
			BuiltInType.StatusCode => new Variant(ReadStatusCodeArray(fieldName), TypeInfo.Arrays.StatusCode), 
			BuiltInType.XmlElement => new Variant(ReadXmlElementArray(fieldName), TypeInfo.Arrays.XmlElement), 
			BuiltInType.ExtensionObject => new Variant(ReadExtensionObjectArray(fieldName), TypeInfo.Arrays.ExtensionObject), 
			BuiltInType.Variant => new Variant(ReadVariantArray(fieldName), TypeInfo.Arrays.Variant), 
			BuiltInType.DiagnosticInfo => new Variant(ReadDiagnosticInfoArray(fieldName), TypeInfo.Arrays.DiagnosticInfo), 
			BuiltInType.DataValue => new Variant(ReadDataValueArray(fieldName), TypeInfo.Arrays.DataValue), 
			_ => Variant.Null, 
		};
	}

	private List<object> ReadArray()
	{
		CheckAndIncrementNestingLevel();
		try
		{
			List<object> list = new List<object>();
			while (m_reader.Read() && m_reader.TokenType != JsonToken.EndArray)
			{
				switch (m_reader.TokenType)
				{
				case JsonToken.Null:
					list.Add(JTokenNullObject.Array);
					break;
				case JsonToken.Integer:
				case JsonToken.Float:
				case JsonToken.String:
				case JsonToken.Boolean:
				case JsonToken.Date:
					list.Add(m_reader.Value);
					break;
				case JsonToken.StartArray:
					list.Add(ReadArray());
					break;
				case JsonToken.StartObject:
					list.Add(ReadObject());
					break;
				}
			}
			return list;
		}
		finally
		{
			m_nestingLevel--;
		}
	}

	private Dictionary<string, object> ReadObject()
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		while (m_reader.Read() && m_reader.TokenType != JsonToken.EndObject)
		{
			if (m_reader.TokenType == JsonToken.StartArray)
			{
				dictionary["___root_array___"] = ReadArray();
			}
			else
			{
				if (m_reader.TokenType != JsonToken.PropertyName)
				{
					continue;
				}
				string key = (string)m_reader.Value;
				if (m_reader.Read() && m_reader.TokenType != JsonToken.EndObject)
				{
					switch (m_reader.TokenType)
					{
					case JsonToken.Null:
						dictionary[key] = JTokenNullObject.Object;
						break;
					case JsonToken.Integer:
					case JsonToken.Float:
					case JsonToken.String:
					case JsonToken.Boolean:
					case JsonToken.Date:
					case JsonToken.Bytes:
						dictionary[key] = m_reader.Value;
						break;
					case JsonToken.StartArray:
						dictionary[key] = ReadArray();
						break;
					case JsonToken.StartObject:
						dictionary[key] = ReadObject();
						break;
					}
				}
			}
		}
		return dictionary;
	}

	private void ReadMatrixPart(string fieldName, List<object> currentArray, BuiltInType builtInType, ref List<object> elements, ref List<int> dimensions, int level, Type systemType, ExpandedNodeId encodeableTypeId)
	{
		CheckAndIncrementNestingLevel();
		try
		{
			if (currentArray == null || currentArray.Count <= 0)
			{
				return;
			}
			bool flag = false;
			for (int i = 0; i < currentArray.Count; i++)
			{
				if (i == 0 && dimensions.Count <= level)
				{
					dimensions.Add(currentArray.Count);
				}
				if (!(currentArray[i] is List<object>))
				{
					break;
				}
				flag = true;
				PushArray(fieldName, i);
				ReadMatrixPart(null, currentArray[i] as List<object>, builtInType, ref elements, ref dimensions, level + 1, systemType, encodeableTypeId);
				Pop();
			}
			if (flag)
			{
				return;
			}
			Array array = ReadArray(null, 1, builtInType, systemType, encodeableTypeId);
			if (array == null || array.Length <= 0)
			{
				return;
			}
			foreach (object item in array)
			{
				elements.Add(item);
			}
		}
		finally
		{
			m_nestingLevel--;
		}
	}

	private NodeId DefaultNodeId(IdType idType, ushort namespaceIndex)
	{
		return idType switch
		{
			IdType.Opaque => new NodeId(Array.Empty<byte>(), namespaceIndex), 
			IdType.String => new NodeId("", namespaceIndex), 
			IdType.Guid => new NodeId(Guid.Empty, namespaceIndex), 
			_ => new NodeId(0u, namespaceIndex), 
		};
	}

	private void EncodeAsJson(JsonTextWriter writer, object value)
	{
		if (value is Dictionary<string, object> value2)
		{
			EncodeAsJson(writer, value2);
		}
		else if (value is List<object> list)
		{
			writer.WriteStartArray();
			foreach (object item in list)
			{
				EncodeAsJson(writer, item);
			}
			writer.WriteStartArray();
		}
		else
		{
			writer.WriteValue(value);
		}
	}

	private void EncodeAsJson(JsonTextWriter writer, Dictionary<string, object> value)
	{
		writer.WriteStartObject();
		foreach (KeyValuePair<string, object> item in value)
		{
			writer.WritePropertyName(item.Key);
			EncodeAsJson(writer, item.Value);
		}
		writer.WriteEndObject();
	}

	private bool ReadArrayField(string fieldName, out List<object> array)
	{
		array = null;
		if (!ReadField(fieldName, out var token))
		{
			return false;
		}
		array = token as List<object>;
		if (array == null)
		{
			return false;
		}
		if (m_context.MaxArrayLength > 0 && m_context.MaxArrayLength < array.Count)
		{
			throw new ServiceResultException(2148007936u);
		}
		return true;
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
