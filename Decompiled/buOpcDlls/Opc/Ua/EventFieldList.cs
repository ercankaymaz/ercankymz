using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class EventFieldList : IEncodeable, ICloneable, IJsonEncodeable
{
	private uint m_clientHandle;

	private VariantCollection m_eventFields;

	private object m_handle;

	[DataMember(Name = "ClientHandle", IsRequired = false, Order = 1)]
	public uint ClientHandle
	{
		get
		{
			return m_clientHandle;
		}
		set
		{
			m_clientHandle = value;
		}
	}

	[DataMember(Name = "EventFields", IsRequired = false, Order = 2)]
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

	public virtual ExpandedNodeId TypeId => DataTypeIds.EventFieldList;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.EventFieldList_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.EventFieldList_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.EventFieldList_Encoding_DefaultJson;

	public NotificationMessage Message
	{
		get
		{
			return m_handle as NotificationMessage;
		}
		set
		{
			m_handle = value;
		}
	}

	public object Handle
	{
		get
		{
			return m_handle;
		}
		set
		{
			m_handle = value;
		}
	}

	public EventFieldList()
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
		m_clientHandle = 0u;
		m_eventFields = new VariantCollection();
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteUInt32("ClientHandle", ClientHandle);
		encoder.WriteVariantArray("EventFields", EventFields);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		ClientHandle = decoder.ReadUInt32("ClientHandle");
		EventFields = decoder.ReadVariantArray("EventFields");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is EventFieldList eventFieldList))
		{
			return false;
		}
		if (!Utils.IsEqual(m_clientHandle, eventFieldList.m_clientHandle))
		{
			return false;
		}
		if (!Utils.IsEqual(m_eventFields, eventFieldList.m_eventFields))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (EventFieldList)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		EventFieldList obj = (EventFieldList)base.MemberwiseClone();
		obj.m_clientHandle = (uint)Utils.Clone(m_clientHandle);
		obj.m_eventFields = (VariantCollection)Utils.Clone(m_eventFields);
		return obj;
	}
}
