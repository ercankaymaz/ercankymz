// Decompiled with JetBrains decompiler
// Type: Opc.Ua.DeleteNodesRequest
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
public class DeleteNodesRequest : IEncodeable, ICloneable, IJsonEncodeable, IServiceRequest
{
  private RequestHeader m_requestHeader;
  private DeleteNodesItemCollection m_nodesToDelete;

  public DeleteNodesRequest() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_requestHeader = new RequestHeader();
    this.m_nodesToDelete = new DeleteNodesItemCollection();
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

  [DataMember(Name = "NodesToDelete", IsRequired = false, Order = 2)]
  public DeleteNodesItemCollection NodesToDelete
  {
    get => this.m_nodesToDelete;
    set
    {
      this.m_nodesToDelete = value;
      if (value != null)
        return;
      this.m_nodesToDelete = new DeleteNodesItemCollection();
    }
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.DeleteNodesRequest;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.DeleteNodesRequest_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.DeleteNodesRequest_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.DeleteNodesRequest_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteEncodeable("RequestHeader", (IEncodeable) this.RequestHeader, typeof (RequestHeader));
    encoder.WriteEncodeableArray("NodesToDelete", (IList<IEncodeable>) this.NodesToDelete.ToArray(), typeof (DeleteNodesItem));
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.RequestHeader = (RequestHeader) decoder.ReadEncodeable("RequestHeader", typeof (RequestHeader));
    this.NodesToDelete = (DeleteNodesItemCollection) (DeleteNodesItem[]) decoder.ReadEncodeableArray("NodesToDelete", typeof (DeleteNodesItem));
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is DeleteNodesRequest deleteNodesRequest && Utils.IsEqual((object) this.m_requestHeader, (object) deleteNodesRequest.m_requestHeader) && Utils.IsEqual((object) this.m_nodesToDelete, (object) deleteNodesRequest.m_nodesToDelete);
  }

  public virtual object Clone() => (object) (DeleteNodesRequest) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    DeleteNodesRequest deleteNodesRequest = (DeleteNodesRequest) base.MemberwiseClone();
    deleteNodesRequest.m_requestHeader = (RequestHeader) Utils.Clone((object) this.m_requestHeader);
    deleteNodesRequest.m_nodesToDelete = (DeleteNodesItemCollection) Utils.Clone((object) this.m_nodesToDelete);
    return (object) deleteNodesRequest;
  }
}
