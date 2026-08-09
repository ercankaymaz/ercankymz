using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class CallMethodRequest : IEncodeable, ICloneable, IJsonEncodeable
{
	private NodeId m_objectId;

	private NodeId m_methodId;

	private VariantCollection m_inputArguments;

	private object m_handle;

	private bool m_processed;

	[DataMember(Name = "ObjectId", IsRequired = false, Order = 1)]
	public NodeId ObjectId
	{
		get
		{
			return m_objectId;
		}
		set
		{
			m_objectId = value;
		}
	}

	[DataMember(Name = "MethodId", IsRequired = false, Order = 2)]
	public NodeId MethodId
	{
		get
		{
			return m_methodId;
		}
		set
		{
			m_methodId = value;
		}
	}

	[DataMember(Name = "InputArguments", IsRequired = false, Order = 3)]
	public VariantCollection InputArguments
	{
		get
		{
			return m_inputArguments;
		}
		set
		{
			m_inputArguments = value;
			if (value == null)
			{
				m_inputArguments = new VariantCollection();
			}
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.CallMethodRequest;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.CallMethodRequest_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.CallMethodRequest_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.CallMethodRequest_Encoding_DefaultJson;

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

	public bool Processed
	{
		get
		{
			return m_processed;
		}
		set
		{
			m_processed = value;
		}
	}

	public CallMethodRequest()
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
		m_objectId = null;
		m_methodId = null;
		m_inputArguments = new VariantCollection();
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteNodeId("ObjectId", ObjectId);
		encoder.WriteNodeId("MethodId", MethodId);
		encoder.WriteVariantArray("InputArguments", InputArguments);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		ObjectId = decoder.ReadNodeId("ObjectId");
		MethodId = decoder.ReadNodeId("MethodId");
		InputArguments = decoder.ReadVariantArray("InputArguments");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is CallMethodRequest callMethodRequest))
		{
			return false;
		}
		if (!Utils.IsEqual(m_objectId, callMethodRequest.m_objectId))
		{
			return false;
		}
		if (!Utils.IsEqual(m_methodId, callMethodRequest.m_methodId))
		{
			return false;
		}
		if (!Utils.IsEqual(m_inputArguments, callMethodRequest.m_inputArguments))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (CallMethodRequest)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		CallMethodRequest obj = (CallMethodRequest)base.MemberwiseClone();
		obj.m_objectId = (NodeId)Utils.Clone(m_objectId);
		obj.m_methodId = (NodeId)Utils.Clone(m_methodId);
		obj.m_inputArguments = (VariantCollection)Utils.Clone(m_inputArguments);
		return obj;
	}
}
