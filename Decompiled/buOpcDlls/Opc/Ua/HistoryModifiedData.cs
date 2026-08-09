using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class HistoryModifiedData : HistoryData
{
	private ModificationInfoCollection m_modificationInfos;

	[DataMember(Name = "ModificationInfos", IsRequired = false, Order = 1)]
	public ModificationInfoCollection ModificationInfos
	{
		get
		{
			return m_modificationInfos;
		}
		set
		{
			m_modificationInfos = value;
			if (value == null)
			{
				m_modificationInfos = new ModificationInfoCollection();
			}
		}
	}

	public override ExpandedNodeId TypeId => DataTypeIds.HistoryModifiedData;

	public override ExpandedNodeId BinaryEncodingId => ObjectIds.HistoryModifiedData_Encoding_DefaultBinary;

	public override ExpandedNodeId XmlEncodingId => ObjectIds.HistoryModifiedData_Encoding_DefaultXml;

	public override ExpandedNodeId JsonEncodingId => ObjectIds.HistoryModifiedData_Encoding_DefaultJson;

	public HistoryModifiedData()
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
		m_modificationInfos = new ModificationInfoCollection();
	}

	public override void Encode(IEncoder encoder)
	{
		base.Encode(encoder);
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteEncodeableArray("ModificationInfos", ModificationInfos.ToArray(), typeof(ModificationInfo));
		encoder.PopNamespace();
	}

	public override void Decode(IDecoder decoder)
	{
		base.Decode(decoder);
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		ModificationInfos = (ModificationInfo[])decoder.ReadEncodeableArray("ModificationInfos", typeof(ModificationInfo));
		decoder.PopNamespace();
	}

	public override bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is HistoryModifiedData historyModifiedData))
		{
			return false;
		}
		if (!base.IsEqual(encodeable))
		{
			return false;
		}
		if (!Utils.IsEqual(m_modificationInfos, historyModifiedData.m_modificationInfos))
		{
			return false;
		}
		return base.IsEqual(encodeable);
	}

	public override object Clone()
	{
		return (HistoryModifiedData)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		HistoryModifiedData obj = (HistoryModifiedData)base.MemberwiseClone();
		obj.m_modificationInfos = (ModificationInfoCollection)Utils.Clone(m_modificationInfos);
		return obj;
	}
}
