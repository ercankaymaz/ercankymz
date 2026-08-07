// Decompiled with JetBrains decompiler
// Type: Opc.Ua.SessionlessInvokeResponseType
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
public class SessionlessInvokeResponseType : IEncodeable, ICloneable, IJsonEncodeable
{
  private StringCollection m_namespaceUris;
  private StringCollection m_serverUris;
  private uint m_serviceId;

  public SessionlessInvokeResponseType() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_namespaceUris = new StringCollection();
    this.m_serverUris = new StringCollection();
    this.m_serviceId = 0U;
  }

  [DataMember(Name = "NamespaceUris", IsRequired = false, Order = 1)]
  public StringCollection NamespaceUris
  {
    get => this.m_namespaceUris;
    set
    {
      this.m_namespaceUris = value;
      if (value != null)
        return;
      this.m_namespaceUris = new StringCollection();
    }
  }

  [DataMember(Name = "ServerUris", IsRequired = false, Order = 2)]
  public StringCollection ServerUris
  {
    get => this.m_serverUris;
    set
    {
      this.m_serverUris = value;
      if (value != null)
        return;
      this.m_serverUris = new StringCollection();
    }
  }

  [DataMember(Name = "ServiceId", IsRequired = false, Order = 3)]
  public uint ServiceId
  {
    get => this.m_serviceId;
    set => this.m_serviceId = value;
  }

  public virtual ExpandedNodeId TypeId
  {
    get => (ExpandedNodeId) DataTypeIds.SessionlessInvokeResponseType;
  }

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.SessionlessInvokeResponseType_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.SessionlessInvokeResponseType_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.SessionlessInvokeResponseType_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteStringArray("NamespaceUris", (IList<string>) this.NamespaceUris);
    encoder.WriteStringArray("ServerUris", (IList<string>) this.ServerUris);
    encoder.WriteUInt32("ServiceId", this.ServiceId);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.NamespaceUris = decoder.ReadStringArray("NamespaceUris");
    this.ServerUris = decoder.ReadStringArray("ServerUris");
    this.ServiceId = decoder.ReadUInt32("ServiceId");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is SessionlessInvokeResponseType invokeResponseType && Utils.IsEqual((object) this.m_namespaceUris, (object) invokeResponseType.m_namespaceUris) && Utils.IsEqual((object) this.m_serverUris, (object) invokeResponseType.m_serverUris) && Utils.IsEqual((object) this.m_serviceId, (object) invokeResponseType.m_serviceId);
  }

  public virtual object Clone() => (object) (SessionlessInvokeResponseType) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    SessionlessInvokeResponseType invokeResponseType = (SessionlessInvokeResponseType) base.MemberwiseClone();
    invokeResponseType.m_namespaceUris = (StringCollection) Utils.Clone((object) this.m_namespaceUris);
    invokeResponseType.m_serverUris = (StringCollection) Utils.Clone((object) this.m_serverUris);
    invokeResponseType.m_serviceId = (uint) Utils.Clone((object) this.m_serviceId);
    return (object) invokeResponseType;
  }
}
