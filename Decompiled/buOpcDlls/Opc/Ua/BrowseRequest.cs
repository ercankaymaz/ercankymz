using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class BrowseRequest : IEncodeable, ICloneable, IJsonEncodeable, IServiceRequest
{
	private RequestHeader m_requestHeader;

	private ViewDescription m_view;

	private uint m_requestedMaxReferencesPerNode;

	private BrowseDescriptionCollection m_nodesToBrowse;

	[DataMember(Name = "RequestHeader", IsRequired = false, Order = 1)]
	public RequestHeader RequestHeader
	{
		get
		{
			return m_requestHeader;
		}
		set
		{
			m_requestHeader = value;
			if (value == null)
			{
				m_requestHeader = new RequestHeader();
			}
		}
	}

	[DataMember(Name = "View", IsRequired = false, Order = 2)]
	public ViewDescription View
	{
		get
		{
			return m_view;
		}
		set
		{
			m_view = value;
			if (value == null)
			{
				m_view = new ViewDescription();
			}
		}
	}

	[DataMember(Name = "RequestedMaxReferencesPerNode", IsRequired = false, Order = 3)]
	public uint RequestedMaxReferencesPerNode
	{
		get
		{
			return m_requestedMaxReferencesPerNode;
		}
		set
		{
			m_requestedMaxReferencesPerNode = value;
		}
	}

	[DataMember(Name = "NodesToBrowse", IsRequired = false, Order = 4)]
	public BrowseDescriptionCollection NodesToBrowse
	{
		get
		{
			return m_nodesToBrowse;
		}
		set
		{
			m_nodesToBrowse = value;
			if (value == null)
			{
				m_nodesToBrowse = new BrowseDescriptionCollection();
			}
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.BrowseRequest;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.BrowseRequest_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.BrowseRequest_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.BrowseRequest_Encoding_DefaultJson;

	public BrowseRequest()
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
		m_requestHeader = new RequestHeader();
		m_view = new ViewDescription();
		m_requestedMaxReferencesPerNode = 0u;
		m_nodesToBrowse = new BrowseDescriptionCollection();
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteEncodeable("RequestHeader", RequestHeader, typeof(RequestHeader));
		encoder.WriteEncodeable("View", View, typeof(ViewDescription));
		encoder.WriteUInt32("RequestedMaxReferencesPerNode", RequestedMaxReferencesPerNode);
		encoder.WriteEncodeableArray("NodesToBrowse", NodesToBrowse.ToArray(), typeof(BrowseDescription));
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		RequestHeader = (RequestHeader)decoder.ReadEncodeable("RequestHeader", typeof(RequestHeader));
		View = (ViewDescription)decoder.ReadEncodeable("View", typeof(ViewDescription));
		RequestedMaxReferencesPerNode = decoder.ReadUInt32("RequestedMaxReferencesPerNode");
		NodesToBrowse = (BrowseDescription[])decoder.ReadEncodeableArray("NodesToBrowse", typeof(BrowseDescription));
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is BrowseRequest browseRequest))
		{
			return false;
		}
		if (!Utils.IsEqual(m_requestHeader, browseRequest.m_requestHeader))
		{
			return false;
		}
		if (!Utils.IsEqual(m_view, browseRequest.m_view))
		{
			return false;
		}
		if (!Utils.IsEqual(m_requestedMaxReferencesPerNode, browseRequest.m_requestedMaxReferencesPerNode))
		{
			return false;
		}
		if (!Utils.IsEqual(m_nodesToBrowse, browseRequest.m_nodesToBrowse))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (BrowseRequest)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		BrowseRequest obj = (BrowseRequest)base.MemberwiseClone();
		obj.m_requestHeader = (RequestHeader)Utils.Clone(m_requestHeader);
		obj.m_view = (ViewDescription)Utils.Clone(m_view);
		obj.m_requestedMaxReferencesPerNode = (uint)Utils.Clone(m_requestedMaxReferencesPerNode);
		obj.m_nodesToBrowse = (BrowseDescriptionCollection)Utils.Clone(m_nodesToBrowse);
		return obj;
	}
}
