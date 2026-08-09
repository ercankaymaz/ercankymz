using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class QueryFirstRequest : IEncodeable, ICloneable, IJsonEncodeable, IServiceRequest
{
	private RequestHeader m_requestHeader;

	private ViewDescription m_view;

	private NodeTypeDescriptionCollection m_nodeTypes;

	private ContentFilter m_filter;

	private uint m_maxDataSetsToReturn;

	private uint m_maxReferencesToReturn;

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

	[DataMember(Name = "NodeTypes", IsRequired = false, Order = 3)]
	public NodeTypeDescriptionCollection NodeTypes
	{
		get
		{
			return m_nodeTypes;
		}
		set
		{
			m_nodeTypes = value;
			if (value == null)
			{
				m_nodeTypes = new NodeTypeDescriptionCollection();
			}
		}
	}

	[DataMember(Name = "Filter", IsRequired = false, Order = 4)]
	public ContentFilter Filter
	{
		get
		{
			return m_filter;
		}
		set
		{
			m_filter = value;
			if (value == null)
			{
				m_filter = new ContentFilter();
			}
		}
	}

	[DataMember(Name = "MaxDataSetsToReturn", IsRequired = false, Order = 5)]
	public uint MaxDataSetsToReturn
	{
		get
		{
			return m_maxDataSetsToReturn;
		}
		set
		{
			m_maxDataSetsToReturn = value;
		}
	}

	[DataMember(Name = "MaxReferencesToReturn", IsRequired = false, Order = 6)]
	public uint MaxReferencesToReturn
	{
		get
		{
			return m_maxReferencesToReturn;
		}
		set
		{
			m_maxReferencesToReturn = value;
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.QueryFirstRequest;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.QueryFirstRequest_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.QueryFirstRequest_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.QueryFirstRequest_Encoding_DefaultJson;

	public QueryFirstRequest()
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
		m_nodeTypes = new NodeTypeDescriptionCollection();
		m_filter = new ContentFilter();
		m_maxDataSetsToReturn = 0u;
		m_maxReferencesToReturn = 0u;
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteEncodeable("RequestHeader", RequestHeader, typeof(RequestHeader));
		encoder.WriteEncodeable("View", View, typeof(ViewDescription));
		encoder.WriteEncodeableArray("NodeTypes", NodeTypes.ToArray(), typeof(NodeTypeDescription));
		encoder.WriteEncodeable("Filter", Filter, typeof(ContentFilter));
		encoder.WriteUInt32("MaxDataSetsToReturn", MaxDataSetsToReturn);
		encoder.WriteUInt32("MaxReferencesToReturn", MaxReferencesToReturn);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		RequestHeader = (RequestHeader)decoder.ReadEncodeable("RequestHeader", typeof(RequestHeader));
		View = (ViewDescription)decoder.ReadEncodeable("View", typeof(ViewDescription));
		NodeTypes = (NodeTypeDescription[])decoder.ReadEncodeableArray("NodeTypes", typeof(NodeTypeDescription));
		Filter = (ContentFilter)decoder.ReadEncodeable("Filter", typeof(ContentFilter));
		MaxDataSetsToReturn = decoder.ReadUInt32("MaxDataSetsToReturn");
		MaxReferencesToReturn = decoder.ReadUInt32("MaxReferencesToReturn");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is QueryFirstRequest queryFirstRequest))
		{
			return false;
		}
		if (!Utils.IsEqual(m_requestHeader, queryFirstRequest.m_requestHeader))
		{
			return false;
		}
		if (!Utils.IsEqual(m_view, queryFirstRequest.m_view))
		{
			return false;
		}
		if (!Utils.IsEqual(m_nodeTypes, queryFirstRequest.m_nodeTypes))
		{
			return false;
		}
		if (!Utils.IsEqual(m_filter, queryFirstRequest.m_filter))
		{
			return false;
		}
		if (!Utils.IsEqual(m_maxDataSetsToReturn, queryFirstRequest.m_maxDataSetsToReturn))
		{
			return false;
		}
		if (!Utils.IsEqual(m_maxReferencesToReturn, queryFirstRequest.m_maxReferencesToReturn))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (QueryFirstRequest)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		QueryFirstRequest obj = (QueryFirstRequest)base.MemberwiseClone();
		obj.m_requestHeader = (RequestHeader)Utils.Clone(m_requestHeader);
		obj.m_view = (ViewDescription)Utils.Clone(m_view);
		obj.m_nodeTypes = (NodeTypeDescriptionCollection)Utils.Clone(m_nodeTypes);
		obj.m_filter = (ContentFilter)Utils.Clone(m_filter);
		obj.m_maxDataSetsToReturn = (uint)Utils.Clone(m_maxDataSetsToReturn);
		obj.m_maxReferencesToReturn = (uint)Utils.Clone(m_maxReferencesToReturn);
		return obj;
	}
}
