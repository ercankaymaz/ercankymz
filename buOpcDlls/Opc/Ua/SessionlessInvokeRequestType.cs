// Decompiled with JetBrains decompiler
// Type: Opc.Ua.SessionlessInvokeRequestType
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
public class SessionlessInvokeRequestType : IEncodeable, ICloneable, IJsonEncodeable
{
  private uint m_urisVersion;
  private StringCollection m_namespaceUris;
  private StringCollection m_serverUris;
  private StringCollection m_localeIds;
  private uint m_serviceId;

  public SessionlessInvokeRequestType() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_urisVersion = 0U;
    this.m_namespaceUris = new StringCollection();
    this.m_serverUris = new StringCollection();
    this.m_localeIds = new StringCollection();
    this.m_serviceId = 0U;
  }

  [DataMember(Name = "UrisVersion", IsRequired = false, Order = 1)]
  public uint UrisVersion
  {
    get => this.m_urisVersion;
    set => this.m_urisVersion = value;
  }

  [DataMember(Name = "NamespaceUris", IsRequired = false, Order = 2)]
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

  [DataMember(Name = "ServerUris", IsRequired = false, Order = 3)]
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

  [DataMember(Name = "LocaleIds", IsRequired = false, Order = 4)]
  public StringCollection LocaleIds
  {
    get => this.m_localeIds;
    set
    {
      this.m_localeIds = value;
      if (value != null)
        return;
      this.m_localeIds = new StringCollection();
    }
  }

  [DataMember(Name = "ServiceId", IsRequired = false, Order = 5)]
  public uint ServiceId
  {
    get => this.m_serviceId;
    set => this.m_serviceId = value;
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.SessionlessInvokeRequestType;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.SessionlessInvokeRequestType_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.SessionlessInvokeRequestType_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.SessionlessInvokeRequestType_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteUInt32("UrisVersion", this.UrisVersion);
    encoder.WriteStringArray("NamespaceUris", (IList<string>) this.NamespaceUris);
    encoder.WriteStringArray("ServerUris", (IList<string>) this.ServerUris);
    encoder.WriteStringArray("LocaleIds", (IList<string>) this.LocaleIds);
    encoder.WriteUInt32("ServiceId", this.ServiceId);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.UrisVersion = decoder.ReadUInt32("UrisVersion");
    this.NamespaceUris = decoder.ReadStringArray("NamespaceUris");
    this.ServerUris = decoder.ReadStringArray("ServerUris");
    this.LocaleIds = decoder.ReadStringArray("LocaleIds");
    this.ServiceId = decoder.ReadUInt32("ServiceId");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is SessionlessInvokeRequestType invokeRequestType && Utils.IsEqual((object) this.m_urisVersion, (object) invokeRequestType.m_urisVersion) && Utils.IsEqual((object) this.m_namespaceUris, (object) invokeRequestType.m_namespaceUris) && Utils.IsEqual((object) this.m_serverUris, (object) invokeRequestType.m_serverUris) && Utils.IsEqual((object) this.m_localeIds, (object) invokeRequestType.m_localeIds) && Utils.IsEqual((object) this.m_serviceId, (object) invokeRequestType.m_serviceId);
  }

  public virtual object Clone() => (object) (SessionlessInvokeRequestType) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    SessionlessInvokeRequestType invokeRequestType = (SessionlessInvokeRequestType) base.MemberwiseClone();
    invokeRequestType.m_urisVersion = (uint) Utils.Clone((object) this.m_urisVersion);
    invokeRequestType.m_namespaceUris = (StringCollection) Utils.Clone((object) this.m_namespaceUris);
    invokeRequestType.m_serverUris = (StringCollection) Utils.Clone((object) this.m_serverUris);
    invokeRequestType.m_localeIds = (StringCollection) Utils.Clone((object) this.m_localeIds);
    invokeRequestType.m_serviceId = (uint) Utils.Clone((object) this.m_serviceId);
    return (object) invokeRequestType;
  }
}
