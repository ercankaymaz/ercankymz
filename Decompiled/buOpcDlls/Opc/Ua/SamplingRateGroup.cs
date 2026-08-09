using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[DataContract(Namespace = "http://opcfoundation.org/UA/SDK/Configuration.xsd")]
[ComVisible(true)]
public class SamplingRateGroup
{
	private double m_start;

	private double m_increment;

	private int m_count;

	[DataMember(IsRequired = false, Order = 1)]
	public double Start
	{
		get
		{
			return m_start;
		}
		set
		{
			m_start = value;
		}
	}

	[DataMember(IsRequired = false, Order = 2)]
	public double Increment
	{
		get
		{
			return m_increment;
		}
		set
		{
			m_increment = value;
		}
	}

	[DataMember(IsRequired = false, Order = 3)]
	public int Count
	{
		get
		{
			return m_count;
		}
		set
		{
			m_count = value;
		}
	}

	public SamplingRateGroup()
	{
		Initialize();
	}

	public SamplingRateGroup(int start, int increment, int count)
	{
		m_start = start;
		m_increment = increment;
		m_count = count;
	}

	private void Initialize()
	{
		m_start = 1000.0;
		m_increment = 0.0;
		m_count = 0;
	}

	[OnDeserializing]
	public void Initialize(StreamingContext context)
	{
		Initialize();
	}
}
