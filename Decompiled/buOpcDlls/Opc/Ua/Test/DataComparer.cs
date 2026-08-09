using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Xml;

namespace Opc.Ua.Test;

[ComVisible(true)]
public class DataComparer
{
	private delegate bool Comparator<T>(T value1, T value2);

	private static IEncodeableFactory s_Factory = new EncodeableFactory();

	private IServiceMessageContext m_context;

	private bool m_throwOnError;

	public bool ThrowOnError
	{
		get
		{
			return m_throwOnError;
		}
		set
		{
			m_throwOnError = value;
		}
	}

	public static IEncodeableFactory EncodeableFactory
	{
		get
		{
			if (s_Factory == null)
			{
				s_Factory = new EncodeableFactory();
				s_Factory.AddEncodeableTypes(typeof(DataComparer).GetTypeInfo().Assembly);
			}
			return s_Factory;
		}
	}

	public DataComparer(IServiceMessageContext context)
	{
		m_context = context;
		m_throwOnError = true;
	}

	public bool CompareBoolean(bool value1, bool value2)
	{
		if (value1 != value2)
		{
			return ReportError(value1, value2);
		}
		return true;
	}

	public bool CompareSByte(sbyte value1, sbyte value2)
	{
		if (value1 != value2)
		{
			return ReportError(value1, value2);
		}
		return true;
	}

	public bool CompareByte(byte value1, byte value2)
	{
		if (value1 != value2)
		{
			return ReportError(value1, value2);
		}
		return true;
	}

	public bool CompareInt16(short value1, short value2)
	{
		if (value1 != value2)
		{
			return ReportError(value1, value2);
		}
		return true;
	}

	public bool CompareUInt16(ushort value1, ushort value2)
	{
		if (value1 != value2)
		{
			return ReportError(value1, value2);
		}
		return true;
	}

	public bool CompareInt32(int value1, int value2)
	{
		if (value1 != value2)
		{
			return ReportError(value1, value2);
		}
		return true;
	}

	public bool CompareUInt32(uint value1, uint value2)
	{
		if (value1 != value2)
		{
			return ReportError(value1, value2);
		}
		return true;
	}

	public bool CompareInt64(long value1, long value2)
	{
		if (value1 != value2)
		{
			return ReportError(value1, value2);
		}
		return true;
	}

	public bool CompareUInt64(ulong value1, ulong value2)
	{
		if (value1 != value2)
		{
			return ReportError(value1, value2);
		}
		return true;
	}

	public bool CompareFloat(float value1, float value2)
	{
		if (value1 != value2)
		{
			if (float.IsNaN(value1) && float.IsNaN(value2))
			{
				return true;
			}
			return ReportError(value1, value2);
		}
		return true;
	}

	public bool CompareDouble(double value1, double value2)
	{
		if (value1 != value2)
		{
			if (double.IsNaN(value1) && double.IsNaN(value2))
			{
				return true;
			}
			double num = Math.Abs(value1 - value2);
			if (num < Math.Abs(value1 / 1000000000000000.0))
			{
				return true;
			}
			return ReportError(value1, num);
		}
		return true;
	}

	public bool CompareString(string value1, string value2)
	{
		if (value1 != value2)
		{
			return ReportError(value1, value2);
		}
		return true;
	}

	public bool CompareDateTime(DateTime value1, DateTime value2)
	{
		if (value1.Kind != value2.Kind)
		{
			value1 = Utils.ToOpcUaUniversalTime(value1);
			value2 = Utils.ToOpcUaUniversalTime(value2);
		}
		if (value1 < Utils.TimeBase)
		{
			value1 = DateTime.MinValue;
		}
		if (value2 < Utils.TimeBase)
		{
			value2 = DateTime.MinValue;
		}
		if (value1 == value2)
		{
			return true;
		}
		return Math.Abs((value1 - value2).Ticks) < 10000;
	}

	public bool CompareUuid(Uuid value1, Uuid value2)
	{
		if (value1 != value2)
		{
			return ReportError(value1, value2);
		}
		return true;
	}

	public bool CompareByteString(byte[] value1, byte[] value2)
	{
		if (value1 == null || value2 == null)
		{
			if (value1 != value2)
			{
				return ReportError(value1, value2);
			}
			return true;
		}
		if (value1.Length != value2.Length)
		{
			return ReportError(value1, value2);
		}
		for (int i = 0; i < value1.Length; i++)
		{
			if (value1[i] != value2[i])
			{
				return ReportError(value1[i], value1[i]);
			}
		}
		return true;
	}

	public bool CompareXmlElement(XmlElement value1, XmlElement value2)
	{
		if (value1 == null || value2 == null)
		{
			if (value1 != value2)
			{
				return ReportError(value1, value2);
			}
			return true;
		}
		if (value1.LocalName != value2.LocalName)
		{
			return ReportError(value1.LocalName, value2.LocalName);
		}
		if (value1.NamespaceURI != value2.NamespaceURI)
		{
			return ReportError(value1.NamespaceURI, value2.NamespaceURI);
		}
		foreach (XmlAttribute attribute in value1.Attributes)
		{
			XmlAttribute attributeNode = value2.GetAttributeNode(attribute.Name);
			if (attributeNode == null)
			{
				if (!attribute.Name.StartsWith("xmlns", StringComparison.Ordinal))
				{
					return ReportError(attribute, attributeNode);
				}
				string prefix = ((attribute.Name.Length > 5) ? attribute.Name.Substring(6) : string.Empty);
				if (attribute.Value != value2.GetNamespaceOfPrefix(prefix))
				{
					return ReportError(attribute.Value, value2.GetNamespaceOfPrefix(prefix));
				}
			}
			else if (attributeNode.Value != attribute.Value)
			{
				return ReportError(attributeNode.Value, attribute.Value);
			}
		}
		XmlNode xmlNode = value1.FirstChild;
		XmlNode xmlNode2 = value2.FirstChild;
		while (xmlNode != null && xmlNode2 != null)
		{
			while (xmlNode != null && xmlNode.NodeType != XmlNodeType.Element)
			{
				xmlNode = xmlNode.NextSibling;
			}
			while (xmlNode2 != null && xmlNode2.NodeType != XmlNodeType.Element)
			{
				xmlNode2 = xmlNode2.NextSibling;
			}
			if (!CompareXmlElement((XmlElement)xmlNode, (XmlElement)xmlNode2))
			{
				return false;
			}
			if (xmlNode != null)
			{
				xmlNode = xmlNode.NextSibling;
			}
			if (xmlNode2 != null)
			{
				xmlNode2 = xmlNode2.NextSibling;
			}
		}
		if (xmlNode != xmlNode2)
		{
			return ReportError(xmlNode, xmlNode2);
		}
		return true;
	}

	public bool CompareNodeId(NodeId value1, NodeId value2)
	{
		if (NodeId.IsNull(value1) && NodeId.IsNull(value2))
		{
			return true;
		}
		if (value1 == null || value2 == null)
		{
			if (value1 != value2)
			{
				return ReportError(value1, value2);
			}
			return true;
		}
		if (value1 != value2)
		{
			return ReportError(value1, value2);
		}
		return true;
	}

	public bool CompareExpandedNodeId(ExpandedNodeId value1, ExpandedNodeId value2)
	{
		if (NodeId.IsNull(value1) && NodeId.IsNull(value2))
		{
			return true;
		}
		if (value1 == null || value2 == null)
		{
			if (value1 != value2)
			{
				return false;
			}
			return true;
		}
		if (value1 != value2)
		{
			NodeId nodeId = ExpandedNodeId.ToNodeId(value1, m_context.NamespaceUris);
			NodeId nodeId2 = ExpandedNodeId.ToNodeId(value2, m_context.NamespaceUris);
			if (nodeId != nodeId2)
			{
				return ReportError(value1, value2);
			}
		}
		return true;
	}

	public bool CompareStatusCode(StatusCode value1, StatusCode value2)
	{
		if (value1 != value2)
		{
			return ReportError(value1, value2);
		}
		return true;
	}

	public bool CompareDiagnosticInfo(DiagnosticInfo value1, DiagnosticInfo value2)
	{
		if (value1 == null && value2 == null)
		{
			return true;
		}
		if (value1 == null)
		{
			value1 = new DiagnosticInfo();
		}
		if (value2 == null)
		{
			value2 = new DiagnosticInfo();
		}
		if (!CompareInt32(value1.SymbolicId, value2.SymbolicId))
		{
			return false;
		}
		if (!CompareInt32(value1.NamespaceUri, value2.NamespaceUri))
		{
			return false;
		}
		if (!CompareInt32(value1.Locale, value2.Locale))
		{
			return false;
		}
		if (!CompareInt32(value1.LocalizedText, value2.LocalizedText))
		{
			return false;
		}
		if (!CompareString(value1.AdditionalInfo, value2.AdditionalInfo))
		{
			return false;
		}
		if (!CompareStatusCode(value1.InnerStatusCode, value2.InnerStatusCode))
		{
			return false;
		}
		if (!CompareDiagnosticInfo(value1.InnerDiagnosticInfo, value2.InnerDiagnosticInfo))
		{
			return false;
		}
		return true;
	}

	public bool CompareQualifiedName(QualifiedName value1, QualifiedName value2)
	{
		if (value1 == null)
		{
			if (value2 == null || value2 == QualifiedName.Null)
			{
				return true;
			}
			return false;
		}
		if (value2 == null)
		{
			if (value1 == null || value1 == QualifiedName.Null)
			{
				return true;
			}
			return false;
		}
		if (!value1.Equals(value2))
		{
			return ReportError(value1, value1);
		}
		return true;
	}

	public bool CompareLocalizedText(LocalizedText value1, LocalizedText value2)
	{
		if (value1 == null)
		{
			if (value2 == null || value2 == LocalizedText.Null)
			{
				return true;
			}
			return false;
		}
		if (value2 == null)
		{
			if (value1 == null || value1 == LocalizedText.Null)
			{
				return true;
			}
			return false;
		}
		if (!value1.Equals(value2))
		{
			return ReportError(value1, value1);
		}
		return true;
	}

	public bool CompareVariant(Variant value1, Variant value2)
	{
		if (value1.Value == null || value2.Value == null)
		{
			if (value1.Value != value2.Value)
			{
				return ReportError(value1.Value, value2.Value);
			}
			return true;
		}
		Type type = value1.Value.GetType();
		if (type != value2.Value.GetType())
		{
			return ReportError(value1.Value, value2.Value);
		}
		if (!type.IsArray || type == typeof(byte[]))
		{
			if (type == typeof(bool))
			{
				return CompareBoolean((bool)value1.Value, (bool)value2.Value);
			}
			if (type == typeof(sbyte))
			{
				return CompareSByte((sbyte)value1.Value, (sbyte)value2.Value);
			}
			if (type == typeof(byte))
			{
				return CompareByte((byte)value1.Value, (byte)value2.Value);
			}
			if (type == typeof(short))
			{
				return CompareInt16((short)value1.Value, (short)value2.Value);
			}
			if (type == typeof(ushort))
			{
				return CompareUInt16((ushort)value1.Value, (ushort)value2.Value);
			}
			if (type == typeof(int))
			{
				return CompareInt32((int)value1.Value, (int)value2.Value);
			}
			if (type == typeof(uint))
			{
				return CompareUInt32((uint)value1.Value, (uint)value2.Value);
			}
			if (type == typeof(long))
			{
				return CompareInt64((long)value1.Value, (long)value2.Value);
			}
			if (type == typeof(ulong))
			{
				return CompareUInt64((ulong)value1.Value, (ulong)value2.Value);
			}
			if (type == typeof(float))
			{
				return CompareFloat((float)value1.Value, (float)value2.Value);
			}
			if (type == typeof(double))
			{
				return CompareDouble((double)value1.Value, (double)value2.Value);
			}
			if (type == typeof(string))
			{
				return CompareString((string)value1.Value, (string)value2.Value);
			}
			if (type == typeof(DateTime))
			{
				return CompareDateTime((DateTime)value1.Value, (DateTime)value2.Value);
			}
			if (type == typeof(Uuid))
			{
				return CompareUuid((Uuid)value1.Value, (Uuid)value2.Value);
			}
			if (type == typeof(byte[]))
			{
				return CompareByteString((byte[])value1.Value, (byte[])value2.Value);
			}
			if (type == typeof(XmlElement))
			{
				return CompareXmlElement((XmlElement)value1.Value, (XmlElement)value2.Value);
			}
			if (type == typeof(NodeId))
			{
				return CompareNodeId((NodeId)value1.Value, (NodeId)value2.Value);
			}
			if (type == typeof(ExpandedNodeId))
			{
				return CompareExpandedNodeId((ExpandedNodeId)value1.Value, (ExpandedNodeId)value2.Value);
			}
			if (type == typeof(StatusCode))
			{
				return CompareStatusCode((StatusCode)value1.Value, (StatusCode)value2.Value);
			}
			if (type == typeof(DiagnosticInfo))
			{
				return CompareDiagnosticInfo((DiagnosticInfo)value1.Value, (DiagnosticInfo)value2.Value);
			}
			if (type == typeof(QualifiedName))
			{
				return CompareQualifiedName((QualifiedName)value1.Value, (QualifiedName)value2.Value);
			}
			if (type == typeof(LocalizedText))
			{
				return CompareLocalizedText((LocalizedText)value1.Value, (LocalizedText)value2.Value);
			}
			if (type == typeof(ExtensionObject))
			{
				return CompareExtensionObject((ExtensionObject)value1.Value, (ExtensionObject)value2.Value);
			}
			if (type == typeof(DataValue))
			{
				return CompareDataValue((DataValue)value1.Value, (DataValue)value2.Value);
			}
			if (type == typeof(Variant))
			{
				return CompareVariant((Variant)value1.Value, (Variant)value2.Value);
			}
			if (type == typeof(Matrix))
			{
				return CompareMatrix((Matrix)value1.Value, (Matrix)value2.Value);
			}
		}
		else
		{
			if (type == typeof(bool[]))
			{
				return CompareArray((bool[])value1.Value, (bool[])value2.Value, CompareBoolean);
			}
			if (type == typeof(sbyte[]))
			{
				return CompareArray((sbyte[])value1.Value, (sbyte[])value2.Value, CompareSByte);
			}
			if (type == typeof(short[]))
			{
				return CompareArray((short[])value1.Value, (short[])value2.Value, CompareInt16);
			}
			if (type == typeof(ushort[]))
			{
				return CompareArray((ushort[])value1.Value, (ushort[])value2.Value, CompareUInt16);
			}
			if (type == typeof(int[]))
			{
				return CompareArray((int[])value1.Value, (int[])value2.Value, CompareInt32);
			}
			if (type == typeof(uint[]))
			{
				return CompareArray((uint[])value1.Value, (uint[])value2.Value, CompareUInt32);
			}
			if (type == typeof(long[]))
			{
				return CompareArray((long[])value1.Value, (long[])value2.Value, CompareInt64);
			}
			if (type == typeof(ulong[]))
			{
				return CompareArray((ulong[])value1.Value, (ulong[])value2.Value, CompareUInt64);
			}
			if (type == typeof(float[]))
			{
				return CompareArray((float[])value1.Value, (float[])value2.Value, CompareFloat);
			}
			if (type == typeof(double[]))
			{
				return CompareArray((double[])value1.Value, (double[])value2.Value, CompareDouble);
			}
			if (type == typeof(string[]))
			{
				return CompareArray((string[])value1.Value, (string[])value2.Value, CompareString);
			}
			if (type == typeof(DateTime[]))
			{
				return CompareArray((DateTime[])value1.Value, (DateTime[])value2.Value, CompareDateTime);
			}
			if (type == typeof(Uuid[]))
			{
				return CompareArray((Uuid[])value1.Value, (Uuid[])value2.Value, CompareUuid);
			}
			if (type == typeof(byte[][]))
			{
				return CompareArray((byte[][])value1.Value, (byte[][])value2.Value, CompareByteString);
			}
			if (type == typeof(XmlElement[]))
			{
				return CompareArray((XmlElement[])value1.Value, (XmlElement[])value2.Value, CompareXmlElement);
			}
			if (type == typeof(NodeId[]))
			{
				return CompareArray((NodeId[])value1.Value, (NodeId[])value2.Value, CompareNodeId);
			}
			if (type == typeof(ExpandedNodeId[]))
			{
				return CompareArray((ExpandedNodeId[])value1.Value, (ExpandedNodeId[])value2.Value, CompareExpandedNodeId);
			}
			if (type == typeof(StatusCode[]))
			{
				return CompareArray((StatusCode[])value1.Value, (StatusCode[])value2.Value, CompareStatusCode);
			}
			if (type == typeof(DiagnosticInfo[]))
			{
				return CompareArray((DiagnosticInfo[])value1.Value, (DiagnosticInfo[])value2.Value, CompareDiagnosticInfo);
			}
			if (type == typeof(QualifiedName[]))
			{
				return CompareArray((QualifiedName[])value1.Value, (QualifiedName[])value2.Value, CompareQualifiedName);
			}
			if (type == typeof(LocalizedText[]))
			{
				return CompareArray((LocalizedText[])value1.Value, (LocalizedText[])value2.Value, CompareLocalizedText);
			}
			if (type == typeof(ExtensionObject[]))
			{
				return CompareArray((ExtensionObject[])value1.Value, (ExtensionObject[])value2.Value, CompareExtensionObject);
			}
			if (type == typeof(DataValue[]))
			{
				return CompareArray((DataValue[])value1.Value, (DataValue[])value2.Value, CompareDataValue);
			}
			if (type == typeof(Variant[]))
			{
				return CompareArray((Variant[])value1.Value, (Variant[])value2.Value, CompareVariant);
			}
		}
		return ReportError(value1.Value, value2.Value);
	}

	public bool CompareDataValue(DataValue value1, DataValue value2)
	{
		if (value1 == null || value2 == null)
		{
			if (value1 != value2)
			{
				return ReportError(value1, value2);
			}
			return true;
		}
		if (!CompareVariant(value1.WrappedValue, value2.WrappedValue))
		{
			return false;
		}
		if (!CompareStatusCode(value1.StatusCode, value2.StatusCode))
		{
			return false;
		}
		if (!CompareDateTime(value1.SourceTimestamp, value2.SourceTimestamp))
		{
			return false;
		}
		if (!CompareUInt16(value1.SourcePicoseconds, value2.SourcePicoseconds))
		{
			return false;
		}
		if (!CompareDateTime(value1.ServerTimestamp, value2.ServerTimestamp))
		{
			return false;
		}
		if (!CompareUInt16(value1.ServerPicoseconds, value2.ServerPicoseconds))
		{
			return false;
		}
		return true;
	}

	public bool CompareMatrix(Matrix value1, Matrix value2)
	{
		if (value1 == null || value2 == null)
		{
			if (value1 != value2)
			{
				return ReportError(value1, value2);
			}
			return true;
		}
		if (!CompareVariant(new Variant(value1.Elements), new Variant(value2.Elements)))
		{
			return false;
		}
		if (!CompareArray(value1.Dimensions, value2.Dimensions, CompareInt32))
		{
			return false;
		}
		return true;
	}

	public static object GetExtensionObjectBody(ExtensionObject value)
	{
		object body = value.Body;
		if (body is IEncodeable result)
		{
			return result;
		}
		Type systemType = EncodeableFactory.GetSystemType(value.TypeId);
		if (systemType == null)
		{
			return body;
		}
		IServiceMessageContext context = new ServiceMessageContext
		{
			Factory = EncodeableFactory
		};
		if (body is XmlElement element)
		{
			XmlQualifiedName xmlName = Opc.Ua.EncodeableFactory.GetXmlName(systemType);
			XmlDecoder xmlDecoder = new XmlDecoder(element, context);
			xmlDecoder.PushNamespace(xmlName.Namespace);
			body = xmlDecoder.ReadEncodeable(xmlName.Name, systemType);
			xmlDecoder.PopNamespace();
			xmlDecoder.Close();
			return (IEncodeable)body;
		}
		if (body is byte[] buffer)
		{
			BinaryDecoder binaryDecoder = new BinaryDecoder(buffer, context);
			body = binaryDecoder.ReadEncodeable(null, systemType);
			binaryDecoder.Close();
			return (IEncodeable)body;
		}
		return body;
	}

	public bool CompareExtensionObject(ExtensionObject value1, ExtensionObject value2)
	{
		if (value1 == null || value2 == null)
		{
			if (value1 != value2)
			{
				return ReportError(value1, value2);
			}
			return true;
		}
		object body = value1.Body;
		object body2 = value2.Body;
		if (body == null || body2 == null)
		{
			return body == body2;
		}
		if (value1.Body is byte[] value3 && value2.Body is byte[] value4)
		{
			if (!CompareExpandedNodeId(value1.TypeId, value2.TypeId))
			{
				return ReportError(value1.TypeId, value2.TypeId);
			}
			return CompareByteString(value3, value4);
		}
		if (value1.Body is XmlElement value5 && value2.Body is XmlElement value6)
		{
			if (!CompareExpandedNodeId(value1.TypeId, value2.TypeId))
			{
				return ReportError(value1.TypeId, value2.TypeId);
			}
			return CompareXmlElement(value5, value6);
		}
		body = GetExtensionObjectBody(value1);
		body2 = GetExtensionObjectBody(value2);
		if (!CompareExtensionObjectBody(body, body2))
		{
			return ReportError(value1, value2);
		}
		return true;
	}

	protected virtual bool CompareExtensionObjectBody(object value1, object value2)
	{
		if (value1 == value2)
		{
			return true;
		}
		if (value1 is IEncodeable encodeable && value2 is IEncodeable encodeable2 && encodeable.IsEqual(encodeable2))
		{
			return true;
		}
		return false;
	}

	private bool CompareArray<T>(IEnumerable<T> value1, IEnumerable<T> value2, Comparator<T> comparator)
	{
		if (value1 == null)
		{
			if (value2 == null || !value2.GetEnumerator().MoveNext())
			{
				return true;
			}
			return false;
		}
		if (value2 == null)
		{
			if (value1 == null || !value1.GetEnumerator().MoveNext())
			{
				return true;
			}
			return false;
		}
		IEnumerator<T> enumerator = value1.GetEnumerator();
		IEnumerator<T> enumerator2 = value2.GetEnumerator();
		while (enumerator.MoveNext())
		{
			if (!enumerator2.MoveNext())
			{
				return ReportError(value1, value2);
			}
			if (!comparator(enumerator.Current, enumerator2.Current))
			{
				return false;
			}
		}
		if (enumerator2.MoveNext())
		{
			return ReportError(value1, value2);
		}
		return true;
	}

	private bool ReportError(object value1, object value2)
	{
		if (m_throwOnError)
		{
			throw ServiceResultException.Create(2147549184u, "'{0}' is not equal to '{1}'.", value1, value2);
		}
		return false;
	}
}
