// Decompiled with JetBrains decompiler
// Type: Opc.Ua.BrowseRequest
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class BrowseRequest : IEncodeable, ICloneable, IJsonEncodeable, IServiceRequest
{
  private RequestHeader m_requestHeader;
  private ViewDescription m_view;
  private uint m_requestedMaxReferencesPerNode;
  private BrowseDescriptionCollection m_nodesToBrowse;

  public BrowseRequest() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_requestHeader = new RequestHeader();
    this.m_view = new ViewDescription();
    this.m_requestedMaxReferencesPerNode = 0U;
    this.m_nodesToBrowse = new BrowseDescriptionCollection();
  }

  [DataMember(Name = "RequestHeader", IsRequired = false, Order = 1)]
  public RequestHeader RequestHeader
  {
    get => this.m_requestHeader;
    set
    {
      this.m_requestHeader = value;
      if (value != null)
        return;
      this.m_requestHeader = new RequestHeader();
    }
  }

  [DataMember(Name = "View", IsRequired = false, Order = 2)]
  public ViewDescription View
  {
    get => this.m_view;
    set
    {
      this.m_view = value;
      if (value != null)
        return;
      this.m_view = new ViewDescription();
    }
  }

  [DataMember(Name = "RequestedMaxReferencesPerNode", IsRequired = false, Order = 3)]
  public uint RequestedMaxReferencesPerNode
  {
    get => this.m_requestedMaxReferencesPerNode;
    set => this.m_requestedMaxReferencesPerNode = value;
  }

  [DataMember(Name = "NodesToBrowse", IsRequired = false, Order = 4)]
  public BrowseDescriptionCollection NodesToBrowse
  {
    get => this.m_nodesToBrowse;
    set
    {
      this.m_nodesToBrowse = value;
      if (value != null)
        return;
      this.m_nodesToBrowse = new BrowseDescriptionCollection();
    }
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.BrowseRequest;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.BrowseRequest_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.BrowseRequest_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.BrowseRequest_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteEncodeable("RequestHeader", (IEncodeable) this.RequestHeader, typeof (RequestHeader));
    encoder.WriteEncodeable("View", (IEncodeable) this.View, typeof (ViewDescription));
    encoder.WriteUInt32("RequestedMaxReferencesPerNode", this.RequestedMaxReferencesPerNode);
    encoder.WriteEncodeableArray("NodesToBrowse", (IList<IEncodeable>) this.NodesToBrowse.ToArray(), typeof (BrowseDescription));
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.RequestHeader = (RequestHeader) decoder.ReadEncodeable("RequestHeader", typeof (RequestHeader));
    this.View = (ViewDescription) decoder.ReadEncodeable("View", typeof (ViewDescription));
    this.RequestedMaxReferencesPerNode = decoder.ReadUInt32("RequestedMaxReferencesPerNode");
    this.NodesToBrowse = (BrowseDescriptionCollection) (BrowseDescription[]) decoder.ReadEncodeableArray("NodesToBrowse", typeof (BrowseDescription));
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is BrowseRequest browseRequest && Utils.IsEqual((object) this.m_requestHeader, (object) browseRequest.m_requestHeader) && Utils.IsEqual((object) this.m_view, (object) browseRequest.m_view) && Utils.IsEqual((object) this.m_requestedMaxReferencesPerNode, (object) browseRequest.m_requestedMaxReferencesPerNode) && Utils.IsEqual((object) this.m_nodesToBrowse, (object) browseRequest.m_nodesToBrowse);
  }

  public virtual object Clone() => (object) (BrowseRequest) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    BrowseRequest browseRequest = (BrowseRequest) base.MemberwiseClone();
    browseRequest.m_requestHeader = (RequestHeader) Utils.Clone((object) this.m_requestHeader);
    browseRequest.m_view = (ViewDescription) Utils.Clone((object) this.m_view);
    browseRequest.m_requestedMaxReferencesPerNode = (uint) Utils.Clone((object) this.m_requestedMaxReferencesPerNode);
    browseRequest.m_nodesToBrowse = (BrowseDescriptionCollection) Utils.Clone((object) this.m_nodesToBrowse);
    return (object) browseRequest;
  }
}
