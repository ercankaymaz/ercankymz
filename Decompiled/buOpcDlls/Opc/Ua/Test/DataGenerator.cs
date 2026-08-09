using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;

namespace Opc.Ua.Test;

[ComVisible(true)]
public class DataGenerator
{
	private class BoundaryValues
	{
		public Type SystemType;

		public List<object> Values;

		public BoundaryValues(Type systemType, params object[] values)
		{
			SystemType = systemType;
			if (values != null)
			{
				Values = new List<object>(values);
			}
			else
			{
				Values = new List<object>();
			}
		}
	}

	private static readonly BoundaryValues[] s_AvailableBoundaryValues = new BoundaryValues[22]
	{
		new BoundaryValues(typeof(sbyte), sbyte.MinValue, (sbyte)0, sbyte.MaxValue),
		new BoundaryValues(typeof(byte), (byte)0, byte.MaxValue),
		new BoundaryValues(typeof(short), short.MinValue, (short)0, short.MaxValue),
		new BoundaryValues(typeof(ushort), (ushort)0, ushort.MaxValue),
		new BoundaryValues(typeof(int), int.MinValue, 0, int.MaxValue),
		new BoundaryValues(typeof(uint), 0u, uint.MaxValue),
		new BoundaryValues(typeof(long), long.MinValue, 0L, long.MaxValue),
		new BoundaryValues(typeof(ulong), 0uL, ulong.MaxValue),
		new BoundaryValues(typeof(float), float.Epsilon, float.MaxValue, float.MinValue, float.NaN, float.NegativeInfinity, float.PositiveInfinity, 0f),
		new BoundaryValues(typeof(double), double.Epsilon, double.MaxValue, double.MinValue, double.NaN, double.NegativeInfinity, double.PositiveInfinity, 0.0),
		new BoundaryValues(typeof(string), null, string.Empty),
		new BoundaryValues(typeof(DateTime), DateTime.MinValue, DateTime.MaxValue, new DateTime(1099, 1, 1), Utils.TimeBase, new DateTime(2039, 4, 4), new DateTime(2001, 9, 11, 9, 15, 0, DateTimeKind.Local)),
		new BoundaryValues(typeof(Guid), Guid.Empty),
		new BoundaryValues(typeof(Uuid), Uuid.Empty),
		new BoundaryValues(typeof(byte[]), null, Array.Empty<byte>()),
		new BoundaryValues(typeof(XmlElement), null),
		new BoundaryValues(typeof(NodeId), null, NodeId.Null, new NodeId(Guid.Empty), new NodeId(string.Empty), new NodeId(Array.Empty<byte>())),
		new BoundaryValues(typeof(ExpandedNodeId), null, ExpandedNodeId.Null, new ExpandedNodeId(Guid.Empty), new ExpandedNodeId(string.Empty), new ExpandedNodeId(Array.Empty<byte>())),
		new BoundaryValues(typeof(QualifiedName), null, QualifiedName.Null),
		new BoundaryValues(typeof(LocalizedText), null, LocalizedText.Null),
		new BoundaryValues(typeof(StatusCode), 0u, 1073741824u, 2147483648u),
		new BoundaryValues(typeof(ExtensionObject), ExtensionObject.Null)
	};

	private IRandomSource m_random;

	private int m_maxArrayLength;

	private int m_maxStringLength;

	private DateTime m_minDateTimeValue;

	private DateTime m_maxDateTimeValue;

	private int m_boundaryValueFrequency;

	private int m_maxXmlAttributeCount;

	private int m_maxXmlElementCount;

	private NamespaceTable m_namespaceUris;

	private StringTable m_serverUris;

	private SortedDictionary<string, object[]> m_boundaryValues;

	private string[] m_availableLocales;

	private SortedDictionary<string, string[]> m_tokenValues;

	private const string kPunctuation = "`~!@#$%^&*()_-+={}[]:\"';?><,./";

	public int MaxArrayLength
	{
		get
		{
			return m_maxArrayLength;
		}
		set
		{
			m_maxArrayLength = value;
		}
	}

	public int MaxStringLength
	{
		get
		{
			return m_maxStringLength;
		}
		set
		{
			m_maxStringLength = value;
		}
	}

	public DateTime MinDateTimeValue
	{
		get
		{
			return m_minDateTimeValue;
		}
		set
		{
			m_minDateTimeValue = value;
		}
	}

	public DateTime MaxDateTimeValue
	{
		get
		{
			return m_maxDateTimeValue;
		}
		set
		{
			m_maxDateTimeValue = value;
		}
	}

	public int MaxXmlAttributeCount
	{
		get
		{
			return m_maxXmlAttributeCount;
		}
		set
		{
			m_maxXmlAttributeCount = value;
		}
	}

	public int MaxXmlElementCount
	{
		get
		{
			return m_maxXmlElementCount;
		}
		set
		{
			m_maxXmlElementCount = value;
		}
	}

	public NamespaceTable NamespaceUris
	{
		get
		{
			return m_namespaceUris;
		}
		set
		{
			m_namespaceUris = value;
		}
	}

	public StringTable ServerUris
	{
		get
		{
			return m_serverUris;
		}
		set
		{
			m_serverUris = value;
		}
	}

	public int BoundaryValueFrequency
	{
		get
		{
			return m_boundaryValueFrequency;
		}
		set
		{
			m_boundaryValueFrequency = value;
		}
	}

	public DataGenerator(IRandomSource random)
	{
		m_maxArrayLength = 100;
		m_maxStringLength = 100;
		m_maxXmlAttributeCount = 10;
		m_maxXmlElementCount = 10;
		m_minDateTimeValue = new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc);
		m_maxDateTimeValue = new DateTime(2100, 1, 1, 0, 0, 0, DateTimeKind.Utc);
		m_random = random;
		m_boundaryValueFrequency = 20;
		m_namespaceUris = new NamespaceTable();
		m_serverUris = new StringTable();
		if (m_random == null)
		{
			m_random = new RandomSource();
		}
		m_boundaryValues = new SortedDictionary<string, object[]>();
		for (int i = 0; i < s_AvailableBoundaryValues.Length; i++)
		{
			m_boundaryValues[s_AvailableBoundaryValues[i].SystemType.Name] = s_AvailableBoundaryValues[i].Values.ToArray();
		}
		m_tokenValues = LoadStringData("Opc.Ua.Types.Utils.LocalizedData.txt");
		if (m_tokenValues.Count == 0)
		{
			m_tokenValues = LoadStringData("Opc.Ua.Utils.LocalizedData.txt");
		}
		m_availableLocales = new string[m_tokenValues.Count];
		int num = 0;
		foreach (string key in m_tokenValues.Keys)
		{
			m_availableLocales[num++] = key;
		}
	}

	private bool UseBoundaryValue()
	{
		return m_random.NextInt32(99) < m_boundaryValueFrequency;
	}

	public object GetRandom(NodeId dataType, int valueRank, IList<uint> arrayDimensions, ITypeTable typeTree)
	{
		BuiltInType builtInType = TypeInfo.GetBuiltInType(dataType, typeTree);
		int num = 0;
		num = valueRank switch
		{
			-2 => (arrayDimensions == null || arrayDimensions.Count <= 0) ? GetRandomRange(0, 1) : arrayDimensions.Count, 
			-3 => GetRandomRange(0, 1), 
			0 => (arrayDimensions == null || arrayDimensions.Count <= 0) ? GetRandomRange(1, 1) : arrayDimensions.Count, 
			-1 => 0, 
			_ => valueRank, 
		};
		if (num == 0)
		{
			if (builtInType == BuiltInType.Variant)
			{
				BuiltInType builtInType2 = BuiltInType.Variant;
				while (builtInType2 == BuiltInType.Variant || builtInType2 == BuiltInType.DataValue)
				{
					builtInType2 = (BuiltInType)m_random.NextInt32(24);
				}
				return GetRandomVariant(builtInType2, isArray: false);
			}
			return GetRandom(builtInType);
		}
		int[] array = new int[num];
		for (int i = 0; i < num; i++)
		{
			if (arrayDimensions != null && arrayDimensions.Count > i)
			{
				array[i] = (int)arrayDimensions[i];
			}
			while (array[i] == 0)
			{
				array[i] = m_random.NextInt32(m_maxArrayLength);
			}
		}
		Array array2 = TypeInfo.CreateArray(builtInType, array);
		int length = array2.Length;
		int[] array3 = new int[array.Length];
		for (int j = 0; j < length; j++)
		{
			int num2 = array2.Length;
			for (int k = 0; k < array3.Length; k++)
			{
				num2 /= array[k];
				array3[k] = j / num2 % array[k];
			}
			object obj = GetRandom(dataType, -1, null, typeTree);
			if (obj != null)
			{
				if (builtInType == BuiltInType.Guid && obj is Guid)
				{
					obj = new Uuid((Guid)obj);
				}
				array2.SetValue(obj, array3);
			}
		}
		return array2;
	}

	public object GetRandom(BuiltInType expectedType)
	{
		switch (expectedType)
		{
		case BuiltInType.Boolean:
			return GetRandomBoolean();
		case BuiltInType.SByte:
			return GetRandomSByte();
		case BuiltInType.Byte:
			return GetRandomByte();
		case BuiltInType.Int16:
			return GetRandomInt16();
		case BuiltInType.UInt16:
			return GetRandomUInt16();
		case BuiltInType.Int32:
			return GetRandomInt32();
		case BuiltInType.UInt32:
			return GetRandomUInt32();
		case BuiltInType.Int64:
			return GetRandomInt64();
		case BuiltInType.UInt64:
			return GetRandomUInt64();
		case BuiltInType.Float:
			return GetRandomFloat();
		case BuiltInType.Double:
			return GetRandomDouble();
		case BuiltInType.String:
			return GetRandomString();
		case BuiltInType.DateTime:
			return GetRandomDateTime();
		case BuiltInType.Guid:
			return GetRandomUuid();
		case BuiltInType.ByteString:
			return GetRandomByteString();
		case BuiltInType.XmlElement:
			return GetRandomXmlElement();
		case BuiltInType.NodeId:
			return GetRandomNodeId();
		case BuiltInType.ExpandedNodeId:
			return GetRandomExpandedNodeId();
		case BuiltInType.QualifiedName:
			return GetRandomQualifiedName();
		case BuiltInType.LocalizedText:
			return GetRandomLocalizedText();
		case BuiltInType.StatusCode:
			return GetRandomStatusCode();
		case BuiltInType.Variant:
			return GetRandomVariant();
		case BuiltInType.Enumeration:
			return GetRandomInt32();
		case BuiltInType.ExtensionObject:
			return GetRandomExtensionObject();
		case BuiltInType.DataValue:
			return GetRandomDataValue();
		case BuiltInType.DiagnosticInfo:
			return GetRandomDiagnosticInfo();
		case BuiltInType.Number:
		{
			BuiltInType builtInType3 = (BuiltInType)(m_random.NextInt32(9) + 2);
			return GetRandomVariant(builtInType3, isArray: false);
		}
		case BuiltInType.Integer:
		{
			BuiltInType builtInType2 = (BuiltInType)(m_random.NextInt32(3) * 2 + 2);
			return GetRandomVariant(builtInType2, isArray: false);
		}
		case BuiltInType.UInteger:
		{
			BuiltInType builtInType = (BuiltInType)(m_random.NextInt32(3) * 2 + 3);
			return GetRandomVariant(builtInType, isArray: false);
		}
		default:
			return null;
		}
	}

	public Array GetRandomArray(BuiltInType expectedType, bool useBoundaryValues, int length, bool fixedLength)
	{
		switch (expectedType)
		{
		case BuiltInType.Null:
			return GetNullArray<object>(length, fixedLength);
		case BuiltInType.Boolean:
			return GetRandomArray<bool>(useBoundaryValues, length, fixedLength);
		case BuiltInType.SByte:
			return GetRandomArray<sbyte>(useBoundaryValues, length, fixedLength);
		case BuiltInType.Byte:
			return GetRandomArray<byte>(useBoundaryValues, length, fixedLength);
		case BuiltInType.Int16:
			return GetRandomArray<short>(useBoundaryValues, length, fixedLength);
		case BuiltInType.UInt16:
			return GetRandomArray<ushort>(useBoundaryValues, length, fixedLength);
		case BuiltInType.Int32:
			return GetRandomArray<int>(useBoundaryValues, length, fixedLength);
		case BuiltInType.UInt32:
			return GetRandomArray<uint>(useBoundaryValues, length, fixedLength);
		case BuiltInType.Int64:
			return GetRandomArray<long>(useBoundaryValues, length, fixedLength);
		case BuiltInType.UInt64:
			return GetRandomArray<ulong>(useBoundaryValues, length, fixedLength);
		case BuiltInType.Float:
			return GetRandomArray<float>(useBoundaryValues, length, fixedLength);
		case BuiltInType.Double:
			return GetRandomArray<double>(useBoundaryValues, length, fixedLength);
		case BuiltInType.String:
			return GetRandomArray<string>(useBoundaryValues, length, fixedLength);
		case BuiltInType.DateTime:
			return GetRandomArray<DateTime>(useBoundaryValues, length, fixedLength);
		case BuiltInType.Guid:
			return GetRandomArray<Uuid>(useBoundaryValues, length, fixedLength);
		case BuiltInType.ByteString:
			return GetRandomArray<byte[]>(useBoundaryValues, length, fixedLength);
		case BuiltInType.XmlElement:
			return GetRandomArray<XmlElement>(useBoundaryValues, length, fixedLength);
		case BuiltInType.NodeId:
			return GetRandomArray<NodeId>(useBoundaryValues, length, fixedLength);
		case BuiltInType.ExpandedNodeId:
			return GetRandomArray<ExpandedNodeId>(useBoundaryValues, length, fixedLength);
		case BuiltInType.QualifiedName:
			return GetRandomArray<QualifiedName>(useBoundaryValues, length, fixedLength);
		case BuiltInType.LocalizedText:
			return GetRandomArray<LocalizedText>(useBoundaryValues, length, fixedLength);
		case BuiltInType.StatusCode:
			return GetRandomArray<StatusCode>(useBoundaryValues, length, fixedLength);
		case BuiltInType.Variant:
			return GetRandomArray<Variant>(useBoundaryValues, length, fixedLength);
		case BuiltInType.ExtensionObject:
			return GetRandomArray<ExtensionObject>(useBoundaryValues, length, fixedLength);
		case BuiltInType.Number:
		{
			BuiltInType builtInType3 = (BuiltInType)(m_random.NextInt32(9) + 2);
			return GetRandomArrayInVariant(builtInType3, useBoundaryValues, length, fixedLength);
		}
		case BuiltInType.Integer:
		{
			BuiltInType builtInType2 = (BuiltInType)(m_random.NextInt32(3) * 2 + 2);
			return GetRandomArrayInVariant(builtInType2, useBoundaryValues, length, fixedLength);
		}
		case BuiltInType.UInteger:
		{
			BuiltInType builtInType = (BuiltInType)(m_random.NextInt32(3) * 2 + 3);
			return GetRandomArrayInVariant(builtInType, useBoundaryValues, length, fixedLength);
		}
		case BuiltInType.Enumeration:
			return GetRandomArray<int>(useBoundaryValues, length, fixedLength);
		default:
			return null;
		}
	}

	private Variant[] GetRandomArrayInVariant(BuiltInType builtInType, bool useBoundaryValues, int length, bool fixedLength)
	{
		Array randomArray = GetRandomArray(builtInType, useBoundaryValues, length, fixedLength);
		Variant[] array = new Variant[randomArray.Length];
		TypeInfo typeInfo = new TypeInfo(builtInType, -1);
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = new Variant(randomArray.GetValue(i), typeInfo);
		}
		return array;
	}

	public T GetRandom<T>(bool useBoundaryValues)
	{
		if (useBoundaryValues && UseBoundaryValue())
		{
			object boundaryValue = GetBoundaryValue(typeof(T));
			if (boundaryValue != null || !typeof(T).GetTypeInfo().IsValueType)
			{
				return (T)boundaryValue;
			}
		}
		return (T)GetRandom(typeof(T));
	}

	public T[] GetNullArray<T>(int length, bool fixedLength)
	{
		if (length < 0)
		{
			return null;
		}
		if (!fixedLength)
		{
			length = m_random.NextInt32(length);
		}
		T[] array = new T[length];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = default(T);
		}
		return array;
	}

	public T[] GetRandomArray<T>(bool useBoundaryValues, int length, bool fixedLength)
	{
		if (length < 0)
		{
			return null;
		}
		if (!fixedLength)
		{
			length = m_random.NextInt32(length);
		}
		T[] array = new T[length];
		for (int i = 0; i < array.Length; i++)
		{
			object obj = null;
			obj = ((!useBoundaryValues || !UseBoundaryValue()) ? GetRandom(typeof(T)) : GetBoundaryValue(typeof(T)));
			if (obj == null)
			{
				obj = default(T);
				if (obj == null)
				{
					Type typeFromHandle = typeof(T);
					if (typeFromHandle == typeof(ExpandedNodeId))
					{
						obj = ExpandedNodeId.Null;
					}
					else if (typeFromHandle == typeof(NodeId))
					{
						obj = NodeId.Null;
					}
					else if (typeFromHandle == typeof(LocalizedText))
					{
						obj = LocalizedText.Null;
					}
					else if (typeFromHandle == typeof(QualifiedName))
					{
						obj = QualifiedName.Null;
					}
				}
			}
			array[i] = (T)obj;
		}
		return array;
	}

	public bool GetRandomBoolean()
	{
		return m_random.NextInt32(1) != 0;
	}

	public sbyte GetRandomSByte()
	{
		int num = m_random.NextInt32(255);
		if (num > 127)
		{
			return (sbyte)(-128 + (num - 127) - 1);
		}
		return (sbyte)num;
	}

	public byte GetRandomByte()
	{
		return (byte)m_random.NextInt32(255);
	}

	public short GetRandomInt16()
	{
		int num = m_random.NextInt32(65535);
		if (num > 32767)
		{
			return (short)(-32768 + (num - 32767) - 1);
		}
		return (short)num;
	}

	public ushort GetRandomUInt16()
	{
		return (ushort)m_random.NextInt32(65535);
	}

	public int GetRandomInt32()
	{
		return m_random.NextInt32(int.MaxValue);
	}

	public uint GetRandomUInt32()
	{
		byte[] array = new byte[4];
		m_random.NextBytes(array, 0, array.Length);
		return BitConverter.ToUInt32(array, 0);
	}

	public long GetRandomInt64()
	{
		byte[] array = new byte[8];
		m_random.NextBytes(array, 0, array.Length);
		return BitConverter.ToInt64(array, 0);
	}

	public ulong GetRandomUInt64()
	{
		byte[] array = new byte[8];
		m_random.NextBytes(array, 0, array.Length);
		return BitConverter.ToUInt64(array, 0);
	}

	public float GetRandomFloat()
	{
		byte[] array = new byte[4];
		m_random.NextBytes(array, 0, array.Length);
		return BitConverter.ToSingle(array, 0);
	}

	public double GetRandomDouble()
	{
		byte[] array = new byte[8];
		m_random.NextBytes(array, 0, array.Length);
		return BitConverter.ToSingle(array, 0);
	}

	public string GetRandomString()
	{
		return CreateString(GetRandomLocale(), isSymbol: false);
	}

	public string GetRandomString(string locale)
	{
		return CreateString(locale, isSymbol: false);
	}

	public string GetRandomSymbol()
	{
		return CreateString(GetRandomLocale(), isSymbol: true);
	}

	public string GetRandomSymbol(string locale)
	{
		return CreateString(locale, isSymbol: false);
	}

	public DateTime GetRandomDateTime()
	{
		int min = (int)(m_minDateTimeValue.Ticks >> 32);
		int max = (int)(m_maxDateTimeValue.Ticks >> 32);
		long num = (long)GetRandomRange(min, max) << 32;
		uint randomUInt = GetRandomUInt32();
		return new DateTime(num + randomUInt, DateTimeKind.Utc);
	}

	public Guid GetRandomGuid()
	{
		byte[] array = new byte[16];
		m_random.NextBytes(array, 0, array.Length);
		return new Guid(array);
	}

	public Uuid GetRandomUuid()
	{
		byte[] array = new byte[16];
		m_random.NextBytes(array, 0, array.Length);
		return new Uuid(new Guid(array));
	}

	public byte[] GetRandomByteString()
	{
		byte[] array = new byte[m_random.NextInt32(m_maxStringLength)];
		m_random.NextBytes(array, 0, array.Length);
		return array;
	}

	public XmlElement GetRandomXmlElement()
	{
		string randomLocale = GetRandomLocale();
		string randomLocale2 = GetRandomLocale();
		XmlDocument xmlDocument = new XmlDocument();
		XmlElement xmlElement = xmlDocument.CreateElement("n0", CreateString(randomLocale, isSymbol: true), Utils.Format("http://{0}", CreateString(randomLocale, isSymbol: true)));
		xmlDocument.AppendChild(xmlElement);
		int num = m_random.NextInt32(m_maxXmlAttributeCount);
		for (int i = 0; i < num; i++)
		{
			string name = CreateString(randomLocale, isSymbol: true);
			XmlAttribute xmlAttribute = xmlDocument.CreateAttribute(name);
			xmlAttribute.Value = CreateString(randomLocale2, isSymbol: true);
			xmlElement.SetAttributeNode(xmlAttribute);
		}
		int num2 = m_random.NextInt32(m_maxXmlElementCount);
		for (int j = 0; j < num2; j++)
		{
			string localName = CreateString(randomLocale, isSymbol: true);
			XmlElement xmlElement2 = xmlDocument.CreateElement(xmlElement.Prefix, localName, xmlElement.NamespaceURI);
			xmlElement2.InnerText = CreateString(randomLocale2, isSymbol: false);
			xmlElement.AppendChild(xmlElement2);
		}
		return xmlElement;
	}

	public NodeId GetRandomNodeId()
	{
		ushort namespaceIndex = (ushort)m_random.NextInt32(m_namespaceUris.Count - 1);
		return (IdType)m_random.NextInt32(4) switch
		{
			IdType.String => new NodeId(CreateString(GetRandomLocale(), isSymbol: true), namespaceIndex), 
			IdType.Guid => new NodeId(GetRandomGuid(), namespaceIndex), 
			IdType.Opaque => new NodeId(GetRandomByteString(), namespaceIndex), 
			_ => new NodeId(GetRandomUInt32(), namespaceIndex), 
		};
	}

	public ExpandedNodeId GetRandomExpandedNodeId()
	{
		NodeId randomNodeId = GetRandomNodeId();
		ushort serverIndex = (ushort)((m_serverUris.Count != 0) ? ((ushort)m_random.NextInt32(m_serverUris.Count - 1)) : 0);
		return new ExpandedNodeId(randomNodeId, m_namespaceUris.GetString(randomNodeId.NamespaceIndex), serverIndex);
	}

	public QualifiedName GetRandomQualifiedName()
	{
		ushort namespaceIndex = (ushort)m_random.NextInt32(m_namespaceUris.Count - 1);
		return new QualifiedName(CreateString(GetRandomLocale(), isSymbol: true), namespaceIndex);
	}

	public LocalizedText GetRandomLocalizedText()
	{
		string randomLocale = GetRandomLocale();
		return new LocalizedText(randomLocale, CreateString(randomLocale, isSymbol: false));
	}

	public StatusCode GetRandomStatusCode()
	{
		int randomRange = GetRandomRange(32769, 32951);
		return (uint)(2147549184u + (randomRange << 16));
	}

	public Variant GetRandomVariant()
	{
		return GetRandomVariant(allowArrays: true);
	}

	public Variant GetRandomVariant(bool allowArrays)
	{
		BuiltInType builtInType = BuiltInType.Variant;
		while (builtInType == BuiltInType.Variant || builtInType == BuiltInType.DataValue)
		{
			builtInType = (BuiltInType)m_random.NextInt32(24);
		}
		return GetRandomVariant(builtInType, allowArrays && m_random.NextInt32(1) == 1);
	}

	private Variant GetRandomVariant(BuiltInType builtInType, bool isArray)
	{
		if (builtInType == BuiltInType.Null)
		{
			return Variant.Null;
		}
		int num = -1;
		if (isArray)
		{
			num = m_random.NextInt32(m_maxArrayLength - 1);
		}
		else if (builtInType == BuiltInType.Variant)
		{
			num = 1;
		}
		if (num >= 0)
		{
			switch (builtInType)
			{
			case BuiltInType.Boolean:
				return new Variant(GetRandomArray<bool>(useBoundaryValues: true, num, fixedLength: true));
			case BuiltInType.SByte:
				return new Variant(GetRandomArray<sbyte>(useBoundaryValues: true, num, fixedLength: true));
			case BuiltInType.Byte:
				return new Variant(GetRandomArray<byte>(useBoundaryValues: true, num, fixedLength: true));
			case BuiltInType.Int16:
				return new Variant(GetRandomArray<short>(useBoundaryValues: true, num, fixedLength: true));
			case BuiltInType.UInt16:
				return new Variant(GetRandomArray<ushort>(useBoundaryValues: true, num, fixedLength: true));
			case BuiltInType.Int32:
				return new Variant(GetRandomArray<int>(useBoundaryValues: true, num, fixedLength: true));
			case BuiltInType.UInt32:
				return new Variant(GetRandomArray<uint>(useBoundaryValues: true, num, fixedLength: true));
			case BuiltInType.Int64:
				return new Variant(GetRandomArray<long>(useBoundaryValues: true, num, fixedLength: true));
			case BuiltInType.UInt64:
				return new Variant(GetRandomArray<ulong>(useBoundaryValues: true, num, fixedLength: true));
			case BuiltInType.Float:
				return new Variant(GetRandomArray<float>(useBoundaryValues: true, num, fixedLength: true));
			case BuiltInType.Double:
				return new Variant(GetRandomArray<double>(useBoundaryValues: true, num, fixedLength: true));
			case BuiltInType.String:
				return new Variant(GetRandomArray<string>(useBoundaryValues: true, num, fixedLength: true));
			case BuiltInType.DateTime:
				return new Variant(GetRandomArray<DateTime>(useBoundaryValues: true, num, fixedLength: true));
			case BuiltInType.Guid:
				return new Variant(GetRandomArray<Uuid>(useBoundaryValues: true, num, fixedLength: true));
			case BuiltInType.ByteString:
				return new Variant(GetRandomArray<byte[]>(useBoundaryValues: true, num, fixedLength: true));
			case BuiltInType.XmlElement:
				return new Variant(GetRandomArray<XmlElement>(useBoundaryValues: true, num, fixedLength: true));
			case BuiltInType.NodeId:
				return new Variant(GetRandomArray<NodeId>(useBoundaryValues: true, num, fixedLength: true));
			case BuiltInType.ExpandedNodeId:
				return new Variant(GetRandomArray<ExpandedNodeId>(useBoundaryValues: true, num, fixedLength: true));
			case BuiltInType.QualifiedName:
				return new Variant(GetRandomArray<QualifiedName>(useBoundaryValues: true, num, fixedLength: true));
			case BuiltInType.LocalizedText:
				return new Variant(GetRandomArray<LocalizedText>(useBoundaryValues: true, num, fixedLength: true));
			case BuiltInType.StatusCode:
				return new Variant(GetRandomArray<StatusCode>(useBoundaryValues: true, num, fixedLength: true));
			case BuiltInType.Variant:
				return new Variant(GetRandomArray<Variant>(useBoundaryValues: true, num, fixedLength: true));
			}
		}
		return new Variant(GetRandom(builtInType));
	}

	public ExtensionObject GetRandomExtensionObject()
	{
		NodeId randomNodeId = GetRandomNodeId();
		if (NodeId.IsNull(randomNodeId))
		{
			return ExtensionObject.Null;
		}
		object obj = null;
		return new ExtensionObject(body: (m_random.NextInt32(1) == 0) ? ((object)GetRandomXmlElement()) : ((object)GetRandomByteString()), typeId: randomNodeId);
	}

	public DataValue GetRandomDataValue()
	{
		Variant randomVariant = GetRandomVariant();
		StatusCode randomStatusCode = GetRandomStatusCode();
		DateTime randomDateTime = GetRandomDateTime();
		GetRandomDateTime();
		return new DataValue(randomVariant, randomStatusCode, randomDateTime, DateTime.UtcNow);
	}

	public DiagnosticInfo GetRandomDiagnosticInfo()
	{
		return new DiagnosticInfo(ServiceResult.Good, DiagnosticsMasks.NoInnerStatus, serviceLevel: true, new StringTable());
	}

	public object GetRandomNumber()
	{
		switch (m_random.NextInt32(5))
		{
		case 0:
		case 1:
			return GetRandomInteger();
		case 2:
		case 3:
			return GetRandomUInteger();
		case 4:
			return GetRandomFloat();
		default:
			return GetRandomDouble();
		}
	}

	public object GetRandomInteger()
	{
		return m_random.NextInt32(3) switch
		{
			0 => GetRandomSByte(), 
			1 => GetRandomInt16(), 
			2 => GetRandomInt32(), 
			_ => GetRandomInt64(), 
		};
	}

	public object GetRandomUInteger()
	{
		return m_random.NextInt32(3) switch
		{
			0 => GetRandomByte(), 
			1 => GetRandomUInt16(), 
			2 => GetRandomUInt32(), 
			_ => GetRandomUInt64(), 
		};
	}

	private static SortedDictionary<string, string[]> LoadStringData(string resourceName)
	{
		SortedDictionary<string, string[]> sortedDictionary = new SortedDictionary<string, string[]>();
		try
		{
			string text = null;
			List<string> list = null;
			Stream stream = typeof(DataGenerator).GetTypeInfo().Assembly.GetManifestResourceStream(resourceName);
			if (stream == null)
			{
				stream = new FileInfo(resourceName).OpenRead();
			}
			using (StreamReader streamReader = new StreamReader(stream))
			{
				for (string text2 = streamReader.ReadLine(); text2 != null; text2 = streamReader.ReadLine())
				{
					string text3 = text2.Trim();
					if (!string.IsNullOrEmpty(text3))
					{
						if (text3.StartsWith("=", StringComparison.Ordinal))
						{
							if (text != null)
							{
								sortedDictionary.Add(text, list.ToArray());
							}
							text = text3.Substring(1);
							list = new List<string>();
						}
						else
						{
							list.Add(text3);
						}
					}
				}
			}
			return sortedDictionary;
		}
		catch (Exception)
		{
			return sortedDictionary;
		}
	}

	private object GetBoundaryValue(Type type)
	{
		if (type == null)
		{
			return null;
		}
		object[] value = null;
		if (!m_boundaryValues.TryGetValue(type.Name, out value))
		{
			return null;
		}
		if (value == null || value.Length == 0)
		{
			return null;
		}
		int num = m_random.NextInt32(value.Length - 1);
		if (type.IsInstanceOfType(value[num]))
		{
			return value[num];
		}
		return null;
	}

	private int GetRandomRange(int min, int max)
	{
		if (min < 0)
		{
			min = 0;
		}
		if (max < 0)
		{
			max = 0;
		}
		if (min >= max)
		{
			return min;
		}
		return m_random.NextInt32(max - min) + min;
	}

	private object GetRandom(Type expectedType)
	{
		BuiltInType builtInType = TypeInfo.Construct(expectedType).BuiltInType;
		object random = GetRandom(builtInType);
		if (builtInType == BuiltInType.Guid && expectedType == typeof(Guid))
		{
			return (Guid)(Uuid)random;
		}
		return random;
	}

	private string GetRandomLocale()
	{
		int num = m_random.NextInt32(m_availableLocales.Length - 1);
		return m_availableLocales[num];
	}

	private string CreateString(string locale, bool isSymbol)
	{
		string[] value = null;
		if (!m_tokenValues.TryGetValue(locale, out value))
		{
			value = m_tokenValues["en-US"];
		}
		int num = 0;
		num = ((!isSymbol) ? (m_random.NextInt32(m_maxStringLength) + 1) : (m_random.NextInt32(2) + 1));
		StringBuilder stringBuilder = new StringBuilder();
		while (stringBuilder.Length < num)
		{
			if (!isSymbol && stringBuilder.Length > 0)
			{
				stringBuilder.Append(' ');
			}
			int num2 = m_random.NextInt32(value.Length - 1);
			stringBuilder.Append(value[num2]);
			if (!isSymbol && m_random.NextInt32(1) != 0)
			{
				num2 = m_random.NextInt32("`~!@#$%^&*()_-+={}[]:\"';?><,./".Length - 1);
				stringBuilder.Append("`~!@#$%^&*()_-+={}[]:\"';?><,./"[num2]);
			}
		}
		return stringBuilder.ToString();
	}
}
