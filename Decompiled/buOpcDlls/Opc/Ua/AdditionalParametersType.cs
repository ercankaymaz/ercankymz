using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class AdditionalParametersType : IEncodeable, ICloneable, IJsonEncodeable
{
	private KeyValuePairCollection m_parameters;

	[DataMember(Name = "Parameters", IsRequired = false, Order = 1)]
	public KeyValuePairCollection Parameters
	{
		get
		{
			return m_parameters;
		}
		set
		{
			m_parameters = value;
			if (value == null)
			{
				m_parameters = new KeyValuePairCollection();
			}
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.AdditionalParametersType;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.AdditionalParametersType_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.AdditionalParametersType_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.AdditionalParametersType_Encoding_DefaultJson;

	public AdditionalParametersType()
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
		m_parameters = new KeyValuePairCollection();
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteEncodeableArray("Parameters", Parameters.ToArray(), typeof(KeyValuePair));
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		Parameters = (KeyValuePair[])decoder.ReadEncodeableArray("Parameters", typeof(KeyValuePair));
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is AdditionalParametersType additionalParametersType))
		{
			return false;
		}
		if (!Utils.IsEqual(m_parameters, additionalParametersType.m_parameters))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (AdditionalParametersType)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		AdditionalParametersType obj = (AdditionalParametersType)base.MemberwiseClone();
		obj.m_parameters = (KeyValuePairCollection)Utils.Clone(m_parameters);
		return obj;
	}
}
