// Decompiled with JetBrains decompiler
// Type: Opc.Ua.RelativePathElement
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
public class RelativePathElement : IEncodeable, ICloneable, IJsonEncodeable
{
  private NodeId m_referenceTypeId;
  private bool m_isInverse;
  private bool m_includeSubtypes;
  private QualifiedName m_targetName;

  public RelativePathElement() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_referenceTypeId = (NodeId) null;
    this.m_isInverse = true;
    this.m_includeSubtypes = true;
    this.m_targetName = (QualifiedName) null;
  }

  [DataMember(Name = "ReferenceTypeId", IsRequired = false, Order = 1)]
  public NodeId ReferenceTypeId
  {
    get => this.m_referenceTypeId;
    set => this.m_referenceTypeId = value;
  }

  [DataMember(Name = "IsInverse", IsRequired = false, Order = 2)]
  public bool IsInverse
  {
    get => this.m_isInverse;
    set => this.m_isInverse = value;
  }

  [DataMember(Name = "IncludeSubtypes", IsRequired = false, Order = 3)]
  public bool IncludeSubtypes
  {
    get => this.m_includeSubtypes;
    set => this.m_includeSubtypes = value;
  }

  [DataMember(Name = "TargetName", IsRequired = false, Order = 4)]
  public QualifiedName TargetName
  {
    get => this.m_targetName;
    set => this.m_targetName = value;
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.RelativePathElement;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.RelativePathElement_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.RelativePathElement_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.RelativePathElement_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteNodeId("ReferenceTypeId", this.ReferenceTypeId);
    encoder.WriteBoolean("IsInverse", this.IsInverse);
    encoder.WriteBoolean("IncludeSubtypes", this.IncludeSubtypes);
    encoder.WriteQualifiedName("TargetName", this.TargetName);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.ReferenceTypeId = decoder.ReadNodeId("ReferenceTypeId");
    this.IsInverse = decoder.ReadBoolean("IsInverse");
    this.IncludeSubtypes = decoder.ReadBoolean("IncludeSubtypes");
    this.TargetName = decoder.ReadQualifiedName("TargetName");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is RelativePathElement relativePathElement && Utils.IsEqual((object) this.m_referenceTypeId, (object) relativePathElement.m_referenceTypeId) && Utils.IsEqual((object) this.m_isInverse, (object) relativePathElement.m_isInverse) && Utils.IsEqual((object) this.m_includeSubtypes, (object) relativePathElement.m_includeSubtypes) && Utils.IsEqual((object) this.m_targetName, (object) relativePathElement.m_targetName);
  }

  public virtual object Clone() => (object) (RelativePathElement) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    RelativePathElement relativePathElement = (RelativePathElement) base.MemberwiseClone();
    relativePathElement.m_referenceTypeId = (NodeId) Utils.Clone((object) this.m_referenceTypeId);
    relativePathElement.m_isInverse = (bool) Utils.Clone((object) this.m_isInverse);
    relativePathElement.m_includeSubtypes = (bool) Utils.Clone((object) this.m_includeSubtypes);
    relativePathElement.m_targetName = (QualifiedName) Utils.Clone((object) this.m_targetName);
    return (object) relativePathElement;
  }
}
