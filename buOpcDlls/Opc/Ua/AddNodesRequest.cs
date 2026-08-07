// Decompiled with JetBrains decompiler
// Type: Opc.Ua.AddNodesRequest
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
public class AddNodesRequest : IEncodeable, ICloneable, IJsonEncodeable, IServiceRequest
{
  private RequestHeader m_requestHeader;
  private AddNodesItemCollection m_nodesToAdd;

  public AddNodesRequest() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_requestHeader = new RequestHeader();
    this.m_nodesToAdd = new AddNodesItemCollection();
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

  [DataMember(Name = "NodesToAdd", IsRequired = false, Order = 2)]
  public AddNodesItemCollection NodesToAdd
  {
    get => this.m_nodesToAdd;
    set
    {
      this.m_nodesToAdd = value;
      if (value != null)
        return;
      this.m_nodesToAdd = new AddNodesItemCollection();
    }
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.AddNodesRequest;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.AddNodesRequest_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.AddNodesRequest_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.AddNodesRequest_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteEncodeable("RequestHeader", (IEncodeable) this.RequestHeader, typeof (RequestHeader));
    encoder.WriteEncodeableArray("NodesToAdd", (IList<IEncodeable>) this.NodesToAdd.ToArray(), typeof (AddNodesItem));
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.RequestHeader = (RequestHeader) decoder.ReadEncodeable("RequestHeader", typeof (RequestHeader));
    this.NodesToAdd = (AddNodesItemCollection) (AddNodesItem[]) decoder.ReadEncodeableArray("NodesToAdd", typeof (AddNodesItem));
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is AddNodesRequest addNodesRequest && Utils.IsEqual((object) this.m_requestHeader, (object) addNodesRequest.m_requestHeader) && Utils.IsEqual((object) this.m_nodesToAdd, (object) addNodesRequest.m_nodesToAdd);
  }

  public virtual object Clone() => (object) (AddNodesRequest) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    AddNodesRequest addNodesRequest = (AddNodesRequest) base.MemberwiseClone();
    addNodesRequest.m_requestHeader = (RequestHeader) Utils.Clone((object) this.m_requestHeader);
    addNodesRequest.m_nodesToAdd = (AddNodesItemCollection) Utils.Clone((object) this.m_nodesToAdd);
    return (object) addNodesRequest;
  }
}
