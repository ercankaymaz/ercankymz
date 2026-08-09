using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class IdentityMappingRuleType : IEncodeable, ICloneable, IJsonEncodeable
{
	private IdentityCriteriaType m_criteriaType;

	private string m_criteria;

	[DataMember(Name = "CriteriaType", IsRequired = false, Order = 1)]
	public IdentityCriteriaType CriteriaType
	{
		get
		{
			return m_criteriaType;
		}
		set
		{
			m_criteriaType = value;
		}
	}

	[DataMember(Name = "Criteria", IsRequired = false, Order = 2)]
	public string Criteria
	{
		get
		{
			return m_criteria;
		}
		set
		{
			m_criteria = value;
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.IdentityMappingRuleType;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.IdentityMappingRuleType_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.IdentityMappingRuleType_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.IdentityMappingRuleType_Encoding_DefaultJson;

	public IdentityMappingRuleType()
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
		m_criteriaType = IdentityCriteriaType.UserName;
		m_criteria = null;
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteEnumerated("CriteriaType", CriteriaType);
		encoder.WriteString("Criteria", Criteria);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		CriteriaType = (IdentityCriteriaType)(object)decoder.ReadEnumerated("CriteriaType", typeof(IdentityCriteriaType));
		Criteria = decoder.ReadString("Criteria");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is IdentityMappingRuleType identityMappingRuleType))
		{
			return false;
		}
		if (!Utils.IsEqual(m_criteriaType, identityMappingRuleType.m_criteriaType))
		{
			return false;
		}
		if (!Utils.IsEqual(m_criteria, identityMappingRuleType.m_criteria))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (IdentityMappingRuleType)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		IdentityMappingRuleType obj = (IdentityMappingRuleType)base.MemberwiseClone();
		obj.m_criteriaType = (IdentityCriteriaType)Utils.Clone(m_criteriaType);
		obj.m_criteria = (string)Utils.Clone(m_criteria);
		return obj;
	}
}
