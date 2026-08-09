using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class UpdateDataDetails : HistoryUpdateDetails
{
	private PerformUpdateType m_performInsertReplace;

	private DataValueCollection m_updateValues;

	[DataMember(Name = "PerformInsertReplace", IsRequired = false, Order = 1)]
	public PerformUpdateType PerformInsertReplace
	{
		get
		{
			return m_performInsertReplace;
		}
		set
		{
			m_performInsertReplace = value;
		}
	}

	[DataMember(Name = "UpdateValues", IsRequired = false, Order = 2)]
	public DataValueCollection UpdateValues
	{
		get
		{
			return m_updateValues;
		}
		set
		{
			m_updateValues = value;
			if (value == null)
			{
				m_updateValues = new DataValueCollection();
			}
		}
	}

	public override ExpandedNodeId TypeId => DataTypeIds.UpdateDataDetails;

	public override ExpandedNodeId BinaryEncodingId => ObjectIds.UpdateDataDetails_Encoding_DefaultBinary;

	public override ExpandedNodeId XmlEncodingId => ObjectIds.UpdateDataDetails_Encoding_DefaultXml;

	public override ExpandedNodeId JsonEncodingId => ObjectIds.UpdateDataDetails_Encoding_DefaultJson;

	public UpdateDataDetails()
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
		m_performInsertReplace = PerformUpdateType.Insert;
		m_updateValues = new DataValueCollection();
	}

	public override void Encode(IEncoder encoder)
	{
		base.Encode(encoder);
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteEnumerated("PerformInsertReplace", PerformInsertReplace);
		encoder.WriteDataValueArray("UpdateValues", UpdateValues);
		encoder.PopNamespace();
	}

	public override void Decode(IDecoder decoder)
	{
		base.Decode(decoder);
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		PerformInsertReplace = (PerformUpdateType)(object)decoder.ReadEnumerated("PerformInsertReplace", typeof(PerformUpdateType));
		UpdateValues = decoder.ReadDataValueArray("UpdateValues");
		decoder.PopNamespace();
	}

	public override bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is UpdateDataDetails updateDataDetails))
		{
			return false;
		}
		if (!base.IsEqual(encodeable))
		{
			return false;
		}
		if (!Utils.IsEqual(m_performInsertReplace, updateDataDetails.m_performInsertReplace))
		{
			return false;
		}
		if (!Utils.IsEqual(m_updateValues, updateDataDetails.m_updateValues))
		{
			return false;
		}
		return base.IsEqual(encodeable);
	}

	public override object Clone()
	{
		return (UpdateDataDetails)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		UpdateDataDetails obj = (UpdateDataDetails)base.MemberwiseClone();
		obj.m_performInsertReplace = (PerformUpdateType)Utils.Clone(m_performInsertReplace);
		obj.m_updateValues = (DataValueCollection)Utils.Clone(m_updateValues);
		return obj;
	}
}
