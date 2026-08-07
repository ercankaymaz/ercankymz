// Decompiled with JetBrains decompiler
// Type: Opc.Ua.NetworkGroupDataType
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
public class NetworkGroupDataType : IEncodeable, ICloneable, IJsonEncodeable
{
  private string m_serverUri;
  private EndpointUrlListDataTypeCollection m_networkPaths;

  public NetworkGroupDataType() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_serverUri = (string) null;
    this.m_networkPaths = new EndpointUrlListDataTypeCollection();
  }

  [DataMember(Name = "ServerUri", IsRequired = false, Order = 1)]
  public string ServerUri
  {
    get => this.m_serverUri;
    set => this.m_serverUri = value;
  }

  [DataMember(Name = "NetworkPaths", IsRequired = false, Order = 2)]
  public EndpointUrlListDataTypeCollection NetworkPaths
  {
    get => this.m_networkPaths;
    set
    {
      this.m_networkPaths = value;
      if (value != null)
        return;
      this.m_networkPaths = new EndpointUrlListDataTypeCollection();
    }
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.NetworkGroupDataType;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.NetworkGroupDataType_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.NetworkGroupDataType_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.NetworkGroupDataType_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteString("ServerUri", this.ServerUri);
    encoder.WriteEncodeableArray("NetworkPaths", (IList<IEncodeable>) this.NetworkPaths.ToArray(), typeof (EndpointUrlListDataType));
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.ServerUri = decoder.ReadString("ServerUri");
    this.NetworkPaths = (EndpointUrlListDataTypeCollection) (EndpointUrlListDataType[]) decoder.ReadEncodeableArray("NetworkPaths", typeof (EndpointUrlListDataType));
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is NetworkGroupDataType networkGroupDataType && Utils.IsEqual((object) this.m_serverUri, (object) networkGroupDataType.m_serverUri) && Utils.IsEqual((object) this.m_networkPaths, (object) networkGroupDataType.m_networkPaths);
  }

  public virtual object Clone() => (object) (NetworkGroupDataType) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    NetworkGroupDataType networkGroupDataType = (NetworkGroupDataType) base.MemberwiseClone();
    networkGroupDataType.m_serverUri = (string) Utils.Clone((object) this.m_serverUri);
    networkGroupDataType.m_networkPaths = (EndpointUrlListDataTypeCollection) Utils.Clone((object) this.m_networkPaths);
    return (object) networkGroupDataType;
  }
}
