using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;

namespace Opc.Ua;

[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class ExtensionObject : IFormattable, ICloneable
{
	private static readonly ExtensionObject s_Null = new ExtensionObject();

	private ExpandedNodeId m_typeId;

	private ExtensionObjectEncoding m_encoding;

	private object m_body;

	private IServiceMessageContext m_context;

	public ExpandedNodeId TypeId
	{
		get
		{
			return m_typeId;
		}
		set
		{
			m_typeId = value;
		}
	}

	public ExtensionObjectEncoding Encoding => m_encoding;

	public object Body
	{
		get
		{
			return m_body;
		}
		set
		{
			m_body = value;
			if (m_body == null)
			{
				m_encoding = ExtensionObjectEncoding.None;
				return;
			}
			if (m_body is IEncodeable)
			{
				m_encoding = ExtensionObjectEncoding.EncodeableObject;
				return;
			}
			if (m_body is byte[])
			{
				m_encoding = ExtensionObjectEncoding.Binary;
				return;
			}
			if (m_body is XmlElement)
			{
				m_encoding = ExtensionObjectEncoding.Xml;
				return;
			}
			throw new ServiceResultException(2151481344u, Utils.Format("Cannot add a object with type '{0}' to an extension object.", m_body.GetType().FullName));
		}
	}

	public static ExtensionObject Null => s_Null;

	[DataMember(Name = "TypeId", Order = 1, IsRequired = false, EmitDefaultValue = true)]
	private NodeId XmlEncodedTypeId
	{
		get
		{
			if (m_body is IEncodeable encodeable)
			{
				return ExpandedNodeId.ToNodeId(encodeable.XmlEncodingId, m_context.NamespaceUris);
			}
			if (m_typeId.IsNull)
			{
				return NodeId.Null;
			}
			return ExpandedNodeId.ToNodeId(m_typeId, m_context.NamespaceUris);
		}
		set
		{
			m_typeId = NodeId.ToExpandedNodeId(value, m_context.NamespaceUris);
		}
	}

	[DataMember(Name = "Body", Order = 2, IsRequired = false, EmitDefaultValue = true)]
	private XmlElement XmlEncodedBody
	{
		get
		{
			if (m_body == null)
			{
				return null;
			}
			using XmlEncoder xmlEncoder = new XmlEncoder(m_context);
			xmlEncoder.WriteExtensionObjectBody(m_body);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadInnerXml(xmlEncoder.CloseAndReturnText());
			return xmlDocument.DocumentElement;
		}
		set
		{
			if (value == null)
			{
				Body = null;
				return;
			}
			XmlDecoder xmlDecoder = new XmlDecoder(value, m_context);
			Body = xmlDecoder.ReadExtensionObjectBody(m_typeId);
			if (m_body is IEncodeable)
			{
				m_typeId = ExpandedNodeId.Null;
			}
			try
			{
				xmlDecoder.Close(checkEof: true);
			}
			catch (Exception e)
			{
				throw new ServiceResultException(2147942400u, Utils.Format("Did not read all of a extension object body: '{0}'", m_typeId), e);
			}
		}
	}

	public ExtensionObject()
	{
		m_typeId = ExpandedNodeId.Null;
		m_encoding = ExtensionObjectEncoding.None;
		m_body = null;
		m_context = MessageContextExtension.CurrentContext;
	}

	public ExtensionObject(ExtensionObject value)
	{
		if (value == null)
		{
			throw new ArgumentNullException("value");
		}
		TypeId = value.TypeId;
		Body = Utils.Clone(value.Body);
	}

	public ExtensionObject(ExpandedNodeId typeId)
	{
		TypeId = typeId;
		Body = null;
	}

	public ExtensionObject(object body)
		: this(ExpandedNodeId.Null, body)
	{
	}

	public ExtensionObject(ExpandedNodeId typeId, object body)
	{
		TypeId = typeId;
		Body = body;
	}

	[OnSerializing]
	private void UpdateContext(StreamingContext context)
	{
		m_context = MessageContextExtension.CurrentContext;
	}

	[OnDeserializing]
	private void Initialize(StreamingContext context)
	{
		m_typeId = ExpandedNodeId.Null;
		m_encoding = ExtensionObjectEncoding.None;
		m_body = null;
		m_context = MessageContextExtension.CurrentContext;
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return IsNull(this);
		}
		if (this == obj)
		{
			return true;
		}
		if (obj is ExtensionObject extensionObject)
		{
			if (m_typeId != extensionObject.m_typeId)
			{
				return false;
			}
			return Utils.IsEqual(m_body, extensionObject.m_body);
		}
		return false;
	}

	public override int GetHashCode()
	{
		if (m_body != null)
		{
			return m_body.GetHashCode();
		}
		if (m_typeId != null)
		{
			return m_typeId.GetHashCode();
		}
		return 0;
	}

	public override string ToString()
	{
		return ToString(null, null);
	}

	public string ToString(string format, IFormatProvider formatProvider)
	{
		if (format == null)
		{
			if (m_body is byte[] array)
			{
				return string.Format(formatProvider, "Byte[{0}]", array.Length);
			}
			if (m_body is XmlElement xmlElement)
			{
				return string.Format(formatProvider, "<{0}>", xmlElement.Name);
			}
			if (m_body is IFormattable formattable)
			{
				return string.Format(formatProvider, "{0}", formattable.ToString(null, formatProvider));
			}
			if (m_body is IEncodeable)
			{
				StringBuilder stringBuilder = new StringBuilder();
				PropertyInfo[] properties = m_body.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy);
				foreach (PropertyInfo propertyInfo in properties)
				{
					object[] array2 = propertyInfo.GetCustomAttributes(typeof(DataMemberAttribute), inherit: true).ToArray();
					for (int j = 0; j < array2.Length; j++)
					{
						if (array2[j] is DataMemberAttribute)
						{
							if (stringBuilder.Length == 0)
							{
								stringBuilder.Append('{');
							}
							else
							{
								stringBuilder.Append(" | ");
							}
							stringBuilder.AppendFormat("{0}", propertyInfo.GetGetMethod().Invoke(m_body, null));
						}
					}
				}
				if (stringBuilder.Length > 0)
				{
					stringBuilder.Append('}');
				}
				return string.Format(formatProvider, "{0}", stringBuilder);
			}
			if (!NodeId.IsNull(m_typeId))
			{
				return string.Format(formatProvider, "{{{0}}}", m_typeId);
			}
			return "(null)";
		}
		throw new FormatException(Utils.Format("Invalid format string: '{0}'.", format));
	}

	public virtual object Clone()
	{
		return MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		return new ExtensionObject(this);
	}

	public static bool IsNull(ExtensionObject extension)
	{
		if (extension != null && extension.m_body != null)
		{
			return false;
		}
		return true;
	}

	public static IEncodeable ToEncodeable(ExtensionObject extension)
	{
		if (extension == null)
		{
			return null;
		}
		return extension.Body as IEncodeable;
	}

	public static Array ToArray(object source, Type elementType)
	{
		if (!(source is Array array))
		{
			return null;
		}
		Array array2 = Array.CreateInstance(elementType, array.Length);
		for (int i = 0; i < array2.Length; i++)
		{
			IEncodeable encodeable = ToEncodeable(array.GetValue(i) as ExtensionObject);
			if (elementType.IsInstanceOfType(encodeable))
			{
				array2.SetValue(encodeable, i);
			}
		}
		return array2;
	}

	public static List<T> ToList<T>(object source) where T : class
	{
		if (!(source is Array array))
		{
			return null;
		}
		List<T> list = new List<T>();
		for (int i = 0; i < array.Length; i++)
		{
			IEncodeable encodeable = ToEncodeable(array.GetValue(i) as ExtensionObject);
			if (typeof(T).IsInstanceOfType(encodeable))
			{
				list.Add((T)encodeable);
			}
			else
			{
				list.Add(null);
			}
		}
		return list;
	}
}
