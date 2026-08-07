// Decompiled with JetBrains decompiler
// Type: Opc.Ua.IdentityMappingRuleType
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class IdentityMappingRuleType : IEncodeable, ICloneable, IJsonEncodeable
{
  private IdentityCriteriaType m_criteriaType;
  private string m_criteria;

  public IdentityMappingRuleType() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_criteriaType = IdentityCriteriaType.UserName;
    this.m_criteria = (string) null;
  }

  [DataMember(Name = "CriteriaType", IsRequired = false, Order = 1)]
  public IdentityCriteriaType CriteriaType
  {
    get => this.m_criteriaType;
    set => this.m_criteriaType = value;
  }

  [DataMember(Name = "Criteria", IsRequired = false, Order = 2)]
  public string Criteria
  {
    get => this.m_criteria;
    set => this.m_criteria = value;
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.IdentityMappingRuleType;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.IdentityMappingRuleType_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.IdentityMappingRuleType_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.IdentityMappingRuleType_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteEnumerated("CriteriaType", (Enum) this.CriteriaType);
    encoder.WriteString("Criteria", this.Criteria);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.CriteriaType = (IdentityCriteriaType) decoder.ReadEnumerated("CriteriaType", typeof (IdentityCriteriaType));
    this.Criteria = decoder.ReadString("Criteria");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is IdentityMappingRuleType identityMappingRuleType && Utils.IsEqual((object) this.m_criteriaType, (object) identityMappingRuleType.m_criteriaType) && Utils.IsEqual((object) this.m_criteria, (object) identityMappingRuleType.m_criteria);
  }

  public virtual object Clone() => (object) (IdentityMappingRuleType) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    IdentityMappingRuleType identityMappingRuleType = (IdentityMappingRuleType) base.MemberwiseClone();
    identityMappingRuleType.m_criteriaType = (IdentityCriteriaType) Utils.Clone((object) this.m_criteriaType);
    identityMappingRuleType.m_criteria = (string) Utils.Clone((object) this.m_criteria);
    return (object) identityMappingRuleType;
  }
}
