using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class ViewDescription : IEncodeable, ICloneable, IJsonEncodeable
{
	private NodeId m_viewId;

	private DateTime m_timestamp;

	private uint m_viewVersion;

	private object m_handle;

	[DataMember(Name = "ViewId", IsRequired = false, Order = 1)]
	public NodeId ViewId
	{
		get
		{
			return m_viewId;
		}
		set
		{
			m_viewId = value;
		}
	}

	[DataMember(Name = "Timestamp", IsRequired = false, Order = 2)]
	public DateTime Timestamp
	{
		get
		{
			return m_timestamp;
		}
		set
		{
			m_timestamp = value;
		}
	}

	[DataMember(Name = "ViewVersion", IsRequired = false, Order = 3)]
	public uint ViewVersion
	{
		get
		{
			return m_viewVersion;
		}
		set
		{
			m_viewVersion = value;
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.ViewDescription;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.ViewDescription_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.ViewDescription_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.ViewDescription_Encoding_DefaultJson;

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

	public ViewDescription()
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
		m_viewId = null;
		m_timestamp = DateTime.MinValue;
		m_viewVersion = 0u;
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteNodeId("ViewId", ViewId);
		encoder.WriteDateTime("Timestamp", Timestamp);
		encoder.WriteUInt32("ViewVersion", ViewVersion);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		ViewId = decoder.ReadNodeId("ViewId");
		Timestamp = decoder.ReadDateTime("Timestamp");
		ViewVersion = decoder.ReadUInt32("ViewVersion");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is ViewDescription viewDescription))
		{
			return false;
		}
		if (!Utils.IsEqual(m_viewId, viewDescription.m_viewId))
		{
			return false;
		}
		if (!Utils.IsEqual(m_timestamp, viewDescription.m_timestamp))
		{
			return false;
		}
		if (!Utils.IsEqual(m_viewVersion, viewDescription.m_viewVersion))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (ViewDescription)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		ViewDescription obj = (ViewDescription)base.MemberwiseClone();
		obj.m_viewId = (NodeId)Utils.Clone(m_viewId);
		obj.m_timestamp = (DateTime)Utils.Clone(m_timestamp);
		obj.m_viewVersion = (uint)Utils.Clone(m_viewVersion);
		return obj;
	}

	public static bool IsDefault(ViewDescription view)
	{
		if (view == null)
		{
			return true;
		}
		if (NodeId.IsNull(view.m_viewId) && view.m_viewVersion == 0 && view.m_timestamp == DateTime.MinValue)
		{
			return true;
		}
		return false;
	}
}
