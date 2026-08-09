using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class DataChangeFilter : MonitoringFilter
{
	private DataChangeTrigger m_trigger;

	private uint m_deadbandType;

	private double m_deadbandValue;

	[DataMember(Name = "Trigger", IsRequired = false, Order = 1)]
	public DataChangeTrigger Trigger
	{
		get
		{
			return m_trigger;
		}
		set
		{
			m_trigger = value;
		}
	}

	[DataMember(Name = "DeadbandType", IsRequired = false, Order = 2)]
	public uint DeadbandType
	{
		get
		{
			return m_deadbandType;
		}
		set
		{
			m_deadbandType = value;
		}
	}

	[DataMember(Name = "DeadbandValue", IsRequired = false, Order = 3)]
	public double DeadbandValue
	{
		get
		{
			return m_deadbandValue;
		}
		set
		{
			m_deadbandValue = value;
		}
	}

	public override ExpandedNodeId TypeId => DataTypeIds.DataChangeFilter;

	public override ExpandedNodeId BinaryEncodingId => ObjectIds.DataChangeFilter_Encoding_DefaultBinary;

	public override ExpandedNodeId XmlEncodingId => ObjectIds.DataChangeFilter_Encoding_DefaultXml;

	public override ExpandedNodeId JsonEncodingId => ObjectIds.DataChangeFilter_Encoding_DefaultJson;

	public DataChangeFilter()
	{
		Initialize();
	}

	[OnDeserializing]
	private void Initialize(StreamingContext context)
	{
		Initialize();
	}

	private void Initialize()
	{
		m_trigger = DataChangeTrigger.Status;
		m_deadbandType = 0u;
		m_deadbandValue = 0.0;
	}

	public override void Encode(IEncoder encoder)
	{
		base.Encode(encoder);
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteEnumerated("Trigger", Trigger);
		encoder.WriteUInt32("DeadbandType", DeadbandType);
		encoder.WriteDouble("DeadbandValue", DeadbandValue);
		encoder.PopNamespace();
	}

	public override void Decode(IDecoder decoder)
	{
		base.Decode(decoder);
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		Trigger = (DataChangeTrigger)(object)decoder.ReadEnumerated("Trigger", typeof(DataChangeTrigger));
		DeadbandType = decoder.ReadUInt32("DeadbandType");
		DeadbandValue = decoder.ReadDouble("DeadbandValue");
		decoder.PopNamespace();
	}

	public override bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is DataChangeFilter dataChangeFilter))
		{
			return false;
		}
		if (!base.IsEqual(encodeable))
		{
			return false;
		}
		if (!Utils.IsEqual(m_trigger, dataChangeFilter.m_trigger))
		{
			return false;
		}
		if (!Utils.IsEqual(m_deadbandType, dataChangeFilter.m_deadbandType))
		{
			return false;
		}
		if (!Utils.IsEqual(m_deadbandValue, dataChangeFilter.m_deadbandValue))
		{
			return false;
		}
		return base.IsEqual(encodeable);
	}

	public override object Clone()
	{
		return (DataChangeFilter)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		DataChangeFilter obj = (DataChangeFilter)base.MemberwiseClone();
		obj.m_trigger = (DataChangeTrigger)Utils.Clone(m_trigger);
		obj.m_deadbandType = (uint)Utils.Clone(m_deadbandType);
		obj.m_deadbandValue = (double)Utils.Clone(m_deadbandValue);
		return obj;
	}

	public ServiceResult Validate()
	{
		if ((int)DeadbandType < 0 || (int)DeadbandType > 2)
		{
			return ServiceResult.Create(2156789760u, "Deadband type '{0}' is not recognized.", DeadbandType);
		}
		if (Trigger < DataChangeTrigger.Status || Trigger > DataChangeTrigger.StatusValueTimestamp)
		{
			return ServiceResult.Create(2156789760u, "Deadband trigger '{0}' is not recognized.", Trigger);
		}
		if (DeadbandValue < 0.0)
		{
			return ServiceResult.Create(2156789760u, "Deadband value '{0}' cannot be less than zero.", DeadbandValue);
		}
		if (DeadbandType == 2 && DeadbandValue > 100.0)
		{
			return ServiceResult.Create(2156789760u, "Percentage deadband value '{0}' cannot be greater than 100.", DeadbandValue);
		}
		return ServiceResult.Good;
	}

	public static double GetAbsoluteDeadband(MonitoringFilter filter)
	{
		if (!(filter is DataChangeFilter dataChangeFilter))
		{
			return 0.0;
		}
		if (dataChangeFilter.DeadbandType != 1)
		{
			return 0.0;
		}
		return dataChangeFilter.DeadbandValue;
	}

	public static double GetPercentageDeadband(MonitoringFilter filter)
	{
		if (!(filter is DataChangeFilter dataChangeFilter))
		{
			return 0.0;
		}
		if (dataChangeFilter.DeadbandType != 2)
		{
			return 0.0;
		}
		return dataChangeFilter.DeadbandValue;
	}
}
