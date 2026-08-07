// Decompiled with JetBrains decompiler
// Type: Opc.Ua.CallRequest
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
public class CallRequest : IEncodeable, ICloneable, IJsonEncodeable, IServiceRequest
{
  private RequestHeader m_requestHeader;
  private CallMethodRequestCollection m_methodsToCall;

  public CallRequest() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_requestHeader = new RequestHeader();
    this.m_methodsToCall = new CallMethodRequestCollection();
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

  [DataMember(Name = "MethodsToCall", IsRequired = false, Order = 2)]
  public CallMethodRequestCollection MethodsToCall
  {
    get => this.m_methodsToCall;
    set
    {
      this.m_methodsToCall = value;
      if (value != null)
        return;
      this.m_methodsToCall = new CallMethodRequestCollection();
    }
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.CallRequest;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.CallRequest_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.CallRequest_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.CallRequest_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteEncodeable("RequestHeader", (IEncodeable) this.RequestHeader, typeof (RequestHeader));
    encoder.WriteEncodeableArray("MethodsToCall", (IList<IEncodeable>) this.MethodsToCall.ToArray(), typeof (CallMethodRequest));
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.RequestHeader = (RequestHeader) decoder.ReadEncodeable("RequestHeader", typeof (RequestHeader));
    this.MethodsToCall = (CallMethodRequestCollection) (CallMethodRequest[]) decoder.ReadEncodeableArray("MethodsToCall", typeof (CallMethodRequest));
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is CallRequest callRequest && Utils.IsEqual((object) this.m_requestHeader, (object) callRequest.m_requestHeader) && Utils.IsEqual((object) this.m_methodsToCall, (object) callRequest.m_methodsToCall);
  }

  public virtual object Clone() => (object) (CallRequest) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    CallRequest callRequest = (CallRequest) base.MemberwiseClone();
    callRequest.m_requestHeader = (RequestHeader) Utils.Clone((object) this.m_requestHeader);
    callRequest.m_methodsToCall = (CallMethodRequestCollection) Utils.Clone((object) this.m_methodsToCall);
    return (object) callRequest;
  }
}
