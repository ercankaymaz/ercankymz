// Decompiled with JetBrains decompiler
// Type: Opc.Ua.NetworkAddressUrlDataType
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class NetworkAddressUrlDataType : NetworkAddressDataType
{
  private string m_url;

  public NetworkAddressUrlDataType() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize() => this.m_url = (string) null;

  [DataMember(Name = "Url", IsRequired = false, Order = 1)]
  public string Url
  {
    get => this.m_url;
    set => this.m_url = value;
  }

  public override ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.NetworkAddressUrlDataType;

  public override ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.NetworkAddressUrlDataType_Encoding_DefaultBinary;
  }

  public override ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.NetworkAddressUrlDataType_Encoding_DefaultXml;
  }

  public override ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.NetworkAddressUrlDataType_Encoding_DefaultJson;
  }

  public override void Encode(IEncoder encoder)
  {
    base.Encode(encoder);
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteString("Url", this.Url);
    encoder.PopNamespace();
  }

  public override void Decode(IDecoder decoder)
  {
    base.Decode(decoder);
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.Url = decoder.ReadString("Url");
    decoder.PopNamespace();
  }

  public override bool IsEqual(IEncodeable encodeable)
  {
    if (this == encodeable)
      return true;
    return encodeable is NetworkAddressUrlDataType addressUrlDataType && base.IsEqual(encodeable) && Utils.IsEqual((object) this.m_url, (object) addressUrlDataType.m_url) && base.IsEqual(encodeable);
  }

  public override object Clone() => (object) (NetworkAddressUrlDataType) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    NetworkAddressUrlDataType addressUrlDataType = (NetworkAddressUrlDataType) base.MemberwiseClone();
    addressUrlDataType.m_url = (string) Utils.Clone((object) this.m_url);
    return (object) addressUrlDataType;
  }
}
