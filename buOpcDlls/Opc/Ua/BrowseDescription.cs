// Decompiled with JetBrains decompiler
// Type: Opc.Ua.BrowseDescription
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
public class BrowseDescription : IEncodeable, ICloneable, IJsonEncodeable
{
  private NodeId m_nodeId;
  private BrowseDirection m_browseDirection;
  private NodeId m_referenceTypeId;
  private bool m_includeSubtypes;
  private uint m_nodeClassMask;
  private uint m_resultMask;
  private object m_handle;

  public BrowseDescription() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_nodeId = (NodeId) null;
    this.m_browseDirection = BrowseDirection.Forward;
    this.m_referenceTypeId = (NodeId) null;
    this.m_includeSubtypes = true;
    this.m_nodeClassMask = 0U;
    this.m_resultMask = 0U;
  }

  [DataMember(Name = "NodeId", IsRequired = false, Order = 1)]
  public NodeId NodeId
  {
    get => this.m_nodeId;
    set => this.m_nodeId = value;
  }

  [DataMember(Name = "BrowseDirection", IsRequired = false, Order = 2)]
  public BrowseDirection BrowseDirection
  {
    get => this.m_browseDirection;
    set => this.m_browseDirection = value;
  }

  [DataMember(Name = "ReferenceTypeId", IsRequired = false, Order = 3)]
  public NodeId ReferenceTypeId
  {
    get => this.m_referenceTypeId;
    set => this.m_referenceTypeId = value;
  }

  [DataMember(Name = "IncludeSubtypes", IsRequired = false, Order = 4)]
  public bool IncludeSubtypes
  {
    get => this.m_includeSubtypes;
    set => this.m_includeSubtypes = value;
  }

  [DataMember(Name = "NodeClassMask", IsRequired = false, Order = 5)]
  public uint NodeClassMask
  {
    get => this.m_nodeClassMask;
    set => this.m_nodeClassMask = value;
  }

  [DataMember(Name = "ResultMask", IsRequired = false, Order = 6)]
  public uint ResultMask
  {
    get => this.m_resultMask;
    set => this.m_resultMask = value;
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.BrowseDescription;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.BrowseDescription_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.BrowseDescription_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.BrowseDescription_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteNodeId("NodeId", this.NodeId);
    encoder.WriteEnumerated("BrowseDirection", (Enum) this.BrowseDirection);
    encoder.WriteNodeId("ReferenceTypeId", this.ReferenceTypeId);
    encoder.WriteBoolean("IncludeSubtypes", this.IncludeSubtypes);
    encoder.WriteUInt32("NodeClassMask", this.NodeClassMask);
    encoder.WriteUInt32("ResultMask", this.ResultMask);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.NodeId = decoder.ReadNodeId("NodeId");
    this.BrowseDirection = (BrowseDirection) decoder.ReadEnumerated("BrowseDirection", typeof (BrowseDirection));
    this.ReferenceTypeId = decoder.ReadNodeId("ReferenceTypeId");
    this.IncludeSubtypes = decoder.ReadBoolean("IncludeSubtypes");
    this.NodeClassMask = decoder.ReadUInt32("NodeClassMask");
    this.ResultMask = decoder.ReadUInt32("ResultMask");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is BrowseDescription browseDescription && Utils.IsEqual((object) this.m_nodeId, (object) browseDescription.m_nodeId) && Utils.IsEqual((object) this.m_browseDirection, (object) browseDescription.m_browseDirection) && Utils.IsEqual((object) this.m_referenceTypeId, (object) browseDescription.m_referenceTypeId) && Utils.IsEqual((object) this.m_includeSubtypes, (object) browseDescription.m_includeSubtypes) && Utils.IsEqual((object) this.m_nodeClassMask, (object) browseDescription.m_nodeClassMask) && Utils.IsEqual((object) this.m_resultMask, (object) browseDescription.m_resultMask);
  }

  public virtual object Clone() => (object) (BrowseDescription) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    BrowseDescription browseDescription = (BrowseDescription) base.MemberwiseClone();
    browseDescription.m_nodeId = (NodeId) Utils.Clone((object) this.m_nodeId);
    browseDescription.m_browseDirection = (BrowseDirection) Utils.Clone((object) this.m_browseDirection);
    browseDescription.m_referenceTypeId = (NodeId) Utils.Clone((object) this.m_referenceTypeId);
    browseDescription.m_includeSubtypes = (bool) Utils.Clone((object) this.m_includeSubtypes);
    browseDescription.m_nodeClassMask = (uint) Utils.Clone((object) this.m_nodeClassMask);
    browseDescription.m_resultMask = (uint) Utils.Clone((object) this.m_resultMask);
    return (object) browseDescription;
  }

  public object Handle
  {
    get => this.m_handle;
    set => this.m_handle = value;
  }
}
