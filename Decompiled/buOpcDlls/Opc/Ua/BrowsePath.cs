using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class BrowsePath : IEncodeable, ICloneable, IJsonEncodeable
{
	private NodeId m_startingNode;

	private RelativePath m_relativePath;

	private object m_handle;

	[DataMember(Name = "StartingNode", IsRequired = false, Order = 1)]
	public NodeId StartingNode
	{
		get
		{
			return m_startingNode;
		}
		set
		{
			m_startingNode = value;
		}
	}

	[DataMember(Name = "RelativePath", IsRequired = false, Order = 2)]
	public RelativePath RelativePath
	{
		get
		{
			return m_relativePath;
		}
		set
		{
			m_relativePath = value;
			if (value == null)
			{
				m_relativePath = new RelativePath();
			}
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.BrowsePath;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.BrowsePath_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.BrowsePath_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.BrowsePath_Encoding_DefaultJson;

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

	public BrowsePath()
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
		m_startingNode = null;
		m_relativePath = new RelativePath();
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteNodeId("StartingNode", StartingNode);
		encoder.WriteEncodeable("RelativePath", RelativePath, typeof(RelativePath));
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		StartingNode = decoder.ReadNodeId("StartingNode");
		RelativePath = (RelativePath)decoder.ReadEncodeable("RelativePath", typeof(RelativePath));
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is BrowsePath browsePath))
		{
			return false;
		}
		if (!Utils.IsEqual(m_startingNode, browsePath.m_startingNode))
		{
			return false;
		}
		if (!Utils.IsEqual(m_relativePath, browsePath.m_relativePath))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (BrowsePath)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		BrowsePath obj = (BrowsePath)base.MemberwiseClone();
		obj.m_startingNode = (NodeId)Utils.Clone(m_startingNode);
		obj.m_relativePath = (RelativePath)Utils.Clone(m_relativePath);
		return obj;
	}
}
