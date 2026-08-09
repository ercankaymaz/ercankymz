using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class DataTypeDescription : IEncodeable, ICloneable, IJsonEncodeable
{
	private NodeId m_dataTypeId;

	private QualifiedName m_name;

	[DataMember(Name = "DataTypeId", IsRequired = false, Order = 1)]
	public NodeId DataTypeId
	{
		get
		{
			return m_dataTypeId;
		}
		set
		{
			m_dataTypeId = value;
		}
	}

	[DataMember(Name = "Name", IsRequired = false, Order = 2)]
	public QualifiedName Name
	{
		get
		{
			return m_name;
		}
		set
		{
			m_name = value;
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.DataTypeDescription;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.DataTypeDescription_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.DataTypeDescription_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.DataTypeDescription_Encoding_DefaultJson;

	public DataTypeDescription()
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
		m_dataTypeId = null;
		m_name = null;
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteNodeId("DataTypeId", DataTypeId);
		encoder.WriteQualifiedName("Name", Name);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		DataTypeId = decoder.ReadNodeId("DataTypeId");
		Name = decoder.ReadQualifiedName("Name");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is DataTypeDescription dataTypeDescription))
		{
			return false;
		}
		if (!Utils.IsEqual(m_dataTypeId, dataTypeDescription.m_dataTypeId))
		{
			return false;
		}
		if (!Utils.IsEqual(m_name, dataTypeDescription.m_name))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (DataTypeDescription)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		DataTypeDescription obj = (DataTypeDescription)base.MemberwiseClone();
		obj.m_dataTypeId = (NodeId)Utils.Clone(m_dataTypeId);
		obj.m_name = (QualifiedName)Utils.Clone(m_name);
		return obj;
	}
}
