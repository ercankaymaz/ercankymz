// Decompiled with JetBrains decompiler
// Type: Opc.Ua.BrowsePathTarget
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
public class BrowsePathTarget : IEncodeable, ICloneable, IJsonEncodeable
{
  private ExpandedNodeId m_targetId;
  private uint m_remainingPathIndex;

  public BrowsePathTarget() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_targetId = (ExpandedNodeId) null;
    this.m_remainingPathIndex = 0U;
  }

  [DataMember(Name = "TargetId", IsRequired = false, Order = 1)]
  public ExpandedNodeId TargetId
  {
    get => this.m_targetId;
    set => this.m_targetId = value;
  }

  [DataMember(Name = "RemainingPathIndex", IsRequired = false, Order = 2)]
  public uint RemainingPathIndex
  {
    get => this.m_remainingPathIndex;
    set => this.m_remainingPathIndex = value;
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.BrowsePathTarget;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.BrowsePathTarget_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.BrowsePathTarget_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.BrowsePathTarget_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteExpandedNodeId("TargetId", this.TargetId);
    encoder.WriteUInt32("RemainingPathIndex", this.RemainingPathIndex);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.TargetId = decoder.ReadExpandedNodeId("TargetId");
    this.RemainingPathIndex = decoder.ReadUInt32("RemainingPathIndex");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is BrowsePathTarget browsePathTarget && Utils.IsEqual((object) this.m_targetId, (object) browsePathTarget.m_targetId) && Utils.IsEqual((object) this.m_remainingPathIndex, (object) browsePathTarget.m_remainingPathIndex);
  }

  public virtual object Clone() => (object) (BrowsePathTarget) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    BrowsePathTarget browsePathTarget = (BrowsePathTarget) base.MemberwiseClone();
    browsePathTarget.m_targetId = (ExpandedNodeId) Utils.Clone((object) this.m_targetId);
    browsePathTarget.m_remainingPathIndex = (uint) Utils.Clone((object) this.m_remainingPathIndex);
    return (object) browsePathTarget;
  }
}
