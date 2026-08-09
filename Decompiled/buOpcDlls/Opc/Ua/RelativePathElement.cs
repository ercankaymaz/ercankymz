using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class RelativePathElement : IEncodeable, ICloneable, IJsonEncodeable
{
	private NodeId m_referenceTypeId;

	private bool m_isInverse;

	private bool m_includeSubtypes;

	private QualifiedName m_targetName;

	[DataMember(Name = "ReferenceTypeId", IsRequired = false, Order = 1)]
	public NodeId ReferenceTypeId
	{
		get
		{
			return m_referenceTypeId;
		}
		set
		{
			m_referenceTypeId = value;
		}
	}

	[DataMember(Name = "IsInverse", IsRequired = false, Order = 2)]
	public bool IsInverse
	{
		get
		{
			return m_isInverse;
		}
		set
		{
			m_isInverse = value;
		}
	}

	[DataMember(Name = "IncludeSubtypes", IsRequired = false, Order = 3)]
	public bool IncludeSubtypes
	{
		get
		{
			return m_includeSubtypes;
		}
		set
		{
			m_includeSubtypes = value;
		}
	}

	[DataMember(Name = "TargetName", IsRequired = false, Order = 4)]
	public QualifiedName TargetName
	{
		get
		{
			return m_targetName;
		}
		set
		{
			m_targetName = value;
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.RelativePathElement;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.RelativePathElement_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.RelativePathElement_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.RelativePathElement_Encoding_DefaultJson;

	public RelativePathElement()
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
		m_referenceTypeId = null;
		m_isInverse = true;
		m_includeSubtypes = true;
		m_targetName = null;
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteNodeId("ReferenceTypeId", ReferenceTypeId);
		encoder.WriteBoolean("IsInverse", IsInverse);
		encoder.WriteBoolean("IncludeSubtypes", IncludeSubtypes);
		encoder.WriteQualifiedName("TargetName", TargetName);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		ReferenceTypeId = decoder.ReadNodeId("ReferenceTypeId");
		IsInverse = decoder.ReadBoolean("IsInverse");
		IncludeSubtypes = decoder.ReadBoolean("IncludeSubtypes");
		TargetName = decoder.ReadQualifiedName("TargetName");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is RelativePathElement relativePathElement))
		{
			return false;
		}
		if (!Utils.IsEqual(m_referenceTypeId, relativePathElement.m_referenceTypeId))
		{
			return false;
		}
		if (!Utils.IsEqual(m_isInverse, relativePathElement.m_isInverse))
		{
			return false;
		}
		if (!Utils.IsEqual(m_includeSubtypes, relativePathElement.m_includeSubtypes))
		{
			return false;
		}
		if (!Utils.IsEqual(m_targetName, relativePathElement.m_targetName))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (RelativePathElement)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		RelativePathElement obj = (RelativePathElement)base.MemberwiseClone();
		obj.m_referenceTypeId = (NodeId)Utils.Clone(m_referenceTypeId);
		obj.m_isInverse = (bool)Utils.Clone(m_isInverse);
		obj.m_includeSubtypes = (bool)Utils.Clone(m_includeSubtypes);
		obj.m_targetName = (QualifiedName)Utils.Clone(m_targetName);
		return obj;
	}
}
