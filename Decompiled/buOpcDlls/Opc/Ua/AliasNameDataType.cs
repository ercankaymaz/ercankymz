using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class AliasNameDataType : IEncodeable, ICloneable, IJsonEncodeable
{
	private QualifiedName m_aliasName;

	private ExpandedNodeIdCollection m_referencedNodes;

	[DataMember(Name = "AliasName", IsRequired = false, Order = 1)]
	public QualifiedName AliasName
	{
		get
		{
			return m_aliasName;
		}
		set
		{
			m_aliasName = value;
		}
	}

	[DataMember(Name = "ReferencedNodes", IsRequired = false, Order = 2)]
	public ExpandedNodeIdCollection ReferencedNodes
	{
		get
		{
			return m_referencedNodes;
		}
		set
		{
			m_referencedNodes = value;
			if (value == null)
			{
				m_referencedNodes = new ExpandedNodeIdCollection();
			}
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.AliasNameDataType;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.AliasNameDataType_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.AliasNameDataType_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.AliasNameDataType_Encoding_DefaultJson;

	public AliasNameDataType()
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
		m_aliasName = null;
		m_referencedNodes = new ExpandedNodeIdCollection();
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteQualifiedName("AliasName", AliasName);
		encoder.WriteExpandedNodeIdArray("ReferencedNodes", ReferencedNodes);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		AliasName = decoder.ReadQualifiedName("AliasName");
		ReferencedNodes = decoder.ReadExpandedNodeIdArray("ReferencedNodes");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is AliasNameDataType aliasNameDataType))
		{
			return false;
		}
		if (!Utils.IsEqual(m_aliasName, aliasNameDataType.m_aliasName))
		{
			return false;
		}
		if (!Utils.IsEqual(m_referencedNodes, aliasNameDataType.m_referencedNodes))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (AliasNameDataType)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		AliasNameDataType obj = (AliasNameDataType)base.MemberwiseClone();
		obj.m_aliasName = (QualifiedName)Utils.Clone(m_aliasName);
		obj.m_referencedNodes = (ExpandedNodeIdCollection)Utils.Clone(m_referencedNodes);
		return obj;
	}
}
