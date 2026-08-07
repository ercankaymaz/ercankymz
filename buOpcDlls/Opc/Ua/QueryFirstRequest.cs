// Decompiled with JetBrains decompiler
// Type: Opc.Ua.QueryFirstRequest
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
public class QueryFirstRequest : IEncodeable, ICloneable, IJsonEncodeable, IServiceRequest
{
  private RequestHeader m_requestHeader;
  private ViewDescription m_view;
  private NodeTypeDescriptionCollection m_nodeTypes;
  private ContentFilter m_filter;
  private uint m_maxDataSetsToReturn;
  private uint m_maxReferencesToReturn;

  public QueryFirstRequest() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_requestHeader = new RequestHeader();
    this.m_view = new ViewDescription();
    this.m_nodeTypes = new NodeTypeDescriptionCollection();
    this.m_filter = new ContentFilter();
    this.m_maxDataSetsToReturn = 0U;
    this.m_maxReferencesToReturn = 0U;
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

  [DataMember(Name = "NodeTypes", IsRequired = false, Order = 3)]
  public NodeTypeDescriptionCollection NodeTypes
  {
    get => this.m_nodeTypes;
    set
    {
      this.m_nodeTypes = value;
      if (value != null)
        return;
      this.m_nodeTypes = new NodeTypeDescriptionCollection();
    }
  }

  [DataMember(Name = "Filter", IsRequired = false, Order = 4)]
  public ContentFilter Filter
  {
    get => this.m_filter;
    set
    {
      this.m_filter = value;
      if (value != null)
        return;
      this.m_filter = new ContentFilter();
    }
  }

  [DataMember(Name = "MaxDataSetsToReturn", IsRequired = false, Order = 5)]
  public uint MaxDataSetsToReturn
  {
    get => this.m_maxDataSetsToReturn;
    set => this.m_maxDataSetsToReturn = value;
  }

  [DataMember(Name = "MaxReferencesToReturn", IsRequired = false, Order = 6)]
  public uint MaxReferencesToReturn
  {
    get => this.m_maxReferencesToReturn;
    set => this.m_maxReferencesToReturn = value;
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.QueryFirstRequest;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.QueryFirstRequest_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.QueryFirstRequest_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.QueryFirstRequest_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteEncodeable("RequestHeader", (IEncodeable) this.RequestHeader, typeof (RequestHeader));
    encoder.WriteEncodeable("View", (IEncodeable) this.View, typeof (ViewDescription));
    encoder.WriteEncodeableArray("NodeTypes", (IList<IEncodeable>) this.NodeTypes.ToArray(), typeof (NodeTypeDescription));
    encoder.WriteEncodeable("Filter", (IEncodeable) this.Filter, typeof (ContentFilter));
    encoder.WriteUInt32("MaxDataSetsToReturn", this.MaxDataSetsToReturn);
    encoder.WriteUInt32("MaxReferencesToReturn", this.MaxReferencesToReturn);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.RequestHeader = (RequestHeader) decoder.ReadEncodeable("RequestHeader", typeof (RequestHeader));
    this.View = (ViewDescription) decoder.ReadEncodeable("View", typeof (ViewDescription));
    this.NodeTypes = (NodeTypeDescriptionCollection) (NodeTypeDescription[]) decoder.ReadEncodeableArray("NodeTypes", typeof (NodeTypeDescription));
    this.Filter = (ContentFilter) decoder.ReadEncodeable("Filter", typeof (ContentFilter));
    this.MaxDataSetsToReturn = decoder.ReadUInt32("MaxDataSetsToReturn");
    this.MaxReferencesToReturn = decoder.ReadUInt32("MaxReferencesToReturn");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is QueryFirstRequest queryFirstRequest && Utils.IsEqual((object) this.m_requestHeader, (object) queryFirstRequest.m_requestHeader) && Utils.IsEqual((object) this.m_view, (object) queryFirstRequest.m_view) && Utils.IsEqual((object) this.m_nodeTypes, (object) queryFirstRequest.m_nodeTypes) && Utils.IsEqual((object) this.m_filter, (object) queryFirstRequest.m_filter) && Utils.IsEqual((object) this.m_maxDataSetsToReturn, (object) queryFirstRequest.m_maxDataSetsToReturn) && Utils.IsEqual((object) this.m_maxReferencesToReturn, (object) queryFirstRequest.m_maxReferencesToReturn);
  }

  public virtual object Clone() => (object) (QueryFirstRequest) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    QueryFirstRequest queryFirstRequest = (QueryFirstRequest) base.MemberwiseClone();
    queryFirstRequest.m_requestHeader = (RequestHeader) Utils.Clone((object) this.m_requestHeader);
    queryFirstRequest.m_view = (ViewDescription) Utils.Clone((object) this.m_view);
    queryFirstRequest.m_nodeTypes = (NodeTypeDescriptionCollection) Utils.Clone((object) this.m_nodeTypes);
    queryFirstRequest.m_filter = (ContentFilter) Utils.Clone((object) this.m_filter);
    queryFirstRequest.m_maxDataSetsToReturn = (uint) Utils.Clone((object) this.m_maxDataSetsToReturn);
    queryFirstRequest.m_maxReferencesToReturn = (uint) Utils.Clone((object) this.m_maxReferencesToReturn);
    return (object) queryFirstRequest;
  }
}
