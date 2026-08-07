// Decompiled with JetBrains decompiler
// Type: Opc.Ua.AddReferencesRequest
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
public class AddReferencesRequest : IEncodeable, ICloneable, IJsonEncodeable, IServiceRequest
{
  private RequestHeader m_requestHeader;
  private AddReferencesItemCollection m_referencesToAdd;

  public AddReferencesRequest() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_requestHeader = new RequestHeader();
    this.m_referencesToAdd = new AddReferencesItemCollection();
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

  [DataMember(Name = "ReferencesToAdd", IsRequired = false, Order = 2)]
  public AddReferencesItemCollection ReferencesToAdd
  {
    get => this.m_referencesToAdd;
    set
    {
      this.m_referencesToAdd = value;
      if (value != null)
        return;
      this.m_referencesToAdd = new AddReferencesItemCollection();
    }
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.AddReferencesRequest;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.AddReferencesRequest_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.AddReferencesRequest_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.AddReferencesRequest_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteEncodeable("RequestHeader", (IEncodeable) this.RequestHeader, typeof (RequestHeader));
    encoder.WriteEncodeableArray("ReferencesToAdd", (IList<IEncodeable>) this.ReferencesToAdd.ToArray(), typeof (AddReferencesItem));
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.RequestHeader = (RequestHeader) decoder.ReadEncodeable("RequestHeader", typeof (RequestHeader));
    this.ReferencesToAdd = (AddReferencesItemCollection) (AddReferencesItem[]) decoder.ReadEncodeableArray("ReferencesToAdd", typeof (AddReferencesItem));
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is AddReferencesRequest referencesRequest && Utils.IsEqual((object) this.m_requestHeader, (object) referencesRequest.m_requestHeader) && Utils.IsEqual((object) this.m_referencesToAdd, (object) referencesRequest.m_referencesToAdd);
  }

  public virtual object Clone() => (object) (AddReferencesRequest) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    AddReferencesRequest referencesRequest = (AddReferencesRequest) base.MemberwiseClone();
    referencesRequest.m_requestHeader = (RequestHeader) Utils.Clone((object) this.m_requestHeader);
    referencesRequest.m_referencesToAdd = (AddReferencesItemCollection) Utils.Clone((object) this.m_referencesToAdd);
    return (object) referencesRequest;
  }
}
