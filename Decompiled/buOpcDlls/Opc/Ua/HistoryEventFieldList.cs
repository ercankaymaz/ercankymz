using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class HistoryEventFieldList : IEncodeable, ICloneable, IJsonEncodeable
{
	private VariantCollection m_eventFields;

	[DataMember(Name = "EventFields", IsRequired = false, Order = 1)]
	public VariantCollection EventFields
	{
		get
		{
			return m_eventFields;
		}
		set
		{
			m_eventFields = value;
			if (value == null)
			{
				m_eventFields = new VariantCollection();
			}
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.HistoryEventFieldList;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.HistoryEventFieldList_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.HistoryEventFieldList_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.HistoryEventFieldList_Encoding_DefaultJson;

	public HistoryEventFieldList()
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
		m_eventFields = new VariantCollection();
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteVariantArray("EventFields", EventFields);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		EventFields = decoder.ReadVariantArray("EventFields");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is HistoryEventFieldList historyEventFieldList))
		{
			return false;
		}
		if (!Utils.IsEqual(m_eventFields, historyEventFieldList.m_eventFields))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (HistoryEventFieldList)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		HistoryEventFieldList obj = (HistoryEventFieldList)base.MemberwiseClone();
		obj.m_eventFields = (VariantCollection)Utils.Clone(m_eventFields);
		return obj;
	}
}
