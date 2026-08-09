using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class TargetVariablesDataType : SubscribedDataSetDataType
{
	private FieldTargetDataTypeCollection m_targetVariables;

	[DataMember(Name = "TargetVariables", IsRequired = false, Order = 1)]
	public FieldTargetDataTypeCollection TargetVariables
	{
		get
		{
			return m_targetVariables;
		}
		set
		{
			m_targetVariables = value;
			if (value == null)
			{
				m_targetVariables = new FieldTargetDataTypeCollection();
			}
		}
	}

	public override ExpandedNodeId TypeId => DataTypeIds.TargetVariablesDataType;

	public override ExpandedNodeId BinaryEncodingId => ObjectIds.TargetVariablesDataType_Encoding_DefaultBinary;

	public override ExpandedNodeId XmlEncodingId => ObjectIds.TargetVariablesDataType_Encoding_DefaultXml;

	public override ExpandedNodeId JsonEncodingId => ObjectIds.TargetVariablesDataType_Encoding_DefaultJson;

	public TargetVariablesDataType()
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
		m_targetVariables = new FieldTargetDataTypeCollection();
	}

	public override void Encode(IEncoder encoder)
	{
		base.Encode(encoder);
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteEncodeableArray("TargetVariables", TargetVariables.ToArray(), typeof(FieldTargetDataType));
		encoder.PopNamespace();
	}

	public override void Decode(IDecoder decoder)
	{
		base.Decode(decoder);
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		TargetVariables = (FieldTargetDataType[])decoder.ReadEncodeableArray("TargetVariables", typeof(FieldTargetDataType));
		decoder.PopNamespace();
	}

	public override bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is TargetVariablesDataType targetVariablesDataType))
		{
			return false;
		}
		if (!base.IsEqual(encodeable))
		{
			return false;
		}
		if (!Utils.IsEqual(m_targetVariables, targetVariablesDataType.m_targetVariables))
		{
			return false;
		}
		return base.IsEqual(encodeable);
	}

	public override object Clone()
	{
		return (TargetVariablesDataType)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		TargetVariablesDataType obj = (TargetVariablesDataType)base.MemberwiseClone();
		obj.m_targetVariables = (FieldTargetDataTypeCollection)Utils.Clone(m_targetVariables);
		return obj;
	}
}
