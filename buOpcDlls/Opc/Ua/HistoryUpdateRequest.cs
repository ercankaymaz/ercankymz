// Decompiled with JetBrains decompiler
// Type: Opc.Ua.HistoryUpdateRequest
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
public class HistoryUpdateRequest : IEncodeable, ICloneable, IJsonEncodeable, IServiceRequest
{
  private RequestHeader m_requestHeader;
  private ExtensionObjectCollection m_historyUpdateDetails;

  public HistoryUpdateRequest() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_requestHeader = new RequestHeader();
    this.m_historyUpdateDetails = new ExtensionObjectCollection();
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

  [DataMember(Name = "HistoryUpdateDetails", IsRequired = false, Order = 2)]
  public ExtensionObjectCollection HistoryUpdateDetails
  {
    get => this.m_historyUpdateDetails;
    set
    {
      this.m_historyUpdateDetails = value;
      if (value != null)
        return;
      this.m_historyUpdateDetails = new ExtensionObjectCollection();
    }
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.HistoryUpdateRequest;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.HistoryUpdateRequest_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.HistoryUpdateRequest_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.HistoryUpdateRequest_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteEncodeable("RequestHeader", (IEncodeable) this.RequestHeader, typeof (RequestHeader));
    encoder.WriteExtensionObjectArray("HistoryUpdateDetails", (IList<ExtensionObject>) this.HistoryUpdateDetails);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.RequestHeader = (RequestHeader) decoder.ReadEncodeable("RequestHeader", typeof (RequestHeader));
    this.HistoryUpdateDetails = decoder.ReadExtensionObjectArray("HistoryUpdateDetails");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is HistoryUpdateRequest historyUpdateRequest && Utils.IsEqual((object) this.m_requestHeader, (object) historyUpdateRequest.m_requestHeader) && Utils.IsEqual((object) this.m_historyUpdateDetails, (object) historyUpdateRequest.m_historyUpdateDetails);
  }

  public virtual object Clone() => (object) (HistoryUpdateRequest) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    HistoryUpdateRequest historyUpdateRequest = (HistoryUpdateRequest) base.MemberwiseClone();
    historyUpdateRequest.m_requestHeader = (RequestHeader) Utils.Clone((object) this.m_requestHeader);
    historyUpdateRequest.m_historyUpdateDetails = (ExtensionObjectCollection) Utils.Clone((object) this.m_historyUpdateDetails);
    return (object) historyUpdateRequest;
  }
}
