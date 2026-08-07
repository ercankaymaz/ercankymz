// Decompiled with JetBrains decompiler
// Type: Opc.Ua.AddReferencesItem
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
public class AddReferencesItem : IEncodeable, ICloneable, IJsonEncodeable
{
  private NodeId m_sourceNodeId;
  private NodeId m_referenceTypeId;
  private bool m_isForward;
  private string m_targetServerUri;
  private ExpandedNodeId m_targetNodeId;
  private NodeClass m_targetNodeClass;

  public AddReferencesItem() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_sourceNodeId = (NodeId) null;
    this.m_referenceTypeId = (NodeId) null;
    this.m_isForward = true;
    this.m_targetServerUri = (string) null;
    this.m_targetNodeId = (ExpandedNodeId) null;
    this.m_targetNodeClass = NodeClass.Unspecified;
  }

  [DataMember(Name = "SourceNodeId", IsRequired = false, Order = 1)]
  public NodeId SourceNodeId
  {
    get => this.m_sourceNodeId;
    set => this.m_sourceNodeId = value;
  }

  [DataMember(Name = "ReferenceTypeId", IsRequired = false, Order = 2)]
  public NodeId ReferenceTypeId
  {
    get => this.m_referenceTypeId;
    set => this.m_referenceTypeId = value;
  }

  [DataMember(Name = "IsForward", IsRequired = false, Order = 3)]
  public bool IsForward
  {
    get => this.m_isForward;
    set => this.m_isForward = value;
  }

  [DataMember(Name = "TargetServerUri", IsRequired = false, Order = 4)]
  public string TargetServerUri
  {
    get => this.m_targetServerUri;
    set => this.m_targetServerUri = value;
  }

  [DataMember(Name = "TargetNodeId", IsRequired = false, Order = 5)]
  public ExpandedNodeId TargetNodeId
  {
    get => this.m_targetNodeId;
    set => this.m_targetNodeId = value;
  }

  [DataMember(Name = "TargetNodeClass", IsRequired = false, Order = 6)]
  public NodeClass TargetNodeClass
  {
    get => this.m_targetNodeClass;
    set => this.m_targetNodeClass = value;
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.AddReferencesItem;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.AddReferencesItem_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.AddReferencesItem_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.AddReferencesItem_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteNodeId("SourceNodeId", this.SourceNodeId);
    encoder.WriteNodeId("ReferenceTypeId", this.ReferenceTypeId);
    encoder.WriteBoolean("IsForward", this.IsForward);
    encoder.WriteString("TargetServerUri", this.TargetServerUri);
    encoder.WriteExpandedNodeId("TargetNodeId", this.TargetNodeId);
    encoder.WriteEnumerated("TargetNodeClass", (Enum) this.TargetNodeClass);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.SourceNodeId = decoder.ReadNodeId("SourceNodeId");
    this.ReferenceTypeId = decoder.ReadNodeId("ReferenceTypeId");
    this.IsForward = decoder.ReadBoolean("IsForward");
    this.TargetServerUri = decoder.ReadString("TargetServerUri");
    this.TargetNodeId = decoder.ReadExpandedNodeId("TargetNodeId");
    this.TargetNodeClass = (NodeClass) decoder.ReadEnumerated("TargetNodeClass", typeof (NodeClass));
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is AddReferencesItem addReferencesItem && Utils.IsEqual((object) this.m_sourceNodeId, (object) addReferencesItem.m_sourceNodeId) && Utils.IsEqual((object) this.m_referenceTypeId, (object) addReferencesItem.m_referenceTypeId) && Utils.IsEqual((object) this.m_isForward, (object) addReferencesItem.m_isForward) && Utils.IsEqual((object) this.m_targetServerUri, (object) addReferencesItem.m_targetServerUri) && Utils.IsEqual((object) this.m_targetNodeId, (object) addReferencesItem.m_targetNodeId) && Utils.IsEqual((object) this.m_targetNodeClass, (object) addReferencesItem.m_targetNodeClass);
  }

  public virtual object Clone() => (object) (AddReferencesItem) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    AddReferencesItem addReferencesItem = (AddReferencesItem) base.MemberwiseClone();
    addReferencesItem.m_sourceNodeId = (NodeId) Utils.Clone((object) this.m_sourceNodeId);
    addReferencesItem.m_referenceTypeId = (NodeId) Utils.Clone((object) this.m_referenceTypeId);
    addReferencesItem.m_isForward = (bool) Utils.Clone((object) this.m_isForward);
    addReferencesItem.m_targetServerUri = (string) Utils.Clone((object) this.m_targetServerUri);
    addReferencesItem.m_targetNodeId = (ExpandedNodeId) Utils.Clone((object) this.m_targetNodeId);
    addReferencesItem.m_targetNodeClass = (NodeClass) Utils.Clone((object) this.m_targetNodeClass);
    return (object) addReferencesItem;
  }
}
