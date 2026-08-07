// Decompiled with JetBrains decompiler
// Type: Opc.Ua.NetworkAddressDataType
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class NetworkAddressDataType : IEncodeable, ICloneable, IJsonEncodeable
{
  private string m_networkInterface;

  public NetworkAddressDataType() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize() => this.m_networkInterface = (string) null;

  [DataMember(Name = "NetworkInterface", IsRequired = false, Order = 1)]
  public string NetworkInterface
  {
    get => this.m_networkInterface;
    set => this.m_networkInterface = value;
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.NetworkAddressDataType;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.NetworkAddressDataType_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.NetworkAddressDataType_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.NetworkAddressDataType_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteString("NetworkInterface", this.NetworkInterface);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.NetworkInterface = decoder.ReadString("NetworkInterface");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is NetworkAddressDataType networkAddressDataType && Utils.IsEqual((object) this.m_networkInterface, (object) networkAddressDataType.m_networkInterface);
  }

  public virtual object Clone() => (object) (NetworkAddressDataType) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    NetworkAddressDataType networkAddressDataType = (NetworkAddressDataType) base.MemberwiseClone();
    networkAddressDataType.m_networkInterface = (string) Utils.Clone((object) this.m_networkInterface);
    return (object) networkAddressDataType;
  }
}
