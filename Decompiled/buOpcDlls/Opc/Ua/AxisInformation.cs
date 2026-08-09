using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class AxisInformation : IEncodeable, ICloneable, IJsonEncodeable
{
	private EUInformation m_engineeringUnits;

	private Range m_eURange;

	private LocalizedText m_title;

	private AxisScaleEnumeration m_axisScaleType;

	private DoubleCollection m_axisSteps;

	[DataMember(Name = "EngineeringUnits", IsRequired = false, Order = 1)]
	public EUInformation EngineeringUnits
	{
		get
		{
			return m_engineeringUnits;
		}
		set
		{
			m_engineeringUnits = value;
			if (value == null)
			{
				m_engineeringUnits = new EUInformation();
			}
		}
	}

	[DataMember(Name = "EURange", IsRequired = false, Order = 2)]
	public Range EURange
	{
		get
		{
			return m_eURange;
		}
		set
		{
			m_eURange = value;
			if (value == null)
			{
				m_eURange = new Range();
			}
		}
	}

	[DataMember(Name = "Title", IsRequired = false, Order = 3)]
	public LocalizedText Title
	{
		get
		{
			return m_title;
		}
		set
		{
			m_title = value;
		}
	}

	[DataMember(Name = "AxisScaleType", IsRequired = false, Order = 4)]
	public AxisScaleEnumeration AxisScaleType
	{
		get
		{
			return m_axisScaleType;
		}
		set
		{
			m_axisScaleType = value;
		}
	}

	[DataMember(Name = "AxisSteps", IsRequired = false, Order = 5)]
	public DoubleCollection AxisSteps
	{
		get
		{
			return m_axisSteps;
		}
		set
		{
			m_axisSteps = value;
			if (value == null)
			{
				m_axisSteps = new DoubleCollection();
			}
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.AxisInformation;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.AxisInformation_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.AxisInformation_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.AxisInformation_Encoding_DefaultJson;

	public AxisInformation()
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
		m_engineeringUnits = new EUInformation();
		m_eURange = new Range();
		m_title = null;
		m_axisScaleType = AxisScaleEnumeration.Linear;
		m_axisSteps = new DoubleCollection();
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteEncodeable("EngineeringUnits", EngineeringUnits, typeof(EUInformation));
		encoder.WriteEncodeable("EURange", EURange, typeof(Range));
		encoder.WriteLocalizedText("Title", Title);
		encoder.WriteEnumerated("AxisScaleType", AxisScaleType);
		encoder.WriteDoubleArray("AxisSteps", AxisSteps);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		EngineeringUnits = (EUInformation)decoder.ReadEncodeable("EngineeringUnits", typeof(EUInformation));
		EURange = (Range)decoder.ReadEncodeable("EURange", typeof(Range));
		Title = decoder.ReadLocalizedText("Title");
		AxisScaleType = (AxisScaleEnumeration)(object)decoder.ReadEnumerated("AxisScaleType", typeof(AxisScaleEnumeration));
		AxisSteps = decoder.ReadDoubleArray("AxisSteps");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is AxisInformation axisInformation))
		{
			return false;
		}
		if (!Utils.IsEqual(m_engineeringUnits, axisInformation.m_engineeringUnits))
		{
			return false;
		}
		if (!Utils.IsEqual(m_eURange, axisInformation.m_eURange))
		{
			return false;
		}
		if (!Utils.IsEqual(m_title, axisInformation.m_title))
		{
			return false;
		}
		if (!Utils.IsEqual(m_axisScaleType, axisInformation.m_axisScaleType))
		{
			return false;
		}
		if (!Utils.IsEqual(m_axisSteps, axisInformation.m_axisSteps))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (AxisInformation)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		AxisInformation obj = (AxisInformation)base.MemberwiseClone();
		obj.m_engineeringUnits = (EUInformation)Utils.Clone(m_engineeringUnits);
		obj.m_eURange = (Range)Utils.Clone(m_eURange);
		obj.m_title = (LocalizedText)Utils.Clone(m_title);
		obj.m_axisScaleType = (AxisScaleEnumeration)Utils.Clone(m_axisScaleType);
		obj.m_axisSteps = (DoubleCollection)Utils.Clone(m_axisSteps);
		return obj;
	}
}
