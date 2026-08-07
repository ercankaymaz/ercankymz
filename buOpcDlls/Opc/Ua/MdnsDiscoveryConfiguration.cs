// Decompiled with JetBrains decompiler
// Type: Opc.Ua.MdnsDiscoveryConfiguration
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class MdnsDiscoveryConfiguration : DiscoveryConfiguration
{
  private string m_mdnsServerName;
  private StringCollection m_serverCapabilities;

  public MdnsDiscoveryConfiguration() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_mdnsServerName = (string) null;
    this.m_serverCapabilities = new StringCollection();
  }

  [DataMember(Name = "MdnsServerName", IsRequired = false, Order = 1)]
  public string MdnsServerName
  {
    get => this.m_mdnsServerName;
    set => this.m_mdnsServerName = value;
  }

  [DataMember(Name = "ServerCapabilities", IsRequired = false, Order = 2)]
  public StringCollection ServerCapabilities
  {
    get => this.m_serverCapabilities;
    set
    {
      this.m_serverCapabilities = value;
      if (value != null)
        return;
      this.m_serverCapabilities = new StringCollection();
    }
  }

  public override ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.MdnsDiscoveryConfiguration;

  public override ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.MdnsDiscoveryConfiguration_Encoding_DefaultBinary;
  }

  public override ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.MdnsDiscoveryConfiguration_Encoding_DefaultXml;
  }

  public override ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.MdnsDiscoveryConfiguration_Encoding_DefaultJson;
  }

  public override void Encode(IEncoder encoder)
  {
    base.Encode(encoder);
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteString("MdnsServerName", this.MdnsServerName);
    encoder.WriteStringArray("ServerCapabilities", (IList<string>) this.ServerCapabilities);
    encoder.PopNamespace();
  }

  public override void Decode(IDecoder decoder)
  {
    base.Decode(decoder);
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.MdnsServerName = decoder.ReadString("MdnsServerName");
    this.ServerCapabilities = decoder.ReadStringArray("ServerCapabilities");
    decoder.PopNamespace();
  }

  public override bool IsEqual(IEncodeable encodeable)
  {
    if (this == encodeable)
      return true;
    return encodeable is MdnsDiscoveryConfiguration discoveryConfiguration && base.IsEqual(encodeable) && Utils.IsEqual((object) this.m_mdnsServerName, (object) discoveryConfiguration.m_mdnsServerName) && Utils.IsEqual((object) this.m_serverCapabilities, (object) discoveryConfiguration.m_serverCapabilities) && base.IsEqual(encodeable);
  }

  public override object Clone() => (object) (MdnsDiscoveryConfiguration) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    MdnsDiscoveryConfiguration discoveryConfiguration = (MdnsDiscoveryConfiguration) base.MemberwiseClone();
    discoveryConfiguration.m_mdnsServerName = (string) Utils.Clone((object) this.m_mdnsServerName);
    discoveryConfiguration.m_serverCapabilities = (StringCollection) Utils.Clone((object) this.m_serverCapabilities);
    return (object) discoveryConfiguration;
  }
}
