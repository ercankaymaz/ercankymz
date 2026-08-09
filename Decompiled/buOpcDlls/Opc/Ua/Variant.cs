using System;
using System.Collections;
using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;

namespace Opc.Ua;

[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public struct Variant : ICloneable, IFormattable, IEquatable<Variant>
{
	public static readonly Variant Null;

	private object m_value;

	private TypeInfo m_typeInfo;

	[DataMember(Name = "Value", Order = 1)]
	private XmlElement XmlEncodedValue
	{
		get
		{
			using XmlEncoder xmlEncoder = new XmlEncoder(MessageContextExtension.CurrentContext);
			xmlEncoder.WriteVariantContents(m_value, m_typeInfo);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadInnerXml(xmlEncoder.CloseAndReturnText());
			return xmlDocument.DocumentElement;
		}
		set
		{
			if (value == null)
			{
				m_value = null;
				return;
			}
			TypeInfo typeInfo = null;
			XmlDecoder xmlDecoder = new XmlDecoder(value, MessageContextExtension.CurrentContext);
			try
			{
				object value2 = xmlDecoder.ReadVariantContents(out typeInfo);
				Set(value2, typeInfo);
			}
			catch (Exception e)
			{
				throw ServiceResultException.Create(2147942400u, e, "Error decoding Variant value.");
			}
			finally
			{
				xmlDecoder.Close();
			}
		}
	}

	public object Value
	{
		get
		{
			return m_value;
		}
		set
		{
			Set(value, TypeInfo.Construct(value));
		}
	}

	public TypeInfo TypeInfo => m_typeInfo;

	public Variant(Variant value)
	{
		m_value = Utils.Clone(value.m_value);
		m_typeInfo = value.m_typeInfo;
	}

	public Variant(object value, TypeInfo typeInfo)
	{
		m_value = null;
		m_typeInfo = typeInfo;
		Set(value, typeInfo);
	}

	public Variant(object value)
	{
		m_value = null;
		m_typeInfo = TypeInfo.Construct(value);
		Set(value, m_typeInfo);
	}

	public Variant(Matrix value)
	{
		m_value = value;
		m_typeInfo = value.TypeInfo;
	}

	public Variant(bool value)
	{
		m_value = value;
		m_typeInfo = TypeInfo.Scalars.Boolean;
	}

	public Variant(sbyte value)
	{
		m_value = value;
		m_typeInfo = TypeInfo.Scalars.SByte;
	}

	public Variant(byte value)
	{
		m_value = value;
		m_typeInfo = TypeInfo.Scalars.Byte;
	}

	public Variant(short value)
	{
		m_value = value;
		m_typeInfo = TypeInfo.Scalars.Int16;
	}

	public Variant(ushort value)
	{
		m_value = value;
		m_typeInfo = TypeInfo.Scalars.UInt16;
	}

	public Variant(int value)
	{
		m_value = value;
		m_typeInfo = TypeInfo.Scalars.Int32;
	}

	public Variant(uint value)
	{
		m_value = value;
		m_typeInfo = TypeInfo.Scalars.UInt32;
	}

	public Variant(long value)
	{
		m_value = value;
		m_typeInfo = TypeInfo.Scalars.Int64;
	}

	public Variant(ulong value)
	{
		m_value = value;
		m_typeInfo = TypeInfo.Scalars.UInt64;
	}

	public Variant(float value)
	{
		m_value = value;
		m_typeInfo = TypeInfo.Scalars.Float;
	}

	public Variant(double value)
	{
		m_value = value;
		m_typeInfo = TypeInfo.Scalars.Double;
	}

	public Variant(string value)
	{
		m_value = value;
		m_typeInfo = TypeInfo.Scalars.String;
	}

	public Variant(DateTime value)
	{
		m_value = value;
		m_typeInfo = TypeInfo.Scalars.DateTime;
	}

	public Variant(Guid value)
	{
		m_value = new Uuid(value);
		m_typeInfo = TypeInfo.Scalars.Guid;
	}

	public Variant(Uuid value)
	{
		m_value = value;
		m_typeInfo = TypeInfo.Scalars.Guid;
	}

	public Variant(byte[] value)
	{
		m_value = value;
		m_typeInfo = TypeInfo.Scalars.ByteString;
	}

	public Variant(XmlElement value)
	{
		m_value = value;
		m_typeInfo = TypeInfo.Scalars.XmlElement;
	}

	public Variant(NodeId value)
	{
		m_value = value;
		m_typeInfo = TypeInfo.Scalars.NodeId;
	}

	public Variant(ExpandedNodeId value)
	{
		m_value = value;
		m_typeInfo = TypeInfo.Scalars.ExpandedNodeId;
	}

	public Variant(StatusCode value)
	{
		m_value = value;
		m_typeInfo = TypeInfo.Scalars.StatusCode;
	}

	public Variant(QualifiedName value)
	{
		m_value = value;
		m_typeInfo = TypeInfo.Scalars.QualifiedName;
	}

	public Variant(LocalizedText value)
	{
		m_value = value;
		m_typeInfo = TypeInfo.Scalars.LocalizedText;
	}

	public Variant(ExtensionObject value)
	{
		m_value = value;
		m_typeInfo = TypeInfo.Scalars.ExtensionObject;
	}

	public Variant(DataValue value)
	{
		m_value = value;
		m_typeInfo = TypeInfo.Scalars.DataValue;
	}

	public Variant(bool[] value)
	{
		m_value = value;
		m_typeInfo = TypeInfo.Arrays.Boolean;
	}

	public Variant(sbyte[] value)
	{
		m_value = value;
		m_typeInfo = TypeInfo.Arrays.SByte;
	}

	public Variant(short[] value)
	{
		m_value = value;
		m_typeInfo = TypeInfo.Arrays.Int16;
	}

	public Variant(ushort[] value)
	{
		m_value = value;
		m_typeInfo = TypeInfo.Arrays.UInt16;
	}

	public Variant(int[] value)
	{
		m_value = value;
		m_typeInfo = TypeInfo.Arrays.Int32;
	}

	public Variant(uint[] value)
	{
		m_value = value;
		m_typeInfo = TypeInfo.Arrays.UInt32;
	}

	public Variant(long[] value)
	{
		m_value = value;
		m_typeInfo = TypeInfo.Arrays.Int64;
	}

	public Variant(ulong[] value)
	{
		m_value = value;
		m_typeInfo = TypeInfo.Arrays.UInt64;
	}

	public Variant(float[] value)
	{
		m_value = value;
		m_typeInfo = TypeInfo.Arrays.Float;
	}

	public Variant(double[] value)
	{
		m_value = value;
		m_typeInfo = TypeInfo.Arrays.Double;
	}

	public Variant(string[] value)
	{
		m_value = value;
		m_typeInfo = TypeInfo.Arrays.String;
	}

	public Variant(DateTime[] value)
	{
		m_value = value;
		m_typeInfo = TypeInfo.Arrays.DateTime;
	}

	public Variant(Guid[] value)
	{
		m_value = null;
		m_typeInfo = TypeInfo.Arrays.Guid;
		Set(value);
	}

	public Variant(Uuid[] value)
	{
		m_value = value;
		m_typeInfo = TypeInfo.Arrays.Guid;
	}

	public Variant(byte[][] value)
	{
		m_value = value;
		m_typeInfo = TypeInfo.Arrays.ByteString;
	}

	public Variant(XmlElement[] value)
	{
		m_value = value;
		m_typeInfo = TypeInfo.Arrays.XmlElement;
	}

	public Variant(NodeId[] value)
	{
		m_value = value;
		m_typeInfo = TypeInfo.Arrays.NodeId;
	}

	public Variant(ExpandedNodeId[] value)
	{
		m_value = value;
		m_typeInfo = TypeInfo.Arrays.ExpandedNodeId;
	}

	public Variant(StatusCode[] value)
	{
		m_value = value;
		m_typeInfo = TypeInfo.Arrays.StatusCode;
	}

	public Variant(QualifiedName[] value)
	{
		m_value = value;
		m_typeInfo = TypeInfo.Arrays.QualifiedName;
	}

	public Variant(LocalizedText[] value)
	{
		m_value = value;
		m_typeInfo = TypeInfo.Arrays.LocalizedText;
	}

	public Variant(ExtensionObject[] value)
	{
		m_value = value;
		m_typeInfo = TypeInfo.Arrays.ExtensionObject;
	}

	public Variant(DataValue[] value)
	{
		m_value = value;
		m_typeInfo = TypeInfo.Arrays.DataValue;
	}

	public Variant(Variant[] value)
	{
		m_value = value;
		m_typeInfo = TypeInfo.Arrays.Variant;
	}

	public Variant(object[] value)
	{
		m_value = null;
		m_typeInfo = TypeInfo.Arrays.Variant;
		Set(value);
	}

	public string ToString(string format, IFormatProvider formatProvider)
	{
		if (format == null)
		{
			StringBuilder stringBuilder = new StringBuilder();
			AppendFormat(stringBuilder, m_value, formatProvider);
			return stringBuilder.ToString();
		}
		throw new FormatException(Utils.Format("Invalid format string: '{0}'.", format));
	}

	private void AppendByteString(StringBuilder buffer, byte[] bytes, IFormatProvider formatProvider)
	{
		if (bytes != null)
		{
			for (int i = 0; i < bytes.Length; i++)
			{
				buffer.AppendFormat(formatProvider, "{0:X2}", bytes[i]);
			}
		}
		else
		{
			buffer.Append("(null)");
		}
	}

	private void AppendFormat(StringBuilder buffer, object value, IFormatProvider formatProvider)
	{
		if (value == null || m_typeInfo == null)
		{
			buffer.Append("(null)");
		}
		else if (m_typeInfo.BuiltInType == BuiltInType.ByteString && m_typeInfo.ValueRank < 0)
		{
			byte[] bytes = (byte[])value;
			AppendByteString(buffer, bytes, formatProvider);
		}
		else if (m_typeInfo.BuiltInType == BuiltInType.XmlElement && m_typeInfo.ValueRank < 0)
		{
			XmlElement xmlElement = (XmlElement)value;
			buffer.AppendFormat(formatProvider, "{0}", xmlElement.OuterXml);
		}
		else if (value is Array array && m_typeInfo.ValueRank <= 1)
		{
			buffer.Append('{');
			if (m_typeInfo.BuiltInType == BuiltInType.ByteString)
			{
				if (array.Length > 0)
				{
					byte[] bytes2 = (byte[])array.GetValue(0);
					AppendByteString(buffer, bytes2, formatProvider);
				}
				for (int i = 1; i < array.Length; i++)
				{
					buffer.Append('|');
					byte[] bytes3 = (byte[])array.GetValue(i);
					AppendByteString(buffer, bytes3, formatProvider);
				}
			}
			else
			{
				if (array.Length > 0)
				{
					AppendFormat(buffer, array.GetValue(0), formatProvider);
				}
				for (int j = 1; j < array.Length; j++)
				{
					buffer.Append('|');
					AppendFormat(buffer, array.GetValue(j), formatProvider);
				}
			}
			buffer.Append('}');
		}
		else
		{
			buffer.AppendFormat(formatProvider, "{0}", value);
		}
	}

	public object Clone()
	{
		return MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		return new Variant(Utils.Clone(Value));
	}

	public static bool operator ==(Variant a, Variant b)
	{
		return a.Equals(b);
	}

	public static bool operator !=(Variant a, Variant b)
	{
		return !a.Equals(b);
	}

	public static implicit operator Variant(bool value)
	{
		return new Variant(value);
	}

	public static implicit operator Variant(sbyte value)
	{
		return new Variant(value);
	}

	public static implicit operator Variant(byte value)
	{
		return new Variant(value);
	}

	public static implicit operator Variant(short value)
	{
		return new Variant(value);
	}

	public static implicit operator Variant(ushort value)
	{
		return new Variant(value);
	}

	public static implicit operator Variant(int value)
	{
		return new Variant(value);
	}

	public static implicit operator Variant(uint value)
	{
		return new Variant(value);
	}

	public static implicit operator Variant(long value)
	{
		return new Variant(value);
	}

	public static implicit operator Variant(ulong value)
	{
		return new Variant(value);
	}

	public static implicit operator Variant(float value)
	{
		return new Variant(value);
	}

	public static implicit operator Variant(double value)
	{
		return new Variant(value);
	}

	public static implicit operator Variant(string value)
	{
		return new Variant(value);
	}

	public static implicit operator Variant(DateTime value)
	{
		return new Variant(value);
	}

	public static implicit operator Variant(Guid value)
	{
		return new Variant(value);
	}

	public static implicit operator Variant(Uuid value)
	{
		return new Variant(value);
	}

	public static implicit operator Variant(byte[] value)
	{
		return new Variant(value);
	}

	public static implicit operator Variant(XmlElement value)
	{
		return new Variant(value);
	}

	public static implicit operator Variant(NodeId value)
	{
		return new Variant(value);
	}

	public static implicit operator Variant(ExpandedNodeId value)
	{
		return new Variant(value);
	}

	public static implicit operator Variant(StatusCode value)
	{
		return new Variant(value);
	}

	public static implicit operator Variant(QualifiedName value)
	{
		return new Variant(value);
	}

	public static implicit operator Variant(LocalizedText value)
	{
		return new Variant(value);
	}

	public static implicit operator Variant(ExtensionObject value)
	{
		return new Variant(value);
	}

	public static implicit operator Variant(DataValue value)
	{
		return new Variant(value);
	}

	public static implicit operator Variant(bool[] value)
	{
		return new Variant(value);
	}

	public static implicit operator Variant(sbyte[] value)
	{
		return new Variant(value);
	}

	public static implicit operator Variant(short[] value)
	{
		return new Variant(value);
	}

	public static implicit operator Variant(ushort[] value)
	{
		return new Variant(value);
	}

	public static implicit operator Variant(int[] value)
	{
		return new Variant(value);
	}

	public static implicit operator Variant(uint[] value)
	{
		return new Variant(value);
	}

	public static implicit operator Variant(long[] value)
	{
		return new Variant(value);
	}

	public static implicit operator Variant(ulong[] value)
	{
		return new Variant(value);
	}

	public static implicit operator Variant(float[] value)
	{
		return new Variant(value);
	}

	public static implicit operator Variant(double[] value)
	{
		return new Variant(value);
	}

	public static implicit operator Variant(string[] value)
	{
		return new Variant(value);
	}

	public static implicit operator Variant(DateTime[] value)
	{
		return new Variant(value);
	}

	public static implicit operator Variant(Guid[] value)
	{
		return new Variant(value);
	}

	public static implicit operator Variant(Uuid[] value)
	{
		return new Variant(value);
	}

	public static implicit operator Variant(byte[][] value)
	{
		return new Variant(value);
	}

	public static implicit operator Variant(XmlElement[] value)
	{
		return new Variant(value);
	}

	public static implicit operator Variant(NodeId[] value)
	{
		return new Variant(value);
	}

	public static implicit operator Variant(ExpandedNodeId[] value)
	{
		return new Variant(value);
	}

	public static implicit operator Variant(StatusCode[] value)
	{
		return new Variant(value);
	}

	public static implicit operator Variant(QualifiedName[] value)
	{
		return new Variant(value);
	}

	public static implicit operator Variant(LocalizedText[] value)
	{
		return new Variant(value);
	}

	public static implicit operator Variant(ExtensionObject[] value)
	{
		return new Variant(value);
	}

	public static implicit operator Variant(DataValue[] value)
	{
		return new Variant(value);
	}

	public static implicit operator Variant(Variant[] value)
	{
		return new Variant(value);
	}

	public static implicit operator Variant(object[] value)
	{
		return new Variant(value);
	}

	public bool Equals(Variant other)
	{
		Variant? variant = other;
		if (variant.HasValue)
		{
			return Utils.IsEqual(m_value, variant.Value.m_value);
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		Variant? variant = obj as Variant?;
		if (variant.HasValue)
		{
			return Utils.IsEqual(m_value, variant.Value.m_value);
		}
		return false;
	}

	public override int GetHashCode()
	{
		if (m_value != null)
		{
			return m_value.GetHashCode();
		}
		return 0;
	}

	public override string ToString()
	{
		return ToString(null, null);
	}

	public void Set(bool value)
	{
		m_value = value;
		m_typeInfo = TypeInfo.Scalars.Boolean;
	}

	public void Set(sbyte value)
	{
		m_value = value;
		m_typeInfo = TypeInfo.Scalars.SByte;
	}

	public void Set(byte value)
	{
		m_value = value;
		m_typeInfo = TypeInfo.Scalars.Byte;
	}

	public void Set(short value)
	{
		m_value = value;
		m_typeInfo = TypeInfo.Scalars.Int16;
	}

	public void Set(ushort value)
	{
		m_value = value;
		m_typeInfo = TypeInfo.Scalars.UInt16;
	}

	public void Set(int value)
	{
		m_value = value;
		m_typeInfo = TypeInfo.Scalars.Int32;
	}

	public void Set(uint value)
	{
		m_value = value;
		m_typeInfo = TypeInfo.Scalars.UInt32;
	}

	public void Set(long value)
	{
		m_value = value;
		m_typeInfo = TypeInfo.Scalars.Int64;
	}

	public void Set(ulong value)
	{
		m_value = value;
		m_typeInfo = TypeInfo.Scalars.UInt64;
	}

	public void Set(float value)
	{
		m_value = value;
		m_typeInfo = TypeInfo.Scalars.Float;
	}

	public void Set(double value)
	{
		m_value = value;
		m_typeInfo = TypeInfo.Scalars.Double;
	}

	public void Set(string value)
	{
		m_value = value;
		m_typeInfo = TypeInfo.Scalars.String;
	}

	public void Set(DateTime value)
	{
		m_value = value;
		m_typeInfo = TypeInfo.Scalars.DateTime;
	}

	public void Set(Guid value)
	{
		m_value = new Uuid(value);
		m_typeInfo = TypeInfo.Scalars.Guid;
	}

	public void Set(Uuid value)
	{
		m_value = value;
		m_typeInfo = TypeInfo.Scalars.Guid;
	}

	public void Set(byte[] value)
	{
		m_value = value;
		m_typeInfo = TypeInfo.Scalars.ByteString;
	}

	public void Set(XmlElement value)
	{
		m_value = value;
		m_typeInfo = TypeInfo.Scalars.XmlElement;
	}

	public void Set(NodeId value)
	{
		m_value = value;
		m_typeInfo = TypeInfo.Scalars.NodeId;
	}

	public void Set(ExpandedNodeId value)
	{
		m_value = value;
		m_typeInfo = TypeInfo.Scalars.ExpandedNodeId;
	}

	public void Set(StatusCode value)
	{
		m_value = value;
		m_typeInfo = TypeInfo.Scalars.StatusCode;
	}

	public void Set(QualifiedName value)
	{
		m_value = value;
		m_typeInfo = TypeInfo.Scalars.QualifiedName;
	}

	public void Set(LocalizedText value)
	{
		m_value = value;
		m_typeInfo = TypeInfo.Scalars.LocalizedText;
	}

	public void Set(ExtensionObject value)
	{
		m_value = value;
		m_typeInfo = TypeInfo.Scalars.ExtensionObject;
	}

	public void Set(DataValue value)
	{
		m_value = value;
		m_typeInfo = TypeInfo.Scalars.DataValue;
	}

	public void Set(bool[] value)
	{
		m_value = value;
		m_typeInfo = TypeInfo.Arrays.Boolean;
	}

	public void Set(sbyte[] value)
	{
		m_value = value;
		m_typeInfo = TypeInfo.Arrays.SByte;
	}

	public void Set(short[] value)
	{
		m_value = value;
		m_typeInfo = TypeInfo.Arrays.Int16;
	}

	public void Set(ushort[] value)
	{
		m_value = value;
		m_typeInfo = TypeInfo.Arrays.UInt16;
	}

	public void Set(int[] value)
	{
		m_value = value;
		m_typeInfo = TypeInfo.Arrays.Int32;
	}

	public void Set(uint[] value)
	{
		m_value = value;
		m_typeInfo = TypeInfo.Arrays.UInt32;
	}

	public void Set(long[] value)
	{
		m_value = value;
		m_typeInfo = TypeInfo.Arrays.Int64;
	}

	public void Set(ulong[] value)
	{
		m_value = value;
		m_typeInfo = TypeInfo.Arrays.UInt64;
	}

	public void Set(float[] value)
	{
		m_value = value;
		m_typeInfo = TypeInfo.Arrays.Float;
	}

	public void Set(double[] value)
	{
		m_value = value;
		m_typeInfo = TypeInfo.Arrays.Double;
	}

	public void Set(string[] value)
	{
		m_value = value;
		m_typeInfo = TypeInfo.Arrays.String;
	}

	public void Set(DateTime[] value)
	{
		m_value = value;
		m_typeInfo = TypeInfo.Arrays.DateTime;
	}

	public void Set(Guid[] value)
	{
		m_value = null;
		if (value != null)
		{
			Uuid[] array = new Uuid[value.Length];
			for (int i = 0; i < value.Length; i++)
			{
				array[i] = new Uuid(value[i]);
			}
			m_value = array;
		}
		m_typeInfo = TypeInfo.Arrays.Guid;
	}

	public void Set(Uuid[] value)
	{
		m_value = value;
		m_typeInfo = TypeInfo.Arrays.Guid;
	}

	public void Set(byte[][] value)
	{
		m_value = value;
		m_typeInfo = TypeInfo.Arrays.ByteString;
	}

	public void Set(XmlElement[] value)
	{
		m_value = value;
		m_typeInfo = TypeInfo.Arrays.XmlElement;
	}

	public void Set(NodeId[] value)
	{
		m_value = value;
		m_typeInfo = TypeInfo.Arrays.NodeId;
	}

	public void Set(ExpandedNodeId[] value)
	{
		m_value = value;
		m_typeInfo = TypeInfo.Arrays.ExpandedNodeId;
	}

	public void Set(StatusCode[] value)
	{
		m_value = value;
		m_typeInfo = TypeInfo.Arrays.StatusCode;
	}

	public void Set(QualifiedName[] value)
	{
		m_value = value;
		m_typeInfo = TypeInfo.Arrays.QualifiedName;
	}

	public void Set(LocalizedText[] value)
	{
		m_value = value;
		m_typeInfo = TypeInfo.Arrays.LocalizedText;
	}

	public void Set(ExtensionObject[] value)
	{
		m_value = value;
		m_typeInfo = TypeInfo.Arrays.ExtensionObject;
	}

	public void Set(DataValue[] value)
	{
		m_value = value;
		m_typeInfo = TypeInfo.Arrays.DataValue;
	}

	public void Set(Variant[] value)
	{
		m_value = value;
		m_typeInfo = TypeInfo.Arrays.Variant;
	}

	public void Set(object[] value)
	{
		m_value = null;
		if (value != null)
		{
			Variant[] array = new Variant[value.Length];
			for (int i = 0; i < value.Length; i++)
			{
				array[i] = new Variant(value[i]);
			}
			m_value = array;
		}
		m_typeInfo = TypeInfo.Arrays.Variant;
	}

	private void SetScalar(object value, TypeInfo typeInfo)
	{
		m_typeInfo = typeInfo;
		switch (typeInfo.BuiltInType)
		{
		case BuiltInType.Null:
			if (value.GetType().GetTypeInfo().IsEnum)
			{
				Set(Convert.ToInt32(value, CultureInfo.InvariantCulture));
				break;
			}
			if (value is Matrix value2)
			{
				m_value = value2;
				break;
			}
			throw new ServiceResultException(2151481344u, Utils.Format("The type '{0}' cannot be stored in a Variant object.", value.GetType().FullName));
		case BuiltInType.Guid:
		{
			Guid? guid = value as Guid?;
			if (guid.HasValue)
			{
				m_value = new Uuid(guid.Value);
			}
			else
			{
				m_value = value;
			}
			break;
		}
		case BuiltInType.ExtensionObject:
			if (value is IEncodeable body)
			{
				m_value = new ExtensionObject(body);
			}
			else
			{
				m_value = value;
			}
			break;
		case BuiltInType.Variant:
			m_value = ((Variant)value).Value;
			m_typeInfo = TypeInfo.Construct(m_value);
			break;
		default:
			m_value = value;
			break;
		}
	}

	private void SetArray(Array array, TypeInfo typeInfo)
	{
		m_typeInfo = typeInfo;
		switch (typeInfo.BuiltInType)
		{
		case BuiltInType.Null:
			if (array.GetType().GetElementType().GetTypeInfo()
				.IsEnum)
			{
				int[] array6 = new int[array.Length];
				for (int k = 0; k < array.Length; k++)
				{
					array6[k] = Convert.ToInt32(array.GetValue(k), CultureInfo.InvariantCulture);
				}
				m_value = array6;
				break;
			}
			throw new ServiceResultException(2151481344u, Utils.Format("The type '{0}' cannot be stored in a Variant object.", array.GetType().FullName));
		case BuiltInType.Guid:
			if (array is Guid[] value)
			{
				Set(value);
			}
			else
			{
				m_value = array;
			}
			break;
		case BuiltInType.ExtensionObject:
			if (array is IEncodeable[] array4)
			{
				ExtensionObject[] array5 = new ExtensionObject[array4.Length];
				for (int j = 0; j < array4.Length; j++)
				{
					array5[j] = new ExtensionObject(array4[j]);
				}
				m_value = array5;
			}
			else
			{
				m_value = array;
			}
			break;
		case BuiltInType.Variant:
			if (array is object[] array2)
			{
				Variant[] array3 = new Variant[array2.Length];
				for (int i = 0; i < array2.Length; i++)
				{
					array3[i] = new Variant(array2[i]);
				}
				m_value = array3;
			}
			else
			{
				m_value = array;
			}
			break;
		default:
			m_value = array;
			break;
		}
	}

	private void SetList(IList value, TypeInfo typeInfo)
	{
		m_typeInfo = typeInfo;
		Array array = TypeInfo.CreateArray(typeInfo.BuiltInType, value.Count);
		for (int i = 0; i < value.Count; i++)
		{
			if (typeInfo.BuiltInType == BuiltInType.ExtensionObject && value[i] is IEncodeable body)
			{
				array.SetValue(new ExtensionObject(body), i);
			}
			else
			{
				array.SetValue(value[i], i);
			}
		}
		SetArray(array, typeInfo);
	}

	private void Set(object value, TypeInfo typeInfo)
	{
		if (value == null)
		{
			m_value = null;
			m_typeInfo = typeInfo;
			return;
		}
		if (typeInfo.ValueRank < 0)
		{
			SetScalar(value, typeInfo);
			return;
		}
		Array array = value as Array;
		if (typeInfo.ValueRank <= 1)
		{
			if (array != null)
			{
				SetArray(array, typeInfo);
				return;
			}
			if (value is IList value2)
			{
				SetList(value2, typeInfo);
				return;
			}
		}
		if (array != null)
		{
			m_value = new Matrix(array, typeInfo.BuiltInType);
			m_typeInfo = typeInfo;
			return;
		}
		if (value is Matrix matrix)
		{
			m_value = matrix;
			m_typeInfo = matrix.TypeInfo;
			return;
		}
		throw new ServiceResultException(2151481344u, Utils.Format("Arrays of the type '{0}' cannot be stored in a Variant object.", value.GetType().FullName));
	}

	static Variant()
	{
	}
}
