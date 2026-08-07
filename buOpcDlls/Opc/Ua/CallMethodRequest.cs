// Decompiled with JetBrains decompiler
// Type: Opc.Ua.CallMethodRequest
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
public class CallMethodRequest : IEncodeable, ICloneable, IJsonEncodeable
{
  private NodeId m_objectId;
  private NodeId m_methodId;
  private VariantCollection m_inputArguments;
  private object m_handle;
  private bool m_processed;

  public CallMethodRequest() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_objectId = (NodeId) null;
    this.m_methodId = (NodeId) null;
    this.m_inputArguments = new VariantCollection();
  }

  [DataMember(Name = "ObjectId", IsRequired = false, Order = 1)]
  public NodeId ObjectId
  {
    get => this.m_objectId;
    set => this.m_objectId = value;
  }

  [DataMember(Name = "MethodId", IsRequired = false, Order = 2)]
  public NodeId MethodId
  {
    get => this.m_methodId;
    set => this.m_methodId = value;
  }

  [DataMember(Name = "InputArguments", IsRequired = false, Order = 3)]
  public VariantCollection InputArguments
  {
    get => this.m_inputArguments;
    set
    {
      this.m_inputArguments = value;
      if (value != null)
        return;
      this.m_inputArguments = new VariantCollection();
    }
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.CallMethodRequest;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.CallMethodRequest_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.CallMethodRequest_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.CallMethodRequest_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteNodeId("ObjectId", this.ObjectId);
    encoder.WriteNodeId("MethodId", this.MethodId);
    encoder.WriteVariantArray("InputArguments", (IList<Variant>) this.InputArguments);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.ObjectId = decoder.ReadNodeId("ObjectId");
    this.MethodId = decoder.ReadNodeId("MethodId");
    this.InputArguments = decoder.ReadVariantArray("InputArguments");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is CallMethodRequest callMethodRequest && Utils.IsEqual((object) this.m_objectId, (object) callMethodRequest.m_objectId) && Utils.IsEqual((object) this.m_methodId, (object) callMethodRequest.m_methodId) && Utils.IsEqual((object) this.m_inputArguments, (object) callMethodRequest.m_inputArguments);
  }

  public virtual object Clone() => (object) (CallMethodRequest) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    CallMethodRequest callMethodRequest = (CallMethodRequest) base.MemberwiseClone();
    callMethodRequest.m_objectId = (NodeId) Utils.Clone((object) this.m_objectId);
    callMethodRequest.m_methodId = (NodeId) Utils.Clone((object) this.m_methodId);
    callMethodRequest.m_inputArguments = (VariantCollection) Utils.Clone((object) this.m_inputArguments);
    return (object) callMethodRequest;
  }

  public object Handle
  {
    get => this.m_handle;
    set => this.m_handle = value;
  }

  public bool Processed
  {
    get => this.m_processed;
    set => this.m_processed = value;
  }
}
