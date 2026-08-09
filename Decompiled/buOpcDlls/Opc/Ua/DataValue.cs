using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class DataValue : ICloneable, IFormattable, IEquatable<DataValue>
{
	private Variant m_value;

	private StatusCode m_statusCode;

	private DateTime m_sourceTimestamp;

	private ushort m_sourcePicoseconds;

	private DateTime m_serverTimestamp;

	private ushort m_serverPicoseconds;

	public object Value
	{
		get
		{
			return m_value.Value;
		}
		set
		{
			m_value.Value = value;
		}
	}

	[DataMember(Name = "Value", Order = 1, IsRequired = false)]
	public Variant WrappedValue
	{
		get
		{
			return m_value;
		}
		set
		{
			m_value = value;
		}
	}

	[DataMember(Order = 2, IsRequired = false)]
	public StatusCode StatusCode
	{
		get
		{
			return m_statusCode;
		}
		set
		{
			m_statusCode = value;
		}
	}

	[DataMember(Order = 3, IsRequired = false)]
	public DateTime SourceTimestamp
	{
		get
		{
			return m_sourceTimestamp;
		}
		set
		{
			m_sourceTimestamp = value;
		}
	}

	[DataMember(Order = 4, IsRequired = false)]
	public ushort SourcePicoseconds
	{
		get
		{
			return m_sourcePicoseconds;
		}
		set
		{
			m_sourcePicoseconds = value;
		}
	}

	[DataMember(Order = 5, IsRequired = false)]
	public DateTime ServerTimestamp
	{
		get
		{
			return m_serverTimestamp;
		}
		set
		{
			m_serverTimestamp = value;
		}
	}

	[DataMember(Order = 6, IsRequired = false)]
	public ushort ServerPicoseconds
	{
		get
		{
			return m_serverPicoseconds;
		}
		set
		{
			m_serverPicoseconds = value;
		}
	}

	public DataValue()
	{
		Initialize();
	}

	public DataValue(DataValue value)
	{
		if (value == null)
		{
			throw new ArgumentNullException("value");
		}
		m_value.Value = Utils.Clone(value.m_value.Value);
		m_statusCode = value.m_statusCode;
		m_sourceTimestamp = value.m_sourceTimestamp;
		m_sourcePicoseconds = value.m_sourcePicoseconds;
		m_serverTimestamp = value.m_serverTimestamp;
		m_serverPicoseconds = value.m_serverPicoseconds;
	}

	public DataValue(Variant value)
	{
		Initialize();
		m_value = value;
	}

	public DataValue(StatusCode statusCode)
	{
		Initialize();
		m_statusCode = statusCode;
	}

	public DataValue(StatusCode statusCode, DateTime serverTimestamp)
	{
		Initialize();
		m_statusCode = statusCode;
		m_serverTimestamp = serverTimestamp;
	}

	public DataValue(Variant value, StatusCode statusCode)
	{
		Initialize();
		m_value = value;
		m_statusCode = statusCode;
	}

	public DataValue(Variant value, StatusCode statusCode, DateTime sourceTimestamp)
	{
		Initialize();
		m_value = value;
		m_statusCode = statusCode;
		m_sourceTimestamp = sourceTimestamp;
	}

	public DataValue(Variant value, StatusCode statusCode, DateTime sourceTimestamp, DateTime serverTimestamp)
	{
		Initialize();
		m_value = value;
		m_statusCode = statusCode;
		m_sourceTimestamp = sourceTimestamp;
		m_serverTimestamp = serverTimestamp;
	}

	private void Initialize()
	{
		m_value = Variant.Null;
		m_statusCode = 0u;
		m_sourceTimestamp = DateTime.MinValue;
		m_serverTimestamp = DateTime.MinValue;
	}

	public override bool Equals(object obj)
	{
		if (this == obj)
		{
			return true;
		}
		if (obj is DataValue dataValue)
		{
			if (m_statusCode != dataValue.m_statusCode)
			{
				return false;
			}
			if (m_serverTimestamp != dataValue.m_serverTimestamp)
			{
				return false;
			}
			if (m_sourceTimestamp != dataValue.m_sourceTimestamp)
			{
				return false;
			}
			if (m_serverPicoseconds != dataValue.m_serverPicoseconds)
			{
				return false;
			}
			if (m_sourcePicoseconds != dataValue.m_sourcePicoseconds)
			{
				return false;
			}
			return Utils.IsEqual(m_value.Value, dataValue.m_value.Value);
		}
		return false;
	}

	public bool Equals(DataValue other)
	{
		if (this == other)
		{
			return true;
		}
		if (other != null)
		{
			if (m_statusCode != other.m_statusCode)
			{
				return false;
			}
			if (m_serverTimestamp != other.m_serverTimestamp)
			{
				return false;
			}
			if (m_sourceTimestamp != other.m_sourceTimestamp)
			{
				return false;
			}
			if (m_serverPicoseconds != other.m_serverPicoseconds)
			{
				return false;
			}
			if (m_sourcePicoseconds != other.m_sourcePicoseconds)
			{
				return false;
			}
			return Utils.IsEqual(m_value.Value, other.m_value.Value);
		}
		return false;
	}

	public override int GetHashCode()
	{
		if (m_value.Value != null)
		{
			return m_value.Value.GetHashCode();
		}
		return m_statusCode.GetHashCode();
	}

	public override string ToString()
	{
		return ToString(null, null);
	}

	public string ToString(string format, IFormatProvider formatProvider)
	{
		if (format == null)
		{
			return string.Format(formatProvider, "{0}", m_value);
		}
		throw new FormatException(Utils.Format("Invalid format string: '{0}'.", format));
	}

	public virtual object Clone()
	{
		return MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		return new DataValue(this);
	}

	public static bool IsGood(DataValue value)
	{
		if (value != null)
		{
			return StatusCode.IsGood(value.m_statusCode);
		}
		return false;
	}

	public static bool IsNotGood(DataValue value)
	{
		if (value != null)
		{
			return StatusCode.IsNotGood(value.m_statusCode);
		}
		return true;
	}

	public static bool IsUncertain(DataValue value)
	{
		if (value != null)
		{
			return StatusCode.IsUncertain(value.m_statusCode);
		}
		return false;
	}

	public static bool IsNotUncertain(DataValue value)
	{
		if (value != null)
		{
			return StatusCode.IsNotUncertain(value.m_statusCode);
		}
		return false;
	}

	public static bool IsBad(DataValue value)
	{
		if (value != null)
		{
			return StatusCode.IsBad(value.m_statusCode);
		}
		return true;
	}

	public static bool IsNotBad(DataValue value)
	{
		if (value != null)
		{
			return StatusCode.IsNotBad(value.m_statusCode);
		}
		return false;
	}

	public object GetValue(Type expectedType)
	{
		object obj = Value;
		if (expectedType != null && obj != null)
		{
			if (StatusCode.IsBad(StatusCode))
			{
				return null;
			}
			if (obj is ExtensionObject extensionObject)
			{
				obj = extensionObject.Body;
			}
			if (!expectedType.IsInstanceOfType(obj))
			{
				throw ServiceResultException.Create(2155085824u, "DataValue is not of type {0}.", expectedType.Name);
			}
		}
		return obj;
	}

	public T GetValue<T>(T defaultValue)
	{
		if (StatusCode.IsNotGood(StatusCode))
		{
			return defaultValue;
		}
		if (typeof(T).IsInstanceOfType(Value))
		{
			return (T)Value;
		}
		if (Value is ExtensionObject extensionObject && typeof(T).IsInstanceOfType(extensionObject.Body))
		{
			return (T)extensionObject.Body;
		}
		return defaultValue;
	}
}
